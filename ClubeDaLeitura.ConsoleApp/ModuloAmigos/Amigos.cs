using ClubeDaLeitura.ConsoleApp.Utilidades;
namespace ClubeDaLeitura.ConsoleApp.ModuloAmigos;

public class Amigos
{
    public int Id { get; set; }
    public string Nome { get; private set; }
    public string NomeResponsavel { get; private set; }
    public int Telefone { get; private set; }

    public Amigos(string nome, string nomeResponsavel, int telefone)
    {
        Id = GeradorDeIds.ObterIdAmigo();
        Nome = nome;
        NomeResponsavel = nomeResponsavel;
        Telefone = telefone;
    }
}
