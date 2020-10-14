using System;
using Microsoft.AspNetCore.Mvc;
using CadastroWebApi.Data;
using System.Threading.Tasks;
using CadastroWebApi.Models;

namespace CadastroWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IRepositorio Repositorio;

        public ClienteController(IRepositorio Repositorio)
        {
            this.Repositorio = Repositorio;
        }

        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await Repositorio.GetAllClientesAsync();
                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{clienteId}")]
        public async Task<IActionResult> GetById(long clienteId)
        {
            try
            {
                var result = await Repositorio.GetClienteByIdAsync(clienteId);
                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Cliente clienteModelo)
        {
            try
            {
                Repositorio.Add(clienteModelo);

                var result = await Repositorio.SaveChangesAsync(); 

                if(!result)
                    throw new Exception("Falha ao Salvar");

                return Ok(clienteModelo);

            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{clienteId}")]
        public async Task<IActionResult> Put(long clienteId, Cliente clienteModelo)
        {
            try
            {
                var cliente = await Repositorio.GetClienteByIdAsync(clienteId);
                if(cliente == null) return NotFound();

                Repositorio.Update(clienteModelo);

                var result = await Repositorio.SaveChangesAsync(); 

                if(!result)
                    throw new Exception("Falha ao Salvar");

                return Ok(clienteModelo);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{clienteId}")]
        public async Task<IActionResult> Delete(long clienteId)
        {
            try
            {
                var cliente = await Repositorio.GetClienteByIdAsync(clienteId);
                if(cliente == null) return NotFound();

                Repositorio.Delete(cliente);

                var result = await Repositorio.SaveChangesAsync(); 

                if(!result)
                    throw new Exception("Falha ao Salvar");

                return Ok("Removido");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}