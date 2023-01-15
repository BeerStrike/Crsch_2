using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crsch_2 {
    public partial class RecsForm : Form {
        public RecsForm() {
            InitializeComponent();
            TableHeader.Location = new Point(20, 10);
            using (StreamReader sr = new StreamReader("Recs.txt")) {
                int i = 0;
                while (i != 5) {
                    Label lb = new Label();
                    if (!sr.EndOfStream) {
                        lb.Text = (i+1) + ")" + " " + sr.ReadLine() + ": " + sr.ReadLine();
                        i++;
                    } else {
                        lb.Text = (i+1) + ")" + " Пусто";
                        i++;
                    }
                    lb.Location = new Point(20, 10 + 25 * i);
                    this.Controls.Add(lb);

                }
            }
        }
    }
}
