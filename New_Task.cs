using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskManager
{
    public partial class New_Task : Form
    {
        private readonly Form1 form;
        public New_Task(Form1 form)
        {
            this.form = form;
            InitializeComponent();
        }

        public New_Task(Form1 form, int i)
        {
            this.form = form;
            InitializeComponent();

            Description_TB.Text = form.task.TasksList[i].Description;
            Perfomer_TB.Text = form.task.TasksList[i].Perfomer;
            Title_TB.Text = form.task.TasksList[i].Title;
            dateTimePicker1.Value = Convert.ToDateTime(form.task.TasksList[i].Date);
            Status_combobox.Text = form.task.TasksList[i].Result;
        }
        private bool Isempty()
        {
            foreach (Control x in this.Controls)
            {
                if (x is TextBox)
                {
                    if (((TextBox)x).Text == string.Empty)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if(Isempty())
            {
                foreach(Control x in this.Controls)
                {
                    if(x is TextBox)
                    {
                        ((TextBox)x).BackColor = Color.Red;
                    }
                }
            }
            else
            {
                Task a = new Task(dateTimePicker1.Value.ToShortDateString(), Title_TB.Text, Description_TB.Text, Perfomer_TB.Text, Status_combobox.SelectedItem.ToString());
                try
                {
                   
                    if (!form.task.TasksList.Contains(a))
                    {
                        form.task.TasksList.Add(a);
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch(Exception)
                {

                }

            }

            form.dataGridView1.DataSource = null;
            form.dataGridView1.DataSource = form.task.TasksList;
            this.Close();

        }
    }
}
