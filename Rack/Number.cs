using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rack
{
    class Number
    {

        public const string Next = "[#NEXT]";
        public const string Prev = "[#PREV]";
        public const string Insert = "[#INSERT]";
        public const string Delete = "[#DELETE]";
        public const string Version = "[#VERSION]";
        public const string Setting = "[#SETTING]";
        public static string LastNumber;


        public static bool IsNote(string number)
        {
            if (number.Length < 6) return false;
            if (number == Next) return true;
            if (number == Prev) return true;
            return int.TryParse(number.Substring(2, 4), out int i);
        }

        public static string GetNumber(int i)
        {
            return $"[#{i.ToString().PadLeft(4, '0')}]";
        }

        public static int GetInt(string number)
        {
            //if (number == "[#NEXT]") return Ust.Notes.Count();
            return int.Parse(number.Substring(2, 4));
        }
    }

}
