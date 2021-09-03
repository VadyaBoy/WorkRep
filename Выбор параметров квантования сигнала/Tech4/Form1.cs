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

namespace Tech4
{
    public partial class fm : Form
    {
        public fm()
        {
            InitializeComponent();
            cmbLvl.SelectedIndex = 0;
            notLine = new double[12];
            notLine[0] = 0; // Веса нелинейного квантирования
            notLine[1] = 22.0  / 255.0;
            notLine[2] = 43.0 / 255.0;
            notLine[3] = 57.0 / 255.0;
            notLine[4] = 92.0 / 255.0;
            notLine[5] = 106.0 / 255.0;
            notLine[6] = 120.0 / 255.0;
            notLine[7] = 134.0 / 255.0;
            notLine[8] = 197.0 / 255.0;
            notLine[9] = 218.0 / 255.0;
            notLine[10] = 232.0 / 255.0;
            notLine[11] = 255.0 / 255.0;
        }
        double[] imgSin; // Массивы изображений
        double[] imgQ;
        double[] imgQnew;
        int[] gistSin; // Массивы гистрограмм изображений
        int[] gistQ;
        int[] gistQnew;
        int height = 300, width = 300; // Размеры изображения
        Color c; // Объект цвета
        Bitmap img1; // Изображения
        Bitmap img2;
        Bitmap img3;
        double[] notLine; // Массив весов нелинейного квантования
        /// <summary>
        /// Константа k_1
        /// </summary>
        double k_1 = 0.01;
        /// <summary>
        /// Константа k_2
        /// </summary>
        double k_2 = 0.03;
        /// <summary>
        /// Динамический диапазон пикселей
        /// </summary>
        int L = 255;
        double[] Sinusoid(double fs, double phase, int dots) // Функция синусоиды
        {
            double[] x = new double[dots];
            double delta = fs / dots;
            x[0] = 0;
            for (int i = 1; i < dots; i++)
            {
                x[i] = x[i - 1] + delta;
            }
            double[] y = new double[dots];
            for (int i = 0; i < dots; i++)
            {
                y[i] = 0.5 + 0.5 * Math.Sin(x[i] + phase * x[i]);
            }
            return y;
        }
        void Quant() // Функция квантования
        {
            c = new Color();
            imgSin = new double[width];
            imgQ = new double[width];
            gistSin = new int[256];
            gistQ = new int[256];
            for (int i = 0; i < 256; i++)
            {
                gistSin[i] = 0;
                gistQ[i] = 0;
            }
            imgSin = Sinusoid(Convert.ToDouble(tbFs.Text.ToString()) / 2, 0, width); // Сохранение синусоиды
            img1 = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            for (int i = 0; i < width; i++) // Вывод в изображение синусоиды
            {
                for (int j = 0; j < height; j++)
                {
                    gistSin[Convert.ToInt32(Math.Round(imgSin[j] * 255))]++;
                    c = Color.FromArgb(Convert.ToInt32(Math.Round(imgSin[j] * 255)), Convert.ToInt32(Math.Round(imgSin[j] * 255)), Convert.ToInt32(Math.Round(imgSin[j] * 255))); // Задание цвета пикселя
                    img1.SetPixel(j, i, c); // Вывод в изображение
                }
            }
            panImg1.BackgroundImage = img1;

            int lvl = Convert.ToInt32(cmbLvl.SelectedItem.ToString()); // Линейное квантование
            double lvlStep = 1 / Convert.ToDouble(lvl);
            double[] masLvl = new double[lvl + 1];
            masLvl[0] = 0;
            for (int i = 1; i < masLvl.Length; i++) // Рассчет уровней квантования
            {
                masLvl[i] = masLvl[i - 1] + lvlStep;
            }
            double delta = 1;
            int index = 0;
            for (int i = 0; i < width; i++) // Рассчет линейного квантования
            {

                if (imgSin[i] >= Convert.ToDouble(tbBottom.Text) && imgSin[i] <= Convert.ToDouble(tbTop.Text))
                {
                    delta = 1;
                    for (int j = 0; j < masLvl.Length; j++)
                    {
                        if (Math.Abs(imgSin[i] - masLvl[j]) < delta)
                        {
                            delta = Math.Abs(imgSin[i] - masLvl[j]);
                            index = j;
                        }
                    }
                    imgQ[i] = masLvl[index];
                }
                else
                {
                    imgQ[i] = imgSin[i];
                }

            }

            img2 = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            for (int i = 0; i < width; i++) // Вывод изображения после линейного квантования
            {
                for (int j = 0; j < height; j++)
                {
                    gistQ[Convert.ToInt32(Math.Round(imgQ[j] * 255))]++;
                    c = Color.FromArgb(Convert.ToInt32(Math.Round(imgQ[j] * 255)), Convert.ToInt32(Math.Round(imgQ[j] * 255)), Convert.ToInt32(Math.Round(imgQ[j] * 255))); // Задание цвета пикселя
                    img2.SetPixel(j, i, c); // Вывод в изображение
                }
            }
            panImg2.BackgroundImage = img2;
            SumPixel(GetBitMapColorMatrix(img1), GetBitMapColorMatrix(img2)); // Рассчет метрик
            StreamWriter sw1 = new StreamWriter("Assets/Gist1.txt", false); // Файлы для записи гистограмм
            sw1.Write("");
            sw1.Close();
            sw1 = new StreamWriter("Assets/Gist1.txt");
            StreamWriter sw2 = new StreamWriter("Assets/Gist2.txt", false); // Файлы для записи гистограмм
            sw2.Write("");
            sw2.Close();
            sw2 = new StreamWriter("Assets/Gist2.txt");
            for (int i = 0; i < 256; i++)
            {
                sw1.WriteLine(gistSin[i].ToString());
                sw2.WriteLine(gistQ[i].ToString());
            }
            sw1.Close();
            sw2.Close();
        }
        void SumPixel(Color[,] NewCalcpict1, Color[,] NewCalcpict2) // Метод рассчета метрик
        {
            double[] MSEMass = new double[4]; // Массив для хранения поканальных различий MSE
            int LenghtMass = NewCalcpict2.Length; // Общее количество элементов в картинке

            double MSE = 0;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    MSE += Math.Pow(CalcBrighness(NewCalcpict1[i, j]) - CalcBrighness(NewCalcpict2[i, j]), 2); // Разность яркостей между первой картинки и второй                    
                }
            }
            MSE = Math.Round(MSE / LenghtMass, 2, MidpointRounding.AwayFromZero); // Расчет конечного значения MSE            

            laMSE.Text = "MSE: " + MSE; //Отображение MSE на форме
            double PSNR;
            if (MSE == 0)
            {
                PSNR = 0; // Значения PSNR, если MSE равен нулю, то деление на ноль в логарифме - невозможно. Значит PSNR пусть будет равен нулю
            }
            else
            {
                PSNR = Math.Round(10 * Math.Log10(Math.Pow(255, 2) / MSE), 2, MidpointRounding.AwayFromZero); // Расчет значения PSNR
            }
            laPSNR.Text = "PSNR: " + PSNR; // Вывод значения

            double X = 0;
            double Y = 0;
            double Sigma_X = 0;
            double Sigma_Y = 0;
            double Sigma_X_Y = 0;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    X += CalcBrighness(NewCalcpict1[i, j]); // Суммирование яркости первой картинки                    
                    Y += CalcBrighness(NewCalcpict2[i, j]); // Суммирование яркости второй картинки
                }
            }

            X = X / LenghtMass; // Деление проссумированного значения на количество элементов первой картинки
            Y = Y / LenghtMass; // Деление проссумированного значения на количество элементов второй картинки                       

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Sigma_X += Math.Pow(CalcBrighness(NewCalcpict1[i, j]) - X, 2); // Расчет сигмы первого изображения 
                    Sigma_Y += Math.Pow(CalcBrighness(NewCalcpict2[i, j]) - Y, 2); // Расчет сигмы второго изображения 
                    Sigma_X_Y += (CalcBrighness(NewCalcpict1[i, j]) - X) * (CalcBrighness(NewCalcpict2[i, j]) - Y); // Расчет сигмы для двух изображений
                }
            }
            Sigma_X = Sigma_X / ((width - 1) * (height - 1)); // Деления сигмы для первого изображения на ширину - 1px и высоту - 1px изображения
            Sigma_Y = Sigma_Y / ((width - 1) * (height - 1)); // Деления сигмы для второго изображения на ширину - 1px и высоту - 1px изображения
            Sigma_X_Y = Sigma_X_Y / ((width - 1) * (height - 1)); // Деления сигмы для двух изображений на ширину - 1px и высоту - 1px изображения
            double SSIM = Math.Round(((2 * X * Y + Calc_C(L, k_1)) * (2 * Sigma_X_Y + Calc_C(L, k_2))) / ((Math.Pow(X, 2) + Math.Pow(Y, 2) + Calc_C(L, k_1)) * (Sigma_X + Sigma_Y + Calc_C(L, k_2))), 2, MidpointRounding.AwayFromZero); // Расчет SSIM
            laSSIM.Text = "SSIM: " + SSIM; // Вывод SSIM на форму
        }
        /// <summary>
        /// Метод расчета яркости
        /// </summary>
        /// <param name="Pix">Пиксель картинки</param>
        /// <returns></returns>
        double CalcBrighness(Color Pix)
        {
            return Math.Sqrt(0.299 * Math.Pow(Pix.R, 2) + 0.587 * Math.Pow(Pix.G, 2) + 0.114 * Math.Pow(Pix.B, 2)); ; // Возвращение значения яркости из метода
        }
        /// <summary>
        /// Расчет переменных С
        /// </summary>
        /// <param name="L">Динамический диапазон пикселей</param>
        /// <param name="k"> Константа</param>
        /// <returns></returns>
        double Calc_C(int L, double k)
        {
            return Math.Pow(k * L, 2);
        }
        Color[,] GetBitMapColorMatrix(Bitmap b1) // Функция преобразования изображения в массив цветов
        {
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
        private void BuCalc_Click(object sender, EventArgs e) // Кнопка рассчета линейного квантования
        {
            laMSE.Text = "MSE: "; //Сброс отображения значения
            laPSNR.Text = "PSNR: "; //Сброс отображения значения
            laSSIM.Text = "SSIM: "; //Сброс отображения значения
            buSave.Enabled = true;
            buCalc2.Enabled = true;
            Quant();
        }
        private void BuCalc2_Click(object sender, EventArgs e) // Кнопка рассчета нелинейного квантования
        {
            double delta = 1;
            int index = 0;
            imgQnew = new double[width];
            gistQnew = new int[256];
            for (int i = 0; i < 256; i++)
            {
                
                gistQnew[i] = 0;
            }
            for (int i = 0; i < width; i++)
            {

                if (imgQ[i] >= Convert.ToDouble(tbBottom.Text) && imgQ[i] <= Convert.ToDouble(tbTop.Text))
                {
                    delta = 1;
                    for (int j = 0; j < notLine.Length; j++)
                    {
                        if (Math.Abs(imgSin[i] - notLine[j]) < delta)
                        {
                            delta = Math.Abs(imgQ[i] - notLine[j]);
                            index = j;
                        }
                    }
                    imgQnew[i] = notLine[index];
                }
                else
                {
                    imgQnew[i] = imgQ[i];
                }

            }
            img3 = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    gistQnew[Convert.ToInt32(Math.Round(imgQ[j] * 255))]++;
                    c = Color.FromArgb(Convert.ToInt32(Math.Round(imgQnew[j]*255)), Convert.ToInt32(Math.Round(imgQnew[j]*255)), Convert.ToInt32(Math.Round(imgQnew[j]*255))); // Задание цвета пикселя
                    img3.SetPixel(j, i, c); // Вывод в изображение
                }
            }
            panImg2.BackgroundImage = img3;
            SumPixel(GetBitMapColorMatrix(img2), GetBitMapColorMatrix(img3));
            StreamWriter sw3 = new StreamWriter("Assets/Gist3.txt", false); // Файлы для записи гистограмм
            sw3.Write("");
            sw3.Close();
            sw3 = new StreamWriter("Assets/Gist3.txt");
            for (int i = 0; i < 256; i++)
            {
                sw3.WriteLine(gistSin[i].ToString());

            }
        }
        private void BuSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog(); // Сохранение изображения
            sfd.Filter = "Рисунок .jpg | *.jpg";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                panImg2.BackgroundImage.Save(sfd.FileName);
            }
        }
    }
}
