using System;

class ScientificCalculator
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Ammars Scientific Calculator ===");
        Console.WriteLine("Type 'help!' to see available operations.");
        Console.WriteLine("Type 'leave?' to quit.\n");

        while (true)
        {
            Console.Write("Enter operation: ");
            string input = Console.ReadLine().ToLower().Trim();

            if (input == "leave?") break;

            if (input == "help!")
            {
                ShowHelp();
                continue;
            }

            try
            {
                ProcessOperation(input);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}\n");
            }
        }

        Console.WriteLine("SEE YOU NEXT TIME!");
    }

    static void ShowHelp()
    {
        Console.WriteLine("\n--- Operations Available ---");
        Console.WriteLine("Basic   : +  -  *  /");
        Console.WriteLine("Math    : sqrt  ^  log  log10  abs");
        Console.WriteLine("Trig    : sin  cos  tan  (in degrees)");
        Console.WriteLine("Other   : !  %");
        Console.WriteLine("----------------------------\n");
    }

    static void ProcessOperation(string operation)
    {
        double num1, num2, result;

        switch (operation)
        {
            case "+":
                Console.Write("Enter your first number: ");
                num1 = double.Parse(Console.ReadLine());
                Console.Write("Enter your second number: ");
                num2 = double.Parse(Console.ReadLine());
                result = num1 + num2;
                Console.WriteLine($"Result: {num1} + {num2} = {result}\n");
                break;

            case "-":
                Console.Write("Enter your first number: ");
                num1 = double.Parse(Console.ReadLine());
                Console.Write("Enter your second number: ");
                num2 = double.Parse(Console.ReadLine());
                result = num1 - num2;
                Console.WriteLine($"Result: {num1} - {num2} = {result}\n");
                break;

            case "*":
                Console.Write("Enter your first number: ");
                num1 = double.Parse(Console.ReadLine());
                Console.Write("Enter your first number: ");
                num2 = double.Parse(Console.ReadLine());
                result = num1 * num2;
                Console.WriteLine($"Result: {num1} × {num2} = {result}\n");
                break;

            case "/":
                Console.Write("Enter your first number: ");
                num1 = double.Parse(Console.ReadLine());
                Console.Write("Enter your first number: ");
                num2 = double.Parse(Console.ReadLine());
                if (num2 == 0) throw new Exception("Cannot divide by zero!");
                result = num1 / num2;
                Console.WriteLine($"Result: {num1} ÷ {num2} = {result}\n");
                break;

            case "sqrt":
                Console.Write("Enter the number: ");
                num1 = double.Parse(Console.ReadLine());
                if (num1 < 0) throw new Exception(" a square root of a negative number is not possible!");
                result = Math.Sqrt(num1);
                Console.WriteLine($"Result: √{num1} = {result}\n");
                break;

            case "^":
                Console.Write("Enter the base number: ");
                num1 = double.Parse(Console.ReadLine());
                Console.Write("Enter the exponent: ");
                num2 = double.Parse(Console.ReadLine());
                result = Math.Pow(num1, num2);
                Console.WriteLine($"Result: {num1}^{num2} = {result}\n");
                break;

            case "log":
                Console.Write("Enter the number you got: ");
                num1 = double.Parse(Console.ReadLine());
                if (num1 <= 0) throw new Exception("Remember Log requires a positive number!");
                result = Math.Log(num1);
                Console.WriteLine($"Result: ln({num1}) = {result}\n");
                break;

            case "log10":
                Console.Write("Enter the number you got: ");
                num1 = double.Parse(Console.ReadLine());
                if (num1 <= 0) throw new Exception("Remember Log requires a positive number!");
                result = Math.Log10(num1);
                Console.WriteLine($"Result: log10({num1}) = {result}\n");
                break;

            case "abs":
                Console.Write("Enter the number you got: ");
                num1 = double.Parse(Console.ReadLine());
                result = Math.Abs(num1);
                Console.WriteLine($"Result: |{num1}| = {result}\n");
                break;

            case "sin":
                Console.Write("Enter angle in degrees ok: ");
                num1 = double.Parse(Console.ReadLine());
                result = Math.Sin(num1 * Math.PI / 180);
                Console.WriteLine($"Result: sin({num1}°) = {Math.Round(result, 6)}\n");
                break;

            case "cos":
                Console.Write("Enter angle in degrees ok: ");
                num1 = double.Parse(Console.ReadLine());
                result = Math.Cos(num1 * Math.PI / 180);
                Console.WriteLine($"Result: cos({num1}°) = {Math.Round(result, 6)}\n");
                break;

            case "tan":
                Console.Write("Enter angle in degrees ok: ");
                num1 = double.Parse(Console.ReadLine());
                result = Math.Tan(num1 * Math.PI / 180);
                Console.WriteLine($"Result: tan({num1}°) = {Math.Round(result, 6)}\n");
                break;

            case "!":
                Console.Write("Enter a whole number of (0-20): ");
                num1 = double.Parse(Console.ReadLine());
                if (num1 < 0 || num1 != Math.Floor(num1)) throw new Exception("Factorial needs a non-negative whole number!");
                result = Factorial((int)num1);
                Console.WriteLine($"Result: {num1}! = {result}\n");
                break;

            case "%":
                Console.Write("Enter the first number: ");
                num1 = double.Parse(Console.ReadLine());
                Console.Write("Enter the second number: ");
                num2 = double.Parse(Console.ReadLine());
                if (num2 == 0) throw new Exception("Cannot mod by zero!");
                result = num1 % num2;
                Console.WriteLine($"Result: {num1} % {num2} = {result}\n");
                break;

            default:
                Console.WriteLine($"Unknown operation: '{operation}'. Type 'help' to see options.\n");
                break;
        }
    }

    static long Factorial(int n)
    {
        if (n == 0 || n == 1) return 1;
        return n * Factorial(n - 1);
    }
}