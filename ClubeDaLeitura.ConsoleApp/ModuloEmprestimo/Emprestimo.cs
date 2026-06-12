using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigos;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using ClubeDaLeitura.ConsoleApp.Utilidades;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;

public class Emprestimo : EntidadeBase
{
    public Amigos Amigo { get; private set; }
    public Revista Revista { get; private set; }
    public DateTime DataAbertura { get; private set; }
    public DateTime DataDevolucaoPrevista
    {
        get //get SEMPRE precisa RETORNAR algo
        {
            int diasDeEmprestimo = Revista.Caixa.DiasDeEmprestimo;
            DateTime dataDevolucaoPrevista = DataAbertura.AddDays(diasDeEmprestimo); //adicionando nro de dias na data de abertura
            return dataDevolucaoPrevista;
        }
    }

    public Emprestimo(Amigos amigo, Revista revista)
    {
        Id = GeradorDeIds.ObterIdEmprestimo();

        Amigo = amigo;
        Revista = revista;
    }

    public override void Atualizar(EntidadeBase entidadeAtualizada)
    {
        throw new NotImplementedException();
    }
}
