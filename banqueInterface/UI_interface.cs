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
using Microsoft.VisualBasic;

using appBanque;
namespace banqueInterface
{
    public partial class UI_interface : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Banque3; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=true;");
        static Client c1;
        float solde;
        // public object Interaction { get; private set; }

        public UI_interface(Client c)
        {
            c1 = c;

            InitializeComponent();
            label4.Text = c1.afficher();
            dataGridView1.Hide();
            /*  SqlDataReader reader = Selecte("select tauxinteret, valeurs from compte c join CompteEpargne ce on ce.idCompte=c.id "
                  + "join devise d on c.idDevise = d.id where c.idClient =" + c.id);
              if (reader.HasRows)

              {

                  DataTable dt = new DataTable();

                  dt.Load(reader);

                  dataGridView1.DataSource = dt;

              }*/
            // MessageBox.Show(c.comptes[0].afficher());


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "CompteEpargne")
            {
                SqlDataReader reader = Selecte("select tauxinteret, valeurs from compte c join CompteEpargne ce on ce.idCompte=c.id "
                 + "join devise d on c.idDevise = d.id where c.idClient =" + c1.id);
                if (reader.HasRows)

                {

                    DataTable dt = new DataTable();

                    dt.Load(reader);

                    dataGridView1.DataSource = dt;

                }
                dataGridView1.Show();


            }
            else if (comboBox1.SelectedItem.ToString() == "CompteCourant")
            {
                /*select* from compte c join CompteCourant cc on cc.idCompte = c.id
            join devise d on c.idDevise = d.id where idClient = 1
            and cc.id not in (select IdCompteCr from ComptePayant);*/
                SqlDataReader reader = Selecte("select decouvert, valeurs from compte c" +
                    " join CompteCourant cc on cc.idCompte=c.id" +
                   " join devise d on c.idDevise = d.id where idClient =" + c1.id +
                   " and cc.id not in (select IdCompteCr from ComptePayant)");
                if (reader.HasRows)
                {

                    DataTable dt = new DataTable();

                    dt.Load(reader);

                    dataGridView1.DataSource = dt;

                }
                dataGridView1.Show();


            }
            else if (comboBox1.SelectedItem.ToString() == "comptePayant")
            {
                /*select * from compte c join CompteCourant cc on c.id = cc.idCompte
                   join comptePayant cp on cc.id = cp.IdCompteCr
                   join devise d on c.idDevise = d.id where c.Id = 1
                        }*/
                SqlDataReader reader = Selecte("select decouvert, valeurs  from compte c join CompteCourant cc on c.id = cc.idCompte" +
                   " join comptePayant cp on cc.id = cp.IdCompteCr " +
                  " join devise d on c.idDevise = d.id where c.Id = " + c1.id);
                if (reader.HasRows)
                {

                    DataTable dt = new DataTable();

                    dt.Load(reader);

                    dataGridView1.DataSource = dt;

                }
                dataGridView1.Show();

            }
            else dataGridView1.Hide();
        }
       private SqlDataReader Selecte(string commande)
        {

            if (connection.State != System.Data.ConnectionState.Open) connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlDataReader reader;
            adapter.SelectCommand = new SqlCommand(commande, connection);
            reader = adapter.SelectCommand.ExecuteReader();
            adapter.SelectCommand.Dispose();

            return reader;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string message, title, defaultvalue;
            object myValue;
            //Set prompt
            message = "Entrez le solde que vous voulez crediter: ";
            //Set title.
            title = "CREDIT";

            // Set defaulte value
            defaultvalue = "Code A minute: ";
            //Display
            myValue = Interaction.InputBox(message, title, defaultvalue);
            //if user has clicked cancel, set my value to defaultvale
            if ((string)myValue == "")
            {
                myValue = defaultvalue;
                Microsoft.VisualBasic.Interaction.MsgBox("Operation annulée ",
                    MsgBoxStyle.OkOnly | MsgBoxStyle.Information, "c# demo");
            }
            else
            {
                Interaction.MsgBox("La valeur est " + myValue.ToString() + "!"
                    + Environment.NewLine, MsgBoxStyle.OkOnly | MsgBoxStyle.Information, "c# msg demo");
                solde = float.Parse((string)myValue);
                //MessageBox.Show(v.ToString());
                if (comboBox1.SelectedItem.ToString() == "CompteEpargne")
                {
                    /*Update Devise set valeurs = valeurs - " + solde + "where Id in " +
                         "(Select  IdDevise from compte c join CompteEpargne ce on ce.idCompte=c.id" +
                                        "and c.idClient =" + c1.id + ")*/
                  Modifier(" UPDATE Devise SET valeurs = valeurs - " + solde + " WHERE Id in" + 
                        " ( SELECT  IdDevise FROM compte c "+
                        " JOIN CompteEpargne ce ON ce.idCompte = c.id "+
                            " AND c.idClient =" + c1.id + ")");
                    dataGridView1.Refresh();
                }
                /// MessageBox.Show(comboBox1.SelectedItem.ToString());
                dataGridView1.Refresh();


            }
        }
            private void Modifier(string commande)
            {
                if (connection.State != System.Data.ConnectionState.Open) connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.UpdateCommand = new SqlCommand(commande, connection);
                adapter.UpdateCommand.ExecuteNonQuery();
                adapter.UpdateCommand.Dispose();
                connection.Close();
            }
        
    } 
}
