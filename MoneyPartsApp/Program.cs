using MoneyPartsApp;

class Program
{
    static void Main()
    {
        var moneyParts = new MoneyParts();
        Console.Write("Ingrese un monto en soles: ");
        string input = Console.ReadLine();

        try
        {
            var combinations = moneyParts.Build(input);
            Console.WriteLine($"Combinaciones posibles para {input}:");
            foreach (var combo in combinations)
            {
                Console.WriteLine($"[{string.Join(", ", combo)}]");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.WriteLine("Presione cualquier tecla para salir...");
        Console.ReadKey();
    }
}