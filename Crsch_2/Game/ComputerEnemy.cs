using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crsch_2.Game {
    class ComputerEnemy :IEnemy{
        private List<Cell> q;
        public event GameManadger.ShootCell moveMaked;
        private bool[,] myField;
        public ComputerEnemy() {
            q = new List<Cell>();
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
            if (myField[cl.x, cl.y])
                return 1;
            else
                return 0;
        }
    }
   
}
