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
    public partial class GameForm : Form {
        private EnemyFieldBtn[,] EnmField;
        private PlayerFieldCell[,] PlaField;
        public GameForm() {
            InitializeComponent();
            EnmField = new EnemyFieldBtn[10, 10];
            PlaField = new PlayerFieldCell[10, 10];
            EnemyFieldBtn btn;
            int dltx = 500, dlty = 100;
            for(int i=0;i<10;i++)
                for(int j = 0; j < 10; j++) {
                    btn = new EnemyFieldBtn();
                    EnmField[i, j] = btn;
                    btn.x = i;
                    btn.y = j;
                    btn.Size = new Size(30, 30);
                    btn.Location = new Point( dltx + i * 31, dlty + j * 31);
                    btn.Click += EnemyFielgClick;
                    btn.BackgroundImage = Properties.Resources.Watertext;
                    btn.FlatStyle = FlatStyle.Flat;
                    this.Controls.Add(btn);
                }
            dltx = 100;
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++) {
                    PlayerFieldCell cell = new PlayerFieldCell();
                    PlaField[i, j] = cell;
                    cell.x = i;
                    cell.y = j;
                    cell.Size = new Size(30, 30);
                    cell.Location = new Point(dltx + i * 31, dlty + j * 31);
                    cell.Click += EnemyFielgClick;
                    cell.BackgroundImage = Properties.Resources.Watertext;
                    this.Controls.Add(cell);
                }
         }
        private void EnemyFielgClick(object sender, EventArgs e) {
            //  this.Text = ((EnemyFieldBtn)sender).x.ToString() + " " + ((EnemyFieldBtn)sender).y.ToString();
            PlaField[((EnemyFieldBtn)sender).x, ((EnemyFieldBtn)sender).y].BackgroundImage = Properties.Resources.ExplodeText;
        }
    }
}
