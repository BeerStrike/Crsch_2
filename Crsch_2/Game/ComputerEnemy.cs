using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crsch_2.Game {
    class ComputerEnemy :IEnemy{
        private List<Cell> q;
        private List<Cell> shtd;
        private Stack<Cell> prevhit;
        public event GameManadger.ShootCell moveMaked;
        private bool[,] myField;
        public ComputerEnemy() {
            q = new List<Cell>();
            prevhit = new Stack<Cell>();
            shtd = new List<Cell>();
            myField = new bool[10, 10];
            for (int i = 0; i <= 9; i++)
                for (int j = 0; j <= 9; j++) {
                    q.Add(new Cell(i, j));
                    myField[i, j] = false;
                }
            myField[5, 5] = true;
            myField[5, 6] = true; 
            Random RND = new Random();
            for (int i = 0; i < q.Count; i++) {
                Cell tmp = q[0];
                q.RemoveAt(0);
                q.Insert(RND.Next(q.Count), tmp);
            }
        }
        public  void askShoot() {
            if (q.Count != 0) {
                Cell r = q[0];
                q.Remove(r);
                moveMaked(r);
            }
            else moveMaked(new Cell(0,0));
        }
        public  int getShoot(Cell cl) {
            shtd.Add(cl);
            if (myField[cl.x, cl.y]) {
                if ((cl.x != 0 && myField[cl.x - 1, cl.y]) && (cl.x != 9 && myField[cl.x + 1, cl.y])) {
                    for (int i = 1; i < 4; i++)
                        if (cl.x - i >= 0 || !myField[cl.x - i, cl.y]) {
                            for (int j = 1; j < 4; j++)
                                if (cl.x + j == 9 || !myField[cl.x + j, cl.y]) {
                                  return 2;
                                } else if (!shtd.Contains(new Cell(cl.x + j, cl.y))) {
                                    return 1;
                                    break; 
                                }
                        } else if (!shtd.Contains(new Cell(cl.x -i, cl.y))) {
                            return 1;
                            break;
                        }
                } else if ((cl.y != 0 && myField[cl.x, cl.y - 1]) && (cl.y != 9 && myField[cl.x, cl.y + 1])) {
                    for (int i = 1; i < 4; i++)
                        if (cl.y - i >= 0 || !myField[cl.x, cl.y - i]) {
                            for (int j = 1; j < 4; j++)
                                if (cl.y + j == 9 || !myField[cl.x, cl.y + j]) {
                                  return 2;
                                } else if (!shtd.Contains(new Cell(cl.x, cl.y + j))) {
                                    return 1;
                                    break;
                                }
                        } else if (!shtd.Contains(new Cell(cl.x, cl.y - i))) {
                            return 1;
                            break;
                        }
                } else if (cl.x != 0 && myField[cl.x - 1, cl.y]) {
                    for (int i = 1; i < 4; i++)
                        if (cl.x - i == 0 || !myField[cl.x - i, cl.y]) {
                          return 2;
                            break;
                        } else if (!shtd.Contains(new Cell(cl.x - i, cl.y))) {
                            return 1;
                            break;
                        }
                } else if (cl.y != 0 && myField[cl.x, cl.y - 1]) {
                    for (int i = 1; i < 4; i++)
                        if (cl.y - i == 0 || !myField[cl.x, cl.y - i]) {
                          return 2;
                        } else if (!shtd.Contains(new Cell(cl.x, cl.y - i))) {
                            return 1;
                        }
                } else if (cl.x != 9 && myField[cl.x + 1, cl.y]) {
                    for (int i = 1; i < 4; i++)
                        if (cl.x + i == 9 || !myField[cl.x + i, cl.y]) {
                          return 2;
                        } else if (!shtd.Contains(new Cell(cl.x + i, cl.y))) {
                            return 1;
                            break;
                        }
                } else if (cl.y != 9 && myField[cl.x, cl.y + 1]) {
                    for (int i = 1; i < 4; i++)
                        if (cl.y + i == 9 || !myField[cl.x, cl.y + i]) {
                            return 2;

                        } else if (!shtd.Contains(new Cell(cl.x, cl.y + i))) {
                            return 1;
                        }

                } else return 2;
            } else
                return 0;
            return 3;
        }

        public void sendShootRes(Cell cl, int type) {
            if (type == 1) {
                if (prevhit.Count() == 0) {
                    int i = 0;
                    if (cl.x != 0) {
                        Cell mv = new Cell(cl.x - 1, cl.y);
                        if (q.Contains(mv)) {
                            q.Remove(mv);
                            q.Insert(0, mv);
                            i++;
                        }
                    }
                    if (cl.x != 9) {
                        Cell mv = new Cell(cl.x + 1, cl.y);
                        if (q.Contains(mv)) {
                            q.Remove(mv);
                            q.Insert(0, mv);
                            i++;
                        }
                    }
                    if (cl.y != 0) {
                        Cell mv = new Cell(cl.x, cl.y - 1);
                        if (q.Contains(mv)) {
                            q.Remove(mv);
                            q.Insert(0, mv);
                            i++;
                        }
                    }
                    if (cl.y != 9) {
                        Cell mv = new Cell(cl.x, cl.y + 1);
                        if (q.Contains(mv)) {
                            q.Remove(mv);
                            q.Insert(0, mv);
                            i++;
                        }
                    }
                    for (int j = 0; j < i; j++) {
                        Cell tmp = q[0];
                        q.RemoveAt(0);
                        Random RND = new Random();
                        q.Insert(RND.Next(i), tmp);
                    }
                } else {
                    if (prevhit.Peek().x == cl.x) {
                        if (prevhit.Peek().y < cl.y) {
                            Cell mv = new Cell(cl.x, cl.y + 1);
                            if (q.Contains(mv)) {
                                q.Remove(mv);
                                q.Insert(0, mv);
                            }
                        } else {
                            Cell mv = new Cell(cl.x, cl.y - 1);
                            if (q.Contains(mv)) {
                                q.Remove(mv);
                                q.Insert(0, mv);
                            }
                        }
                    } else if (prevhit.Peek().y == cl.y) {
                        if (prevhit.Peek().x < cl.x) {
                            Cell mv = new Cell(cl.x + 1, cl.y);
                            if (q.Contains(mv)) {
                                q.Remove(mv);
                                q.Insert(0, mv);
                            }
                        } else {
                            Cell mv = new Cell(cl.x - 1, cl.y);
                            if (q.Contains(mv)) {
                                q.Remove(mv);
                                q.Insert(0, mv);
                            }
                        }
                    }
                }
                prevhit.Push(cl);
            } else {
                if(type==2){
                    prevhit.Push(cl);
                    while (prevhit.Count() != 0) {
                        cl = prevhit.Pop();
                        q.Remove(new Cell(cl.x-1, cl.y));
                        q.Remove(new Cell(cl.x, cl.y-1));
                        q.Remove(new Cell(cl.x+1, cl.y));
                        q.Remove(new Cell(cl.x, cl.y+1));
                        q.Remove(new Cell(cl.x-1, cl.y-1));
                        q.Remove(new Cell(cl.x+1, cl.y+1));
                        q.Remove(new Cell(cl.x-1, cl.y+1));
                        q.Remove(new Cell(cl.x-1, cl.y+1)); 
                    }
                 }
            }
        }
    }
   
}
