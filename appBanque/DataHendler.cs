using System.Collections.Generic;
using System.Data.SqlClient;

namespace appBanque
{
    public class DBHendler2
    {
        SqlConnection connection = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Banque3; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=true;");
        string providerName = "System.Data.SqlClient";
        List<Client> lesClients = new List<Client>();
        static public Client client_auth;
        static DBHendler2 user = null;

        public static DBHendler2 DB_Access()
        {
            if (user == null) user = new DBHendler2();
            return user;
        }
        private DBHendler2()
        {

            if (connection.State != System.Data.ConnectionState.Open) connection.Open();
            Client temp;
            SqlDataReader readerClient, readerCompte;
            readerClient = Selecte("Select * from Client ");
            while (readerClient.Read())
            {
                int id = int.Parse(readerClient["id"].ToString());
                string nom = readerClient["nom"].ToString();
                string prenom = readerClient["prenom"].ToString();
                string login = readerClient["login"].ToString();
                string pass = readerClient["password"].ToString();
                string adress = readerClient["adress"].ToString();

                temp = new Client(id, nom, prenom, adress, login, pass);

                lesClients.Add(temp);
                /*  readerCompte = Selecte("Select * from Compte where idClient = " + temp.id);
                  while(readerCompte.Read())
                  {
                      int id1 = int.Parse(readerClient["id"].ToString());
                      temp.Add_compte(new Compte())
                  }*/

            }



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


        private void Ajouet(string commande)
        {
            if (connection.State != System.Data.ConnectionState.Open) connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.InsertCommand = new SqlCommand(commande, connection);
            adapter.InsertCommand.ExecuteNonQuery();
            adapter.InsertCommand.Dispose();
            connection.Close();
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
        private void Supprimer(string commande)
        {
            if (connection.State != System.Data.ConnectionState.Open) connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.DeleteCommand = new SqlCommand(commande, connection);
            adapter.DeleteCommand.ExecuteNonQuery();
            adapter.DeleteCommand.Dispose();
            connection.Close();
        }


        // connection = new SqlConnection(connectionString);


    }
}
