using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crsch_2 {
    public partial class MenuForm : Form {
        public MenuForm() {
            InitializeComponent();
            NameInput nmpt = new NameInput();
            nmpt.ShowDialog();
            PlayerNameLabel.Text = PlayerInfo.Default.Nickname;
        }

        private void RecBtn_Click(object sender, EventArgs e) {
            RecsForm rcf = new RecsForm();
            rcf.ShowDialog();
        }

        private void SnglPlayByn_Click(object sender, EventArgs e) {
            GameForm gm=new GameForm();
            gm.Show();
        }

        private void MltpPlayBtn_Click(object sender, EventArgs e) {

        }

        private void ExtiBtn_Click(object sender, EventArgs e) {
            Application.Exit();
        }
    }
}
