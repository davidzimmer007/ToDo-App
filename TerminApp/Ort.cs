using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminApp
{
    public class Ort 
    {
        public int Postleitzahl { get; set; }
        public string Stadt { get; set; }
        public string Strasse { get; set; }

        public Ort(int postleitzahl, string stadt, string strasse)
        {
            Postleitzahl = postleitzahl;
            Stadt = stadt;
            Strasse = strasse;
        }


        public bool Equals(Ort? other)
        {
            if (other is null)
            {
                return false;
            }

            
            return (GetHashCode() == other.GetHashCode());
        }

        public override int GetHashCode() => (Postleitzahl, Stadt, Strasse).GetHashCode();

        
    }
}
