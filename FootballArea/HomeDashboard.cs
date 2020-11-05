using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootballArea
{
    public partial class HomeDashboard : Form
    {
        public HomeDashboard()
        {
            InitializeComponent();
        }

        private void btnReserve_Click(object sender, EventArgs e)
        {
            Area_Dashboard are = new Area_Dashboard();
            are.ShowDialog();
        }

        private void btnAddWorker_Click(object sender, EventArgs e)
        {

        }
    }
}
