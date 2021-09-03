using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using AForge.Imaging;

namespace Obr5
{
    public partial class fm : Form
    {
        public fm()
        {
            InitializeComponent();
            cmbF.SelectedIndex = 0;
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
        /// Кнопка загрузки изображения
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
                panImg.BackgroundImage = System.Drawing.Image.FromFile(OPF.FileName); // Отображение изображения на форме   
                height = panImg.BackgroundImage.Height;
                width = panImg.BackgroundImage.Width;
                buCalc.Enabled = true;
            }
            else
            {
                return;
            }
        }
        /// <summary>
        /// Кнопка рассчета спектра и востановленного изображения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuCalc_Click(object sender, EventArgs e)
        {
            ComplexImage cImgSpec; // Создание комплексного изображения
            var gray = new AForge.Imaging.Filters.Grayscale(0.2125, 0.7154, 0.0721).Apply(new Bitmap(panImg.BackgroundImage)); // Преобразование изображение в GrayScale
            cImgSpec = ComplexImage.FromBitmap(gray); // Заполнение комплексного изображения
            cImgSpec.ForwardFourierTransform(); // Прямое Фурье преобразование
            panSpectr.BackgroundImage = cImgSpec.ToBitmap(); // Сохранение спектра в картинку
            cImgSpec.BackwardFourierTransform(); // Обратное Фурье преобразование
            panRest.BackgroundImage = cImgSpec.ToBitmap(); // Сохранение востановленного изображения в картинку
            buFilter.Enabled = true;
            buSave1.Enabled = true;
        }
        /// <summary>
        /// Кнопка рассчета фильтра
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuFilter_Click(object sender, EventArgs e)
        {
            double d0 = Convert.ToDouble(numBorder.Value.ToString()); // Значение среза
            double d; // Переменная функции фильтра
            double h; // Значение функции фильтра
            ComplexImage cImgSpecF; // Создание комплексного изображения
            var gray = new AForge.Imaging.Filters.Grayscale(0.2125, 0.7154, 0.0721).Apply(new Bitmap(panImg.BackgroundImage)); // Преобразование изображение в GrayScale
            cImgSpecF = ComplexImage.FromBitmap(gray); // Заполнение комплексного изображения
            cImgSpecF.ForwardFourierTransform(); // Прямое Фурье преобразование
            switch (cmbF.SelectedIndex) // Выбор фильтра
            {
                case 0: // Идеальный низкочастотный
                    for (int i = 0; i < width; i++)
                    {
                        for (int j = 0; j < height; j++)
                        {
                            d = Math.Sqrt(Math.Pow(i - (width / 2), 2) + Math.Pow(j - (height / 2), 2));
                            if (d <= d0)
                            {
                                cImgSpecF.Data[i, j] = cImgSpecF.Data[i, j] * 1;
                            }
                            else
                            {
                                cImgSpecF.Data[i, j] = cImgSpecF.Data[i, j] * 0;
                            }
                        }
                    }
                    break;
                case 1: // Низкочастотный Гаусса
                    for (int i = 0; i < width; i++)
                    {
                        for (int j = 0; j < height; j++)
                        {
                            d = Math.Sqrt(Math.Pow(i - (width / 2), 2) + Math.Pow(j - (height / 2), 2));
                            h = Math.Exp(-Math.Pow(d, 2)/(2* Math.Pow(d0, 2)));
                            cImgSpecF.Data[i, j] = cImgSpecF.Data[i, j] * h;
                        }
                    }
                    break;
                case 2: // Идеальный высокочастотный
                    for (int i = 0; i < width; i++)
                    {
                        for (int j = 0; j < height; j++)
                        {
                            d = Math.Sqrt(Math.Pow(i - (width / 2), 2) + Math.Pow(j - (height / 2), 2));
                            if (d <= d0)
                            {
                                cImgSpecF.Data[i, j] = cImgSpecF.Data[i, j] * 0;
                            }
                            else
                            {
                                cImgSpecF.Data[i, j] = cImgSpecF.Data[i, j] * 1;
                            }
                        }
                    }
                    break;
                case 3: // Высокочастотный Гаусса
                    for (int i = 0; i < width; i++)
                    {
                        for (int j = 0; j < height; j++)
                        {
                            d = Math.Sqrt(Math.Pow(i - (width / 2), 2) + Math.Pow(j - (height / 2), 2));
                            h = 1 - Math.Exp(-Math.Pow(d, 2) / (2 * Math.Pow(d0, 2)));
                            cImgSpecF.Data[i, j] = cImgSpecF.Data[i, j] * h;
                        }
                    }
                    break;
            }
            panF.BackgroundImage = cImgSpecF.ToBitmap(); // Сохранение фильтра спектра в картику
            cImgSpecF.BackwardFourierTransform(); // Обратное Фурье преобразование
            panFRest.BackgroundImage = cImgSpecF.ToBitmap(); // Сохранение фильтра востановленного изображения в картинку
            buSave2.Enabled = true;
        }
        /// <summary>
        /// Кнопка сохрания спектра и востановленного изображения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuSave1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog(); // Сохранение спектра
            sfd.Filter = "Рисунок .jpg | *.jpg";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                panSpectr.BackgroundImage.Save(sfd.FileName);
            }
            sfd = new SaveFileDialog(); // Сохранение востановленного изображения
            sfd.Filter = "Рисунок .jpg | *.jpg";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                panRest.BackgroundImage.Save(sfd.FileName);
            }
        }
        /// <summary>
        /// Кнопка сохрания фильтра спектра и фильтра востановленного изображения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuSave2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog(); // Сохранение фильтра спектра
            sfd.Filter = "Рисунок .jpg | *.jpg";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                panF.BackgroundImage.Save(sfd.FileName);
            }
            sfd = new SaveFileDialog(); // Сохранение фильтра востановленного изображения
            sfd.Filter = "Рисунок .jpg | *.jpg";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                panFRest.BackgroundImage.Save(sfd.FileName);
            }
        }
    }
}