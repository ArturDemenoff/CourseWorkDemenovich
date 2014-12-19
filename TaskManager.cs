using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TaskManager
{
    public class TaskManager
    {
        public List<Task> TasksList = new List<Task>();

        public bool Remove(int index)
        {
            try
            {
                TasksList.RemoveAt(index);
            }
            catch(IndexOutOfRangeException)
            {
                return false;
            }

            return true;
        }

        public void Save(List<Task> obj,string filepath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Task>));

            using (StreamWriter sw = File.CreateText(filepath))
            {
                serializer.Serialize(sw, obj);
            }
        }

        public void Load(string filepath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Task>));

            using (StreamReader sr = new StreamReader(filepath, Encoding.UTF8))
            {
                string a = (sr.ReadToEnd());
                TextReader reader = new StringReader(a);
                TasksList = (List<Task>)serializer.Deserialize(reader);
            }
        }
        public Font GetFont(int size, string path)
        {
            PrivateFontCollection custom_font = new PrivateFontCollection();
            custom_font.AddFontFile(path);
            Font new_font = new Font(custom_font.Families[0], size, FontStyle.Italic);
            return new_font;
        }

        public List<Task> Search(List<Task> obj, string param)
        {
            List<Task> search = new List<Task>();

            foreach(var a in obj)
            {
                if((a.ToString()).Contains(param))
                {
                    search.Add(a);
                }
            }

            return search;
        }
        public List<Task> Search(List<Task> obj, string param, string param2)
        {
            List<Task> search = new List<Task>();

            foreach (var a in obj)
            {
                if ((a.ToString()).Contains(param) && (a.ToString()).Contains(param2))
                {
                    search.Add(a);
                }
            }

            return search;
        }
    }
}
