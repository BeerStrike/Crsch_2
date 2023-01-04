using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crsch_2 {
    class ShipForPlacement:PictureBox {
        public bool isMoving = false;
        public bool isPlaced = false;
        private bool direction = false;
        public int length { get; }
        public ShipForPlacement(int l):base() {
            length = l;
            switch (l) {
                case 1:
                    this.Image = Properties.Resources.sh1;
                    break;
                case 2:
                    this.Image = Properties.Resources.sh2;
                    break;
                case 3:
                    this.Image = Properties.Resources.sh3;
                    break;
                case 4:
                    this.Image = Properties.Resources.sh4;
                    break;
            }
            this.Size = new Size(l*31, 30);
            this.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        public bool getDirection() {
            return direction;
        }
        public void rotate() {
            if (length > 1) {
                direction = !direction;
                if (direction) {
                    switch (length) {
                        case 2:
                            this.Image = Properties.Resources.v2;
                            break;
                        case 3:
                            this.Image = Properties.Resources.v3;
                            break;
                        case 4:
                            this.Image = Properties.Resources.v4;
                            break;
                    }
                    this.Size = new Size(30, length * 31);

                } else { switch (length) {
                        case 2:
                            this.Image = Properties.Resources.sh2;
                            break;
                        case 3:
                            this.Image = Properties.Resources.sh3;
                            break;
                        case 4:
                            this.Image = Properties.Resources.sh4;
                            break;
                    }
                    this.Size = new Size(length * 31, 30);
                }   
            }

        }
    }
}
