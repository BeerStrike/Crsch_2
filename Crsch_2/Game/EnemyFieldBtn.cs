using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crsch_2 {
    class EnemyFieldBtn:Button {
        public int x { get; set; }
        public int y { get; set; }
        public EnemyFieldBtn() :base(){
            this.Size = new Size(30, 30);
            this.BackgroundImageLayout = ImageLayout.Stretch;

            this.BackgroundImage = Properties.Resources.Watertext;
            this.FlatStyle = FlatStyle.Flat;
        }
    }
}
