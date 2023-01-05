using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crsch_2 {
    class PlayerFieldCell:PictureBox {
        public int x { get; set; }
        public int y { get; set; }
        public PlayerFieldCell():base() {
            this.Size = new Size(30, 30);
            this.SizeMode = PictureBoxSizeMode.StretchImage;

            this.Image = Properties.Resources.Watertext;

        }
    }
}
