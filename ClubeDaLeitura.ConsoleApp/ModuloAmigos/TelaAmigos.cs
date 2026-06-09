using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigos;

public class TelaAmigos : TelaBase
{
    private readonly RepositorioAmigos repositorioAmigos;

    public TelaAmigos(string nomeEntidade, RepositorioAmigos repositorioAmigos) : base(nomeEntidade, repositorioAmigos)
    {
        this.repositorioAmigos = repositorioAmigos;
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
        {
            Console.WriteLine("------------------------");
            Console.WriteLine("Visualização de Amigos");
            Console.WriteLine("------------------------");
        }

        Console.WriteLine("{0, -7} | {1, -20} | {2, -20} | {3, -10}",
                        "Id", "Nome", "Nome do Responsável", "Telefone");

        EntidadeBase[] amigos = repositorioAmigos.SelecionarTodos();

        for (int i = 0; i < amigos.Length; i++)
        {
            Amigos a = (Amigos)amigos[i];
            if (a == null)
                continue;

            Console.WriteLine("{0, -7} | {1, -20} | {2, -20} | {3, -10}",
                            a.Id, a.Nome, a.NomeResponsavel, a.Telefone);
        }

        if (deveExibirCabecalho)
        {
            Console.WriteLine("------------------------");
            Console.WriteLine("Digite ENTER para continuar...");
            Console.ReadLine();
        }
    }

    protected override Amigos ObterDadosCadastrais()
    {
        Console.Write("Informe o nome do amigo: ");
        string? nome = Console.ReadLine();

        Console.Write("Informe o nome do responsável: ");
        string? nomeResponsavel = Console.ReadLine();

        Console.Write("Informe o telefone do amigo (somente números): ");
        long telefone = Convert.ToInt64(Console.ReadLine());

        Amigos novoAmigo = new Amigos(nome, nomeResponsavel, telefone);

        return novoAmigo;
    }
}
