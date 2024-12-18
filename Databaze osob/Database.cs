using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Databaze_osob
{
    /// <summary>
    /// database of persons
    /// </summary>
    [Serializable]
    public class Database
    {

        public List<Student> Data { get; private set; }
        public List<Group> Data1 { get; private set; }

        [XmlIgnore]
        public Student[] FilteredData { get; private set; }
        [XmlIgnore]
        public Group[] FilteredData1 { get; private set; }

        public Database()
        {

            Data = new List<Student>();
            FilteredData = Data.ToArray();
            Data1 = new List<Group>();
            FilteredData1 = Data1.ToArray();

        }



        /// <summary>
        /// adds an instance of the Student class to the database
        /// </summary>
        /// <param name="student"></param>
        public void AddStudent(Student student) => Data.Add(student);
        public void AddStudent1(Group group) => Data1.Add(group);

        /// <summary>
        /// removes the selected Student record from the database
        /// </summary>
        /// <param name="student"></param>
        public void RemoveRecord(Student student) => Data.Remove(student);
        public void RemoveRecord1(Group group) => Data1.Remove(group);



        /// <summary>
        ///  serializes and saves the student database
        /// </summary>
        public void saveRecord()
        {

            XmlSerializer xs = new XmlSerializer(Data.GetType());

            using (StreamWriter sw = new StreamWriter("data.xml"))
            {
                xs.Serialize(sw, Data);


            }
            XmlSerializer xs1 = new XmlSerializer(Data1.GetType());

            using (StreamWriter sw = new StreamWriter("datagroup.xml"))
            {
                xs1.Serialize(sw, Data1);


            }

        }

        /// <summary>
        ///  deserializes and loads the student database
        /// </summary>
        public void getRecord()
        {

            if (File.Exists("data.xml"))
            {
                XmlSerializer xs = new XmlSerializer(Data.GetType());

                using (StreamReader sr = new StreamReader("data.xml"))
                {
                    Data = (List<Student>)xs.Deserialize(sr);


                }
            }
            FilteredData = Data.ToArray();

            if (File.Exists("datagroup.xml"))
            {
                XmlSerializer xs1 = new XmlSerializer(Data1.GetType());

                using (StreamReader sr = new StreamReader("datagroup.xml"))
                {
                    Data1 = (List<Group>)xs1.Deserialize(sr);


                }
            }
            FilteredData1 = Data1.ToArray();
        }



        /// <summary>
        ///  sorts by the selected option
        /// </summary>
        public void sortRecords(int sortby)
        {

            if (sortby == 1)
                Data = Data.OrderBy(a => a.FirstName).ToList();
            if (sortby == 2)
                Data = Data.OrderBy(a => a.LastName).ToList();
            if (sortby == 3)
                Data = Data.OrderBy(a => a.ID).ToList();

        }



        /// <summary>
        /// Filters the data according to the specified parameters
        /// </summary>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <param name="ID"></param>



        /// <summary>
        /// Reset filter
        /// </summary>
        public void ResetFilter()
        {
            FilteredData = Data.ToArray();
            FilteredData = Data.ToArray();

        }
        public void Group_Members(int id)
        {

            List<Student> filtering = FilteredData.ToList();

            filtering = filtering.FindAll(a => (a.Group_ID == id));

            FilteredData = filtering.ToArray();


        }
        public void Group_Unique(int id, string name)
        {

            List<Group> filtering = FilteredData1.ToList();

            foreach (Group group in filtering)
            {
                filtering = filtering.FindAll(a => (a.GroupID == id));
                if (filtering.Count() > 0)
                {
                    MessageBox.Show($"Group Exists");
                    Application.Restart();
                    Environment.Exit(0);
                }
            }
            {
                    try
                    {

                        Group grp = new Group(
                        id,
                        name
                     );

                        AddStudent1(grp);
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error {ex.Message}");
                    }
                    
            }

            //FilteredData1 = filtering.ToArray();


        }
    }
}

