using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DataModel
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string TimeZone { get; set; } = null!;
    }
}
