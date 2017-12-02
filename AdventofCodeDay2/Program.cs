using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventofCodeDay2
{
    class Program
    {
        public static readonly List<List<int>> PuzzleInput = new List<List<int>>
        {

            new List<int> {626,2424,2593,139,2136,163,1689,367,2235,125,2365,924,135,2583,1425,2502},
            new List<int> {183, 149, 3794, 5221, 5520, 162, 5430, 4395, 2466, 1888, 3999, 3595, 195, 181, 6188, 4863},
            new List<int> {163, 195, 512, 309, 102, 175, 343, 134, 401, 372, 368, 321, 350, 354, 183, 490},
            new List<int> {2441, 228, 250, 2710, 200, 1166, 231, 2772, 1473, 2898, 2528, 2719, 1736, 249, 1796, 903},
            new List<int> {3999, 820, 3277, 3322, 2997, 1219, 1014, 170, 179, 2413, 183, 3759, 3585, 2136, 3700, 188},
            new List<int> {132, 108, 262, 203, 228, 104, 205, 126, 69, 208, 235, 311, 313, 258, 110, 117},
            new List<int> {963, 1112, 1106, 50, 186, 45, 154, 60, 1288, 1150, 986, 232, 872, 433, 48, 319},
            new List<int> {111, 1459, 98, 1624, 2234, 2528, 93, 1182, 97, 583, 2813, 3139, 1792, 1512, 1326, 3227},
            new List<int> {371, 374, 459, 83, 407, 460, 59, 40, 42, 90, 74, 163, 494, 250, 488, 444},
            new List<int> {1405, 2497, 2079, 2350, 747, 1792, 2412, 2615, 89, 2332, 1363, 102, 81, 2346, 122, 1356},
            new List<int> {1496, 2782, 2257, 2258, 961, 214, 219, 2998, 400, 230, 2676, 3003, 2955, 254, 2250, 2707},
            new List<int> {694, 669, 951, 455, 2752, 216, 1576, 3336, 251, 236, 222, 2967, 3131, 3456, 1586, 1509},
            new List<int> {170, 2453, 1707, 2017, 2230, 157, 2798, 225, 1891, 945, 943, 2746, 186, 206, 2678, 2156},
            new List<int> {3632, 3786, 125, 2650, 1765, 1129, 3675, 3445, 1812, 3206, 99, 105, 1922, 112, 1136, 3242},
            new List<int> {6070, 6670, 1885, 1994, 178, 230, 5857, 241, 253, 5972, 7219, 252, 806, 6116, 4425, 3944},
            new List<int> {2257, 155, 734, 228, 204, 2180, 175, 2277, 180, 2275, 2239, 2331, 2278, 1763, 112, 2054}

        };
        public static void Main(string[] args)
        {
            var checksum = new Checksum(PuzzleInput);
            Console.WriteLine(checksum.GetChecksum());
            Console.ReadKey();
        }
    }

    public class Checksum
    {
        private readonly List<List<int>> _input;
        public Checksum(List<List<int>> input)
        {
            _input = input ?? throw new ArgumentNullException(nameof(input));
        }

        public int GetChecksum()
        {
            List<int> differences = new List<int>();
            foreach (List<int> innerList in _input)
            {
                int minForList = innerList.Aggregate((current, next) => current < next ? current : next);
                int maxForList = innerList.Aggregate((current, next) => current > next ? current : next);

                differences.Add(maxForList - minForList);
            }

            return differences.Aggregate((current, next) => current + next);
        }

        public int GetCheckSum_part2()
        {
            List<int> quotients = new List<int>();
            foreach (List<int> innerlist in _input)
            {
                bool foundQuotient = false;
                for (int i = 0; i < innerlist.Count; i++)
                {
                    if (foundQuotient)
                        break;
                    if (innerlist.Count - i >= 0)
                    {
                        var quotient = ((float) innerlist[i] / (float) innerlist[i + 1] % 1);
                        if (quotient == 0.0)
                        {
                            quotients.Add((int)quotient);
                            foundQuotient = true;
                        }

                    }

                }
                if (foundQuotient)
                    break;
                
                innerlist.Add(innerlist.First());
                innerlist.RemoveAt(0);
            }
        }
    }
}
