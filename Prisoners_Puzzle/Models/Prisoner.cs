using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prisoners_Puzzle.Models
{
    public class Prisoner
    {
        public int _id { get; }
        public int GonnaWatch { get; set; }
        public int WatchedBox { get; set; }
        public Prisoner(int id)
        {
            _id = id;
            WatchedBox = 0;
            GonnaWatch = id;
        }
    }
}
