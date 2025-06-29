using Autodesk.Revit.UI;
using Autodesk.Revit.DB;

public class Command : IExternalCommand
{
    public Result Execute(
        ExternalCommandData commandData,
        ref string message,
        ElementSet elements)
    {
        TaskDialog.Show("Hello", "Xin chào từ Revit API!");
        return Result.Succeeded;
    }
}