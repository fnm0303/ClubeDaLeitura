using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.Utilidades;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista;

public enum StatusRevista
{
    Disponivel,
    Emprestada
}

/*
● Campos obrigatórios:
○ Título (2-100 caracteres)
○ Número da edição (número positivo)
○ Ano de publicação (data válida)
○ Caixa (seleção obrigatória)
● Não pode haver revistas com mesmo título e edição
- O sistema deve armazenar e mostrar o status atual das revistas cadastradas
*/
public class Revista : EntidadeBase
{
    public string Titulo { get; private set; }
    public int NumeroEdicao { get; private set; }
    public int AnoPublicacao { get; private set; }
    public StatusRevista Status { get; private set; }
    public Caixa Caixa { get; private set; }

    public bool EstaDisponivel
    {
        get
        {
            return Status == StatusRevista.Disponivel;
        }
    }

    public Revista(string titulo, int numeroEdicao, int anoPublicacao, Caixa caixa)
    {
        Id = GeradorDeIds.ObterIdRevista();
        Titulo = titulo;
        NumeroEdicao = numeroEdicao;
        AnoPublicacao = anoPublicacao;
        Caixa = caixa;

        Status = StatusRevista.Disponivel;
    }

    public void Emprestar()
    {
        Status = StatusRevista.Emprestada;
    }

    public void Devolver()
    {
        Status = StatusRevista.Disponivel;
    }

    public override void Atualizar(EntidadeBase entidadeAtualizada)
    {
        Revista revistaAtualizada = (Revista)entidadeAtualizada;

        Titulo = revistaAtualizada.Titulo;
        NumeroEdicao = revistaAtualizada.NumeroEdicao;
        AnoPublicacao = revistaAtualizada.AnoPublicacao;
        Caixa = revistaAtualizada.Caixa;
    }
}
