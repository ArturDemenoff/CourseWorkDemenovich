using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace TaskManager
{
    public class Task : IEquatable<Task>
    {
        [XmlAttribute]
        public string Date { get; set; }
        [XmlAttribute]
        public string LastDate { get; set; }
        [XmlElement]
        public string Title { get; set; }
        [XmlElement]
        public string Description { get; set; }
        [XmlAttribute]
        public string Perfomer { get; set; }
        [XmlAttribute]
        public string Result { get; set; }

        public Task(string date, string lastdate,string title, string description, string perfomer, string result)
        {
            this.Date = date;
            this.LastDate = lastdate;
            this.Title = title;
            this.Description = description;
            this.Perfomer = perfomer;
            this.Result = result;
        }

        public Task()
        {

        }

        public override string ToString()
        {
            return String.Concat(Date, " ", Title, " ", Perfomer, " ", Description, " ", Result, " ", LastDate);
        }

        public bool Equals(Task other)
        {
            if (this.Date == other.Date && this.Description == other.Description && this.Perfomer == other.Perfomer && this.Result == other.Result && this.Title == other.Title && this.LastDate == other.LastDate)
                return true;
            return false;
        }
    }
}
