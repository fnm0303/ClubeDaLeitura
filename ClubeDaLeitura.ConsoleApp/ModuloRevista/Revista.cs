using ClubeDaLeitura.ConsoleApp.ModuloCaixa;

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
    public string Titulo { get; private set; }
    public int NumeroEdicao { get; private set; }
    public DateTime AnoPublicacao { get; private set; }
    public Caixa caixa;

    public Revista(string titulo, int numeroEdicao, DateTime anoPublicacao, Caixa caixa)
    {
        Titulo = titulo;
        NumeroEdicao = numeroEdicao;
        AnoPublicacao = anoPublicacao;
        this.caixa = caixa;
    }
}
