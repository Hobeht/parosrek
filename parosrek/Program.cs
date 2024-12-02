using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parosrek
{
    internal class Program
    {
        static int N;
        static int[,] csalodottsagmatrix;
        static int[] parok;
        static bool[] used;
        static int minElegedetlenseg;
        static int[] result;

        static void FindBestPairing(int diakIndex, int currentDissatisfaction)
        {
            
            if (diakIndex == N)
            {
                if (currentDissatisfaction < minElegedetlenseg)
                {
                    minElegedetlenseg = currentDissatisfaction;
                    for (int i = 0; i < parok.Length; i++)
                    {
                        result[i] = parok[i];
                    }
                }
                return;
            }

            for (int i = 0; i < N; i++)
            {
                
                if (used[i] || diakIndex == i) continue;

                
                used[i] = true;
                parok[diakIndex] = i;

               
                FindBestPairing(diakIndex + 1, currentDissatisfaction + csalodottsagmatrix[diakIndex, i]);

                
                used[i] = false;
            }
        }

        static void Main()
        {
            // Beolvasás
            N = int.Parse(Console.ReadLine());
            csalodottsagmatrix = new int[N, N];
            parok = new int[N];
            used = new bool[N];
            minElegedetlenseg = int.MaxValue;
            result = new int[N];

            for (int i = 0; i < N; i++)
            {
                var line = Console.ReadLine().Split();
                for (int j = 0; j < N; j++)
                {
                    csalodottsagmatrix[i, j] = int.Parse(line[j]);
                }
            }

            FindBestPairing(0, 0);

            // Kiírás
            Console.WriteLine(minElegedetlenseg);
            for (int i = 0; i < N; i++)
            {
                Console.Write((result[i] + 1) + " ");
            }

            Console.ReadKey();
        }
    }
}
