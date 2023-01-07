using Crsch_2.Game;
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
        private int plafieldstartx = 50;
        private int plafieldstarty = 50;
        private int enmfieldstartx = 540;
        private int enmfieldstarty = 50;
        List<ShipForPlacement> Shps;
        private bool[,] playerField;
        GameManadger gm;
        public GameForm() {
            InitializeComponent();
            EnmField = new EnemyFieldBtn[10, 10];
            PlaField = new PlayerFieldCell[10, 10];
            Shps = new List<ShipForPlacement>();
            playerField = new bool[10, 10];
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    playerField[i, j] = false;
            EnemyFieldBtn btn;
            for(int i=0;i<10;i++)
                for(int j = 0; j < 10; j++) {
                    btn = new EnemyFieldBtn();
                    EnmField[i, j] = btn;
                    btn.x = i;
                    btn.y = j;
                    btn.Location = new Point(enmfieldstartx + i * 31, enmfieldstarty + j * 31);
                    btn.Click += EnemyFielgClick;
                    this.Controls.Add(btn);
                }
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++) {
                    PlayerFieldCell cell = new PlayerFieldCell();
                    PlaField[i, j] = cell;
                    cell.x = i;
                    cell.y = j;
                    cell.Location = new Point(plafieldstartx + i * 31, plafieldstarty + j * 31);
                    this.Controls.Add(cell);
                }
            ShipForPlacement shp = new ShipForPlacement(4);
            shp.Location = new Point(plafieldstartx+10,plafieldstarty+310+50);
            this.Controls.Add(shp);
            Shps.Add(shp);
            shp = new ShipForPlacement(3);
            shp.Location = new Point(plafieldstartx + 10, plafieldstarty + 310 + 50+ 40);
            this.Controls.Add(shp);
            Shps.Add(shp);
            shp = new ShipForPlacement(3);
            shp.Size = new Size(90, 30);
            shp.Location = new Point(plafieldstartx + 10+100, plafieldstarty + 310 + 50+40);
            this.Controls.Add(shp);
            Shps.Add(shp);
            shp = new ShipForPlacement(2);
            shp.Location = new Point(plafieldstartx + 10, plafieldstarty + 310 + 50+80);
            this.Controls.Add(shp);
            Shps.Add(shp);
            shp = new ShipForPlacement(2);
            shp.Location = new Point(plafieldstartx + 10+70, plafieldstarty + 310 + 50+80);
            this.Controls.Add(shp);
            Shps.Add(shp);
            shp = new ShipForPlacement(2);
            shp.Location = new Point(plafieldstartx + 10+140, plafieldstarty + 310 + 50+80);
            this.Controls.Add(shp);
            Shps.Add(shp);
            shp = new ShipForPlacement(1);
            shp.Location = new Point(plafieldstartx + 10, plafieldstarty + 310 + 50+120);
            this.Controls.Add(shp);
            Shps.Add(shp);
            shp = new ShipForPlacement(1);
            shp.Location = new Point(plafieldstartx + 10+40, plafieldstarty + 310 + 50+120);
            this.Controls.Add(shp);
            Shps.Add(shp);
            shp = new ShipForPlacement(1);
            shp.Location = new Point(plafieldstartx + 10+80, plafieldstarty + 310 + 50+120);
            this.Controls.Add(shp);
            Shps.Add(shp);
            shp = new ShipForPlacement(1);
            shp.Location = new Point(plafieldstartx + 10+120, plafieldstarty + 310 + 50+120);
            this.Controls.Add(shp);
            Shps.Add(shp);
            this.Size = new Size(enmfieldstartx+310+50, plafieldstarty + 310 + 50 + 120+50+30);
            Placed.Location = new Point((enmfieldstartx-plafieldstartx-310)/2+ plafieldstartx + 310-80,plafieldstarty+310+50);
            Placed.Size = new Size(160, 20);
            GameStateLabel.Location= new Point((enmfieldstartx - plafieldstartx - 310) / 2 + plafieldstartx + 310 - 50, plafieldstarty);
            GameStateLabel.Size = new Size(100, 10);
            foreach (ShipForPlacement sh in Shps) {
                sh.MouseDown += Ship_MouseDown;
                sh.MouseUp += Ship_MouseUp;
                sh.MouseMove += Ship_MouseMove;
                sh.MouseClick += Ship_MouseClick;
            }
        }
        private void EnemyFielgClick(object sender, EventArgs e) {
            PlaField[((EnemyFieldBtn)sender).x, ((EnemyFieldBtn)sender).y].BackgroundImage = Properties.Resources.ExplodeText;
        }
        private void Ship_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right)
                ((ShipForPlacement)sender).rotate();
        }
        private void Ship_MouseDown(object sender, MouseEventArgs e) {
            ((ShipForPlacement)sender).isMoving = true;
            int mx = ((ShipForPlacement)sender).Location.X;
            int my = ((ShipForPlacement)sender).Location.Y;
            int cellx = (mx - plafieldstartx) / 31;
            int celly = (my - plafieldstarty) / 31;
            if (((ShipForPlacement)sender).isPlaced){
                for (int i = 0; i < ((ShipForPlacement)sender).length; i++) {
                    if (((ShipForPlacement)sender).getDirection()) {
                        playerField[cellx, celly + i] = false;
                    } else {
                        playerField[cellx + i, celly] = false;
                    }
                }
                ((ShipForPlacement)sender).Location = new Point(cellx * 31 + plafieldstartx, celly * 31 + plafieldstarty);
                ((ShipForPlacement)sender).isPlaced = false;
                ((ShipForPlacement)sender).BringToFront();
                for (int i = 0; i < 10; i++)
                    for (int j = 0; j < 10; j++)
                        if (playerField[i, j])
                            EnmField[i, j].BackgroundImage = Properties.Resources.ExplodeText;
                        else
                            EnmField[i, j].BackgroundImage = Properties.Resources.Watertext;
            }

        }

        private void Ship_MouseUp(object sender, MouseEventArgs e) {
            ((ShipForPlacement)sender).isMoving = false;
            int mx = ((ShipForPlacement)sender).Location.X;
            int my = ((ShipForPlacement)sender).Location.Y;
            int cellx = (mx - plafieldstartx) / 31;
            int celly = (my - plafieldstarty) / 31;
            if (mx >= plafieldstartx && mx <= (plafieldstartx + 310) && my >= plafieldstarty && my <= (plafieldstarty + 310 - (((ShipForPlacement)sender).length - 1) * 31) && ((ShipForPlacement)sender).getDirection() ||
                mx >= plafieldstartx && mx <= (plafieldstartx + 310 - (((ShipForPlacement)sender).length - 1) * 31) && my >= plafieldstarty && my <= (plafieldstarty + 310) && (!((ShipForPlacement)sender).getDirection())
                ) {
                if (!playerField[cellx, celly]&&
                    (cellx == 0 ||!playerField[cellx-1, celly])&&
                    (celly == 0 ||!playerField[cellx, celly-1] ) &&
                    (cellx == 9 ||!playerField[cellx + 1, celly]) &&
                    (celly == 9 ||!playerField[cellx, celly + 1])&&
                    (cellx==0||celly==0|| !playerField[cellx-1, celly -1])&&
                    (cellx == 0 || celly == 9 || !playerField[cellx - 1, celly + 1]) &&
                    (cellx == 9 || celly == 0 || !playerField[cellx + 1, celly - 1]) &&
                    (cellx == 9 || celly == 9 || !playerField[cellx + 1, celly + 1]) 
                    ) {
                    for (int i = 0; i < ((ShipForPlacement)sender).length; i++) {
                        if (((ShipForPlacement)sender).getDirection()) {
                            if(!((cellx==0||!playerField[cellx-1, celly + i])&&
                                (cellx == 9 || !playerField[cellx + 1, celly + i]) &&
                                (celly+i == 9 || !playerField[cellx, celly + i+1]) &&
                                (celly + i == 9 ||cellx==0 ||!playerField[cellx-1, celly + i + 1])&&
                                (celly + i == 9 || cellx == 9||!playerField[cellx + 1, celly + i + 1])
                                )) {
                                while (i != -1) {
                                    playerField[cellx, celly + i] = false;
                                    i--;
                                }
                                ((ShipForPlacement)sender).BringToFront();
                                return;
                            }
                               else
                            playerField[cellx, celly + i] = true;
                        } else {
                            if (!((celly == 0 || !playerField[cellx +i, celly -1]) &&
                                (celly == 9 || !playerField[cellx + i, celly +1]) &&
                                (cellx+i == 9 || !playerField[cellx + i + 1, celly])&&
                                (cellx + i == 9 ||celly==0 ||!playerField[cellx + i + 1, celly-1])&&
                                (cellx + i == 9 || celly == 9||!playerField[cellx + i + 1, celly + 1])
                                )) {
                                while (i != -1) {
                                    playerField[cellx+i, celly] = false;
                                    i--;
                                }
                                ((ShipForPlacement)sender).BringToFront();
                                return;
                            } else
                                playerField[cellx + i, celly] = true;
                        }
                    }
                ((ShipForPlacement)sender).Location = new Point(cellx * 31 + plafieldstartx, celly * 31 + plafieldstarty);
                    ((ShipForPlacement)sender).isPlaced = true;
                    
                    for (int i = 0; i < 10; i++)
                        for (int j = 0; j < 10; j++)
                            if (playerField[i, j])
                                EnmField[i, j].BackgroundImage = Properties.Resources.ExplodeText;
                            else
                                EnmField[i, j].BackgroundImage = Properties.Resources.Watertext;
                }
            }
            ((ShipForPlacement)sender).BringToFront();
        }

        private void Ship_MouseMove(object sender, MouseEventArgs e) {
            if(((ShipForPlacement)sender).isMoving)
            ((ShipForPlacement)sender).Location = this.PointToClient(Control.MousePosition);
            ((ShipForPlacement)sender).BringToFront();
        }
        private void ShootToPlayerField(Cell cl) {
            PlaField[cl.x, cl.y].Image = Properties.Resources.shtdw;
            PlaField[cl.x, cl.y].BringToFront();
           // this.Invalidate();
        }
        private void ShootToEnemyField(Cell cl,int type) {
            switch (type) {
                case 0:
                    EnmField[cl.x, cl.y].MouseClick -= playerMoveClick;
                    EnmField[cl.x, cl.y].BackgroundImage = Properties.Resources.shtdw;
                    break;
                case 1:
                    EnmField[cl.x, cl.y].MouseClick -= playerMoveClick;
                    EnmField[cl.x, cl.y].BackgroundImage = Properties.Resources.shpshtd;

                    break;
                case 2:
                    EnmField[cl.x, cl.y].MouseClick -= playerMoveClick;
                    EnmField[cl.x, cl.y].BackgroundImage = Properties.Resources.fallshp;
                    break;
            }
            
            EnmField[cl.x, cl.y].BringToFront();
        }
        private void Placed_Click(object sender, EventArgs e) {
            foreach (ShipForPlacement sh in Shps)
                if (!sh.isPlaced)
                    return;
            Placed.Dispose();
            foreach (ShipForPlacement sh in Shps) {
                sh.MouseDown -= Ship_MouseDown;
                sh.MouseUp -= Ship_MouseUp;
                sh.MouseMove -= Ship_MouseMove;
                sh.MouseClick -= Ship_MouseClick;
            }
            GameStateLabel.Text = "Сделайте ход";
            gm = new GameManadger(new ComputerEnemy(),playerField);
            gm.ShootPlayerField += ShootToPlayerField;
            gm.ShootEnemyField += ShootToEnemyField;
            gm.Lose += Lose;
            gm.Win += Win;
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    EnmField[i, j].MouseClick += playerMoveClick;        }
        private void playerMoveClick(object sender, EventArgs e) {
            gm.playerMoveProcessor(new Cell(((EnemyFieldBtn)sender).x, ((EnemyFieldBtn)sender).y));
        }
        private void Lose() {
            MessageBox.Show("Вы проиграли", "", MessageBoxButtons.OK);
            this.Close();
        }
        private void Win() {
            MessageBox.Show("Вы выйграли", "", MessageBoxButtons.OK);
            this.Close();
        }
    }
  
}
 