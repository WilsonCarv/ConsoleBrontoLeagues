using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBrontoLeagues.Models
{
    public class BrontoResult
    {

        public bool HasErrors { get; set; }

        public IEnumerable<int> ErrorIndicies { get; set; }

        public List<BrontoResultItem> Items { get; set; }

        public override string ToString()
        {
            string cadena = "";
            int contador = 0;
            cadena += "HasErrors:" + HasErrors + "\n" + "ErrorIndicies" + ErrorIndicies + "\n";
            foreach (var item in Items)
            {
                cadena += item.ToString() + "\n";
                contador++;
            }
            if (HasErrors)
                contador = 0;
            cadena += "\n" + "Total contacts updated : " + contador;
            return cadena;
        }

    }
}
