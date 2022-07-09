using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prisoners_Puzzle.Models
{
    public class RoomWithBox
    {
        private List<Prisoner> _prisoners = null;
        private Random rnd;
        private int[] _boxes;
        private int _numOfTries;
        public RoomWithBox(int numOfBox)
        {
            rnd = new Random();
            if (numOfBox < 10 || numOfBox > 9999)
            {
                Console.WriteLine("min is 10, max is 9999");
                numOfBox = 100;     
            }
            _numOfTries = numOfBox / 2;
            this._boxes = new int[numOfBox];
            _prisoners = new List<Prisoner>();
            for(int i = 0;i < numOfBox; i++)
            {
                _boxes[i] = i;
                _prisoners.Add(new Prisoner(i));
            }
        }

        public RoomWithBox(int numOfBox, int tries) : this(numOfBox)
        {
            _numOfTries = tries;
        }

        public void SwapBoxes()
        {
            if(_boxes != null)
            {
                for(int i = 0; i < _boxes.Length * 3; i++)
                {
                    int a = rnd.Next(0, _boxes.Length);
                    int b = rnd.Next(0, _boxes.Length);
                    int value = _boxes[a];
                    _boxes[a] = _boxes[b];
                    _boxes[b] = value;
                }
            }
        }

        public void PrintBoxes()
        {
            if(_boxes != null)
            {
                for (int i = 0; i < _boxes.Length; i++)
                {
                    if (i % 10 == 0) Console.WriteLine();
                    Console.Write(_boxes[i] + " ");
                }
            }
        }

        public bool StartSimulation()
        {
            bool allFound = true;
            for(int i = 0;i < _prisoners.Count; i++)
            {
                Prisoner prisoner = _prisoners[i];
                for(int j = 0; j < _numOfTries; j++)
                {
                    if (_boxes[prisoner.GonnaWatch] != prisoner._id)
                    {
                        prisoner.GonnaWatch = _boxes[prisoner.GonnaWatch];
                        prisoner.WatchedBox++;
                    }
                    else
                    {
                        Console.WriteLine("Prisoner " + prisoner._id + " has found, used " + prisoner.WatchedBox + " tries");
                        break;
                    }
                    if (j == _numOfTries - 1)
                    {
                        Console.WriteLine("Prisoner " + prisoner._id + " has used " + prisoner.WatchedBox + " tries, but hasn`t found his box...");
                        allFound = false;
                    }
                }
                if (!allFound)
                {
                    break;
                }
            }
            return allFound;
        }
    }
}
