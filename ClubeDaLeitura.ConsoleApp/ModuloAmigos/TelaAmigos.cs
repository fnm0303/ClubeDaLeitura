namespace ClubeDaLeitura.ConsoleApp.ModuloAmigos;

public class TelaAmigos
{
    private readonly RepositorioAmigos repositorioAmigos;
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

        Amigos[] amigos = repositorioAmigos.SelecionarTodos();

        repositorioAmigos.Cadastrar(novoAmigo);

        Console.WriteLine($"O registro \"{novoAmigo.Nome}\" foi cadastrado com sucesso.");
        Console.WriteLine("------------------------");
        Console.WriteLine("Digite ENTER para continuar...");
        Console.ReadLine();
    }

    public void Editar()
    {

    }

    public void Excluir()
    {

    }
    public void VisualizarTodos()
    {

    }

    private Amigos ObterDadosCadastrais()
    {
        Console.Write("Informe o nome do amigo: ");
        string nome = Console.ReadLine();

        Console.Write("Informe o nome do responsável: ");
        string nomeResponsavel = Console.ReadLine();

        Console.Write("Informe o telefone do amigo (somente números): ");
        int telefone = Convert.ToInt32(Console.ReadLine());

        Amigos novoAmigo = new Amigos(nome, nomeResponsavel, telefone);

        return novoAmigo;
    }
}
