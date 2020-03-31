using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace TheScheduleCalls
{
    public class Schedule
    {
        public List<DateTime> timeCalls = new List<DateTime>();
        public List<String> stringCalls = new List<string>();
        public bool isActive;

        /// <summary>
        /// Парсинг документа XML
        /// </summary>
        /// <param name="path">Путь парсинга</param>
        public void LoadFileXML(string path)
        {
            if (System.IO.File.Exists(path))
            {
                XDocument xDoc = XDocument.Load(path);
                XElement schedule = xDoc.Element("Schedule");

                foreach (XElement xe in schedule.Elements("pair").ToList())
                {
                    stringCalls.Add(xe.Element("start").Value);
                    stringCalls.Add(xe.Element("end").Value);
                }

                ConvertStringToDatetime();
            }
        }


        /// <summary>
        /// Сохранение структурного файла с расписанием
        /// </summary>
        /// <param name="nameFile">Название файла для сохранения</param>
        public void SaveFileXML(string nameFile)
        {
            XDocument xDoc = new XDocument();
            XElement elem = new XElement("Schedule");
            for(int i = 0; i < stringCalls.Count-1; i++)
            {

                XElement pair = new XElement("pair");
                XElement start = new XElement("start", stringCalls[i++]);
                XElement end = new XElement("end", stringCalls[i]);

                pair.Add(start);
                pair.Add(end);
                elem.Add(pair);
            }
            xDoc.Add(elem);
            xDoc.Save(nameFile + ".schedule");
        }

        /// <summary>
        /// Конверт времени в лист Datetime
        /// </summary>
        public void ConvertStringToDatetime()
        {
            for(int i = 0; i < stringCalls.Count; i++)
            {
                char[] time = stringCalls[i].ToCharArray();
                DateTime datetime = new DateTime(
                    DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day,
                    int.Parse(time[0].ToString() + time[1].ToString()),
                    int.Parse(time[3].ToString() + time[4].ToString()),
                    int.Parse(time[6].ToString() + time[7].ToString())
                    );
                timeCalls.Add(datetime);
            }
        }
    }
}
