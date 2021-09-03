using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tech5
{
    public partial class fm : Form
    {
        public fm()
        {
            InitializeComponent();
            cmbFilter.SelectedIndex = 0;
            cmbAlg.SelectedIndex = 0;
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
        /// Массив пикселей загруженной картинки
        /// </summary>
        Color[,] Pic;
        /// <summary>
        /// Массив пикселей Grayscale
        /// </summary>
        double[,] PicGr;
        /// <summary>
        /// Объект класса Color
        /// </summary>
        Color c;
        /// <summary>
        /// Функция преобразования изображения в массив пикселей RGB
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
        /// <summary>
        /// Функция дебайеризации изображения
        /// </summary>
        /// <param name="PicGray">Черно-белое ихображение</param>
        /// <param name="type">Тип фильтра</param>
        /// <param name="alg">Тип алгоритма</param>
        /// <returns></returns>
        Bitmap Debayerization(double[,] PicGray, int type, int alg)
        {
            Bitmap Deb;
            int widthD = width;
            int heightD = height;
            c = new Color();
            if (alg == 0) // 0. Суперпиксель
            {
                if (widthD % 2 == 1 || heightD % 2 == 1) // Приведение изображения к четному количеству пикселей по сторонам
                {
                    if (widthD % 2 == 1) widthD++; 
                    if (heightD % 2 == 1) heightD++;
                    double[,] PicGrayNew = new double[widthD, heightD];
                    for (int i = 0; i < widthD; i++)
                    {
                        for (int j = 0; j < heightD; j++)
                        {
                            if(j == heightD - 1)
                            {
                                if(i == widthD - 1)
                                {
                                    PicGrayNew[i, j] = PicGray[i - 2, j - 2];
                                }
                                else
                                {
                                    PicGrayNew[i, j] = PicGray[i, j - 2];
                                }
                            }
                            else
                            {
                                if (i == widthD - 1)
                                {
                                    PicGrayNew[i, j] = PicGray[i - 2, j];
                                }
                                else
                                {
                                    PicGrayNew[i, j] = PicGray[i, j];
                                }
                            }
                        }
                    }
                    PicGray = new double[widthD, heightD];
                    PicGray = PicGrayNew;
                }
                Deb = new Bitmap(widthD / 2, heightD / 2, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                for(int i = 0; i < widthD; i++) // Суперпиксельное преобразование
                {
                    if (i % 2 == 0)
                    {
                        for (int j = 0; j < heightD; j++)
                        {
                            if (j % 2 == 0)
                            {
                                switch (type) // Типы фильтров
                                {
                                    case 0:
                                        c = Color.FromArgb(Convert.ToInt32(Math.Round(PicGray[i, j])),
                                            Convert.ToInt32(Math.Round((PicGray[i + 1, j] + PicGray[i, j + 1]) / 2)),
                                            Convert.ToInt32(Math.Round(PicGray[i + 1, j + 1])));
                                        break;
                                    case 1:
                                        c = Color.FromArgb(Convert.ToInt32(Math.Round(PicGray[i + 1, j + 1])),
                                            Convert.ToInt32(Math.Round((PicGray[i + 1, j] + PicGray[i, j + 1]) / 2)),
                                            Convert.ToInt32(Math.Round(PicGray[i, j])));
                                        break;
                                    case 2:
                                        c = Color.FromArgb(Convert.ToInt32(Math.Round(PicGray[i, j + 1])),
                                            Convert.ToInt32(Math.Round((PicGray[i, j] + PicGray[i + 1, j + 1]) / 2)),
                                            Convert.ToInt32(Math.Round(PicGray[i + 1, j])));
                                        break;
                                    case 3:
                                        c = Color.FromArgb(Convert.ToInt32(Math.Round(PicGray[i + 1, j])),
                                            Convert.ToInt32(Math.Round((PicGray[i, j] + PicGray[i + 1, j + 1]) / 2)),
                                            Convert.ToInt32(Math.Round(PicGray[i, j + 1])));
                                        break;
                                }
                                Deb.SetPixel(i/2, j/2, c);
                            }
                        }
                    }
                }
            }
            else // 1. Билинейная интерполяция
            {
                Deb = new Bitmap(widthD, heightD, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                double[,] ForPic3;
                ForPic3 = new double[widthD + 2, heightD + 2];
                for (int i = 0; i < widthD + 2; i++) // Добавление рамки для рассчета
                {
                    for (int j = 0; j < heightD + 2; j++)
                    {
                        if (i == 0)
                        {
                            if (j == 0)
                            {
                                ForPic3[i, j] = PicGray[i + 1, j + 1];
                            }
                            else
                            {
                                if (j == heightD + 1)
                                {
                                    ForPic3[i, j] = PicGray[i + 1, j - 3];
                                }
                                else
                                {
                                    ForPic3[i, j] = PicGray[i + 1, j - 1];
                                }
                            }
                        }
                        else
                        {
                            if (i == widthD + 1)
                            {
                                if (j == 0)
                                {
                                    ForPic3[i, j] = PicGray[i - 3, j + 1];
                                }
                                else
                                {
                                    if (j == heightD + 1)
                                    {
                                        ForPic3[i, j] = PicGray[i - 4, j - 4];
                                    }
                                    else
                                    {
                                        ForPic3[i, j] = PicGray[i - 3, j - 1];
                                    }
                                }
                            }
                            else
                            {
                                if (j == 0)
                                {
                                    ForPic3[i, j] = PicGray[i - 1, j + 1];
                                }
                                else
                                {
                                    if (j == heightD + 1)
                                    {
                                        ForPic3[i, j] = PicGray[i - 1, j - 3];
                                    }
                                    else
                                    {
                                        ForPic3[i, j] = PicGray[i - 1, j - 1];
                                    }
                                }
                            }
                        }
                    }
                }
                for (int i = 1; i < widthD + 1; i++) // Преобразование с билинейной интерполяцией
                {
                    for (int j = 1; j < heightD + 1; j++)
                    {
                        switch (type) // Типы фильтров
                        {
                            case 0:
                                if (i % 2 == 0)
                                {
                                    if (j % 2 == 0)
                                    {
                                        c = Color.FromArgb(Convert.ToInt32(Math.Round((ForPic3[i - 1, j - 1] + ForPic3[i - 1, j + 1] + ForPic3[i + 1, j - 1] + ForPic3[i + 1, j + 1]) / 4)),
                                    Convert.ToInt32(Math.Round((ForPic3[i + 1, j] + ForPic3[i, j + 1] + ForPic3[i - 1, j] + ForPic3[i, j - 1]) / 4)),
                                    Convert.ToInt32(Math.Round(ForPic3[i, j]))); //Blue
                                    }
                                    else
                                    {
                                        c = Color.FromArgb(Convert.ToInt32(Math.Round((ForPic3[i - 1, j] + ForPic3[i + 1, j]) / 2)),
                                    Convert.ToInt32(Math.Round(ForPic3[i, j])),
                                    Convert.ToInt32(Math.Round((ForPic3[i, j - 1] + ForPic3[i, j + 1]) / 2))); // Green 1
                                    }
                                }
                                else
                                {
                                    if (j % 2 == 0)
                                    {
                                        c = Color.FromArgb(Convert.ToInt32(Math.Round((ForPic3[i, j - 1] + ForPic3[i, j + 1]) / 2)),
                                    Convert.ToInt32(Math.Round(ForPic3[i, j])),
                                    Convert.ToInt32(Math.Round((ForPic3[i - 1, j] + ForPic3[i + 1, j]) / 2))); // Green 2
                                    }
                                    else
                                    {
                                        c = Color.FromArgb(Convert.ToInt32(Math.Round(ForPic3[i, j])),
                                    Convert.ToInt32(Math.Round((ForPic3[i + 1, j] + ForPic3[i, j + 1] + ForPic3[i - 1, j] + ForPic3[i, j - 1]) / 4)),
                                    Convert.ToInt32(Math.Round((ForPic3[i - 1, j - 1] + ForPic3[i - 1, j + 1] + ForPic3[i + 1, j - 1] + ForPic3[i + 1, j + 1]) / 4))); // Red
                                    }
                                }
                                break;
                            case 1:
                                if (i % 2 == 0)
                                {
                                    if (j % 2 == 0)
                                    {
                                        c = Color.FromArgb(Convert.ToInt32(Math.Round(ForPic3[i, j])),
                                    Convert.ToInt32(Math.Round((ForPic3[i + 1, j] + ForPic3[i, j + 1] + ForPic3[i - 1, j] + ForPic3[i, j - 1]) / 4)),
                                    Convert.ToInt32(Math.Round((ForPic3[i - 1, j - 1] + ForPic3[i - 1, j + 1] + ForPic3[i + 1, j - 1] + ForPic3[i + 1, j + 1]) / 4))); // Red
                                    }
                                    else
                                    {
                                        c = Color.FromArgb(Convert.ToInt32(Math.Round((ForPic3[i, j - 1] + ForPic3[i, j + 1]) / 2)),
                                    Convert.ToInt32(Math.Round(ForPic3[i, j])),
                                    Convert.ToInt32(Math.Round((ForPic3[i - 1, j] + ForPic3[i + 1, j]) / 2))); // Green 2
                                    }
                                }
                                else
                                {
                                    if (j % 2 == 0)
                                    {
                                        c = Color.FromArgb(Convert.ToInt32(Math.Round((ForPic3[i - 1, j] + ForPic3[i + 1, j]) / 2)),
                                    Convert.ToInt32(Math.Round(ForPic3[i, j])),
                                    Convert.ToInt32(Math.Round((ForPic3[i, j - 1] + ForPic3[i, j + 1]) / 2))); // Green 1
                                    }
                                    else
                                    {
                                        c = Color.FromArgb(Convert.ToInt32(Math.Round((ForPic3[i - 1, j - 1] + ForPic3[i - 1, j + 1] + ForPic3[i + 1, j - 1] + ForPic3[i + 1, j + 1]) / 4)),
                                    Convert.ToInt32(Math.Round((ForPic3[i + 1, j] + ForPic3[i, j + 1] + ForPic3[i - 1, j] + ForPic3[i, j - 1]) / 4)),
                                    Convert.ToInt32(Math.Round(ForPic3[i, j]))); //Blue
                                    }
                                }
                                break;
                            case 2:
                                if (i % 2 == 0)
                                {
                                    if (j % 2 == 0)
                                    {
                                        c = Color.FromArgb(Convert.ToInt32(Math.Round((ForPic3[i - 1, j] + ForPic3[i + 1, j]) / 2)),
                                    Convert.ToInt32(Math.Round(ForPic3[i, j])),
                                    Convert.ToInt32(Math.Round((ForPic3[i, j - 1] + ForPic3[i, j + 1]) / 2))); // Green 1
                                    }
                                    else
                                    {
                                        c = Color.FromArgb(Convert.ToInt32(Math.Round((ForPic3[i - 1, j - 1] + ForPic3[i - 1, j + 1] + ForPic3[i + 1, j - 1] + ForPic3[i + 1, j + 1]) / 4)),
                                    Convert.ToInt32(Math.Round((ForPic3[i + 1, j] + ForPic3[i, j + 1] + ForPic3[i - 1, j] + ForPic3[i, j - 1]) / 4)),
                                    Convert.ToInt32(Math.Round(ForPic3[i, j]))); //Blue
                                    }
                                }
                                else
                                {
                                    if (j % 2 == 0)
                                    {
                                        c = Color.FromArgb(Convert.ToInt32(Math.Round(ForPic3[i, j])),
                                    Convert.ToInt32(Math.Round((ForPic3[i + 1, j] + ForPic3[i, j + 1] + ForPic3[i - 1, j] + ForPic3[i, j - 1]) / 4)),
                                    Convert.ToInt32(Math.Round((ForPic3[i - 1, j - 1] + ForPic3[i - 1, j + 1] + ForPic3[i + 1, j - 1] + ForPic3[i + 1, j + 1]) / 4))); // Red
                                    }
                                    else
                                    {
                                        c = Color.FromArgb(Convert.ToInt32(Math.Round((ForPic3[i, j - 1] + ForPic3[i, j + 1]) / 2)),
                                    Convert.ToInt32(Math.Round(ForPic3[i, j])),
                                    Convert.ToInt32(Math.Round((ForPic3[i - 1, j] + ForPic3[i + 1, j]) / 2))); // Green 2
                                    }
                                }
                                break;
                            case 3:
                                if (i % 2 == 0)
                                {
                                    if (j % 2 == 0)
                                    {
                                        c = Color.FromArgb(Convert.ToInt32(Math.Round((ForPic3[i, j - 1] + ForPic3[i, j + 1]) / 2)),
                                    Convert.ToInt32(Math.Round(ForPic3[i, j])),
                                    Convert.ToInt32(Math.Round((ForPic3[i - 1, j] + ForPic3[i + 1, j]) / 2))); // Green 2

                                    }
                                    else
                                    {
                                        c = Color.FromArgb(Convert.ToInt32(Math.Round(ForPic3[i, j])),
                                    Convert.ToInt32(Math.Round((ForPic3[i + 1, j] + ForPic3[i, j + 1] + ForPic3[i - 1, j] + ForPic3[i, j - 1]) / 4)),
                                    Convert.ToInt32(Math.Round((ForPic3[i - 1, j - 1] + ForPic3[i - 1, j + 1] + ForPic3[i + 1, j - 1] + ForPic3[i + 1, j + 1]) / 4))); // Red

                                    }
                                }
                                else
                                {
                                    if (j % 2 == 0)
                                    {
                                        c = Color.FromArgb(Convert.ToInt32(Math.Round((ForPic3[i - 1, j - 1] + ForPic3[i - 1, j + 1] + ForPic3[i + 1, j - 1] + ForPic3[i + 1, j + 1]) / 4)),
                                    Convert.ToInt32(Math.Round((ForPic3[i + 1, j] + ForPic3[i, j + 1] + ForPic3[i - 1, j] + ForPic3[i, j - 1]) / 4)),
                                    Convert.ToInt32(Math.Round(ForPic3[i, j]))); //Blue
                                    }
                                    else
                                    {
                                        c = Color.FromArgb(Convert.ToInt32(Math.Round((ForPic3[i - 1, j] + ForPic3[i + 1, j]) / 2)),
                                    Convert.ToInt32(Math.Round(ForPic3[i, j])),
                                    Convert.ToInt32(Math.Round((ForPic3[i, j - 1] + ForPic3[i, j + 1]) / 2))); // Green 1
                                    }
                                }
                                break;
                        }
                        Deb.SetPixel(i - 1, j - 1, c);
                    }
                }
            }
            return Deb;
        }
        /// <summary>
        /// Загрузка изображения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuDownload_Click(object sender, EventArgs e)
        {
            FileName.Clear(); // Очистка массива путей
            OpenFileDialog OPF = new OpenFileDialog(); // Инициализация диалогового окна
            OPF.Filter = "PNG|*.png|JPEG|*.jpeg|JPG|*.jpg"; // Фильтр в диалоговом окне
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                FileName.Add(OPF.FileName); // Добавление в массив пути картинки
                Pic = GetBitMapColorMatrix(FileName[0]); // Сохраненич картинки в массив цветов
                panImg.BackgroundImage = Image.FromFile(OPF.FileName); // Отображение изображения на форме   
                buCalc.Enabled = true;
            }
            else
            {
                return;
            }
        }
        /// <summary>
        /// Кнопка рассчета (с преобразованием изображения в Grayscale)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuCalc_Click(object sender, EventArgs e)
        {
            PicGr = new double[width, height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    //PicGr[i, j] = 0.299 * Pic[i, j].R + 0.587 * Pic[i, j].G + 0.114 * Pic[i, j].B; // Перевод в оттенки серого
                    PicGr[i, j] = (Pic[i, j].R + Pic[i, j].G + Pic[i, j].B) / 3; // Перевод в оттенки серого
                }
            }
            panImgCalc.BackgroundImage = Debayerization(PicGr, cmbFilter.SelectedIndex,
            cmbAlg.SelectedIndex);
        }
        /// <summary>
        /// Кнопка сохранения изображения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog(); // Сохранение изображения
            sfd.Filter = "Рисунок .jpg | *.jpg";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                panImgCalc.BackgroundImage.Save(sfd.FileName);
            }
        }
    }
}
