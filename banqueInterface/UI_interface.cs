using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using appBanque;
namespace banqueInterface
{
    public partial class UI_interface : Form
    {

        public UI_interface(Client c)
        {
            InitializeComponent();
            label4.Text = c.afficher();
            dataGridView1.DataSource = c.comptes;
           // MessageBox.Show(c.comptes[0].afficher());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem.ToString() == "Compte Epargne")
            {
                // dataGridView1.DataSource = Form1.client_auth.comptes;
                dataGridView1.DataSource = Form1.client_auth.comptes;
            }
        }


       

    }
}
