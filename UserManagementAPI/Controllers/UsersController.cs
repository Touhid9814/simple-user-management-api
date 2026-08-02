using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Models;

namespace UserManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private static readonly List<User> Users = new();

    [HttpGet]
    public ActionResult<IEnumerable<User>> GetUsers()
    {
        try
        {
            return Ok(Users);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Unable to retrieve users.", error = ex.Message });
        }
    }

    [HttpGet("{id:int}")]
    public ActionResult<User> GetUser(int id)
    {
        try
        {
            var user = Users.FirstOrDefault(u => u.Id == id);
            return user is null ? NotFound(new { message = $"User with id {id} was not found." }) : Ok(user);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Unable to retrieve user.", error = ex.Message });
        }
    }

    [HttpPost]
    public ActionResult<User> CreateUser([FromBody] User user)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            user.Id = Users.Count + 1;
            Users.Add(user);
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Unable to create user.", error = ex.Message });
        }
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateUser(int id, [FromBody] User updatedUser)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            var user = Users.FirstOrDefault(u => u.Id == id);
            if (user is null)
            {
                return NotFound(new { message = $"User with id {id} was not found." });
            }

            user.Name = updatedUser.Name;
            user.Email = updatedUser.Email;
            user.Department = updatedUser.Department;
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Unable to update user.", error = ex.Message });
        }
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteUser(int id)
    {
        try
        {
            var user = Users.FirstOrDefault(u => u.Id == id);
            if (user is null)
            {
                return NotFound(new { message = $"User with id {id} was not found." });
            }

            Users.Remove(user);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Unable to delete user.", error = ex.Message });
        }
    }
}
