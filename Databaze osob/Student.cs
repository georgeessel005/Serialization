using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Databaze_osob
{/// <summary>
 /// class representing a Student and info
 /// </summary>
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public int ID { get; set; }
        public int Group_ID { get; set; }
        public int StudentMark { get; set; }


        public Student(int id, string firstname, string lastname, string email, int group_id)
        {
            FirstName = firstname;
            LastName = lastname;

            ID = id;
            Email = email;
            Group_ID = group_id;
        }


        public Student() { }//empty constructor for serialization to work
        public override string ToString()
        {
            return String.Format($"{FirstName} {LastName} - {ID}");
        }


    }






}
