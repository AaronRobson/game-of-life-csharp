using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace GameOfLife
{
    public partial class frm_GameOfLife : Form
    {
        // defaults
        const uint HORIZONTAL = 20;  // 1+
        const uint VERTICAL = 20;  // 1+
        const bool EDGE = true;  // same as edgeReturn
        const int TIME = 0;  //4000;  // (ms)
        const byte SIDE = 2;  // 1+    // 7 seems nice
        const byte GAP = 1;  // 0+
        const bool BORDER = true;  // GAP sized border around the edge

        uint Horizontal = HORIZONTAL;
        uint Vertical = VERTICAL;
        bool Edge = EDGE;
        int Time = TIME;
        byte Side = SIDE;
        byte Gap = GAP;
        bool Border = BORDER;

        const string START = "&Start";
        const string STOP = "&Stop";

        //int hexTest = 0x01f0;
        //const int BACK = 0x000000;    //clBlack;
        //int hexString = Convert.ToInt32("FF");

        Color foreground = Color.Lime; //Color.FromArgb(0, 255, 0);  //Color foreground = Color.FromArgb(HexToInt("FFFFFF"));
        Color background = Color.Black;  //Color.FromArgb(0, 0, 0);

        bool repeat = false;
        Thread repeatThread;

        GameOfLifeClass gol = new GameOfLifeClass();

        Bitmap bmp = new Bitmap(1, 1);
        Graphics grap;

        SolidBrush solidBrush;

        Point temp;

        const byte FRM_BORDER_SIZE = 5;

        public frm_GameOfLife()
        {
            InitializeComponent();
        }

        private void Display_Changes() // On Startup
        {
            gol.Set_Max((int)Horizontal, (int)Vertical);
            gol.Set_Edge(Edge);
          
            if (Border)  // ((gol.Get_MaxX() * (SIDE + GAP)) + GAP)
                bmp = new Bitmap(bmp, new Size(((gol.Get_MaxX() * (Side + Gap)) + Gap), ((gol.Get_MaxY() * (Side + Gap)) + Gap))); // Resize bitmap
            else  // ((gol.Get_MaxX() * (SIDE + GAP)) - GAP)
                bmp = new Bitmap(bmp, new Size(((gol.Get_MaxX() * (Side + Gap)) - Gap),((gol.Get_MaxY() * (Side + Gap)) - Gap)));

            grap = Graphics.FromImage(bmp);
           
            pb_Display.Width = bmp.Width;
            pb_Display.Height = bmp.Height;
            
            if (pb_Display.Width + FRM_BORDER_SIZE < btn_Load.Right)
                pb_Display.Left = (btn_Load.Right + FRM_BORDER_SIZE - pb_Display.Width) / 2;
            else
                pb_Display.Left = FRM_BORDER_SIZE;

            Display();
        }

        private void Display()
        {
            
            /*Lock prevents "is being used elsewhere" error on toggling cells while running.
             *It does nothing to prevent flicker however.
            */
            lock (grap)
            {
                grap.Clear(background);  //bmp.SetPixel(x, y, foreground);

                // reproduce the looping code in order to reduce the continuous checks of BORDER for reliability and efficiency
                if (Border)
                {
                    for (int x = 0; (x < gol.Get_MaxX()); ++x)
                        for (int y = 0; (y < gol.Get_MaxY()); ++y)
                            if (gol.Get_Current_Point(x, y))
                                grap.FillRectangle(solidBrush, ((x * (Side + Gap)) + Gap), ((y * (Side + Gap)) + Gap), Side, Side);  // x * (Side + Gap) + Gap
                }
                else
                {
                    for (int x = 0; (x < gol.Get_MaxX()); ++x)
                        for (int y = 0; (y < gol.Get_MaxY()); ++y)
                            if (gol.Get_Current_Point(x, y))
                                grap.FillRectangle(solidBrush, (x * (Side + Gap)), (y * (Side + Gap)), Side, Side);  // x * (Side + Gap)
                }
            }

            lbl_Population.Text = gol.Get_Population_As_Str();
            lbl_Generation.Text = gol.Get_Generation_As_Str();

            pb_Display.Image = bmp;
        }

        private void SetPopulationText(string populationText)
        {
            lbl_Population.Text = populationText;
        }

        private void SetGenerationText(string generationText)
        {
            lbl_Generation.Text = generationText;
        }

        /*
        private void Display_Border()
        {
            lock (grap)
            {
                grap.Clear(background);  //bmp.SetPixel(x, y, foreground);

                for (int x = 0; (x < gol.Get_MaxX()); ++x)
                    for (int y = 0; (y < gol.Get_MaxY()); ++y)
                        if (gol.Get_Current_Point(x, y))
                            grap.FillRectangle(solidBrush, ((x * (SIDE + GAP)) + GAP), ((y * (SIDE + GAP)) + GAP), SIDE, SIDE);  // x * (SIDE + GAP) + GAP
            }

            lbl_Population.Text = gol.Get_Population_As_Str();
            lbl_Generation.Text = gol.Get_Generation_As_Str();
            pb_Display.Image = bmp;
        }

        private void Display_No_Border()
        {
            lock (grap)
            {
                grap.Clear(background);  //bmp.SetPixel(x, y, foreground);

                for (int x = 0; (x < gol.Get_MaxX()); ++x)
                    for (int y = 0; (y < gol.Get_MaxY()); ++y)
                        if (gol.Get_Current_Point(x, y))
                            grap.FillRectangle(solidBrush, (x * (SIDE + GAP)), (y * (SIDE + GAP)), SIDE, SIDE);  // x * (SIDE + GAP)
            }
            
            lbl_Population.Text = gol.Get_Population_As_Str();
            lbl_Generation.Text = gol.Get_Generation_As_Str();
            pb_Display.Image = bmp;
        }
        */
        private void btn_Reset_Click(object sender, EventArgs e)
        {
            repeat = false;
            btn_Start.Text = START;
            gol.Reset(!cb_Border.Checked);  //change after testing
            Display();
        }
        /*
        private void Start()
        {
            repeat = true;
            btn_Start.Text = STOP;
        }
        */
        /*
        private void Stop()
        {
            repeat = false;
            btn_Start.Text = START;
        }
        */
        private void btn_Random_Click(object sender, EventArgs e)
        {
            gol.Fill_Random();
            Display();
        }

        private void btn_Step_Click(object sender, EventArgs e)
        {
            repeat = false;
            btn_Start.Text = START;
            gol.Iteration();
            Display();
        }

        private void frm_GameOfLife_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;  // to stop exception moaning about using Repetition() in the other thread when it is accessable to the rest of the class
            KeyPreview = true;

            // pen = new Pen(foreground);
            solidBrush = new SolidBrush(foreground);
            SettingsLoad();

            repeatThread = new Thread(new ThreadStart(Repetition));
            repeatThread.Start();
        }

        private void btn_Load_Click(object sender, EventArgs e)
        {
            //gol.Reset();
            //gol.Spawn_Glider();
            //gol.Spawn_Blinker();
            //gol.Spawn_Corner_Block();
            //Display();

            SettingsLoad();
        }

        private void SettingsLoad()
        {
            Config_File.ReadFile(ref Horizontal, ref Vertical, ref Edge, ref Time, ref Side, ref Gap, ref Border);
            SettingsToDisplay();
        }

        private void SettingsSave()
        {
            Config_File.WriteFile(Horizontal, Vertical, Edge, Time, Side, Gap, Border);
        }

        private void SettingsDefault()
        {
            Horizontal = HORIZONTAL;
            Vertical = VERTICAL;
            Edge = EDGE;
            Time = TIME;
            Side = SIDE;
            Gap = GAP;
            Border = BORDER;

            SettingsToDisplay();
        }

        private void SettingsToDisplay()
        {
            nud_Horizontal.Value = Horizontal;
            nud_Vertical.Value = Vertical;
            cb_Edge.Checked = Edge;
            nud_Time.Value = Time;
            nud_Side.Value = Side;
            nud_Gap.Value = Gap;
            cb_Border.Checked = Border;
            Display_Changes();
        }

        private void btn_Negative_Click(object sender, EventArgs e)
        {
            gol.Negative();
            Display();
        }

        private void btn_Default_Click(object sender, EventArgs e)
        {
            SettingsDefault();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            SettingsSave();
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            repeat = !repeat;
        }

        private void Repetition()
        {
            do
            {
                while (repeat && gol.Get_LastChanged())
                {
                    btn_Start.Text = STOP;

                    gol.Iteration();
                    Display();
                    Thread.Sleep(Time);
                }
                btn_Start.Text = START;

                // so that if stopped via LastChanged repetition stops so that if btn_Random is pressed it doesn't continue by itself
                if (!gol.Get_LastChanged())
                    repeat = false;
            } 
            while (true);
        }

        private void frm_GameOfLife_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (repeatThread != null)  // if (repeatThread.IsAlive)
                repeatThread.Abort();  // repeat = false;  // unnecessary

            // unnecessary as garbage collection is included in frm_GOL.Designer.cs
            bmp.Dispose();
            grap.Dispose();
            solidBrush.Dispose();
        }

        private void frm_GameOfLife_KeyUp(object sender, KeyEventArgs e)
        {
            // if Escape Key released while Shift Key is not pressed, Close Form
            if ((e.KeyCode == Keys.Escape) && !e.Shift)
                this.Close();
        }

        private void nud_Horizontal_ValueChanged(object sender, EventArgs e)
        {
            Horizontal = (uint)nud_Horizontal.Value;
            Display_Changes();
        }

        private void nud_Vertical_ValueChanged(object sender, EventArgs e)
        {
            Vertical = (uint)nud_Vertical.Value;
            Display_Changes();
        }

        private void nud_Time_ValueChanged(object sender, EventArgs e)
        {
            // Display_Changes();
            Time = (int)nud_Time.Value;
        }

        private void nud_Side_ValueChanged(object sender, EventArgs e)
        {
            Side = (byte)nud_Side.Value;
            Display_Changes();
        }

        private void nud_Gap_ValueChanged(object sender, EventArgs e)
        {
            Gap = (byte)nud_Gap.Value;
            Display_Changes();
        }

        private void cb_Edge_CheckedChanged(object sender, EventArgs e)
        {
            Edge = cb_Edge.Checked;
            Display_Changes();
        }

        private void cb_Border_CheckedChanged(object sender, EventArgs e)
        {
            Border = cb_Border.Checked;
            Display_Changes();
        }

        private void pb_Display_MouseUp(object sender, MouseEventArgs e)
        {
            temp = e.Location;

            if (Place())  // & Place(ref temp.Y))
            {
                gol.SetPoint(temp);  //MessageBox.Show(e.X + ", " + e.Y);  // for testing purposes
            
                Display();
            }
        }
        /*
        private int Place(int mouse)  // if a gap is clicked on it will be attributed to the box closer to the upper right (or nearest one if on the left or upper boarder)
        {
            return ((Border) ? mouse - Gap : mouse) / (Side + Gap);
        }
        */
        private bool Place()
        {
            // if a gap is clicked on it will be attributed to the box closer to the upper right (or nearest one if on the left or upper border)
            return PlacePart(true) & PlacePart(false);
        }

        // if a gap is clicked on it will be attributed to the box closer to the upper right (or nearest one if on the left or upper boarder)
        private bool PlacePart(bool whichSide)
        {
            int mouse = (Border) ? -Gap : 0;            

            if (whichSide)
            {
                mouse += temp.X;
                temp.X = (mouse / (Side + Gap));
                return ((mouse - (temp.X * (Side + Gap))) <= Side);  // test if the point is not in a gap or border
            }
            else
            {
                mouse += temp.Y;
                temp.Y = (mouse / (Side + Gap));
                return ((mouse - (temp.Y * (Side + Gap))) <= Side);  // test if the point is not in a gap or border
            }
        }

        /*
        public static string IntToHex(int number)
        {
            return String.Format("{0:x}", number);
        }

        public static int HexToInt(string hexString)
        {
            return int.Parse(hexString,
                System.Globalization.NumberStyles.HexNumber, null);
        }*/

        /*
        public static Color HexToColor(String hexString)
        // Translates a html hexadecimal definition of a color into a .NET Framework Color.
        // The input string must start with a '#' character and be followed by 6 hexadecimal
        // digits. The digits A-F are not case sensitive. If the conversion was not successfull
        // the color white will be returned.
        {
            Color actColor;
            int r,g,b;
            if ((hexString.StartsWith("#"))&&(hexString.Length==7))
            {
                r=HexToInt(hexString.Substring(1,2));
                g=HexToInt(hexString.Substring(3,2));
                b=HexToInt(hexString.Substring(5,2));
                actColor=Color.FromArgb(r,g,b);
            }
            else
            {
                actColor=Color.White;
            }
            return actColor;
        }
                 
        public static String ColorToHex(Color actColor)
        // Translates a .NET Framework Color into a string containing the html hexadecimal
        // representation of a color. The string has a leading '#' character that is followed
        // by 6 hexadecimal digits.
        {
            return "#"+IntToHex(actColor.R,2)+IntToHex(actColor.G,2)+IntToHex(actColor.B,2);
        } 
         */
    }
}