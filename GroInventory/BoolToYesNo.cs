using System;
namespace GroInventory
{
    public static class BoolToYesNo
    {
        //Converts Bool to Yes/No
        public static string ToYesNoString(this bool value)
        {
            return value ? "Yes" : "No";
        }
    }
}