using Api_Locadora.Models;
using Api_Locadora.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;
using Api_Locadora.DbContext;
using System.Collections.Generic;

namespace Api_Locadora.Controllers
{
    [Route("Genero")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        //[HttpGet("Filmes")] -> para ficar /Filmes/Filmes
        [HttpGet]
        public IActionResult Buscar()
        {
            return Ok(Listar.Generos);
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] GeneroDto item)
        {
            var gen = new Genero();
            gen.Nome = item.Nome;

            Listar.Generos.Add(gen);

            return Ok(gen);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(Guid id, [FromBody] GeneroDto item)
        {
            int indice = Listar.Generos.FindIndex(p => p.Id == id);

            if (indice != -1)
            {
                foreach (Genero gen in Listar.Generos)
                {
                    if (gen.Id == id)
                    {
                        gen.Nome = item.Nome;
                    }
                }
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }


        // verificar se o ID existe

        [HttpDelete("{id}")]
        public IActionResult Remover(Guid id)
        {
            int indice = Listar.Generos.FindIndex(p => p.Id == id); // Percore todo o Listar Filme com até encontrar o indicado, caso ele encontre ele pegar as informações e ficar fora do padrão de -1

            if (indice != -1)
            {
                Listar.Generos.RemoveAt(indice);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
