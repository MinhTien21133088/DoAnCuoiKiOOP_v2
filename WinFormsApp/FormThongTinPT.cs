using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class FormThongTinPT : Form
    {
        string[] ten = { "" };
        string[] noiDung = { "" };
        public FormThongTinPT()
        {
            InitializeComponent();
        }
        // Vẫn đang làm

        public void ShowInfo()
        {
            int x = this.Location.X;
            int y = this.Location.Y;
            List<Label> lbTen = new List<Label>();
            List<Label> lbNoiDung = new List<Label>();

            Label lb1 = new Label();
            lb1.Text = "Ho va ten:";
            Label lb2 = new Label();
            lb2.Text = "Nguyen Van A";

            lbTen.Add(lb1);
            lbNoiDung.Add(lb2);

            for (int i = 0; i < ten.Length; i++)
            {
                lbTen[i].Location = new Point(x+10, y+10);
                lbNoiDung[i].Location = new Point(x + 100, y + 10);
                this.Controls.Add(lbTen[i]);
                this.Controls.Add(lbNoiDung[i]);
            }
        }

        public void AddOption(string ten, string noiDung)
        {
            
        }
    }
}
