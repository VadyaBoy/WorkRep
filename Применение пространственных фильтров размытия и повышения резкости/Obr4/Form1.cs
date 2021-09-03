using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Obr4
{
    public partial class fm : Form
    {
        public fm()
        {
            InitializeComponent();
            winLine[0] = 1; // Веса для линейного сглаживания 3x3
            winLine[1] = 1;
            winLine[2] = 1;
            winLine[3] = 1;
            winLine[4] = 1;
            winLine[5] = 1;
            winLine[6] = 1;
            winLine[7] = 1;
            winLine[8] = 1;

            winLine1[0] = 1; // Веса для линейного сглаживания 3x3
            winLine1[1] = 2;
            winLine1[2] = 1;
            winLine1[3] = 2;
            winLine1[4] = 4;
            winLine1[5] = 2;
            winLine1[6] = 1;
            winLine1[7] = 2;
            winLine1[8] = 1;

            winLine2[0] = 0.000789; // Веса для линейного сглаживания 5x5
            winLine2[1] = 0.006581;
            winLine2[2] = 0.013347;
            winLine2[3] = 0.006581;
            winLine2[4] = 0.000789;
            winLine2[5] = 0.006581;
            winLine2[6] = 0.054901;
            winLine2[7] = 0.111345;
            winLine2[8] = 0.054901;
            winLine2[9] = 0.006581; 
            winLine2[10] = 0.013347;
            winLine2[11] = 0.111345;
            winLine2[12] = 0.225821;
            winLine2[13] = 0.111345;
            winLine2[14] = 0.013347;
            winLine2[15] = 0.006581;
            winLine2[16] = 0.054901;
            winLine2[17] = 0.111345;
            winLine2[18] = 0.054901; 
            winLine2[19] = 0.006581;
            winLine2[20] = 0.000789;
            winLine2[21] = 0.006581;
            winLine2[22] = 0.013347;
            winLine2[23] = 0.006581;
            winLine2[24] = 0.000789;

            winSharp[0] = 1; // Веса для резкости
            winSharp[1] = 1;
            winSharp[2] = 1;
            winSharp[3] = 1;
            winSharp[4] = -8;
            winSharp[5] = 1;
            winSharp[6] = 1;
            winSharp[7] = 1;
            winSharp[8] = 1;
        }
        
        int height = 300;// Длина и ширина изображения
        int width = 300;
        
        double[,] PicGray; // Массивы для расчетов
        double[,] ForPic3;
        double[,] ForPic5;
        double[,] PicLine;
        double[,] PicLine1;
        double[,] PicLine2;
        double[,] PicNoise;
        double[,] PicMed;
        double[,] PicSharp;
        double[,] PicSharp1;
        double[,] PicSharp2;
        Bitmap img1; // Изображения
        Bitmap img2;
        Bitmap img2_1;
        Bitmap img2_2;
        Bitmap img3;
        Bitmap img4;
        Bitmap img5;
        Bitmap img5_1;
        Bitmap img5_2;
        double[] winLine = new double[9]; // Массивы весов
        double[] winLine1 = new double[9];
        double[] winLine2 = new double[25];
        double[] winSharp = new double[9];
        Color c; // Объект цвета
        void FuncRectangle() // Формирование функциии периодического прямоугольного сигнала
        {
            img1 = null;
            PicGray = new double[height, width];
            c = new Color();
            img1 = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            int forImg = 0;
            int n = 1;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if(forImg == 5)
                    {
                        forImg = 0;
                        n *= -1;
                    }
                    if(n == 1) PicGray[i, j] = 255;
                    else PicGray[i, j] = 0;
                    c = Color.FromArgb(Convert.ToInt32(PicGray[i, j]), Convert.ToInt32(PicGray[i, j]), Convert.ToInt32(PicGray[i, j]));
                    img1.SetPixel(j, i, c); // Вывод в изображение
                    forImg++;
                }
            }
            panImg1.BackgroundImage = img1;
        }
        void Linear() // Функция линейного сглаживания
        {

            img2 = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            img2_1 = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            img2_2 = new Bitmap(width + 2, height + 2, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            c = new Color();
            PicLine = new double[height, width];
            PicLine1 = new double[height, width];
            PicLine2 = new double[height + 2, width + 2];
            ForPic3 = new double[height + 2, width + 2];
            ForPic5 = new double[height + 4, width + 4];
            window3(PicGray);
            for (int i = 1; i < height + 1; i++) // Рассчет линейного сглаживания 3х3
            {
                for (int j = 1; j < width + 1; j++)
                {
                    PicLine[i - 1, j - 1] = ForPic3[i - 1, j - 1] * winLine[0] // Равные веса
                        + ForPic3[i - 1, j] * winLine[1]
                        + ForPic3[i - 1, j + 1] * winLine[2]
                        + ForPic3[i, j - 1] * winLine[3]
                        + ForPic3[i, j] * winLine[4]
                        + ForPic3[i, j + 1] * winLine[5]
                        + ForPic3[i + 1, j - 1] * winLine[6]
                        + ForPic3[i + 1, j] * winLine[7]
                        + ForPic3[i + 1, j + 1] * winLine[8];
                    PicLine[i - 1, j - 1] = PicLine[i - 1, j - 1]/9;
                    c = Color.FromArgb(Convert.ToInt32(PicLine[i - 1, j - 1]), Convert.ToInt32(PicLine[i - 1, j - 1]), Convert.ToInt32(PicLine[i - 1, j - 1]));
                    img2.SetPixel(j - 1, i - 1, c); // Вывод в изображение

                    PicLine1[i - 1, j - 1] = ForPic3[i - 1, j - 1] * winLine1[0] // Взвешенные веса
                        + ForPic3[i - 1, j] * winLine1[1]
                        + ForPic3[i - 1, j + 1] * winLine1[2]
                        + ForPic3[i, j - 1] * winLine1[3]
                        + ForPic3[i, j] * winLine1[4]
                        + ForPic3[i, j + 1] * winLine1[5]
                        + ForPic3[i + 1, j - 1] * winLine1[6]
                        + ForPic3[i + 1, j] * winLine1[7]
                        + ForPic3[i + 1, j + 1] * winLine1[8];
                    PicLine1[i - 1, j - 1] = PicLine1[i - 1, j - 1] / 16;
                    c = Color.FromArgb(Convert.ToInt32(PicLine1[i - 1, j - 1]), Convert.ToInt32(PicLine1[i - 1, j - 1]), Convert.ToInt32(PicLine1[i - 1, j - 1]));
                    img2_1.SetPixel(j - 1, i - 1, c); // Вывод в изображение
                }
            }
            panImg2.BackgroundImage = img2;
            panImg2_1.BackgroundImage = img2_1;
            window5(PicGray);
            for (int i = 2; i < height + 2; i++) // Рассчет линейного сглаживания 5х5
            {
                for (int j = 2; j < width + 2; j++)
                {
                    PicLine2[i - 2, j - 2] = ForPic5[i - 2, j - 2] * winLine2[0] // Взвешенные веса
                        + ForPic5[i - 2, j - 1] * winLine2[1]
                        + ForPic5[i - 2, j] * winLine2[2]
                        + ForPic5[i - 2, j + 1] * winLine2[3]
                        + ForPic5[i - 2, j + 2] * winLine2[4]
                        + ForPic5[i - 1, j - 2] * winLine2[5]
                        + ForPic5[i - 1, j - 1] * winLine2[6]
                        + ForPic5[i - 1, j] * winLine2[7]
                        + ForPic5[i - 1, j + 1] * winLine2[8]
                        + ForPic5[i - 1, j + 2] * winLine2[9]
                        + ForPic5[i, j - 2] * winLine2[10]
                        + ForPic5[i, j - 1] * winLine2[11]
                        + ForPic5[i, j] * winLine2[12]
                        + ForPic5[i, j + 1] * winLine2[13]
                        + ForPic5[i, j + 2] * winLine2[14]
                        + ForPic5[i + 1, j - 2] * winLine2[15]
                        + ForPic5[i + 1, j - 1] * winLine2[16]
                        + ForPic5[i + 1, j] * winLine2[17]
                        + ForPic5[i + 1, j + 1] * winLine2[18]
                        + ForPic5[i + 1, j + 2] * winLine2[19]
                        + ForPic5[i + 2, j - 2] * winLine2[20]
                        + ForPic5[i + 2, j - 1] * winLine2[21]
                        + ForPic5[i + 2, j] * winLine2[22]
                        + ForPic5[i + 2, j + 1] * winLine2[23]
                        + ForPic5[i + 2, j + 2] * winLine2[24];
                    c = Color.FromArgb(Convert.ToInt32(PicLine2[i - 2, j - 2]), Convert.ToInt32(PicLine2[i - 2, j - 2]), Convert.ToInt32(PicLine2[i - 2, j - 2]));
                    img2_2.SetPixel(j - 2, i - 2, c); // Вывод в изображение
                }
            }
            panImg2_2.BackgroundImage = img2_2;
        }
        void window3(double[,] pic) // Добавление рамки для рассчета c окном 3х3
        {
            for (int i = 0; i < height + 2; i++) 
            {
                for (int j = 0; j < width + 2; j++)
                {
                    if (i == 0)
                    {
                        if (j == 0)
                        {
                            ForPic3[i, j] = pic[i, j];
                        }
                        else
                        {
                            if (j == width + 1)
                            {
                                ForPic3[i, j] = pic[i, j - 2];
                            }
                            else
                            {
                                ForPic3[i, j] = pic[i, j - 1];
                            }
                        }
                    }
                    else
                    {
                        if (i == height + 1)
                        {
                            if (j == 0)
                            {
                                ForPic3[i, j] = pic[i - 2, j];
                            }
                            else
                            {
                                if (j == width + 1)
                                {
                                    ForPic3[i, j] = pic[i - 2, j - 2];
                                }
                                else
                                {
                                    ForPic3[i, j] = pic[i - 2, j - 1];
                                }
                            }
                        }
                        else
                        {
                            if (j == 0)
                            {
                                ForPic3[i, j] = pic[i - 1, j];
                            }
                            else
                            {
                                if (j == width + 1)
                                {
                                    ForPic3[i, j] = pic[i - 1, j - 2];
                                }
                                else
                                {
                                    ForPic3[i, j] = pic[i - 1, j - 1];
                                }
                            }
                        }
                    }
                }
            }
        }
        void window5(double[,] pic) // Добавление рамки для рассчета c окном 5х5
        {
            if(pic.Length == width*height)window3(pic);
            for (int i = 0; i < height + 4; i++)
            {
                for (int j = 0; j < width + 4; j++)
                {
                    if (i == 0)
                    {
                        if (j == 0)
                        {
                            ForPic5[i, j] = ForPic3[i, j];
                        }
                        else
                        {
                            if (j == width + 3)
                            {
                                ForPic5[i, j] = ForPic3[i, j - 2];
                            }
                            else
                            {
                                ForPic5[i, j] = ForPic3[i, j - 1];
                            }
                        }
                    }
                    else
                    {
                        if (i == height + 3)
                        {
                            if (j == 0)
                            {
                                ForPic5[i, j] = ForPic3[i - 2, j];
                            }
                            else
                            {
                                if (j == width + 3)
                                {
                                    ForPic5[i, j] = ForPic3[i - 2, j - 2];
                                }
                                else
                                {
                                    ForPic5[i, j] = ForPic3[i - 2, j - 1];
                                }
                            }
                        }
                        else
                        {
                            if (j == 0)
                            {
                                ForPic5[i, j] = ForPic3[i - 1, j];
                            }
                            else
                            {
                                if (j == width + 3)
                                {
                                    ForPic5[i, j] = ForPic3[i - 1, j - 2];
                                }
                                else
                                {
                                    ForPic5[i, j] = ForPic3[i - 1, j - 1];
                                }
                            }
                        }
                    }
                    
                }
            }
        }
        void Noise() // Функция добавления импульсного шума
        {
            Random rand = new Random();
            PicNoise = new double[height, width];
            PicNoise = PicGray;
            c = new Color();
            for (int i = 0; i < width*5; i++)
            {
                if(rand.NextDouble() > 0.5)
                {
                    PicNoise[rand.Next(height), rand.Next(width)] = 255;
                }
                else
                {
                    PicNoise[rand.Next(height), rand.Next(width)] = 0;
                }
            }
            img3 = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    c = Color.FromArgb(Convert.ToInt32(PicNoise[i, j]), Convert.ToInt32(PicNoise[i, j]), Convert.ToInt32(PicNoise[i, j]));
                    img3.SetPixel(j, i, c); // Вывод в изображение
                }
            }
            panImg3.BackgroundImage = img3;
        }
        void Median() // Функция медианного сглаживания
        {
            c = new Color();
            img4 = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            PicMed = new double[height, width];
            ForPic3 = new double[height + 2, width + 2];
            window3(PicNoise);
            double[] lSort;
            double[] lSorted;
            double minW = 256;
            int indMin = 0;
            for (int i = 1; i < height + 1; i++) // Рассчет медианы окрестности
            {
                for (int j = 1; j < width + 1; j++)
                {
                    lSort = new double[9] { ForPic3[i - 1, j - 1], ForPic3[i - 1, j],
                        ForPic3[i - 1, j + 1], ForPic3[i, j - 1], ForPic3[i, j],
                    ForPic3[i, j + 1], ForPic3[i + 1, j - 1], ForPic3[i + 1, j], ForPic3[i + 1, j + 1]};
                    lSorted = new double[9];
                    
                    for (int k = 0; k< 9; k++)
                    {
                        for(int l = 0; l < 9; l++)
                        {
                            if(lSort[l] < minW)
                            {
                                minW = lSort[l];
                                indMin = l;
                            }
                        }
                        lSorted[k] = minW;
                        lSort[indMin] = 256;
                        minW = 256;
                    }
                    PicMed[i - 1, j - 1] = lSorted[4];
                    c = Color.FromArgb(Convert.ToInt32(PicMed[i - 1, j - 1]), Convert.ToInt32(PicMed[i - 1, j - 1]), Convert.ToInt32(PicMed[i - 1, j - 1]));
                    img4.SetPixel(j - 1, i - 1, c); // Вывод в изображение
                }
            }
            panImg4.BackgroundImage = img4;
        }
        void Sharpness() // Функуия резкости изображения 
        {
            c = new Color();
            ForPic3 = new double[height + 2, width + 2];
            ForPic5 = new double[height + 4, width + 4];
            img5 = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            img5_1 = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            img5_2 = new Bitmap(width + 2, height + 2, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            PicSharp = new double[height, width];
            PicSharp1 = new double[height, width];
            PicSharp2 = new double[height+2, width+2];
            window3(PicLine);
            for (int i = 1; i < height + 1; i++) // Рассчет резкости после линейного сглаживания 3х3 (равные веса)
            {
                for (int j = 1; j < width + 1; j++)
                {
                    PicSharp[i - 1, j - 1] = ForPic3[i - 1, j - 1] * winSharp[0]
                        + ForPic3[i - 1, j] * winSharp[1]
                        + ForPic3[i - 1, j + 1] * winSharp[2]
                        + ForPic3[i, j - 1] * winSharp[3]
                        + ForPic3[i, j] * winSharp[4]
                        + ForPic3[i, j + 1] * winSharp[5]
                        + ForPic3[i + 1, j - 1] * winSharp[6]
                        + ForPic3[i + 1, j] * winSharp[7]
                        + ForPic3[i + 1, j + 1] * winSharp[8];
                    if (PicSharp[i - 1, j - 1] > 255) PicSharp[i - 1, j - 1] = 255;
                    if (PicSharp[i - 1, j - 1] < 0) PicSharp[i - 1, j - 1] = 0;
                    c = Color.FromArgb(Convert.ToInt32(PicSharp[i - 1, j - 1]), Convert.ToInt32(PicSharp[i - 1, j - 1]), Convert.ToInt32(PicSharp[i - 1, j - 1]));
                    img5.SetPixel(j - 1, i - 1, c); // Вывод в изображение
                }
            }
            panImg5.BackgroundImage = img5;

            ForPic3 = new double[height + 2, width + 2];
            window3(PicLine1);
            for (int i = 1; i < height + 1; i++) // Рассчет резкости после линейного сглаживания 3х3 (взвешанные веса)
            {
                for (int j = 1; j < width + 1; j++)
                {
                    PicSharp1[i - 1, j - 1] = PicGray[i - 1, j - 1] - (ForPic3[i - 1, j - 1] * winSharp[0]
                        + ForPic3[i - 1, j] * winSharp[1]
                        + ForPic3[i - 1, j + 1] * winSharp[2]
                        + ForPic3[i, j - 1] * winSharp[3]
                        + ForPic3[i, j] * winSharp[4]
                        + ForPic3[i, j + 1] * winSharp[5]
                        + ForPic3[i + 1, j - 1] * winSharp[6]
                        + ForPic3[i + 1, j] * winSharp[7]
                        + ForPic3[i + 1, j + 1] * winSharp[8]);
                    if (PicSharp1[i - 1, j - 1] > 255) PicSharp1[i - 1, j - 1] = 255;
                    if (PicSharp1[i - 1, j - 1] < 0) PicSharp1[i - 1, j - 1] = 0;
                    c = Color.FromArgb(Convert.ToInt32(PicSharp1[i - 1, j - 1]), Convert.ToInt32(PicSharp1[i - 1, j - 1]), Convert.ToInt32(PicSharp1[i - 1, j - 1]));
                    img5_1.SetPixel(j - 1, i - 1, c); // Вывод в изображение
                }
            }
            panImg5_1.BackgroundImage = img5_1;

            window5(PicLine2);
            for (int i = 1; i < height + 2; i++) // Рассчет резкости после линейного сглаживания 5х5 (взвешанные веса)
            {
                for (int j = 1; j < width + 2; j++)
                {
                    PicSharp2[i - 1, j - 1] = ForPic5[i - 1, j - 1] * winSharp[0]
                        + ForPic5[i - 1, j] * winSharp[1]
                        + ForPic5[i - 1, j + 1] * winSharp[2]
                        + ForPic5[i, j - 1] * winSharp[3]
                        + ForPic5[i, j] * winSharp[4]
                        + ForPic5[i, j + 1] * winSharp[5]
                        + ForPic5[i + 1, j - 1] * winSharp[6]
                        + ForPic5[i + 1, j] * winSharp[7]
                        + ForPic5[i + 1, j + 1] * winSharp[8];
                    if (PicSharp2[i - 1, j - 1] > 255) PicSharp2[i - 1, j - 1] = 255;
                    if (PicSharp2[i - 1, j - 1] < 0) PicSharp2[i - 1, j - 1] = 0;
                    c = Color.FromArgb(Convert.ToInt32(PicSharp2[i - 1, j - 1]), Convert.ToInt32(PicSharp2[i - 1, j - 1]), Convert.ToInt32(PicSharp2[i - 1, j - 1]));
                    img5_2.SetPixel(j - 1, i - 1, c); // Вывод в изображение
                }
            }
            panImg5_2.BackgroundImage = img5_2;
        }
        private void BuFunc_Click(object sender, EventArgs e) // Нажатие кнопки рассчета
        {
            FuncRectangle();
            Linear();
            Noise();
            Median();
            Sharpness();
            buSave.Enabled = true;
        }

        private void BuSave_Click(object sender, EventArgs e) // Нажатие кнопки сохранения
        {
            SaveFileDialog sfd = new SaveFileDialog(); // Сохранение изображения 1
            sfd.Filter = "Рисунок .jpg | *.jpg";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                img1.Save(sfd.FileName);
            }
            sfd = new SaveFileDialog(); // Сохранение изображения 2
            sfd.Filter = "Рисунок .jpg | *.jpg";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                img2.Save(sfd.FileName);
            }
            sfd = new SaveFileDialog(); // Сохранение изображения 2_1
            sfd.Filter = "Рисунок .jpg | *.jpg";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                img2_1.Save(sfd.FileName);
            }
            sfd = new SaveFileDialog(); // Сохранение изображения 2_2
            sfd.Filter = "Рисунок .jpg | *.jpg";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                img2_2.Save(sfd.FileName);
            }
            sfd = new SaveFileDialog(); // Сохранение изображения 3
            sfd.Filter = "Рисунок .jpg | *.jpg";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                img3.Save(sfd.FileName);
            }
            sfd = new SaveFileDialog(); // Сохранение изображения 4
            sfd.Filter = "Рисунок .jpg | *.jpg";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                img4.Save(sfd.FileName);
            }
            sfd = new SaveFileDialog(); // Сохранение изображения 5
            sfd.Filter = "Рисунок .jpg | *.jpg";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                img5.Save(sfd.FileName);
            }
            sfd = new SaveFileDialog(); // Сохранение изображения 5_1
            sfd.Filter = "Рисунок .jpg | *.jpg";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                img5_1.Save(sfd.FileName);
            }
            sfd = new SaveFileDialog(); // Сохранение изображения 5_2
            sfd.Filter = "Рисунок .jpg | *.jpg";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                img5_2.Save(sfd.FileName);
            }
        }
    }
}
