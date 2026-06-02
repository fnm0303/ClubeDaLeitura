namespace ClubeDaLeitura.ConsoleApp.ModuloAmigos;

public class RepositorioAmigos
{
    private Amigos[] registros = new Amigos[100];

    public void Cadastrar(Amigos novoAmigo)
    {
        for (int i = 0; i < registros.Length; i++)
        {
            if (registros[i] == null)
            {
                registros[i] = novoAmigo;
                break;
            }
        }
    }

    public bool Editar(int idSelecionado, Amigos amigoAtualizado)
    {
        Amigos? amigoSelecionado = null;
        for (int i = 0; i < registros.Length; i++)
        {
            Amigos a = registros[i];

            if (a == null)
                continue;

            if (a.Id == idSelecionado)
            {
                amigoSelecionado = a;
                break;
            }
        }

        if (amigoSelecionado == null)
            return false;

        amigoSelecionado.Atualizar(amigoAtualizado);
        return true;
    }

    public bool Excluir(int idSelecionado)
    {
        for (int i = 0; i < registros.Length; i++)
        {
            Amigos a = registros[i];

            if (a == null)
                continue;

            if (a.Id == idSelecionado)
            {
                registros[i] = null;
                return true;
            }
        }
        return false;
    }

    public Amigos[] SelecionarTodos()
    {
        return registros;
    }

}
