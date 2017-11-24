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
    public partial class editSerie : Form
    {
        dbConnection db;
        serie updateSerie;
        public editSerie(serie Serie)
        {
            updateSerie = Serie;
            InitializeComponent();
            db = new dbConnection();
            db.connectToDB();
            populateRating();
            populateStatus();
            populatureCategories();
            fillFields();
            
        }
        private void populatureCategories()
        {
            DataTable t = db.getData("SELECT * FROM categorie");
            foreach (DataRow item in t.Rows)
            {
                cmbCategorie.Items.Add(item["serieCategorie"]);
            }
            cmbCategorie.SelectedIndex = 0;
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
        private void populateRating()
        {
            DataTable t = db.getData("SELECT * FROM rating");
            foreach (DataRow item in t.Rows)
            {
                cmbRating.Items.Add(item["Rating"]);
            }
            cmbRating.SelectedIndex = 0;
        }
        private void fillFields( )
        {
            tbName.Text = updateSerie.Name;
            numericUpDownEpisode.Value = updateSerie.Episode;
            numericUpDownSeason.Value = updateSerie.Season;
            cmbCategorie.SelectedItem = updateSerie.Type;
            cmbRating.SelectedItem = updateSerie.Rating;
            cmbStatus.SelectedItem = updateSerie.Status;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            db.updateSerie(updateSerie.Id.ToString() , tbName.Text, numericUpDownSeason.Value.ToString(), numericUpDownEpisode.Value.ToString(), Convert.ToString(cmbCategorie.SelectedIndex + 1), Convert.ToString(cmbRating.SelectedIndex + 1), Convert.ToString(cmbStatus.SelectedIndex + 1));
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            db.deleteData("DELETE FROM series WHERE idSeries = " + updateSerie.Id +"");
            this.Close();
        }
    }
}
