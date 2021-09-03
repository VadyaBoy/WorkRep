using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabTech4
{
    public partial class fm : Form
    {
        public fm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Высота картинки
        /// </summary>
        int height;
        /// <summary>
        /// Ширина картинки
        /// </summary>
        int width;
        /// <summary>
        /// Массив путей картинок
        /// </summary>
        List<string> FileName = new List<string>();
        Color[,] Pic; // Исходный массив цветов изображения
        /// <summary>
        /// Функция расчета цветового массива изображения
        /// </summary>
        /// <param name="bitmapFilePath"></param>
        /// <returns>Массив цветов</returns>
        Color[,] GetBitMapColorMatrix(string bitmapFilePath)
        {
            Bitmap b1 = new Bitmap(bitmapFilePath); //Инициализация класса BitMap для работы с картинкой
            height = b1.Height; // Высота картинки
            width = b1.Width; // Ширина картинки
            Color[,] colorMatrix = new Color[width, height]; // Создание двухмерного массива
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    colorMatrix[i, j] = b1.GetPixel(i, j); // Добавление в двухмерный массив пикселей картинки
                }
            }
            return colorMatrix; // Возвращение двухмерного массива
        }
        /// <summary>
        /// Функция расчета среднего значения каналов цветов изображения
        /// </summary>
        void RGB_Mean()
        {
            double R = 0; // Среднее значение канала R
            double G = 0; // Среднее значение канала G
            double B = 0; // Среднее значение канала B
            for (int i = 0; i < width; i++) // Для каждого пикселя
            {
                for (int j = 0; j < height; j++)
                {
                    R += Pic[i, j].R;
                    G += Pic[i, j].G;
                    B += Pic[i, j].B;
                }
            }
            R = R / Pic.Length;
            G = G / Pic.Length;
            B = B / Pic.Length;
            tbR.Text = R.ToString(); // Вывод значения среднего значения канала R
            tbG.Text = G.ToString(); // Вывод значения среднего значения канала G
            tbB.Text = B.ToString(); // Вывод значения среднего значения канала B
        }
        /// <summary>
        /// Кнопка загрузки изображения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buDownload_Click(object sender, EventArgs e)
        {
            FileName.Clear();
            OpenFileDialog OPF = new OpenFileDialog(); // Инициализация диалогового окна
            OPF.Filter = "PNG|*.png|JPEG|*.jpeg|JPG|*.jpg"; // Фильтр в диалоговом окне
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                FileName.Add(OPF.FileName); // Добавление в массив пути картинки 
                Pic = GetBitMapColorMatrix(FileName[0]);
                panImg.BackgroundImage = Image.FromFile(OPF.FileName); // Отображение изображения на форме
                buCalc.Enabled = true;
            }
        }
        /// <summary>
        /// Кнопка расчета средних значений каналов цветов изображения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buCalc_Click(object sender, EventArgs e)
        {
            RGB_Mean();
        }
    }
}
