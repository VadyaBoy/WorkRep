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

namespace Obr6
{
    public partial class fm : Form
    {
        public fm()
        {
            InitializeComponent();
            cmbType.SelectedIndex = 0;
            cmbParts.SelectedIndex = 0;
            cmbDirection.SelectedIndex = 0;
            cmbTypeC.SelectedIndex = 0;
            cmbTypeClaster.SelectedIndex = 0;
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
        double[] Gist; // Гистограмма GrayScale
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
        /// Функция пороговой обработки
        /// </summary>
        /// <param name="pic">Исходное изображение</param>
        /// <param name="t">Порог</param>
        /// <param name="t0">Дельта порога</param>
        /// <param name="type">Тип обработки</param>
        /// <param name="parts">Количество частей адаптивной обработки</param>
        void PorogObr(double[,] pic, int t, double t0, bool type, int parts)
        {
            double[,] PicCalc = new double[width, height];
            if(!type) // Простая обработка
            {
                for (int i = 0; i < width; i++) 
                {
                    for (int j = 0; j < height; j++)
                    {
                        if(pic[i, j] > t)
                        {
                            PicCalc[i, j] = 255;
                        }
                        else
                        {
                            PicCalc[i, j] = 0;
                        }
                    }
                }
            }
            else // Адаптивная обработка
            {
                int widthD = width;
                int heightD = height;
                double[,] PicGrayNew = Copy(PicGray);
                if (widthD % 2 == 1 || heightD % 2 == 1) // Приведение изображения к четному количеству пикселей по сторонам
                {
                    if (widthD % 2 == 1) widthD++;
                    if (heightD % 2 == 1) heightD++;
                    PicGrayNew = new double[widthD, heightD];
                    for (int i = 0; i < widthD; i++)
                    {
                        for (int j = 0; j < heightD; j++)
                        {
                            if (j == heightD - 1)
                            {
                                if (i == widthD - 1)
                                {
                                    PicGrayNew[i, j] = pic[i - 2, j - 2];
                                }
                                else
                                {
                                    PicGrayNew[i, j] = pic[i, j - 2];
                                }
                            }
                            else
                            {
                                if (i == widthD - 1)
                                {
                                    PicGrayNew[i, j] = pic[i - 2, j];
                                }
                                else
                                {
                                    PicGrayNew[i, j] = pic[i, j];
                                }
                            }
                        }
                    }
                    PicCalc = new double[widthD, heightD];
                }
                int iStart = 0; 
                int jStart = 0;
                int iStep = widthD / Convert.ToInt32(Math.Round(Math.Sqrt(parts))); 
                int jStep = heightD / Convert.ToInt32(Math.Round(Math.Sqrt(parts))); 
                int iFinish = iStep;
                int jFinish = jStep;

                List<double> T;
                double tprev;
                double G1;
                double G2;
                double G1count;
                double G2count;
                for(int n = 0; n < Math.Sqrt(parts); n++) // Рассчет адаптивной пороговой обработки
                {
                    jStart = 0;
                    jFinish = jStep;
                    for (int l = 0; l < Math.Sqrt(parts); l++)
                    {
                        T = new List<double>();
                        T.Add(0);
                        T.Add(t);
                        tprev = 0;
                        while (T.Last() - tprev > t0) // Вычисление порога
                        {
                            G1 = 0;
                            G2 = 0;
                            G1count = 0;
                            G2count = 0;
                            for (int i = iStart; i < iFinish; i++)
                            {
                                for (int j = jStart; j < jFinish; j++)
                                {
                                    if (PicGrayNew[i, j] < T.Last())
                                    {
                                        G1 += PicGrayNew[i, j];
                                        G1count++;
                                    }
                                    else
                                    {
                                        G2 += PicGrayNew[i, j];
                                        G2count++;
                                    }
                                }
                            }
                            G1 = G1 / G1count;
                            G2 = G2 / G2count;
                            tprev = T.Last();
                            T.Add(0.5 * (G1 + G2));
                        }

                        for (int i = iStart; i < iFinish; i++) // Заполнение части изображения
                        {
                            for (int j = jStart; j < jFinish; j++)
                            {
                                if (PicGrayNew[i, j] > T.Last())
                                {
                                    PicCalc[i, j] = 255;
                                }
                                else
                                {
                                    PicCalc[i, j] = 0;
                                }
                            }
                        }
                        jStart = jStart + jStep;
                        jFinish = jFinish + jStep;
                    }
                    iStart = iStart + iStep;
                    iFinish = iFinish + iStep;
                }
            }
            Bitmap por = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            for (int i = 0; i < width; i++) // Вывод изображения
            {
                for (int j = 0; j < height; j++)
                {
                    c = Color.FromArgb(Convert.ToInt32(Math.Round(PicCalc[i, j])),
                                    Convert.ToInt32(Math.Round(PicCalc[i, j])),
                                    Convert.ToInt32(Math.Round(PicCalc[i, j])));
                    por.SetPixel(i, j, c);
                }
            }
            panPorog.BackgroundImage = por;
        }
        /// <summary>
        /// Функция выделения контура
        /// </summary>
        /// <param name="Direction">Направление</param>
        /// <param name="type">Тип выделения</param>
        void Сontour(bool Direction, int type)
        {
            Bitmap con;
            double[,] PicCalc = new double[width - 2, height - 2]; // Массив расчета
            double procent = 0;
            double mean = 0;
            switch (type)
            {
                case 0: // Робертс
                    PicCalc = new double[width-1, height-1];
                    if(!Direction) // Горизонтальные
                    {
                        for (int i = 0; i < width - 1; i++)
                        {
                            for (int j = 0; j < height - 1; j++)
                            {
                                PicCalc[i, j] = -PicGray[i, j] + PicGray[i + 1, j + 1];
                                if (PicCalc[i, j] < 0)
                                {
                                    PicCalc[i, j] = 0;
                                }
                                if(PicCalc[i, j] != 0) mean += PicCalc[i, j];
                            }
                        }
                    }
                    else // Вертикальные
                    {
                        for (int i = 0; i < width - 1; i++)
                        {
                            for (int j = 0; j < height - 1; j++)
                            {
                                PicCalc[i, j] = -PicGray[i + 1, j] + PicGray[i, j + 1];
                                if (PicCalc[i, j] < 0)
                                {
                                    PicCalc[i, j] = 0;
                                }
                                if (PicCalc[i, j] != 0) mean += PicCalc[i, j];
                            }
                        }
                    }
                    mean = mean / PicCalc.Length;
                    con = new Bitmap(width-1, height-1, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    for (int i = 0; i < width-1; i++) // Вывод изображения
                    {
                        for (int j = 0; j < height-1; j++)
                        {
                            c = Color.FromArgb(Convert.ToInt32(Math.Round(PicCalc[i, j])),
                                            Convert.ToInt32(Math.Round(PicCalc[i, j])),
                                            Convert.ToInt32(Math.Round(PicCalc[i, j])));
                            con.SetPixel(i, j, c);
                        }
                    }
                    panCountur.BackgroundImage = con;
                    break;
                case 1: // Превитт
                    PicCalc = new double[width - 2, height - 2];
                    if (!Direction) // Горизонтальные
                    {
                        for (int i = 1; i < width - 2; i++)
                        {
                            for (int j = 1; j < height - 2; j++)
                            {
                                PicCalc[i, j] = -PicGray[i - 1, j - 1] - PicGray[i, j - 1]  - PicGray[i + 1, j - 1]
                                                + PicGray[i - 1, j + 1] + PicGray[i, j + 1] + PicGray[i + 1, j + 1];
                                if (PicCalc[i, j] < 0)
                                {
                                    PicCalc[i, j] = 0;
                                }
                                if (PicCalc[i, j] > 255) PicCalc[i, j] = 255;
                                if (PicCalc[i, j] != 0) mean += PicCalc[i, j];
                            }
                        }
                    }
                    else // Вертикальные
                    {
                        for (int i = 1; i < width - 2; i++)
                        {
                            for (int j = 1; j < height - 2; j++)
                            {
                                PicCalc[i, j] = -PicGray[i - 1, j - 1] - PicGray[i - 1, j] - PicGray[i - 1, j + 1]
                                                + PicGray[i + 1, j - 1] + PicGray[i + 1, j] + PicGray[i + 1, j + 1];
                                if (PicCalc[i, j] < 0)
                                {
                                    PicCalc[i, j] = 0;
                                }
                                if (PicCalc[i, j] > 255) PicCalc[i, j] = 255;
                                if (PicCalc[i, j] != 0) mean += PicCalc[i, j];
                            }
                        }
                    }
                    mean = mean / PicCalc.Length;
                    con = new Bitmap(width - 2, height - 2, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    for (int i = 0; i < width - 2; i++) // Вывод изображения
                    {
                        for (int j = 0; j < height - 2; j++)
                        {
                            c = Color.FromArgb(Convert.ToInt32(Math.Round(PicCalc[i, j])),
                                            Convert.ToInt32(Math.Round(PicCalc[i, j])),
                                            Convert.ToInt32(Math.Round(PicCalc[i, j])));
                            con.SetPixel(i, j, c);
                        }
                    }
                    panCountur.BackgroundImage = con;
                    break;
                case 2: // Собел
                    PicCalc = new double[width - 2, height - 2];
                    if (!Direction) // Горизонтальные
                    {
                        for (int i = 1; i < width - 2; i++)
                        {
                            for (int j = 1; j < height - 2; j++)
                            {
                                PicCalc[i, j] = -PicGray[i - 1, j - 1] - 2*PicGray[i, j - 1] - PicGray[i + 1, j - 1]
                                                + PicGray[i - 1, j + 1] + 2*PicGray[i, j + 1] + PicGray[i + 1, j + 1];
                                if (PicCalc[i, j] < 0)
                                {
                                    PicCalc[i, j] = 0;
                                }
                                if (PicCalc[i, j] > 255) PicCalc[i, j] = 255;
                                if (PicCalc[i, j] != 0) mean += PicCalc[i, j];
                            }
                        }
                    }
                    else // Вертикальные
                    {
                        for (int i = 1; i < width - 2; i++)
                        {
                            for (int j = 1; j < height - 2; j++)
                            {
                                PicCalc[i, j] = -PicGray[i - 1, j - 1] - 2*PicGray[i - 1, j] - PicGray[i - 1, j + 1]
                                                + PicGray[i + 1, j - 1] + 2*PicGray[i + 1, j] + PicGray[i + 1, j + 1];
                                if (PicCalc[i, j] < 0)
                                {
                                    PicCalc[i, j] = 0;
                                }
                                if (PicCalc[i, j] > 255) PicCalc[i, j] = 255;
                                if (PicCalc[i, j] != 0) mean += PicCalc[i, j];
                            }
                        }
                    }
                    mean = mean / PicCalc.Length;
                    con = new Bitmap(width - 2, height - 2, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    for (int i = 0; i < width - 2; i++) // Вывод изображения
                    {
                        for (int j = 0; j < height - 2; j++)
                        {
                            c = Color.FromArgb(Convert.ToInt32(Math.Round(PicCalc[i, j])),
                                            Convert.ToInt32(Math.Round(PicCalc[i, j])),
                                            Convert.ToInt32(Math.Round(PicCalc[i, j])));
                            con.SetPixel(i, j, c);
                        }
                    }
                    panCountur.BackgroundImage = con;
                    break;
                case 3: // Лапласиан гауссиана
                    PicCalc = new double[width - 4, height - 4];
                    for (int i = 2; i < width - 4; i++)
                    {
                        for (int j = 2; j < height - 4; j++)
                        {
                                PicCalc[i, j] = - PicGray[i, j - 2]
                                                - PicGray[i - 1, j - 1] - 2*PicGray[i, j - 1] - PicGray[i + 1, j - 1]
                                                - PicGray[i - 2, j] - 2*PicGray[i - 1, j] + 16 * PicGray[i, j] - 2 * PicGray[i + 1, j] - PicGray[i + 2, j]
                                                - PicGray[i - 1, j + 1] - 2 * PicGray[i, j + 1] - PicGray[i + 1, j + 1]
                                                - PicGray[i, j + 2];
                                if (PicCalc[i, j] < 0)
                                {
                                    PicCalc[i, j] = 0;
                                }
                                if (PicCalc[i, j] > 255) PicCalc[i, j] = 255;
                            if (PicCalc[i, j] != 0) mean += PicCalc[i, j];
                        }
                    }
                    mean = mean / PicCalc.Length;
                    con = new Bitmap(width - 4, height - 4, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    for (int i = 0; i < width - 4; i++) // Вывод изображения
                    {
                        for (int j = 0; j < height - 4; j++)
                        {
                            c = Color.FromArgb(Convert.ToInt32(Math.Round(PicCalc[i, j])),
                                            Convert.ToInt32(Math.Round(PicCalc[i, j])),
                                            Convert.ToInt32(Math.Round(PicCalc[i, j])));
                            con.SetPixel(i, j, c);
                        }
                    }
                    panCountur.BackgroundImage = con;
                    break;
            }
            foreach (double var in PicCalc) // Расчет площади
            {
                if (var >= mean) procent++;
            }
            procent = Math.Round((procent / PicCalc.Length)*100, 2);
            laCounturProcent.Text = "Процент контуров: " + procent.ToString() + " %";
        }
        /// <summary>
        /// Функция копирования двумерного массива
        /// </summary>
        /// <typeparam name="T">Класс</typeparam>
        /// <param name="array">Исходный массив</param>
        /// <returns>Новый массив</returns>
        static T[,] Copy<T>(T[,] array)
        {
            T[,] newArray = new T[array.GetLength(0), array.GetLength(1)];
            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                    newArray[i, j] = array[i, j];
            return newArray;
        }
        /// <summary>
        /// Функция кластеризации
        /// </summary>
        /// <param name="type">Тип</param>
        /// <param name="delta">Дельта</param>
        /// <returns>Кластеризованное изображение</returns>
        Bitmap Claster(int type, double delta)
        {
            double[,] PicCalc = Copy(PicGray);
            int x;
            int y;
            Bitmap claster;
            switch(type)
            {
                case 0: // Выращивание областей
                    Random rand = new Random();
                    
                    for (int r = 0; r < 50; r++)
                    {
                        x = rand.Next(0, width);
                        y = rand.Next(0, height);
                        for (int i = 0; i < width; i++)
                        {
                            for (int j = 0; j < height; j++)
                            {
                                if (Math.Abs(PicCalc[i, j] - PicCalc[x, y]) <= delta)
                                {
                                    PicCalc[i, j] = PicCalc[x, y];
                                }
                            }
                        }
                    }
                    break;
                case 1: // Раздлеление и слияние
                    for (int i = 0; i < width - 1; i++)
                    {
                        for (int j = 0; j < height - 1; j++)
                        {
                            if (Math.Abs(PicCalc[i, j] - (PicCalc[i + 1, j] + PicCalc[i, j + 1] + PicCalc[i + 1, j + 1])/3) <= delta)
                            {
                                PicCalc[i + 1, j] = PicCalc[i, j];
                                PicCalc[i, j + 1] = PicCalc[i, j];
                                PicCalc[i + 1, j + 1] = PicCalc[i, j];
                            }
                        }
                    }
                    break;
                case 2: // Водоразделы
                    bool grad;
                    double[,] PicCalc1 = new double[width,height];
                    for (int i = 1; i < width - 1; i++)
                    {
                        for (int j = 1; j < height - 1; j++)
                        {
                            x = i;
                            y = j;
                            grad = true;
                            while (grad && x > 0 && y > 0 && x < width - 1 && y < height - 1)
                            {
                                if(PicCalc[x,y] > PicCalc[x + 1, y])
                                {
                                    x++;
                                }
                                else
                                {
                                    if (PicCalc[x, y] > PicCalc[x - 1, y])
                                    {
                                        x--;
                                    }
                                    else
                                    {
                                        if (PicCalc[x, y] > PicCalc[x, y + 1])
                                        {
                                           y++;
                                        }
                                        else
                                        {
                                            if (PicCalc[x, y] > PicCalc[x, y - 1])
                                            {
                                                y--;
                                            }
                                            else
                                            {
                                                grad = !grad;
                                            }
                                        }
                                    }
                                }
                                PicCalc1[i, j] = PicCalc[x, y];
                            }
                            
                        }
                    }
                    PicCalc = PicCalc1;
                    break;
            }
            claster = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            for (int i = 0; i < width; i++) // Вывод изображения
            {
                for (int j = 0; j < height; j++)
                {
                    c = Color.FromArgb(Convert.ToInt32(Math.Round(PicCalc[i, j])),
                                    Convert.ToInt32(Math.Round(PicCalc[i, j])),
                                    Convert.ToInt32(Math.Round(PicCalc[i, j])));
                    claster.SetPixel(i, j, c);
                }
            }
            return claster;
        }
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
            Bitmap Gray = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            for (int i = 0; i < width; i++) // Вывод изображения GrayScale
            {
                for (int j = 0; j < height; j++)
                {
                    c = Color.FromArgb(Convert.ToInt32(Math.Round(PicGray[i, j])),
                                    Convert.ToInt32(Math.Round(PicGray[i, j])),
                                    Convert.ToInt32(Math.Round(PicGray[i, j])));
                    Gray.SetPixel(i, j, c);
                }
            }
            //SaveFileDialog sfd = new SaveFileDialog(); // Сохранение GrayScale
            //sfd.Filter = "Рисунок .jpg | *.jpg";
            //if (sfd.ShowDialog() == DialogResult.OK)
            //{
            //    Gray.Save(sfd.FileName);
            //}
            Gist = new double[256];
            for (int i = 0; i < width; i++) // Рассчет гистограммы Grayscale
            {
                for (int j = 0; j < height; j++)
                {
                    Gist[Convert.ToInt32(Math.Round(PicGray[i, j]))]++;
                }
            }
            StreamWriter sw = new StreamWriter("Assets/1.txt"); // Файлы для записи гистограмм
            sw.Write("");
            sw.Close();
            sw = new StreamWriter("Assets/1.txt", true);
            for (int i = 0; i < Gist.Length; i++) // Запись гистограммы в файл
            {
                sw.WriteLine((Gist[i] / (height * width)).ToString());
            }
            sw.Close();
            cmbType.Enabled = true; //Включение элементов интерфейса
            tbPorog.Enabled = true;
            numPorog.Enabled = true;
            buPorog.Enabled = true; 
            cmbParts.Enabled = true;
            cmbDirection.Enabled = true;
            cmbTypeC.Enabled = true;
            buCountur.Enabled = true;
            buClaster.Enabled = true;
            numClaster.Enabled = true;
            cmbTypeClaster.Enabled = true;
        }
        /// <summary>
        /// Кнопка пороговой обработки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buPorog_Click(object sender, EventArgs e)
        {
            PorogObr(PicGray, Convert.ToInt32(numPorog.Value.ToString()), Convert.ToDouble(tbPorog.Text), Convert.ToBoolean(cmbType.SelectedIndex), Convert.ToInt32(cmbParts.SelectedItem));
            buSavePorog.Enabled = true;
        }
        /// <summary>
        /// Кнопка сохранения пороговой обработки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buSavePorog_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog(); // Сохранение
            sfd.Filter = "Рисунок .jpg | *.jpg";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                panPorog.BackgroundImage.Save(sfd.FileName);
            }
        }
        /// <summary>
        /// Кнопка выделения контуров
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buCountur_Click(object sender, EventArgs e)
        {
            Сontour(Convert.ToBoolean(cmbDirection.SelectedIndex), Convert.ToInt32(cmbTypeC.SelectedIndex));
            buSaveCounter.Enabled = true;
        }
        /// <summary>
        /// Кнопка сохранения выделения контуров
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buSaveCounter_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog(); // Сохранение
            sfd.Filter = "Рисунок .jpg | *.jpg";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                panCountur.BackgroundImage.Save(sfd.FileName);
            }
        }
        /// <summary>
        /// Кнопка кластеризации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buClaster_Click(object sender, EventArgs e)
        {
            picClaster.Image = Claster(Convert.ToInt32(cmbTypeClaster.SelectedIndex), Convert.ToInt32(numClaster.Value.ToString()));
            buSaveClaster.Enabled = true;
        }
        /// <summary>
        /// Кнопка сохранения кластеризации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buSaveClaster_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog(); // Сохранение
            sfd.Filter = "Рисунок .jpg | *.jpg";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                picClaster.Image.Save(sfd.FileName);
            }
        }
    }
}
