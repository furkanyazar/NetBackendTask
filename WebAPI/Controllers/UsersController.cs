using Business.Abstract;
using Core.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : BaseController
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetDetails()
    {
        UserGetByIdDto userDto = await _userService.GetByIdDtoAsync(getUserIdFromRequest());
        return Ok(userDto);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateUserDto updateUserDto)
    {
        UpdatedUserDto updatedUser = await _userService.UpdateAsync(getUserIdFromRequest(), updateUserDto);
        return Ok(updatedUser);
    }
}
