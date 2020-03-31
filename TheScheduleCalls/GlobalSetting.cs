using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TheScheduleCalls
{
    class GlobalSetting
    {
        public enum typeSheduleActive { mainSchedule, reducedSchedule, suterdaySchedule};

        //Пути к файлам
        /// <summary>
        /// Путь к главному расписанию
        /// </summary>
        public static string PathMainSchedule { get; set; }
        /// <summary>
        /// Путь к сокращённому расписанию
        /// </summary>
        public static string PathReducedSchedule { get; set; }
        /// <summary>
        /// Путь к субботнему расписанию
        /// </summary>
        public static string PathSaturdaySchedule { get; set; }
        /// <summary>
        /// Путь к звонку на пару и с пары
        /// </summary>
        public static string PathSoundCall { get; set; }
        /// <summary>
        /// Путь к учебной тревоге
        /// </summary>
        public static string PathTrainingAllertCall { get; set; }

        /// <summary>
        /// Активное расписание
        /// </summary>
        //public static typeSheduleActive TypeScheduleActive { get; private set; }

        /// <summary>
        /// Сохранить настройки в файл
        /// </summary>
        public static void SaveSettings()
        {
            XDocument xDoc = new XDocument();
            XElement elem = new XElement("Setting",
                new XElement("PathMainSchedule", PathMainSchedule),
                new XElement("PathReducedSchedule", PathReducedSchedule),
                new XElement("PathSaturdaySchedule", PathSaturdaySchedule), 
                new XElement("PathSoundCall", PathSoundCall),
                new XElement("PathTrainingAllertCall", PathTrainingAllertCall));
            xDoc.Add(elem);
            xDoc.Save("setting.s");
        }

        public static void LoadSetting()
        {
            if (System.IO.File.Exists("setting.s"))
            {
                XDocument xdoc = XDocument.Load("setting.s");
                PathMainSchedule = xdoc.Element("Setting").Element("PathMainSchedule").Value;
                PathReducedSchedule = xdoc.Element("Setting").Element("PathReducedSchedule").Value;
                PathSaturdaySchedule = xdoc.Element("Setting").Element("PathSaturdaySchedule").Value;
                PathSoundCall = xdoc.Element("Setting").Element("PathSoundCall").Value;
                PathTrainingAllertCall = xdoc.Element("Setting").Element("PathTrainingAllertCall").Value;
            }
        }
    }
}
