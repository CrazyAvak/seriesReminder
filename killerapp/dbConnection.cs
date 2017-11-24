using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace killerapp
{
    class dbConnection
    {
        MySqlConnection conn;
        public void connectToDB()
        {
            //Server=localhost;Database=seriesreminder;Uid=root;pwd=;
            string connectionString = null;
            
            connectionString = "Server=localhost;Database=seriesreminder;Uid=root;Pwd=;";
            conn = new MySqlConnection(connectionString);            
            try
            {
                
                
            }
            catch(Exception e)
            {
                MessageBox.Show("not connected");
            }

        }


        public DataTable getData(string query)
        {
            DataTable dtable = new DataTable();
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter();
                myAdapter.SelectCommand = cmd;
                myAdapter.Fill(dtable);
                conn.Close();
                return dtable;

            }
            catch (Exception e)
            {
                throw;
            }
        }
        public void deleteData(string query)
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                conn.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
                    
        public void InsertSerie(string name, string season, string episode, string categorie_id, string rating_id, string status_id)
        {
            DateTime theDate = DateTime.Now;            
            try
            {
                conn.Open();
                string query = "INSERT into series(Name, Season, Episode,Date_created, date_updated, Categorie_idType, Rating_idRating, Status_idStatus) " +
                    "values('" + name + "','" + season + "','" + episode + "','" + theDate.ToString("yyyy-MM-dd H:mm:ss") + "','" + theDate.ToString("yyyy-MM-dd H:mm:ss") + "','" + categorie_id + "','" + rating_id + "','" + status_id + "');";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void updateSerie(string id, string name, string season, string episode, string categorie_id, string rating_id, string status_id)
        {
            DateTime theDate = DateTime.Now;
            try
            {
                conn.Open();
                string query = "UPDATE series " +
                    "SET Name = '" + name + "', Season = '" + season + "', Episode = '" + episode + "', date_updated= '" + theDate.ToString("yyyy-MM-dd H:mm:ss") + "', " +
                    "Categorie_idType= '" + categorie_id + "', Rating_idRating= '" + rating_id + "',Status_idStatus= '" + status_id + "' WHERE idSeries = '" + id + "' ";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        
    }
}
