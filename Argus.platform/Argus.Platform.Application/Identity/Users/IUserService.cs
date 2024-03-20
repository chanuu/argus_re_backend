
using Argus.Platform.Application.Identity.Users.DTOs;
using Argus.Platform.Core.Common;
using Argus.Platform.Core.Identity;
using Microsoft.AspNetCore.Identity;

namespace Argus.Platform.Application.Identity.Users
{
    public interface IUserService :ITransientService
    {
        Task<List<UserDetailsDto>> GetListAsync();


        Task<UserDetailsDto> GetAsync(string id);

        Task<IdentityResult> CreateAsync(CreateUserDto request);

        Task<IdentityResult> UpdateAsync(UpdateUserDto request);

        Task<IdentityResult> ChangePassword(ChangeUserPasswordDto request);
        Task<LoginResponseDto> Login(LoginInputDto Request);

        RefreshTokenResponseDto RefreshToken(string refreshToken);
        Task<User> GetExistingUser(LoginInputDto Request);

        Task DeleteUser(DeleteUserDto request);

        Task<bool> GenaratePasswordResetToken(GenaratePasswordResetTokenDto input);

        Task<IdentityResult> ResetPasswordWithToken(ForgetPasswordDto input);

        Task AddRoleAsync(AddToRoleDto request);
    }
}
