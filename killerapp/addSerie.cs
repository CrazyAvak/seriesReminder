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
    public partial class addSerie : Form
    {
        dbConnection db;
        public addSerie()
        {
            db = new dbConnection();
            db.connectToDB();
            InitializeComponent();
            populatureCategories();
            populateStatus();
            populateRating();
            
        }
        private void populatureCategories()
        {
            DataTable t = db.GetCategories();
            foreach (DataRow item in t.Rows)
            {
                cmbCategorie.Items.Add(item["serieCategorie"]);
            }
            cmbCategorie.SelectedIndex = 0;
        }
        private void populateStatus()
        {
            DataTable t = db.getStatus();
            foreach (DataRow item in t.Rows)
            {
                cmbStatus.Items.Add(item["serieStatus"]);
            }
            cmbStatus.SelectedIndex = 0;
        }
        private void populateRating()
        {
            DataTable t = db.getRating();
            foreach (DataRow item in t.Rows)
            {
                cmbRating.Items.Add(item["Rating"]);
            }
            cmbRating.SelectedIndex = 0;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            db.InsertSerie(tbName.Text, numericUpDownSeason.Value.ToString(), numericUpDownEpisode.Value.ToString(), Convert.ToString(cmbCategorie.SelectedIndex + 1), Convert.ToString(cmbRating.SelectedIndex + 1), Convert.ToString(cmbStatus.SelectedIndex + 1));
        }
    }
}
