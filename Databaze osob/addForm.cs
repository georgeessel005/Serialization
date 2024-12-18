using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

using Microsoft.VisualBasic.FileIO;

namespace Databaze_osob
{
    /// <summary>
    /// form to add a person
    /// </summary>
    public partial class addForm : Form
    {

        Database database;
        Student student;
        Group grp;
        public addForm(Database database)
        {
            InitializeComponent();
            this.database = database;
        }


        // button to save a new student
        private void saveButton_Click(object sender, EventArgs e)
        {

            try
            {
                //creates a Student from the entered data
                Student student = new Student(
                int.Parse(textBox1.Text),
                firstnameTextBox.Text,
                lastnameTextBox.Text,
                textBox2.Text,
                int.Parse(textBox3.Text)
             );

                //adds the Student to the database
                database.AddStudent(student);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving the person. Error: {ex.Message}");
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void datumTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btbrowse_Click(object sender, EventArgs e)
        {

        }

        private void btbrowse_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new()
            {
                // To list only csv files, we need to add this filter
                Filter = "|*.csv"
            };
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                csvPath.Text = openFileDialog.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                csvGridView.DataSource = GetDataTableFromCSVFile(csvPath.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Import CSV File", MessageBoxButtons.OK,
  MessageBoxIcon.Error);
            }
        }
        private static DataTable GetDataTableFromCSVFile(string csvfilePath)
        {
            DataTable csvData = new();
            using (TextFieldParser csvReader = new(csvfilePath))
            {
                csvReader.SetDelimiters(new string[] { "," });
                csvReader.HasFieldsEnclosedInQuotes = true;

                //Read columns from CSV file, remove this line if columns not exits  
                string[] colFields = csvReader.ReadFields();

                for (int i = 0; i < colFields.Length; i++)
                {
                    string column = colFields[i];
                    DataColumn datecolumn = new(column)
                    {
                        AllowDBNull = true
                    };
                    csvData.Columns.Add(datecolumn);
                }

                while (!csvReader.EndOfData)
                {
                    string[] fieldData = csvReader.ReadFields();
                    //Making empty value as null

                    if (fieldData is not null)
                    {
                        for (int i = 0; i < fieldData.Length; i++)
                        {
                            if (fieldData[i] == "")
                            {
                                fieldData[i] = null;
                            }
                        }
                        csvData.Rows.Add(fieldData);
                    }
                }
            }
            return csvData;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtItem = (DataTable)(csvGridView.DataSource);
                string ID, First_Name, Last_Name, Email;
                int Group_id = 0;
                string InsertItemQry = "";
                int count = 0;
                foreach (DataRow dr in dtItem.Rows)
                {
                    ID = Convert.ToString(dr["ID"]);
                    First_Name = Convert.ToString(dr["FirstName"]);
                    Last_Name = Convert.ToString(dr["LastName"]);
                    Email = Convert.ToString(dr["Email"]);
                    if (ID != "" && First_Name != "" && Last_Name != "" && Email != "")
                    {
                        try
                        {
                            Student student = new Student(
                            int.Parse(ID),
                            First_Name,
                            Last_Name,
                            Email,
                            Group_id
                         );

                            //Add student(s) to database
                            database.AddStudent(student);
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex);
            }
        }

        private void lastnameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void addForm_Load(object sender, EventArgs e)
        {

        }

    }
}
