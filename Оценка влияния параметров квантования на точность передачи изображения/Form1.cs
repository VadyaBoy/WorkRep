using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechLab3
{
    public partial class fm : Form
    {
        public fm()
        {
            InitializeComponent();
            cmbLvl.SelectedIndex = 0;
            cmbType.SelectedIndex = 0;
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
        /// <summary>
        /// Объект класса Color
        /// </summary>
        Color c; // Объект класса Color
        Color[,] Pic; // Исходный массив цветов изображения
        double[,] PicGray; // Массив GrayScale
        /// <summary>
        /// Функция преобразования изображения в массив цветов
        /// </summary>
        /// <param name="bitmapFilePath">Путь</param>
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
        /// Функция квантования изображения
        /// </summary>
        /// <returns>Изображения после квантования</returns>
        Bitmap Quant() // Функция квантования
        {
            c = new Color();
            double[,] Q = new double[width, height];
            int lvl = Convert.ToInt32(cmbLvl.SelectedItem.ToString()); // Линейное квантование
            double lvlStep = 255 / Convert.ToDouble(lvl);
            double[] masLvl = new double[lvl + 1];
            masLvl[0] = 0;
            for (int i = 1; i < masLvl.Length; i++) // Рассчет уровней квантования
            {
                masLvl[i] = masLvl[i - 1] + lvlStep;
            }
            double delta;
            int index = 0;
            for (int i = 0; i < width; i++) // Рассчет линейного квантования
            {
                for(int j = 0; j < height; j++)
                {
                    delta = 255;
                    for (int k = 0; k < masLvl.Length; k++)
                    {
                        if (Math.Abs(PicGray[i,j] - masLvl[k]) < delta)
                        {
                            delta = Math.Abs(PicGray[i, j] - masLvl[k]);
                            index = k;
                        }
                    }
                    Q[i, j] = masLvl[index];
                }
            }
            Bitmap img = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            for (int i = 0; i < width; i++) // Вывод изображения после линейного квантования
            {
                for (int j = 0; j < height; j++)
                {
                    c = Color.FromArgb(Convert.ToInt32(Math.Round(Q[i, j])), Convert.ToInt32(Math.Round(Q[i, j])), Convert.ToInt32(Math.Round(Q[i, j]))); // Задание цвета пикселя
                    img.SetPixel(i, j, c); // Вывод в изображение
                }
            }
            SumPixel(PicGray, Q);
            return img;
        }
        /// <summary>
        /// Функция расчета показателей качества
        /// </summary>
        /// <param name="NewCalcpict1">Певрое изображение</param>
        /// <param name="NewCalcpict2">Второе изображение</param>
        void SumPixel(double[,] NewCalcpict1, double[,] NewCalcpict2) // Метод рассчета метрик
        {
            int LenghtMass = NewCalcpict2.Length; // Общее количество элементов в картинке
            double MSE = 0;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    MSE += Math.Pow(NewCalcpict1[i, j] - NewCalcpict2[i, j], 2); // Разность яркостей между первой картинки и второй                    
                }
            }
            MSE = Math.Round(MSE / LenghtMass, 2, MidpointRounding.AwayFromZero); // Расчет конечного значения MSE            
            tbMSE.Text = MSE.ToString(); //Отображение MSE на форме

            double PSNR;
            if (MSE == 0)
            {
                PSNR = 100; // Значения PSNR, если MSE равен нулю, то деление на ноль в логарифме - невозможно. Значит PSNR пусть будет равен 100
            }
            else
            {
                PSNR = Math.Round(10 * Math.Log10(Math.Pow(255, 2) / MSE), 2, MidpointRounding.AwayFromZero); // Расчет значения PSNR
            }
            tbPSNR.Text = PSNR.ToString(); // Вывод значения

            double X = 0;
            double Y = 0;
            double Sigma_X = 0;
            double Sigma_Y = 0;
            double Sigma_X_Y = 0;
            double k_1 = 0.01;
            double k_2 = 0.03;
            int L = 255;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    X += NewCalcpict1[i, j]; // Суммирование яркости первой картинки                    
                    Y += NewCalcpict2[i, j]; // Суммирование яркости второй картинки
                }
            }
            X = X / LenghtMass; // Деление проссумированного значения на количество элементов первой картинки
            Y = Y / LenghtMass; // Деление проссумированного значения на количество элементов второй картинки                       
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Sigma_X += Math.Pow(NewCalcpict1[i, j] - X, 2); // Расчет сигмы первого изображения 
                    Sigma_Y += Math.Pow(NewCalcpict2[i, j] - Y, 2); // Расчет сигмы второго изображения 
                    Sigma_X_Y += (NewCalcpict1[i, j] - X) * (NewCalcpict2[i, j] - Y); // Расчет сигмы для двух изображений
                }
            }
            Sigma_X = Sigma_X / ((width - 1) * (height - 1)); // Деления сигмы для первого изображения на ширину - 1px и высоту - 1px изображения
            Sigma_Y = Sigma_Y / ((width - 1) * (height - 1)); // Деления сигмы для второго изображения на ширину - 1px и высоту - 1px изображения
            Sigma_X_Y = Sigma_X_Y / ((width - 1) * (height - 1)); // Деления сигмы для двух изображений на ширину - 1px и высоту - 1px изображения
            double SSIM = Math.Round(((2 * X * Y + Calc_C(L, k_1)) * (2 * Sigma_X_Y + Calc_C(L, k_2))) / ((Math.Pow(X, 2) + Math.Pow(Y, 2) + Calc_C(L, k_1)) * (Sigma_X + Sigma_Y + Calc_C(L, k_2))), 2, MidpointRounding.AwayFromZero); // Расчет SSIM
            tbSSIM.Text = SSIM.ToString(); // Вывод SSIM на форму
        }
        double Calc_C(int L, double k)
        {
            return Math.Pow(k * L, 2);
        }
        /// <summary>
        /// Функция дизеринга
        /// </summary>
        /// <param name="type">Тип</param>
        /// <returns>Изображение после дизеринга</returns>
        Bitmap Dizering(bool type)
        {
            Bitmap img = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Random rnd = new Random();
            double[,] D = new double[width, height]; // Массив светлот дизеринга
            if(!type) // Случайный дизеринг
            {
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        D[i, j] = rnd.Next(0, 256);
                        if (PicGray[i, j] > D[i, j])
                        {
                            D[i, j] = 255;
                        }
                        else
                        {
                            D[i, j] = 0;
                        }
                    }
                }
            }
            else // Упорядоченный дизеринг
            {
                double mean; // Среднее значение маски
                double lvl0 = 255 * 0.25; // 1 уровень
                double lvl1 = 255 * 0.5; // 2 уровень
                double lvl2 = 255 * 0.75; // 3 уровень
                double lvl3 = 255; // 4 уровень
                for (int i = 0; i < width - 1; i += 2)
                {
                    for (int j = 0; j < height - 1; j += 2)
                    {
                        mean = (PicGray[i, j] + PicGray[i + 1, j] + PicGray[i, j + 1] + PicGray[i + 1, j + 1]) / 4;
                        if(mean >= lvl3)
                        {
                            D[i, j + 1] = 255;
                        }
                        else
                        {
                            D[i, j + 1] = 0;
                        }
                        if (mean >= lvl2)
                        {
                            D[i + 1, j] = 255;
                        }
                        else
                        {
                            D[i + 1, j] = 0;
                        }
                        if (mean >= lvl1)
                        {
                            D[i + 1, j + 1] = 255;
                        }
                        else
                        {
                            D[i + 1, j + 1] = 0;
                        }
                        if (mean >= lvl0)
                        {
                            D[i, j] = 255;
                        }
                        else
                        {
                            D[i, j] = 0;
                        }
                    }
                }
            }
            for (int i = 0; i < width; i++) // Вывод изображения после линейного квантования
            {
                for (int j = 0; j < height; j++)
                {
                    c = Color.FromArgb(Convert.ToInt32(Math.Round(D[i, j])), Convert.ToInt32(Math.Round(D[i, j])), Convert.ToInt32(Math.Round(D[i, j]))); // Задание цвета пикселя
                    img.SetPixel(i, j, c); // Вывод в изображение
                }
            }
            SumPixel(PicGray, D); // Рассчет показателей качества
            return img;
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
            OPF.Filter = "JPG|*.jpg|JPEG|*.jpeg|PNG|*.png"; // Фильтр в диалоговом окне
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                FileName.Add(OPF.FileName); // Добавление в массив пути картинки 
                Pic = GetBitMapColorMatrix(FileName[0]);
                panImg.BackgroundImage = Image.FromFile(OPF.FileName); // Отображение изображения на форме   
            }
            else
            {
                return;
            }
            PicGray = new double[width, height];
            for (int i = 0; i < width; i++) // Grayscale
            {
                for (int j = 0; j < height; j++)
                {
                    PicGray[i, j] = 0.299 * Pic[i, j].R + 0.587 * Pic[i, j].G + 0.114 * Pic[i, j].B; // Перевод в оттенки серого
                }
            }
            buQuant.Enabled = true;
            cmbLvl.Enabled = true;
            buDizering.Enabled = true;
            cmbType.Enabled = true;
        }
        /// <summary>
        /// Кнопка квантования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buQuant_Click(object sender, EventArgs e)
        {
            panResult.BackgroundImage = Quant();
            buSave.Enabled = true;
        }
        /// <summary>
        /// Кнопка дизеринга
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buDizering_Click(object sender, EventArgs e)
        {
            panResult.BackgroundImage = Dizering(Convert.ToBoolean(cmbType.SelectedIndex));
            buSave.Enabled = true;
        }
        /// <summary>
        /// Кнопка сохранения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog(); // Сохранение
            sfd.Filter = "Рисунок .jpg | *.jpg";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                panResult.BackgroundImage.Save(sfd.FileName);
            }
        }
    }
}
