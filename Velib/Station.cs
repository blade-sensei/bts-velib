using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Velib
{
    class Station
    {
        private string numero;
        private string adresse;
        private bool ouvert;
        private bool bonus;
        private string arrondissement;

       
        public string Numero
        {
            get { return this.numero; }
        }
        public string Adresse 
        {
            get { return this.adresse; }
        }
        public bool Ouvert
        {
            get { return this.ouvert; }
        }
        public bool Bonus 
        {
            get { return this.bonus; }
        }
        public string Arrondissement
        {
            get { return this.arrondissement; }
        }

        //--methodes--//

        public Station(string un_numero, string une_adresse, bool s_ouvert, bool un_bonus)
        {
            int taille; //taille du numero//
            int numero_bis; //numero convertit en type INT//

            numero = un_numero;
            adresse = une_adresse;
            ouvert = s_ouvert;
            bonus = un_bonus;

            
            numero_bis = Convert.ToInt32(un_numero);
            taille = un_numero.Length;
            // calculs pour avoir l'arrondissement//
            if (taille == 3)
            {
                if (numero_bis == 903)
                {
                    this.arrondissement = "13";
                }
                else if (numero_bis == 906)
                {
                    this.arrondissement = "10";
                }
                else
                    this.arrondissement = "7";
            }
            else if (numero_bis < 21000)
            {
                if (numero_bis < 10000)
                {
                    this.arrondissement = un_numero.Substring(0, 1); //1er chiffre de numero
                }
                else
                {
                    this.arrondissement = un_numero.Substring(0, 2); //2 premier chiffres
                }
            }
            else if (numero_bis >= 21000)
            {
                this.arrondissement = "9" + un_numero.Substring(0, 1);//9+le 1er chiffre//
            }
            //** fin des calculs **//
        }

        public override string ToString()
        {
            return arrondissement+" "+adresse+" "+bonus+"  "+ouvert+"\n";
        }
        
        
    }
}
