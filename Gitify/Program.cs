using Service;
using Service.Enums;

namespace Gitify
{
    public class Program
    {
        public static void Main()
        {
            do
            {
                //Catch the user input.
                Console.Write("> ");
                var userInput = Console.ReadLine();

                //Run the program using the user input.
                var result = CommandHandler.RunInput(userInput);

                //Check if the user wants to exit the program.
                if (result.RunCode == RunCode.Stop) { return; }

                //Print the execution result.
                Console.WriteLine(result.DataResult);
                Console.WriteLine();

            } while (true);
        }
    }
}
