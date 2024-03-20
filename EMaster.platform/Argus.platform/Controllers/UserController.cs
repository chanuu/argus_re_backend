using Argus.Platform.Application.Identity.Users;
using Argus.Platform.Application.Identity.Users.DTOs;
using Argus.Platform.Contract.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Argus.Platform.Controllers
{
    [ApiController]
  
    public class UserController : Controller
    {

        private IUserService _UserService { get; set; }

        public UserController(IUserService userService)
        {
            _UserService = userService;

        }

        [HttpPost(ApiRoutes.User.Register)]
        public async Task<IActionResult> Register([FromBody] CreateUserDto request)
        {
            var result = await _UserService.CreateAsync(request);


            if (!result.Succeeded)
            {
                return StatusCode(500, result.Errors.ToList());
            }


            return Ok("User created successfully.");

        }

     
        [HttpPost(ApiRoutes.User.Login)]
        public async Task<IActionResult> Login([FromBody] LoginInputDto request)
        {
            var user = await _UserService.Login(request);
            return Ok(user);

        }

        [HttpPut(ApiRoutes.User.Update)]
        public async Task<IActionResult> Update([FromBody] UpdateUserDto request)
        {
            var result = await _UserService.UpdateAsync(request);

            if (!result.Succeeded)
            {
                return StatusCode(500, result.Errors.ToList());
            }


            return Ok("User created successfully.");

        }


        [HttpPost(ApiRoutes.User.ChangePassword)]
        public async Task<IActionResult> ChangePassword([FromBody] ChangeUserPasswordDto request)
        {
            var result = await _UserService.ChangePassword(request);

            if (!result.Succeeded)
            {
                return StatusCode(500, result.Errors.ToList());
            }


            return Ok("User Password Update successfully.");

        }

        [HttpPost(ApiRoutes.User.GenaratePasswordResetToken)]
        public async Task<IActionResult> GenaratePasswordResetToken([FromBody] GenaratePasswordResetTokenDto request)
        {
            var result = await _UserService.GenaratePasswordResetToken(request);

            if (!result == true)
            {
                return StatusCode(500, "Password Reset Token Genration Failed !");
            }


            return Ok("Password Reset Token Genration successfully.");

        }

        [HttpGet(ApiRoutes.User.GetAll)]
        public async Task<ActionResult<List<UserDetailsDto>>> GetUsers()
        {


            return Ok(await _UserService.GetListAsync());
        }


        [HttpPost(ApiRoutes.User.ResetPasswordWithToken)]
        public async Task<IActionResult> ResetPasswordWithToken([FromBody] ForgetPasswordDto request)
        {
            var result = await _UserService.ResetPasswordWithToken(request);

            if (!result.Succeeded)
            {
                return StatusCode(500, result);
            }


            return Ok("Password Reset Token Genration successfully.");

        }

    }
}
