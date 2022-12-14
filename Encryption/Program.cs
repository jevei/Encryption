using System;

namespace Encryption
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            do
            {
                Console.WriteLine("Veuillez choisir l'action désiré.\n1-Chiffrer. \n2-Déchiffrer.\n3-Quitter.");
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        Console.WriteLine("Quitté.");
                        break;
                    default:
                        Console.WriteLine("Entrée invalide!");
                        break;
                }
            } while (input != "3");
        }
    }
}
