using System;
using Prisoners_Puzzle.Models;
namespace Prisoners_Puzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            double success = 0;
            double simulationsCount = 1000;
            int numOfBox = 100;
            for(int i = 0; i < simulationsCount; i++)
            {
                RoomWithBox rwb = new RoomWithBox(numOfBox);
                rwb.SwapBoxes();
                rwb.PrintBoxes();
                Console.WriteLine();
                bool result = rwb.StartSimulation();
                if (result) success++;
            }
            Console.WriteLine();
            Console.WriteLine("Successfull tries: " + success + " of " + simulationsCount);
            Console.WriteLine("Success rate: " + (success / simulationsCount) *100 + "%");
        }
    }
}
