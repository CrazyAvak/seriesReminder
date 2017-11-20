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
        public Form1()
        {
            InitializeComponent();
             db = new dbConnection();
            db.connectToDB();
            populateStatus();
            populateSeriesList2();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addSerie addSerie = new addSerie();
            addSerie.Show();
        }

        private void populateSeriesList2()
        {
            List<serie> series = new List<serie>();
            DataTable t = db.getData("SELECT Name, Season, Episode, categorie.serieCategorie , status.serieStatus, rating.Rating " +
                            "FROM `series` INNER JOIN rating ON series.Rating_idRating = rating.idRating INNER JOIN categorie ON series.Categorie_idType = categorie.idType INNER JOIN status ON series.Status_idStatus = status.idStatus");
            foreach (DataRow item in t.Rows)
            {
                serie serie = new serie();
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
                serie = item.Name + ", Season:" + item.Season + ", Episode:" + item.Episode + ", Categorie:" + item.Type + ", Status:" + item.Status + ", Rating:" + item.Rating;
                listSeries.Items.Add(serie);
            }
        }

        private void populateSeriesList()
        {

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
            DataTable t = db.getData("SELECT * FROM status");
            foreach (DataRow item in t.Rows)
            {
                cmbStatus.Items.Add(item["serieStatus"]);
            }
            cmbStatus.SelectedIndex = 0;
        }
    }
}
