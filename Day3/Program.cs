using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Dynamic;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            var puzzleInput = 312051;
           var spiralizer = new Spiralizer(puzzleInput);
            Console.WriteLine(spiralizer.GetWalk());
            Console.ReadKey();
        }
        
    }

    class Spiralizer
    {
        private readonly int _puzzleInput;
        public Spiralizer(int puzzleInput)
        {
            _puzzleInput = puzzleInput;
            
        }

        public int GetWalk()
        {
            var lastSquare = 0;
           
            foreach (var oddSquare in GetOddSquares())
            {
                if (oddSquare < _puzzleInput)
                {
                    lastSquare = oddSquare;
                }
                else
                {
                    break;
                }
            }
            var layerLevel = (int)Math.Abs(Math.Sqrt(lastSquare) - 2);
            
            var diagonalWalk = layerLevel - 1;
            //side length is the layer level
            return diagonalWalk + (_puzzleInput - lastSquare);
        }

        private IEnumerable<int> GetOddSquares()
        {
            for (int i = 1; i < Math.Sqrt(_puzzleInput); i+=2)
            {
                yield return (int)Math.Pow(i, 2);
            }
            
        }
    }


}
