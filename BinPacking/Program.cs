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
            while(popSize < 20)
            {
                List<int> keys = exampleKeys.ToList();
                int[] representation = new int[keys.Count];
                while(keys.Count > 0)
                { 
                    keys = keys.OrderBy(x => Guid.NewGuid()).ToList();
                    int itemId = keys[0];
                    Random random = new Random();
                    Thread.Sleep(15);
                    representation[itemId-1] = (random.Next() % NumberOfBins) + 1;
                    keys.Remove(itemId);
                }
                

                if(validateRepresentation(representation,exampleProblem))
                {
                    popSize++;
                    population.Add(representation);
                    Console.WriteLine($"Added element {popSize} to population");
                }
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

        static bool validateRepresentation(int[] representation, Dictionary<int,int> problem)
        {
            int[] actualBinWeights = initializeBinArray(NumberOfBins);

            for(int i=0;i<representation.Length;i++)
            {
                int itemWeight = problem[i+1];
                actualBinWeights[representation[i] - 1] += itemWeight;
                if (actualBinWeights[representation[i] - 1] > MaxBinSize)
                    return false;
            }
            
            return true;

        }

        static int[] initializeBinArray(int numberOfBins)
        {
            int[] actualBinWeights = new int[numberOfBins];
            for (int i = 0; i < numberOfBins; i++)
            {
                actualBinWeights[i] = 0;
            }
            return actualBinWeights;
        }
    }
}
