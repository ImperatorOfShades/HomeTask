using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Praktica
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public static Project Buff;
        private void Addbtn_Click(object sender, EventArgs e)
        {
            if ((posTB.Value > Form1.NRec+1) || (posTB.Value < 1))
            {
                MessageBox.Show("Проект не может занять "+posTB.Value+" позицию!");
                this.Hide();
            }
            Buff = new Project();
            if (NameTB.Text == "")
            {
                MessageBox.Show("Проект не может быть безымнным!");
                return;
            }
            if (ClientTB.Text == "")
            {
                MessageBox.Show("Проект не может быть без заказчика!");
                return;
            }
            Buff.Name = NameTB.Text;

            Buff.Client = ClientTB.Text;

            Buff.StartDate = startDateTB.Text;
            Buff.EndDate = endDateTB.Text;

            Buff.Price = Convert.ToDecimal(PriceTB.Value);
            Buff.Realization = Convert.ToDouble(RealizTB.Value);
            Buff.Rollback = Convert.ToDouble(RollbackTB.Value);
            Buff.adding = true;
            Buff.possition = (Convert.ToInt32(posTB.Value)) - 1;
            this.Hide();
        }

    }
}
