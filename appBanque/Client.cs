using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appBanque
{
    public class Client
    {
        //private static int nb = 0;
        private int id;
        private string nom;
        private string prenom;
        private string adress;
        private string username;
        private string password;
        private List<Compte> comptes=new List<Compte>();
        /*public Client(string nom,string prenom,string adress,string username,
            string password)
        {
            id = ++nb;
            this.nom = nom;
            this.prenom = prenom;
            this.adress = adress;
            this.username = username;
            this.password = password;

        }*/
        public Client(int id,string nom, string prenom, string adress, string username,
            string password)
        {
            //nb++;
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.adress = adress;
            this.username = username;
            this.password = password;

        }
    }
}
