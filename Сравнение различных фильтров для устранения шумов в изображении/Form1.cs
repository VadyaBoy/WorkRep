using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Imaging;

namespace LabObr2
{
    public partial class fm : Form
    {
        public fm()
        {
            InitializeComponent();
            cmbType.SelectedIndex = 0;
            cmbLin.SelectedIndex = 0;
        }
        List<string> FileName = new List<string>();
        int height, width; // Длина и ширина изображения
        Color[,] Pic; // Исходный массив цветов изображения
        Color c = new Color();
        double[,] PicGray; // Массив для расчетов
        double[,] PicPSNR;
        bool psnr = false;
        /// <summary>
        /// Функция получения массива цветов изображения
        /// </summary>
        /// <param name="bitmapFilePath">Путь к файлу</param>
        /// <returns>Массив цветов изображения</returns>
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
        /// Функция перевода изображения в Grayscale
        /// </summary>
        /// <returns>Массив GrayScale</returns>
        private double[,] GrayScale()
        {
            Pic = GetBitMapColorMatrix(FileName[0]); // Получение массива цветов изображения
            double[,] Gray = new double[width, height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Gray[i, j] = 0.299 * Pic[i, j].R + 0.587 * Pic[i, j].G + 0.114 * Pic[i, j].B; // Перевод в оттенки серого
                }
            }
            return Gray;
        }
        double[,] window3(double[,] pic) // Добавление рамки для рассчета c окном 3х3
        {
            double[,] Win3 = new double[width + 2, height + 2];
            for (int i = 0; i < width + 2; i++)
            {
                for (int j = 0; j < height + 2; j++)
                {
                    if (i == 0)
                    {
                        if (j == 0)
                        {
                            Win3[i, j] = pic[i, j];
                        }
                        else
                        {
                            if (j == height + 1)
                            {
                                Win3[i, j] = pic[i, j - 2];
                            }
                            else
                            {
                                Win3[i, j] = pic[i, j - 1];
                            }
                        }
                    }
                    else
                    {
                        if (i == width + 1)
                        {
                            if (j == 0)
                            {
                                Win3[i, j] = pic[i - 2, j];
                            }
                            else
                            {
                                if (j == height + 1)
                                {
                                    Win3[i, j] = pic[i - 2, j - 2];
                                }
                                else
                                {
                                    Win3[i, j] = pic[i - 2, j - 1];
                                }
                            }
                        }
                        else
                        {
                            if (j == 0)
                            {
                                Win3[i, j] = pic[i - 1, j];
                            }
                            else
                            {
                                if (j == height + 1)
                                {
                                    Win3[i, j] = pic[i - 1, j - 2];
                                }
                                else
                                {
                                    Win3[i, j] = pic[i - 1, j - 1];
                                }
                            }
                        }
                    }
                }
            }
            return Win3;
        }
        double[,] window5(double[,] pic) // Добавление рамки для рассчета c окном 5х5
        {
            double[,] Win3 = new double[width + 2, height + 2];
            double[,] Win5 = new double[width + 4, height + 4];
            if (pic.Length == width * height) Win3 = window3(pic);
            for (int i = 0; i < width + 4; i++)
            {
                for (int j = 0; j < height + 4; j++)
                {
                    if (i == 0)
                    {
                        if (j == 0)
                        {
                            Win5[i, j] = Win3[i, j];
                        }
                        else
                        {
                            if (j == height + 3)
                            {
                                Win5[i, j] = Win3[i, j - 2];
                            }
                            else
                            {
                                Win5[i, j] = Win3[i, j - 1];
                            }
                        }
                    }
                    else
                    {
                        if (i == width + 3)
                        {
                            if (j == 0)
                            {
                                Win5[i, j] = Win3[i - 2, j];
                            }
                            else
                            {
                                if (j == height + 3)
                                {
                                    Win5[i, j] = Win3[i - 2, j - 2];
                                }
                                else
                                {
                                    Win5[i, j] = Win3[i - 2, j - 1];
                                }
                            }
                        }
                        else
                        {
                            if (j == 0)
                            {
                                Win5[i, j] = Win3[i - 1, j];
                            }
                            else
                            {
                                if (j == height + 3)
                                {
                                    Win5[i, j] = Win3[i - 1, j - 2];
                                }
                                else
                                {
                                    Win5[i, j] = Win3[i - 1, j - 1];
                                }
                            }
                        }
                    }

                }
            }
            return Win5;
        }
        /// <summary>
        /// Функция медианной фильтрации
        /// </summary>
        /// <returns>Изображение с медианной фильтрацией</returns>
        Bitmap Median()
        {
            double[,] PicCalc = new double[width, height];
            Bitmap img = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            double[] lSort;
            double[] lSorted;
            double minW = 256;
            int indMin = 0;
            switch (cmbLin.SelectedIndex)
            {
                case 0: // Маска 3х3
                    double[,] Win3 = window3(PicGray);
                    for (int i = 1; i < width + 1; i++) // Рассчет медианы окрестности
                    {
                        for (int j = 1; j < height + 1; j++)
                        {
                            lSort = new double[9] { Win3[i - 1, j - 1], Win3[i - 1, j],
                        Win3[i - 1, j + 1], Win3[i, j - 1], Win3[i, j],
                    Win3[i, j + 1], Win3[i + 1, j - 1], Win3[i + 1, j], Win3[i + 1, j + 1]};
                            lSorted = new double[9];
                            for (int k = 0; k < 9; k++)
                            {
                                for (int l = 0; l < 9; l++)
                                {
                                    if (lSort[l] < minW)
                                    {
                                        minW = lSort[l];
                                        indMin = l;
                                    }
                                }
                                lSorted[k] = minW;
                                lSort[indMin] = 256;
                                minW = 256;
                            }
                            PicCalc[i - 1, j - 1] = lSorted[4];
                            c = Color.FromArgb(Convert.ToInt32(Math.Round(PicCalc[i - 1, j - 1])), Convert.ToInt32(Math.Round(PicCalc[i - 1, j - 1])), Convert.ToInt32(Math.Round(PicCalc[i - 1, j - 1])));
                            img.SetPixel(i - 1, j - 1, c); // Вывод в изображение
                        }
                    }
                    break;
                case 1: // Маска 5х5
                    double[,] Win5 = window5(PicGray);
                    for (int i = 2; i < width + 2; i++) // Рассчет медианы окрестности
                    {
                        for (int j = 2; j < height + 2; j++)
                        {
                            lSort = new double[25] { Win5[i - 2, j - 2], Win5[i - 2, j - 1],
                        Win5[i - 2, j], Win5[i - 2, j + 1], Win5[i - 2, j + 2],
                        Win5[i - 1, j - 2], Win5[i - 1, j - 1], Win5[i - 1, j],
                        Win5[i - 1, j + 1], Win5[i - 1, j + 2], Win5[i, j - 2],
                        Win5[i, j - 1], Win5[i, j], Win5[i, j + 1], Win5[i, j + 2] ,
                        Win5[i + 1, j - 2], Win5[i + 1, j - 1], Win5[i + 1, j],
                        Win5[i + 1, j + 1], Win5[i + 1, j + 2], Win5[i + 2, j - 2],
                        Win5[i + 2, j - 1], Win5[i + 2, j], Win5[i + 2, j + 1],
                        Win5[i + 2, j + 2]};
                            lSorted = new double[25];
                            for (int k = 0; k < 25; k++)
                            {
                                for (int l = 0; l < 25; l++)
                                {
                                    if (lSort[l] < minW)
                                    {
                                        minW = lSort[l];
                                        indMin = l;
                                    }
                                }
                                lSorted[k] = minW;
                                lSort[indMin] = 256;
                                minW = 256;
                            }
                            PicCalc[i - 2, j - 2] = lSorted[12];
                            c = Color.FromArgb(Convert.ToInt32(Math.Round(PicCalc[i - 2, j - 2])), Convert.ToInt32(Math.Round(PicCalc[i - 2, j - 2])), Convert.ToInt32(Math.Round(PicCalc[i - 2, j - 2])));
                            img.SetPixel(i - 2, j - 2, c); // Вывод в изображение
                        }
                    }
                    break;
            }
            if (psnr)
            {
                PSNR(PicCalc);
            }
            return img;
        }
        /// <summary>
        /// Функция повышения резкости изображения
        /// </summary>
        /// <returns>Изображение с повышенной резкостью</returns>
        Bitmap Sharpness()
        {
            int[] weights = new int[] { 0, -1, 0, -1, 4, -1, 0, -1, 0 };// Веса для резкости { 1, 1, 1, 1, -8, 1, 1, 1, 1 }
            double[,] Win3 = window3(PicGray);
            double[,] PicCalc = new double[width, height];
            Bitmap img = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            for (int i = 1; i < width + 1; i++) // Рассчет резкости после линейного сглаживания 3х3 (равные веса)
            {
                for (int j = 1; j < height + 1; j++)
                {
                    PicCalc[i - 1, j - 1] = PicGray[i - 1, j - 1] + (Win3[i - 1, j - 1] * weights[0]
                        + Win3[i - 1, j] * weights[1]
                        + Win3[i - 1, j + 1] * weights[2]
                        + Win3[i, j - 1] * weights[3]
                        + Win3[i, j] * weights[4]
                        + Win3[i, j + 1] * weights[5]
                        + Win3[i + 1, j - 1] * weights[6]
                        + Win3[i + 1, j] * weights[7]
                        + Win3[i + 1, j + 1] * weights[8]);
                    if (PicCalc[i - 1, j - 1] > 255) PicCalc[i - 1, j - 1] = 255;
                    if (PicCalc[i - 1, j - 1] < 0) PicCalc[i - 1, j - 1] = 0;
                    c = Color.FromArgb(Convert.ToInt32(Math.Round(PicCalc[i - 1, j - 1])), Convert.ToInt32(Math.Round(PicCalc[i - 1, j - 1])), Convert.ToInt32(Math.Round(PicCalc[i - 1, j - 1])));
                    img.SetPixel(i - 1, j - 1, c); // Вывод в изображение
                }
            }
            if (psnr)
            {
                PSNR(PicCalc);
            }
            return img;
        }
        /// <summary>
        /// Функция размытия по Гауссу
        /// </summary>
        /// <returns>Изображение с Гауссовым размытием</returns>
        Bitmap Gauss()
        {
            ComplexImage cImgSpecF; // Создание комплексного изображения
            var gray = new AForge.Imaging.Filters.Grayscale(0.2125, 0.7154, 0.0721).Apply(new Bitmap(panImg.BackgroundImage)); // Преобразование изображение в GrayScale
            cImgSpecF = ComplexImage.FromBitmap(gray); // Заполнение комплексного изображения
            cImgSpecF.ForwardFourierTransform(); // Прямое Фурье преобразование
            Bitmap img;
            double d; // Переменная функции фильтра
            double h; // Значение функции фильтра
            double d0 = Convert.ToDouble(numBorder.Value.ToString()); // Значение среза
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    d = Math.Sqrt(Math.Pow(i - (width / 2), 2) + Math.Pow(j - (height / 2), 2));
                    h = Math.Exp(-Math.Pow(d, 2) / (2 * Math.Pow(d0, 2)));
                    cImgSpecF.Data[i, j] = cImgSpecF.Data[i, j] * h;
                }
            }
            cImgSpecF.BackwardFourierTransform(); // Обратное Фурье преобразование
            img = cImgSpecF.ToBitmap(); // Сохранение фильтра востановленного изображения в картинку
            if(psnr)
            {
                double[,] PicCalc = new double[width, height];
                for (int i = 0; i < img.Width; i++)
                {
                    for (int j = 0; j < img.Height; j++)
                    {
                        PicCalc[i, j] = 0.299 * img.GetPixel(i, j).R + 0.587 * img.GetPixel(i, j).G + 0.114 * img.GetPixel(i, j).B; // Добавление в двухмерный массив пикселей картинки
                    }
                }
                PSNR(PicCalc);
            }
            return img;
        }
        /// <summary>
        /// Функция линейного размытия
        /// </summary>
        /// <returns>Изображение с лейным размытием</returns>
        Bitmap Linear() // Функция линейного сглаживания
        {
            Bitmap img = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            double[] weights;// Веса для сглаживания
            c = new Color();
            double[,] PicCalc = new double[width, height];
            switch (cmbLin.SelectedIndex)
            {
                case 0: // Маска 3х3
                    weights = new double[] { 1, 2, 1, 2, 4, 2, 1, 2, 1 };// Веса для сглаживания
                    double[,] Win3 = window3(PicGray);
                    for (int i = 1; i < width + 1; i++) // Рассчет линейного сглаживания 3х3
                    {
                        for (int j = 1; j < height + 1; j++)
                        {
                            PicCalc[i - 1, j - 1] = Win3[i - 1, j - 1] * weights[0] // Равные веса
                                + Win3[i - 1, j] * weights[1]
                                + Win3[i - 1, j + 1] * weights[2]
                                + Win3[i, j - 1] * weights[3]
                                + Win3[i, j] * weights[4]
                                + Win3[i, j + 1] * weights[5]
                                + Win3[i + 1, j - 1] * weights[6]
                                + Win3[i + 1, j] * weights[7]
                                + Win3[i + 1, j + 1] * weights[8];
                            PicCalc[i - 1, j - 1] = PicCalc[i - 1, j - 1] / 16;
                            c = Color.FromArgb(Convert.ToInt32(Math.Round(PicCalc[i - 1, j - 1])), Convert.ToInt32(Math.Round(PicCalc[i - 1, j - 1])), Convert.ToInt32(Math.Round(PicCalc[i - 1, j - 1])));
                            img.SetPixel(i - 1, j - 1, c); // Вывод в изображение
                        }
                    }
                    break;
                case 1: // Маска 5х5
                    weights = new double[] { 0.000789, 0.006581, 0.013347, 0.006581, 0.000789, 0.006581,
                    0.054901, 0.111345, 0.054901, 0.006581, 0.013347, 0.111345, 0.225821, 0.111345,
                    0.013347, 0.006581, 0.054901, 0.111345, 0.054901, 0.006581, 0.000789, 0.006581,
                    0.013347, 0.006581, 0.000789};// Веса для сглаживания
                    double[,] Win5 = window5(PicGray);
                    for (int i = 2; i < width + 2; i++) // Рассчет линейного сглаживания 5х5
                    {
                        for (int j = 2; j < height + 2; j++)
                        {
                            PicCalc[i - 2, j - 2] = Win5[i - 2, j - 2] * weights[0] // Взвешенные веса
                                + Win5[i - 2, j - 1] * weights[1]
                                + Win5[i - 2, j] * weights[2]
                                + Win5[i - 2, j + 1] * weights[3]
                                + Win5[i - 2, j + 2] * weights[4]
                                + Win5[i - 1, j - 2] * weights[5]
                                + Win5[i - 1, j - 1] * weights[6]
                                + Win5[i - 1, j] * weights[7]
                                + Win5[i - 1, j + 1] * weights[8]
                                + Win5[i - 1, j + 2] * weights[9]
                                + Win5[i, j - 2] * weights[10]
                                + Win5[i, j - 1] * weights[11]
                                + Win5[i, j] * weights[12]
                                + Win5[i, j + 1] * weights[13]
                                + Win5[i, j + 2] * weights[14]
                                + Win5[i + 1, j - 2] * weights[15]
                                + Win5[i + 1, j - 1] * weights[16]
                                + Win5[i + 1, j] * weights[17]
                                + Win5[i + 1, j + 1] * weights[18]
                                + Win5[i + 1, j + 2] * weights[19]
                                + Win5[i + 2, j - 2] * weights[20]
                                + Win5[i + 2, j - 1] * weights[21]
                                + Win5[i + 2, j] * weights[22]
                                + Win5[i + 2, j + 1] * weights[23]
                                + Win5[i + 2, j + 2] * weights[24];
                            c = Color.FromArgb(Convert.ToInt32(Math.Round(PicCalc[i - 2, j - 2])), Convert.ToInt32(Math.Round(PicCalc[i - 2, j - 2])), Convert.ToInt32(Math.Round(PicCalc[i - 2, j - 2])));
                            img.SetPixel(i - 2, j - 2, c); // Вывод в изображение
                        }
                    }
                    break;
            }
            if (psnr)
            {
                PSNR(PicCalc);
            }
            return img;
        }
        /// <summary>
        /// Функция расчета PSNR (исходное изображение и изображение с шумом после фильтрации)
        /// </summary>
        /// <param name="pic">Изображение после фильтрации</param>
        void PSNR(double[,] pic)
        {
            int LenghtMass = pic.Length; // Общее количество элементов в картинке
            double MSE = 0;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    MSE += Math.Pow(PicPSNR[i, j] - pic[i, j], 2); // Разность яркостей между первой картинки и второй                    
                }
            }
            MSE = Math.Round(MSE / LenghtMass, 2, MidpointRounding.AwayFromZero); // Расчет конечного значения MSE            
            double PSNR;
            if (MSE == 0)
            {
                PSNR = 100; // Значения PSNR, если MSE равен нулю, то деление на ноль в логарифме - невозможно. Значит PSNR пусть будет равен 100
            }
            else
            {
                PSNR = Math.Round(10 * Math.Log10(Math.Pow(255, 2) / MSE), 2, MidpointRounding.AwayFromZero); // Расчет значения PSNR
            }
            laPSNR.Text = "PSNR: " + PSNR; // Вывод значения
        }
        /// <summary>
        /// Кнопка загрузки изображения с шумом
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buDownload_Click(object sender, EventArgs e)
        {
            FileName.Clear();
            OpenFileDialog OPF = new OpenFileDialog(); // Инициализация диалогового окна
            OPF.Filter = "JPG|*.jpg|PNG|*.png"; // Фильтр в диалоговом окне
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                FileName.Add(OPF.FileName); // Добавление в массив пути картинки                    
                panImg.BackgroundImage = System.Drawing.Image.FromFile(OPF.FileName); // Отображение изображения на форме
                PicGray = GrayScale();
                buCalc.Enabled = true;
                cmbType.Enabled = true;
                numBorder.Enabled = true;
                cmbLin.Enabled = true;
            }
            else
            {
                return;
            }
        }
        /// <summary>
        /// Кнопка загрузки исходного изображения для расчета PSNR
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buPSNR_Click(object sender, EventArgs e)
        {
            FileName.Clear();
            OpenFileDialog OPF = new OpenFileDialog(); // Инициализация диалогового окна
            OPF.Filter = "JPG|*.jpg|PNG|*.png"; // Фильтр в диалоговом окне
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                FileName.Add(OPF.FileName); // Добавление в массив пути картинки                    
                panPSNR.BackgroundImage = System.Drawing.Image.FromFile(OPF.FileName); // Отображение изображения на форме
                PicPSNR = GrayScale();
                psnr = true;
            }
            else
            {
                return;
            }
        }
        /// <summary>
        /// Кнопка расчета
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buCalc_Click(object sender, EventArgs e)
        {
            switch (cmbType.SelectedIndex)
            {
                case 0:
                    panCalc.BackgroundImage = Median();
                    break;
                case 1:
                    panCalc.BackgroundImage = Sharpness();
                    break;
                case 2:
                    panCalc.BackgroundImage = Gauss();
                    break;
                case 3:
                    panCalc.BackgroundImage = Linear();
                    break;
            }
            buSave.Enabled = true;
        }
        /// <summary>
        /// Кнопка сохранения полученного изображения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog(); // Сохранение фильтра спектра
            sfd.Filter = "Рисунок .jpg | *.jpg";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                panCalc.BackgroundImage.Save(sfd.FileName);
            }
        }
    }
}
