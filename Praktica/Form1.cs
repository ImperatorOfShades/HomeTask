using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections.Concurrent;
using System.Threading;

namespace Praktica
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Project> URL = new List<Project>();
        List<Technical_Project> URL_T = new List<Technical_Project>();
        List<Econom_Project> URL_E = new List<Econom_Project>();
        Form2 Dialog = new Form2();
        public static int NRec;
        bool sortasc;
        bool first = true;
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!first)
            {
                MessageBox.Show("Ошибка. Файл уже открыт!");
                return;
            }
            first = false;
            string[] words;
            OpenFileDialog openFileDlg = new OpenFileDialog();
            openFileDlg.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            StreamReader streamR = new StreamReader(openFileDlg.OpenFile());
            if (streamR == null)
            {
                MessageBox.Show( "Ошибка открытия файла" + openFileDlg.OpenFile());
                return;
            }
            stText.Text = "Файл отрыт";
            sortasc = false;
            NRec = 0;
            String input;
            while ((input = streamR.ReadLine()) != null)
                NRec++;
            streamR.Close();

            this.bindingNavigatorAddNewItem.Enabled = true;
            this.toolStripButton1.Enabled = true;
            Project[] Project_All;
            Technical_Project[] Project_Tech;
            Econom_Project[] Project_Econom;
            Project_All = new Project[NRec];
            Project_Tech = new Technical_Project[NRec];
            Project_Econom = new Econom_Project[NRec];
            for (int t = 0; t < NRec; t++)
            {
                Project_All[t] = new Project();
                Project_Tech[t] = new Technical_Project();
                Project_Econom[t] = new Econom_Project();
            }
            
            //Data d1 = new Data();
            //Data d2 = new Data();
            words = new string[20];
            streamR = new StreamReader(openFileDlg.OpenFile());
            string type_project;
            int CountAll = 0, CountT = 0, CountE = 0;
            while ((input = streamR.ReadLine()) != null)
            {
                string [] split = input.Split(new Char [] {'\t'});
                int i = 0;
                foreach(string s in split)
                {
                    if(s.Trim() != "")
                        words[i] = s;
                    i++;
                }

                type_project = words[0];
                Project_Tech[CountT].Name = words[1];
                Project_Tech[CountT].Client = words[2];

                Project_Tech[CountT].StartDate = words[3];
                Project_Tech[CountT].EndDate = words[4];

                Project_Tech[CountT].Price =  Decimal.Parse(words[5]);
                Project_Tech[CountT].Realization = Double.Parse(words[6]);
                Project_Tech[CountT].Rollback = Double.Parse(words[7]);
                URL.Add(Project_Tech[CountT]);
                CountAll++;
 
                switch (type_project)
                {
                    case "t":
                        {
                            Project_Tech[CountT].Name = words[1];
                            Project_Tech[CountT].Client = words[2];

                            Project_Tech[CountT].StartDate = words[3];
                            Project_Tech[CountT].EndDate = words[4];

                            Project_Tech[CountT].Price =  Decimal.Parse(words[5]);
                            Project_Tech[CountT].Realization = Double.Parse(words[6]);
                            Project_Tech[CountT].Rollback = Double.Parse(words[7]);
                            Project_Tech[CountT].Econom_Rating = Decimal.Parse(words[8]);
                            Project_Tech[CountT].Quality_rating = words[9];
                            Project_Tech[CountT].Standart = words[10];
                            Project_Tech[CountT].Techn_Task = words[11];
                            Project_Tech[CountT].Parts = Int32.Parse(words[12]);
                            
                            URL_T.Add(Project_Tech[CountT]);
                            CountT++;
                            break;
                        }
                    case "e":
                        {
                            Project_Econom[CountE].Name = words[1];
                            Project_Econom[CountE].Client = words[2];

                            Project_Econom[CountE].StartDate = words[3];
                            Project_Econom[CountE].EndDate = words[4];

                            Project_Econom[CountE].Price = Decimal.Parse(words[5]);
                            Project_Econom[CountE].Realization = Double.Parse(words[6]);
                            Project_Econom[CountE].Rollback = Double.Parse(words[7]);
                            Project_Econom[CountE].Demand = Boolean.Parse(words[8]);
                            Project_Econom[CountE].Orientation = words[9];
                            Project_Econom[CountE].Project_Complexity = Int32.Parse(words[10]);
                            Project_Econom[CountE].Income = Decimal.Parse(words[11]);

                            URL_E.Add(Project_Econom[CountE]);
                            CountE++;
                            break;
                        } 
                }
                

                
            }
            bindingSource1.DataSource = null;
            dataGridView1.DataSource = null;
            bindingSource1.DataSource = URL;
            dataGridView1.DataSource = bindingSource1;

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            
                Dialog.ShowDialog();
          
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            if (Form2.Buff.adding)
            {
                URL.RemoveAt((URL.Count)-1);
                if ((Form2.Buff.possition >= NRec) && (Form2.Buff.possition < 1))
                    URL.Add(Form2.Buff);
                else
                    URL.Insert(Form2.Buff.possition, Form2.Buff);
                
                NRec++;
                stText.Text = "Проект добавлен";
                Form2.Buff.adding = false;
                Dialog.Hide();
            }
            bindingSource1.DataSource = null;
            bindingSource1.DataSource = URL;
            dataGridView1.DataSource = bindingSource1;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Dialog.ShowDialog();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveAsFDlg = new SaveFileDialog();
            StreamWriter streamWriter;
            SaveAsFDlg.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if(SaveAsFDlg.ShowDialog()!= System.Windows.Forms.DialogResult.OK)
                return;
            streamWriter = new StreamWriter(SaveAsFDlg.OpenFile());
            if(streamWriter == null)
            {
                MessageBox.Show( "Ошибка открытия файла");
                return;
            }
            String OutStr;
            for(int i = 0; i < NRec; i++)
            {
                OutStr = URL[i].Name + "\t" + URL[i].Client + "\t" + URL[i].StartDate + "\t" + URL[i].EndDate + "\t"
                    + URL[i].Price + "\t" + URL[i].Realization + "\t" + URL[i].Rollback; 
                streamWriter.WriteLine(OutStr,Encoding.Default);
            }
            streamWriter.Close();
            stText.Text = "Файл успешо сохранен";
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            NRec--;
            stText.Text = "Проект удален";
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigatorDeleteItem.PerformClick() ;
        }

        private void findTB_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = false;
                for (int t = 0; t < dataGridView1.ColumnCount; t++)
                {
                    if (dataGridView1.Rows[i].Cells[t].Value != null)
                    {
                        if (dataGridView1.Rows[i].Cells[t].Value.ToString().Contains(findTB.Text))
                        {
                            if (findTB.Text == "")
                                dataGridView1.Rows[i].Selected = false;
                            else
                            {
                                dataGridView1.Rows[i].Selected = true;
                                stText.Text = "Проект найден";
                                
                            }
                            break;
                        }
                    }
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            SortColumn(e.ColumnIndex);
            stText.Text = "Данные отсортированы";
        }
        public void SortColumn(int num)
        {
            switch (num)
            {
                case 0:
                    try
                    {
                        if (sortasc)
                        {
                            URL.Sort(delegate(Project v1, Project v2)
                            {
                                return v2.Name.CompareTo(v1.Name);
                            });
                            sortasc = false;
                        }
                        else
                        {
                            URL.Sort(delegate(Project v1, Project v2)
                            {
                                return v1.Name.CompareTo(v2.Name);
                            });
                            sortasc = true;
                        }

                        bindingSource1.DataSource = URL;
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = bindingSource1;
                    }
                    catch { MessageBox.Show("no sort"); } break;

                case 1:
                    try
                    {
                        if (sortasc)
                        {
                            URL.Sort(delegate(Project v1, Project v2)
                            {
                                return v2.Client.CompareTo(v1.Client);
                            });
                            sortasc = false;
                        }
                        else
                        {
                            URL.Sort(delegate(Project v1, Project v2)
                            {
                                return v1.Client.CompareTo(v2.Client);
                            });
                            sortasc = true;
                        }

                        bindingSource1.DataSource = URL;
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = bindingSource1;
                    }
                    catch { MessageBox.Show("no sort"); } break;

                case 2:
                    try
                    {
                        if (sortasc)
                        {
                            URL.Sort(delegate(Project v1, Project v2)
                            {
                                return v2.StartDate.CompareTo(v1.StartDate);
                            });
                            sortasc = false;
                        }
                        else
                        {
                            URL.Sort(delegate(Project v1, Project v2)
                            {
                                return v1.StartDate.CompareTo(v2.StartDate);
                            });
                            sortasc = true;
                        }

                        bindingSource1.DataSource = URL;
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = bindingSource1;
                    }
                    catch { MessageBox.Show("no sort"); } break;

                case 3:
                    try
                    {
                        if (sortasc)
                        {
                            URL.Sort(delegate(Project v1, Project v2)
                            {
                                return v2.EndDate.CompareTo(v1.EndDate);
                            });
                            sortasc = false;
                        }
                        else
                        {
                            URL.Sort(delegate(Project v1, Project v2)
                            {
                                return v1.EndDate.CompareTo(v2.EndDate);
                            });
                            sortasc = true;
                        }

                        bindingSource1.DataSource = URL;
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = bindingSource1;
                    }
                    catch { MessageBox.Show("no sort"); } break;

                case 4:
                    try
                    {
                        if (sortasc)
                        {
                            URL.Sort(delegate(Project v1, Project v2)
                            {
                                return v2.Price.CompareTo(v1.Price);
                            });
                            sortasc = false;
                        }
                        else
                        {
                            URL.Sort(delegate(Project v1, Project v2)
                            {
                                return v1.Price.CompareTo(v2.Price);
                            });
                            sortasc = true;
                        }

                        bindingSource1.DataSource = URL;
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = bindingSource1;
                    }
                    catch { MessageBox.Show("no sort"); } break;

                case 5:
                    try
                    {
                        if (sortasc)
                        {
                            URL.Sort(delegate(Project v1, Project v2)
                            {
                                return v2.Realization.CompareTo(v1.Realization);
                            });
                            sortasc = false;
                        }
                        else
                        {
                            URL.Sort(delegate(Project v1, Project v2)
                            {
                                return v1.Realization.CompareTo(v2.Realization);
                            });
                            sortasc = true;
                        }

                        bindingSource1.DataSource = URL;
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = bindingSource1;
                    }
                    catch { MessageBox.Show("no sort"); } break;

                case 6:
                    try
                    {
                        if (sortasc)
                        {
                            URL.Sort(delegate(Project v1, Project v2)
                            {
                                return v2.Rollback.CompareTo(v1.Rollback);
                            });
                            sortasc = false;
                        }
                        else
                        {
                            URL.Sort(delegate(Project v1, Project v2)
                            {
                                return v1.Rollback.CompareTo(v2.Rollback);
                            });
                            sortasc = true;
                        }

                        bindingSource1.DataSource = URL;
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = bindingSource1;
                    }
                    catch { MessageBox.Show("no sort"); } break;
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NRec = 0;
            first = true;

            URL.Clear();
            bindingSource1.DataSource = null;
            dataGridView1.DataSource = null;

        }

        private void technicalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingSource1.DataSource = null;
            dataGridView1.DataSource = null;
            bindingSource1.DataSource = URL_T;
            dataGridView1.DataSource = bindingSource1;
        }

        private void economicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingSource1.DataSource = null;
            dataGridView1.DataSource = null;
            bindingSource1.DataSource = URL_E;
            dataGridView1.DataSource = bindingSource1;
        }

        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingSource1.DataSource = null;
            dataGridView1.DataSource = null;
            bindingSource1.DataSource = URL;
            dataGridView1.DataSource = bindingSource1;
        }

       

   
    }
}
