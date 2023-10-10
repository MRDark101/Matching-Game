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
    public partial class AloitusRuutu : Form
    {
        public AloitusRuutu()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Vaikeustaso vaikeustaso = new Vaikeustaso();
            this.Hide();
            vaikeustaso.Show();
        }

        private void Aloitus_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
