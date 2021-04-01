using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace GICAS_KPRZ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                String chaineConnexion;
                String ligne;
                StreamReader fichier = new StreamReader("config.txt");
                ligne = fichier.ReadLine();
                while (ligne != null)
                {
                    chaineConnexion = "data source=" + ligne + "; initial catalog=GICAS;user id=utilGICAS;password=caribou;";
                    SqlConnection maConnexion;
                    maConnexion = new SqlConnection(chaineConnexion);
                    maConnexion.Open();

                    String req;
                    req = "select idClub, NomClub, Ville, Departement from Club order by IdClub";
                    SqlCommand cmd = new SqlCommand(req, maConnexion);

                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {


                        String nom = (String)rdr["NomClub"];
                        String ville = (String)rdr["Ville"];
                        String departement = (String)rdr["Departement"];
                        String numdept = rdr["idClub"].ToString();
                        ListeCur.Items.Add("#" + numdept + " - " + nom + " " + ville + " " + departement);
                    }
                    ligne = fichier.ReadLine();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "/////////////" + ex.StackTrace);
                return;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
c; ; ; ; ; ; ; ; ; ;