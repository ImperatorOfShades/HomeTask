public void mysort(int num)
        {
            switch (num)
            {
                case 0:
                    try
                    {
                        if (sortasc)
                        {
                            URL.Sort(delegate(Project v1, Project v2) // хуй знает как работает, но работает
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
                        dataGridView1.DataSource = null; // очищаем таблицу и заполняем заново
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
} //в самом датагридвью сортировать элементы нельзя(у меня не получилось), поэтому сортируем список вручную, в зависимости от того, на какой столбец кликнули 