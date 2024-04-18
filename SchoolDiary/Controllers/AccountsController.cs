using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolDiary.DTOs;
using SchoolDiary.Services;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SchoolDiary.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AccountsController : ControllerBase
	{
		private readonly UserManager<User> _userManager;
		private readonly TokenService _tokenService;
		public AccountsController(UserManager<User> userManager, TokenService tokenService)
		{
			_userManager = userManager;
			_tokenService = tokenService;
		}
		[AllowAnonymous]
		[HttpPost("login")]
		public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDTO)
		{
			try
			{
				var user = await _userManager.FindByEmailAsync(loginDTO.Email);
				if (user == null)
				{
					return Unauthorized();
				}
				var result = await _userManager.CheckPasswordAsync(user, loginDTO.Password);
				if (result)
				{
					return CreateUserObject(user);
				}
				return Unauthorized();
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}
		}
		[AllowAnonymous]
		[HttpPost("register")]
		public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDTO)
		{
			try
			{
				if (await _userManager.Users.AnyAsync(x => x.UserName == registerDTO.Username))
				{
					return BadRequest("Username is already taken");
				}
				if (await _userManager.Users.AnyAsync(x => x.Email == registerDTO.Email))
				{
					return BadRequest("Email is already taken");
				}
				var user = new User
				{
					DisplayName = registerDTO.DisplayName,
					Email = registerDTO.Email,
					UserName = registerDTO.Username
				};

				var result = await _userManager.CreateAsync(user, registerDTO.Password);

				if (result.Succeeded)
				{
					return CreateUserObject(user);
				}

				return BadRequest(result.Errors);
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}
		}

		[Authorize]
		[HttpGet]
		public async Task<ActionResult<UserDTO>> GetCurrentUser()
		{
			try
			{
				var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));
				return CreateUserObject(user);
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}
		}
		private UserDTO CreateUserObject(User user)
		{
			return new UserDTO
			{
				DisplayName = user.DisplayName,
				Image = null,
				Token = _tokenService.CreateToken(user),
				Username = user.UserName,
			};
		}
	}

}
