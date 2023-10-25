using System;
using System.Collections.Generic;
using System.Threading;

public partial class CalculatorProgram
{
    List<string> historico = new List<string>();
    Dictionary<int, Func<double, double, double>> opcoes;

    public CalculatorProgram()
    {
        opcoes = new Dictionary<int, Func<double, double, double>>
        {
            {1, RealizarSoma},
            {2, RealizarSubtracao},
            {3, RealizarMultiplicacao},
            {4, RealizarDivisao},
            {5, RealizarPotenciacao}
        };
    }

    static void Main()
    {
        CalculatorProgram programa = new CalculatorProgram();
        programa.Executar();
    }



    void Executar()
    {
        ExibirOpcoesDoMenu(opcoes, historico);
    }

    static void ExibirLogo()
    {
        Console.WriteLine(@"
░█████╗░░█████╗░██╗░░░░░░█████╗░██╗░░░██╗██╗░░░░░░█████╗░██████╗░░█████╗░██████╗░░█████╗░
██╔══██╗██╔══██╗██║░░░░░██╔══██╗██║░░░██║██║░░░░░██╔══██╗██╔══██╗██╔══██╗██╔══██╗██╔══██╗
██║░░╚═╝███████║██║░░░░░██║░░╚═╝██║░░░██║██║░░░░░███████║██║░░██║██║░░██║██████╔╝███████║
██║░░██╗██╔══██║██║░░░░░██║░░██╗██║░░░██║██║░░░░░██╔══██║██║░░██║██║░░██║██╔══██╗██╔══██║
╚█████╔╝██║░░██║███████╗╚█████╔╝╚██████╔╝███████╗██║░░██║██████╔╝╚█████╔╝██║░░██║██║░░██║
░╚════╝░╚═╝░░╚═╝╚══════╝░╚════╝░░╚═════╝░╚══════╝╚═╝░░╚═╝╚═════╝░░╚════╝░╚═╝░░╚═╝╚═╝░░╚═╝");
        Console.WriteLine("Seja bem vindo");
    }

    static void ExibirOpcoesDoMenu(Dictionary<int, Func<double, double, double>> opcoes, List<string> historico)
    {
        ExibirLogo();
        Console.WriteLine("\n[ 1 ] Soma");
        Console.WriteLine("[ 2 ] Subtração");
        Console.WriteLine("[ 3 ] Multiplicação");
        Console.WriteLine("[ 4 ] Divisão");
        Console.WriteLine("[ 5 ] Potenciação");
        Console.WriteLine("[ 6 ] Exibir Histórico");
        Console.WriteLine("[ 0 ] Sair");

        Console.Write("\nSua escolha: ");
        string opcaoEscolhida = Console.ReadLine();

        if (int.TryParse(opcaoEscolhida, out int opcaoEscolhidaINT))
        {
            if (opcoes.ContainsKey(opcaoEscolhidaINT))
            {
                Func<double, double, double> opcao = opcoes[opcaoEscolhidaINT];
                char sinal = ObterSinalDaOperacao(opcaoEscolhidaINT);
                string titulo = ObterTituloDaOperacao(opcaoEscolhidaINT);
                RealizarOperacao(opcao, sinal, titulo, opcoes, historico);
            }
            else if (opcaoEscolhidaINT == 6)
            {
                ExibirHistorico(opcoes, historico, opcaoEscolhidaINT);
            }
            else if (opcaoEscolhidaINT == 0)
            {
                Sair();
            }
            else
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
                Thread.Sleep(2000);
                Console.Clear();
                ExibirOpcoesDoMenu(opcoes, historico);
            }
        }
        else
        {
            Console.WriteLine("Opção inválida. Tente novamente.");
            Thread.Sleep(2000);
            Console.Clear();
            ExibirOpcoesDoMenu(opcoes, historico);
        }
    }

    static void ExibirHistorico(Dictionary<int, Func<double, double, double>> opcoes, List<string> historico, int opcaoEscolhidaINT)
    {
        Console.Clear();
        string titulo = ObterTituloDaOperacao(opcaoEscolhidaINT);
        ExibirTituloDasOpcoes(titulo);
        foreach (string item in historico)
        {
            Console.WriteLine(item);
        }

        Console.Write("\nPressione qualquer tecla para continuar.");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu(opcoes, historico);
    }

    static void ExibirTituloDasOpcoes(string titulo)
    {
        Console.Clear();
        Console.WriteLine(titulo + "\n");
    }

    

    static void RealizarOperacao(Func<double, double, double> operacao, char sinal, string titulo, Dictionary<int, Func<double, double, double>> opcoes, List<string> historico)
    {
        Console.Clear();
        ExibirTituloDasOpcoes(titulo);

        double numero1Double;
        double numero2Double;

        while (true)
        {
            Console.Write("Digite o primeiro número: ");
            string numero1 = Console.ReadLine();

            if (double.TryParse(numero1, out numero1Double))
            {
                break;
            }
            else
            {
                Console.WriteLine("Valor inválido. Tente Novamente.\n");
            }
        }

        while (true)
        {
            Console.Write("Digite o segundo número: ");
            string numero2 = Console.ReadLine();

            if (double.TryParse(numero2, out numero2Double))
            {
                if (numero2Double == 0)
                {
                    Console.WriteLine("Não é possível fazer uma divisão por 0.\n");
                }
                else
                {
                    break;
                }
            }
            else
            {
                Console.WriteLine("Valor inválido. Tente Novamente.\n");
            }
        }

        double resultado = operacao(numero1Double, numero2Double);
        string resultadoString = $"{numero1Double} {sinal} {numero2Double} = {resultado}";

        if (historico.Count >= 5)
        {
            historico.RemoveAt(0);
        }
        historico.Add(resultadoString);

        Console.WriteLine($"Resultado: {resultadoString}");

        Console.Write("\nPressione qualquer tecla para continuar.");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu(opcoes, historico);
    }

   
    void ExibirHistorico(Dictionary<int, Func<double, double, double>> opcoes, List<string> historico)
    {
        Console.Clear();
        foreach (string item in historico)
        {
            Console.WriteLine(item);
        }

        Console.Write("\nPressione qualquer tecla para continuar.");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu(opcoes, historico);
    }

    static void Sair()
    {
        Console.WriteLine("Encerrando o programa\nTchau tchau :D");
        Thread.Sleep(3000);
        Environment.Exit(0);
    }
}