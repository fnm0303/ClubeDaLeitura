

using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;

RepositorioCaixa repositorioCaixa = new RepositorioCaixa();
TelaCaixa telaCaixa = new TelaCaixa(repositorioCaixa);

TelaRevista telaRevista = new TelaRevista();
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

            else if (opcaoMenuInterno == "2") { }

            else if (opcaoMenuInterno == "3") { }

            else if (opcaoMenuInterno == "4") { }
        }
        else if (opcaoMenuPrincipal == "3") //amigos
        {

        }
        else if (opcaoMenuPrincipal == "4") //empréstimos
        {

        }
    }
}