#region Namespaces
using System;
using System.Collections.Generic;
using System.Reflection;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Windows.Media.Imaging;
using System.Drawing.Imaging;
using System.Windows.Media;
#endregion

namespace ARCtools
{
    class App : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication a)
        {
            String tabname = "ARCTools";
            String panelname = "Tools";

            //create the bimMAP
           BitmapImage btn1img = new BitmapImage(new Uri("pack://application:,,,/ARCtools;component/Resources/RS32px.ico"));
           BitmapImage btn2img = new BitmapImage(new Uri("pack://application:,,,/ARCtools;component/Resources/PF32px.ico"));
           BitmapImage btn3img = new BitmapImage(new Uri("pack://application:,,,/ARCtools;component/Resources/cp32px_bMH_icon.ico"));

            a.CreateRibbonTab(tabname);


            var tester = a.CreateRibbonPanel(tabname, panelname);
            var button1 = new PushButtonData("FirstButton", "Search Room", Assembly.GetExecutingAssembly().Location, "ARCtools.SearchRoombyNumberMain");
            button1.LargeImage = btn1img;
            button1.ToolTip = "Room search is used to find the location of Rooms on a floor plan or section plan.";
            button1.LongDescription = "Which will show the linked model rooms also in the floor plan." +
                " The Room Number option shows the location directly, and the Room Name option iterates the rooms in a floor plan.";

            var btn1 = tester.AddItem(button1) as PushButton;

            var button2 = new PushButtonData("SecondtButton", "Place Family", Assembly.GetExecutingAssembly().Location, "ARCtools.PlaceFamilyMain");
            button2.LargeImage = btn2img;
            button2.ToolTip = "Place family by Coordinates allow to place the family on the coordinates";
            button2.LongDescription = "which is helpful when you find the location as per the site location and also locate the Project Base point," +
                " Survey Point and Project Origin Point.";
            var btn2 = tester.AddItem(button2) as PushButton;

         //   tester.AddStackedItems(button1, button1);

            var button3 = new PushButtonData("ThirdButton", "Create Room \n Plan", Assembly.GetExecutingAssembly().Location, "ARCtools.CreatePlanMain");
            button3.LargeImage = btn3img;
            button3.ToolTip = "In the tool is help to create floor plan and ceiling plan for the each rooms for the project";
            button3.LongDescription = "Which allow to apply Template for the plans and crop view offset for the each rooms and view name Prefix can preset.";
            var btn3 = tester.AddItem(button3) as PushButton;





            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }
    }
}
