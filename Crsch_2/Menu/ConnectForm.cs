using Crsch_2.Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crsch_2 {
    public partial class ConnectForm : Form {
        private Socket tcpSocket;
        public ConnectForm() {
            InitializeComponent();
            tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            CancelConnect.Hide();
        }

        private void ConnectBtn_Click(object sender, EventArgs e) {
            try {
                ConnectionWaiter(new IPEndPoint(IPAddress.Parse(ipInput.Text), Int32.Parse(portInput.Text)));
                ConnectBtn.Hide();
                WaitForConnect.Hide();
                } catch (FormatException exep) {
                MessageBox.Show("Данные для подключения не соответствуют формату", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void WaitForConnect_Click(object sender, EventArgs e) {
            try {
                IPEndPoint adr = new IPEndPoint(IPAddress.Parse(ipInput.Text),Int32.Parse(portInput.Text));
                tcpSocket.Bind(adr);
                tcpSocket.Listen(1);
                WaitConnect();
                ConnectBtn.Hide();
                WaitForConnect.Hide();
                CancelConnect.Show();
                CancelConnect.Click += CancelConnect_Click;
            } catch(FormatException exep) {
                MessageBox.Show("Данные для подключения не соответствуют формату","Ошибка",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void CancelConnect_Click(object sender, EventArgs e) {
            tcpSocket.Dispose();
            tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ConnectBtn.Show();
            WaitForConnect.Show();
            CancelConnect.Hide();
            CancelConnect.Click -= CancelConnect_Click;
        }
        private async void ConnectionWaiter(IPEndPoint adr) {
            bool isSucsess = false;
            string nme= "Sample text";
            await Task.Run(() => {
                try {
                    tcpSocket.Connect(adr);
                    byte[] buf = new byte[256];
                    tcpSocket.Receive(buf);
                    tcpSocket.Send(Encoding.UTF8.GetBytes(PlayerInfo.Default.Nickname));
                    nme = Encoding.UTF8.GetString(buf);
                    isSucsess = true;
                } catch (SocketException exep) {
                    MessageBox.Show(exep.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
            if (isSucsess) { 
                GameForm gm = new GameForm(new NetworkEnemy(tcpSocket,nme), false);
                this.Hide();
                try {
                    gm.ShowDialog();
                    tcpSocket.Close();
                } catch (SocketException exep) {
                    MessageBox.Show(exep.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else {
                tcpSocket.Dispose();
                tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                ConnectBtn.Show();
                WaitForConnect.Show();
            }
        }
        private async void WaitConnect() {
            bool isSucsess = false;
            string nme="Sample text";
            await Task.Run(() => {
                try {
                    Socket opsckt;
                    opsckt = tcpSocket.Accept();
                    byte[] buf = new byte[256];
                    opsckt.Send(Encoding.UTF8.GetBytes(PlayerInfo.Default.Nickname));
                    opsckt.Receive(buf);
                    nme = Encoding.UTF8.GetString(buf);
                    isSucsess = true;
                    tcpSocket.Dispose();
                    tcpSocket = opsckt;
                        //подключились
                }catch (SocketException exep) {
                    MessageBox.Show("Подключение остановлено пользователем", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            });
            if (isSucsess) {
                GameForm gm = new GameForm(new NetworkEnemy(tcpSocket,nme), true);
                this.Hide();
                try {
                    gm.ShowDialog();
                    tcpSocket.Close();
                } catch (SocketException exep) {
                    MessageBox.Show(exep.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Close();
            } else {
                tcpSocket.Close();
                tcpSocket= new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                ConnectBtn.Show();
                WaitForConnect.Show();
            }
        }
    }
}
