using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Lab3
{
    public partial class fm : Form
    {
        public fm()
        {
            InitializeComponent();
        }
        List<string> FileName = new List<string>();
        int height, width; // Длина и ширина изображения
        Color[,] Pic; // Исходный массив цветов изображения
        double[,] PicGray; // Массивы для расчетов
        double[,] PicGN;
        double[,] PicGE;
        double[,] PicGZadF;
        double[] Gist;
        double[] GistNorm;
        double[] GistEq;
        double[] GistZadF;
        Bitmap picc;
        /// <summary>
        /// Рассчет гистограмм
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuCalc_Click(object sender, EventArgs e)
        {
            Pic = GetBitMapColorMatrix(FileName[0]);
            PicGray = new double[width, height];
            
            PicGN = new double[width, height];
            PicGE = new double[width, height];
            PicGZadF = new double[width, height];
            Color c = new Color();
            int max = 0;
            int min = 255;

            double a = 0;
            double b = 0;

            Gist = new double[256];
            GistNorm = new double[256];
            GistEq = new double[256];
            GistZadF = new double[256];
            for (int i = 0; i < Gist.Length; i++)
            {
                Gist[i] = 0;
                GistNorm[i] = 0;
                GistEq[i] = 0;
                GistZadF[i] = 0;
            }

            StreamWriter sw = new StreamWriter("Assets/1.txt"); // Файлы для записи гистограмм
            sw.Write("");
            sw.Close();
            sw = new StreamWriter("Assets/2.txt");
            sw.Write("");
            sw.Close();
            sw = new StreamWriter("Assets/3.txt");
            sw.Write("");
            sw.Close();
            sw = new StreamWriter("Assets/4.txt");
            sw.Write("");
            sw.Close();
            sw = new StreamWriter("Assets/1.txt", true);
            

            // GrayScale
            picc = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    PicGray[i, j] = 0.299 * Pic[i, j].R + 0.587 * Pic[i, j].G + 0.114 * Pic[i, j].B; // Перевод в оттенки серого
                    c = Color.FromArgb(Convert.ToInt32(PicGray[i, j]), Convert.ToInt32(PicGray[i, j]), Convert.ToInt32(PicGray[i, j]));
                    picc.SetPixel(i, j, c); // Вывод в изображение
                    if (max <= PicGray[i, j]) // Расчет максимального значения массива для дальнейших функций
                    {
                        max = Convert.ToInt32(PicGray[i, j]);
                    }
                    if (min >= PicGray[i, j]) // Расчет минимального значения массива для дальнейших функций
                    {
                        min = Convert.ToInt32(PicGray[i, j]);
                    }
                }
            }
            SaveFileDialog sfd = new SaveFileDialog(); // Сохранение изображения
            sfd.Filter = "Рисунок .jpg | *.jpg";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                picc.Save(sfd.FileName);
            }
            panImgGray.BackgroundImage = picc;
            
            for (int i = 0; i < width; i++) // Рассчет гистограммы Grayscale
            {
                for (int j = 0; j < height; j++)
                {
                    Gist[Convert.ToInt32(PicGray[i,j])]++;
                }
            }
            for (int i = 0; i < Gist.Length; i++) // Запись гистограммы в файл
            {
                sw.WriteLine((Gist[i]/(height*width)).ToString());
            }

            sw.Close();

            //Нормализация
            sw = new StreamWriter("Assets/2.txt", true);
            b = (Convert.ToDouble(numTop.Value.ToString()) - Convert.ToDouble(numBottom.Value.ToString()))/(max-min); // Коэффициенты нормализации
            a = Convert.ToDouble(numBottom.Value.ToString())-min*b;
            picc = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    PicGN[i, j] = a + b * PicGray[i, j]; // Нормализация пикселя
                    GistNorm[Convert.ToInt32(PicGN[i, j])]++; // Рассчет гистограммы
                    c = Color.FromArgb(Convert.ToInt32(PicGN[i, j]), Convert.ToInt32(PicGN[i, j]), Convert.ToInt32(PicGN[i, j]));
                    picc.SetPixel(i, j, c); // Вывод в изображение
                }
            }
            sfd = new SaveFileDialog(); // Сохранение изображения
            sfd.Filter = "Рисунок .jpg | *.jpg";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                picc.Save(sfd.FileName);
            }
            panImgNorm.BackgroundImage = picc;
            for (int i = 0; i < GistNorm.Length; i++) // Запись гистограммы в файл
            {
                sw.WriteLine((GistNorm[i] / (height * width)).ToString());
            }

            sw.Close();

            //Эквализация
            sw = new StreamWriter("Assets/3.txt", true);
            double chance = 0; // Параметр эквализации (сумма вероятностей для определенного пикселя)
            

            picc = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    chance = 0;
                    for (int k = 0; k < PicGray[i, j]; k++)
                    {
                        chance += Gist[k]/(width*height); // Рассчет параметра
                    }
                    PicGE[i, j] = (Gist.Length-1)*chance; // Вычисление эквализации
                    GistEq[Convert.ToInt32(PicGE[i, j])]++; // Рассчет гистограммы
                    c = Color.FromArgb(Convert.ToInt32(PicGE[i, j]), Convert.ToInt32(PicGE[i, j]), Convert.ToInt32(PicGE[i, j]));
                    picc.SetPixel(i, j, c); // Вывод в изображение
                }
            }
            sfd = new SaveFileDialog(); // Сохранение изображения
            sfd.Filter = "Рисунок .jpg | *.jpg";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                picc.Save(sfd.FileName);
            }
            panImgEq.BackgroundImage = picc;

            for (int i = 0; i < GistEq.Length; i++) // Запись гистограммы в файл
            {
                sw.WriteLine((GistEq[i] / (height * width)).ToString() + " ");
            }

            sw.Close();

            // Приведение гистограммы по заданной функции
            sw = new StreamWriter("Assets/4.txt", true);
            picc = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            // Заданная функция p(z)=3z^2/(L-1)^3
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    PicGZadF[i, j] = Math.Pow(255* PicGE[i, j] * PicGE[i, j],0.33); // z^3/(L-1)^2=s - Значение заданной функции после преобразования равно эквализации

                    GistZadF[Convert.ToInt32(PicGZadF[i, j])]++; // Рассчет гистограммы
                    c = Color.FromArgb(Convert.ToInt32(PicGZadF[i, j]), Convert.ToInt32(PicGZadF[i, j]), Convert.ToInt32(PicGZadF[i, j]));
                    picc.SetPixel(i, j, c); // Вывод в изображение
                }
            }

            panImgLg.BackgroundImage = picc;
            sfd = new SaveFileDialog(); // Сохранение изображения
            sfd.Filter = "Рисунок .jpg | *.jpg";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                picc.Save(sfd.FileName);
            }
            for (int i = 0; i < GistZadF.Length; i++) // Запись гистограммы в файл
            {
                sw.WriteLine((GistZadF[i] / (height * width)).ToString() + " ");
            }
            sw.Close();
            
        }
        /// <summary>
        /// Загрузка изображения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuImg_Click(object sender, EventArgs e)
        {
            FileName.Clear();
            Pic = null;
            OpenFileDialog OPF = new OpenFileDialog(); // Инициализация диалогового окна
            OPF.Filter = "PNG|*.png|JPEG|*.jpeg|JPG|*.jpg"; // Фильтр в диалоговом окне
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                FileName.Add(OPF.FileName); // Добавление в массив пути картинки                    
                panImg.BackgroundImage = Image.FromFile(OPF.FileName); // Отображение изображения на форме   
                buCalc.Enabled = true; //Включение кнопки расчета
            }
            else
            {
                return;
            }
        }
        /// <summary>
        /// Преобразование изображения в массив RGB
        /// </summary>
        /// <param name="bitmapFilePath">Путь к файлу</param>
        /// <returns></returns>
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
    }
}
