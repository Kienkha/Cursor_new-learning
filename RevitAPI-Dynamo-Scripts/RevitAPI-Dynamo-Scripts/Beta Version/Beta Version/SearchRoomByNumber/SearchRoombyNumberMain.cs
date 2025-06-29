#region Namespaces
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;
#endregion

namespace ARCtools
{
    [Transaction(TransactionMode.Manual)]
    public class SearchRoombyNumberMain : IExternalCommand
        {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
            {

            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;


            //get input from form

            SearchRoombyNumberForm form = new SearchRoombyNumberForm(commandData);
            // Excute Form
            form.ShowDialog();

            // get value from Form
            string number = form.rnumber;
            string radiocontrol = form.radioctrl;


            // get Room Element 
            RoomFilter filter = new RoomFilter();

            IList<Element> rooms = new List<Element>();
            foreach (Document documents in uiapp.Application.Documents)
                {
                FilteredElementCollector collect = new FilteredElementCollector(documents);
                IList<Element> linkedrooms = collect.WherePasses(filter).ToElements();
                foreach (Room lrms in linkedrooms)
                    {
                    rooms.Add(lrms);
                    }
                }


            // Get the active view of the current document.
            Autodesk.Revit.DB.View view = doc.ActiveView;

            using (TransactionGroup tg = new TransactionGroup(doc, "Create and Orient Instances"))
                {
                tg.Start();

                if ((view is Autodesk.Revit.DB.ViewPlan || view is Autodesk.Revit.DB.ViewSection))
                    {

                    if (radiocontrol == "Name")
                        {
                        try
                            {
                            using (Transaction t1 = new Transaction(doc, "Search Room"))
                                {
                                t1.Start();
                                foreach (Room room in rooms)
                                {
                                    String roomname = room.get_Parameter(BuiltInParameter.ROOM_NAME).AsString();

                                    if (roomname==number || roomname.Contains(number) || number.Contains(roomname))
                                        {
                                        
                                        UIView uiView = uidoc.GetOpenUIViews().FirstOrDefault<UIView>(uv => uv.ViewId.Equals(doc.ActiveView.Id));
                                        LocationPoint roomlocation = room.Location as LocationPoint;
                                        uiView.ZoomAndCenterRectangle(new XYZ(roomlocation.Point.X - 10, roomlocation.Point.Y - 10, roomlocation.Point.Z - 10), new XYZ(roomlocation.Point.X + 10, roomlocation.Point.Y + 10, roomlocation.Point.Z + 10));

                                        TaskDialog taskDialog = new TaskDialog("Decision");
                                        taskDialog.MainContent = "This is the Room you Search";
                                        taskDialog.CommonButtons = TaskDialogCommonButtons.Yes | TaskDialogCommonButtons.No | TaskDialogCommonButtons.Cancel;
                                        TaskDialogResult result = taskDialog.Show();

                                        if(result == TaskDialogResult.Yes)
                                            {
                                            break;
                                            }
                                        else if(result == TaskDialogResult.Cancel)
                                            {
                                            break;       
                                            }
                                        else
                                            {
                                            continue;
                                            }
                                        }
                                    //else
                                    //    {
                                    //    TaskDialog.Show("Warning", "Room Name not Available");
                                    //    return Result.Failed;
                                    //    }
                                    }
             

                                t1.Commit();
                                }
                            TaskDialog.Show("Done", "Search Completed");
                            return Result.Succeeded;
                            }
                        catch
                            {
                            return Result.Failed;
                            }


                        }
                    else if (radiocontrol == "Number")
                        {
                        using (Transaction t2 = new Transaction(doc, "Search Room"))
                            {
                            t2.Start();
                            try
                                {
                                foreach (Element iroom in rooms)
                                    {
                                    String roomnumber = iroom.get_Parameter(BuiltInParameter.ROOM_NUMBER).AsString();
                                    if (roomnumber == number)
                                        {
                                        //uidoc.ShowElements(iroom);
                                        //Transform transform;
                                        try
                                            {
                                            UIView uiView = uidoc.GetOpenUIViews().FirstOrDefault<UIView>(uv=> uv.ViewId.Equals(doc.ActiveView.Id));
                                            LocationPoint iroomlocation = iroom.Location as LocationPoint;

                                            uiView.ZoomAndCenterRectangle(new XYZ(iroomlocation.Point.X - 10, iroomlocation.Point.Y - 10, iroomlocation.Point.Z - 10), new XYZ(iroomlocation.Point.X + 10, iroomlocation.Point.Y + 10, iroomlocation.Point.Z + 10));

                                            //uidoc.ShowElements(iroom);
                                            return Result.Succeeded;

                                            }
                                        catch
                                            {
                                            TaskDialog.Show("r","Worng");
                                            }

                                        }
                                    }
                                }

                            catch
                                {
                                TaskDialog.Show("Warning", "Invaild Room Number");
                                }
                            t2.Commit();
                            }
                        }
                    }
                else
                    {
                    TaskDialog.Show("Warning", "Make sure Floor plan or Section View");
                    }


                tg.Assimilate();
                }
            return Result.Succeeded;
            }
        }
}

