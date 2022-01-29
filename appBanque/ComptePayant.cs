namespace appBanque
{
    public class ComptePayant : CompteCourant
    {
        public ComptePayant(int id, Client c, Devise d, double dec) : base(id, c, d, dec)
        {

        }
    }
}
