using Api_Locadora.Models;
using Api_Locadora.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;
using Api_Locadora.DbContext;
using System.Collections.Generic;
using Api_Locadora.DataContexts;
using Microsoft.EntityFrameworkCore;

namespace Api_Locadora.Controllers
{
    [Route("Filmes")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly AppDbContext _contexto;

        public FilmeController(AppDbContext contexto) { 
            _contexto = contexto;
        }

        //[HttpGet("Filmes")] -> para ficar /Filmes/Filmes
        [HttpGet]
        public async Task<IActionResult> Buscar()
        {
            var listarFilmes = await _contexto.Filmes.ToListAsync();

            return Ok(listarFilmes);
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] FilmeDto item)
        {

            var filme = new Filme
            {
                Titulo = item.Titulo,
                Ano_Lancamento = item.Ano_Lancamento,
                Diretor = item.Diretor,
                IMDB = item.IMDB
            };

            await _contexto.Filmes.AddAsync(filme);
            await _contexto.SaveChangesAsync();

            return Created("", filme);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] FilmeDto item)
        {
            int indice = DbContext.DbContext.Filmes.FindIndex(p => p.Id == id);

            if (indice != -1)
            {
                foreach (Filme fil in DbContext.DbContext.Filmes)
                {
                    if (fil.Id == id)
                    {
                        fil.Titulo = item.Titulo;
                        fil.Diretor = item.Diretor;
                        fil.Ano_Lancamento = item.Ano_Lancamento;
                        fil.Diretor = item.Diretor;
                        fil.IMDB = item.IMDB;
                    }
                }
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }



        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            int indice = DbContext.DbContext.Filmes.FindIndex(p => p.Id == id); // Percore todo o Listar Filme com até encontrar o indicado, caso ele encontre ele pegar as informações e ficar fora do padrão de -1

            if (indice != -1)
            {
                DbContext.DbContext.Filmes.RemoveAt(indice);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
        */
    }
}
