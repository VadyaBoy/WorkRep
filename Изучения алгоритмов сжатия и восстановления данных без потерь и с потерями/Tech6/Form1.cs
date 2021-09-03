using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tech6
{
    public partial class fm : Form
    {
        public fm()
        {
            InitializeComponent();
        }
        List<string> FileName = new List<string>(); // Путь к файлу
        /// <summary>
        /// Кнопка загрузки изображений разных форматов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buDownload_Click(object sender, EventArgs e)
        {
            FileName.Clear(); // Очистка массива путей
            OpenFileDialog OPF = new OpenFileDialog(); // Инициализация диалогового окна
            OPF.Filter = "PNG|*.png|JPEG|*.jpeg|JPG|*.jpg|BMP|*.bmp|TIF|*.tif|GIF|*.gif|RAW|*.raw"; // Фильтр в диалоговом окне
            Stopwatch stopWatch = new Stopwatch(); // Класс отсчета
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                stopWatch.Start(); // Начало отсчета
                FileName.Add(OPF.FileName); // Добавление в массив пути картинки
                panImg.BackgroundImage = Image.FromFile(OPF.FileName); // Отображение изображения на форме   
                buSave.Enabled = true; // Включение кнопки "Сохранения"
            }
            else
            {
                return;
            }
            stopWatch.Stop(); // Конец отсчета
            TimeSpan ts = stopWatch.Elapsed; // Преобразование отсчета
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
            laReadTime.Text = elapsedTime; // Вывод времени чтения
            
        }
        /// <summary>
        /// Кнопка сохранения изображений в разных форматах
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog(); // Сохранение изображения
            sfd.Filter = "Рисунок .jpeg | *.jpeg | Рисунок .bmp | *.bmp | Рисунок .tif | *.tif | Рисунок .gif | *.gif | Рисунок .png | *.png | Рисунок .raw | *.raw"; // Фильтр в диалоговом окне
            Stopwatch stopWatch = new Stopwatch(); // Класс отсчета
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                stopWatch.Start(); // Начало отсчета
                panImg.BackgroundImage.Save(sfd.FileName);
            }
            stopWatch.Stop();// Начало отсчета
            TimeSpan ts = stopWatch.Elapsed; // Преобразование отсчета
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
            laWriteTime.Text = elapsedTime; // Вывод времени записи
        }
    }
}
