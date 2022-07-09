using System;
using Prisoners_Puzzle.Models;
namespace Prisoners_Puzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            double success = 0;
            for(int i = 0; i < 500; i++)
            {
                RoomWithBox rwb = new RoomWithBox(100);
                rwb.SwapBoxes();
                Console.WriteLine();
                bool result = rwb.StartSimulation();
                if (result) success++;
            }
            Console.WriteLine();
            Console.WriteLine("Success: " + success);
            Console.WriteLine("%: " + (success / 500));
        }
    }
}
