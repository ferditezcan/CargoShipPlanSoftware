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
    class Clear
    {
        int location;  // specified place in svg
        public List<string> lines;  
        public List<string> xrrbooklist;

        public Clear(string pathh, IEnumerable<string> roroload, IEnumerable<string> rrbooklist)   
        {
            lines = File.ReadAllLines(pathh).ToList();   // read lines of svg file
            xrrbooklist = rrbooklist.ToList();           // convert to list

            lines = File.ReadAllLines(pathh).ToList();      
            location = 9740;                                // location of cleaned place
            int a = int.Parse(xrrbooklist[11].Split(",".ToCharArray())[26])+ int.Parse(xrrbooklist[8].Split(",".ToCharArray())[26])+ int.Parse(xrrbooklist[3].Split(",".ToCharArray())[26]) 
                                                                                   + int.Parse(xrrbooklist[5].Split(",".ToCharArray())[26]);   //  used vehicles which needed to delete
            lines.RemoveRange(location, a);  // delete the range starting from loaction, number of a lines
            File.WriteAllLines(pathh, lines);    //write lines in file
        }
    }
}
