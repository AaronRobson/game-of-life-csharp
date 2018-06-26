using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace GameOfLife
{
    class Config_File  // saves in the current directory
    {
        const string FILENAME = "GOLconfig";
        const string EXTENSION = "ini";
        const string FULLNAME = FILENAME + "." + EXTENSION;
        const string SEP = ": ";

        const string HORI = "horizontal" + SEP;
        const string VERT = "vertical" + SEP;
        const string EDGE = "edge" + SEP;
        const string TIME = "time" + SEP;
        const string SIDE = "side" + SEP;
        const string GAP = "gap" + SEP;
        const string BORDER = "border" + SEP;

        public static void WriteFile(uint horizontal, uint vertical, bool edge, int time, byte side, byte gap, bool border)
        {
            TextWriter tw = new StreamWriter(FULLNAME);
            
            tw.WriteLine(HORI + horizontal);
            tw.WriteLine(VERT + vertical);
            tw.WriteLine(EDGE + edge);
            tw.WriteLine(TIME + time);
            tw.WriteLine(SIDE + side);
            tw.WriteLine(GAP + gap);
            tw.WriteLine(BORDER + border);

            tw.Close();
        }
        
        public static void ReadFile(ref uint horizontal, ref uint vertical, ref bool edge, ref int time, ref byte side, ref byte gap, ref bool border)
        {
            if (System.IO.File.Exists(FULLNAME))
            {
                TextReader tr = new StreamReader(FULLNAME);

                string input = null;
                while ((input = tr.ReadLine()) != null)
                {
                    try
                    {
                        if (input.StartsWith(HORI))
                            horizontal = Convert.ToUInt32(Value(input, HORI));
                        else
                            if (input.StartsWith(VERT))
                                vertical = Convert.ToUInt32(Value(input, VERT));
                            else
                                if (input.StartsWith(EDGE))
                                    edge = Convert.ToBoolean(Value(input, EDGE));
                                else
                                    if (input.StartsWith(TIME))
                                        time = Convert.ToInt32(Value(input, TIME));
                                    else
                                        if (input.StartsWith(SIDE))
                                            side = Convert.ToByte(Value(input, SIDE));
                                        else
                                            if (input.StartsWith(GAP))
                                                gap = Convert.ToByte(Value(input, GAP));
                                            else
                                                if (input.StartsWith(BORDER))
                                                    border = Convert.ToBoolean(Value(input, BORDER));

                    }
                    catch { }
                }

                tr.Close();
            }
        }

        private static string Value(string input, string constant)
        {
            if (constant.Length < input.Length)
                return input.Substring(constant.Length, input.Length - constant.Length);
            else
                return String.Empty;
        }
    }
}
