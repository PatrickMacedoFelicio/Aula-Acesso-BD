using ApiLocadora.DataContexts;
using ApiLocadora.Dtos;
using ApiLocadora.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiLocadora.Services
{
    public class FilmeServices
    {
        private readonly AppDbContext _context;

        public FilmeServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Filme>> GetAll()
        {
            var list = await _context.Filmes
                .Include(e=>e.Estudio)
                .Select(e=> new
                {
                    e.Id,
                    e.Nome,
                })
                .ToListAsync();

            return list;
        }

        public async Task<Filme?> GetOneById(int id)
        {
            try
            {
                return await _context.Filmes.SingleOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Filme?> Create(FilmeDto filmeItem)
        {
            try
            {
                var data = filmeItem.AnoLancamento;

                var filme = new Filme
                {
                    Nome = filmeItem.Nome,
                    Genero = filmeItem.Genero,
                    AnoLancamento = filmeItem.AnoLancamento
                };

                await _context.Filmes.AddAsync(filme);
                await _context.SaveChangesAsync();

                return filme;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Filme?> Update(int id, FilmeDto filmeItem)
        {
            try
            {
                var _filmes = await GetOneById(id);

                if (_filmes == null)
                {
                    return _filmes;
                }

                _filmes.Nome = filmeItem.Nome;
                _filmes.Genero = filmeItem.Genero;
                _filmes.AnoLancamento = filmeItem.AnoLancamento;

                _context.Filmes.Update(_filmes);
                await _context.SaveChangesAsync();

                return _filmes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Filme?> Delete(int id)
        {
            return null;
        }

        private async Task<bool> ExisteId(int filmeId)
        {
            return await _context.Filmes.AnyAsync(c => c.Id == filmeId);
        }
    }
}
