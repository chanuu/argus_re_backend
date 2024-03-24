using Argus.Platform.Core.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

using Argus.Platform.Application.Identity.Users.DTOs;
using Mapster;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;
using System.Text;

namespace Argus.Platform.Application.Identity.Users
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _UserManager;

        private readonly RoleManager<Role> _RoleManager;

        private readonly IConfiguration _Configuration;

        private readonly IPasswordHasher<User> _PasswordHasher;

        const int MINIMUM_PASSWORD_LENGTH = 8;

       // private HttpContext _HttpContext;

        public UserService(UserManager<User> userManager, RoleManager<Role> roleManager, IConfiguration configuration, IPasswordHasher<User> passwordHasher)
        {
            _UserManager = userManager;
            _RoleManager = roleManager;
            _Configuration = configuration;
            _PasswordHasher = passwordHasher;
          //  _HttpContext = httpContext;
        }


        public Task AddRoleAsync(AddToRoleDto request)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> ChangePassword(ChangeUserPasswordDto request)
        {
            if (request.NewPassword != request.NewPasswordConfrimed)
            {
                return IdentityResult.Failed(new IdentityError { Description = "New Password And Confirm Password Does Not Match" });
            }

            var user = await _UserManager.FindByIdAsync(request.UserId);

            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Cannot Find User With Given ID" });
            }

            return await _UserManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
        }

        public async Task<IdentityResult> CreateAsync(CreateUserDto request)
        {
            if (!IsPasswordValid(request.Password))
            {
                throw new Exception("Password does not meet the criteria!");
            }

            var _User = await _UserManager.FindByNameAsync(request.UserName);
            //If it is not found, then search by email
            if (_User == null)

                _User = await _UserManager.FindByEmailAsync(request.Email);

            // map dto to user model using automapper helper 
          
            var mappedUser = request.Adapt<User>();


            var result = await _UserManager.CreateAsync(mappedUser, request.Password);

            if (!result.Succeeded)
            {

                return result;
            }
            else
            {
                //Add Send email to Hangfirne background task 
               // BackgroundJob.Enqueue(() => SendUserCreatedAlrt(request.Email, request.UserName, request.Password));
                return result;
            }
        }

        public async Task DeleteUser(DeleteUserDto request)
        {
            var user = await _UserManager.FindByIdAsync(Convert.ToString(request.Id));
            // todo: need to do null check 
            await _UserManager.DeleteAsync(user);
        }

        public async Task<bool> GenaratePasswordResetToken(GenaratePasswordResetTokenDto input)
        {
            var user = await _UserManager.FindByEmailAsync(input.Email);

            switch (user)
            {
                case null:
                    throw new Exception("No Account Found With Given Email Address");
                default:
                    var token = await _UserManager.GeneratePasswordResetTokenAsync(user);
                    //todo : implement send mail function to password reset email
                    break;
            }

            return true;
        }

        public Task<UserDetailsDto> GetAsync(string id)
        {
            var _user = _UserManager.FindByIdAsync(id);
            if (_user is not null)
            {
                var mappedUser = _user.Adapt<UserDetailsDto>();
                return Task.FromResult(mappedUser);
            }
            else
            {
                return null;
            }
        }

        public async Task<User> GetExistingUser(LoginInputDto request)
        {
            var user = await _UserManager.FindByNameAsync(request.UserName);

            if (user is null)
            {
                return null;
            }

            return user;
        }

        public Task<List<UserDetailsDto>> GetListAsync()
        {
            var users = _UserManager.Users;
            // map users list to userlistdto using automapper helper
            var mappedList = users.Adapt<List<UserDetailsDto>>();

            return Task.FromResult(mappedList);
        }

        public async Task<LoginResponseDto> Login(LoginInputDto Request)
        {
            var User = await GetExistingUser(Request);

            if(User is null)
            {
                throw new Exception("User Name Or Password Is Incorrect !");
            }

            if (User.IsActive == false)
            {
                return null;
            }

          
            var result = await _UserManager.CheckPasswordAsync(User, Request.Password);
           
            if (result == true)
            {

                var Claim = await _UserManager.GetClaimsAsync(User.Adapt<User>());
                var Role = await _UserManager.GetRolesAsync(User.Adapt<User>());
                Console.WriteLine($"User Claimss Retrieved is: {string.Join(", ", Claim)}");
                Console.WriteLine($"User Roles Retrieved is: {string.Join(", ", Role)}");
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, User.UserName),
                    new Claim(ClaimTypes.NameIdentifier, User.Id),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())

                };


                foreach (var _roleName in Role)
                {
                    var currentRole = await _RoleManager.FindByNameAsync(_roleName);

                    if (currentRole != null)
                    {
                        var _claimList = await _RoleManager.GetClaimsAsync(currentRole);

                        foreach (var _claim in _claimList)
                        {
                            authClaims.Add(new Claim(_claim.Type, _claim.Value));
                            Console.WriteLine($"Claims for role {_roleName}: {string.Join(", ", _claimList.Select(c => $"{c.Type}: {c.Value}"))}");
                        }
                    }
                }

                
                // ToDo : need to move token genration logic to token service 
                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Configuration["JWT:Secret"]));

                Console.WriteLine("accessToken Section starting");
                var accessToken = new JwtSecurityToken(

                    issuer: _Configuration["JWT:ValidIssuer"],
                    audience: _Configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddSeconds(Convert.ToDouble(_Configuration["JWT:lifetime"])),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

                // Generate Refresh Token
                Console.WriteLine("refreshSigningKey Section starting");
                var refreshSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Configuration["JWT:RefreshSecret"]));

                Console.WriteLine("refreshToken Section starting");

                var refreshToken = new JwtSecurityToken(
                    issuer: _Configuration["JWT:ValidIssuer"],
                    audience: _Configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddSeconds(Convert.ToDouble(_Configuration["JWT:refreshTokenLifetime"])),
                    signingCredentials: new SigningCredentials(refreshSigningKey, SecurityAlgorithms.HmacSha256)
                );

                Console.WriteLine("loginResponse Section starting");
                var loginResponse = new LoginResponseDto
                {
                    AccessToken = new JwtSecurityTokenHandler().WriteToken(accessToken),
                    AccessTokenValidUntil = accessToken.ValidTo,
                    RefreshToken = new JwtSecurityTokenHandler().WriteToken(refreshToken),
                    RefreshTokenValidUntil = refreshToken.ValidTo,
                    User = new UserDetailsDto
                    {
                        UserName = User.UserName,
                        Email = User.Email
                        //Name = User.Name,
                        //Image = User.Image,
                        //AboutMe = User.AboutMe,
                        //Id = User.Id,
                        //RoleId = User.RoleId,
                        //CompanyId = User.CompanyId,
                        //BranchId = User.BranchId,
                        //PartnerId = User.PartnerId,
                    }
                };

                Console.WriteLine("loginResponse Section Ended");
                return loginResponse;
            }
            else
            {
                return null;
            }
        }

        public RefreshTokenResponseDto RefreshToken(string refreshToken)
        {
            try
            {
                // Validate the refresh token
                var refreshValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = _Configuration["JWT:ValidIssuer"],
                    ValidAudience = _Configuration["JWT:ValidAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Configuration["JWT:RefreshSecret"])),
                    ValidateLifetime = false, // We handle expiration manually
                };

                Console.WriteLine("refreshValidationParameters defined.");

                var handler = new JwtSecurityTokenHandler();
                Console.WriteLine("handler defined.");

                ClaimsPrincipal claimsPrincipal = handler.ValidateToken(refreshToken, refreshValidationParameters, out SecurityToken validatedToken);
                Console.WriteLine("ClaimsPrincipal defined.");


                // Check if the refresh token is expired
                if (validatedToken is JwtSecurityToken jwtSecurityToken && jwtSecurityToken.ValidTo < DateTime.UtcNow)
                {
                    // Refresh token is expired, return an error in the RefreshTokenResponseDto
                    return new RefreshTokenResponseDto
                    {
                        ErrorMessage = "Refresh token expired",
                    };
                }
                Console.WriteLine("refresh token is expired Check done.");

                // Generate a new access token (similar to your previous code)
                var authClaims = new List<Claim> { /* Add your claims here */ };
                var token = "";//_HttpContext.Request.Headers["Authorization"];
                token = token.ToString().Substring("Bearer ".Length).Trim();
                var principle = GetPrincipalFromExpiredToken(token);

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Configuration["JWT:Secret"]));
                var accessToken = new JwtSecurityToken(
                    issuer: _Configuration["JWT:ValidIssuer"],
                    audience: _Configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddSeconds(Convert.ToDouble(_Configuration["JWT:lifetime"])),
                    claims: principle.Claims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

                // Return the new access token
                return new RefreshTokenResponseDto
                {
                    AccessToken = new JwtSecurityTokenHandler().WriteToken(accessToken),
                    AccessTokenValidUntil = DateTime.Now.AddSeconds((int)TimeSpan.FromSeconds(Convert.ToDouble(_Configuration["JWT:lifetime"])).TotalSeconds),
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during RefreshAccessToken: {ex}");

                return new RefreshTokenResponseDto
                {
                    ErrorMessage = "Invalid refresh token",
                };
            }
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var Key = Encoding.UTF8.GetBytes(_Configuration["JWT:Secret"]);

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Key),
                ClockSkew = TimeSpan.Zero
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            JwtSecurityToken jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }

            return principal;
        }
        public async Task<IdentityResult> ResetPasswordWithToken(ForgetPasswordDto input)
        {

            var user = await _UserManager.FindByEmailAsync(input.Email);


            if (user != null)
            {
                var result = await _UserManager.ResetPasswordAsync(user, input.ResetCode, input.NewPassword);
                return result;

            }
            else
            {
                return null;
            }

        }

        public async Task<IdentityResult> UpdateAsync(UpdateUserDto request)
        {
            var user = await _UserManager.FindByNameAsync(request.UserName);


            if (user == null)
            {
                // Handle error when user is not found
                return IdentityResult.Failed(new IdentityError { Description = "User not found." });
            }

            // Update the properties of the existing user entity
            user.UserName = request.UserName;
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;
            user.PhoneNumber = request.PhoneNumber;

            // Save the changes to the database
            var result = await _UserManager.UpdateAsync(user);

            return result;
        }

        private bool IsPasswordValid(string password)
        {
            // Check password length and character requirements
            return password.Length >= MINIMUM_PASSWORD_LENGTH && ContainsAllCharacters(password);
        }

        private bool ContainsAllCharacters(string password)
        {
            // Check if password contains all required characters (e.g., lowercase, uppercase, digits, etc.)
            return password.Any(char.IsLower) &&
                   password.Any(char.IsUpper) &&
                   password.Any(char.IsDigit);
        }
    }
}
