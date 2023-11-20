using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Rack
{

    public class UNote
    {
        public object UI { get; set; }
        public int InitLength { get; set; }
        public int Preutterance { get; set; }
        public int NoteNum { get; set; }
        public UNote Parent { get; set; }
        public List<UNote> Children { get; set; }

        private string _number;
        private string _lyric;
        private int _length;
        private string _flags = "";

        public string CleanLyric = "";
        public string Prefix = "";
        public string Suffix = "";

        public string Lyric { get => _lyric; set => _lyric = value; }
        public string Number { get => _number; set => _number = value; }
        public string Flags { get => _flags; set => _flags = value; }
        public bool IsRest { get; set; }
        public int Length
        {
            get { return _length; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception($"Got negative note length on note {Lyric} ");
                    Length = 10;
                }
                else _length = value;
            }
        }
        public bool MustSkip
        {
            get
            {
                return Flags.Contains("x");
            }
        }

        public UNote()
        {
            Children = new List<UNote>();
            
        }


        public UNote Clone()
        {
            UNote note = new UNote()
            {
                Number = Number,
                Length = Length,
                Preutterance = Preutterance,
                Lyric = Lyric,
                NoteNum = NoteNum,
                InitLength = InitLength,
                IsRest = IsRest
            };
            return note;
        }

        public string[] GetText(bool last = false)
        {
            string lyric = Lyric;
            if (lyric == "r") lyric = "rr";
            string number = Number == Rack.Number.LastNumber ? Rack.Number.Insert : Number;
            if (last) number = Rack.Number.LastNumber;
            List<string> text = new List<string>
            {
                number,
                $"Length={Length}",
                $"Lyric={lyric}",
                $"NoteNum={NoteNum}",
                $"Flags={Flags}"
            };
            if (Number == Rack.Number.Insert) text.Add("Modulation=0");
            return text.ToArray();
        }

        public void ReadLyric(string lyric, bool keepRest = false)
        {
            Lyric = lyric;
        }

    }

}
