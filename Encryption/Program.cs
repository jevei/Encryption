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
                string message;
                string cle;
                switch (input)
                {
                    case "1":
                        Console.WriteLine("Veuillez entrer le message à chiffrer.");
                        message = Console.ReadLine();
                        Console.WriteLine("Veuillez entrer la clé de transposition.");
                        cle = Console.ReadLine();
                        Console.WriteLine(Chiffrement.Chiffrer(message, cle));
                        break;
                    case "2":
                        Console.WriteLine("Veuillez entrer le message à déchiffrer.");
                        message = Console.ReadLine();
                        Console.WriteLine("Veuillez entrer la clé de transposition.");
                        cle = Console.ReadLine();
                        Console.WriteLine(Chiffrement.Dechiffrer(message, cle));
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
