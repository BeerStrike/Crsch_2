using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crsch_2.Game {
    interface IEnemy {
        event GameManadger.ShootCell moveMaked;
        void askShoot();
        int getShoot(Cell cl);
    }
}
