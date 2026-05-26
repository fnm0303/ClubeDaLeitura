using ClubeDaLeitura.ConsoleApp.Utilidades;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa;

/*
Regras de Negócio:
● Campos obrigatórios:
○ Etiqueta (texto único, máximo 50 caracteres)
○ Cor (seleção de paleta ou hexadecimal)
○ Dias de empréstimo (número, padrão 7)
● Não pode haver etiquetas duplicadas
● Não permitir excluir uma caixa caso tenha revistas vinculadas
● Cada caixa define o prazo máximo para empréstimo de suas revistas
*/

public class Caixa
{
    public int Id { get; set; }
    public string Etiqueta { get; private set; }
    public string Cor { get; private set; }
    public int DiasDeEmprestimo { get; private set; }

    public Caixa(string etiqueta, string cor, int diasDeEmprestimo) //construtor
    {
        Id = GeradorDeIds.ObterIdCaixa();
        Etiqueta = etiqueta;
        Cor = cor;
        DiasDeEmprestimo = diasDeEmprestimo;
    }
}
