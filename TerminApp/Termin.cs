using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminApp
{
    public class Termin :  IComparable<Termin>
    {
        public Ort Ort { get; set; }
        public DateTime DatumUndUhrzeit { get; set; }
        public int Prioritaet { get; set; }
        public string Thema { get; set; }


        public Termin(string thema, Ort ort, DateTime dateTime, int prioritaet)
        {
            Thema = thema;
            Ort = ort;
            DatumUndUhrzeit = dateTime;
            Prioritaet = prioritaet;
        }



        public override bool Equals(object ?o) => this.Equals(o as Termin);

        public bool Equals(Termin? other)
        {
            if (other == null)
            {
                return false;
            }

            

            return (GetHashCode() == other.GetHashCode()); 
        }

        public override int GetHashCode() => (Ort.Stadt, Ort.Postleitzahl, Ort.Strasse, DatumUndUhrzeit).GetHashCode(); // wichtig denn diese methode wird bei contains verwendet

        public override string ToString()
        {
            return "Thema: " + Thema + "\n" +
                   "Ort: " + Ort.Stadt + "/" + Ort.Postleitzahl + "/" + Ort.Strasse + "\n" +
                   "DatumUndUhrzeit: " + "\n" + DatumUndUhrzeit + "\n" +
                   "Priorität: " + "\n" + Prioritaet;
        }

        public int CompareTo(Termin? other)
        {
            if (other == null)
                return 1;

            // Vergleich der Prioritäten
            return Prioritaet.CompareTo(other.Prioritaet);
        }
    }
}
