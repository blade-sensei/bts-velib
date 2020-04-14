using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Velib
{
    class Carte
    {
        private List<Station> mes_stations;

        public List<Station> Mes_stations
        {
            get { return mes_stations; }
        }
        public Carte() //constructeur//
        {
            this.mes_stations = new List<Station>();
        }

        public void ajouteStation(Station une_station) 
        {
            this.mes_stations.Add(une_station);
            //ajoute une station à la liste de station (carte)
        }

        public Station getLaStation(int i)
        {
            Station demande = mes_stations[i];
            return demande;
            //retourne une station demandé //
        }

        public int nbStations()
        {
            int nbr_stations = mes_stations.Count();
            return nbr_stations;
            //retourne le nombre de stations dans la liste//
        }
    }
}
