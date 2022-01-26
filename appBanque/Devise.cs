using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appBanque
{
    public abstract class Devise
    {
        protected int id;
        protected double value;

        public Devise(int id,double value)
        {
            this.id = id;
            this.value = value;
        }
    }
}
