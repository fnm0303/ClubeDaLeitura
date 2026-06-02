using ClubeDaLeitura.ConsoleApp.Utilidades;
namespace ClubeDaLeitura.ConsoleApp.ModuloAmigos;

public class Amigos
{
    public int Id { get; set; }
    public string Nome { get; private set; }
    public string NomeResponsavel { get; private set; }
    public long Telefone { get; private set; }

    public Amigos(string nome, string nomeResponsavel, long telefone)
    {
        Id = GeradorDeIds.ObterIdAmigo();
        Nome = nome;
        NomeResponsavel = nomeResponsavel;
        Telefone = telefone;
    }

    internal void Atualizar(Amigos amigoAtualizado)
    {
        Nome = amigoAtualizado.Nome;
        NomeResponsavel = amigoAtualizado.NomeResponsavel;
        Telefone = amigoAtualizado.Telefone;
    }
}
