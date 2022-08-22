using System;
namespace GroInventory
{
    public static class BoolToUnitLb
    {
        //Converts Bool to Units or Lb (pound)
        public static string ToUnitsOrLb(this bool value)
        {
            return value ? "lb" : "each";
        }
    }
}

