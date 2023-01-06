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
        public delegate void EndGame();
        public event EndGame Win;
        public event EndGame Lose;
        private bool[,] plaFieldShts;
        private bool[,] enmFieldShts;
        private bool[,] plaField;
        private IEnemy enm;
        private bool isPlayerMove;
        private int playerRemain = 20;
        private int enemyRemain = 20  ;
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
                    if ((cl.x != 0 && plaField[cl.x - 1, cl.y])&& (cl.x != 9 && plaField[cl.x + 1, cl.y])) {
                         for(int i=1;i<4;i++)
                            if (cl.x - i >= 0 || !plaField[cl.x - i, cl.y]) {
                                for (int j = 1; j < 4; j++)
                                    if (cl.x + j == 9 || !plaField[cl.x + j, cl.y]) {
                                        enm.sendShootRes(cl, 2);
                                        //
                                        break;
                                    } else if (!plaFieldShts[cl.x + j, cl.y]) {
                                        enm.sendShootRes(cl, 1);
                                        break;
                                    }
                            } else if (!plaFieldShts[cl.x - i, cl.y]) {
                                enm.sendShootRes(cl, 1);
                                break;
                            }
                    } else if ((cl.y != 0 && plaField[cl.x, cl.y - 1])&& (cl.y != 9 && plaField[cl.x, cl.y + 1])) {
                        for (int i = 1; i < 4; i++)
                            if (cl.y - i >= 0 || !plaField[cl.x, cl.y - i]) {
                                for (int j = 1; j < 4; j++)
                                    if (cl.y + j == 9 || !plaField[cl.x, cl.y + j]) {
                                        enm.sendShootRes(cl, 2);
                                        //
                                        break;
                                    } else if (!plaFieldShts[cl.x, cl.y + j]) {
                                        enm.sendShootRes(cl, 1);
                                        break;
                                    }
                            } else if (!plaFieldShts[cl.x, cl.y - i]) {
                                enm.sendShootRes(cl, 1);
                                break;
                            }
                    } else if (cl.x != 0 && plaField[cl.x - 1, cl.y]) {
                        for(int i=1;i<4;i++)
                            if (cl.x-i==0||!plaField[cl.x-i,cl.y]) {
                                enm.sendShootRes(cl,2);
                              /*  while (i != -1) {
                                   if(cl.x!=0) ShootPlayerField(new Cell(cl.x-1, cl.y));
                                   if(cl.y!=0) ShootPlayerField(new Cell(cl.x, cl.y-1));
                                   if (cl.x != 0&&cl.y!=0) ShootPlayerField(new Cell(cl.x-1, cl.y-1));
                                   if (cl.x != 9) ShootPlayerField(new Cell(cl.x+1, cl.y));
                                   if (cl.y != 9) ShootPlayerField(new Cell(cl.x, cl.y+1));
                                   if (cl.x != 9&&cl.y!=9) ShootPlayerField(new Cell(cl.x+1, cl.y+1));
                                   if (cl.x != 0&&cl.y!=9) ShootPlayerField(new Cell(cl.x-1, cl.y+1));
                                   if (cl.x != 9&&cl.y!=0) ShootPlayerField(new Cell(cl.x+1, cl.y-1));
                                    i--;
                                }*/ 
                                break;
                             }else if(!plaFieldShts[cl.x-i,cl.y]) { 
                                 enm.sendShootRes(cl,1);
                                 break;
                            }
                    } else if (cl.y != 0 && plaField[cl.x, cl.y - 1]) {
                        for (int i = 1; i < 4; i++)
                            if (cl.y - i == 0 || !plaField[cl.x, cl.y-i]) {
                                enm.sendShootRes(cl, 2);
                              //
                                break;
                            } else if (!plaFieldShts[cl.x, cl.y-i]) {
                                enm.sendShootRes(cl, 1);
                                break;
                            }
                    } else if (cl.x != 9 && plaField[cl.x + 1, cl.y]) {
                        for (int i = 1; i < 4; i++)
                            if (cl.x + i == 9 || !plaField[cl.x+i, cl.y]) {
                                enm.sendShootRes(cl, 2);
                                //
                                break;
                            } else if (!plaFieldShts[cl.x+i, cl.y]) {
                                enm.sendShootRes(cl, 1);
                                break;
                            }
                    } else if (cl.y != 9 && plaField[cl.x, cl.y + 1]) {
                        for (int i = 1; i < 4; i++)
                            if (cl.y + i == 9 || !plaField[cl.x, cl.y + i]) {
                                enm.sendShootRes(cl, 2);
                                //
                                break;
                            } else if (!plaFieldShts[cl.x, cl.y + i]) {
                                enm.sendShootRes(cl, 1);
                                break;
                            } 

                    } else enm.sendShootRes(cl, 2);
                    if (--playerRemain == 0) {
                        Lose();
                    }

                } else {
                    enm.sendShootRes(cl, 0);
                }
            }
        }
        public void playerMoveProcessor(Cell cl) {
            //TODO: доделать эту херню
            if (isPlayerMove&&!enmFieldShts[cl.x,cl.y]) {
                int gt = enm.getShoot(cl);
                if (gt != 0)
                    if (--enemyRemain == 0)
                        Win();
                if (gt == 2) {
                    if(cl.x != 0 && plaField[cl.x - 1, cl.y]) {
                        for (int i = 0; i < 4; i++)
                            if (cl.x - i != 0 && plaField[cl.x - i - 1, cl.y])
                                ShootEnemyField(cl, 2);
                            else break;
                    }
                    if (cl.y != 0 && plaField[cl.x, cl.y - 1]) {
                        for (int i = 0; i < 4; i++)
                            if (cl.y - i != 0 && plaField[cl.x, cl.y - i - 1])
                                ShootEnemyField(cl, 2);
                            else break;

                    }
                    if (cl.x != 9 && plaField[cl.x + 1, cl.y]) {
                        for (int i = 0; i < 4; i++)
                            if (cl.x + i != 9 && plaField[cl.x + i + 1, cl.y])
                                ShootEnemyField(cl, 2);
                            else break;

                    }
                    if (cl.y != 9 && plaField[cl.x, cl.y + 1]) {
                        for (int i = 0; i < 4; i++)
                            if (cl.y + i != 0 && plaField[cl.x , cl.y+i+1])
                                ShootEnemyField(cl, 2);
                            else break;

                    }
                }
                  ShootEnemyField(cl,gt);
                enmFieldShts[cl.x, cl.y] = true;
                isPlayerMove=false;
                enm.askShoot();
            }
        }
    }
}
