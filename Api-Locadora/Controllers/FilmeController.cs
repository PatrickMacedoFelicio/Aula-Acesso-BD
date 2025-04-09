using Api_Locadora.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Api_Locadora.Controllers
{
    [Route("Filmes")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private static List<Filme> ListarFilmes = [
            new Filme() {
                Nome = "Jogos Vorazes",
                Genero = "Ação"
            },
            new Filme() {
                Nome = "Turma da Monica",
                Genero = "Animação"
            }
        ];

        //[HttpGet("Filmes")] -> para ficar /Filmes/Filmes
        [HttpGet]
        public IActionResult Buscar()
        {
            return Ok(ListarFilmes);
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] FilmeDto item)
        {
            var filme = new Filme();
            filme.Nome = item.Nome;
            filme.Genero = item.Genero;

            ListarFilmes.Add(filme);

            return Ok(filme);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(Guid id, [FromBody] FilmeDto item)
        {
            Filme update = new Filme();

            foreach (Filme fil in ListarFilmes)
            {
                if (fil.Id == id)
                {
                    fil.Nome = item.Nome;
                    fil.Genero = item.Genero;

                    update.Nome = item.Nome;
                }
            }

            if (update != null) { return Ok(); }
            else { return NotFound(); }

        }


        // verificar se o ID existe

        [HttpDelete("{id}")]
        public IActionResult Remover(Guid id)
        {
            return Ok();
        }
    }
}
