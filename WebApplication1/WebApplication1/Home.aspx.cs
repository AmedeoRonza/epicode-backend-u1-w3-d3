using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cinema
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string Cinema = ConfigurationManager.ConnectionStrings["Cinema"].ConnectionString;
            SqlConnection conn = new SqlConnection(Cinema);
            string selectedValue = DropDownList2.SelectedValue;

            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "INSERT INTO Cinema (Nome, Cognome, SalaNord, SalaSud, SalaEst, Ridotto) VALUES (@Nome, @Cognome, @SalaNord, @SalaSud, @SalaEst, @Ridotto)";
                command.Parameters.AddWithValue("@Nome", Nome.Text);
                command.Parameters.AddWithValue("@Cognome", Cognome.Text);
                command.Parameters.AddWithValue("@SalaNord", selectedValue == "Nord" ? true : false);
                command.Parameters.AddWithValue("@SalaSud", selectedValue == "Sud" ? true : false);
                command.Parameters.AddWithValue("@SalaEst", selectedValue == "Est" ? true : false);
                command.Parameters.AddWithValue("@Ridotto", CheckBox1.Checked);

                command.ExecuteNonQuery();
                Response.Write("Prenotazione Effettuata 👍");

            }
            catch (Exception ex)
            {
                Response.Write("Errore");
                Response.Write(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }



 }
    }
