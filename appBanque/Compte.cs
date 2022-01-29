using System;
using System.Collections.Generic;

namespace appBanque
{
    public abstract class Compte
    {
        protected Client client
        {
            get; set;
         }
       public int id { get; set; }
        public List<Operation> operations = new List<Operation>();
       public Devise solde { get; set; }

        public Compte(int id, Client client, Devise solde)
        {
            this.id = id;
            this.client = client;
            this.solde = solde;
        }
        public string afficher()
        {
           return this.solde.afficher();
        }
    }
}
