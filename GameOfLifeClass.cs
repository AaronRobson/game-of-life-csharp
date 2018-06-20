using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace GameOfLife
{
    class GameOfLifeClass
    {
        const int BORN_NUM = 3;
        const int STAY_ALIVE_NUM = 2; // and 3
        const int A = 3;
        /*
        const string PROJECT_NAME = "Game Of Life";
        const string AUTHOR_NAME  = "Aaron Robson";
        const string YEAR         = "2007";
        const string SEP_DASH     = " - ";
        const string PROG_VERSION = "6.00" + SEP_DASH + "Recoded in C#, Object-Orientated, Setting Storage"; //"5.00" + SEP_DASH + "Object-Orientated, Setting Storage & Black Skin"; //"4.00 - Object-Orientated, Setting Storage & Black Skin"; //"A.00 - Object-Orientated & Setting Storage"; //"2.00 - Object-Orientated";  //"1.00 - Procedural";
        const string TITLE_BAR = PROJECT_NAME + SEP_DASH + AUTHOR_NAME + SEP_DASH + YEAR + SEP_DASH + "Version: " + PROG_VERSION;
        const byte DEF_TIME =   0;  // Overwrites what is set in form if no setting file can be found
        const byte DEF_MAX  = 100;
        const byte DEF_SIDE =   7;
        const byte GAP      =   1;
        const bool DEF_EDGE_RETURN = true;
        const bool DEF_SIMPLE      = false;
        const string SETTINGS_FOLDER    = "System";
        const string SETTINGS_NAME      = "Settings_File";
        const string SETTINGS_EXTENSION = "ini";
        const string SETTINGS_File_Loc = SETTINGS_FOLDER + @"\" + SETTINGS_NAME + "." + SETTINGS_EXTENSION;
        const string SEP_COL = ": ";
        const string POPULATION_TEXT = "Pop" + SEP_COL;
        const string GENERATION_TEXT = "Gen" + SEP_COL;
        const string START = "&Start";
        const string STOP  = "&Stop";
        const int DEF  = 0xFFFFFF;    //clWhite;    // Colours (RGB)
        const int BACK = 0x000000;    //clBlack;
        const int FORE = 0x00FF00;    //clLime;
        */

        int validX;
        int validY;

        bool currentArr;   // True for First, False for Second

        bool edge = true;
        bool lastChanged = true;

        bool[,,] Arr;  // Arr = new bool[A,,];  //Arr : array of array of array of boolean;     //[0 .. 2, 0 .. max-1, 0 .. max-1]
        bool[,,] tempArr;  // only used in the Max_Set methods
        Random RandomClass = new Random();

        UInt64 generation;
        UInt64 population;
       
        private int CurArr()
        {
            return (currentArr) ? 0 : 1;  // if (currentArr) return 0; else return 1;
        }
     
        private int OthArr()
        {
            return (currentArr) ? 1 : 0;  // if (currentArr) return 1; else return 0;
        }
        
        private bool InRange(int inputX, int inputY)
        {
            return ((0 <= inputX) && (inputX < Get_MaxX()) && (0 <= inputY) && (inputY < Get_MaxY()));
        }
       
        public bool ValidX(int num)
        {
            validX = num;

            if (num < 0)
            {
                validX = Arr.GetLength(1) + num;
                return edge;
            }
            else
            {
                if (Arr.GetLength(1) <= num)
                {
                    validX = num - Arr.GetLength(1);
                    return edge;
                }
            }
            return true;
        }

        public bool ValidY(int num)
        {
            validY = num;

            if (num < 0)
            {
                validY = Arr.GetLength(2) + num;
                return edge;
            }
            else
            {
                if (Arr.GetLength(2) <= num)
                {
                    validY = num - Arr.GetLength(2);
                    return edge;
                }
            }
            return true;

            /*
            if ((0 <= num) && (num < max))   // More even speed but slower
                return num;
            else
                if (max-1 < num)
                    return num - max;
                else
                    return max + num;   */

        }
    /*
        private bool Valid(int inputX, int inputY)
        {
            return (ValidX(inputX) & ValidY(inputY));  // single & as it is safer to assume the numbers left afterward may be used
        }
    */
        private void All_Change()   // all around changed
        {
            lastChanged = true;

            for (int b = 0; b < Arr.GetLength(1); b++)
                for (int c = 0; c < Arr.GetLength(2); c++)
                    Arr[2,b,c] = true;
        }

        private void Update_Check()
        {
            for (int b = 0; b < Arr.GetLength(1); b++)
                for (int c = 0; c < Arr.GetLength(2); c++)
                    Arr[2, b, c] = Arr[0,b,c] != Arr[1,b,c];
        }

       private bool Check_Change(int x, int y)
       {
           for (int xCount = x - 1; (xCount <= x + 1); xCount++)
               for (int yCount = y - 1; (yCount <= y + 1); yCount++)
               {
                   // could have done single & to make sure both are done but they are overwriten the next time anyway
                    if (ValidX(xCount) & ValidY(yCount))
                        if (Arr[2, validX, validY])
                            return true;
               }

           return false;
       }

        public byte Those_Around(int b, int c)
        {
            byte counter = 0;

            // if (Arr[Calc_Current_Arr(),Valid(b+b_Count),Valid(c+c_Count)] = True) and (Off_Edge(b+b_Count) = False) and (Off_Edge(c+c_Count) = False)
            for (sbyte b_Count = -1; (b_Count <= 1); b_Count++)
                for (sbyte c_Count = -1; (c_Count <= 1); c_Count++)
                {
                    if (ValidX(b + b_Count) && ValidY(c + c_Count))
                        if (Arr[CurArr(), validX, validY])
                            counter++;
                }

            // if (Arr[Calc_Current_Arr(), b, c]) counter--;  // no longer necessary

            return counter;
        }

       public bool Get_Current_Point(int b, int c)
       {
           return Arr[CurArr(), b, c];
       }

       public bool Iteration()
       {
           lastChanged = false; 
           population = 0;

           // don't attempt to store the value for Those_Around it reduces the speed to circa a half (7000+ to 4328 (30second with line oscilator))
           for (int b = 0; b < Arr.GetLength(1); b++)
               for (int c = 0; c < Arr.GetLength(2); c++)
               {
                   if (Check_Change(b, c))
                   {
                       if ((Those_Around(b, c) == STAY_ALIVE_NUM + 1) || (Arr[CurArr(), b, c] && (Those_Around(b, c) == BORN_NUM + 1)))
                       {       // if 3 around become alive, if alive and 2 around stay alive, otherwise die
                           if (!Arr[CurArr(), b, c])
                               lastChanged = true;

                           Arr[OthArr(), b, c] = true;
                       }
                       else
                       {
                           if (Arr[CurArr(), b, c])
                               lastChanged = true;

                           Arr[OthArr(), b, c] = false;
                       }
                   }

                   // must be performed outside of the Check_Change if statement
                   if (Arr[OthArr(), b, c])
                       population++;
               }

           currentArr = !currentArr;  // Switch Arrays


           if (lastChanged)
           {
               // slows slightly but means no next generation when nothing has been changed (indicating still life or extinction)
               generation++;
               Update_Check();  // after so as to not to interfere with All_Change() in Set_Edge and Set_Max to avoid illogical remnants at edges
           }

           return lastChanged;
       }

       public void SetPoint(int x, int y)  //overload;
       {
           if (InRange(x, y))
           {
               if (Arr[CurArr(), x, y])  //better than Arr[Calc_Current_Arr(),b,c] = !(Arr[Calc_Current_Arr(),b,c]); as only checks once
               {
                   Arr[CurArr(), x, y] = false;

                   // no need for //Calc_Population();
                   population--;
               }
               else
               {
                   Arr[CurArr(), x, y] = true;
                   population++;
               }
               Arr[2, x, y] = true;     // Set Change
               lastChanged = true;
           }
       }

        public void SetPoint(int x, int y, bool wanted) //overload;
        {
            if (InRange(x, y))
            {
                // XOR (if different)
                if (Arr[CurArr(), x, y] ^ wanted)
                {
                    if (wanted)
                        population++;
                    else
                        population--;

                    Arr[CurArr(), x, y] = wanted;
                    Arr[2, x, y] = true;
                    lastChanged = true;
                }
            }
        }

        public void SetPoint(Point input) //overload;
        {
            SetPoint(input.X, input.Y);
        }

        public void SetPoint(Point input, bool wanted) //overload;
        {
            SetPoint(input.X, input.Y, wanted);
        }

        public void Reset(bool wanted)    // and startup // make vacuum
        {
            generation = 0;
            population = (wanted) ? Max_Population() : 0 ;

            for (int b = 0; b < Arr.GetLength(1); b++)
                for (int c = 0; c < Arr.GetLength(2); c++)
                    Arr[CurArr(), b, c] = wanted;  // only the current array is needed to be cleared
    
            All_Change();     // don't: All_Change incorporated into 0 to 2 (instead of 0 to 1) as 2's must be changed to true
        }

        public bool Get_LastChanged()
        {
            return lastChanged;
        }

        public UInt64 Max_Population()
        {
            return (UInt64)Arr.GetLength(1) * (UInt64)Arr.GetLength(2);
        }

        public void Reset()
        {
            Reset(false);
        }

       public void Fill_Random()
       {
           population = 0;

           for (int b = 0; b < Arr.GetLength(1); b++)
               for (int c = 0; c < Arr.GetLength(2); c++)
                   if (RandomClass.Next(2) == 0)
                   {
                       Arr[CurArr(), b, c] = true;

                       // custom Calc_population();
                       population++;
                   }
                   else
                       Arr[CurArr(), b, c] = false;

         All_Change();
         generation = 0;
       }

        public void Fill_Random(uint amount)
        {
            Reset();

            if (Arr.GetLength(1) * Arr.GetLength(2) < amount)
            {
                Random RandomClass = new Random();
                int randomX;
                int randomY;

                while ((UInt64)amount < population)
                {
                    randomX = RandomClass.Next(0, Arr.GetLength(1) + 1);
                    randomY = RandomClass.Next(0, Arr.GetLength(2) + 1);
                    if (!Arr[CurArr(), randomX, randomY]) // if not already true
                    {
                        Arr[CurArr(), randomX, randomY] = true;
                        population++;
                    }
                }
            }
            else
                Negative();
        }

       public void Negative()
       {
           for (int b = 0; b < Arr.GetLength(1); b++)
               for (int c = 0; c < Arr.GetLength(2); c++)
                   Arr[CurArr(), b, c] = !Arr[CurArr(), b, c];

         All_Change();
         population = (UInt64)(Arr.GetLength(1) * Arr.GetLength(2)) - population;  // custom Calc_Population();
       }

       public void Calc_Population()
       {
           UInt64 tempPopulation = 0;

           for (int b = 0; b < Arr.GetLength(1); b++)
               for (int c = 0; c < Arr.GetLength(2); c++)
                   if (Arr[CurArr(), b, c])
                       tempPopulation++;

           population = tempPopulation;
       }

       public bool Get_Edge()
       {
           return edge;
       }

       public void Set_Edge(bool inEdge)
       {
           edge = inEdge;
           All_Change();      // to avoid illogical remnants at edges, old array cannot be trusted to be relevant
       }

        public int Get_MaxX()
        {
            return Arr.GetLength(1);
        }

        public int Get_MaxY()
        {
            return Arr.GetLength(2);
        }

        private int One_Min(int input) // returns 1 if the input is lower
        {
            if (input < 1)
                return 1;
            else
                return input;
        }

        private int One_Min(uint input)
        {
            return One_Min((int)input);
        }

        public void Set_MaxX(int maxX)
        {
            Arr = new bool[A, One_Min(maxX), Arr.GetLength(2)];
            
            All_Change();      // to avoid illogical remnants at edges, old array cannot be trusted to be relevant
            Calc_Population();
        }

        public void Set_MaxY(int maxY)
        {
            Arr = new bool[A, Arr.GetLength(1), One_Min(maxY)];

            All_Change();      // to avoid illogical remnants at edges, old array cannot be trusted to be relevant
            Calc_Population();
        }

        public GameOfLifeClass(int maxX, int maxY)
        {
            Arr = new bool[A, One_Min(maxX), One_Min(maxY)];
        }

        public GameOfLifeClass(uint maxX, uint maxY)
        {
            Arr = new bool[A, One_Min(maxX), One_Min(maxY)];
        }

        public GameOfLifeClass()
        {
            Arr = new bool[A, One_Min(1), One_Min(1)];
        }

        public void Set_Max(int maxX, int maxY)
        {
            maxX = One_Min(maxX);
            maxY = One_Min(maxY);

            int lowX = Low(maxX, Get_MaxX());
            int lowY = Low(maxY, Get_MaxY());

            tempArr = new bool [A, lowX, lowY];

             // tempArr = Arr
            for (int a = 0; a < A - 1; a++)
                for (int x = 0; x < lowX; x++)
                    for (int y = 0; y < lowY; y++)
                        tempArr[a, x, y] = Arr[a, x, y];

            // SetLength(Arr,A,maxX,maxY);
            Arr = new bool[A, maxX, maxY];

            // Arr = tempArr
            for (int a = 0; a < A - 1; a++)
                for (int x = 0; x < lowX; x++)
                    for (int y = 0; y < lowY; y++)
                        Arr[a, x, y] = tempArr[a, x, y];

            All_Change();      // to avoid illogical remnants at edges, old array cannot be trusted to be relevant
            Calc_Population();
        }

        private int Low(int input1, int input2)
        {
            if (input1 < input2)
                return input1;
            else
                return input2;
        }

        public UInt64 Get_Population_As_Int()
        {
          return population;
        }

        public string Get_Population_As_Str()
        {
          return Convert.ToString(population);
        }

        public UInt64 Get_Generation_As_Int()
        {
          return generation;
        }

        public string Get_Generation_As_Str()
        {
          return Convert.ToString(generation);
        }

        public void Spawn_Glider()
        {
            int xOffset = 3;
            int yOffset = 3;

            for (int x = 0; x < (xOffset * xOffset); x++)
                for (int y = 0; y < (yOffset * yOffset); y++)
                    SetPoint(x, y, false); // , false

            SetPoint(1 + xOffset, 0 + yOffset);
            SetPoint(2 + xOffset, 1 + yOffset);
            SetPoint(0 + xOffset, 2 + yOffset);
            SetPoint(1 + xOffset, 2 + yOffset);
            SetPoint(2 + xOffset, 2 + yOffset);
        }

        public void Spawn_Blinker()
        {
            int xOffset = 3;
            int yOffset = 3;

            for (int x = 0; x < (xOffset * xOffset); x++)
                for (int y = 0; y < (yOffset * yOffset); y++)
                    SetPoint(x, y, false);

            SetPoint(0 + xOffset, 1 + yOffset);
            SetPoint(1 + xOffset, 1 + yOffset);
            SetPoint(2 + xOffset, 1 + yOffset);
        }

        public void Spawn_Corner_Block()
        {
            Reset();

            //SetPoint(0,0);
            //SetPoint(0,Get_MaxY()-1);
            //SetPoint(Get_MaxX()-1,0);
            //SetPoint(Get_MaxX()-1,Get_MaxY()-1);
            SetPoint(3,0);
            SetPoint(2,0);
            SetPoint(0,1);
            SetPoint(3,1);
            SetPoint(0,2);
            SetPoint(1,2);
        }
    }
}
