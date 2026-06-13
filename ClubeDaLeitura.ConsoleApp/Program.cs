
using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigos;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;

RepositorioCaixa repositorioCaixa = new RepositorioCaixa();
RepositorioRevista repositorioRevista = new RepositorioRevista();
RepositorioAmigos repositorioAmigos = new RepositorioAmigos();
RepositorioEmprestimo repositorioEmprestimo = new RepositorioEmprestimo();

Caixa caixaTeste = new Caixa("Gibis", "Azul", 3);
Revista revistaTeste = new Revista("Cebolinha", 4, 1984, caixaTeste);
Amigos amigoTeste = new Amigos("Marília", "Cremilda", 4799141593);
Emprestimo emprestimoTeste = new Emprestimo(amigoTeste, revistaTeste);

repositorioCaixa.Cadastrar(caixaTeste);
repositorioRevista.Cadastrar(revistaTeste);
repositorioAmigos.Cadastrar(amigoTeste);
repositorioEmprestimo.Cadastrar(emprestimoTeste);

TelaCaixa telaCaixa = new TelaCaixa("Caixa", repositorioCaixa, repositorioRevista);
TelaRevista telaRevista = new TelaRevista("Revista", repositorioRevista, repositorioCaixa);
TelaAmigos telaAmigos = new TelaAmigos("Amigo", repositorioAmigos);
TelaEmprestimo telaEmprestimo = new TelaEmprestimo(repositorioEmprestimo, repositorioRevista, repositorioAmigos);

MenuPrincipal menuPrincipal = new MenuPrincipal();

while (true)
{
    string? opcaoMenuPrincipal = menuPrincipal.ObterOpcaoMenuPrincipal();

    if (opcaoMenuPrincipal == "S")
        break;

    while (true)
    {
        if (opcaoMenuPrincipal == "1") //caixas
        {
            string? opcaoMenuInterno = telaCaixa.ObterOpcaoMenu();

            if (opcaoMenuInterno == "S")
                break;

            if (opcaoMenuInterno == "1")
                telaCaixa.Cadastrar();

            else if (opcaoMenuInterno == "2")
                telaCaixa.Editar();

            else if (opcaoMenuInterno == "3")
                telaCaixa.Excluir();

            else if (opcaoMenuInterno == "4")
                telaCaixa.VisualizarTodos(true);

        }

        else if (opcaoMenuPrincipal == "2") //revistas
        {
            string? opcaoMenuInterno = telaRevista.ObterOpcaoMenu();

            if (opcaoMenuInterno == "S")
                break;

            if (opcaoMenuInterno == "1")
                telaRevista.Cadastrar();

            else if (opcaoMenuInterno == "2")
                telaRevista.Editar();

            else if (opcaoMenuInterno == "3")
                telaRevista.Excluir();

            else if (opcaoMenuInterno == "4")
                telaRevista.VisualizarTodos(true);
        }

        else if (opcaoMenuPrincipal == "3") //amigos
        {
            string? opcaoMenuInterno = telaAmigos.ObterOpcaoMenu();
            if (opcaoMenuInterno == "S")
                break;

            if (opcaoMenuInterno == "1")
                telaAmigos.Cadastrar();

            else if (opcaoMenuInterno == "2")
                telaAmigos.Editar();

            else if (opcaoMenuInterno == "3")
                telaAmigos.Excluir();

            else if (opcaoMenuInterno == "4")
                telaAmigos.VisualizarTodos(true);
        }

        else if (opcaoMenuPrincipal == "4") //empréstimos
        {
            string? opcaoMenuInterno = telaEmprestimo.ObterOpcaoMenu();
            if (opcaoMenuInterno == "S")
                break;

            if (opcaoMenuInterno == "1")
                telaEmprestimo.Abrir();

            else if (opcaoMenuInterno == "2")
                telaEmprestimo.Concluir();

            else if (opcaoMenuInterno == "3")
                telaEmprestimo.VisualizarTodos(true);
        }
    }
}