using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Databaze_osob
{
    public partial class Members : Form
    {
        Database database;
        public Members(Database database, Group group)
        {
            InitializeComponent();
            database.Group_Members(group.GroupID);
            listBox1.DataSource = database.FilteredData;
            label1.Text = group.GroupName;
        }
    }
}
