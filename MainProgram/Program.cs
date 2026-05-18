namespace MainProgram;

class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            try
            {
                Console.WriteLine("\nChoose task:");
                Console.WriteLine("1. Task 4-5 (Launch UdpClient)");
                Console.WriteLine("0. Exit");
                string? input = InputHelpers.StringInput("\nYour choice: ");

                if (int.TryParse(input, out int userChoice))
                {
                    if (userChoice == 0)
                    {
                        Console.WriteLine("\nExitting...");
                        return;
                    }
                    else if (userChoice == 1)
                    {
                        Task4.Run();
                    }
                    else
                    {
                        Console.WriteLine("\nEnter a number!");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                return;
            }
        }
    }
}