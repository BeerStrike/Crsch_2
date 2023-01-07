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
        private List<Cell> shtd;
        public GameManadger(IEnemy enem,bool[,] plf) {
            shtd = new List<Cell>();
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
            if (!isPlayerMove) {//TODO: список или так пойдет
                ShootPlayerField(cl);
                plaFieldShts[cl.x, cl.y] = true; 
                isPlayerMove = true;
                if (plaField[cl.x, cl.y]) {
                    if ((cl.x != 0 && plaField[cl.x - 1, cl.y]) && (cl.x != 9 && plaField[cl.x + 1, cl.y])) {
                        for (int i = 1; i < 5; i++)
                            if (cl.x - i + 1 == 0 || !plaField[cl.x - i, cl.y]) {
                                for (int j = 1; j < 5; j++)
                                    if (cl.x + j - 1 == 9 || !plaField[cl.x + j, cl.y]) {
                                        enm.sendShootRes(cl, 2);
                                        break;
                                    } else if (!plaFieldShts[cl.x + j, cl.y]) {
                                        enm.sendShootRes(cl, 1);
                                        break;
                                    }
                            } else if (!plaFieldShts[cl.x - i, cl.y]) {
                                enm.sendShootRes(cl, 1);
                                break;
                            }
                    } else if ((cl.y != 0 && plaField[cl.x, cl.y - 1]) && (cl.y != 9 && plaField[cl.x, cl.y + 1])) {
                        for (int i = 1; i < 5; i++)
                            if (cl.y - i + 1 == 0 || !plaField[cl.x, cl.y - i]) {
                                for (int j = 1; j < 5; j++)
                                    if (cl.y + j - 1 == 9 || !plaField[cl.x, cl.y + j]) {
                                        enm.sendShootRes(cl, 2);
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
                        for (int i = 1; i < 5; i++)
                            if (cl.x - i + 1 == 0 || !plaField[cl.x - i, cl.y]) {
                                enm.sendShootRes(cl, 2);
                                break;
                            } else if (!plaFieldShts[cl.x - i, cl.y]) {
                                enm.sendShootRes(cl, 1);
                                break;
                            }
                    } else if (cl.y != 0 && plaField[cl.x, cl.y - 1]) {
                        for (int i = 1; i < 5; i++)
                            if (cl.y - i + 1 == 0 || !plaField[cl.x, cl.y - i]) {
                                enm.sendShootRes(cl, 2);
                                break;
                            } else if (!plaFieldShts[cl.x, cl.y - i]) {
                                enm.sendShootRes(cl, 1);
                                break;
                            }
                    } else if (cl.x != 9 && plaField[cl.x + 1, cl.y]) {
                        for (int i = 1; i < 5; i++)
                            if (cl.x + i - 1 == 9 || !plaField[cl.x + i, cl.y]) {
                                enm.sendShootRes(cl, 2);
                                break; 
                            } else if (!plaFieldShts[cl.x + i, cl.y]) {
                                enm.sendShootRes(cl, 1);
                                break;
                            }
                    } else if (cl.y != 9 && plaField[cl.x, cl.y + 1]) {
                        for (int i = 1; i < 5; i++)
                            if (cl.y + i - 1 == 9 || !plaField[cl.x, cl.y + i]) {
                                enm.sendShootRes(cl, 2);
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
            if (isPlayerMove&&!enmFieldShts[cl.x,cl.y]) {
                int gt = enm.getShoot(cl);
                if (gt != 0) {
                    shtd.Add(cl);
                    if (--enemyRemain == 0)
                        Win();
                    if (gt == 2) {
                        if (cl.x != 0 && !shtd.Contains(new Cell(cl.x - 1, cl.y)))
                            ShootEnemyField(new Cell(cl.x - 1, cl.y), 0);
                        if (cl.x != 9 && !shtd.Contains(new Cell(cl.x +1, cl.y)))
                            ShootEnemyField(new Cell(cl.x +1, cl.y), 0);
                        if (cl.y != 0 && !shtd.Contains(new Cell(cl.x , cl.y - 1)))
                            ShootEnemyField(new Cell(cl.x , cl.y - 1), 0);
                        if (cl.y != 9 && !shtd.Contains(new Cell(cl.x , cl.y + 1)))
                            ShootEnemyField(new Cell(cl.x , cl.y + 1), 0);
                        if (cl.x != 9 && cl.y != 9 && !shtd.Contains(new Cell(cl.x +1, cl.y + 1)))
                            ShootEnemyField(new Cell(cl.x +1, cl.y + 1), 0);
                        if (cl.x != 0 && cl.y != 0 && !shtd.Contains(new Cell(cl.x -1, cl.y - 1)))
                            ShootEnemyField(new Cell(cl.x-1 , cl.y-1), 0);
                        if (cl.x  != 0 && cl.y != 9 && !shtd.Contains(new Cell(cl.x - 1, cl.y + 1)))
                            ShootEnemyField(new Cell(cl.x -1, cl.y+1), 0);
                        if (cl.x  != 9 && cl.y != 0 && !shtd.Contains(new Cell(cl.x +1, cl.y - 1)))
                            ShootEnemyField(new Cell(cl.x +1, cl.y-1), 0);
                        if (cl.x != 0 && shtd.Contains(new Cell(cl.x - 1, cl.y))) {
                            for (int i = 0; i < 4; i++)
                                if (cl.x - i != 0 && shtd.Contains(new Cell(cl.x - i - 1, cl.y))) {
                                    ShootEnemyField(new Cell(cl.x - i - 1, cl.y), 2);
                                    if (cl.x != 0 && !shtd.Contains(new Cell(cl.x - i - 1 - 1, cl.y)))
                                        ShootEnemyField(new Cell(cl.x - i - 1 - 1, cl.y), 0);
                                    if (cl.x != 9 && !shtd.Contains(new Cell(cl.x - i - 1 + 1, cl.y)))
                                        ShootEnemyField(new Cell(cl.x - i - 1 + 1, cl.y), 0);
                                    if (cl.y != 0 && !shtd.Contains(new Cell(cl.x - i - 1, cl.y - 1)))
                                        ShootEnemyField(new Cell(cl.x - i - 1, cl.y - 1), 0);
                                    if (cl.y != 9 && !shtd.Contains(new Cell(cl.x - i - 1, cl.y + 1)))
                                        ShootEnemyField(new Cell(cl.x - i - 1, cl.y + 1), 0);
                                    if (cl.x != 9 && cl.y != 9 && !shtd.Contains(new Cell(cl.x - i - 1 + 1, cl.y + 1)))
                                        ShootEnemyField(new Cell(cl.x - i - 1 + 1, cl.y + 1), 0);
                                    if (cl.x != 0 && cl.y != 0 && !shtd.Contains(new Cell(cl.x - i - 1 - 1, cl.y - 1)))
                                        ShootEnemyField(new Cell(cl.x - i - 1 - 1, cl.y - 1), 0);
                                    if (cl.x != 0 && cl.y != 9 && !shtd.Contains(new Cell(cl.x - i - 1 - 1, cl.y + 1)))
                                        ShootEnemyField(new Cell(cl.x - i - 1 - 1, cl.y + 1), 0);
                                    if (cl.x != 9 && cl.y != 0 && !shtd.Contains(new Cell(cl.x - i - 1 + 1, cl.y - 1)))
                                        ShootEnemyField(new Cell(cl.x - i - 1 + 1, cl.y - 1), 0);
                                } else break;
                        }
                        if (cl.y != 0 && shtd.Contains(new Cell(cl.x, cl.y - 1))) {
                            for (int i = 0; i < 4; i++)
                                if (cl.y - i != 0 && shtd.Contains(new Cell(cl.x, cl.y - i - 1))) {
                                    ShootEnemyField(new Cell(cl.x, cl.y - i - 1), 2);
                                    if (cl.x != 0 && !shtd.Contains(new Cell(cl.x - 1, cl.y - i - 1)))
                                        ShootEnemyField(new Cell(cl.x - 1, cl.y - i - 1), 0);
                                    if (cl.x != 9 && !shtd.Contains(new Cell(cl.x + 1, cl.y - i - 1)))
                                        ShootEnemyField(new Cell(cl.x + 1, cl.y - i - 1), 0);
                                    if (cl.y != 0 && !shtd.Contains(new Cell(cl.x, cl.y - i - 1 - 1)))
                                        ShootEnemyField(new Cell(cl.x, cl.y - i - 1 - 1), 0);
                                    if (cl.y != 9 && !shtd.Contains(new Cell(cl.x, cl.y - i - 1 + 1)))
                                        ShootEnemyField(new Cell(cl.x, cl.y - i - 1 + 1), 0);
                                    if (cl.x != 9 && cl.y != 9 && !shtd.Contains(new Cell(cl.x + 1, cl.y - i - 1 + 1)))
                                        ShootEnemyField(new Cell(cl.x + 1, cl.y - i - 1 + 1), 0);
                                    if (cl.x != 0 && cl.y != 0 && !shtd.Contains(new Cell(cl.x - 1, cl.y - i - 1 - 1)))
                                        ShootEnemyField(new Cell(cl.x - 1, cl.y - i - 1 - 1), 0);
                                    if (cl.x != 0 && cl.y != 9 && !shtd.Contains(new Cell(cl.x - 1, cl.y - i - 1 + 1)))
                                        ShootEnemyField(new Cell(cl.x - 1, cl.y - i - 1 + 1), 0);
                                    if (cl.x != 9 && cl.y != 0 && !shtd.Contains(new Cell(cl.x + 1, cl.y - i - 1 - 1)))
                                        ShootEnemyField(new Cell(cl.x + 1, cl.y - i - 1 - 1), 0);
                                } else break;

                        }
                        if (cl.x != 9 && shtd.Contains(new Cell(cl.x + 1, cl.y))) {
                            for (int i = 0; i < 4; i++)
                                if (cl.x + i != 9 && shtd.Contains(new Cell(cl.x + i + 1, cl.y))) {
                                    ShootEnemyField(new Cell(cl.x + i + 1, cl.y), 2);
                                    if (cl.x != 0 && !shtd.Contains(new Cell(cl.x + i + 1 - 1, cl.y)))
                                        ShootEnemyField(new Cell(cl.x + i + 1 - 1, cl.y), 0);
                                    if (cl.x != 9 && !shtd.Contains(new Cell(cl.x + i + 1 + 1, cl.y)))
                                        ShootEnemyField(new Cell(cl.x + i + 1 + 1, cl.y), 0);
                                    if (cl.y != 0 && !shtd.Contains(new Cell(cl.x + i + 1, cl.y - 1)))
                                        ShootEnemyField(new Cell(cl.x + i + 1, cl.y - 1), 0);
                                    if (cl.y != 9 && !shtd.Contains(new Cell(cl.x + i + 1, cl.y + 1)))
                                        ShootEnemyField(new Cell(cl.x + i + 1, cl.y + 1), 0);
                                    if (cl.x != 9 && cl.y != 9 && !shtd.Contains(new Cell(cl.x + i + 1 + 1, cl.y + 1)))
                                        ShootEnemyField(new Cell(cl.x + i + 1 + 1, cl.y + 1), 0);
                                    if (cl.x != 0 && cl.y != 0 && !shtd.Contains(new Cell(cl.x + i + 1 - 1, cl.y - 1)))
                                        ShootEnemyField(new Cell(cl.x + i + 1 - 1, cl.y - 1), 0);
                                    if (cl.x != 0 && cl.y != 9 && !shtd.Contains(new Cell(cl.x + i + 1 - 1, cl.y + 1)))
                                        ShootEnemyField(new Cell(cl.x + i + 1 - 1, cl.y + 1), 0);
                                    if (cl.x != 9 && cl.y != 0 && !shtd.Contains(new Cell(cl.x + i + 1 + 1, cl.y - 1)))
                                        ShootEnemyField(new Cell(cl.x + i + 1 + 1, cl.y - 1), 0);
                                } else break;

                        }
                        if (cl.y != 9 && shtd.Contains(new Cell(cl.x, cl.y + 1))) {
                            for (int i = 0; i < 4; i++)
                                if (cl.y + i != 0 && shtd.Contains(new Cell(cl.x, cl.y + i + 1))) {
                                    ShootEnemyField(new Cell(cl.x, cl.y + i + 1), 2);
                                    if (cl.x != 0 && !shtd.Contains(new Cell(cl.x - 1, cl.y + i + 1)))
                                        ShootEnemyField(new Cell(cl.x - 1, cl.y + i + 1), 0);
                                    if (cl.x != 9 && !shtd.Contains(new Cell(cl.x + 1, cl.y + i + 1)))
                                        ShootEnemyField(new Cell(cl.x + 1, cl.y + i + 1), 0);
                                    if (cl.y != 0 && !shtd.Contains(new Cell(cl.x, cl.y + i + 1 - 1)))
                                        ShootEnemyField(new Cell(cl.x, cl.y - 1 + i + 1), 0);
                                    if (cl.y != 9 && !shtd.Contains(new Cell(cl.x, cl.y + i + 1 + 1)))
                                        ShootEnemyField(new Cell(cl.x, cl.y + 1 + i + 1), 0);
                                    if (cl.x != 9 && cl.y != 9 && !shtd.Contains(new Cell(cl.x + 1, cl.y + i + 1 + 1)))
                                        ShootEnemyField(new Cell(cl.x + 1, cl.y + 1 + i + 1), 0);
                                    if (cl.x != 0 && cl.y != 0 && !shtd.Contains(new Cell(cl.x - 1, cl.y + i + 1 - 1)))
                                        ShootEnemyField(new Cell(cl.x - 1, cl.y - 1 + i + 1), 0);
                                    if (cl.x != 0 && cl.y != 9 && !shtd.Contains(new Cell(cl.x - 1, cl.y + i + 1 + 1)))
                                        ShootEnemyField(new Cell(cl.x - 1, cl.y + 1 + i + 1), 0);
                                    if (cl.x != 9 && cl.y != 0 && !shtd.Contains(new Cell(cl.x + 1, cl.y + i + 1 - 1)))
                                        ShootEnemyField(new Cell(cl.x + 1, cl.y - 1 + i + 1), 0);
                                } else break;

                        }
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
