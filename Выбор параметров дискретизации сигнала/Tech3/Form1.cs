using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tech3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Bitmap picc; // Выходное изображение
        int width; // Ширина и высота выходного изображения
        int height;
        double[] imgSin; // Значение точек синусоиды на заданном промежутке
        double imgPhase = 0; // Сдвиг по периоду
        double imgFs; // Коэффициент частоты дискретизации
        Color c;
        /// <summary>
        /// Функция преобразования синусоиды в выходное изображение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuCalc_Click(object sender, EventArgs e)
        {
            c = new Color();
            width = Convert.ToInt32(tbSize.Text.ToString());
            height = Convert.ToInt32(tbSize.Text.ToString());
            imgSin = new double[width];
            if(chbFs.Checked == true) // Выбор сдвига
            {
                imgPhase = Math.PI;
            }
            else
            {
                imgPhase = 0;
            }
            imgFs = (Convert.ToDouble(tbFs.Text.ToString())); // Рассчет входной частоты дискретизации
            imgSin = Sinusoid(imgFs, imgPhase, width); // Вызов функции синусоиды и сохранение её в массив
            for(int i=0;i<width;i++) // Преобразование массива к Grayscale
            {
                imgSin[i] = imgSin[i] * 255;
            }

            picc = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            // Формирование выходного изображения
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    c = Color.FromArgb(Convert.ToInt32(imgSin[j]), Convert.ToInt32(imgSin[j]), Convert.ToInt32(imgSin[j])); // Задание цвета пикселя
                    picc.SetPixel(i, j, c); // Вывод в изображение
                }
            }
            panImg.BackgroundImage = picc; // Отображение изображения на форме
        }
        /// <summary>
        /// Функция рассчета точек синусоиды на заданном промежутке
        /// </summary>
        /// <param name="fs">Частота дискретизации</param>
        /// <param name="phase">Сдвиг</param>
        /// <param name="dots"></param>
        /// <returns></returns>
        double[] Sinusoid(double fs, double phase, int dots)
        {
            double[] x = new double[dots];
            double delta = fs / dots;
            x[0] = 0;
            for(int i = 1; i < dots; i++)
            {
                x[i] = x[i-1] + delta;
            }
            double[] y = new double[dots];
            for (int i = 0; i < dots; i++)
            {
                y[i] = 0.5 + 0.5*Math.Sin(x[i] + phase * x[i]);
            }
            return y;
        }
        /// <summary>
        /// Функция сохранения изображения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog(); // Сохранение изображения
            sfd.Filter = "Рисунок .jpg | *.jpg";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                picc.Save(sfd.FileName);
            }
        }
    }
}
