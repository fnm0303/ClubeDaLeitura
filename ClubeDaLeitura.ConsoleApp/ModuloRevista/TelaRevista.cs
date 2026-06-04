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

        Revista novaRevista = ObterDadosCadastrais();

        repositorioRevista.Cadastrar(novaRevista);

        Console.WriteLine($"O registro \"{novaRevista.Titulo}\" foi cadastrado com sucesso.");
        Console.WriteLine("------------------------");
        Console.WriteLine("Digite ENTER para continuar...");
        Console.ReadLine();
    }

    public void Editar()
    {
        Console.WriteLine("------------------------");
        Console.WriteLine("Edição de Revistas");
        Console.WriteLine("------------------------");

        VisualizarTodos(false); //false para não mostrar o cabeçalho

        Console.WriteLine("------------------------");

        Console.Write("Digite o ID do registro que deseja editar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("------------------------");

        Revista revistaAtualizada = ObterDadosCadastrais();

        repositorioRevista.Editar(idSelecionado, revistaAtualizada);

        Console.WriteLine($"O registro \"{revistaAtualizada.Titulo}\" foi editado com sucesso.");
        Console.WriteLine("------------------------");
        Console.WriteLine("Digite ENTER para continuar...");
        Console.ReadLine();
    }

    public void Excluir()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Exclusão de Revista");
        Console.WriteLine("---------------------------------");

        VisualizarTodos(false);

        Console.Write("Digite o ID do registro que deseja excluir: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        repositorioRevista.Excluir(idSelecionado);

        Console.WriteLine($"O registro de ID \"{idSelecionado}\" foi excluído com sucesso.");
        Console.WriteLine("------------------------");
        Console.WriteLine("Digite ENTER para continuar...");
        Console.ReadLine();
    }

    public void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Visualização de Revistas");
            Console.WriteLine("---------------------------------");
        }

        Console.WriteLine(
            "{0, -7} | {1, -25} | {2, -6} | {3, -4} | {4, -15}",
            "Id", "Título", "Edição", "Ano", "Caixa"
        );

        Revista[] revistas = repositorioRevista.SelecionarTodos();

        for (int i = 0; i < revistas.Length; i++)
        {
            Revista r = revistas[i];

            if (r == null)
                continue;

            Console.WriteLine(
                "{0, -7} | {1, -25} | {2, -6} | {3, -4} | {4, -15}",
                r.Id, r.Titulo, r.NumeroEdicao, r.AnoPublicacao, r.Caixa.Etiqueta
            );
        }

        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Digite ENTER para continuar");
            Console.ReadLine();
        }
    }

    private Revista ObterDadosCadastrais()
    {
        Console.Write("Informe o título da revista: ");
        string? titulo = Console.ReadLine();

        Console.Write("Informe o número de edição da revista: ");
        int numeroEdicao = Convert.ToInt32(Console.ReadLine());

        Console.Write("Informe o ano de publicação da revista: ");
        int anoPublicacao = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("--------------------------------");

        Console.WriteLine("{0, -7} | {1, -20} | {2, -10} | {3, -20}",
                            "Id", "Etiqueta", "Cor", "Dias de empréstimo");

        object[] registros = repositorioCaixa.SelecionarTodos();

        for (int i = 0; i < registros.Length; i++)
        {
            Caixa c = (Caixa)registros[i];
            if (c == null)
                continue;

            Console.WriteLine("{0, -7} | {1, -20} | {2, -10} | {3, -20}",
                            c.Id, c.Etiqueta, c.Cor, c.DiasDeEmprestimo);
        }

        Console.WriteLine("--------------------------------");

        Console.Write("Digite o ID da caixa que deseja selecionar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Caixa? caixaSelecionada = repositorioCaixa.SelecionarPorId(idSelecionado);

        return new Revista(titulo, numeroEdicao, anoPublicacao, caixaSelecionada);
    }
}
