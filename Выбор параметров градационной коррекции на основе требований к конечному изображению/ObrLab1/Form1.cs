using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace ObrLab1
{
    public partial class fm : Form
    {
        public fm()
        {
            InitializeComponent();
            cmbType.SelectedIndex = 0;
        }
        List<string> FileName = new List<string>();
        int height, width; // Длина и ширина изображения
        Color[,] Pic; // Исходный массив цветов изображения
        double[,] PicGray; // Массив для расчетов
        double max; // Максимальная и минимальная светлота исходного изображения
        double min;
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
        /// Функция перевода изображения в GrayScale
        /// </summary>
        private void GrayScale()
        {
            Pic = GetBitMapColorMatrix(FileName[0]); // Получение массива цветов изображения
            PicGray = new double[width, height];
            max = 0;
            min = 255;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    PicGray[i, j] = 0.299 * Pic[i, j].R + 0.587 * Pic[i, j].G + 0.114 * Pic[i, j].B; // Перевод в оттенки серого
                    if (max <= PicGray[i, j]) // Расчет максимального значения массива для дальнейших функций
                    {
                        max = PicGray[i, j];
                    }
                    if (min >= PicGray[i, j]) // Расчет минимального значения массива для дальнейших функций
                    {
                        min = PicGray[i, j];
                    }
                }
            }
            laK.Text = Convert.ToInt32(max - min).ToString();
        }
        /// <summary>
        /// Функция получения гистограммы изображения
        /// </summary>
        /// <param name="pic">Массив светлот</param>
        /// <returns>Гистограмма изображения</returns>
        private double[] Gistogramm(double[,] pic)
        {
            double[] Gist = new double[256];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Gist[Convert.ToInt32(Math.Round(pic[i, j]))]++;
                }
            }
            for(int i = 0; i < Gist.Length; i++)
            {
                Gist[i] = Gist[i]/(height*width);
            }
            return Gist;
        }
        /// <summary>
        /// Функция визуального построения гистограммы
        /// </summary>
        /// <param name="z">Элемент интерфейса (ZedGraphControl)</param>
        /// <param name="g">Гистограмма изображения</param>
        private void DrawGraph(ZedGraphControl z, double[] g)
        {
            // Получим панель для рисования
            GraphPane pane = z.GraphPane;
            // Очистим список кривых на тот случай, если до этого сигналы уже были нарисованы
            pane.CurveList.Clear();
            if (z.Tag.ToString() == "0") pane.Title.Text = "GrayScale";
            else pane.Title.Text = "Calculated";
            int itemscount = g.Length;
            // Подписи под столбиками
            string[] names = new string[itemscount];
            // Высота столбиков
            double[] values = new double[itemscount];
            // Заполним данные
            for (int i = 0; i < itemscount; i++)
            {
                names[i] = string.Format("{0}", i + 1);
                values[i] = g[i];
            }
            // Создадим кривую-гистограмму
            // Первый параметр - название кривой для легенды
            // Второй параметр - значения для оси X, т.к. у нас по этой оси будет идти текст, а функция ожидает тип параметра double[], то пока передаем null
            // Третий параметр - значения для оси Y
            // Четвертый параметр - цвет
            BarItem curve = pane.AddBar("Гистограмма", null, values, Color.Blue);
            // Настроим ось X так, чтобы она отображала текстовые данные
            pane.XAxis.Type = AxisType.Text;
            // Уставим для оси наши подписи
            pane.XAxis.Scale.TextLabels = names;
            // Вызываем метод AxisChange (), чтобы обновить данные об осях.
            z.AxisChange();
            // Обновляем график
            z.Invalidate();
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
                panImg.BackgroundImage = Image.FromFile(OPF.FileName); // Отображение изображения на форме
                GrayScale();
                DrawGraph(zedGraphGray, Gistogramm(PicGray));
                buCalc.Enabled = true; //Включение элементов интерфейса
                cmbType.Enabled = true;
                tbPow.Enabled = true;
                numBottom.Enabled = true;
                numTop.Enabled = true;
            }
            else
            {
                return;
            }
        }
        /// <summary>
        /// Кнопка рассчета методов преобразования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buCalc_Click(object sender, EventArgs e)
        {
            Bitmap picc = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            double[,] PicCalc = new double[width, height];
            Color c = new Color();
            double C;
            double min1 = 255;
            double max1 = 0;
            switch (cmbType.SelectedIndex)
            {
                case 0: // Логарифмическое преобразование
                    C = 255 / (Math.Log10(1 + max)); // Рассчет константы C
                    for (int i = 0; i < width; i++)
                    {
                        for (int j = 0; j < height; j++)
                        {
                            PicCalc[i, j] = C * Math.Log10(1 + PicGray[i, j]); // Рассчет логарифмического преобразования
                            c = Color.FromArgb(Convert.ToInt32(Math.Round(PicCalc[i, j])), Convert.ToInt32(Math.Round(PicCalc[i, j])), Convert.ToInt32(Math.Round(PicCalc[i, j])));
                            picc.SetPixel(i, j, c); // Вывод в изображение
                            if (max1 <= PicCalc[i, j]) // Расчет максимального значения массива
                            {
                                max1 = PicCalc[i, j];
                            }
                            if (min1 >= PicCalc[i, j]) // Расчет минимального значения массива
                            {
                                min1 = PicCalc[i, j];
                            }
                        }
                    }
                    break;
                case 1: // Степенное преобразование
                    C = 255; // Константа С
                    for (int i = 0; i < width; i++)
                    {
                        for (int j = 0; j < height; j++)
                        {
                            PicCalc[i, j] = C * Math.Pow(PicGray[i, j] / 255, Convert.ToDouble(tbPow.Text)); // Рассчет степенного преобразования
                            c = Color.FromArgb(Convert.ToInt32(Math.Round(PicCalc[i, j])), Convert.ToInt32(Math.Round(PicCalc[i, j])), Convert.ToInt32(Math.Round(PicCalc[i, j])));
                            picc.SetPixel(i, j, c); // Вывод в изображение
                            if (max1 <= PicCalc[i, j]) // Расчет максимального значения массива
                            {
                                max1 = PicCalc[i, j];
                            }
                            if (min1 >= PicCalc[i, j]) // Расчет минимального значения массива
                            {
                                min1 = PicCalc[i, j];
                            }
                        }
                    }
                    break;
                case 2: // Нормализация
                    double b = (Convert.ToDouble(numTop.Value.ToString()) - Convert.ToDouble(numBottom.Value.ToString())) / (max - min); // Коэффициенты нормализации
                    double a = Convert.ToDouble(numBottom.Value.ToString()) - min * b;
                    for (int i = 0; i < width; i++)
                    {
                        for (int j = 0; j < height; j++)
                        {
                            PicCalc[i, j] = a + b * PicGray[i, j]; // Нормализация пикселя
                            c = Color.FromArgb(Convert.ToInt32(Math.Round(PicCalc[i, j])), Convert.ToInt32(Math.Round(PicCalc[i, j])), Convert.ToInt32(Math.Round(PicCalc[i, j])));
                            picc.SetPixel(i, j, c); // Вывод в изображение
                            if (max1 <= PicCalc[i, j]) // Расчет максимального значения массива
                            {
                                max1 = PicCalc[i, j];
                            }
                            if (min1 >= PicCalc[i, j]) // Расчет минимального значения массива
                            {
                                min1 = PicCalc[i, j];
                            }
                        }
                    }
                    break;
                case 3: // Эквализация
                    double chance; // Параметр эквализации (сумма вероятностей для определенного пикселя)
                    double[] Gist = Gistogramm(PicGray);
                    for (int i = 0; i < width; i++)
                    {
                        for (int j = 0; j < height; j++)
                        {
                            chance = 0;
                            for (int k = 0; k < PicGray[i, j]; k++)
                            {
                                chance += Gist[k]; // Рассчет параметра
                            }
                            PicCalc[i, j] = (Gist.Length - 1) * chance; // Вычисление эквализации
                            c = Color.FromArgb(Convert.ToInt32(Math.Round(PicCalc[i, j])), Convert.ToInt32(Math.Round(PicCalc[i, j])), Convert.ToInt32(Math.Round(PicCalc[i, j])));
                            picc.SetPixel(i, j, c); // Вывод в изображение
                            if (max1 <= PicCalc[i, j]) // Расчет максимального значения массива
                            {
                                max1 = PicCalc[i, j];
                            }
                            if (min1 >= PicCalc[i, j]) // Расчет минимального значения массива
                            {
                                min1 = PicCalc[i, j];
                            }
                        }
                    }
                    break;
            }
            laK1.Text = Convert.ToInt32(max1 - min1).ToString();
            panCalc.BackgroundImage = picc;
            DrawGraph(zedGraphCalc, Gistogramm(PicCalc));
            buSave.Enabled = true;
        }
        /// <summary>
        /// Кнопка сохранения полученого изображения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog(); // Сохранение изображения
            sfd.Filter = "Рисунок .jpg | *.jpg";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                panCalc.BackgroundImage.Save(sfd.FileName);
            }
        }
    }
}
