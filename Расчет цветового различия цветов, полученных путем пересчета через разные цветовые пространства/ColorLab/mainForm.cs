using System;
using System.Drawing;
using System.Windows.Forms;

namespace ColorLab
{
    public partial class MainForm : Form
    {
        // Цветовое пространство XYZ
        int X_XYZ;
        int Y_XYZ;
        int Z_XYZ;
        // Цветовое пространство RGB
        int R_RGB;
        int G_RGB;
        int B_RGB;
        // Цветовое пространство LCH
        int L_LCH;
        int C_LCH;
        int H_LCH;
        // Цветовое пространство HSV
        int H_HSV;
        int S_HSV;
        int V_HSV;
        // Цветовое пространство HSL
        int H_HSL;
        int S_HSL;
        int L_HSL;
        // Цветовое пространство LAB
        int L_LAB;
        int A_LAB;
        int B_LAB;
        // Цветовое пространство LAB (первые значения)
        int Old_L_LAB;
        int Old_A_LAB;
        int Old_B_LAB;

        // Справочные значения X, Y и Z (D65)/2 градуса
        double Reference_X = 95.047;
        double Reference_Y = 100.000;
        double Reference_Z = 108.883;

        // Весовые факторы LCH
        double WHT_L = 1;
        double WHT_C = 1;
        double WHT_H = 1;

        double Delta_E;
        double Delta_E94;
        double Delta_E00;

        public MainForm()
        {
            InitializeComponent();
            laDelta.Text = "";
        }

        private void buLABtoRGB_Click(object sender, EventArgs e)
        {
            LABtoXYZ();
            XYZtoRGB();
            rRGB.Value = R_RGB;
            gRGB.Value = G_RGB;
            bRGB.Value = B_RGB;
        }
        /// <summary>
        /// Метод перевода из LAB в XYZ
        /// </summary>
        void LABtoXYZ()
        {
            Old_L_LAB = L_LAB = (int)LLab.Value;
            Old_A_LAB = A_LAB = (int)aLab.Value;
            Old_B_LAB = B_LAB = (int)bLab.Value;
            double var_Y = ((double)L_LAB + 16) / 116;
            double var_X = ((double)A_LAB / 500) + var_Y;
            double var_Z = var_Y - ((double)B_LAB / 200);

            if (Math.Pow(var_Y, 3) > 0.008856)
            {
                var_Y = Math.Pow(var_Y, 3);
            }
            else
            {
                var_Y = (var_Y - (16 / 116)) / 7.787;
            }

            if (Math.Pow(var_X, 3) > 0.008856)
            {
                var_X = Math.Pow(var_X, 3);
            }
            else
            {
                var_X = (var_X - (16 / 116)) / 7.787;
            }

            if (Math.Pow(var_Z, 3) > 0.008856)
            {
                var_Z = Math.Pow(var_Z, 3);
            }
            else
            {
                var_Z = (var_Z - (16 / 116)) / 7.787;
            }

            X_XYZ = (int)Math.Round(var_X * Reference_X, MidpointRounding.AwayFromZero);
            Y_XYZ = (int)Math.Round(var_Y * Reference_Y, MidpointRounding.AwayFromZero);
            Z_XYZ = (int)Math.Round(var_Z * Reference_Z, MidpointRounding.AwayFromZero);
        }
        /// <summary>
        /// Метод перевода из XYZ в RGB
        /// </summary>
        void XYZtoRGB()
        {
            double var_X = (double)X_XYZ / 100;
            double var_Y = (double)Y_XYZ / 100;
            double var_Z = (double)Z_XYZ / 100;

            double var_R = var_X * 3.2406 + var_Y * -1.5372 + var_Z * -0.4986;
            double var_G = var_X * -0.9689 + var_Y * 1.8758 + var_Z * 0.0415;
            double var_B = var_X * 0.0557 + var_Y * -0.2040 + var_Z * 1.0570;

            if (var_R > 0.0031308)
            {
                var_R = 1.055 * Math.Pow(var_R, 1.0 / 2.4) - 0.055;
            }
            else
            {
                var_R = 12.92 * var_R;
            }

            if (var_G > 0.0031308)
            {
                var_G = 1.055 * Math.Pow(var_G, 1.0 / 2.4) - 0.055;
            }
            else
            {
                var_G = 12.92 * var_G;
            }

            if (var_B > 0.0031308)
            {
                var_B = 1.055 * Math.Pow(var_B, 1.0 / 2.4) - 0.055;
            }
            else
            {
                var_B = 12.92 * var_B;
            }

            R_RGB = (int)Math.Round(var_R * 255, MidpointRounding.AwayFromZero);
            G_RGB = (int)Math.Round(var_G * 255, MidpointRounding.AwayFromZero);
            B_RGB = (int)Math.Round(var_B * 255, MidpointRounding.AwayFromZero);
        }

        private void buLABtoLCH_Click(object sender, EventArgs e)
        {
            LABtoLCH();
            lLCH.Value = L_LCH;
            cLCH.Value = C_LCH;
            hLCH.Value = H_LCH;

        }
        /// <summary>
        /// Метод перевода из LAB в LCH
        /// </summary>
        void LABtoLCH()
        {
            Old_L_LAB = L_LAB = (int)(LLab.Value);
            Old_A_LAB = A_LAB = (int)(aLab.Value);
            Old_B_LAB = B_LAB = (int)(bLab.Value);
            double var_L = (double)L_LAB;
            double var_C = Math.Sqrt(Math.Pow((double)A_LAB, 2) + Math.Pow((double)B_LAB, 2));
            double var_H;
            if (Math.Atan2((double)B_LAB, (double)A_LAB) == 0)
            {
                var_H = 0;
            }
            else
            {
                var_H = Math.Pow(Math.Atan2((double)B_LAB, (double)A_LAB), -1.0);
            }
            if (var_H > 0)
            {
                var_H = (var_H / Math.PI) * 180;
            }
            else
            {
                var_H = 360 - (Math.Abs(var_H) / Math.PI * 180);
            }
            L_LCH = (int)Math.Round(var_L, MidpointRounding.AwayFromZero);
            C_LCH = (int)Math.Round(var_C, MidpointRounding.AwayFromZero);
            H_LCH = (int)Math.Round(var_H, MidpointRounding.AwayFromZero);
        }

        private void buRGBtoHSV_Click(object sender, EventArgs e)
        {
            RGBtoHSV();
            hHSV.Value = H_HSV;
            sHSV.Value = S_HSV;
            vHSV.Value = V_HSV;
        }
        /// <summary>
        /// Метод перевода из RGB в HSV (HSB)
        /// </summary>
        void RGBtoHSV()
        {
            double Local_H_HSV = 0;
            R_RGB = (int)rRGB.Value;
            G_RGB = (int)gRGB.Value;
            B_RGB = (int)bRGB.Value;

            double var_R = (double)R_RGB / 255;
            double var_G = (double)G_RGB / 255;
            double var_B = (double)B_RGB / 255;

            double var_Min; // Минимальное значение RGB
            if (var_R <= var_G && var_R <= var_B)
            {
                var_Min = var_R;
            }
            else if (var_G <= var_B)
            {
                var_Min = var_G;
            }
            else
            {
                var_Min = var_B;
            }

            double var_Max; // Максимальное значение RGB
            if (var_R >= var_G && var_R >= var_B)
            {
                var_Max = var_R;
            }
            else if (var_G >= var_B)
            {
                var_Max = var_G;
            }
            else
            {
                var_Max = var_B;
            }
            double Delta_Max_Min = var_Max - var_Min; // Дельта между максимальным и минимальным RGB

            V_HSV = (int)Math.Round(var_Max * 100, MidpointRounding.AwayFromZero);

            if (Delta_Max_Min == 0)
            {
                H_HSV = 0;
                S_HSV = 0;
            }
            else
            {
                S_HSV = (int)Math.Round(Delta_Max_Min / var_Max * 100, MidpointRounding.AwayFromZero);

                double del_R = (((var_Max - var_R) / 6) + (Delta_Max_Min / 2)) / Delta_Max_Min;
                double del_G = (((var_Max - var_G) / 6) + (Delta_Max_Min / 2)) / Delta_Max_Min;
                double del_B = (((var_Max - var_B) / 6) + (Delta_Max_Min / 2)) / Delta_Max_Min;

                if (var_R == var_Max)
                {
                    Local_H_HSV = ((del_B - del_G));
                }
                else if (var_G == var_Max)
                {
                    Local_H_HSV = (((1 / 3) + del_R - del_B));
                }
                else if (var_B == var_Max)
                {
                    Local_H_HSV = (((2 / 3) + del_G - del_R));
                }

                if (Local_H_HSV < 0)
                {
                    Local_H_HSV += 1;
                }
                if (Local_H_HSV > 1)
                {
                    Local_H_HSV -= 1;
                }
                H_HSV = (int)Math.Round(Local_H_HSV * 360, MidpointRounding.AwayFromZero);
            }
        }
        private void buRGBtoHSL_Click(object sender, EventArgs e)
        {
            RGBtoHSL();
            hHSL.Value = H_HSL;
            sHSL.Value = S_HSL;
            lHSL.Value = L_HSL;
        }
        /// <summary>
        /// Метод перевода из RGB в HSL
        /// </summary>
        void RGBtoHSL()
        {
            double Local_H_HSL = 0;
            R_RGB = (int)rRGB.Value;
            G_RGB = (int)gRGB.Value;
            B_RGB = (int)bRGB.Value;

            double var_R = (double)R_RGB / 255;
            double var_G = (double)G_RGB / 255;
            double var_B = (double)B_RGB / 255;

            double var_Min; // Минимальное значение RGB
            if (var_R <= var_G && var_R <= var_B)
            {
                var_Min = var_R;
            }
            else if (var_G <= var_B)
            {
                var_Min = var_G;
            }
            else
            {
                var_Min = var_B;
            }

            double var_Max; // Максимальное значение RGB
            if (var_R >= var_G && var_R >= var_B)
            {
                var_Max = var_R;
            }
            else if (var_G >= var_B)
            {
                var_Max = var_G;
            }
            else
            {
                var_Max = var_B;
            }
            double Delta_Max_Min = var_Max - var_Min; // Дельта между максимальным и минимальным RGB

            L_HSL = (int)Math.Round(((var_Max + var_Min) / 2) * 100, MidpointRounding.AwayFromZero);

            if (Delta_Max_Min == 0)
            {
                H_HSL = 0;
                S_HSL = 0;
            }
            else
            {
                if (L_HSL < 0.5)
                {
                    S_HSL = (int)Math.Round(Delta_Max_Min / (var_Max + var_Min) * 100, MidpointRounding.AwayFromZero);
                }
                else
                {
                    S_HSL = (int)Math.Round(Delta_Max_Min / (2 - var_Max - var_Min) * 100, MidpointRounding.AwayFromZero);
                }

                double del_R = (((var_Max - var_R) / 6) + (Delta_Max_Min / 2)) / Delta_Max_Min;
                double del_G = (((var_Max - var_G) / 6) + (Delta_Max_Min / 2)) / Delta_Max_Min;
                double del_B = (((var_Max - var_B) / 6) + (Delta_Max_Min / 2)) / Delta_Max_Min;

                if (var_R == var_Max)
                {
                    Local_H_HSL = del_B - del_G;
                }
                else if (var_G == var_Max)
                {
                    Local_H_HSL = (1 / 3) + del_R - del_B;
                }
                else if (var_B == var_Max)
                {
                    Local_H_HSL = (2 / 3) + del_G - del_R;
                }

                if (Local_H_HSL < 0)
                {
                    Local_H_HSL += 1;
                }
                if (Local_H_HSL > 1)
                {
                    Local_H_HSL -= 1;
                }

                H_HSL = (int)Math.Round(Local_H_HSL * 360, MidpointRounding.AwayFromZero);
            }
        }
        /// <summary>
        /// Метод перевода из LCH в LAB
        /// </summary>
        void LCHtoLAB()
        {
            L_LCH = (int)lLCH.Value;
            C_LCH = (int)cLCH.Value;
            H_LCH = (int)hLCH.Value;
            L_LAB = L_LCH;
            A_LAB = (int)Math.Round(Math.Cos((double)H_LCH / Math.PI * 180) * (double)C_LCH, MidpointRounding.AwayFromZero);
            B_LAB = (int)Math.Round(Math.Sin((double)H_LCH / Math.PI * 180) * (double)C_LCH, MidpointRounding.AwayFromZero);
        }

        private void buLCHtoLAB_Click(object sender, EventArgs e)
        {
            LCHtoLAB();
            LLab.Value = L_LAB;
            aLab.Value = A_LAB;
            bLab.Value = B_LAB;
            Calc_Delta_E();
            Calc_Delta_E94();
            Calc_Delta_E00();
            laDelta.Text = "Дельта Е(74) = " + Delta_E + "; Дельта E(94) = " + Delta_E94 + "; Дельта E(00) = " + Delta_E00;
        }

        private void buRGBtoLAB_Click(object sender, EventArgs e)
        {
            RGBtoXYZ();
            XYZtoLAB();
            LLab.Value = L_LAB;
            aLab.Value = A_LAB;
            bLab.Value = B_LAB;
        }
        /// <summary>
        /// Метод перевода из RGB в XYZ
        /// </summary>
        void RGBtoXYZ()
        {
            R_RGB = (int)rRGB.Value;
            G_RGB = (int)gRGB.Value;
            B_RGB = (int)bRGB.Value;

            double var_R = (double)R_RGB / 255;
            double var_G = (double)G_RGB / 255;
            double var_B = (double)B_RGB / 255;

            if (var_R > 0.04045)
            {
                var_R = Math.Pow(((var_R + 0.055) / 1.055), 2.4);
            }
            else
            {
                var_R = var_R / 12.92;
            }
            if (var_G > 0.04045)
            {
                var_G = Math.Pow(((var_G + 0.055) / 1.055), 2.4);
            }
            else
            {
                var_G = var_G / 12.92;
            }
            if (var_B > 0.04045)
            {
                var_B = Math.Pow(((var_B + 0.055) / 1.055), 2.4);
            }
            else
            {
                var_B = var_B / 12.92;
            }

            var_R = var_R * 100;
            var_G = var_G * 100;
            var_B = var_B * 100;

            X_XYZ = (int)Math.Round(var_R * 0.4124 + var_G * 0.3576 + var_B * 0.1805, MidpointRounding.AwayFromZero);
            Y_XYZ = (int)Math.Round(var_R * 0.2126 + var_G * 0.7152 + var_B * 0.0722, MidpointRounding.AwayFromZero);
            Z_XYZ = (int)Math.Round(var_R * 0.0193 + var_G * 0.1192 + var_B * 0.9505, MidpointRounding.AwayFromZero);
        }
        /// <summary>
        /// Метод перевода из XYZ в LAB
        /// </summary>
        void XYZtoLAB()
        {
            double var_X = (double)X_XYZ / Reference_X;
            double var_Y = (double)Y_XYZ / Reference_Y;
            double var_Z = (double)Z_XYZ / Reference_Z;

            if (var_X > 0.008856)
            {
                var_X = Math.Pow(var_X, 1.0 / 3);
            }
            else
            {
                var_X = (7.787 * var_X) + (16 / 116);
            }
            if (var_Y > 0.008856)
            {
                var_Y = Math.Pow(var_Y, 1.0 / 3);
            }
            else
            {
                var_Y = (7.787 * var_Y) + (16 / 116);
            }
            if (var_Z > 0.008856)
            {
                var_Z = Math.Pow(var_Z, 1.0 / 3);
            }
            else
            {
                var_Z = (7.787 * var_Z) + (16 / 116);
            }

            double L = ((116 * var_Y) - 16);
            double A = (500 * (var_X - var_Y));
            double B = (200 * (var_Y - var_Z));

            L_LAB = (int)Math.Round((116 * var_Y) - 16, MidpointRounding.AwayFromZero);
            A_LAB = (int)Math.Round(500 * (var_X - var_Y), MidpointRounding.AwayFromZero);
            B_LAB = (int)Math.Round(200 * (var_Y - var_Z), MidpointRounding.AwayFromZero);
        }

        private void buHSVtoLAB_Click(object sender, EventArgs e)
        {
            HSVtoRGB();
            RGBtoXYZ();
            XYZtoLAB();
            LLab.Value = L_LAB;
            aLab.Value = A_LAB;
            bLab.Value = B_LAB;
        }
        /// <summary>
        /// Метод перевода из HSV в RGB
        /// </summary>
        void HSVtoRGB()
        {
            double var_R = 0;
            double var_G = 0;
            double var_B = 0;

            H_HSV = (int)hHSV.Value;
            S_HSV = (int)sHSV.Value;
            V_HSV = (int)vHSV.Value;

            double var_H = (double)H_HSV / 360;
            double var_S = (double)S_HSV / 100;
            double var_V = (double)V_HSV / 100;

            if (S_HSV == 0)
            {
                R_RGB = (int)Math.Round(var_V * 255, MidpointRounding.AwayFromZero);
                G_RGB = (int)Math.Round(var_V * 255, MidpointRounding.AwayFromZero);
                B_RGB = (int)Math.Round(var_V * 255, MidpointRounding.AwayFromZero);
            }
            else
            {
                var_H = var_H * 6;
                if (var_H == 6)
                {
                    var_H = 0;
                }
                double var_i = (int)var_H;
                double var_1 = var_V * (1 - var_S);
                double var_2 = var_V * (1 - var_S * (var_H - var_i));
                double var_3 = var_V * (1 - var_S * (1 - (var_H - var_i)));

                if (var_i == 0)
                {
                    var_R = var_V;
                    var_G = var_3;
                    var_B = var_1;
                }
                else if (var_i == 1)
                {
                    var_R = var_2;
                    var_G = var_V;
                    var_B = var_1;
                }
                else if (var_i == 2)
                {
                    var_R = var_1;
                    var_G = var_V;
                    var_B = var_3;
                }
                else if (var_i == 3)
                {
                    var_R = var_1;
                    var_G = var_2;
                    var_B = var_V;
                }
                else if (var_i == 4)
                {
                    var_R = var_3;
                    var_G = var_1;
                    var_B = var_V;
                }
                else
                {
                    var_R = var_V;
                    var_G = var_1;
                    var_B = var_2;
                }
                R_RGB = (int)Math.Round(var_R * 255, MidpointRounding.AwayFromZero);
                G_RGB = (int)Math.Round(var_G * 255, MidpointRounding.AwayFromZero);
                B_RGB = (int)Math.Round(var_B * 255, MidpointRounding.AwayFromZero);
            }

        }
        /// <summary>
        /// Метод перевода из HSL в RGB
        /// </summary>
        void HSLtoRGB()
        {
            double var_2 = 0;
            H_HSL = (int)hHSL.Value;
            S_HSL = (int)sHSL.Value;
            L_HSL = (int)lHSL.Value;

            double var_H = (double)H_HSL / 360;
            double var_S = (double)S_HSL / 100;
            double var_L = (double)L_HSL / 100;

            if (var_S == 0)
            {
                R_RGB = (int)Math.Round(var_L * 255, MidpointRounding.AwayFromZero);
                G_RGB = (int)Math.Round(var_L * 255, MidpointRounding.AwayFromZero);
                B_RGB = (int)Math.Round(var_L * 255, MidpointRounding.AwayFromZero);
            }
            else
            {
                if (var_L < 0.5)
                {
                    var_2 = var_L * (1 + var_S);
                }
                else
                {
                    var_2 = (var_L + var_S) - (var_S * var_L);
                }
                double var_1 = 2 * var_L - var_2;
                R_RGB = (int)Math.Round(255 * HtoRGB(var_1, var_2, var_H + (1.0 / 3)), MidpointRounding.AwayFromZero);
                G_RGB = (int)Math.Round(255 * HtoRGB(var_1, var_2, var_H), MidpointRounding.AwayFromZero);
                B_RGB = (int)Math.Round(255 * HtoRGB(var_1, var_2, var_H - (1.0 / 3)), MidpointRounding.AwayFromZero);
            }
        }
        /// <summary>
        /// Метод перевода оттенка (HUE)
        /// </summary>
        /// <param name="v1">Значение var_1 из метода HSLtoRGB()</param>
        /// <param name="v2">Значение var_2 из метода HSLtoRGB()</param>
        /// <param name="vH">Значение var_H из метода HSLtoRGB()</param>
        /// <returns></returns>
        double HtoRGB(double v1, double v2, double vH)
        {
            if (vH < 0)
            {
                vH += 1;
            }
            if (vH > 1)
            {
                vH -= 1;
            }
            if ((6 * vH) < 1)
            {
                return (v1 + (v2 - v1) * 6 * vH);
            }
            if ((2 * vH) < 1)
            {
                return (v2);
            }
            if ((3 * vH) < 2)
            {
                return (v1 + (v2 - v1) * ((2 / 3) - vH) * 6);
            }
            return v1;
        }

        private void buHSLtoLAB_Click(object sender, EventArgs e)
        {
            HSLtoRGB();
            RGBtoXYZ();
            XYZtoLAB();
            LLab.Value = L_LAB;
            aLab.Value = A_LAB;
            bLab.Value = B_LAB;
        }

        private void buViewColor(object sender, EventArgs e)
        {
            string NameColorButton = (sender as Button).Name;
            if (NameColorButton == "buFirstColor")
            {
                // Вывод цвета канала LAB
                LABtoXYZ();
                XYZtoRGB();
                pLab.BackColor = Color.FromArgb(R_RGB, G_RGB, B_RGB);
                // Вывод цвета канала LCH
                LCHtoLAB();
                LABtoXYZ();
                XYZtoRGB();
                pLCH.BackColor = Color.FromArgb(R_RGB, G_RGB, B_RGB);
                // Вывод цвета канала RGB
                pRGB.BackColor = Color.FromArgb((int)rRGB.Value, (int)gRGB.Value, (int)bRGB.Value);
                // Вывод цвета канала HSV (HSB)
                HSVtoRGB();
                pHSV.BackColor = Color.FromArgb(R_RGB, G_RGB, B_RGB);
                // Вывод цвета канала HSL (HSI)
                HSLtoRGB();
                pHSL.BackColor = Color.FromArgb(R_RGB, G_RGB, B_RGB);
            }
            if (NameColorButton == "buFinallyColor")
            {
                // Вывод цвета канала после обратного преобразования из LCH
                LCHtoLAB();
                //-------\\
                LABtoXYZ();
                XYZtoRGB();
                pLCHback.BackColor = Color.FromArgb(R_RGB, G_RGB, B_RGB);
                // Вывод цвета канала после обратного преобразования из RGB
                RGBtoXYZ();
                XYZtoLAB();
                //-------\\
                LABtoXYZ();
                XYZtoRGB();
                pRGBback.BackColor = Color.FromArgb(R_RGB, G_RGB, B_RGB);
                // Вывод цвета канала после обратного преобразования из HSV (HSB)
                HSVtoRGB();
                RGBtoXYZ();
                XYZtoLAB();
                //-------\\
                LABtoXYZ();
                XYZtoRGB();
                pHSVback.BackColor = Color.FromArgb(R_RGB, G_RGB, B_RGB);
                // Вывод цвета канала после обратного преобразования из HSL (HSI)
                HSLtoRGB();
                RGBtoXYZ();
                XYZtoLAB();
                //-------\\
                LABtoXYZ();
                XYZtoRGB();
                pHSLback.BackColor = Color.FromArgb(R_RGB, G_RGB, B_RGB);
            }
        }
        /// <summary>
        /// Метод для расчета Delta E74
        /// </summary>
        void Calc_Delta_E()
        {
            Delta_E = Math.Round(Math.Sqrt(Math.Pow(L_LAB - Old_L_LAB, 2)  + Math.Pow(A_LAB - Old_A_LAB, 2) + Math.Pow(B_LAB - Old_B_LAB, 2)), 2, MidpointRounding.AwayFromZero);
        }
        /// <summary>
        /// Метод расчета Delta E94
        /// </summary>
        void Calc_Delta_E94()
        {
            double xC1 = Math.Sqrt(Math.Pow(A_LAB,2) + Math.Pow(B_LAB, 2));
            double xC2 = Math.Sqrt(Math.Pow(Old_A_LAB, 2) + Math.Pow(Old_B_LAB, 2));
            double xDL = Old_L_LAB - L_LAB;
            double xDC = xC2 - xC1;
            double xDE = Math.Sqrt(Math.Pow(L_LAB - Old_L_LAB, 2) + Math.Pow(A_LAB - Old_A_LAB, 2) + Math.Pow(B_LAB - Old_B_LAB, 2));
            double xDH = (xDE * xDE) - (xDL * xDL) - (xDC * xDC);
            if (xDH > 0)
            {
                xDH = Math.Sqrt(xDH);
}
            else
            {
                xDH = 0;
            }

            double xSC = 1 + (0.045 * xC1);
            double xSH = 1 + (0.015 * xC1);
            xDL /= WHT_L;
            xDC /= WHT_C * xSC;
            xDH /= WHT_H * xSH;

            Delta_E94 = Math.Round(Math.Sqrt(Math.Pow(xDL, 2) + Math.Pow(xDC, 2) + Math.Pow(xDH, 2)), 2, MidpointRounding.AwayFromZero);
        }
        void Calc_Delta_E00()
        {
            double xC1 = Math.Sqrt(Math.Pow(A_LAB, 2) + Math.Pow(B_LAB, 2));
            double xC2 = Math.Sqrt(Math.Pow(Old_A_LAB, 2) + Math.Pow(Old_B_LAB, 2));
            double xCX = (xC1 + xC2) / 2;
            double xGX = 0.5 * (1 - Math.Sqrt(Math.Pow(xCX, 7) / (Math.Pow(xCX, 7) + Math.Pow(25, 7))));
            double xNN = (1 + xGX) * L_LAB;
            xC1 = Math.Sqrt(xNN * xNN + Math.Pow(B_LAB, 2));
            double xH1 = LabToH(xNN, B_LAB);
            xNN = (1 + xGX) * Old_A_LAB;
            xC2 = Math.Sqrt(xNN * xNN + Math.Pow(Old_B_LAB, 7));
            double xH2 = LabToH(xNN, Old_B_LAB);
            double xDL = Old_L_LAB - L_LAB;
            double xDC = xC2 - xC1;
            double xDH;
            if ((xC1 * xC2) == 0) 
            {
                xDH = 0;
}
            else
            {
                xNN = Math.Round(xH2 - xH1, 12, MidpointRounding.AwayFromZero);
                if (Math.Abs(xNN) <= 180)
                {
                    xDH = xH2 - xH1;
                }
                else
                {
                    if (xNN > 180)
                    {
                        xDH = xH2 - xH1 - 360;
                    }
                    else
                    {
                        xDH = xH2 - xH1 + 360;
                    }
                }
            }
            xDH = 2 * Math.Sqrt(xC1 * xC2) * Math.Sin(xDH / 2);
            double xLX = (L_LAB + Old_L_LAB) / 2;
            double xCY = (xC1 + xC2) / 2;
            double xHX;
            if ((xC1 * xC2) == 0)
            {
                xHX = xH1 + xH2;
            }
            else
            {
                xNN = Math.Abs(Math.Round(xH1 - xH2, 12));
               if (xNN > 180)
                {
                    if ((xH2 + xH1) < 360) xHX = xH1 + xH2 + 360;
                    else xHX = xH1 + xH2 - 360;
   }
                else
                {
                    xHX = xH1 + xH2;
                }
                xHX /= 2;
            }
            double xTX = 1 - 0.17 * Math.Cos(xHX - (Math.PI/6)) + 0.24 * Math.Cos((2 * xHX) * Math.PI / 180) + 0.32 * Math.Cos((3 * xHX + (Math.PI / 30)) * Math.PI / 180) - 0.20 * Math.Cos(4 * xHX - (7 * Math.PI / 20));
            double xPH = 30 * Math.Exp(-((xHX - 275) / 25) * ((xHX - 275) / 25));
            double xRC = 2 * Math.Sqrt(Math.Pow(xCY, 7) / (Math.Pow(xCY, 7) + Math.Pow(25, 7)));
            double xSL = 1 + ((0.015 * Math.Pow(xLX - 50, 2)) / Math.Sqrt(20 + Math.Pow(xLX - 50, 2)));

            double xSC = 1 + 0.045 * xCY;
            double xSH = 1 + 0.015 * xCY * xTX;
            double xRT = -Math.Sin((2 * xPH) * Math.PI / 180) * xRC;
            xDL = xDL / (WHT_L * xSL);
            xDC = xDC / (WHT_C * xSC);
            xDH = xDH / (WHT_H * xSH);

            Delta_E00 = Math.Round(Math.Sqrt(Math.Pow(xDL, 2) + Math.Pow(xDC, 2) + Math.Pow(xDH, 2) + xRT * xDC * xDH), 2, MidpointRounding.AwayFromZero);
        }
        double LabToH(double var_a, double var_b )          //Function returns CIE-H° value
        {
            double var_bias = 0;
            if (var_a >= 0 && var_b == 0) return 0;
            if (var_a < 0 && var_b == 0) return 180;
            if (var_a == 0 && var_b > 0) return 90;
            if (var_a == 0 && var_b < 0) return 270;
            if (var_a > 0 && var_b > 0) var_bias = 0;
            if (var_a < 0) var_bias = 180;
            if (var_a > 0 && var_b < 0) var_bias = 360;
            return ((Math.Atan(var_b / var_a) / Math.PI * 180) + var_bias);
        }
    }
}
