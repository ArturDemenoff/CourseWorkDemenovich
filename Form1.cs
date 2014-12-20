using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskManager
{
    public partial class Form1 : Form
    {
        public TaskManager task = new TaskManager();
        List<Task> result = new List<Task>();

        public Form1()
        {

            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#454545");
            label1.Font = task.GetFont(25, "Cool.ttf");
            label1.ForeColor = ColorTranslator.FromHtml("#87BDFF");
            result_cb.ForeColor = ColorTranslator.FromHtml("#87BDFF");

            foreach (Control x in tabControl1.Controls)
            {
                if (x is TabPage)
                {
                    foreach (Control y in x.Controls)
                    {
                        if(y is Label)
                            ((Label)y).ForeColor = ColorTranslator.FromHtml("#87BDFF");
                        if (y is Button)
                            ((Button)y).BackColor = ColorTranslator.FromHtml("#87BDFF");
                        if (y is DataGridView)
                            ((DataGridView)y).BackgroundColor = ColorTranslator.FromHtml("#fff");
                    }
                    ((TabPage)x).BackColor = ColorTranslator.FromHtml("#454545");
                }
            }

           
            dataGridView1.DataSource = task.TasksList;
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Add_Click(object sender, EventArgs e)
        {
            New_Task a = new New_Task(this);
            a.Show();
        }
        private void Search_Click(object sender, EventArgs e)
        {
            if (!result_cb.Checked)
            {
                result = task.TasksList;
            }
            if (Title_TB.Text != string.Empty)
            {
                result = task.Search(result, Title_TB.Text);
                dataGridView2.DataSource = result;
            }
            if (Perfomer_TB.Text != string.Empty)
            {
                result = task.Search(result, Perfomer_TB.Text);
                dataGridView2.DataSource = result;
            }
            if (Tags_LB.SelectedIndex != -1)
            {
                result = task.Search(result, Tags_LB.SelectedItem.ToString());
                dataGridView2.DataSource = result;
            }
            if (Title_TB.Text != string.Empty && Perfomer_TB.Text != string.Empty)
            {
                result = task.Search(result, Title_TB.Text, Perfomer_TB.Text);
                dataGridView2.DataSource = result;
            }
            if (Title_TB.Text != string.Empty && Tags_LB.SelectedIndex != -1)
            {
                result = task.Search(result, Title_TB.Text, Tags_LB.SelectedItem.ToString());
                dataGridView2.DataSource = result;
            }
            if (Perfomer_TB.Text != string.Empty && Tags_LB.SelectedIndex != -1)
            {
                result = task.Search(result, Perfomer_TB.Text, Tags_LB.SelectedItem.ToString());
                dataGridView2.DataSource = result;
            }
            if (dateTimePicker1.Checked)
            {
                result = task.Search(result, dateTimePicker1.Value.ToShortDateString());
                dataGridView2.DataSource = result;
            }
            if (dateTimePicker1.Checked == true && Tags_LB.SelectedIndex != -1)
            {
                result = task.Search(result, dateTimePicker1.Value.ToShortDateString(), Tags_LB.SelectedItem.ToString());
                dataGridView2.DataSource = result;
            }
            if (dateTimePicker1.Checked == true && Perfomer_TB.Text != string.Empty)
            {
                result = task.Search(result, dateTimePicker1.Value.ToShortDateString(), Perfomer_TB.Text);
                dataGridView2.DataSource = result;
            }
            if (dateTimePicker1.Checked == true && Title_TB.Text != string.Empty)
            {
                result = task.Search(result, dateTimePicker1.Value.ToShortDateString(), Title_TB.Text);
                dataGridView2.DataSource = result;
            }
            Title_TB.Text = string.Empty;
            Perfomer_TB.Text = string.Empty;
            Tags_LB.ClearSelected();
            task.ColorRows(dataGridView2, task.TasksList);
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = task.TasksList;
            dataGridView1.Refresh();

            int i = dataGridView1.CurrentRow.Index;

            if (i != -1)
            {
                if (task.Remove(i))
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = task.TasksList;
                }
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            New_Task b = new New_Task(this, i);
            b.Show();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            task.Save(task.TasksList, "save.xml");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            task.Load("save.xml");
            dataGridView1.DataSource = task.TasksList;
            task.ColorRows(dataGridView1, task.TasksList);
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Tags_LB.Items.Clear();
            if (tabControl1.SelectedIndex == 1)
                foreach (var a in task.TasksList)
                {
                    string pattern = @"(\#\w+)";

                    MatchCollection matches = Regex.Matches(a.Description, pattern, RegexOptions.IgnoreCase);

                    foreach (Match match in matches)
                    {
                        Tags_LB.Items.Add(match.Groups[1].Value);
                    }
                }
        }

        private void Save_BTN_Click(object sender, EventArgs e)
        {
            dataGridView3.DataSource = result;
            task.ColorRows(dataGridView3, result);
            tabControl1.SelectedIndex = 2;
        }

        private void Add_BTN_Click(object sender, EventArgs e)
        {
            New_Task a = new New_Task(this);
            a.Show();
        }

        private void SaveBTN_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                {
                    foreach (var a in result)
                        sw.WriteLine(a.ToString());
                }
            }
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int i = e.ColumnIndex;
            if (i == 0)
            {
                task.TasksList.Sort(delegate(Task obj1, Task obj2)
                {
                    return obj1.Date.CompareTo(obj2.Date);
                });
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = task.TasksList;
            }
            if (i == 1)
            {
                task.TasksList.Sort(delegate(Task obj1, Task obj2)
                {
                    return obj1.Title.CompareTo(obj2.Title);
                });
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = task.TasksList;
            }
            if (i == 2)
            {
                task.TasksList.Sort(delegate(Task obj1, Task obj2)
                {
                    return obj1.Description.CompareTo(obj2.Description);
                });
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = task.TasksList;
            }
            if (i == 3)
            {
                task.TasksList.Sort(delegate(Task obj1, Task obj2)
                {
                    return obj1.Perfomer.CompareTo(obj2.Perfomer);
                });
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = task.TasksList;
            }
            if (i == 4)
            {
                task.TasksList.Sort(delegate(Task obj1, Task obj2)
                {
                    return obj1.Result.CompareTo(obj2.Result);
                });
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = task.TasksList;
            }
            task.ColorRows(dataGridView1, task.TasksList);
        }

        private void dataGridView3_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int i = e.ColumnIndex;
            if (i == 0)
            {
                result.Sort(delegate(Task obj1, Task obj2)
                {
                    return obj1.Date.CompareTo(obj2.Date);
                });
                dataGridView3.DataSource = null;
                dataGridView3.DataSource = result;
            }
            if (i == 1)
            {
                result.Sort(delegate(Task obj1, Task obj2)
                {
                    return obj1.Title.CompareTo(obj2.Title);
                });
                dataGridView3.DataSource = null;
                dataGridView3.DataSource = result;
            }
            if (i == 2)
            {
                result.Sort(delegate(Task obj1, Task obj2)
                {
                    return obj1.Description.CompareTo(obj2.Description);
                });
                dataGridView3.DataSource = null;
                dataGridView3.DataSource = result;
            }
            if (i == 3)
            {
                result.Sort(delegate(Task obj1, Task obj2)
                {
                    return obj1.Perfomer.CompareTo(obj2.Perfomer);
                });
                dataGridView3.DataSource = null;
                dataGridView3.DataSource = result;
            }
            if (i == 4)
            {
                result.Sort(delegate(Task obj1, Task obj2)
                {
                    return obj1.Result.CompareTo(obj2.Result);
                });
                dataGridView3.DataSource = null;
                dataGridView3.DataSource = result;
            }
            task.ColorRows(dataGridView3, result);
        }

        private void dataGridView2_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int i = e.ColumnIndex;
            if (i == 0)
            {
                result.Sort(delegate(Task obj1, Task obj2)
                {
                    return obj1.Date.CompareTo(obj2.Date);
                });
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = result;
            }
            if (i == 1)
            {
                result.Sort(delegate(Task obj1, Task obj2)
                {
                    return obj1.Title.CompareTo(obj2.Title);
                });
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = result;
            }
            if (i == 2)
            {
                result.Sort(delegate(Task obj1, Task obj2)
                {
                    return obj1.Description.CompareTo(obj2.Description);
                });
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = result;
            }
            if (i == 3)
            {
                result.Sort(delegate(Task obj1, Task obj2)
                {
                    return obj1.Perfomer.CompareTo(obj2.Perfomer);
                });
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = result;
            }
            if (i == 4)
            {
                result.Sort(delegate(Task obj1, Task obj2)
                {
                    return obj1.Result.CompareTo(obj2.Result);
                });
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = result;
            }
            task.ColorRows(dataGridView2, result);
        }

        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            New_Task b = new New_Task(this, i);
            b.Show();
        }

        private void dataGridView3_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            New_Task b = new New_Task(this, i);
            b.Show();
        }
    }
}
