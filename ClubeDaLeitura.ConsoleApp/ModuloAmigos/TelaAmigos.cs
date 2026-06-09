using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigos;

public class TelaAmigos : TelaBase
{
    private readonly RepositorioAmigos repositorioAmigos;

    public TelaAmigos(string nomeEntidade, RepositorioAmigos repositorioAmigos) : base(nomeEntidade, repositorioAmigos)
    {
        this.repositorioAmigos = repositorioAmigos;
    }

    public void Editar()
    {
        Console.WriteLine("------------------------");
        Console.WriteLine("Edição de Amigo");
        Console.WriteLine("------------------------");

        VisualizarTodos(false);

        Console.WriteLine("------------------------");
        Console.Write("Digite o ID do registro que deseja editar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("------------------------");

        Amigos amigoAtualizado = ObterDadosCadastrais();

        repositorioAmigos.Editar(idSelecionado, amigoAtualizado);

        Console.WriteLine("------------------------");
        Console.WriteLine($"O registro \"{amigoAtualizado.Nome}\" foi atualizado com sucesso.");
        Console.WriteLine("------------------------");
        Console.WriteLine("Digite ENTER para continuar...");
        Console.ReadLine();
    }

    public void Excluir()
    {
        Console.WriteLine("------------------------");
        Console.WriteLine("Exclusão de Amigo");
        Console.WriteLine("------------------------");

        VisualizarTodos(false);

        Console.WriteLine("------------------------");
        Console.Write("Digite o ID do registro que deseja excluir: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        repositorioAmigos.Excluir(idSelecionado);

        Console.WriteLine("------------------------");
        Console.WriteLine($"O registro de ID \"{idSelecionado}\" foi excluído com sucesso.");
        Console.WriteLine("------------------------");
        Console.WriteLine("Digite ENTER para continuar...");
        Console.ReadLine();
    }
    public void VisualizarTodos(bool deveExibirCabecalho)
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
