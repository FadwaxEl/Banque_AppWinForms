using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appBanque
{
    public abstract class Compte
    {
        protected Client client;
        protected int id;
        protected List<Operation> operations=new List<Operation>();
        Devise solde;

        public Compte(int id,Client client,Devise solde)
        {
            this.id = id;
            this.client = client;
            this.solde = solde;
        }
    }
}
