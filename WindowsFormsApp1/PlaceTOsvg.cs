using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;
using System.Xml.Linq;
using System.Xml;
using System.IO;

namespace WindowsFormsApp1
{
    class PlaceTOsvg
    {
       
        public List<string> lines;        //declariton of lines
        public List<string> xrrbooklist;  //declariton of xrrbooklist

        public List<string> vehicles = new List<string>(); //declariton of vehicles list
        int location;                                      // specified line in file
        public PlaceTOsvg(string pathh, IEnumerable<string> roroload, IEnumerable<string> rrbooklist)
        {
            lines = File.ReadAllLines(pathh).ToList();     

            xrrbooklist = rrbooklist.ToList();  // convet to list

            //////////////////////////////////
            //Place vehicles to  the svg file 
            //////////////////////////////////
          
            int f = 0;
            double x = 65;
            int y = 135;

            while (f < int.Parse(xrrbooklist[11].Split(",".ToCharArray())[26]))     // LOOP it specified number of vehicle times
            {

                double result = (double.Parse(xrrbooklist[11].Split(',')[9], System.Globalization.CultureInfo.InvariantCulture)) * 5.3;  // blank between the vehices  (change only 5.3 value)  


                double wid = (double.Parse(xrrbooklist[11].Split(',')[9], System.Globalization.CultureInfo.InvariantCulture)) * 5;   // width of car

                x += result; 

                string up = "<rect id = \"rect3713\" width = \"" + wid + "\" height = \"" + 1 + xrrbooklist[11].Split(",".ToCharArray())[11] + "\" x = \"" + x + 
                    "\" y = \"" + y + "\" style = \"stroke-width:0.1;stroke:black;stroke-width:0.5;stroke-opacity:0.9 \" fill=\"" + xrrbooklist[11].Split(",".ToCharArray())[29] + "\" />";

                location = 9740;
                lines.Insert(location, up.Replace(',', '.')); // replaces them because when convert to string it changes automatically and destroyes the scales

                f++;
            }

            int d = 0;

            x += (double.Parse(xrrbooklist[11].Split(',')[9], System.Globalization.CultureInfo.InvariantCulture)) * 5.3; // blank between the vehices  (change only 5.3 value)  

            while (d < int.Parse(xrrbooklist[8].Split(",".ToCharArray())[26])) // do it specified number of vehicle times
            {


                double result = (double.Parse(xrrbooklist[8].Split(',')[9], System.Globalization.CultureInfo.InvariantCulture)) * 5.3;


                double wid = (double.Parse(xrrbooklist[8].Split(',')[9], System.Globalization.CultureInfo.InvariantCulture)) * 5;  // width of car



                string up = "<rect id = \"rect3713\" width = \"" + wid + "\" height = \"" + 1 + xrrbooklist[8].Split(",".ToCharArray())[11] + "\" x = \"" + x + 
                    "\" y = \"" + y + "\" style = \"stroke-width:0.1;stroke:black;stroke-width:0.5;stroke-opacity:0.9 \" fill=\"" + xrrbooklist[8].Split(",".ToCharArray())[29] + "\" />";

                x += result;

                location = 9740;
                lines.Insert(location, up.Replace(',', '.'));// replaces them because when convert to string it changes automatically and destroyes the scales

                d++;
            }

            int c = 0;

            while (c < int.Parse(xrrbooklist[3].Split(",".ToCharArray())[26])) // do it specified number of vehicle times
            {
                if (x < 820 & y == 135)
                {

                    double result = (double.Parse(xrrbooklist[3].Split(',')[9], System.Globalization.CultureInfo.InvariantCulture)) * 5.3;// width of car


                    double wid = (double.Parse(xrrbooklist[3].Split(',')[9], System.Globalization.CultureInfo.InvariantCulture)) * 5;   // width



                    string up = "<rect id = \"rect3713\" width = \"" + wid + "\" height = \"" + 1 + xrrbooklist[3].Split(",".ToCharArray())[11] + "\" x = \"" + x + 
                        "\" y = \"" + y + "\" style = \"stroke-width:0.1;stroke:black;stroke-width:0.5;stroke-opacity:0.9 \" fill=\"" + xrrbooklist[3].Split(",".ToCharArray())[29] + "\" />";

                    x += result;

                    location = 9740;
                    lines.Insert(location, up.Replace(',', '.'));// replaces them because when convert to string it changes automatically and destroyes the scales

                    c++;
                }
                else
                {
                    x = 183;
                    y = 150;
                    double result = (double.Parse(xrrbooklist[3].Split(',')[9], System.Globalization.CultureInfo.InvariantCulture)) * 5.3;

                    double wid = (double.Parse(xrrbooklist[3].Split(',')[9], System.Globalization.CultureInfo.InvariantCulture)) * 5;  // width of car

                    string up = "<rect id = \"rect3713\" width = \"" + wid + "\" height = \"" + 1 + xrrbooklist[3].Split(",".ToCharArray())[11] + "\" x = \"" + x + 
                        "\" y = \"" + y + "\" style = \"stroke-width:0.1;stroke:black;stroke-width:0.5;stroke-opacity:0.9 \" fill=\"" + xrrbooklist[3].Split(",".ToCharArray())[29] + "\" />";
                    x += result;

                    location = 9740;
                    lines.Insert(location, up.Replace(',', '.'));// replaces them because when convert to string it changes automatically and destroyes the scales

                    c++;
                }

            }

            int e = 0;

            while (e < int.Parse(xrrbooklist[5].Split(",".ToCharArray())[26])) // do it specified number of vehicle times
            {

                double result = (double.Parse(xrrbooklist[5].Split(',')[9], System.Globalization.CultureInfo.InvariantCulture)) * 5.3; // blank between the vehices  (change only 5.3 value)  

                double wid = (double.Parse(xrrbooklist[5].Split(',')[9], System.Globalization.CultureInfo.InvariantCulture)) * 5;   // width of car

                string up = "<rect id = \"rect3713\" width = \"" + wid + "\" height = \"" + 1 + xrrbooklist[5].Split(",".ToCharArray())[11] + "\" x = \"" + x + 
                    "\" y = \"" + y + "\" style = \"stroke-width:0.1;stroke:black;stroke-width:0.5;stroke-opacity:0.9 \" fill=\"" + xrrbooklist[5].Split(",".ToCharArray())[29] + "\" />";
                x += result;

                location = 9740;
                lines.Insert(location, up.Replace(',', '.'));// replaces them because when convert to string it changes automatically and destroyes the scales

                e++;

            }

            File.WriteAllLines(pathh, lines); // write them in to svg file
        }

    }
}