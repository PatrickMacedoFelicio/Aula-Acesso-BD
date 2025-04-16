using Api_Locadora.Models;

namespace Api_Locadora.DbContext
{
    public static class Listar
    {
        public static List<Filme> Filmes = new List<Filme>();
        public static List<Genero> Generos { get; set; } = new List<Genero>();
        public static List<Estudio> Estudios { get; set; } = new List<Estudio>();
    }
}
