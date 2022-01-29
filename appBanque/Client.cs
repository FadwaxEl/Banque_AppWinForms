using System.Collections.Generic;

namespace appBanque
{
    public class Client
    {
        //private static int nb = 0;
        public int id;
        private string nom;
        private string prenom;
        private string adress;
        private string username;
        private string password;
        public List<Compte> comptes { get; set; }

        public Client(int id, string nom, string prenom, string adress, string username,
            string password)
        {
            //nb++;
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.adress = adress;
            this.username = username;
            this.password = password;
            comptes = new List<Compte>();

        }


        public bool Verifier_auth(string log, string pass)
        {
            return (this.username == log) && (this.password == pass);
        }
        public void Add_compte(Compte c)
        {
            if (comptes.Contains(c)) return;
            comptes.Add(c);
        }
        public string afficher()
        {
            string s = "";
            s += this.username;
            return s;
        }
        /* public Client login()
         {
             SqlConnection connection;
             string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=banque;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
             connection = new SqlConnection(connectionString);
             connection.Open();

             SqlCommand cmd;
             SqlDataReader reader;
             string query = "select * from Client";
             cmd = new SqlCommand(query, connection);
             reader = cmd.ExecuteReader();

             while (reader.Read())
             {
                 if (reader["login"].ToString() == this.username)
                 {
                     if (reader["password"].ToString() == this.password)
                     {
                         int id = int.Parse(reader["id"].ToString());
                         string nom = reader["nom"].ToString();
                         string prenom = reader["prenom"].ToString();
                         string adress = reader["adress"].ToString();
                         string username = this.username;
                         string password = this.password;

                         return new Client(id, nom, prenom, adress, username, password);

                     }
                     return null;
                 }
             }
             connection.Close();
             return null;
         }*/

        /*public List<CompteEpargne> comptes_cli(){
            List<CompteEpargne> comptes=new List<CompteEpargne>();
            SqlConnection connection;
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=banque;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "select * from comptes c join CompteEpargnes ce on ce.idCompte=c.id "+
                "join devises d on c.idDevise=d.id where c.idClient=" + id;
            /*string query2 = "select * from comptes c join ComptesCourant cc on cc.idCompte=c.id "+"" +
                "join devises d on c.idDevise=d.id where idClient=" + id +
                " and id not in (select idCourant from comptePayants)";
            string query3 = "select * from comptes c join ComptesCourant cc on c.id=cc.idCompte" +
                "join comptePayants cp on cc.id=cp.idCourant join devises d on c.idDevise=d.id where id=" + id;*/

        /*  SqlCommand cmd;
          SqlDataReader reader;
          cmd=new SqlCommand(query,connection);
          reader=cmd.ExecuteReader();
          while (reader.Read()) {
              int idDevice=int.Parse(reader["idDevice"].ToString());
              double valeur = double.Parse(reader["valeur"].ToString());
              Devise d = new Mad(id, valeur);
              int idCompte = int.Parse((string)reader["idCompte"]);
              double tauxInteret = double.Parse((string)reader["tauxInteret"]);
              comptes.Add(new CompteEpargne(idCompte, this, d, tauxInteret));
          }
          return comptes;
      }*/

    }
}
