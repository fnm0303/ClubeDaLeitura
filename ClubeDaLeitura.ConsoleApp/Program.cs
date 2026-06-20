
using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigos;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;

MenuPrincipal menuPrincipal = new MenuPrincipal();

while (true)
{
    ITelaOpcoes? telaSelecionada = menuPrincipal.ObterOpcaoMenuPrincipal();

    if (telaSelecionada == null)
        break;

    while (true)
    {
        string? opcaoMenuInterno = telaSelecionada.ObterOpcaoMenu();

        if (opcaoMenuInterno == "S")
            break;

        if (telaSelecionada is TelaBase telaBase)
        {
            if (opcaoMenuInterno == "1")
                telaBase.Cadastrar();

            else if (opcaoMenuInterno == "2")
                telaBase.Editar();

            else if (opcaoMenuInterno == "3")
                telaBase.Excluir();

            else if (opcaoMenuInterno == "4")
                telaBase.VisualizarTodos(true);

            else if (telaBase is TelaAmigos telaAmigo) //aqui o próprio c# faz o casting
            {
                if (opcaoMenuInterno == "5")
                    telaAmigo.VisualizarEmprestimoAmigo();
            }
        }

        else if (telaSelecionada is TelaEmprestimo telaEmprestimo) //empréstimos
        {
            if (opcaoMenuInterno == "1")
                telaEmprestimo.Abrir();

            else if (opcaoMenuInterno == "2")
                telaEmprestimo.Concluir();

            else if (opcaoMenuInterno == "3")
                telaEmprestimo.VisualizarTodos(true);

        }
    }
}