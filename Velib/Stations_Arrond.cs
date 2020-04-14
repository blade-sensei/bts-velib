using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Velib
{
    struct Station_Arronds
    {
        private string adresse;

        public string Adresse
        {
            get { return adresse; }
            set { adresse = value; }
        }
        private bool ouvert;

        public bool Ouvert
        {
            get { return ouvert; }
            set { ouvert = value; }
        }
        private bool bonus;

        public bool Bonus
        {
            get { return bonus; }
            set { bonus = value; }
        }

        public Station_Arronds(string adresse_st, bool ouvert_st, bool bonus_st)
        {
            this.adresse = adresse_st;
            this.ouvert = ouvert_st;
            this.bonus = bonus_st;
 
        }


    }
}
