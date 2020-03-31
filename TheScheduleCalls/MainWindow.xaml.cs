using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TheScheduleCalls
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Schedule mainSchedule = new Schedule();
        public Schedule reducedSchedule = new Schedule();
        public Schedule saturdaySchedule = new Schedule();

        //Активное расписание
        public bool isMainSchedule = false;
        public bool isReducedSchedule = false;
        public bool isSuterdaySchedule = false;

        //Есть ли данные для расписания
        public bool isMainScheduleExists = false;
        public bool isReducedScheduleExists = false;
        public bool isSuterdayExists = false;

        public List<TextBlock> tb_mainSchedule = new List<TextBlock>(); 

        public MainWindow()
        {
            InitializeComponent();
            GlobalSetting.LoadSetting();
            InitializeSetting();
            ShowTime();

            if (System.IO.File.Exists("setting.s")){
                mainSchedule.LoadFileXML(GlobalSetting.PathMainSchedule);
                InitializeMainScheduleList();
                UpdateMainSchedule();
            }
        }

        private void InitializeSetting()
        {
            tb_SoundCall.Text           =   GlobalSetting.PathSoundCall;
            tb_TreningAlert.Text        =   GlobalSetting.PathTrainingAllertCall;
            tb_MainSchedule.Text        =   GlobalSetting.PathMainSchedule;
            tb_ReducedSchedule.Text     =   GlobalSetting.PathReducedSchedule;
            tb_SaturdaySchedule.Text    =   GlobalSetting.PathSaturdaySchedule;
        }

        private void CreateSchedule_Click(object sender, RoutedEventArgs e)
        {
            CreateSchedule createSchedule = new CreateSchedule();
            createSchedule.ShowDialog();
        }

        private void reviewSoundCall_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Sound file |*.wav";
            opf.CheckFileExists = true;
            opf.Multiselect = false;
            if (opf.ShowDialog() == true)
            {
                GlobalSetting.PathSoundCall = opf.FileName;
                tb_SoundCall.Text = opf.FileName;
            }
        }

        private void testSoundCall_Click(object sender, RoutedEventArgs e)
        {

        }

        private void reviewTreningAlertSound_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Sound file |*.wav";
            opf.CheckFileExists = true;
            opf.Multiselect = false;
            if (opf.ShowDialog() == true)
            {
                GlobalSetting.PathTrainingAllertCall = opf.FileName;
                tb_TreningAlert.Text = opf.FileName;
            }
        }

        private void testSoundAlert_Click(object sender, RoutedEventArgs e)
        {

        }

        private void reviewMainSchedule_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Schedule file |*.schedule";
            opf.CheckFileExists = true;
            opf.Multiselect = false;
            if (opf.ShowDialog() == true)
            {
                GlobalSetting.PathMainSchedule = opf.FileName;
                tb_MainSchedule.Text = opf.FileName;
            }
        }

        private void reviewReducedSchedule_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Schedule file |*.schedule";
            opf.CheckFileExists = true;
            opf.Multiselect = false;
            if (opf.ShowDialog() == true)
            {
                GlobalSetting.PathReducedSchedule = opf.FileName;
                tb_ReducedSchedule.Text = opf.FileName;
            }
        }

        private void reviewSaturdaySchedule_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Schedule file |*.schedule";
            opf.CheckFileExists = true;
            opf.Multiselect = false;
            if (opf.ShowDialog() == true)
            {
                GlobalSetting.PathSaturdaySchedule = opf.FileName;
                tb_SaturdaySchedule.Text = opf.FileName;
            }
        }

        private void saveSetting_Click(object sender, RoutedEventArgs e)
        {
            GlobalSetting.SaveSettings();
        }

        /// <summary>
        /// Устанавливает или обновляет значения расписания MainSchedule
        /// </summary>
        private void UpdateMainSchedule()
        {
            for(int i = 0; i < tb_mainSchedule.Count-1; i++)
            {
                tb_mainSchedule[i].Text = mainSchedule.stringCalls[i];
            }
        }

        /// <summary>
        /// Инициализирует лист главного расписания
        /// </summary>
        private void InitializeMainScheduleList()
        {
            tb_mainSchedule = new List<TextBlock>
            {
                tb_mainSchedule_start0, tb_mainSchedule_end0,
                tb_mainSchedule_start1, tb_mainSchedule_end1,
                tb_mainSchedule_start2, tb_mainSchedule_end2,
                tb_mainSchedule_start3, tb_mainSchedule_end3,
                tb_mainSchedule_start4, tb_mainSchedule_end4,
                tb_mainSchedule_start5, tb_mainSchedule_end5,
                tb_mainSchedule_start6, tb_mainSchedule_end6,
                tb_mainSchedule_start7, tb_mainSchedule_end7,
            };
        }

        void ShowTime()
        {
            var timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.IsEnabled = true;
            timer.Tick += (o, e) => {
                timeNow.Text = $"ВРЕМЯ СЕЙЧАС: {DateTime.Now.ToString("HH:mm:ss")}";

            };
            timer.Start();
        }

        private void rb_mainSchedule_Checked(object sender, RoutedEventArgs e)
        {
            rb_reducedSchedule.IsChecked = false;
            rb_saturdaySchedule.IsChecked = false;

            isMainSchedule = true;
            isReducedSchedule = false;
            isSuterdaySchedule = false;
        }

        private void rb_reducedSchedule_Checked(object sender, RoutedEventArgs e)
        {
            rb_mainSchedule.IsChecked = false;
            rb_saturdaySchedule.IsChecked = false;

            isMainSchedule = false;
            isReducedSchedule = true;
            isSuterdaySchedule = false;
        }

        private void rb_saturdaySchedule_Checked(object sender, RoutedEventArgs e)
        {
            rb_mainSchedule.IsChecked = false;
            rb_reducedSchedule.IsChecked = false;

            isMainSchedule = false;
            isReducedSchedule = false;
            isSuterdaySchedule = true;
        }
    }
}
