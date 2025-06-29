using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;


namespace ARCtools
{
    public partial class CreatePlanForm : System.Windows.Forms.Form
    {

        // Boiler Plate
        private UIApplication uiapp;
        private UIDocument uidoc;
        private Autodesk.Revit.ApplicationServices.Application app;
        public Document doc;

        public CreatePlanForm(ExternalCommandData commandData)
        {
            InitializeComponent();
            uiapp = commandData.Application;
            uidoc = uiapp.ActiveUIDocument;
            app = uiapp.Application;
            doc = uidoc.Document;
            }


        //varilable from main Program
        public AutoCompleteMode AutoCompleteMode { get; private set; }
        public string Radioctrlvalue = "floorplan";
        public string vtemplate;
        public List<string> roomlist = new List<string>();
        public string prefix;
        public string sep = " ";
        public double off;
  
        //Floor Plan Radio
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Radioctrlvalue = "floorplan";
        }


        //Ceiling Plan Radio
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Radioctrlvalue = "ceilingplan";
        }

        //View Template Combo
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            IEnumerable<Autodesk.Revit.DB.View> views = new FilteredElementCollector(doc).OfClass(typeof(Autodesk.Revit.DB.View)).Cast<Autodesk.Revit.DB.View>();
            List<string> roomtemplete = new List<string>();





            foreach (Autodesk.Revit.DB.View view in views)
                {               
                if (radioButton1.Checked)
                    {
                    if (view.IsTemplate && view.ViewType.Equals(ViewType.FloorPlan))
                        {
                        roomtemplete.Add(view.Name.ToString());
                        }
                    }
                else if (radioButton2.Checked)
                    {
                    if (view.IsTemplate && view.ViewType.Equals(ViewType.CeilingPlan))
                        {
                        roomtemplete.Add(view.Name.ToString());
                        }
                    }
                }
            comboBox1.Items.Clear();

            foreach (string rmtpl in roomtemplete)
                {                   
                  comboBox1.Items.Add(rmtpl).ToString();
                }

            }


        //Room Selection
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        //Select all checkbox
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            selectall(checkBox1.Checked);
        }

        //select all method
        private void selectall(bool val)
        {
            if (val == true)
            {
                for (int i = 0; i <= listView1.Items.Count - 1; i++)
                {
                    if (!listView1.Items[i].Checked)
                        listView1.Items[i].Checked = val;
                }
            }
            else
            {
                for (int i = 0; i <= listView1.Items.Count - 1; i++)
                {
                    if (listView1.Items[i].Checked)
                        listView1.Items[i].Checked = val;
                }
            }
        }


        //Button OK
        private void button1_Click(object sender, EventArgs e)
        {
            List<string> msb = new List<string>();
            foreach (ListViewItem lst in listView1.CheckedItems)
                {
                roomlist.Add(lst.SubItems[1].Text.ToString());                                       
                }

            //assign DialogResult as OK for button;
            button1.DialogResult = DialogResult.OK;
            //debug bookmark
            Debug.WriteLine("OK Clicked");
        }

        //Button Cancel
        private void button2_Click(object sender, EventArgs e)
        {
            //assign DialogResult as Cancel for button;
            button2.DialogResult = DialogResult.Cancel;
            //debug bookmark
            Debug.WriteLine("Cancel Clicked");
        }

        //Form
        private void CreatePlanForm_Load(object sender, EventArgs e)
        {
            RoomFilter filter = new RoomFilter();
            //      FilteredElementCollector collector = new FilteredElementCollector(doc);
            IList<Element> rooms = new List<Element>();         

                foreach (Document document in uiapp.Application.Documents)
                    {
                    FilteredElementCollector collect = new FilteredElementCollector(document);
                    IList<Element> linkrooms = collect.WherePasses(filter).ToElements();
                    foreach (Room lrm in linkrooms)
                        {
                        rooms.Add(lrm);
                        }                    
                    }


            foreach (Element room in rooms)
            {
                ListViewItem listViewItem = new ListViewItem();

                Parameter parameter = room.get_Parameter(BuiltInParameter.ROOM_NUMBER);
                string roomNumber = (parameter.HasValue) ? parameter.AsString() : String.Empty;
                listViewItem.SubItems.Add(roomNumber.ToString());

                Parameter parameter1 = room.get_Parameter(BuiltInParameter.ROOM_NAME);
                string roomName = (parameter1.HasValue) ? parameter1.AsString() : String.Empty;
                listViewItem.SubItems.Add(roomName.ToString());
                listView1.Items.Add(listViewItem);
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
            {

            vtemplate = comboBox1.SelectedItem.ToString();

            }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
            {
            sep = comboBox2.SelectedItem.ToString();
            }

        private void textBox1_TextChanged(object sender, EventArgs e)
            {
            prefix = textBox1.Text.ToString();
            }

        private void textBox2_TextChanged(object sender, EventArgs e)
            {
            off = 0;
            try
                {
                DisplayUnitType displayUnitType = doc.GetUnits().GetFormatOptions(UnitType.UT_Length).DisplayUnits;
                off = UnitUtils.ConvertToInternalUnits(Convert.ToDouble(textBox2.Text.ToString())*-1, displayUnitType);
                }
            catch
                {
                TaskDialog.Show("Warning", "Enter Offset Numeric value ");
                }            
            }
        }
}
