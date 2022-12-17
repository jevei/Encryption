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
            char[] test = Encoding.ASCII.GetChars(blocClair);
            string test2 = "";
            //Console.WriteLine("N*Gg\u0014g\be\fx\u0016x\rl\u001d=I=\u001dx\u0019|\\/Ll\u0018k\u0002c\u0010x\u001do\u001d~^a\u0012-H:N;Op");
            //Console.WriteLine("")
            foreach (char c in test)
            {
                test2 += c;
            }
            var test3 = test2.Length;
            return Encoding.ASCII.GetString(blocClair);
        }

        private static string Transpose(string message, string v)
        {
            int col = v.Length;
            int row = message.Length % v.Length;
            if (row != 0)
            {
                row = message.Length / v.Length + 1;
            }
            else
            {
                row = message.Length / v.Length;
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
            message = "N*Gg\u0014g\be\fx\u0016x\rl\u001d=I=\u001dx\u0019|\\/Ll\u0018k\u0002c\u0010x\u001do\u001d~^;H-H:N;O*";
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

        private static string TransposeInverse(string v1, string v2)
        {
            throw new NotImplementedException();
        }

        private static string RemoveAccents(string input)
        {
            return new string(input.Normalize(System.Text.NormalizationForm.FormD).ToCharArray().Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark).ToArray());
        }
    }
}
