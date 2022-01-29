namespace appBanque
{
    public class CompteEpargne : Compte
    {
        private double tauxInteret;
        public CompteEpargne(int id, Client client, Devise devise, double tauxInteret) : base(id, client, devise)
        {
            this.tauxInteret = tauxInteret;
        }
    }
}
