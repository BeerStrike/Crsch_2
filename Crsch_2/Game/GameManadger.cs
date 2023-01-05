using Crsch_2.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crsch_2 {
    class GameManadger {
        public delegate void ShootCell(Cell cl);
        public delegate void ShootECell(Cell cl,int type);
        public event ShootCell ShootPlayerField;
        public event ShootECell ShootEnemyField;
        private bool[,] plaFieldShts;
        private bool[,] enmFieldShts;
        private bool[,] plaField;
        private IEnemy enm;
        private bool isPlayerMove;
        public GameManadger(IEnemy enem,bool[,] plf) {
            enm = enem;
            isPlayerMove = true;
            plaFieldShts = new bool[10, 10];
            enmFieldShts = new bool[10, 10];
            for(int i=0;i<10;i++)
                for(int j = 0; j < 10; j++) {
                    plaFieldShts[i, j] = false;
                    enmFieldShts[i, j] = false;
                }
            plaField = plf;
            enm.moveMaked += enemyMoveProcessor;
        }
        public void enemyMoveProcessor(Cell cl) {
            if (!isPlayerMove) {
                ShootPlayerField(cl);
                plaFieldShts[cl.x, cl.y] = true; 
                isPlayerMove = true;
                if (plaField[cl.x, cl.y]) {
                    if ((cl.x == 0 || !plaField[cl.x - 1, cl.y])&& (cl.x == 9 || !plaField[cl.x + 1, cl.y])) {

                    }else if ((cl.y == 0 || !plaField[cl.x, cl.y - 1])&& (cl.y == 9 || !plaField[cl.x, cl.y + 1])) {

                    }else if (cl.x == 0 || !plaField[cl.x - 1, cl.y]) {
                        for(int i=1;i<4;i++)
                            if (!plaField[cl.x-i,cl.y]) {
                                //корабль сбит
                            }else if(plaField[cl.x - i, cl.y]&&plaFieldShts[cl.x-i,cl.y]) {
                                //продолжпем проверку
                            } else {
                                //попал
                            }
                    }else if (cl.y == 0 || !plaField[cl.x, cl.y - 1]) {

                    }else if (cl.x == 9 || !plaField[cl.x + 1, cl.y]) {

                    }else if (cl.y == 9 || !plaField[cl.x, cl.y + 1]) {

                    } else {
                        //миио
                    }
                }
            }
        }
        public void playerMoveProcessor(Cell cl) {
            if (isPlayerMove&&!enmFieldShts[cl.x,cl.y]) {
                ShootEnemyField(cl,enm.getShoot(cl));
                enmFieldShts[cl.x, cl.y] = true;
                isPlayerMove=false;
                enm.askShoot();
            }
        }
    }
}
