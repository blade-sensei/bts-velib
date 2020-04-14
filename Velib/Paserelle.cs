using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Xml;

namespace Velib
{
    class Paserelle
    {
        private static string urlCarto = "http://www.velib.paris.fr/service/carto";
        private static string urlDispo = "http://www.velib.paris/service/stationdetails/";

        public static Carte getCarte()
        {
            Carte carte_station = new Carte(); 
            WebRequest requete; //on créer une variable requete Web
            requete = WebRequest.Create(urlCarto); //passer en paramètre un url//
            requete.Method = WebRequestMethods.Http.Get; //on précise la methode GET// 
            requete.Proxy = HttpWebRequest.GetSystemWebProxy();
            NetworkCredential monid = new NetworkCredential("COYLAC-J15","177494");
            requete.Proxy.Credentials = monid;
            WebResponse reponse; //variable pour la réponse de la requete//
            reponse = requete.GetResponse(); //reponse de requete//
            
            StreamReader flux = new StreamReader(reponse.GetResponseStream());
            //GetReponse retourne le flux de données de la requetes//
            //StreamReader permet de lire le flux//
            XmlReader xml = XmlReader.Create(flux); //lire données en xml//
            xml.ReadToFollowing("marker"); //Lire jusqu'à toucher le mot marker dans le xml
            do
            {
                string numero;
                string adresse;
                string ouvert;
                string bonus_xml;
                bool open;
                bool bonus;
                numero = xml.GetAttribute("number"); //xml/GetAttribute recuper la valeur <marker number="">
                adresse = xml.GetAttribute("fullAddress"); //valeur adresse
                ouvert = xml.GetAttribute("open"); //valeur open//
                bonus_xml = xml.GetAttribute("bonus");
                
                //-- Obtenier open et bonus en mode BOOL --//
                if (Convert.ToInt16(ouvert) == 1) //converti le caractère ouvert en String pour comparer//
                {
                    open = true;
                }
                else
                    open = false;

                if (Convert.ToInt16(bonus_xml) == 1)
                {
                    bonus = true;
                }
                else
                    bonus = false;
                //--FIN--//

                Station s1 = new Station(numero,adresse,open,bonus); //Créer une station//
                carte_station.ajouteStation(s1); //ajouter la station à la carte "velo" //
                
            }
            while (xml.ReadToNextSibling("marker")); //s'arrete quand il trouve un autre marker"///

            return carte_station; //retourne la carte VELO //

        }
        public static string[] getDispo(string numero_station,string adresse_station)
        {
            
            try
            {
                string urlInfos = urlDispo+numero_station;
                WebRequest requete_infos = WebRequest.Create(urlInfos); //requete information
                requete_infos.Method = WebRequestMethods.Http.Get;
                WebResponse reponse_infos = requete_infos.GetResponse();
                StreamReader flux_infos = new StreamReader(reponse_infos.GetResponseStream());
                XmlReader xml_infos = XmlReader.Create(flux_infos);
                string[] infos = new string[8]; //8 cases d'informations
                int i = 1; // pour commencer a remplir à partir de la case 1 
                infos[0] = adresse_station;//par defaut 0 est l'adresse
                while (xml_infos.Read()) //lire tout le fichier
                {
                    if (xml_infos.NodeType == XmlNodeType.Text) //PAS COMPRIS
                    {
                        
                        infos[i++] = xml_infos.Value; //on ajoute la valeur ses balises
                        //dans le tableau 
                        
                    }
                    
                }
                
                return infos;
            }
            catch (Exception e)
            {
                Console.Write(e.Message+""+"ERREURS TEST");
                return null;
            }
        }
        
            
        }
  }
                