using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace TheScheduleCalls
{
    /// <summary>
    /// Логика взаимодействия для TaskShedule.xaml
    /// </summary>
    public partial class TaskShedule : Window
    {
        public static List<Task> Tasks = new List<Task>();
        bool isError = false;

        public TaskShedule()
        {
            InitializeComponent();
            //Tasks.Clear();
            UpdateUIListTasks();
        }

        /// <summary>
        /// Создать задачу и добавить в лист
        /// </summary>
        /// <param name="time">Дата смены расписания</param>
        /// <param name="type">Тип расписания на который сменить</param>
        public void CreateTask(DateTime time, GlobalSetting.typeSheduleActive type)
        {
            Task task = new Task();
            task.timeSwitch = time;
            task.type = type;

            Tasks.Add(task);

            UpdateUIListTasks();
        }

        /// <summary>
        /// Обновить визуальное оформление задачи
        /// </summary>
        public void UpdateUIListTasks()
        {
            sp_listTask.Children.Clear();
            for (int i = 0; i < Tasks.Count; i++) {
                CreateUIGridTask(Tasks[i].timeSwitch, Tasks[i].type, i);
            }
        }

        /// <summary>
        /// Создание структуры XAML для задачи
        /// </summary>
        /// <param name="date"></param>
        /// <param name="type"></param>
        /// <param name="id">Позиция где находиться задача в листе задач</param>
        private void CreateUIGridTask(DateTime date, GlobalSetting.typeSheduleActive type, int id)
        {
            Grid mainGrid = new Grid();
            Grid grid = new Grid();

            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());

            grid.ColumnDefinitions.Add(new ColumnDefinition());
            ColumnDefinition column = new ColumnDefinition();
            column.Width = new GridLength(20);
            grid.ColumnDefinitions.Add(column);

            TextBlock tbDate = new TextBlock();
            tbDate.Text = $"Дата изменения {date.Day}.{date.Month}.{date.Year}";
            tbDate.Margin = new Thickness(12, 5, 0, 0);

            TextBlock tbType = new TextBlock();
            tbType.Margin = new Thickness(12, 0, 0, 0);
            switch (type)
            {
                case GlobalSetting.typeSheduleActive.mainSchedule:
                    tbType.Text = "Изменить на основное расписание";
                    break;
                case GlobalSetting.typeSheduleActive.reducedSchedule:
                    tbType.Text = "Изменить на сокращённое расписание";
                    break;
                case GlobalSetting.typeSheduleActive.trainingAllertCall:
                    tbDate.Text = $"Дата изменения {date.Day}.{date.Month}.{date.Year} время {date.Hour}:{date.Minute}";
                    tbType.Text = "Учебная тревога";
                    break;
            }

            Button btn = new Button();
            btn.Name = "id" + id.ToString();
            btn.Content = "X";
            btn.Foreground = Brushes.White;
            btn.Background = Brushes.Red;
            btn.Click += Btn_Click;

            Grid.SetRow(tbDate, 0);
            Grid.SetColumn(tbDate, 0);

            Grid.SetRow(tbType, 1);
            Grid.SetColumn(tbType, 0);

            Grid.SetRow(btn, 0);
            Grid.SetColumn(btn, 1);

            grid.Children.Add(tbDate);
            grid.Children.Add(tbType);
            grid.Children.Add(btn);

            grid.Background = Brushes.LightGray;
            grid.Margin = new Thickness(0,0,0,5);

            mainGrid.Children.Add(grid);

            sp_listTask.Children.Add(mainGrid);

            SaveTaskXML(); //Сохранение листа
        }

        //Удаление задачи
        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            char[] charNameBnt = ((Button)sender).Name.ToArray();
            charNameBnt[0] = '0';
            charNameBnt[1] = '0';
            string str = new string(charNameBnt);

            Tasks.RemoveAt(int.Parse(str));

            SaveTaskXML(); //Сохранение листа
            //Обновить содержимое страницы
            UpdateUIListTasks();
        }

        //Добавление задачи
        private void addTask_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int day = int.Parse(tb_day.Text);
                int month = int.Parse(tb_month.Text);
                DateTime dateTime;

                GlobalSetting.typeSheduleActive type = new GlobalSetting.typeSheduleActive();

                //Назначение тайпа
                if (rb_main.IsChecked == true)
                {
                    type = GlobalSetting.typeSheduleActive.mainSchedule;
                }
                else if (rb_reduced.IsChecked == true) {
                    type = GlobalSetting.typeSheduleActive.reducedSchedule;
                }
                else if(rb_trainingAllertCall.IsChecked == true)
                {
                    type = GlobalSetting.typeSheduleActive.trainingAllertCall;
                }

                if (type == GlobalSetting.typeSheduleActive.trainingAllertCall)
                {
                    int hour = int.Parse(tb_hour_box.Text);
                    int minutes = int.Parse(tb_minutes_box.Text);
                    dateTime = new DateTime(DateTime.Now.Year, month, day, hour, minutes, 0);
                }
                else
                {
                    dateTime = new DateTime(DateTime.Now.Year, month, day);
                }

                CreateTask(dateTime,type);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! Проверьте правильность данных " + ex.ToString());
            }
        }

        /// <summary>
        /// Загрузка данных из файла XML
        /// </summary>
        public static void LoadTaskXML()
        {
            if (System.IO.File.Exists("Tasks.task"))
            {
                XDocument xDoc = XDocument.Load("Tasks.task");
                XElement schedule = xDoc.Element("Tasks");

                foreach (XElement xe in schedule.Elements("task").ToList())
                {
                    Task task = new Task();
                    string type_task = xe.Element("type").Value;

                    if(type_task == GlobalSetting.typeSheduleActive.mainSchedule.ToString())
                    {
                        task.type = GlobalSetting.typeSheduleActive.mainSchedule;
                    }else if (type_task == GlobalSetting.typeSheduleActive.reducedSchedule.ToString())
                    {
                        task.type = GlobalSetting.typeSheduleActive.reducedSchedule;
                    }
                    else
                    {
                        task.type = GlobalSetting.typeSheduleActive.trainingAllertCall;
                    }
                    DateTime time = new DateTime(
                        int.Parse(xe.Element("year").Value),
                        int.Parse(xe.Element("month").Value),
                        int.Parse(xe.Element("day").Value),
                        int.Parse(xe.Element("hour").Value),
                        int.Parse(xe.Element("minutes").Value),
                        0 //Секунды
                        );
                    task.timeSwitch = time;
                    Tasks.Add(task);
                }
            }
        }

        /// <summary>
        /// Сохранение данных в XML
        /// </summary>
        public static void SaveTaskXML()
        {
            XDocument xDoc = new XDocument();
            XElement elem = new XElement("Tasks");
            for (int i = 0; i < Tasks.Count; i++)
            {
                XElement task_elem = new XElement("task");
                XElement type_elem = new XElement("type", Tasks[i].type.ToString());
                XElement day_elem = new XElement("day", Tasks[i].timeSwitch.Day);
                XElement month_elem = new XElement("month", Tasks[i].timeSwitch.Month);
                XElement hour_elem = new XElement("hour", Tasks[i].timeSwitch.Hour);
                XElement minutes_elem = new XElement("minutes", Tasks[i].timeSwitch.Minute);
                XElement year_elem = new XElement("year", Tasks[i].timeSwitch.Year);


                task_elem.Add(type_elem);
                task_elem.Add(day_elem);
                task_elem.Add(month_elem);
                task_elem.Add(hour_elem);
                task_elem.Add(minutes_elem);
                task_elem.Add(year_elem);

                elem.Add(task_elem);
            }
            xDoc.Add(elem);
            xDoc.Save("Tasks.task");
        }

        /// <summary>
        /// Отобразить поля для времени
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowTimeBox(object sender, RoutedEventArgs e)
        {
            tb_hour.Visibility =        Visibility.Visible;
            tb_minutes.Visibility =     Visibility.Visible;
            tb_hour_box.Visibility =    Visibility.Visible;
            tb_minutes_box.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Скрыть поля для времени
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HideTimeBox(object sender, RoutedEventArgs e)
        {
            tb_hour.Visibility =        Visibility.Hidden;
            tb_minutes.Visibility =     Visibility.Hidden;
            tb_hour_box.Visibility =    Visibility.Hidden;
            tb_minutes_box.Visibility = Visibility.Hidden;
        }
    }

    public class Task
    {
        /// <summary>
        /// Дата переключения на расписание
        /// </summary>
        public DateTime timeSwitch;
        /// <summary>
        /// На какой тип расписания переключить
        /// </summary>
        public GlobalSetting.typeSheduleActive type;
    }
}
