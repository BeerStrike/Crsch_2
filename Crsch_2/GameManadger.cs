using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crsch_2 {
    class GameManadger {
        private bool[,] fieldLft;
        private bool[,] fieldRgh;
        private PlayerBase Lft;
        private PlayerBase Rgh;
        int LftRemained;
        int RghRemained;
        public GameManadger(PlayerBase LftPl,PlayerBase RghPl) {
            fieldLft = new bool[10, 10];
            fieldRgh = new bool[10, 10];
            Lft = LftPl;
            Rgh = RghPl;
            LftRemained = 16;
            RghRemained = 16;
        }
        public void StartGame() {
            while (true) {
                Cell Sht = Lft.AskShoot();
                bool Res = fieldRgh[Sht.x,Sht.y];
                if (Res) {
                    if (fieldRgh[Sht.x + 1, Sht.y] || fieldRgh[Sht.x, Sht.y + 1] || fieldRgh[Sht.x, Sht.y - 1] || fieldRgh[Sht.x - 1, Sht.y])
                        Lft.ResiveHit(1);
                    else
                        Lft.ResiveHit(2);
                    fieldRgh[Sht.x, Sht.y] = false;
                    if (--RghRemained == 0) {
                        //TODO: левый выйграл
                    }
                } else Lft.ResiveHit(0);
                Sht = Rgh.AskShoot();
                Res = fieldRgh[Sht.x, Sht.y];
                if (Res) {
                    if (fieldLft[Sht.x + 1, Sht.y] || fieldLft[Sht.x, Sht.y + 1] || fieldLft[Sht.x, Sht.y - 1] || fieldLft[Sht.x - 1, Sht.y])
                        Rgh.ResiveHit(1);
                    else
                        Rgh.ResiveHit(2);
                    fieldLft[Sht.x, Sht.y] = false;
                    if (--RghRemained == 0) {
                        //TODO: правый выйграл
                    }
                } else Rgh.ResiveHit(0);
            }
        }
    }
}
