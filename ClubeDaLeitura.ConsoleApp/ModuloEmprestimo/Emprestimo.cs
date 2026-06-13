using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigos;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using ClubeDaLeitura.ConsoleApp.Utilidades;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;

public enum StatusEmprestimo //ENUM é um tipo 
{
    Aberto,
    Concluido,
    Atrasado //constantes que definem que tipo de valores esse tipo pode ser
}

public class Emprestimo : EntidadeBase
{
    public Amigos Amigo { get; private set; }
    public Revista Revista { get; private set; }
    public StatusEmprestimo Status { get; set; }
    public DateTime DataAbertura { get; private set; }
    public DateTime DataConclusaoPrevista
    {
        get //get SEMPRE precisa RETORNAR algo
        {
            int diasDeEmprestimo = Revista.Caixa.DiasDeEmprestimo;
            DateTime dataConclusaoPrevista = DataAbertura.AddDays(diasDeEmprestimo); //adicionando nro de dias na data de abertura
            return dataConclusaoPrevista;
        }
    }

    public Emprestimo(Amigos amigo, Revista revista)
    {
        Id = GeradorDeIds.ObterIdEmprestimo();
        DataAbertura = DateTime.Now;
        Status = StatusEmprestimo.Aberto;
        Amigo = amigo;
        Revista = revista;
    }

    public override void Atualizar(EntidadeBase entidadeAtualizada)
    {
        Emprestimo emprestimoAtualizado = (Emprestimo)entidadeAtualizada;
        Status = emprestimoAtualizado.Status;
    }
}
