using DemoAPI5.Data;
using DemoAPI5.Models;
using DemoAPI5.InputModels;
using DemoAPI5.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DemoAPI5.Controllers
{
    public class UsuarioController : ControllerBase
    {
        [HttpGet("/usuarios")]
        public IActionResult Get([FromServices] DemoDataContext context)
        {
            try
            {
                var usuarios = context.Usuarios.ToList();
                var usuariosViewModel = usuarios
                 .Select(u => new UsuarioViewModel()
                 {
                     Id = u.Id,
                     Nome = u.Nome,
                     Email = u.Email,
                     DataCriacao = u.DataCriacao,
                     Admin = u.Admin
                 }).ToList();

                return Ok(usuariosViewModel);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Falha interna no servidor");
            }
        }

        [HttpGet("/usuarios/{id:int}")]
        public IActionResult
            GetById([FromRoute] int id, [FromServices] DemoDataContext context)
        {
            try
            {
                var usuario = context.Usuarios.FirstOrDefault(x => x.Id == id);

                if (usuario == null)
                    return NotFound("Usuario não encontrada!");

                return Ok(new UsuarioViewModel(usuario));
            }
            catch (Exception e)
            {
                return StatusCode(500, "Falha interna no servidor");
            }
        }

        [HttpPost("/usuarios")]
        public IActionResult Post([FromBody] AddUsuarioInputModel model, [FromServices] DemoDataContext context)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var usuario = new Usuario()
                {
                    Nome = model.Nome,
                    Email = model.Email,
                    Senha = model.Senha,
                    Admin = model.Admin,
                };

                context.Usuarios.Add(usuario);
                context.SaveChanges();

                return Created($"usuarios/{usuario.Id}", usuario);
            }
            catch (DbUpdateException e)
            {
                return BadRequest("Não foi possivel incluir o Usuario");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Não foi possivel incluir o Usuario");
            }
        }

        [HttpPut("/usuarios/{id:int}")]
        public  IActionResult
            Put([FromRoute] int id, [FromBody] UpdateUsuarioInputModel model, [FromServices] DemoDataContext context)
        {
            try
            {
                var usuario = context.Usuarios.FirstOrDefault(x => x.Id == id);

                if (usuario == null)
                    return NotFound("Usuario não encontrado!");

                usuario.Nome = model.Nome;
                usuario.Email = model.Email;
                usuario.Admin = model.Admin;

                context.Usuarios.Update(usuario);
                context.SaveChanges();

                return Ok(new UsuarioViewModel(usuario));
            }
            catch (DbUpdateException e)
            {
                return BadRequest("Não foi possivel incluir o Usuario");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Não foi possivel incluir o Usuario");
            }
        }

        [HttpDelete("/usuarios/{id:int}")]
        public IActionResult
            Delete([FromRoute] int id, [FromServices] DemoDataContext context)
        {
            try
            {
                var usuario = context.Usuarios.FirstOrDefault(x => x.Id == id);

                if (usuario == null)
                    return NotFound("Usuario não encontrado!");

                context.Usuarios.Remove(usuario);
                context.SaveChanges();

                return Ok(new UsuarioViewModel(usuario));
            }
            catch (DbUpdateException e)
            {
                return BadRequest("Não foi possivel incluir o Usuario");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Não foi possivel incluir o Usuario");
            }
        }
    }
}
