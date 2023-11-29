using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminApp
{
    public class TerminKalender 
    {
        private List<Termin> _termine;
        public List<Termin> Termine
        {
            get { return _termine; }
            set
            {
                if (value != null)
                {
                    _termine = value;
                }
                else
                {
                    throw new ArgumentNullException("Die Liste ist Null");
                }

            }
        }

        

        public TerminKalender(List<Termin> termine)
        {
            Termine = termine;
        }

        public TerminKalender()
        {

        }

        public int GetAnzTeil(string teil)
        {
            int anz = 0;
            foreach (var termin in Termine)
            {
                if (termin.Thema.Contains(teil))
                {
                    anz++;
                }
            }
            return anz;
        }

        public void SortTermineDatum()
        {
            Termine.Sort((t1,t2) => t1.DatumUndUhrzeit.CompareTo(t2.DatumUndUhrzeit));
              
            
        }

        public void SortTerminePrioritaet()
        {
            Termine.Sort();

        }

        public void AddTermin(Termin termin)
        {
            if (termin != null && !Termine.Contains(termin))
            {
                Termine.Add(termin);
            }
            else
            {
                throw new ArgumentException("Fehler beim Adden!");
            }
        }

        public void RemoveTermin(Termin termin)
        {
            if (termin != null && Termine.Contains(termin))
            {
                Termine.Remove(termin);
            }
            else
            {
                throw new ArgumentNullException("Der übergebene Termin ist Null.");
            }
        }



    }
}