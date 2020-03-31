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

namespace TheScheduleCalls
{
    /// <summary>
    /// Логика взаимодействия для CreateSchedule.xaml
    /// </summary>
    public partial class CreateSchedule : Window
    {
        public List<TextBox> textBoxList;
        private TextBox errorBox;
        private Schedule schedule = new Schedule();

        public CreateSchedule()
        {
            InitializeComponent();
            InitializeList();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckValidation())  {
                statusSave.Text = "Статус сохранения: присутствует ошибка";
                statusSave.Foreground = Brushes.Red;
            }
            else
            {
                WriteAndSaveScheduleToStringCalls();
                statusSave.Text = "Статус сохранения: сохранено";
                statusSave.Foreground = Brushes.Green;
            }
        }

        /// <summary>
        /// Записать и сохранить в лист для сохранения структуры XML
        /// </summary>
        private void WriteAndSaveScheduleToStringCalls()
        {
            for (int i = 0; i < textBoxList.Count; i++) {
                schedule.stringCalls.Add(textBoxList[i].Text);
            }
            schedule.SaveFileXML(nameFileToSave.Text);
        }

        /// <summary>
        /// Проверка правильности значения
        /// </summary>
        /// <returns>Возвращает результат проверки</returns>
        private bool CheckValidation()
        {
            bool isError = false;

            //Если было ошибочное поле, то вернуть ему стандартный цвет заднего фона
            if(errorBox != null) errorBox.Background = Brushes.White;

            for (int i = 0; i < textBoxList.Count; i++)
            {
                //Если поле пустое, то выдать ошибку
                if (textBoxList[i].Text == String.Empty || textBoxList[i].Text.Length != 8)
                {
                    isError = true;
                    errorBox = textBoxList[i];
                    errorBox.Background = Brushes.Red;
                    MessageBox.Show("Поле заполненно не правильно ");
                    break;
                }

                if (textBoxList[i].Text[2].ToString() != ":" || textBoxList[i].Text[5].ToString() != ":")
                {
                    isError = true;
                    MessageBox.Show("Разделителем между часами:минутами:секундами должно быть двоеточие ");
                    errorBox = textBoxList[i];
                    errorBox.Background = Brushes.Red;
                    break;
                }

                int hour = int.Parse(textBoxList[i].Text[0].ToString() + textBoxList[i].Text[1].ToString());
                int minutes = int.Parse(textBoxList[i].Text[3].ToString() + textBoxList[i].Text[4].ToString());
                int seconds = int.Parse(textBoxList[i].Text[6].ToString() + textBoxList[i].Text[7].ToString());

                if (hour > 23 || minutes > 59 || seconds > 59)
                {
                    isError = true;
                    MessageBox.Show("Неверный формат времени");
                    errorBox = textBoxList[i];
                    errorBox.Background = Brushes.Red;
                    break;
                }
            }

            //Вернуть противоположное значение ошибки.
            return !isError;
        }

        /// <summary>
        /// Заполняет лист полями из графического интерфейса
        /// </summary>
        private void InitializeList()
        {
            textBoxList = new List<TextBox>
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
    }
}
