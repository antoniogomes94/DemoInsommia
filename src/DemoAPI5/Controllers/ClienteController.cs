using DemoAPI5.Data;
using DemoAPI5.Models;
using DemoAPI5.InputModels;
using DemoAPI5.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace DemoAPI5.Controllers
{
    public class ClienteController : ControllerBase
    {
        [Authorize]
        [HttpGet("/clientes")]
        public IActionResult Get([FromServices] DemoDataContext context)
        {
            try
            {
                var clientes = context.Clientes.ToList();
                var usuariosViewModel = clientes
                 .Select(c => new ClienteViewModel()
                 {
                     Id = c.Id,
                     Nome = c.Nome,
                     Email = c.Email,
                     CPF = c.CPF,
                     DataCriacao = c.DataCriacao
                 }).ToList();

                return Ok(usuariosViewModel);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Falha interna no servidor");
            }
        }

        [Authorize]
        [HttpPost("/clientes")]
        public IActionResult Post([FromBody] ClienteInputModel model, [FromServices] DemoDataContext context)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var cliente = new Cliente()
                {
                    Nome = model.Nome,
                    Email = model.Email,
                    CPF = model.CPF.Replace(".", "").Replace("-", "").Trim()
            };

                context.Clientes.Add(cliente);
                context.SaveChanges();

                return Created($"clientes/{cliente.Id}", cliente);
            }
            catch (DbUpdateException e)
            {
                return BadRequest("Não foi possivel incluir o Cliente");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Não foi possivel incluir o Cliente");
            }
        }

        [Authorize]
        [HttpPut("/clientes/{id:int}")]
        public IActionResult
            Put([FromRoute] int id, [FromBody] ClienteInputModel model, [FromServices] DemoDataContext context)
        {
            try
            {
                var cliente = context.Clientes.FirstOrDefault(x => x.Id == id);

                if (cliente == null)
                    return NotFound("Cliente não encontrado!");

                cliente.Nome = model.Nome;
                cliente.Email = model.Email;
                cliente.CPF = model.CPF;

                context.Clientes.Update(cliente);
                context.SaveChanges();

                return Ok(new ClienteViewModel(cliente));
            }
            catch (DbUpdateException e)
            {
                return BadRequest("Não foi possivel incluir o Cliente");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Não foi possivel incluir o Cliente");
            }
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("/clientes/{id:int}")]
        public IActionResult
            Delete([FromRoute] int id, [FromServices] DemoDataContext context)
        {
            try
            {
                var cliente = context.Clientes.FirstOrDefault(x => x.Id == id);

                if (cliente == null)
                    return NotFound("Cliente não encontrado!");

                context.Clientes.Remove(cliente);
                context.SaveChanges();

                return Ok(new ClienteViewModel(cliente));
            }
            catch (DbUpdateException e)
            {
                return BadRequest("Não foi possivel incluir o Cliente");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Não foi possivel incluir o Cliente");
            }
        }
    }
}