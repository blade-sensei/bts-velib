using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace Velib
{
    public partial class Form1 : Form
    {
        private List<Station> lesStation;
        private Carte laCarte;
        private string[] lesInfos;
        private string adresse; 
         
        

        public Form1()
        {
            InitializeComponent();
            this.laCarte = Paserelle.getCarte(); //la carte de stations
            this.lesStation = new List<Station>(); //stations d'un arrondissement ou dep
            
            
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public void remplitdtg(string arrondissement_dtg)
        { //Fonction pour remplire dtg en fonction de l'arrondissement clické//
            datagridInfo.DataSource = null; //on vide le tableau
            setLesStations(arrondissement_dtg); //onbitent les arrondissement
            datagridInfo.DataSource = lesStation; //remplis le tableau 
            datagridInfo.Columns["Numero"].Visible = false;
            datagridInfo.Columns["Adresse"].Width = 262;

        }


        private void setLesStations(string arrondissement)
        {//methode pour avoir les stations d'un arrondissement ou dep//
            lesStation.Clear();
            List<Station> StationLaCarte; //Stations de toute la carte
            StationLaCarte = laCarte.Mes_stations;
            foreach (Station s in StationLaCarte) //on selectionne chaque station
            {
                string arr = s.Arrondissement; //on prends l'arrdon de chque station "s"
                if (arr == arrondissement) //on compare si elle est égale au paramètre
                { 
                    lesStation.Add(s);
                }
                
            }            

        }
        private void chargerLesLabels(string[] infos_charger)
        {
            if (infos_charger[1] == null)
            {
                lbpoint.Text = infos_charger[0]+" "+"Informations indisponibles";
                lbcb.Visible = false;
                lbNbpa.Visible = false;
                lbpadispo.Visible = false;
                lbDispo.Visible = false;
            }
            else
            {
                
                lbpoint.Text = infos_charger[0];
                lbDispo.Text = infos_charger[1];
                lbNbpa.Text = infos_charger[3];
                lbpadispo.Text = infos_charger[2];
                string cb = infos_charger[4];
                if (cb == "1")
                {
                    lbcb.Text = "OUI";
                }
                else
                    lbcb.Text = "NON";
            }


        }

        //Remplie le data grid selon le rb choisie//
        private void rbArr1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton bt = (RadioButton)sender;
            string text = bt.Text;
            remplitdtg(text);
        }

        private void rbArr2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton bt = (RadioButton)sender;
            remplitdtg(bt.Text);
        }

        private void rbArr3_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton bt = (RadioButton)sender;
            remplitdtg(bt.Text);
        }

        private void rbArr4_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton bt = (RadioButton)sender;
            remplitdtg(bt.Text);
        }

        private void rbArr5_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton bt = (RadioButton)sender;
            remplitdtg(bt.Text);

        }

        private void rbArr6_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton bt = (RadioButton)sender;
            remplitdtg(bt.Text);
        }

        private void rbArr19_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton bt = (RadioButton)sender;
            remplitdtg(bt.Text);
        }

        private void rbArr15_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton bt = (RadioButton)sender;
            remplitdtg(bt.Text);
        }

        private void rbArr18_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton bt = (RadioButton)sender;
            remplitdtg(bt.Text);
        }

        private void radioButton14_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton bt = (RadioButton)sender;
            remplitdtg(bt.Text);
        }

        private void rbArr17_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton bt = (RadioButton)sender;
            remplitdtg(bt.Text);
        }

        private void rbArr16_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton bt = (RadioButton)sender;
            remplitdtg(bt.Text);
        }

        private void rbArr13_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton bt = (RadioButton)sender;
            remplitdtg(bt.Text);
        }

        private void rbArr12_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton bt = (RadioButton)sender;
            remplitdtg(bt.Text);
        }

        private void rbArr11_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton bt = (RadioButton)sender;
            remplitdtg(bt.Text);
        }

        private void rbArr10_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton bt = (RadioButton)sender;
            remplitdtg(bt.Text);
        }

        private void rbArr9_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton bt = (RadioButton)sender;
            remplitdtg(bt.Text);
        }

        private void rbArr8_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton bt = (RadioButton)sender;
            remplitdtg(bt.Text);
        }

        private void rbArr7_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton bt = (RadioButton)sender;
            remplitdtg(bt.Text);
        }

        private void rbArr20_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton bt = (RadioButton)sender;
            remplitdtg(bt.Text);
        }

        private void radioButton23_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton bt = (RadioButton)sender;
            remplitdtg(bt.Text);
        }

        private void radioButton21_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton bt = (RadioButton)sender;
            remplitdtg(bt.Text);
        }

        private void radioButton22_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton bt = (RadioButton)sender;
            remplitdtg(bt.Text);
        }
      // Fin du remplissage du datagrid avec le rb//

        private void datagridInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        { //Remplissage des labes quand on click sur une cellule de DTG
            string numero = datagridInfo.CurrentRow.Cells[0].Value.ToString(); //Celulle current, on recupere la colone 0
            string adresse = datagridInfo.CurrentRow.Cells[1].Value.ToString();//colone 1 "adresse"
            //lesInfos = Paserelle.getDispo(numero, adresse);//on récuprer les infos de l'adresse selectionnée//
            //chargerLesLabels(lesInfos);// on remplis les labes selon les infos
            this.adresse = adresse;
            string url = Paserelle.getDispo(numero,adresse) + numero;
            HttpWebRequest requete = (HttpWebRequest)WebRequest.Create(url);
            requete.Method = WebRequestMethods.Http.Get;
            requete.BeginGetResponse(new AsyncCallback(getValAsynchrone), requete);

            

        }


    }
}
