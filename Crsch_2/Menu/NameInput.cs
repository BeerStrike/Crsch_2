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
    public partial class NameInput : Form {
        public NameInput() {
            InitializeComponent();
        }

        private void OK_btnClick(object sender, EventArgs e) {
            if (NameInputBox.Text != "")
                PlayerInfo.Default.Nickname = NameInputBox.Text;
            else
                PlayerInfo.Default.Nickname = "Игрок";
            this.Close();
        }

        private void NameInput_Load(object sender, EventArgs e) {

        }
    }
}
