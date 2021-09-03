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
using ZedGraph;

namespace TechLab1
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
        Color c; // Объект класса Color
        Color[,] Pic; // Исходный массив цветов изображения
        double[,] PicGray; // Массив GrayScale
        double[] str;
        List<string> FileName = new List<string>();
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
        /// Функция поворота изображения
        /// </summary>
        /// <param name="bmp">Изображение</param>
        /// <param name="angle">Угол</param>
        /// <returns>Повернутое изображение</returns>
        private Bitmap RotateImage(Bitmap bmp, float angle)
        {
            Bitmap rotatedImage = new Bitmap(bmp.Width, bmp.Height);
            rotatedImage.SetResolution(bmp.HorizontalResolution, bmp.VerticalResolution);
            using (Graphics g = Graphics.FromImage(rotatedImage))
            {
                // Установка точки поворота в центр матрицы
                g.TranslateTransform(bmp.Width / 2, bmp.Height / 2);
                // Поворот
                g.RotateTransform(angle);
                // Востановление точки поворота матрицы
                g.TranslateTransform(-bmp.Width / 2, -bmp.Height / 2);
                // Зарисовка изображения в Bitmap
                g.DrawImage(bmp, new Point(0, 0));
            }
            return rotatedImage;
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
                panImg.BackgroundImage = System.Drawing.Image.FromFile(OPF.FileName); // Отображение изображения на форм
            }
            else
            {
                return;
            }
            buRotate.Enabled = true;
            numAngle.Enabled = true;
        }
        /// <summary>
        /// Кнопка поворота изображения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buRotate_Click(object sender, EventArgs e)
        {
            Bitmap rot = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            PicGray = new double[width, height];
            str = new double[width];
            for (int i = 0; i < width; i++) // Копирование изображения для поворота
            {
                for (int j = 0; j < height; j++)
                {
                    PicGray[i,j] = (Pic[i, j].R + Pic[i, j].G + Pic[i, j].B) / 3;
                    c = Color.FromArgb(Convert.ToInt32(Math.Round(PicGray[i, j])),
                                    Convert.ToInt32(Math.Round(PicGray[i, j])),
                                    Convert.ToInt32(Math.Round(PicGray[i, j])));
                    rot.SetPixel(i, j, c);
                }
            }
            rot = RotateImage(rot, Convert.ToInt32(numAngle.Value.ToString())); // Поворот
            Color[,] colorMatrix = new Color[width, height];
            for (int i = 0; i < width; i++) // Усреденение столбцов светлот пикслелей 
            {
                double tmp = 0;
                int count = 1;
                for (int j = 0; j < height; j++)
                {
                    colorMatrix[i, j] = rot.GetPixel(i, j);
                    PicGray[i, j] = (colorMatrix[i, j].R + colorMatrix[i, j].G + colorMatrix[i, j].B) / 3;
                    if (PicGray[i, j] != 0)
                    {
                        tmp = tmp + PicGray[i, j];
                        count++;
                    }
                    
                }
                tmp = tmp / count;
                str[i] = tmp;
                for (int j = 0; j < height; j++)
                {

                    c = Color.FromArgb(Convert.ToInt32(Math.Round(tmp)),
                                    Convert.ToInt32(Math.Round(tmp)),
                                    Convert.ToInt32(Math.Round(tmp)));
                    rot.SetPixel(i, j, c);
                }
            }
            panRot.BackgroundImage = rot;
            buMTF.Enabled = true;
        }
        /// <summary>
        /// Кнопка рассчета ФПМ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buMTF_Click(object sender, EventArgs e)
        {
            Bitmap MTF = new Bitmap(width, width, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            double[] str1 = new double[width];
            for (int i = 0; i < width; i++) // Функция размытия линии
            {
                if (i == 0) str1[i] = 0;
                else str1[i] = Math.Abs(str[i] - str[i - 1]);
            }
            for (int i = 0; i < width; i++) // Заполнение изображения полученной функцией
            {
                for (int j = 0; j < width; j++)
                {
                    c = Color.FromArgb(Convert.ToInt32(Math.Round(str1[i])),
                                    Convert.ToInt32(Math.Round(str1[i])),
                                    Convert.ToInt32(Math.Round(str1[i])));
                    MTF.SetPixel(i, j, c);
                }
            }
            ComplexImage cImgSpec; // Создание комплексного изображения
            var gray = new AForge.Imaging.Filters.Grayscale(0.2125, 0.7154, 0.0721).Apply(MTF); // Преобразование изображение в GrayScale
            cImgSpec = ComplexImage.FromBitmap(gray); // Заполнение комплексного изображения
            cImgSpec.ForwardFourierTransform(); // Прямое Фурье преобразование
            MTF = cImgSpec.ToBitmap(); // Сохранение спектра в картинку
            int tmp;
            double pix;
            Color[,] colorMatrix = new Color[width, width];
            for (int i = 0; i < width; i++) // Поиск МПФ в двумерном изображении
            {
                tmp = 0;
                for (int j = 0; j < width; j++)
                {
                    colorMatrix[i, j] = MTF.GetPixel(i, j);
                    pix = (colorMatrix[i, j].R + colorMatrix[i, j].G + colorMatrix[i, j].B) / 3;
                    if (tmp < pix)
                    {
                        tmp = Convert.ToInt32(Math.Round(pix));
                    }
                }
                str1[i] = tmp;
            }
            DrawGraph(str1); // Вывод графика МПФ
            panMTF.BackgroundImage = MTF;
        }
        List<PointPairList> ob = new List<PointPairList>(); // Для рассчета графика МПФ объектива
        /// <summary>
        /// Функция создания графика МПФ
        /// </summary>
        /// <param name="str">Массив МПФ</param>
        private void DrawGraph(double[] str)
        {
            // Получим панель для рисования
            GraphPane pane = zedGraphMTF.GraphPane;
            pane.Title.Text = "Функция передачи модуляции";
            pane.XAxis.Title.Text = "Циклы/пиксели";
            pane.YAxis.Title.Text = "Модуляция";
            // Очистим список кривых на тот случай, если до этого сигналы уже были нарисованы
            pane.CurveList.Clear();
            // Создадим список точек
            PointPairList list = new PointPairList();
            PointPairList list1 = new PointPairList();
            // Заполняем список точек
            double x = 0;
            double max = str[64];
            for (int i = str.Length / 2; i < str.Length; i++)
            {
                // добавим в список точку
                list.Add(x, str[i]/max);
                list1.Add(x, 0.5);
                x = x + 0.00025;
            }
            pane.YAxis.Scale.Min = 0; // Границы
            pane.YAxis.Scale.Max = 1;
            pane.XAxis.Scale.Min = 0;
            pane.XAxis.Scale.Max = 0.002;
            // Создадим кривую с названием "Sinc",
            // которая будет рисоваться голубым цветом (Color.Blue),
            // Опорные точки выделяться не будут (SymbolType.None)
            LineItem myCurve = pane.AddCurve("ФПМ", list, Color.Blue, SymbolType.None);
            LineItem myCurve1 = pane.AddCurve("MTF50", list1, Color.Red, SymbolType.None);
            // Вызываем метод AxisChange (), чтобы обновить данные об осях.
            // В противном случае на рисунке будет показана только часть графика,
            // которая умещается в интервалы по осям, установленные по умолчанию
            zedGraphMTF.AxisChange();
            // Обновляем график
            zedGraphMTF.Invalidate();
            ob.Add(list);
        }
        /// <summary>
        /// Кнопка рассчета МПФ объектива (опасно! читай текст на графической форме)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buOb_Click(object sender, EventArgs e)
        {
            PointPairList list = new PointPairList();
            for (int i = 0; i < ob[0].Count; i++)
            {
                // добавим в список точку
                if (ob[1][i].Y == 0) ob[1][i].Y = 1;
                list.Add(i * 0.00025, ob[0][i].Y / ob[1][i].Y);
                if (list[i].Y > 1) list[i].Y = 1;
                if (list[i].Y < 0) list[i].Y = 0;
            }
            ob.Clear();
            // Получим панель для рисования
            GraphPane pane = zedGraphMTF.GraphPane;
            pane.Title.Text = "Функция передачи модуляции";
            pane.XAxis.Title.Text = "Циклы/пиксели";
            pane.YAxis.Title.Text = "Модуляция";
            // Очистим список кривых на тот случай, если до этого сигналы уже были нарисованы
            pane.CurveList.Clear();
            // Создадим список точек
            PointPairList list1 = new PointPairList();
            // Заполняем список точек
            double x = 0;
            for (int i = 0; i < list.Count; i++)
            {
                // добавим в список точку
                list1.Add(x, 0.5);
                x = x + 0.00025;
            }
            pane.YAxis.Scale.Min = 0;
            pane.YAxis.Scale.Max = 1;
            pane.XAxis.Scale.Min = 0;
            pane.XAxis.Scale.Max = 0.002;
            // Создадим кривую с названием "Sinc",
            // которая будет рисоваться голубым цветом (Color.Blue),
            // Опорные точки выделяться не будут (SymbolType.None)
            LineItem myCurve = pane.AddCurve("ФПМ", list, Color.Blue, SymbolType.None);
            LineItem myCurve1 = pane.AddCurve("MTF50", list1, Color.Red, SymbolType.None);
            // Вызываем метод AxisChange (), чтобы обновить данные об осях.
            // В противном случае на рисунке будет показана только часть графика,
            // которая умещается в интервалы по осям, установленные по умолчанию
            zedGraphMTF.AxisChange();
            // Обновляем график
            zedGraphMTF.Invalidate();
        }
    }
}
