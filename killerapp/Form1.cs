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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addSerie addSerie = new addSerie();
            addSerie.Show();
        }
    }
}
