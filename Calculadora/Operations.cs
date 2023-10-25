using System;

public partial class CalculatorProgram
{
    double RealizarSoma(double numero1, double numero2)
    {
        return numero1 + numero2;
    }

    double RealizarSubtracao(double numero1, double numero2)
    {
        return numero1 - numero2;
    }

    double RealizarMultiplicacao(double numero1, double numero2)
    {
        return numero1 * numero2;
    }

    double RealizarDivisao(double numero1, double numero2)
    {
        return numero1 / numero2;
    }

    double RealizarPotenciacao(double numero1, double numero2)
    {
        return Math.Pow(numero1, numero2);
    }
}