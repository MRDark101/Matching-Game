using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matching_game
{
    public partial class Vaikeustaso : Form
    {
        public Vaikeustaso()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form1 helppo = new Form1();
            this.Hide();
            helppo.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Normaali normaali = new Normaali();
            this.Hide();
            normaali.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Vaikea vaikea = new Vaikea();
            this.Hide();
            vaikea.Show();
        }
    }
}
