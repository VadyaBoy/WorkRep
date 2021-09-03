using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Obr2
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
        double[,] PicNeg;
        double[,] PicLog;
        double[,] PicPow1;
        double[,] PicPow2;
        double[,] PicLinear;
        double[,] PicSlice;
        private void BuGetImg_Click(object sender, EventArgs e)
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

        private void BuCalc_Click(object sender, EventArgs e)
        {
            Pic = GetBitMapColorMatrix(FileName[0]);
            PicGray = new double[width, height];
            PicNeg = new double[width, height];
            PicLog = new double[width, height];
            PicPow1 = new double[width, height];
            PicPow2 = new double[width, height];
            PicLinear = new double[width, height];
            PicSlice = new double[width, height];
            Color c = new Color();
            double max = 0;
            // GrayScale
            Bitmap picc = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    PicGray[i, j] = 0.299 * Pic[i, j].R + 0.587 * Pic[i, j].G + 0.114 * Pic[i, j].B; // Перевод в оттенки серого
                    c = Color.FromArgb(Convert.ToInt32(PicGray[i, j]), Convert.ToInt32(PicGray[i, j]), Convert.ToInt32(PicGray[i, j]));
                    picc.SetPixel(i,j,c); // Вывод в изображение
                    if(max <= PicGray[i, j]) // Расчет максимального значения массива для дальнейших функций
                    {
                        max = PicGray[i, j];
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
            //// Негатив
            picc = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    PicNeg[i, j] = Math.Abs(PicGray[i, j] - 255); // Рассчет негатива
                    c = Color.FromArgb(Convert.ToInt32(PicNeg[i, j]), Convert.ToInt32(PicNeg[i, j]), Convert.ToInt32(PicNeg[i, j]));
                    picc.SetPixel(i, j, c); // Вывод в изображение
                }
            }
            sfd = new SaveFileDialog(); // Сохранение изображения
            sfd.Filter = "Рисунок .jpg | *.jpg";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                picc.Save(sfd.FileName);
            }
            panImgNeg.BackgroundImage = picc;
            // Логарифмическое преобразование
            double C1 = 255 / (Math.Log10(1 + max)); // Рассчет константы C
            picc = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    PicLog[i, j] = C1*Math.Log10(1 + PicGray[i, j]); // Рассчет логарифмического преобразования
                    c = Color.FromArgb(Convert.ToInt32(PicLog[i, j]), Convert.ToInt32(PicLog[i, j]), Convert.ToInt32(PicLog[i, j]));
                    picc.SetPixel(i, j, c); // Вывод в изображение
                }
            }
            sfd = new SaveFileDialog(); // Сохранение изображения
            sfd.Filter = "Рисунок .jpg | *.jpg";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                picc.Save(sfd.FileName);
            }
            panImgLog.BackgroundImage = picc;
            // Степенное преобразование для степени > 1
            double C2 = 255; // Константа С
            picc = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    PicPow1[i, j] = C2 * Math.Pow(PicGray[i, j] / 255, 1.5); // Рассчет степенного преобразования
                    c = Color.FromArgb(Convert.ToInt32(PicPow1[i, j]), Convert.ToInt32(PicPow1[i, j]), Convert.ToInt32(PicPow1[i, j]));
                    picc.SetPixel(i, j, c); // Вывод в изображение
                }
            }
            sfd = new SaveFileDialog(); // Сохранение изображения
            sfd.Filter = "Рисунок .jpg | *.jpg";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                picc.Save(sfd.FileName);
            }
            panImgPow1.BackgroundImage = picc;
            // Степенное преобразование для степени < 1
            picc = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    PicPow2[i, j] = C2 * Math.Pow(PicGray[i, j] / 255, 0.67); // Рассчет степенного преобразования
                    c = Color.FromArgb(Convert.ToInt32(PicPow2[i, j]), Convert.ToInt32(PicPow2[i, j]), Convert.ToInt32(PicPow2[i, j]));
                    picc.SetPixel(i, j, c); // Вывод в изображение
                }
            }
            sfd = new SaveFileDialog(); // Сохранение изображения
            sfd.Filter = "Рисунок .jpg | *.jpg";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                picc.Save(sfd.FileName);
            }
            panImgPow2.BackgroundImage = picc;
            // Линейно-кусочное преобразование
            int r1 = 70; // Необходимое коэффициенты
            int s1 = 0;
            int r2 = 140;
            int s2 = 255;
            picc = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if ((PicGray[i, j] >= 0) && (PicGray[i, j] <= r1)) // Констркция рассчета
                    {
                        PicLinear[i, j] = (s1 / r1) * PicGray[i, j];
                    }
                    else
                    {
                        if ((PicGray[i, j] > r1) && (PicGray[i, j] <= r2))
                        {
                            PicLinear[i, j] = ((s2 - s1) / (r2 - r1)) * (PicGray[i, j] - r1) + s1;
                        }
                        else
                        {
                            PicLinear[i, j] = ((255 - s2) / (255 - r2)) * (PicGray[i, j] - r2) + s2;
                        }
                    }
                    c = Color.FromArgb(Convert.ToInt32(PicLinear[i, j]), Convert.ToInt32(PicLinear[i, j]), Convert.ToInt32(PicLinear[i, j]));
                    picc.SetPixel(i, j, c); // Вывод в изображение
                }
            }
            sfd = new SaveFileDialog(); // Сохранение изображения
            sfd.Filter = "Рисунок .jpg | *.jpg";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                picc.Save(sfd.FileName);
            }
            panImgLinear.BackgroundImage = picc;
            // Вырезание уровней
            // 8 уровень (самый светлый)
            picc = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (perevod(Convert.ToInt32(PicGray[i, j]))[0] == 1)
                    {
                        PicSlice[i, j] = 0;
                    }
                    else
                    {
                        PicSlice[i, j] = 255;
                    }
                    c = Color.FromArgb(Convert.ToInt32(PicSlice[i, j]), Convert.ToInt32(PicSlice[i, j]), Convert.ToInt32(PicSlice[i, j]));
                    picc.SetPixel(i, j, c); // Вывод в изображение
                }
            }
            sfd = new SaveFileDialog(); // Сохранение изображения
            sfd.Filter = "Рисунок .jpg | *.jpg";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                picc.Save(sfd.FileName);
            }
            panImgSlice1.BackgroundImage = picc;
            // 7 уровень 
            picc = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if ((perevod(Convert.ToInt32(PicGray[i, j]))[0]) != 1 && (perevod(Convert.ToInt32(PicGray[i, j]))[1] == 1))
                    {
                        PicSlice[i, j] = 0;
                    }
                    else
                    {
                        PicSlice[i, j] = 255;
                    }
                    c = Color.FromArgb(Convert.ToInt32(PicSlice[i, j]), Convert.ToInt32(PicSlice[i, j]), Convert.ToInt32(PicSlice[i, j]));
                    picc.SetPixel(i, j, c); // Вывод в изображение
                }
            }
            sfd = new SaveFileDialog(); // Сохранение изображения
            sfd.Filter = "Рисунок .jpg | *.jpg";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                picc.Save(sfd.FileName);
            }
            panImgSlice2.BackgroundImage = picc;
            // 6 уровень 
            picc = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if ((perevod(Convert.ToInt32(PicGray[i, j]))[0]) != 1 && (perevod(Convert.ToInt32(PicGray[i, j]))[1] != 1) && (perevod(Convert.ToInt32(PicGray[i, j]))[2] == 1))
                    {
                        PicSlice[i, j] = 0;
                    }
                    else
                    {
                        PicSlice[i, j] = 255;
                    }
                    c = Color.FromArgb(Convert.ToInt32(PicSlice[i, j]), Convert.ToInt32(PicSlice[i, j]), Convert.ToInt32(PicSlice[i, j]));
                    picc.SetPixel(i, j, c); // Вывод в изображение
                }
            }
            sfd = new SaveFileDialog(); // Сохранение изображения
            sfd.Filter = "Рисунок .jpg | *.jpg";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                picc.Save(sfd.FileName);
            }
            panImgSlice3.BackgroundImage = picc;
            // 5 уровень 
            picc = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if ((perevod(Convert.ToInt32(PicGray[i, j]))[0]) != 1 && (perevod(Convert.ToInt32(PicGray[i, j]))[1] != 1) && (perevod(Convert.ToInt32(PicGray[i, j]))[2] != 1) && (perevod(Convert.ToInt32(PicGray[i, j]))[3] == 1))
                    {
                        PicSlice[i, j] = 0;
                    }
                    else
                    {
                        PicSlice[i, j] = 255;
                    }
                    c = Color.FromArgb(Convert.ToInt32(PicSlice[i, j]), Convert.ToInt32(PicSlice[i, j]), Convert.ToInt32(PicSlice[i, j]));
                    picc.SetPixel(i, j, c); // Вывод в изображение
                }
            }
            sfd = new SaveFileDialog(); // Сохранение изображения
            sfd.Filter = "Рисунок .jpg | *.jpg";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                picc.Save(sfd.FileName);
            }
            panImgSlice4.BackgroundImage = picc;
            // 4 уровень 
            picc = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if ((perevod(Convert.ToInt32(PicGray[i, j]))[0]) != 1 && (perevod(Convert.ToInt32(PicGray[i, j]))[1] != 1) && (perevod(Convert.ToInt32(PicGray[i, j]))[2] != 1) && (perevod(Convert.ToInt32(PicGray[i, j]))[3] != 1) && (perevod(Convert.ToInt32(PicGray[i, j]))[4] == 1))
                    {
                        PicSlice[i, j] = 0;
                    }
                    else
                    {
                        PicSlice[i, j] = 255;
                    }
                    c = Color.FromArgb(Convert.ToInt32(PicSlice[i, j]), Convert.ToInt32(PicSlice[i, j]), Convert.ToInt32(PicSlice[i, j]));
                    picc.SetPixel(i, j, c); // Вывод в изображение
                }
            }
            sfd = new SaveFileDialog(); // Сохранение изображения
            sfd.Filter = "Рисунок .jpg | *.jpg";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                picc.Save(sfd.FileName);
            }
            panImgSlice5.BackgroundImage = picc;
            // 3 уровень 
            picc = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if ((perevod(Convert.ToInt32(PicGray[i, j]))[0]) != 1 && (perevod(Convert.ToInt32(PicGray[i, j]))[1] != 1) && (perevod(Convert.ToInt32(PicGray[i, j]))[2] != 1) && (perevod(Convert.ToInt32(PicGray[i, j]))[3] != 1) && (perevod(Convert.ToInt32(PicGray[i, j]))[4] != 1) && (perevod(Convert.ToInt32(PicGray[i, j]))[5] == 1))
                    {
                        PicSlice[i, j] = 0;
                    }
                    else
                    {
                        PicSlice[i, j] = 255;
                    }
                    c = Color.FromArgb(Convert.ToInt32(PicSlice[i, j]), Convert.ToInt32(PicSlice[i, j]), Convert.ToInt32(PicSlice[i, j]));
                    picc.SetPixel(i, j, c); // Вывод в изображение
                }
            }
            sfd = new SaveFileDialog(); // Сохранение изображения
            sfd.Filter = "Рисунок .jpg | *.jpg";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                picc.Save(sfd.FileName);
            }
            panImgSlice6.BackgroundImage = picc;
            // 2 уровень 
            picc = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if ((perevod(Convert.ToInt32(PicGray[i, j]))[0]) != 1 && (perevod(Convert.ToInt32(PicGray[i, j]))[1] != 1) && (perevod(Convert.ToInt32(PicGray[i, j]))[2] != 1) && (perevod(Convert.ToInt32(PicGray[i, j]))[3] != 1) && (perevod(Convert.ToInt32(PicGray[i, j]))[4] != 1) && (perevod(Convert.ToInt32(PicGray[i, j]))[5] != 1) && (perevod(Convert.ToInt32(PicGray[i, j]))[6] == 1))
                    {
                        PicSlice[i, j] = 0;
                    }
                    else
                    {
                        PicSlice[i, j] = 255;
                    }
                    c = Color.FromArgb(Convert.ToInt32(PicSlice[i, j]), Convert.ToInt32(PicSlice[i, j]), Convert.ToInt32(PicSlice[i, j]));
                    picc.SetPixel(i, j, c); // Вывод в изображение
                }
            }
            sfd = new SaveFileDialog(); // Сохранение изображения
            sfd.Filter = "Рисунок .jpg | *.jpg";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                picc.Save(sfd.FileName);
            }
            panImgSlice7.BackgroundImage = picc;
            // 1 уровень (самый темный)
            picc = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if ((perevod(Convert.ToInt32(PicGray[i, j]))[0]) != 1 && (perevod(Convert.ToInt32(PicGray[i, j]))[1] != 1) && (perevod(Convert.ToInt32(PicGray[i, j]))[2] != 1) && (perevod(Convert.ToInt32(PicGray[i, j]))[3] != 1) && (perevod(Convert.ToInt32(PicGray[i, j]))[4] != 1) && (perevod(Convert.ToInt32(PicGray[i, j]))[5] != 1) && (perevod(Convert.ToInt32(PicGray[i, j]))[6] != 1))
                    {
                        PicSlice[i, j] = 0;
                    }
                    else
                    {
                        PicSlice[i, j] = 255;
                    }
                    c = Color.FromArgb(Convert.ToInt32(PicSlice[i, j]), Convert.ToInt32(PicSlice[i, j]), Convert.ToInt32(PicSlice[i, j]));
                    picc.SetPixel(i, j, c); // Вывод в изображение
                }
            }
            sfd = new SaveFileDialog(); // Сохранение изображения
            sfd.Filter = "Рисунок .jpg | *.jpg";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                picc.Save(sfd.FileName);
            }
            panImgSlice8.BackgroundImage = picc;
        }
        // Преобразование изображения в массив цветов RGB
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
        //получает обратную запись двоичного числа из дсятичного
        private int[] perevod(int temp)
        {
            int temp1 = 0;
            List<int> s = new List<int>();
            while (temp > 0)
            {
                temp1 = temp % 2;
                temp = temp / 2;
                s.Add(temp1);
            }
            if (s.Count < 8)
            {
                int d = s.Count;
                for (int i = 0; i < 8 - d; i++)
                {
                    s.Add(0);
                }
            }
            return obrat(s);
        }
        //переворачивает число и возвращает прямую запись двоичного числа.
        private int[] obrat(List<int> norm)
        {
            int[] s = new int[norm.Count];
            for (int i = norm.Count - 1; i >= 0; i--)
            {
                s[norm.Count - 1 - i] = norm[i];
            }
            
            return s;
        }
    }
}
