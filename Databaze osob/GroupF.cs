using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Databaze_osob
{
    public partial class GroupF : Form
    {
        Database database;
        Student student;
        Group grp;
        editForm editF;
        public GroupF(Database database)
        {
            InitializeComponent();
            this.database = database;
            listBox1.DataSource = database.Data;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            database.Group_Unique(Convert.ToInt32(textBox3.Text), textBox4.Text);
            if (listBox1.SelectedItems.Count > 4)
            {
                MessageBox.Show($"cannot add more than four students");
            }
            else
            {

                foreach (var item in listBox1.SelectedItems)
                {
                    editF = new editForm((Student)item, int.Parse(textBox3.Text));
                }
            }
            Application.Restart();
            Environment.Exit(0);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
