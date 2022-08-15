using DemoAPI5.Data;
using DemoAPI5.InputModels;
using DemoAPI5.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DemoAPI.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet("")]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpPost("/login")]
        public IActionResult Login(
        [FromBody] LoginInputModel model,
        [FromServices] DemoDataContext context,
        [FromServices] TokenService tokenService)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user = context
                .Usuarios
                .AsNoTracking()
                .FirstOrDefault(x => x.Email == model.Email);

            if (user == null)
                return StatusCode(401, "Usuário ou senha inválidos");

            if (user.Senha != model.Senha)
                return StatusCode(401, "Usuário ou senha inválidos");

            try
            {
                var token = tokenService.GenerateToken(user);
                return Ok(token);
            }
            catch
            {
                return StatusCode(500, "Falha interna no servidor");
            }
        }
    }
}
