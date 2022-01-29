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

using appBanque;
namespace banqueInterface
{
    public partial class UI_interface : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Banque3; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=true;");
        static Client c1;
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
            if (comboBox1.SelectedItem.ToString() == "Compte Epargne")
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
            else if (comboBox1.SelectedItem.ToString() == "Compte Courant")
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
            else if (comboBox1.SelectedItem.ToString() == "Compte Payant")
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
                public SqlDataReader Selecte(string commande)
        {

            if (connection.State != System.Data.ConnectionState.Open) connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlDataReader reader;
            adapter.SelectCommand = new SqlCommand(commande, connection);
            reader = adapter.SelectCommand.ExecuteReader();
            adapter.SelectCommand.Dispose();

            return reader;

        }



    }
}
