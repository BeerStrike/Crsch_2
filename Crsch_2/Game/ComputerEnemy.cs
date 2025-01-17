﻿using System;
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
            myField = generateField();
           
            Random RND = new Random();
            for (int i = 0; i < q.Count; i++) {
                Cell tmp = q[0];
                q.RemoveAt(0);
                q.Insert(RND.Next(q.Count), tmp);
            }
        }
        private bool[,] generateField() {
            myField = new bool[10, 10];
            for (int i = 0; i <= 9; i++)
                for (int j = 0; j <= 9; j++)
                    q.Add(new Cell(i, j));
            while (true) {
                for (int i = 0; i <= 9; i++)
                    for (int j = 0; j <= 9; j++)
                        myField[i, j] = false;
                int attempt= 10;
                Random RND = new Random();
                if (RND.Next(2) == 1) {
                    int x = RND.Next(10);
                    int y = RND.Next(7);
                    for(int i = 0; i < 4; i++) 
                        myField[x, y + i] = true;
                } else {
                    int x = RND.Next(7);
                    int y = RND.Next(10);
                    for (int i = 0; i < 4; i++)
                        myField[x+i, y] = true;
                }
                for(int k = 0; k < 2; k++) {
                    attempt = 80;
                    while (attempt != 0) {
                        if (RND.Next(2) == 1) {
                            int x = RND.Next(10);
                            int y = RND.Next(8);
                            bool valid = true;
                            for (int i = 0; i < 3; i++) {
                                if (!(!myField[x, y + i] &&
                                    (x == 0 || !myField[x - 1, y + i]) &&
                                    (y + i == 0 || !myField[x, y - 1 + i]) &&
                                    (x == 9 || !myField[x + 1, y + i]) &&
                                    (y + i == 9 || !myField[x, y + 1 + i]) &&
                                    (x == 0 || y + i == 0 || !myField[x - 1, y - 1 + i]) &&
                                    (x == 0 || y + i == 9 || !myField[x - 1, y + 1 + i]) &&
                                    (x == 9 || y + i == 0 || !myField[x + 1, y - 1 + i]) &&
                                    (x == 9 || y + i == 9 || !myField[x + 1, y + 1 + i]))) {
                                    attempt--;
                                    valid = false;
                                    break;
                                }
                            }
                            if (valid) {
                                for (int i = 0; i < 3; i++)
                                    myField[x, y + i] = true;
                                break;
                            }
                        } else {
                            int x = RND.Next(8);
                            int y = RND.Next(10);
                            bool valid = true;
                            for (int i = 0; i < 3; i++) {
                                if (!(!myField[x+i, y] &&
                                    (x + i == 0 || !myField[x - 1 + i, y]) &&
                                    (y == 0 || !myField[x + i, y - 1]) &&
                                    (x + i == 9 || !myField[x + 1 + i, y]) &&
                                    (y == 9 || !myField[x + i, y + 1]) &&
                                    (x + i == 0 || y == 0 || !myField[x - 1 + i, y - 1]) &&
                                    (x + i == 0 || y == 9 || !myField[x - 1 + i, y + 1]) &&
                                    (x + i == 9 || y == 0 || !myField[x + 1 + i, y - 1]) &&
                                    (x + i == 9 || y == 9 || !myField[x + 1 + i, y + 1]))) {
                                    attempt--;
                                    valid = false;
                                    break;
                                }
                            }
                            if (valid) {
                                for (int i = 0; i < 3; i++)
                                    myField[x + i, y] = true;
                                break;
                            }
                        }
                    }
                    if (attempt == 0)
                        break;
                }
                if (attempt == 0)
                    continue;
                for (int k = 0; k < 3; k++) {
                    attempt = 90;
                    while (attempt != 0) {
                        if (RND.Next(2) == 1) {
                            int x = RND.Next(10);
                            int y = RND.Next(9);
                            bool valid = true;
                            for (int i = 0; i < 2; i++) {
                                if (!(!myField[x, y + i] &&
                                    (x == 0 || !myField[x - 1, y + i]) &&
                                    (y + i == 0 || !myField[x, y - 1 + i]) &&
                                    (x == 9 || !myField[x + 1, y + i]) &&
                                    (y + i == 9 || !myField[x, y + 1 + i]) &&
                                    (x == 0 || y + i == 0 || !myField[x - 1, y - 1 + i]) &&
                                    (x == 0 || y + i == 9 || !myField[x - 1, y + 1 + i]) &&
                                    (x == 9 || y + i == 0 || !myField[x + 1, y - 1 + i]) &&
                                    (x == 9 || y + i == 9 || !myField[x + 1, y + 1 + i]))) {
                                    attempt--;
                                    valid = false;
                                    break;
                                }
                            }
                            if (valid) {
                                for (int i = 0; i < 2; i++)
                                    myField[x, y + i] = true;
                                break;
                            }
                        } else {
                            int x = RND.Next(9);
                            int y = RND.Next(10);
                            bool valid = true;
                            for (int i = 0; i < 2; i++) {
                                if (!(!myField[x + i, y] &&
                                    (x + i == 0 || !myField[x - 1 + i, y]) &&
                                    (y == 0 || !myField[x + i, y - 1]) &&
                                    (x + i == 9 || !myField[x + 1 + i, y]) &&
                                    (y == 9 || !myField[x + i, y + 1]) &&
                                    (x + i == 0 || y == 0 || !myField[x - 1 + i, y - 1]) &&
                                    (x + i == 0 || y == 9 || !myField[x - 1 + i, y + 1]) &&
                                    (x + i == 9 || y == 0 || !myField[x + 1 + i, y - 1]) &&
                                    (x + i == 9 || y == 9 || !myField[x + 1 + i, y + 1]))) {
                                    attempt--;
                                    valid = false;
                                    break;
                                }
                            }
                            if (valid) {
                                for (int i = 0; i < 2; i++)
                                    myField[x + i, y] = true;
                                break;
                            }
                        }
                    }
                    if (attempt == 0)
                        break;
                }
                if (attempt == 0)
                    continue;
                //
                for (int k = 0; k < 4; k++) {
                    attempt = 90;
                    while (attempt != 0) {
                        int x = RND.Next(10);
                        int y = RND.Next(10);
                        if (!myField[x , y] &&
                                   (x  == 0 || !myField[x - 1 , y]) &&
                                   (y == 0 || !myField[x , y - 1]) &&
                                   (x  == 9 || !myField[x + 1 , y]) &&
                                   (y == 9 || !myField[x , y + 1]) &&
                                   (x  == 0 || y == 0 || !myField[x - 1 , y - 1]) &&
                                   (x  == 0 || y == 9 || !myField[x - 1 , y + 1]) &&
                                   (x  == 9 || y == 0 || !myField[x + 1 , y - 1]) &&
                                   (x  == 9 || y == 9 || !myField[x + 1 , y + 1])) {
                            myField[x , y] = true;
                            break;
                        }
                    }
                    if (attempt == 0)
                        break;
                }
                if (attempt == 0)
                    continue;
                break;
            }
            /* myField[5, 5] = true;
             myField[5, 6] = true;
             myField[5, 9] = true;
             myField[6, 9] = true;
             myField[9, 5] = true;
             myField[9, 6] = true;
             myField[0, 0] = true;
             myField[0, 9] = true;
             myField[9, 0] = true;
             myField[9, 9] = true;
             myField[2, 1] = true;
             myField[3, 1] = true;
             myField[4, 1] = true;
             myField[1, 6] = true;
             myField[1, 3] = true;
             myField[1, 4] = true;
             myField[1, 5] = true;
             myField[7, 3] = true;
             myField[7, 4] = true;
             myField[7, 5] = true;*/
            return myField;
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
                    for (int i = 1; i < 5; i++)
                        if (cl.x - i+1 == 0 || !myField[cl.x - i, cl.y]) {
                            for (int j = 1; j < 5; j++)
                                if (cl.x + j-1 == 9 || !myField[cl.x + j, cl.y]) {
                                  return 2;
                                } else if (!shtd.Contains(new Cell(cl.x + j, cl.y))) {
                                    return 1;
                                }
                        } else if (!shtd.Contains(new Cell(cl.x -i, cl.y))) {
                            return 1;
                        }
                } else if ((cl.y != 0 && myField[cl.x, cl.y - 1]) && (cl.y != 9 && myField[cl.x, cl.y + 1])) {
                    for (int i = 1; i < 5; i++)
                        if (cl.y - i +1== 0 || !myField[cl.x, cl.y - i]) {
                            for (int j = 1; j < 5; j++)
                                if (cl.y + j-1 == 9 || !myField[cl.x, cl.y + j]) {
                                  return 2;
                                } else if (!shtd.Contains(new Cell(cl.x, cl.y + j))) {
                                    return 1;
                                }
                        } else if (!shtd.Contains(new Cell(cl.x, cl.y - i))) {
                            return 1;
                        }
                } else if (cl.x != 0 && myField[cl.x - 1, cl.y]) {
                    for (int i = 1; i < 5; i++)
                        if (cl.x - i+1 == 0 || !myField[cl.x - i, cl.y]) {
                          return 2;
                        } else if (!shtd.Contains(new Cell(cl.x - i, cl.y))) {
                            return 1;                        }
                } else if (cl.y != 0 && myField[cl.x, cl.y - 1]) {
                    for (int i = 1; i < 5; i++)
                        if (cl.y - i+1 == 0 || !myField[cl.x, cl.y - i]) {
                          return 2;
                        } else if (!shtd.Contains(new Cell(cl.x, cl.y - i))) {
                            return 1;
                        }
                } else if (cl.x != 9 && myField[cl.x + 1, cl.y]) {
                    for (int i = 1; i < 5; i++)
                        if (cl.x + i-1 == 9 || !myField[cl.x + i, cl.y]) {
                          return 2;
                        } else if (!shtd.Contains(new Cell(cl.x + i, cl.y))) {
                            return 1;
                        }
                } else if (cl.y != 9 && myField[cl.x, cl.y + 1]) {
                    for (int i = 1; i < 5; i++)
                        if (cl.y + i-1 == 9 || !myField[cl.x, cl.y + i]) {
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

        public int CheckConnect() {
            return 1;
        }

        public void Ready() {
        }

        public string getName() {
            return "Компьютер";
        }
    }
   
}
