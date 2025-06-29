using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.ApplicationServices;
using System.Diagnostics;

namespace ARCtools
{
    public partial class SearchRoombyNumberForm : System.Windows.Forms.Form
    {
        
        private UIApplication uiapp;
        private UIDocument uidoc;
        private Autodesk.Revit.ApplicationServices.Application app;
        private Document doc;

        public String rnumber;
        public string radioctrl = "Name";

        public AutoCompleteMode AutoCompleteMode { get; private set; }

        public SearchRoombyNumberForm(ExternalCommandData commandData)
        {
            InitializeComponent();
            uiapp = commandData.Application;
            uidoc = uiapp.ActiveUIDocument;
            app = uiapp.Application;
            doc = uidoc.Document;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

      

        private void searchButton_Click(object sender, EventArgs e) 
        {

                rnumber = roomNameBox.Text;
                searchButton.DialogResult = DialogResult.OK;
                Debug.WriteLine("Search Clicked");


        }

        private void cancelButton_Click(object sender, EventArgs e)
        {

            

            cancelButton.DialogResult = DialogResult.Cancel;
            Debug.WriteLine("Cancel Clicked");
          
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void SearchRoombyNumberForm_Load(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
            {

            radioctrl = "Name";  

            }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
            {
            radioctrl = "Number";
            }
        }
}
