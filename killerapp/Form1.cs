using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace killerapp
{
    public partial class Form1 : Form
    {
        dbConnection db;
        List<serie> series;
        public Form1()
        {
            InitializeComponent();
             db = new dbConnection();
            db.connectToDB();
            populateStatus();
            populateSeriesList2(false);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addSerie addSerie = new addSerie();
            addSerie.FormClosing += AddSerie_FormClosing1;          
            addSerie.Show();
        }

        private void AddSerie_FormClosing1(object sender, FormClosingEventArgs e)
        {
            populateSeriesList2(false);
        }     

        private void populateSeriesList2(bool isstatusChange)
        {
            listSeries.Items.Clear();
            series = new List<serie>();
            DataTable t;
            if (isstatusChange)
            {
                 t = db.getData("SELECT idSeries,Name, Season, Episode, categorie.serieCategorie , status.serieStatus, rating.Rating " +
                            "FROM `series` INNER JOIN rating ON series.Rating_idRating = rating.idRating INNER JOIN categorie ON series.Categorie_idType = categorie.idType INNER JOIN status ON series.Status_idStatus = status.idStatus" +
                            " WHERE status.serieStatus = '" + cmbStatus.Text + "'");
            }
            else
            {
                 t = db.getData("SELECT idSeries,Name, Season, Episode, categorie.serieCategorie , status.serieStatus, rating.Rating " +
                            "FROM `series` INNER JOIN rating ON series.Rating_idRating = rating.idRating INNER JOIN categorie ON series.Categorie_idType = categorie.idType INNER JOIN status ON series.Status_idStatus = status.idStatus");
            }
            
            foreach (DataRow item in t.Rows)
            {
                serie serie = new serie();
                serie.Id = Convert.ToInt32(item["idSeries"]);
                serie.Name = item["Name"].ToString();
                serie.Season = Convert.ToInt32(item["Season"]);
                serie.Episode = Convert.ToInt32(item["episode"]);
                serie.Type = item["serieCategorie"].ToString();
                serie.Status = item["serieStatus"].ToString();
                serie.Rating = item["rating"].ToString();
                series.Add(serie);
            }
            foreach (var item in series)
            {
                string serie = "";
                serie = item.Id + " ," + item.Name + ", Season:" + item.Season + ", Episode:" + item.Episode + ", Categorie:" + item.Type + ", Status:" + item.Status + ", Rating:" + item.Rating;
                listSeries.Items.Add(serie);
            }
        }

        private void populateSeriesList()
        {
            listSeries.Items.Clear();
            DataTable t = db.getData("SELECT Name, Season, Episode, categorie.serieCategorie , status.serieStatus, rating.Rating " +
                "FROM `series` INNER JOIN rating ON series.Rating_idRating = rating.idRating INNER JOIN categorie ON series.Categorie_idType = categorie.idType INNER JOIN status ON series.Status_idStatus = status.idStatus");
            foreach (DataRow item in t.Rows)
            {
                string serie = "";
                serie = Convert.ToString(item["Name"]) + ", Season:" + item["Season"] + ", Episode:" + item["Episode"] + ", Categorie:" + item["serieCategorie"] + ", Status:" + item["serieStatus"] + ", Rating:" + item["Rating"];
                listSeries.Items.Add(serie);
            }
        }
        private void populateStatus()
        {
            cmbStatus.Items.Add("none");
            DataTable t = db.getData("SELECT * FROM status");
            foreach (DataRow item in t.Rows)
            {
                cmbStatus.Items.Add(item["serieStatus"]);
            }
            cmbStatus.SelectedIndex = 0;
        }

        private void listSeries_DoubleClick(object sender, EventArgs e)
        {
            string aSerie;
            try
            {
                aSerie = listSeries.SelectedItem.ToString();
                string id = aSerie.Substring(0, aSerie.IndexOf(" "));
                serie serie = new serie();
                foreach (var item in series)
                {
                    if (item.Id == Convert.ToInt32(id))
                    {
                        serie = item;
                    }
                }
                editSerie editSerie = new editSerie(serie);
                editSerie.Show();
                editSerie.FormClosing += EditSerie_FormClosing;
            }
            catch (Exception d)
            {

                
            }
            
                
        }

        private void EditSerie_FormClosing(object sender, FormClosingEventArgs e)
        {
            populateSeriesList2(false);
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbStatus.Text == "none")
            {
                populateSeriesList2(false);
            }
            else
            {
                populateSeriesList2(true);              
            }
        }
    }
}
