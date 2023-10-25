using System;
using System.Collections.Generic;

public partial class CalculatorProgram
{
    static char ObterSinalDaOperacao(int opcaoEscolhida)
    {
        Dictionary<int, char> sinais = new()
        {
            { 1, '+' },
            { 2, '-' },
            { 3, 'x' },
            { 4, '/' },
            { 5, '^' }
        };
        return sinais[opcaoEscolhida];
    }

    static string ObterTituloDaOperacao(int opcaoEscolhida)
    {
        Dictionary<int, string> titulo = new()
        {
            { 1, @"
█▀ █▀█ █▀▄▀█ ▄▀█
▄█ █▄█ █░▀░█ █▀█" },
            { 2, @"
█▀ █░█ █▄▄ ▀█▀ █▀█ ▄▀█ █▀▀ ▄▀█ █▀█
▄█ █▄█ █▄█ ░█░ █▀▄ █▀█ █▄▄ █▀█ █▄█" },
            { 3, @"
█▀▄▀█ █░█ █░░ ▀█▀ █ █▀█ █░░ █ █▀▀ ▄▀█ █▀▀ ▄▀█ █▀█
█░▀░█ █▄█ █▄▄ ░█░ █ █▀▀ █▄▄ █ █▄▄ █▀█ █▄▄ █▀█ █▄█" },
            { 4, @"
█▀▄ █ █░█ █ █▀ ▄▀█ █▀█
█▄▀ █ ▀▄▀ █ ▄█ █▀█ █▄█" },
            { 5, @"
█▀█ █▀█ ▀█▀ █▀▀ █▄░█ █▀▀ █ ▄▀█ █▀▀ ▄▀█ █▀█
█▀▀ █▄█ ░█░ ██▄ █░▀█ █▄▄ █ █▀█ █▄▄ █▀█ █▄█" },
            { 6, @"
█░█ █ █▀ ▀█▀ █▀█ █▀█ █ █▀▀ █▀█
█▀█ █ ▄█ ░█░ █▄█ █▀▄ █ █▄▄ █▄█"}
        };
        return titulo[opcaoEscolhida];
    }
}