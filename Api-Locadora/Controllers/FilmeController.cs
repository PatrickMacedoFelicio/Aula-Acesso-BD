using Api_Locadora.Models;
using Api_Locadora.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;
using Api_Locadora.DbContext;
using System.Collections.Generic;

namespace Api_Locadora.Controllers
{
    [Route("Filmes")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        //[HttpGet("Filmes")] -> para ficar /Filmes/Filmes
        [HttpGet]
        public IActionResult Buscar()
        {
            return Ok(Listar.Filmes);
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] FilmeDto item)
        {
            var filme = new Filme();
            filme.Titulo = item.Titulo;
            filme.Diretor = item.Diretor;
            filme.Ano_Lancamento = item.Ano_Lancamento;
            filme.Diretor = item.Diretor;
            filme.Genero = item.Genero;
            filme.Estudio = item.Estudio;
            filme.IMDB = item.IMDB;

            Listar.Filmes.Add(filme);

            return Ok(filme);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(Guid id, [FromBody] FilmeDto item)
        {
            int indice = Listar.Filmes.FindIndex(p => p.Id == id);

            if (indice != -1)
            {
                foreach (Filme fil in Listar.Filmes)
                {
                    if (fil.Id == id)
                    {
                        fil.Titulo = item.Titulo;
                        fil.Diretor = item.Diretor;
                        fil.Ano_Lancamento = item.Ano_Lancamento;
                        fil.Diretor = item.Diretor;
                        fil.IMDB = item.IMDB;
                        fil.Estudio = item.Estudio;
                        fil.Genero = item.Genero;
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
            int indice = Listar.Filmes.FindIndex(p => p.Id == id); // Percore todo o Listar Filme com até encontrar o indicado, caso ele encontre ele pegar as informações e ficar fora do padrão de -1

            if (indice != -1)
            {
                Listar.Filmes.RemoveAt(indice);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
