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
    class ParseLD
    {
        public IEnumerable<string> rrbooklist;  //shared variables
        public IEnumerable<string> roroload;    //shared variables
        public ParseLD(string pathos)
        {
            string ldfilepath = pathos;    // default path
            List<string> lines2 = File.ReadAllLines(ldfilepath).ToList();  // read the ld file

            string[] parts = new string[] { };
            int i = 1;
            int e = 1;
            foreach (string line in lines2)      // count lines till TAB*OB_RRBOOKLIST 
            {

                if (line.Contains("TAB*OB_RRBOOKLIST"))
                {
                    break;
                }
                else
                    i++;

            }
            int y = i+1;

            IEnumerable<string> lines = lines2.Skip(y);

            foreach (string line1 in lines)      // count lines till TAB*OB_IMOLOAD 
            {
                if (line1.Contains("TAB*OB_IMOLOAD"))
                {
                    break;
                }
                else
                    e++;
            }

            int z = e - 2;

            rrbooklist = lines.Take(z);     //till here i got the vehicles in rrbooklist  &   14 lines inside

            int o = 1;
            int m = 1;

            foreach (string lin in lines2)    // count lines till TAB*OB_ROROLOAD
            {

                if (lin.Contains("TAB*OB_ROROLOAD"))
                {
                    break;
                }
                else
                    o++;

            }
            int x = o + 1;

            IEnumerable<string> lin1 = lines2.Skip(x);

            foreach (string lin2 in lin1)      // count lines till TAB*OB_RRBOOKLIST
            {
                if (lin2.Contains("TAB*OB_RRBOOKLIST"))
                {
                    break;
                }
                else
                    m++;
            }

            int s = m - 2;

            roroload = lin1.Take(s);        //till here i got the vehicles in rororload  &   248 lines lines inside



        }
    }
}