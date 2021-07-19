using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Film_projekt
{
    public class Film
    {
        public int FilmId { get; set; }
        public string Tytul { get; set; }
        public int RezyserId { get; set;  }
        public int Rok { get; set; }
        public string AktorzyId { get; set; }
    }
}
