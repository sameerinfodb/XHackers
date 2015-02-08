using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Housee.Business.Service
{
    public class RandomNumberGenerator
    {
        private List<int> AnnoucedNumber = new List<int>();
        private List<int> ChitNumbers = new List<int>();
        public RandomNumberGenerator()
        {
            AnnoucedNumber = Enumerable.Range(1, 100).ToList<int>();
            ChitNumbers = AnnoucedNumber;
        }
        public int Next()
        {
            int[] test = this.AnnoucedNumber.ToArray();
            FisherYates(test);
            int nextrandomno = test.Take(1).Single();
            this.ChitNumbers = test.ToList<int>();
            ChitNumbers.RemoveAt(0);
            return nextrandomno;

        }
        /**
         * An improved version (Durstenfeld) of the Fisher-Yates algorithm with O(n) time complexity
         * Permutes the given array
         * @param array array to be shuffled
         * Taken from the http://en.algoritmy.net/ url for shuffling the array of numbers
         */
        public void FisherYates(int[] array)
        {
            Random r = new Random();
            for (int i = array.Length - 1; i > 0; i--)
            {
                int index = r.Next(i);
                //swap
                int tmp = array[index];
                array[index] = array[i];
                array[i] = tmp;
            }
        }


        public List<int> GenerationRandomNumbers(int p)
        {
            int[] test= this.ChitNumbers.ToArray();
            FisherYates(test);
            List<int> nextrandomno = test.Take(p).ToList<int>();
            this.ChitNumbers = test.ToList<int>();
            return nextrandomno;
        }
    }


}
