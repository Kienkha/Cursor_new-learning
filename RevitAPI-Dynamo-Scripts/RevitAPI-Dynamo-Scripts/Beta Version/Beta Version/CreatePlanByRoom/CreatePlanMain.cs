#region Namespaces
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
#endregion

namespace ARCtools
    {
    [Transaction(TransactionMode.Manual)]
    public class CreatePlanMain : IExternalCommand
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


            CreatePlanForm form = new CreatePlanForm(commandData);
            form.ShowDialog();
            List<string> roomlists = form.roomlist;
            string viewtemp = form.vtemplate;
            string radio = form.Radioctrlvalue;
            string seprator = form.sep;
            string prefixtext = form.prefix;
            double offset = form.off;



            //Retrive View Tamplate
            ElementId viewid = null;
            IEnumerable<View> views = new FilteredElementCollector(doc).OfClass(typeof(View)).Cast<View>();
            List<string> viewnames = new List<string>();
            foreach (View view in views)
                {
                if (view.Name.ToString().Equals(viewtemp))
                    {
                    viewid = view.Id;
                    }
                viewnames.Add(view.get_Parameter(BuiltInParameter.VIEW_NAME).AsString());
                }


            // Retrive Rooms
            List<Room> RoomElement = new List<Room>();
            RoomFilter filter = new RoomFilter();
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            IList<Element> rooms = new List<Element>();

            //linkedmodel room
            foreach (Document documents in uiapp.Application.Documents)
                {
                FilteredElementCollector collect = new FilteredElementCollector(documents);
                IList<Element> linkedrooms = collect.WherePasses(filter).ToElements();
                foreach (Room lrms in linkedrooms)
                    {
                    rooms.Add(lrms);
                    }
                }


            foreach (Room room in rooms)
                {
                foreach (string Selectedroom in roomlists)
                    {
                    if (Selectedroom == room.get_Parameter(BuiltInParameter.ROOM_NUMBER).AsString())
                        {
                        RoomElement.Add(room);
                        }
                    }
                }

            //view Family type
            IEnumerable<ViewFamilyType> viewFamilyTypes = new FilteredElementCollector(doc)
                 .WherePasses(new ElementClassFilter(typeof(ViewFamilyType), false))
                 .Cast<ViewFamilyType>();
            ElementId floorPlanId = new ElementId(-1);
            foreach (ViewFamilyType e in viewFamilyTypes)
                {                
                if (e.ViewFamily == ViewFamily.FloorPlan)
                    {
                    floorPlanId = e.Id;
                    break;
                    }
                }

            ElementId ceilingPlanId = new ElementId(-1);
            foreach (ViewFamilyType e in viewFamilyTypes)
                {
                if (e.ViewFamily == ViewFamily.CeilingPlan)
                    {
                    ceilingPlanId = e.Id;
                    break;
                    }
                }
            ElementId PlanId = new ElementId(-1);
            if (radio == "ceilingplan")
                {
                PlanId = ceilingPlanId;
                }
            else if(radio == "floorplan")
                {
                PlanId = floorPlanId;
                }

            //Create Views by Room
            try
                {

                foreach (Room viewroom in RoomElement)
                    
                    {
                    //Parameter level = viewroom.get_Parameter(BuiltInParameter.INSTANCE_REFERENCE_LEVEL_PARAM);
                    //Element ilevel = doc.GetElement(level.AsElementId());
                    //Level levelel = ilevel as Level;

                    //ElementId ilevelid = levelel.Id;
                    ElementId levelid = viewroom.Level.Id;


                    //Check View Name

                    string vName = prefixtext + seprator + viewroom.get_Parameter(BuiltInParameter.ROOM_NUMBER).AsString() +"-"+viewroom.get_Parameter(BuiltInParameter.ROOM_NAME).AsString();



                    using (Transaction tx = new Transaction(doc))
                        {
                        tx.Start("Plan Create");
                            ViewPlan viewPlan = ViewPlan.Create(doc, PlanId, levelid);

                        try
                            {
                            viewPlan.Name = vName;
                            }
                        catch
                            {
                            continue;
                            }


                        try
                            {                            
                                //Crop View for the Room

                                IList<IList<BoundarySegment>> segments = viewroom.GetBoundarySegments(new SpatialElementBoundaryOptions());

                                CurveLoop loopcurve = null;

                                foreach (IList<BoundarySegment> boundary in segments)
                                    {
                                    loopcurve = new CurveLoop();

                                    foreach (BoundarySegment curves in boundary)
                                        {
                                        loopcurve.Append(curves.GetCurve());
                                        }
                                    break;
                                    }


                                CurveLoop curveloop2 = CurveLoop.CreateViaOffset(loopcurve, offset, new XYZ(0, 0, -1));

                                ViewCropRegionShapeManager cropviewregionmanager = viewPlan.GetCropRegionShapeManager();



                                bool valid = cropviewregionmanager.IsCropRegionShapeValid(curveloop2);

                                if (valid)
                                    {
                                    viewPlan.CropBoxActive = true;
                                    viewPlan.CropBoxVisible = true;
                                    }

                                cropviewregionmanager.SetCropShape(curveloop2);
                                if (viewid != null)
                                    {
                                    viewPlan.ViewTemplateId = viewid;
                                    }
                                }
                        catch
                            {
                            continue;
                            }

                        tx.Commit();

                        }
                    
                    }


                return Result.Succeeded;
                

                }
            catch
                {
                TaskDialog.Show("Warining","Check View Names");
                return Result.Failed;
                }
            }

            
        }
}
