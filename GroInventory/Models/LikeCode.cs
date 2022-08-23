using System;
using System.Collections.Generic;

namespace GroInventory.Models
{
    public class LikeCode
    {
        public int LikeCodeID { get; set; }
        public string LikeCodeName { get; set; }
        public static IEnumerable<LikeCode> LikeCodeList { get; set; }
    }
}

