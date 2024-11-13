using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppClima.Models
{
    public class Clima
    {
        public DateTime Data { get; set; }
        public string Condicao { get; set; }
        public int Maxima { get; set; }
        public int IndiceUV { get; set; }
        public string CondicaoDesc { get; set; }
    }
}

