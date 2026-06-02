namespace ClubeDaLeitura.ConsoleApp.ModuloAmigos;

public class TelaAmigos
{
    private readonly RepositorioAmigos repositorioAmigos;

    public TelaAmigos(RepositorioAmigos repositorioAmigos)
    {
        this.repositorioAmigos = repositorioAmigos;
    }
    public string? ObterOpcaoMenu()
    {
        Console.WriteLine("------------------------");
        Console.WriteLine("Gestão de Amigos");
        Console.WriteLine("------------------------");
        Console.WriteLine("1 - Cadastrar amigo");
        Console.WriteLine("2 - Editar amigo");
        Console.WriteLine("3 - Excluir amigo");
        Console.WriteLine("4 - Visualizar amigo");
        Console.WriteLine("S - Sair");
        Console.WriteLine("------------------------");
        Console.Write("> ");
        string? opcaoMenuInterno = Console.ReadLine()?.ToUpper();

        return opcaoMenuInterno;
    }

    public void Cadastrar()
    {
        Console.WriteLine("------------------------");
        Console.WriteLine("Cadastro de Amigos");
        Console.WriteLine("------------------------");

        Amigos novoAmigo = ObterDadosCadastrais();

        repositorioAmigos.Cadastrar(novoAmigo);

        Console.WriteLine($"O registro \"{novoAmigo.Nome}\" foi cadastrado com sucesso.");
        Console.WriteLine("------------------------");
        Console.WriteLine("Digite ENTER para continuar...");
        Console.ReadLine();
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

        Amigos[] registros = repositorioAmigos.SelecionarTodos();

        for (int i = 0; i < registros.Length; i++)
        {
            Amigos a = registros[i];
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

    private Amigos ObterDadosCadastrais()
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
