using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace labForoCompare
{
    public partial class MainForm : Form
    {
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
        /// Массив пикселей первой картинки
        /// </summary>
        Color[,] Pict1;
        /// <summary>
        /// Массив пикселей второй картинки
        /// </summary>
        Color[,] Pict2;
        /// <summary>
        /// Главный метод (создается автоматически)
        /// </summary>

        public MainForm()
        {
            InitializeComponent(); //Инициализация компонентов формы (создается автоматичеки)
            buPict2.Enabled = false; // Отключение кнопки
            buCompare.Enabled = false; // Отключение кнопки      
            buAllClear.Enabled = false; // Отключение кнопки     
            laMSE.Text = "MSE: "; //Сброс отображения значения
            laPSNR.Text = "PSNR: "; //Сброс отображения значения
            laSSIM.Text = "SSIM: "; //Сброс отображения значения
        }
//Начало кода Дралкин Сергея
        /// <summary>
        /// Событие нажатия на кнопку "Выбрать картинку №1"
        /// </summary>
        private void buPict1_Click(object sender, EventArgs e)
        {
            OpenFileDialog OPF = new OpenFileDialog(); // Инициализация диалогового окна
            OPF.Filter = "JPG|*.jpg|JPEG|*.jpeg|PNG|*.png"; // Фильтр в диалоговом окне
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                FileName.Add(OPF.FileName); // Добавление в массив пути картинки                    
                imPanel1.BackgroundImage = Image.FromFile(OPF.FileName); // Отображение изображения на форме   
                buPict2.Enabled = true; // Включение кнопки
                buPict1.Enabled = false; // Отключение кнопки
            }
            else
            {
                return;
            }
        }
        /// <summary>
        /// Событие нажатия на кнопку "Выбрать картинку №2"
        /// </summary>
        private void buPict2_Click(object sender, EventArgs e)
        {
            OpenFileDialog OPF = new OpenFileDialog(); // Инициализация диалогового окна
            OPF.Filter = "JPG|*.jpg|JPEG|*.jpeg|PNG|*.png"; // Фильтр в диалоговом окне
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                FileName.Add(OPF.FileName); // Добавление в массив пути картинки                
                imPanel2.BackgroundImage = Image.FromFile(OPF.FileName); // Отображение изображения на форме            
                buPict2.Enabled = false; // Отключение кнопки
                buCompare.Enabled = true; // Включение кнопки
            }
            else
            {
                return;
            }
        }
//Конец кода Дралкин Сергея
//Начало кода Мелкова Вадима
        /// <summary>
        /// Событие нажатия на кнопку "Очистить"
        /// </summary>
        private void buAllClear_Click(object sender, EventArgs e)
        {
            buPict1.Enabled = true; // Включение кнопки
            buPict2.Enabled = false; // Отключение кнопки
            buCompare.Enabled = false; // Отключение кнопки
            imPanel1.BackgroundImage = null; // Очистка картинки на форме
            imPanel2.BackgroundImage = null; // Очистка картинки на форме
            FileName.Clear(); // Очистка массива путей
            Pict1 = null; // Очистка массива картинки 1
            Pict2 = null; // Очистка массива картинки 2
            buAllClear.Enabled = false; // Отключение кнопки
            laMSE.Text = "MSE: "; //Сброс отображения значения
            laPSNR.Text = "PSNR: "; //Сброс отображения значения
            laSSIM.Text = "SSIM: "; //Сброс отображения значения
        }
        /// <summary>
        /// Метод преобразования изображения в массив пикселей
        /// </summary>
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
        /// Событие нажатия на кнопку "Сравнить"
        /// </summary>
        private void buCompare_Click(object sender, EventArgs e)
        {
            Pict1 = GetBitMapColorMatrix(FileName[0]); // Добавление в массив всех пикселей картинки №1
            Pict2 = GetBitMapColorMatrix(FileName[1]); // Добавление в массив всех пикселей картинки №2
            SumPixel(Pict1, Pict2);
            buCompare.Enabled = false;
            buAllClear.Enabled = true;
        }
//Конец кода Мелкова Вадима
//Начало кода Дралкин Сергея
        /// <summary>
        /// Метод расчета цветовых различий
        /// </summary>
        /// <param name="NewCalcpict1"> Массив пикселей первого изображения</param>
        /// <param name="NewCalcpict2"> Массив пикселей второго изображения</param>
        void SumPixel(Color[,] NewCalcpict1, Color[,] NewCalcpict2)
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
//Конец кода Дралкин Сергея
//Начало кода Мелкова Вадима
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
            return Math.Pow(k*L, 2);
        }
//Конец кода Мелкова Вадима
    }
}
