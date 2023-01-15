using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Crsch_2.Game {
    class NetworkEnemy : IEnemy {
        private Socket sckt;
        private int asyncResRectver = -1;
        private int timeOut = 5;
        private bool isReady =false;
        private string name;
        public NetworkEnemy(Socket s,string nme) {
            name = nme;
            sckt = s;
            Reciver();
        }
        public event GameManadger.ShootCell moveMaked;
        
        public void askShoot() {
        }

        public int CheckConnect() {
            byte[] buf = new byte[256];
            buf[0] = 3;
            sckt.Send(buf);
            int wait = timeOut;
            while (asyncResRectver == -1) {
                Thread.Sleep(100);
                if (--wait == 0) {
                    sckt.Dispose();
                    return 0;
                }
            }
            int b = asyncResRectver;
            asyncResRectver = -1;
            return b;
        }

        public string getName() {
            return name;
        }

        public int getShoot(Cell cl) {
            byte[] buf = new byte[256];
            buf[0] = 1;
            buf[1]=(byte)cl.x;
            buf[2]=(byte)cl.y;
            sckt.Send(buf);
            int wait = timeOut;
            while (asyncResRectver == -1) {
                Thread.Sleep(100);
                if (--wait == 0) {
                    sckt.Dispose();
                    return -1;
                }
            }
            int b = asyncResRectver;
            asyncResRectver = -1;
            return b;
        }

        public void Ready() {
            isReady = true;
        }

        public void sendShootRes(Cell cl, int type) {
            byte[] buf = new byte[256];
            buf[0] = 2;
            buf[1] = (byte)cl.x;
            buf[2] = (byte)cl.y;
            buf[3] = (byte)type;
            sckt.Send(buf);
        }
        private async void Reciver() {
            byte[] buf = new byte[256];
            while (true) {
                if (!sckt.Connected)
                    break;
                await Task.Run(() => {
                    try {
                        sckt.Receive(buf);
                        switch (buf[0]) {
                            case 2: {
                                    asyncResRectver = (int)buf[3];
                                }
                                break;
                            case 3: {
                                    buf = new byte[256];
                                    buf[0] = 4;
                                    if (isReady)
                                        buf[1] = 1;
                                    else
                                        buf[1] = 2;
                                    sckt.Send(buf);
                                }
                                break;
                            case 4: {
                                    asyncResRectver = (int)buf[1];
                                }
                                break;

                        }
                    } catch (SocketException e) {

                    }
                });
                switch (buf[0]) {
                    case 1: {
                            Cell cl = new Cell();
                            cl.x = buf[1];
                            cl.y = buf[2];
                            byte[] bf = new byte[256];
                            moveMaked(cl);
                        }
                        break;
                }
            }
        }
    }
}
