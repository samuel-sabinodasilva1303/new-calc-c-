using System;

class Program
{
    enum Operations { Soma = 1, Subtracao, Divisao, Multiplicao, Potencia, Raiz, Sair }

    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Sua calculadora, selecione uma opção:");
            Console.WriteLine("1- Soma\n2- Subtração\n3- Divisão\n4- Multiplicação\n5- Potência\n6- Raiz\n7- Sair");

            if (!int.TryParse(Console.ReadLine(), out int input) || !Enum.IsDefined(typeof(Operations), input))
            {
                Console.WriteLine("Opção inválida, tente novamente.");
                Console.ReadLine();
                continue;
            }

            Operations optionsSelected = (Operations)input;

            if (optionsSelected == Operations.Sair)
            {
                Sair();
                break;
            }

            double result = 0;
            switch (optionsSelected)
            {
                case Operations.Soma:
                    result = PerformOperation("soma", (a, b) => a + b);
                    break;
                case Operations.Subtracao:
                    result = PerformOperation("subtração", (a, b) => a - b);
                    break;
                case Operations.Divisao:
                    result = PerformOperation("divisão", (a, b) => b != 0 ? a / b : double.NaN, true);
                    break;
                case Operations.Multiplicao:
                    result = PerformOperation("multiplicação", (a, b) => a * b);
                    break;
                case Operations.Potencia:
                    result = PerformOperation("potência", (a, b) => Math.Pow(a, b));
                    break;
                case Operations.Raiz:
                    result = PerformSingleOperation("raiz", a => Math.Sqrt(a));
                    break;
            }

            Console.WriteLine($"O resultado é: {result}");
            Console.WriteLine("Pressione Enter para continuar...");
            Console.ReadLine();
        }
    }

    static void Sair()
    {
        Console.WriteLine("Você saiu da calculadora. Até mais!");
    }

    static double PerformOperation(string operationName, Func<double, double, double> operation, bool validateDivisor = false)
    {
        Console.WriteLine($"Digite o primeiro número para a {operationName}:");
        double num1 = double.Parse(Console.ReadLine());
        Console.WriteLine($"Digite o segundo número para a {operationName}:");
        double num2 = double.Parse(Console.ReadLine());

        if (validateDivisor && num2 == 0)
        {
            Console.WriteLine("Divisão por zero não é permitida!");
            return double.NaN;
        }

        return operation(num1, num2);
    }

    static double PerformSingleOperation(string operationName, Func<double, double> operation)
    {
        Console.WriteLine($"Digite o número para a {operationName}:");
        double num = double.Parse(Console.ReadLine());
        return operation(num);
    }
}
