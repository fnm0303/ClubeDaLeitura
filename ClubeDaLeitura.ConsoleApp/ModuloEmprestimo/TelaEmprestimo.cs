using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigos;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;

public class TelaEmprestimo : ITelaOpcoes //Não será uma tela base
{
    private readonly RepositorioEmprestimo repositorioEmprestimo; //apenas no construtor pegará o valor
    private readonly RepositorioRevista repositorioRevista;
    private readonly RepositorioAmigos repositorioAmigos;

    public TelaEmprestimo(RepositorioEmprestimo repositorioEmprestimo, RepositorioRevista repositorioRevista, RepositorioAmigos repositorioAmigos)
    {
        this.repositorioEmprestimo = repositorioEmprestimo;
        this.repositorioRevista = repositorioRevista;
        this.repositorioAmigos = repositorioAmigos;
    }
    public string? ObterOpcaoMenu()
    {
        Console.WriteLine("------------------------");
        Console.WriteLine($"Gestão de Empréstimos");
        Console.WriteLine("------------------------");
        Console.WriteLine($"1 - Abrir Empréstimo");
        Console.WriteLine($"2 - Concluir Empréstimo");
        Console.WriteLine($"3 - Visualizar Empréstimos");
        Console.WriteLine("S - Sair");
        Console.WriteLine("------------------------");
        Console.Write("> ");
        string? opcaoMenuInterno = Console.ReadLine()?.ToUpper();

        return opcaoMenuInterno;
    }

    public void Abrir()
    {
        Console.WriteLine("------------------------");
        Console.WriteLine("Abertura de Empréstimo");
        Console.WriteLine("------------------------");

        VisualizarRevistas();

        Console.WriteLine("------------------------");
        Console.WriteLine("Digite o ID da revista que deseja emprestar: ");
        int idRevista = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("------------------------");

        VisualizarAmigos();

        Console.WriteLine("------------------------");
        Console.WriteLine("Digite o ID do amigo que irá receber a revista: ");
        int idAmigo = Convert.ToInt32(Console.ReadLine());

        Revista? revistaSelecionada = (Revista?)repositorioRevista.SelecionarPorId(idRevista);
        Amigos? amigoSelecionado = (Amigos?)repositorioAmigos.SelecionarPorId(idAmigo);

        if (revistaSelecionada == null)
        {
            Console.WriteLine("------------------------");
            Console.WriteLine($"A revista \"{idRevista}\" não foi encontrada.");
            Console.WriteLine("------------------------");
            Console.WriteLine("Digite ENTER para continuar...");
            Console.ReadLine();
            return;
        }

        if (!revistaSelecionada.EstaDisponivel)
        {
            Console.WriteLine("------------------------");
            Console.WriteLine($"A revista \"{revistaSelecionada.Titulo}\" está indisponível.");
            Console.WriteLine("------------------------");
            Console.WriteLine("Digite ENTER para continuar...");
            Console.ReadLine();
            return;
        }

        if (amigoSelecionado == null)
        {
            Console.WriteLine("------------------------");
            Console.WriteLine($"O amigo \"{idAmigo}\" não foi encontrado.");
            Console.WriteLine("------------------------");
            Console.WriteLine("Digite ENTER para continuar...");
            Console.ReadLine();
            return;
        }

        EntidadeBase[] emprestimos = repositorioEmprestimo.SelecionarTodos();

        for (int i = 0; i < emprestimos.Length; i++)
        {
            Emprestimo e = (Emprestimo)emprestimos[i];

            if (e == null)
                continue;

            if (e.Amigo.Id == amigoSelecionado.Id && e.EstaAberto)
            {
                Console.WriteLine("------------------------");
                Console.WriteLine($"O amigo \"{amigoSelecionado.Nome}\" já tem um empréstimo em aberto.");
                Console.WriteLine("------------------------");
                Console.WriteLine("Digite ENTER para continuar...");
                Console.ReadLine();
                return;
            }
        }

        Emprestimo novoEmprestimo = new Emprestimo(amigoSelecionado, revistaSelecionada);

        novoEmprestimo.Abrir();

        repositorioEmprestimo.Cadastrar(novoEmprestimo);

        Console.WriteLine($"O empréstimo \"{novoEmprestimo.Id}\" foi aberto com sucesso.");
        Console.WriteLine("------------------------");
        Console.WriteLine("Digite ENTER para continuar...");
        Console.ReadLine();
    }
    public void Concluir()
    {
        Console.WriteLine("------------------------");
        Console.WriteLine("Conclusão de Empréstimo");
        Console.WriteLine("------------------------");

        VisualizarTodos(false);

        Console.WriteLine("------------------------");
        Console.WriteLine("Digite o ID do empréstimo que deseja concluir: ");
        int idEmprestimo = Convert.ToInt32(Console.ReadLine());

        Emprestimo? emprestimo = (Emprestimo?)repositorioEmprestimo.SelecionarPorId(idEmprestimo);

        if (emprestimo == null)
        {
            Console.WriteLine("------------------------");
            Console.WriteLine($"O empréstimo \"{idEmprestimo}\" não foi encontrado.");
            Console.WriteLine("------------------------");
            Console.WriteLine("Digite ENTER para continuar...");
            Console.ReadLine();
            return;
        }

        if (emprestimo.EstaAberto)
        {
            Console.WriteLine("------------------------");
            Console.WriteLine($"O empréstimo \"{idEmprestimo}\" já está concluído.");
            Console.WriteLine("------------------------");
            Console.WriteLine("Digite ENTER para continuar...");
            Console.ReadLine();
            return;
        }

        emprestimo.Concluir();

        repositorioEmprestimo.Editar(idEmprestimo, emprestimo);

        Console.WriteLine("------------------------");
        Console.WriteLine($"O empréstimo \"{emprestimo.Id}\" foi concluído com sucesso.");
        Console.WriteLine("------------------------");
        Console.WriteLine("Digite ENTER para continuar...");
        Console.ReadLine();
    }
    public void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
        {
            Console.WriteLine("------------------------");
            Console.WriteLine("Visualização de Empréstimos");
            Console.WriteLine("------------------------");
        }

        Console.WriteLine("{0, -7} | {1, -15} | {2, -15} | {3, -13} | {4, -15} | {5, -15}",
                        "Id", "Revista", "Amigo", "Abertura", "Conclusão Prev.", "Status");

        EntidadeBase[] emprestimos = repositorioEmprestimo.SelecionarTodos();

        for (int i = 0; i < emprestimos.Length; i++)
        {
            Emprestimo e = (Emprestimo)emprestimos[i];

            if (e == null)
                continue;

            Console.WriteLine("{0, -7} | {1, -15} | {2, -15} | {3, -13} | {4, -15} | {5, -15}",
                            e.Id, e.Revista.Titulo,
                            e.Amigo.Nome,
                            e.DataAbertura.ToShortDateString(),
                            e.DataConclusaoPrevista.ToShortDateString(),
                            e.Status.ToString());
        }

        if (deveExibirCabecalho)
        {
            Console.WriteLine("------------------------");
            Console.WriteLine("Digite ENTER para continuar...");
            Console.ReadLine();
        }
    }

    private void VisualizarRevistas()
    {
        Console.WriteLine(
        "{0, -7} | {1, -25} | {2, -6} | {3, -4} | {4, -15} | {5, -12}",
        "Id", "Título", "Edição", "Ano", "Caixa", "Status"
        );

        EntidadeBase[] revistas = repositorioRevista.SelecionarTodos();

        for (int i = 0; i < revistas.Length; i++)
        {
            Revista r = (Revista)revistas[i];

            if (r == null)
                continue;

            Console.WriteLine(
                "{0, -7} | {1, -25} | {2, -6} | {3, -4} | {4, -15} | {5, -12}",
                r.Id, r.Titulo, r.NumeroEdicao, r.AnoPublicacao, r.Caixa.Etiqueta, r.Status.ToString()
            );
        }
    }

    private void VisualizarAmigos()
    {
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
    }
}
