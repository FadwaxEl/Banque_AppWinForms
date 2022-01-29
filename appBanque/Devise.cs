


using System;

namespace appBanque
{
    public abstract class Devise
    {
        protected int id
        {
            get; set;
         }
        protected double value { get; set; }

        public Devise(int id, double value)
        {
            this.id = id;
            this.value = value;
        }
        public string afficher()
            {
            string r = "";
            r += this.value;
            //Console.WriteLine(this.value);
            return r;
        }
    }
}
