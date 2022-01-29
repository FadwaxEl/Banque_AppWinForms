



namespace appBanque
{
    public class CompteCourant : Compte
    {
        private double decouvert;
        public CompteCourant(int id, Client c, Devise d, double dec) : base(id, c, d)
        {
            this.decouvert = dec;
        }

    }
}
