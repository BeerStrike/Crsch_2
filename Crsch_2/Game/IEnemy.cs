using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crsch_2.Game {
   public interface IEnemy {
        event GameManadger.ShootCell moveMaked;
        string getName();
        int CheckConnect();
        void Ready();
        void askShoot();
        int getShoot(Cell cl);
        void sendShootRes(Cell cl,int type);
    }
}
