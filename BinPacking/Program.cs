using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BinPacking
{
    class Program
    {
        static int NumberOfBins = 4;
        static int MaxBinSize = 30;
        static void Main(string[] args)
        {
            Dictionary<int, int> exampleProblem = new Dictionary<int, int>() {
                {1,20},
                {2,25},
                {3,10},
                {4,20},
                {5,15},
            };

            List<int> exampleKeys = exampleProblem.Keys.ToList();
            

           

            List<int[]> population = new List<int[]>();

            int popSize = 0;
            while(popSize < 50)
            {
                List<int> keys = exampleKeys.ToList();
                int[] representation = new int[keys.Count];
                while(keys.Count > 0)
                { 
                    keys = keys.OrderBy(x => Guid.NewGuid()).ToList();
                    int itemId = keys[0];
                    Random random = new Random();
                    Thread.Sleep(20);
                    representation[itemId-1] = (random.Next() % NumberOfBins) + 1;
                    keys.Remove(itemId);
                }
                popSize++;
                population.Add(representation);
            }

            foreach(var element in population)
            {
                foreach(var item in element)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
