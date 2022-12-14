using System;

namespace Encryption
{
    static class Chiffrement
    {
        internal static string Chiffrer(string message, string cle)
        {
            string messageTranspose = Transpose(message, cle.Replace(" ", ""));
            throw new NotImplementedException();
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
                    /*else
                    {
                        transposed[i, j] = '^';
                    }*/
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
            return result;
        }

        internal static string Dechiffrer(string message, string cle)
        {
            throw new NotImplementedException();
        }
    }
}
