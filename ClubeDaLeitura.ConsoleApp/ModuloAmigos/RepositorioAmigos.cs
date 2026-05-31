namespace ClubeDaLeitura.ConsoleApp.ModuloAmigos;

public class RepositorioAmigos
{
    private Amigos[] registros = new Amigos[100];

    public Amigos[] SelecionarTodos()
    {
        return registros;
    }

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
}
