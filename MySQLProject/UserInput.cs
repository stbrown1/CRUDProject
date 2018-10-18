using System;
namespace MySQLProject
{
    public class UserInput
    {
       public static string GetStringResponse(string question)
        {
            Console.WriteLine(question);

            string response = Console.ReadLine().Trim();
            while (string .IsNullOrWhiteSpace(response))
            {
                Console.WriteLine(question);
                response = Console.ReadLine().Trim();
            }

            return response;
        }

        public static int GetIntegerResponse(string question)
        {
            Console.WriteLine(question);

            int response;
            while(!int.TryParse(Console.ReadLine(),out response))
            {
                Console.WriteLine(question);
            }

            return response;
        }
    }
}
