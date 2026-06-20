using ClubeDaLeitura.ConsoleApp.ModuloAmigos;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace ClubeDaLeitura.ConsoleApp.Compartilhado;

public class MenuPrincipal
{
    private readonly RepositorioCaixa repositorioCaixa;
    private readonly RepositorioRevista repositorioRevista;
    private readonly RepositorioAmigos repositorioAmigos;
    private readonly RepositorioEmprestimo repositorioEmprestimo;
    public MenuPrincipal()
    {
        repositorioCaixa = new RepositorioCaixa();
        repositorioRevista = new RepositorioRevista();
        repositorioAmigos = new RepositorioAmigos();
        repositorioEmprestimo = new RepositorioEmprestimo();

        Caixa caixaTeste = new Caixa("Gibis", "Azul", 3);
        Revista revistaTeste = new Revista("Cebolinha", 4, 1984, caixaTeste);
        Amigos amigoTeste = new Amigos("Marília", "Cremilda", 4799141593);
        Emprestimo emprestimoTeste = new Emprestimo(amigoTeste, revistaTeste);
        emprestimoTeste.Abrir();

        repositorioCaixa.Cadastrar(caixaTeste);
        repositorioRevista.Cadastrar(revistaTeste);
        repositorioAmigos.Cadastrar(amigoTeste);
        repositorioEmprestimo.Cadastrar(emprestimoTeste);
    }
    public ITelaOpcoes? ObterOpcaoMenuPrincipal()
    {
        Console.WriteLine("------------------------");
        Console.WriteLine("Clube da Leitura");
        Console.WriteLine("------------------------");
        Console.WriteLine("1 - Gerenciar caixas de revistas");
        Console.WriteLine("2 - Gerenciar revistas");
        Console.WriteLine("3 - Gerenciar amigos");
        Console.WriteLine("4 - Gerenciar empréstimos");
        Console.WriteLine("S - Sair");
        Console.WriteLine("------------------------");
        Console.Write("> ");

        string? opcaoMenuPrincipal = Console.ReadLine()?.ToUpper();

        if (opcaoMenuPrincipal == "1")
            return new TelaCaixa("Caixa", repositorioCaixa, repositorioRevista);

        if (opcaoMenuPrincipal == "2")
            return new TelaRevista("Revista", repositorioRevista, repositorioCaixa);

        if (opcaoMenuPrincipal == "3")
            return new TelaAmigos("Amigo", repositorioAmigos, repositorioEmprestimo);

        if (opcaoMenuPrincipal == "4")
            return new TelaEmprestimo(repositorioEmprestimo, repositorioRevista, repositorioAmigos);

        return null;
    }
}
