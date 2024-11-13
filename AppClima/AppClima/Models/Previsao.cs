using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppClima.Models
{
    public class Previsao
    {
        public DateTime Data { get; set; }
        public string CondicaoDesc { get; set; }
        public int Minima { get; set; }
        public int Maxima { get; set; }
    }
}

