

using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;

RepositorioCaixa repositorioCaixa = new RepositorioCaixa();
TelaCaixa telaCaixa = new TelaCaixa(repositorioCaixa);

MenuPrincipal menuPrincipal = new MenuPrincipal();

while (true)
{
    string? opcaoMenuPrincipal = menuPrincipal.ObterOpcaoMenuPrincipal();

    if (opcaoMenuPrincipal == "S")
        break;

    if (opcaoMenuPrincipal == "1") //caixas
    {
        string? opcaoMenuInterno = telaCaixa.ObterOpcaoMenu();

        if (opcaoMenuPrincipal == "S")
            break;

        if (opcaoMenuInterno == "1")
        {
            telaCaixa.Cadastrar();
        }
        else if (opcaoMenuInterno == "2")
        {

        }
        else if (opcaoMenuInterno == "3")
        {

        }
        else if (opcaoMenuInterno == "4")
        {

        }
    }
    else if (opcaoMenuPrincipal == "2") //revistas
    {

    }
    else if (opcaoMenuPrincipal == "3") //amigos
    {

    }
    else if (opcaoMenuPrincipal == "4") //empréstimos
    {

    }
}