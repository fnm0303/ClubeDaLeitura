using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigos;

public class TelaAmigos : TelaBase
{
    private readonly RepositorioAmigos repositorioAmigos;
    private readonly RepositorioEmprestimo repositorioEmprestimo;

    public TelaAmigos(string nomeEntidade, RepositorioAmigos repositorioAmigos, RepositorioEmprestimo repositorioEmprestimo) : base(nomeEntidade, repositorioAmigos)
    {
        this.repositorioAmigos = repositorioAmigos;
        this.repositorioEmprestimo = repositorioEmprestimo;
    }

    public override string? ObterOpcaoMenu() //override = sobrescrevendo / substituindo
    {
        Console.WriteLine("------------------------");
        Console.WriteLine($"Gestão de Amigos");
        Console.WriteLine("------------------------");
        Console.WriteLine($"1 - Cadastrar Amigo");
        Console.WriteLine($"2 - Editar Amigo");
        Console.WriteLine($"3 - Excluir Amigo");
        Console.WriteLine($"4 - Visualizar Amigos");
        Console.WriteLine($"5 - Visualizar Empréstimos de um Amigo");
        Console.WriteLine("S - Sair");
        Console.WriteLine("------------------------");
        Console.Write("> ");
        string? opcaoMenuInterno = Console.ReadLine()?.ToUpper();

        return opcaoMenuInterno;
    }

    public void VisualizarEmprestimoAmigo()
    {
        Console.WriteLine("------------------------");
        Console.WriteLine("Visualização de Empréstimo de Amigo");
        Console.WriteLine("------------------------");

        VisualizarTodos(false);

        Console.WriteLine("------------------------");
        Console.Write("Digite o ID do amigo que deseja ver os empréstimos: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("------------------------");

        Amigos? amigoSelecionado = (Amigos?)repositorioAmigos.SelecionarPorId(idSelecionado);

        if (amigoSelecionado == null)
        {
            Console.WriteLine("------------------------");
            Console.WriteLine($"O amigo \"{idSelecionado}\" não foi encontrado.");
            Console.WriteLine("------------------------");
            Console.WriteLine("Digite ENTER para continuar...");
            Console.ReadLine();
            return;
        }

        Console.WriteLine("------------------------");
        Console.WriteLine($"Empréstimos de \"{amigoSelecionado.Nome}\"");
        Console.WriteLine("------------------------");

        Console.WriteLine("{0, -7} | {1, -15} | {2, -15} | {3, -15} | {4, -15}",
                            "Id", "Revista", "Abertura", "Conclusão Prev.", "Status");

        EntidadeBase[] emprestimos = repositorioEmprestimo.SelecionarTodos();

        for (int i = 0; i < emprestimos.Length; i++)
        {
            Emprestimo e = (Emprestimo)emprestimos[i];

            if (e == null)
                continue;

            if (e.Amigo.Id != amigoSelecionado.Id)
                continue;

            Console.WriteLine("{0, -7} | {1, -15} | {2, -15} | {3, -15} | {4, -15}",
                    e.Id, e.Revista.Titulo,
                    e.DataAbertura.ToShortDateString(),
                    e.DataConclusaoPrevista.ToShortDateString(),
                    e.Status.ToString());
        }

        Console.WriteLine("------------------------");
        Console.WriteLine("Digite ENTER para continuar...");
        Console.ReadLine();
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
