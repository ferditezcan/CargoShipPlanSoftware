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
/*
How to run ?-- Load Booking; Select the .ld file -> Load tanks; Select the svg file -> Generate Plan.   ( Load checking button only shows that what is in the rrbooklist)
NOT! If you close via stop button in VS studio it wont delete the generated vehicles; Then you have to delete it manually in the svg file.. Thats why for normal usege just close it via close symbol from the program. 
*/

namespace WindowsFormsApp1
{
    public partial class CargoShip : Form
    {
        string LDpath;    // declaration of ld file path 
        string SVGpath;   // declaration of svg file path 
        IEnumerable<string> Xroroload;          //roroload list
        IEnumerable<string> Xrrbooklist;        //Xrrbooklist list
        public CargoShip()
        {
            InitializeComponent();  // initialize the components which used in  the Form1
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();                             //run the timer                                                    
            label10.Text = DateTime.Now.ToString();     //label turns to date and time
        }
        // date and timer   
        private void Timer1_Tick(object sender, EventArgs e)   // date and time   
        {
            label10.Text = DateTime.Now.ToString();                 
            timer1.Start();
        }
        // ld file get path button
        private void Button1_Click(object sender, EventArgs e)      
        {
            getpath();              // ld get path function call


            //List declarations
            List<string> vehicles = new List<string>();     
            List<string> xpc = new List<string>();
            List<string> colours = new List<string>();
            List<string> xrrbooklist = Xrrbooklist.ToList();

            int totveh=0;                   // total vehicles number
            double totweight=0;             // total weight number
            int ii = 0;                     

            while (ii < 14)               // there are 14 diffrent car
            {
                string ha = xrrbooklist[ii].Split(",".ToCharArray())[26];       // adding the number of vehicle pieces to list 
                vehicles.Add(ha);                           

                string za = xrrbooklist[ii].Split(",".ToCharArray())[2];            // adding the vehicle list to list 
                xpc.Add(za);

                string ta = xrrbooklist[ii].Split(",".ToCharArray())[29];           // adding the vehicle colours to list
                colours.Add(ta);

                totveh += int.Parse(xrrbooklist[ii].Split(",".ToCharArray())[26]);      // total number of vehicles

                totweight += double.Parse(xrrbooklist[ii].Split(",".ToCharArray())[33], System.Globalization.CultureInfo.InvariantCulture);   // total weight

                ii++;
            }

            // Add them all to in lisbox and labels :
            listBox1.DataSource = vehicles;   
            listBox2.DataSource = xpc;
            listBox3.DataSource = colours;
            label12.Text = (Convert.ToString(totveh));
            label1.Text = (Convert.ToString(totweight));

        }
        private void CargoShip_FormClosing(object sender, FormClosingEventArgs e)       // actives the clear class and clears the svg file 
        {
            if (SVGpath != null)    
            {
                string SVGpath = openFileDialog1.FileName;       // ger path           
                Clear place = new Clear(SVGpath, Xroroload, Xrrbooklist);       // run the clear class
            }
        }
        public void PlaceToSvg()  // places them into svg file 
        {    
                   
                    PlaceTOsvg place = new PlaceTOsvg(SVGpath, Xroroload, Xrrbooklist);   //run the PlaceTOsvg 
                    this.richTextBox1.Visible = false;                  
                    webBrowser1.Refresh();  // refresh the browser

        }
        private void Button2_Click(object sender, EventArgs e)                  // button that loads the svg file 
        {
            if (LDpath != null)
            {
                openFileDialog1.Title = "Please select the SVG file";     // dialog declarations
                openFileDialog1.FileName = "select the file";
                openFileDialog1.Filter = "LD Files (*.svg)|*.svg";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    SVGpath = openFileDialog1.FileName;             // get path
                    this.webBrowser1.Navigate(SVGpath);             // browse it

                    this.richTextBox1.Visible = false;

                }
                else
                {
                    MessageBox.Show("You should select the .svg file");
                }
            }
            else
            {
                MessageBox.Show("First you should import the .ld file ");
            }

        }
        public void getpath()                                                    // getting parsel ld file exactly 
        {
            openFileDialog1.Title = "Please select the LD file";            // dialog declarations
            openFileDialog1.FileName = "select the file";
            openFileDialog1.Filter = "LD Files (*.ld)|*.ld";
            
           

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                LDpath = openFileDialog1.FileName;            // get path 
                ParseLD place = new ParseLD(LDpath);          // run the ParseLD class
                Xroroload = place.roroload;                  // get the parsed pieces to form1       
                Xrrbooklist = place.rrbooklist;              // get the parsed pieces to form1     
            }
            else
            {
                MessageBox.Show("You should select the .ld file");
            }
        }

        private void Button11_Click(object sender, EventArgs e)    // button that shows roroload list on screen
        {
            if (LDpath != null)
            {
                richTextBox1.Visible = true;                    
            List<string> Xroroload1;           // roroload list
            Xroroload1 = Xroroload.ToList();   
            richTextBox1.Lines = Xroroload1.ToArray();   // print them on the richTextBox1
            }
            else
            {
                MessageBox.Show("You should select the .ld file");
            }
        }

        int cc = 0;
        private void Button6_Click(object sender, EventArgs e)      // button that generates specified plan
        {
           
            if (SVGpath != null & LDpath != null)
            {
                
                if (cc == 0){
                    PlaceToSvg();                       // runs the PlaceToSvg class
                    cc = 1;
                    //button6.Enabled = false;
                }  
                else
                    richTextBox1.Visible = false;
            }
            else
            {
                richTextBox1.Visible = false;
            }
            
        }

        private void CargoShip_Load(object sender, EventArgs e)
        {

        }
    }
}