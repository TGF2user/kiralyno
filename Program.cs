using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kiralyno
{
    class Program
    {
        static void Main(string[] args)
        {
            bool[,] tabla = new bool[8, 8];
            bool[,] rakhato = new bool[8, 8];

            int X = 0, Y = 0, elozoX = 0;

            for (int i = 0; i < rakhato.GetLength(0); i++)
            {

                for (int j = 0; j < rakhato.GetLength(1); j++)
                {
                    rakhato[i, j] = true;
                }

            }
            

                

            Console.WriteLine();
            abrazol(tabla);
            Console.WriteLine();
            abrazol(rakhato);
            Console.ReadLine();
        }

        static void abrazol(bool[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j])
                    {
                        Console.Write("O");
                    }
                    else
                    {
                        Console.Write("+");
                    }
                }

                Console.WriteLine();
            }
        }
        static void rak(int pozX, int pozY, bool[,] refRakhato, bool[,] refTabla, string tipus="alap")
        {
            if (tipus == "alap")
            {
                Console.WriteLine("Hozzáadtam egy elemet!");
            }

            refTabla[pozY, pozX] = true;


            for (int i = 0; i < refRakhato.GetLength(0); i++)
            {
                refRakhato[i, pozX] = false;
            }

            for (int i = 0; i < refRakhato.GetLength(1); i++)
            {
                refRakhato[pozY, i] = false;
            }

            for (int i = pozY; i < refRakhato.GetLength(0); i++)
            {
                for (int j = pozX; j < refRakhato.GetLength(1); j++)
                {
                    if (Math.Abs(pozX - j) == Math.Abs(pozY - i))
                    {
                        refRakhato[i, j] = false;
                    }
                }
            }

            for (int i = pozY; i >= 0; i--)
            {
                for (int j = pozX; j >= 0; j--)
                {
                    if (Math.Abs(pozX - j) == Math.Abs(pozY - i))
                    {
                        refRakhato[i, j] = false;
                    }
                }
            }

            for (int i = pozY; i >= 0; i--)
            {
                for (int j = pozX; j < refRakhato.GetLength(1); j++)
                {
                    if (Math.Abs(pozX - j) == Math.Abs(pozY - i))
                    {
                        refRakhato[i, j] = false;
                    }
                }
            }

            for (int i = pozY; i < refRakhato.GetLength(0); i++)
            {
                for (int j = pozX; j >= 0; j--)
                {
                    if (Math.Abs(pozX - j) == Math.Abs(pozY - i))
                    {
                        refRakhato[i, j] = false;
                    }
                }
            }
            
        }
        static void elvesz(int pozX, int pozY, bool[,] refRakhato, bool[,] refTabla)
        {
            refTabla[pozY, pozX] = false;

            for (int i = 0; i < refRakhato.GetLength(0); i++)
            {
                refRakhato[i, pozX] = true;
            }

            for (int i = 0; i < refRakhato.GetLength(1); i++)
            {
                refRakhato[pozY, i] = true;
            }

            for (int i = pozY; i < refRakhato.GetLength(0); i++)
            {
                for (int j = pozX; j < refRakhato.GetLength(1); j++)
                {
                    if (Math.Abs(pozX - j) == Math.Abs(pozY - i))
                    {
                        refRakhato[i, j] = true;
                    }
                }
            }

            for (int i = pozY; i >= 0; i--)
            {
                for (int j = pozX; j >= 0; j--)
                {
                    if (Math.Abs(pozX - j) == Math.Abs(pozY - i))
                    {
                        refRakhato[i, j] = true;
                    }
                }
            }

            for (int i = pozY; i >= 0; i--)
            {
                for (int j = pozX; j < refRakhato.GetLength(1); j++)
                {
                    if (Math.Abs(pozX - j) == Math.Abs(pozY - i))
                    {
                        refRakhato[i, j] = true;
                    }
                }
            }

            for (int i = pozY; i < refRakhato.GetLength(0); i++)
            {
                for (int j = pozX; j >= 0; j--)
                {
                    if (Math.Abs(pozX - j) == Math.Abs(pozY - i))
                    {
                        refRakhato[i, j] = true;
                    }
                }
            }

            for (int i = 0; i < refTabla.GetLength(0); i++)
            {

                for (int j = 0; j < refTabla.GetLength(1); j++)
                {

                    if (refTabla[i, j])
                    {
                        rak(i, j, refRakhato, refTabla,"elvétel");
                    }
                }
            }
            Console.WriteLine("Elvettem egy elemet!");
        }
    }
    
}
