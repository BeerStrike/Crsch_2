using Crsch_2.Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
        private List<ShipForPlacement> Shps;
        private bool[,] playerField;
        private GameManadger gm;
        private IEnemy enm;
        private bool fmv;
        public GameForm(IEnemy enem,bool firstMove) {
            enm = enem;
            fmv = firstMove;
            InitializeComponent();
            PlayerNameLabel.Text = PlayerInfo.Default.Nickname;
            PlayerNameLabel.Location = new Point(plafieldstartx , plafieldstarty -40);
            EnemyNameLabel.Text = enm.getName();
            EnemyNameLabel.Location = new Point(enmfieldstartx, enmfieldstarty - 40);
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
            for(int i = 0; i < 10; i++){
                Label lbl = new Label();
                lbl.Text = i.ToString();
                lbl.Location = new Point(plafieldstartx-20, plafieldstarty+10+31*i);
                lbl.Size = new Size(15, 15);
                lbl.ForeColor = Color.White;
                this.Controls.Add(lbl);
                lbl = new Label();
                lbl.Text = i.ToString();
                lbl.Location = new Point(enmfieldstartx - 20, enmfieldstarty+10 + 31 * i);
                lbl.Size = new Size(15, 15);
                lbl.ForeColor = Color.White;
                this.Controls.Add(lbl);
                lbl = new Label();
                lbl.Text = ((Char)(Convert.ToUInt16('А') + i)).ToString();
                lbl.Location = new Point(plafieldstartx + 10 + 31 * i, plafieldstarty -20);
                lbl.Size = new Size(15, 15);
                lbl.ForeColor = Color.White;
                this.Controls.Add(lbl);
                lbl = new Label();
                lbl.Text = ((Char)(Convert.ToUInt16('А') + i)).ToString();
                lbl.Location = new Point(enmfieldstartx + 10 + 31 * i, enmfieldstarty -20);
                lbl.Size = new Size(15, 15);
                lbl.ForeColor = Color.White;
                this.Controls.Add(lbl);
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
            if (((ShipForPlacement)sender).getPlaced()){
                for (int i = 0; i < ((ShipForPlacement)sender).length; i++) {
                    if (((ShipForPlacement)sender).getDirection()) {
                        playerField[cellx, celly + i] = false;
                    } else {
                        playerField[cellx + i, celly] = false;
                    }
                }
                ((ShipForPlacement)sender).Location = new Point(cellx * 31 + plafieldstartx, celly * 31 + plafieldstarty);
                ((ShipForPlacement)sender).Unplace();
                ((ShipForPlacement)sender).BringToFront();
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
                    ((ShipForPlacement)sender).Place();
                }
            }
            ((ShipForPlacement)sender).BringToFront();
        }
        private void ErExit(String s) {
            MessageBox.Show(s, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.Close();
        }
       private void Ship_MouseMove(object sender, MouseEventArgs e) {
            if(((ShipForPlacement)sender).isMoving)
            ((ShipForPlacement)sender).Location = this.PointToClient(Control.MousePosition);
            ((ShipForPlacement)sender).BringToFront();
        }
        private void ShootToPlayerField(Cell cl) {
            if (cl.x >= 0 && cl.x <= 9 && cl.y >= 0 && cl.y <= 9) {
                PlaField[cl.x, cl.y].Image = playerField[cl.x, cl.y] ? Properties.Resources.fallshp : Properties.Resources.shtdw;
                PlaField[cl.x, cl.y].BringToFront();
                GameStateLabel.Text = "Сделайте ход";
            }
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
            GameStateLabel.Text = "Ожидание хода соперника";
        }
        private async void Placed_Click(object sender, EventArgs e) {
            foreach (ShipForPlacement sh in Shps)
                if (!sh.getPlaced())
                    return;
            Placed.Dispose();
            foreach (ShipForPlacement sh in Shps) {
                sh.MouseDown -= Ship_MouseDown;
                sh.MouseUp -= Ship_MouseUp;
                sh.MouseMove -= Ship_MouseMove;
                sh.MouseClick -= Ship_MouseClick;
            }
            GameStateLabel.Text = "Ожидание соперника";
            enm.Ready();
            int res = 0;
            while (res!=1) {
                await Task.Run(() => {
                    res = enm.CheckConnect();
                    Thread.Sleep(1000);
                });
                if (res == 0)
                    ErExit("Превышено время ожидания");
            }
            if (fmv)
                GameStateLabel.Text = "Сделайте ход";
            else {
                GameStateLabel.Text = "Ожидание хода соперника";
            }
            gm = new GameManadger(enm,playerField,fmv);
            gm.ShootPlayerField += ShootToPlayerField;
            gm.ShootEnemyField += ShootToEnemyField;
            gm.ErrorExit += ErExit;
            gm.Lose += Lose;
            gm.Win += Win;
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    EnmField[i, j].MouseClick += playerMoveClick;    
        }
        
        private void playerMoveClick(object sender, EventArgs e) {
            gm.playerMoveProcessor(new Cell(((EnemyFieldBtn)sender).x, ((EnemyFieldBtn)sender).y));
        }
        private void Lose() {
            MessageBox.Show("Вы проиграли", "", MessageBoxButtons.OK);
            this.Close();
        }
        private void Win(int mv) {
            string[] nms = new string[5];
            int[] rcs = new int[5];
            int l = 0;
            if (File.Exists("recs.txt"))
                using (StreamReader sr = new StreamReader("Recs.txt")) {
                    for (int i = 0; i < 5; i++) {
                        if (!sr.EndOfStream) {
                            nms[i] = sr.ReadLine();
                            rcs[i] = Int32.Parse(sr.ReadLine());
                            l++;
                        }
                    }
                }
            using (StreamWriter sw = new StreamWriter("Recs.txt")) {
                bool ispl = false;
                int i= 0;
                while (i<l) {
                    if (!ispl) {
                        if (rcs[i] <= mv) {
                            sw.WriteLine(nms[i]);
                            sw.WriteLine(rcs[i]);
                            i++;
                        } else {
                            sw.WriteLine(PlayerInfo.Default.Nickname);
                            sw.WriteLine(mv);
                            ispl = true;
                        }
                    } else {
                        sw.WriteLine(nms[i]);
                        sw.WriteLine(rcs[i]);
                        i++;
                    }

                }
                if (!ispl) {
                    sw.WriteLine(PlayerInfo.Default.Nickname);
                    sw.WriteLine(mv);
                }
            }
            MessageBox.Show("Вы выйграли", "", MessageBoxButtons.OK);
            this.Close();
        }
    }
  
}
  