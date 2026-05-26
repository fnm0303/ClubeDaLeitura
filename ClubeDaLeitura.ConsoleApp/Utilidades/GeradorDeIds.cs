namespace ClubeDaLeitura.ConsoleApp.Utilidades;

public static class GeradorDeIds
{
    private static int contadorIdsCaixa = 1;

    public static int ObterIdCaixa()
    {
        return contadorIdsCaixa++;
    }
}
