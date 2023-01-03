using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crsch_2 {
    abstract class PlayerBase {
        public abstract Cell AskShoot();
        public abstract void ResiveHit(int Hit);
    }
}
