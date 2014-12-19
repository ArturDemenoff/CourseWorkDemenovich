using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
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

        public Form1()
        {
            
            InitializeComponent();
            //dataGridView1.Columns[4] as DataGridViewComboBoxColumn;
          //  DataGridViewComboBoxColumn qwer = new DataGridViewComboBoxColumn();
            
            dataGridView1.BackgroundColor = ColorTranslator.FromHtml("#454545");
            label1.Font = task.GetFont(25, "Cool.ttf");
            Add.BackColor = ColorTranslator.FromHtml("#f2f2f2");
            dataGridView1.DataSource = task.TasksList;

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void Add_Click(object sender, EventArgs e)
        {
            New_Task a = new New_Task(this);
            a.Show();
        }
        List<Task> result = new List<Task>();
        private void Search_Click(object sender, EventArgs e)
        {
            if(!result_cb.Checked)
            {
                result = task.TasksList;
            }
            if(Title_TB.Text != string.Empty)
            {
                result = task.Search(result, Title_TB.Text);
                dataGridView2.DataSource = result;
            }
            if(Perfomer_TB.Text != string.Empty)
            {
                result = task.Search(result, Perfomer_TB.Text);
                dataGridView2.DataSource = result;
            }
            if(Tags_LB.SelectedIndex != -1)
            {
                result = task.Search(result, Tags_LB.SelectedItem.ToString());
                dataGridView2.DataSource = result;
            }

            
            


        }

        private void Remove_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = task.TasksList;
            dataGridView1.Refresh();
            int i = dataGridView1.CurrentRow.Index;
            if(i != -1)
            if (task.Remove(i))
            {
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = task.TasksList;                
            }
            

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            New_Task b = new New_Task(this,i);
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
    }
}
