using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Encryption
{
    static class Chiffrement
    {
        internal static string Chiffrer(string message, string cle)
        {
            message = RemoveAccents(message);
            byte[] blocClair = Encoding.ASCII.GetBytes(Transpose(message, cle.Replace(" ", "")));
            Console.WriteLine("Veuillez déterminer un vecteur d'initialisation par le caractère ASCII représentant la valeur désiré, par exemple, + donne 110101. \n");
            string VI = Console.ReadLine();
            byte[] byteVI = Encoding.ASCII.GetBytes(VI);
            for (int i = 0; i != blocClair.Length; i++)
            {
                if (i == 0)
                {
                    blocClair[i] ^= byteVI[i];
                }
                else
                {
                    blocClair[i] ^= blocClair[i - 1];
                }
            }
            return Encoding.ASCII.GetString(blocClair);
        }

        private static string Transpose(string message, string v)
        {
            int col = v.Length;
            int row = message.Length % col;
            if (row != 0)
            {
                row = message.Length / col + 1;
            }
            else
            {
                row = message.Length / col;
            }
            char[,] transposed = new char[row, col];
            int compteur = 0;
            for (int i = 0; i != row; i++)
            {
                for (int j = 0; j != col; j++)
                {
                    if (compteur < message.Length)
                    {
                        transposed[i, j] = message[compteur];
                    }
                    compteur++;
                }
            }
            char[,] temp = new char[col, row];
            for (int i = 0; i != col; i++)
            {
                int position = int.Parse(v[i].ToString()) - 1;
                for (int j = 0; j != row; j++)
                {
                    temp[position, j] = transposed[j, i];
                }
            }
            string result = "";
            for (int i = 0; i != temp.GetLength(0); i++)
            {
                for (int j = 0; j != temp.GetLength(1); j++)
                {
                    result += temp[i, j];
                }
            }
            return result.Replace("\0", "");
        }

        internal static string Dechiffrer(string message, string cle)
        {
            Console.WriteLine("Veuillez déterminer un vecteur d'initialisation par le caractère ASCII représentant la valeur désiré, par exemple, + donne 110101. \n");
            string VI = Console.ReadLine();
            byte[] blocClair = Encoding.ASCII.GetBytes(message);
            byte[] blocChiffre = Encoding.ASCII.GetBytes(message);
            byte[] byteVI = Encoding.ASCII.GetBytes(VI);
            for (int i = 0; i != blocChiffre.Length; i++)
            {
                if (i == 0)
                {
                    blocClair[i] ^= byteVI[i];
                }
                else
                {
                    blocClair[i] ^= blocChiffre[i - 1];
                }
            }
            Console.WriteLine(Encoding.ASCII.GetString(blocClair));
            return TransposeInverse(Encoding.ASCII.GetString(blocClair), cle.Replace(" ", ""));
        }

        private static string TransposeInverse(string message, string v)
        {
            int col = v.Length;
            int row = message.Length % col;
            if (row != 0)
            {
                row = message.Length / col + 1;
            }
            else
            {
                row = message.Length / col;
            }
            char[,] transposed = new char[col, row];
            int compteur = 0;
            for (int i = 0; i != col; i++)
            {
                for (int j = 0; j != row; j++)
                {
                    if (compteur < message.Length)
                    {
                        transposed[i, j] = message[compteur];
                    }
                    compteur++;
                }
            }
            int caseVides = 0;
            foreach (char c in transposed)
            {
                if (c == '\0')
                {
                    caseVides++;
                }
            }
            for (int i = col; i != col - caseVides; i--)
            {
                int colDesire = int.Parse(v[i - 1].ToString());
                int positionDepartRow = row - 1;
                int positionDepartCol = colDesire - 1;
                char caractereRemplacer = '\0';
                for (int x = positionDepartCol; x != col; x++)
                {
                    for (int y = 0; y != row; y++)
                    {
                        if (x == positionDepartCol && y == positionDepartRow)
                        {
                            caractereRemplacer = transposed[x, y];
                            transposed[x, y] = '\0';
                        }
                        else if (x > positionDepartCol)
                        {
                            char temp = transposed[x, y];
                            transposed[x, y] = caractereRemplacer;
                            caractereRemplacer = temp;
                        }
                    }
                }
            }
            char[,] result = new char[col, row];
            for (int i = 0; i != col; i++)
            {
                int position = int.Parse(v[i].ToString()) - 1;
                for (int j = 0; j != row; j++)
                {
                    result[i, j] = transposed[position, j];
                }
            }
            string retour = "";
            for (int i = 0; i != result.GetLength(1); i++)
            {
                for (int j = 0; j != result.GetLength(0); j++)
                {
                    retour += result[j, i];
                }
            }
            return retour.Replace("\0", "");
        }

        private static string RemoveAccents(string input)
        {
            return new string(input.Normalize(System.Text.NormalizationForm.FormD).ToCharArray().Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark).ToArray());
        }
    }
}
