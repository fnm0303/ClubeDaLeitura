using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.Utilidades;
namespace ClubeDaLeitura.ConsoleApp.ModuloAmigos;

public class Amigos : EntidadeBase
{
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

    public override void Atualizar(EntidadeBase entidadeAtualizada)
    {
        Amigos amigoAtualizado = (Amigos)entidadeAtualizada;

        Nome = amigoAtualizado.Nome;
        NomeResponsavel = amigoAtualizado.NomeResponsavel;
        Telefone = amigoAtualizado.Telefone;
    }
}
