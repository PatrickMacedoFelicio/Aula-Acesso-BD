using Api_Locadora.Models;
using Api_Locadora.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;
using Api_Locadora.DbContext;
using System.Collections.Generic;

namespace Api_Locadora.Controllers
{
    [Route("Estudio")]
    [ApiController]
    public class EstudioController : ControllerBase
    {
        //[HttpGet("Filmes")] -> para ficar /Filmes/Filmes
        [HttpGet]
        public IActionResult Buscar()
        {
            return base.Ok(DbContext.DbContext.Estudios);
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] EstudioDto item)
        {
            var estudio = new Estudio();
            
            estudio.Nome = item.Nome;
            estudio.Distribuidor = item.Distribuidor;

            DbContext.DbContext.Estudios.Add(estudio);

            return Ok(estudio);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(Guid id, [FromBody] EstudioDto item)
        {
            int indice = DbContext.DbContext.Estudios.FindIndex(p => p.Id == id);

            if (indice != -1)
            {
                foreach (Estudio est in DbContext.DbContext.Estudios)
                {
                    if (est.Id == id)
                    {
                        est.Nome = item.Nome;
                        est.Distribuidor = item.Distribuidor;
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
            int indice = DbContext.DbContext.Estudios.FindIndex(p => p.Id == id); // Percore todo o Listar Filme com até encontrar o indicado, caso ele encontre ele pegar as informações e ficar fora do padrão de -1

            if (indice != -1)
            {
                DbContext.DbContext.Estudios.RemoveAt(indice);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
