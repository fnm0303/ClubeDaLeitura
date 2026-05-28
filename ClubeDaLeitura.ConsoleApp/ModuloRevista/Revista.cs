using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.Utilidades;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista;

/*
● Campos obrigatórios:
○ Título (2-100 caracteres)
○ Número da edição (número positivo)
○ Ano de publicação (data válida)
○ Caixa (seleção obrigatória)
● Não pode haver revistas com mesmo título e edição
*/
public class Revista
{
    public int Id { get; private set; }
    public string Titulo { get; private set; }
    public int NumeroEdicao { get; private set; }
    public int AnoPublicacao { get; private set; }
    public Caixa Caixa { get; private set; }

    public Revista(string titulo, int numeroEdicao, int anoPublicacao, Caixa caixa)
    {
        Id = GeradorDeIds.ObterIdRevista();
        Titulo = titulo;
        NumeroEdicao = numeroEdicao;
        AnoPublicacao = anoPublicacao;
        Caixa = caixa;
    }

    public void Atualizar(Revista revistaAtualizada)
    {
        Titulo = revistaAtualizada.Titulo;
        NumeroEdicao = revistaAtualizada.NumeroEdicao;
        AnoPublicacao = revistaAtualizada.AnoPublicacao;
        Caixa = revistaAtualizada.Caixa;
    }
}
