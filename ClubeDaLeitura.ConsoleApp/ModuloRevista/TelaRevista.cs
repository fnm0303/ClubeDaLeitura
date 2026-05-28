using ClubeDaLeitura.ConsoleApp.ModuloCaixa;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista;

public class TelaRevista
{
    private readonly RepositorioRevista repositorioRevista;
    private readonly RepositorioCaixa repositorioCaixa;

    public TelaRevista(RepositorioRevista repositorioRevista, RepositorioCaixa repositorioCaixa)
    {
        this.repositorioRevista = repositorioRevista;
        this.repositorioCaixa = repositorioCaixa;
    }

    public string? ObterOpcaoMenu()
    {
        Console.WriteLine("------------------------");
        Console.WriteLine("Gestão de Revistas");
        Console.WriteLine("------------------------");
        Console.WriteLine("1 - Cadastrar revista");
        Console.WriteLine("2 - Editar revista");
        Console.WriteLine("3 - Excluir revista");
        Console.WriteLine("4 - Visualizar revistas");
        Console.WriteLine("S - Sair");
        Console.WriteLine("------------------------");
        Console.Write("> ");
        string? opcaoMenuInterno = Console.ReadLine()?.ToUpper();

        return opcaoMenuInterno;
    }

    public void Cadastrar()
    {
        Console.WriteLine("------------------------");
        Console.WriteLine("Cadastro de Revistas");
        Console.WriteLine("------------------------");

        Console.Write("Informe o título da revista: ");
        string? titulo = Console.ReadLine();

        Console.Write("Informe o número de edição da revista: ");
        int numeroEdicao = Convert.ToInt32(Console.ReadLine());

        Console.Write("Informe o ano de publicação da revista: ");
        DateTime anoPublicacao = Convert.ToDateTime(Console.ReadLine());

        //ESPERAR AULA PARA VER COMO SELECIONAR A CAIXA DESEJADA      
        Console.Write("Informe o ID da Caixa onde deseja guardar a revista: ");
        int idCaixa = Convert.ToInt32(Console.ReadLine());

        //Revista novaRevista = new Revista(titulo, numeroEdicao, anoPublicacao, caixaSelecionada);
    }

    public void Editar()
    {
        throw new NotImplementedException();
    }

    public void Excluir()
    {
        throw new NotImplementedException();
    }

    public void VisualizarTodos()
    {
        throw new NotImplementedException();
    }
}
