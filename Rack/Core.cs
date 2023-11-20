using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rack
{
    class Core
    {
        public static bool Rack(double multiplayer, bool change_tempo)
        {
            foreach (var note in Ust.Current.Notes)
            {
                if (note.Number == Number.Prev || note.Number == Number.Next)
                    continue;
                note.Length = (int)(note.Length * multiplayer);
            }
            return true;
        }
    }
}
