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
        public static List<Project> URL = new List<Project>();
        public static List<Technical_Project> URL_T = new List<Technical_Project>();
        public static List<Econom_Project> URL_E = new List<Econom_Project>();
        public static int CountAll = 0, CountT = 0, CountE = 0;
        Form2 Dialog = new Form2();
        string type_project = "all";
        public static int NRec;
        bool sortasc;
        //bool first = true;
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*if (!first)
            {
                MessageBox.Show("Ошибка. Файл уже открыт!");
                return;
            }
            first = false;*/
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
            CountAll = 0;
            CountT = 0;
            CountE = 0;
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
                Project_All[CountAll].Name = words[1];
                Project_All[CountAll].Client = words[2];

                Project_All[CountAll].StartDate = words[3];
                Project_All[CountAll].EndDate = words[4];

                Project_All[CountAll].Price = Decimal.Parse(words[5]);
                Project_All[CountAll].Realization = Double.Parse(words[6]);
                Project_All[CountAll].Rollback = Double.Parse(words[7]);
                URL.Add(Project_All[CountAll]);
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
                switch (Form2.type_of_project)
                {
                    case "t":
                        URL.RemoveAt((URL.Count)-1);
                        if ((Form2.Buff.possition >= NRec) && (Form2.Buff.possition < 1))
                        {
                            URL.Add(Form2.Buff);
                            URL_T.Add((Technical_Project)Form2.Buff);
                        }
                        else
                        {
                            URL.Insert(Form2.Buff.possition, Form2.Buff);
                            URL_T.Add((Technical_Project)Form2.Buff);
                        }
                        break;
                    case "e": 
                        URL.RemoveAt((URL.Count) - 1);
                        if ((Form2.Buff.possition >= NRec) && (Form2.Buff.possition < 1))
                        {
                            URL.Add(Form2.Buff);
                            URL_E.Add((Econom_Project)Form2.Buff);
                        }
                        else
                        {
                            URL.Insert(Form2.Buff.possition, Form2.Buff);
                            URL_E.Add((Econom_Project)Form2.Buff);
                        }
                        break;
                }
             
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
            try
            {
                int c = dataGridView1.SelectedCells[0].ColumnIndex-1;
                string s = (string)dataGridView1.SelectedCells[0].Value;
                NRec--;
                stText.Text = "Проект удален";
            }
            catch {  }
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
            switch (type_project)
            {
                case "t": SortColumnT(e.ColumnIndex); break;
                case "e": SortColumnE(e.ColumnIndex); break;
                case "all": SortColumnAll(e.ColumnIndex); break;
            }
            stText.Text = "Данные отсортированы";
        }
        public void SortColumnAll(int num)
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
        public void SortColumnT(int num)
        {
            switch (num)
            {
                case 0:
                    try
                    {
                        if (sortasc)
                        {
                            URL_T.Sort(delegate(Technical_Project v1, Technical_Project v2)
                            {
                                return v2.Standart.CompareTo(v1.Standart);
                            });
                            sortasc = false;
                        }
                        else
                        {
                            URL_T.Sort(delegate(Technical_Project v1, Technical_Project v2)
                            {
                                return v1.Standart.CompareTo(v2.Standart);
                            });
                            sortasc = true;
                        }

                        bindingSource1.DataSource = URL_T;
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = bindingSource1;
                    }
                    catch { MessageBox.Show("no sort"); } break;

                case 1:
                    try
                    {
                        if (sortasc)
                        {
                            URL_T.Sort(delegate(Technical_Project v1, Technical_Project v2)
                            {
                                return v2.Techn_Task.CompareTo(v1.Techn_Task);
                            });
                            sortasc = false;
                        }
                        else
                        {
                            URL_T.Sort(delegate(Technical_Project v1, Technical_Project v2)
                            {
                                return v1.Techn_Task.CompareTo(v2.Techn_Task);
                            });
                            sortasc = true;
                        }

                        bindingSource1.DataSource = URL_T;
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = bindingSource1;
                    }
                    catch { MessageBox.Show("no sort"); } break;

                case 2:
                    try
                    {
                        if (sortasc)
                        {
                            URL_T.Sort(delegate(Technical_Project v1, Technical_Project v2)
                            {
                                return v2.Parts.CompareTo(v1.Parts);
                            });
                            sortasc = false;
                        }
                        else
                        {
                            URL_T.Sort(delegate(Technical_Project v1, Technical_Project v2)
                            {
                                return v1.Parts.CompareTo(v2.Parts);
                            });
                            sortasc = true;
                        }

                        bindingSource1.DataSource = URL_T;
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = bindingSource1;
                    }
                    catch { MessageBox.Show("no sort"); } break;

                case 3:
                   try
                    {
                        if (sortasc)
                        {
                            URL_T.Sort(delegate(Technical_Project v1, Technical_Project v2)
                            {
                                return v2.Econom_Rating.CompareTo(v1.Econom_Rating);
                            });
                            sortasc = false;
                        }
                        else
                        {
                            URL_T.Sort(delegate(Technical_Project v1, Technical_Project v2)
                            {
                                return v1.Econom_Rating.CompareTo(v2.Econom_Rating);
                            });
                            sortasc = true;
                        }

                        bindingSource1.DataSource = URL_T;
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = bindingSource1;
                    }
                    catch { MessageBox.Show("no sort"); } break;

                case 4:
                    try
                    {
                        if (sortasc)
                        {
                            URL_T.Sort(delegate(Technical_Project v1, Technical_Project v2)
                            {
                                return v2.Quality_rating.CompareTo(v1.Quality_rating);
                            });
                            sortasc = false;
                        }
                        else
                        {
                            URL_T.Sort(delegate(Technical_Project v1, Technical_Project v2)
                            {
                                return v1.Quality_rating.CompareTo(v2.Quality_rating);
                            });
                            sortasc = true;
                        }

                        bindingSource1.DataSource = URL_T;
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = bindingSource1;
                    }
                    catch { MessageBox.Show("no sort"); } break;

                case 5:
                    try
                    {
                        if (sortasc)
                        {
                            URL_T.Sort(delegate(Technical_Project v1, Technical_Project v2)
                            {
                                return v2.Name.CompareTo(v1.Name);
                            });
                            sortasc = false;
                        }
                        else
                        {
                            URL_T.Sort(delegate(Technical_Project v1, Technical_Project v2)
                            {
                                return v1.Name.CompareTo(v2.Name);
                            });
                            sortasc = true;
                        }

                        bindingSource1.DataSource = URL_T;
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = bindingSource1;
                    }
                    catch { MessageBox.Show("no sort"); } break;

                case 6:
                    try
                    {
                        if (sortasc)
                        {
                            URL_T.Sort(delegate(Technical_Project v1, Technical_Project v2)
                            {
                                return v2.Client.CompareTo(v1.Client);
                            });
                            sortasc = false;
                        }
                        else
                        {
                            URL_T.Sort(delegate(Technical_Project v1, Technical_Project v2)
                            {
                                return v1.Client.CompareTo(v2.Client);
                            });
                            sortasc = true;
                        }

                        bindingSource1.DataSource = URL_T;
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = bindingSource1;
                    }
                    catch { MessageBox.Show("no sort"); } break;
                case 7:
                    try
                    {
                        if (sortasc)
                        {
                            URL_T.Sort(delegate(Technical_Project v1, Technical_Project v2)
                            {
                                return v2.StartDate.CompareTo(v1.StartDate);
                            });
                            sortasc = false;
                        }
                        else
                        {
                            URL_T.Sort(delegate(Technical_Project v1, Technical_Project v2)
                            {
                                return v1.StartDate.CompareTo(v2.StartDate);
                            });
                            sortasc = true;
                        }

                        bindingSource1.DataSource = URL_T;
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = bindingSource1;
                    }
                    catch { MessageBox.Show("no sort"); } break;
                case 8:
                    try
                    {
                        if (sortasc)
                        {
                            URL_T.Sort(delegate(Technical_Project v1, Technical_Project v2)
                            {
                                return v2.EndDate.CompareTo(v1.EndDate);
                            });
                            sortasc = false;
                        }
                        else
                        {
                            URL_T.Sort(delegate(Technical_Project v1, Technical_Project v2)
                            {
                                return v1.EndDate.CompareTo(v2.EndDate);
                            });
                            sortasc = true;
                        }

                        bindingSource1.DataSource = URL_T;
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = bindingSource1;
                    }
                    catch { MessageBox.Show("no sort"); } break;
                case 9:
                    try
                    {
                        if (sortasc)
                        {
                            URL_T.Sort(delegate(Technical_Project v1, Technical_Project v2)
                            {
                                return v2.Price.CompareTo(v1.Price);
                            });
                            sortasc = false;
                        }
                        else
                        {
                            URL_T.Sort(delegate(Technical_Project v1, Technical_Project v2)
                            {
                                return v1.Price.CompareTo(v2.Price);
                            });
                            sortasc = true;
                        }

                        bindingSource1.DataSource = URL_T;
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = bindingSource1;
                    }
                    catch { MessageBox.Show("no sort"); } break;
                case 10:
                    try
                    {
                        if (sortasc)
                        {
                            URL_T.Sort(delegate(Technical_Project v1, Technical_Project v2)
                            {
                                return v2.Realization.CompareTo(v1.Realization);
                            });
                            sortasc = false;
                        }
                        else
                        {
                            URL_T.Sort(delegate(Technical_Project v1, Technical_Project v2)
                            {
                                return v1.Realization.CompareTo(v2.Realization);
                            });
                            sortasc = true;
                        }

                        bindingSource1.DataSource = URL_T;
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = bindingSource1;
                    }
                    catch { MessageBox.Show("no sort"); } break;
                case 11:
                    try
                    {
                        if (sortasc)
                        {
                            URL_T.Sort(delegate(Technical_Project v1, Technical_Project v2)
                            {
                                return v2.Rollback.CompareTo(v1.Rollback);
                            });
                            sortasc = false;
                        }
                        else
                        {
                            URL_T.Sort(delegate(Technical_Project v1, Technical_Project v2)
                            {
                                return v1.Rollback.CompareTo(v2.Rollback);
                            });
                            sortasc = true;
                        }

                        bindingSource1.DataSource = URL_T;
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = bindingSource1;
                    }
                    catch { MessageBox.Show("no sort"); } break;
            }
        }
        public void SortColumnE(int num)
        {
            switch (num)
            {
                
                case 1:
                    try
                    {
                        if (sortasc)
                        {
                            URL_E.Sort(delegate(Econom_Project v1, Econom_Project v2)
                            {
                                return v2.Orientation.CompareTo(v1.Orientation);
                            });
                            sortasc = false;
                        }
                        else
                        {
                            URL_E.Sort(delegate(Econom_Project v1, Econom_Project v2)
                            {
                                return v1.Orientation.CompareTo(v2.Orientation);
                            });
                            sortasc = true;
                        }

                        bindingSource1.DataSource = URL_E;
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = bindingSource1;
                    }
                    catch { MessageBox.Show("no sort"); } break;

                case 2:
                    try
                    {
                        if (sortasc)
                        {
                            URL_E.Sort(delegate(Econom_Project v1, Econom_Project v2)
                            {
                                return v2.Project_Complexity.CompareTo(v1.Project_Complexity);
                            });
                            sortasc = false;
                        }
                        else
                        {
                            URL_E.Sort(delegate(Econom_Project v1, Econom_Project v2)
                            {
                                return v1.Project_Complexity.CompareTo(v2.Project_Complexity);
                            });
                            sortasc = true;
                        }

                        bindingSource1.DataSource = URL_E;
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = bindingSource1;
                    }
                    catch { MessageBox.Show("no sort"); } break;

                case 3:
                    try
                    {
                        if (sortasc)
                        {
                            URL_E.Sort(delegate(Econom_Project v1, Econom_Project v2)
                            {
                                return v2.Income.CompareTo(v1.Income);
                            });
                            sortasc = false;
                        }
                        else
                        {
                            URL_E.Sort(delegate(Econom_Project v1, Econom_Project v2)
                            {
                                return v1.Income.CompareTo(v2.Income);
                            });
                            sortasc = true;
                        }

                        bindingSource1.DataSource = URL_E;
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = bindingSource1;
                    }
                    catch { MessageBox.Show("no sort"); } break;

                case 4:
                    try
                    {
                        if (sortasc)
                        {
                            URL_E.Sort(delegate(Econom_Project v1, Econom_Project v2)
                            {
                                return v2.Name.CompareTo(v1.Name);
                            });
                            sortasc = false;
                        }
                        else
                        {
                            URL_E.Sort(delegate(Econom_Project v1, Econom_Project v2)
                            {
                                return v1.Name.CompareTo(v2.Name);
                            });
                            sortasc = true;
                        }

                        bindingSource1.DataSource = URL_E;
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = bindingSource1;
                    }
                    catch { MessageBox.Show("no sort"); } break;

                case 5:
                    try
                    {
                        if (sortasc)
                        {
                            URL_E.Sort(delegate(Econom_Project v1, Econom_Project v2)
                            {
                                return v2.Client.CompareTo(v1.Client);
                            });
                            sortasc = false;
                        }
                        else
                        {
                            URL_E.Sort(delegate(Econom_Project v1, Econom_Project v2)
                            {
                                return v1.Client.CompareTo(v2.Client);
                            });
                            sortasc = true;
                        }

                        bindingSource1.DataSource = URL_E;
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = bindingSource1;
                    }
                    catch { MessageBox.Show("no sort"); } break;
                case 6:
                    try
                    {
                        if (sortasc)
                        {
                            URL_E.Sort(delegate(Econom_Project v1, Econom_Project v2)
                            {
                                return v2.StartDate.CompareTo(v1.StartDate);
                            });
                            sortasc = false;
                        }
                        else
                        {
                            URL_E.Sort(delegate(Econom_Project v1, Econom_Project v2)
                            {
                                return v1.StartDate.CompareTo(v2.StartDate);
                            });
                            sortasc = true;
                        }

                        bindingSource1.DataSource = URL_E;
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = bindingSource1;
                    }
                    catch { MessageBox.Show("no sort"); } break;
                case 7:
                    try
                    {
                        if (sortasc)
                        {
                            URL_E.Sort(delegate(Econom_Project v1, Econom_Project v2)
                            {
                                return v2.EndDate.CompareTo(v1.EndDate);
                            });
                            sortasc = false;
                        }
                        else
                        {
                            URL_E.Sort(delegate(Econom_Project v1, Econom_Project v2)
                            {
                                return v1.EndDate.CompareTo(v2.EndDate);
                            });
                            sortasc = true;
                        }

                        bindingSource1.DataSource = URL_E;
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = bindingSource1;
                    }
                    catch { MessageBox.Show("no sort"); } break;
                case 8:
                    try
                    {
                        if (sortasc)
                        {
                            URL_E.Sort(delegate(Econom_Project v1, Econom_Project v2)
                            {
                                return v2.Price.CompareTo(v1.Price);
                            });
                            sortasc = false;
                        }
                        else
                        {
                            URL_E.Sort(delegate(Econom_Project v1, Econom_Project v2)
                            {
                                return v1.Price.CompareTo(v2.Price);
                            });
                            sortasc = true;
                        }

                        bindingSource1.DataSource = URL_E;
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = bindingSource1;
                    }
                    catch { MessageBox.Show("no sort"); } break;
                case 9:
                    try
                    {
                        if (sortasc)
                        {
                            URL_E.Sort(delegate(Econom_Project v1, Econom_Project v2)
                            {
                                return v2.Realization.CompareTo(v1.Realization);
                            });
                            sortasc = false;
                        }
                        else
                        {
                            URL_E.Sort(delegate(Econom_Project v1, Econom_Project v2)
                            {
                                return v1.Realization.CompareTo(v2.Realization);
                            });
                            sortasc = true;
                        }

                        bindingSource1.DataSource = URL_E;
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = bindingSource1;
                    }
                    catch { MessageBox.Show("no sort"); } break;
                case 10:
                    try
                    {
                        if (sortasc)
                        {
                            URL_E.Sort(delegate(Econom_Project v1, Econom_Project v2)
                            {
                                return v2.Rollback.CompareTo(v1.Rollback);
                            });
                            sortasc = false;
                        }
                        else
                        {
                            URL_E.Sort(delegate(Econom_Project v1, Econom_Project v2)
                            {
                                return v1.Rollback.CompareTo(v2.Rollback);
                            });
                            sortasc = true;
                        }

                        bindingSource1.DataSource = URL_E;
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = bindingSource1;
                    }
                    catch { MessageBox.Show("no sort"); } break;
            }
        }
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NRec = 0;

            URL.Clear();
            URL_E.Clear();
            URL_T.Clear();
            bindingSource1.DataSource = null;
            dataGridView1.DataSource = null;

        }

        private void technicalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingSource1.DataSource = null;
            dataGridView1.DataSource = null;
            bindingSource1.DataSource = URL_T;
            dataGridView1.DataSource = bindingSource1;
            type_project = "t";
        }

        private void economicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingSource1.DataSource = null;
            dataGridView1.DataSource = null;
            bindingSource1.DataSource = URL_E;
            dataGridView1.DataSource = bindingSource1;
            type_project = "e";
        }

        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingSource1.DataSource = null;
            dataGridView1.DataSource = null;
            bindingSource1.DataSource = URL;
            dataGridView1.DataSource = bindingSource1;
            type_project = "all";
            
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb = (TextBox)e.Control;
            
            switch (type_project)
            {
                case "t": 
                    {
                        switch (dataGridView1.SelectedCells[0].ColumnIndex)
                        {
                            case 0: tb.KeyPress += new KeyPressEventHandler(tb_KeyPress); break;
                            case 1: tb.KeyPress += new KeyPressEventHandler(tb_KeyPress); break;
                            case 5: tb.KeyPress += new KeyPressEventHandler(tb_KeyPress); break;
                            case 6: tb.KeyPress += new KeyPressEventHandler(tb_KeyPress); break;
                            case 2: tb.KeyPress += new KeyPressEventHandler(tb_KeyPress2); break;
                            case 3: tb.KeyPress += new KeyPressEventHandler(tb_KeyPress2); break;
                            case 9: tb.KeyPress += new KeyPressEventHandler(tb_KeyPress2); break;
                            case 10: tb.KeyPress += new KeyPressEventHandler(tb_KeyPress2); break;
                            case 11: tb.KeyPress += new KeyPressEventHandler(tb_KeyPress2); break;
                            case 4: break;
                            case 7: break;
                            case 8: break;
                        }
                        break; 
                    }
                case "e":
                    {
                        switch (dataGridView1.SelectedCells[0].ColumnIndex)
                        {
                            case 1: tb.KeyPress += new KeyPressEventHandler(tb_KeyPress); break;
                            case 4: tb.KeyPress += new KeyPressEventHandler(tb_KeyPress); break;
                            case 5: tb.KeyPress += new KeyPressEventHandler(tb_KeyPress); break;
                            case 8: tb.KeyPress += new KeyPressEventHandler(tb_KeyPress); break;
                            case 9: tb.KeyPress += new KeyPressEventHandler(tb_KeyPress); break;
                            case 10: tb.KeyPress += new KeyPressEventHandler(tb_KeyPress); break;
                            case 2: tb.KeyPress += new KeyPressEventHandler(tb_KeyPress2); break;
                            case 3: tb.KeyPress += new KeyPressEventHandler(tb_KeyPress2); break;
                            case 6: break;
                            case 7: break;
                        }
                        break;
                    }
                case "all":
                    {
                        switch (dataGridView1.SelectedCells[0].ColumnIndex)
                        {
                            case 0: tb.KeyPress += new KeyPressEventHandler(tb_KeyPress); break;
                            case 1: tb.KeyPress += new KeyPressEventHandler(tb_KeyPress);  break;    
                            case 2:
                            case 3: break;
                            case 4: tb.KeyPress += new KeyPressEventHandler(tb_KeyPress2); break;
                            case 5: tb.KeyPress += new KeyPressEventHandler(tb_KeyPress2); break;
                            case 6: tb.KeyPress += new KeyPressEventHandler(tb_KeyPress2);break;
                            
                        }
                        break;
                    }
            }
            tb.Text = "";
            
        }
        private void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            string vlCell = ((TextBox)sender).Text;
            bool temp = (vlCell.IndexOf(".") == -1);


            if (!char.IsLetter(e.KeyChar) && (e.KeyChar != 8) && !char.IsWhiteSpace(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '\0'))
                {
                    e.Handled = true;
                    e.KeyChar = '\0';
                    MessageBox.Show("В строке должны быть слова !!!!", "Коректность", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            

        }
        private void tb_KeyPress2(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsDigit(e.KeyChar) && (e.KeyChar != 8)) && !((e.KeyChar == ',')) && (e.KeyChar != '\0'))
            {
                e.KeyChar = '\0';
                MessageBox.Show("В строке должны быть цифры !!!!", "Коректность", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

       

   
    }
}
