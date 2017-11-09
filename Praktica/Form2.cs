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
        public static string type_of_project;
        private void Addbtn_Click(object sender, EventArgs e)
        {
            if ((posTB.Value > Form1.NRec+1) || (posTB.Value < 1))
            {
                MessageBox.Show("Проект не может занять "+posTB.Value+" позицию!");
                this.Hide();
            }
            if(EconomicRadioButton.Checked)
                Buff = new Econom_Project();
            if (TechnRadioButton.Checked)
                Buff = new Technical_Project();
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

        private void NameTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (char.IsDigit(ch) && ch != 8) //Если символ, введенный с клавы - не цифра (IsDigit),
            {
                e.Handled = true; // то событие не обрабатывается. ch!=8 (8 - это Backspace)
                MessageBox.Show("В строке должны быть слова !!!!", "Коректность", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void PriceTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsDigit(e.KeyChar) && (e.KeyChar != 8)) && !((e.KeyChar == ',')))
            {
                e.KeyChar = '\0';
                MessageBox.Show("В строке должны быть цифры !!!!", "Коректность", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void ClientTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (char.IsDigit(ch) && ch != 8) //Если символ, введенный с клавы - не цифра (IsDigit),
            {
                e.Handled = true; // то событие не обрабатывается. ch!=8 (8 - это Backspace)
                MessageBox.Show("В строке должны быть слова !!!!", "Коректность", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void RealizTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsDigit(e.KeyChar) && (e.KeyChar != 8)) && !((e.KeyChar == ',')))
            {
                e.KeyChar = '\0';
                MessageBox.Show("В строке должны быть цифры !!!!", "Коректность", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void RollbackTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsDigit(e.KeyChar) && (e.KeyChar != 8)) && !((e.KeyChar == ',')))
            {
                e.KeyChar = '\0';
                MessageBox.Show("В строке должны быть цифры !!!!", "Коректность", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void TechnRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (TechnRadioButton.Checked)
            {
                type_of_project = "t";
                econom_rat_lbl.Visible = true;
                E_R_CB.Visible = true;
                parts_cb.Visible = true;
                parts_lbl.Visible = true;
                qual_lbl.Visible = true;
                Q_r_tb.Visible = true;
                stand_lbl.Visible = true;
                standart_tb.Visible = true;
                techn_task_tb.Visible = true;
                Tecn_task_lbl.Visible = true;

                dem_cb.Visible = false;
                income_lbl.Visible = false;
                income_tb.Visible = false;
                orient_lbl.Visible = false;
                orient_tb.Visible = false;
                comlex_lbl.Visible = false;
                complex_cb.Visible = false;
            }
        }

        private void EconomicRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (EconomicRadioButton.Checked)
            {
                type_of_project = "e";
                econom_rat_lbl.Visible = false;
                E_R_CB.Visible = false;
                parts_cb.Visible = false;
                parts_lbl.Visible = false;
                qual_lbl.Visible = false;
                Q_r_tb.Visible = false;
                stand_lbl.Visible = false;
                standart_tb.Visible = false;
                techn_task_tb.Visible = false;
                Tecn_task_lbl.Visible = false;

                dem_cb.Visible = true;
                income_lbl.Visible = true;
                income_tb.Visible = true;
                orient_lbl.Visible = true;
                orient_tb.Visible = true;
                comlex_lbl.Visible = true;
                complex_cb.Visible = true;
            }
        }

        private void E_R_CB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsDigit(e.KeyChar) && (e.KeyChar != 8)) && !((e.KeyChar == ',')))
            {
                e.KeyChar = '\0';
                MessageBox.Show("В строке должны быть цифры !!!!", "Коректность", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void parts_cb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsDigit(e.KeyChar) && (e.KeyChar != 8)) && !((e.KeyChar == ',')))
            {
                e.KeyChar = '\0';
                MessageBox.Show("В строке должны быть цифры !!!!", "Коректность", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Q_r_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (char.IsDigit(ch) && ch != 8) //Если символ, введенный с клавы - не цифра (IsDigit),
            {
                e.Handled = true; // то событие не обрабатывается. ch!=8 (8 - это Backspace)
                MessageBox.Show("В строке должны быть слова !!!!", "Коректность", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        

    }
}
