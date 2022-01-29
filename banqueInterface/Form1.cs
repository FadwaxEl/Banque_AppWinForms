#pragma warning disable CS0246 // Le nom de type ou d'espace de noms 'appBanque' est introuvable (vous manque-t-il une directive using ou une référence d'assembly ?)
using appBanque;
#pragma warning restore CS0246 // Le nom de type ou d'espace de noms 'appBanque' est introuvable (vous manque-t-il une directive using ou une référence d'assembly ?)
using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace banqueInterface
{
    public partial class Form1 : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Banque3; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=true;");
        List<Client> lesClients = new List<Client>();
        static public Client client_auth;
#pragma warning disable CS0246 // Le nom de type ou d'espace de noms 'DBHendler2' est introuvable (vous manque-t-il une directive using ou une référence d'assembly ?)
#pragma warning disable CS0169 // Le champ 'Form1.users' n'est jamais utilisé
        DBHendler2 users;
#pragma warning restore CS0169 // Le champ 'Form1.users' n'est jamais utilisé
#pragma warning restore CS0246 // Le nom de type ou d'espace de noms 'DBHendler2' est introuvable (vous manque-t-il une directive using ou une référence d'assembly ?)
        public Form1()
        {
            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {

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
        public bool se_connecter(string login, string motdepass)
        {
            foreach (Client c in lesClients)
            {
                if (c.Verifier_auth(login, motdepass))
                {
                    client_auth = c;
                    return true;
                }
            }
            return false;
        }

        private void login_btn_Click_1(object sender, EventArgs e)
        {
            if (connection.State != System.Data.ConnectionState.Open) connection.Open();
            // MessageBox.Show("accces a la base de donne est fait connectez vou!!");

            Client temp;
#pragma warning disable CS0168 // La variable 'readerCompte' est déclarée, mais jamais utilisée
            SqlDataReader readerClient, readerCompte;
#pragma warning restore CS0168 // La variable 'readerCompte' est déclarée, mais jamais utilisée
            readerClient = Selecte("Select * from Client ");
            while (readerClient.Read())
            {
                int id = int.Parse(readerClient["id"].ToString());
                //  MessageBox.Show(readerClient["id"].ToString());
                string nom = readerClient["nom"].ToString();
                string prenom = readerClient["prenom"].ToString();
                string login = readerClient["login"].ToString();
                string pass = readerClient["password"].ToString();
                string adress = readerClient["adress"].ToString();

                temp = new Client(id, nom, prenom, adress, login, pass);

                lesClients.Add(temp);

            }
            if (se_connecter(textBox1.Text.ToString(), textBox3.Text.ToString()))
            {
                MessageBox.Show("Access verified ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comptes_cli(client_auth);
                UI_interface f2 = new UI_interface(client_auth);
                f2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Error!! login");
            }


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
          
        }
        public  void comptes_cli(Client c)
        {
            List<CompteEpargne> comptes = new List<CompteEpargne>();

            /*string query = "select * from comptes c join CompteEpargnes ce on ce.idCompte=c.id " +
                "join devises d on c.idDevise=d.id where c.idClient=" + id;*/
            /*string query2 = "select * from comptes c join ComptesCourant cc on cc.idCompte=c.id "+"" +
                "join devises d on c.idDevise=d.id where idClient=" + id +
                " and id not in (select idCourant from comptePayants)";
            string query3 = "select * from comptes c join ComptesCourant cc on c.id=cc.idCompte" +
                "join comptePayants cp on cc.id=cp.idCourant join devises d on c.idDevise=d.id where id=" + id;*/


            SqlDataReader reader = Selecte("select * from compte c join CompteEpargne ce on ce.idCompte=c.id "
                +"join devise d on c.idDevise = d.id where c.idClient =" + c.id);
            while (reader.Read())
            {
               // MessageBox.Show(reader.GetValue(7).ToString());

                //int idDevice = int.Parse(reader["idDevice"].ToString());
                double valeur = double.Parse(reader.GetValue(7).ToString());
                Devise d = new Mad(c.id, valeur);
                int idCompte = int.Parse(reader.GetValue(4).ToString());
                double tauxInteret = double.Parse(reader.GetValue(5).ToString());
                c.Add_compte(new CompteEpargne(idCompte, c, d, tauxInteret));
              //  comptes.Add(new CompteEpargne(idCompte, c, d, tauxInteret));
            }
           // return comptes;
        }
    }
}
