using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Databaze_osob
{/// <summary>
 /// class representing a Group and info about it
 /// </summary>
    public class Group
    {
        public int GroupID { get; set; }

        public string GroupName { get; set; }
        public int GroupMark { get; set; }

        public Group(int id, string groupname)
        {

            GroupID = id;
            GroupName = groupname;
        }


        public Group() { }
        public override string ToString()
        {
            return String.Format($"{GroupName} - {GroupID}");
        }


    }






}
