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
        protected int id { get; set; }
        protected List<Operation> operations = new List<Operation>();
        private Devise solde { get; set; }

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
