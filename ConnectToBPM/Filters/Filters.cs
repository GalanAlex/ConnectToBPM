using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectToBPM.Filters
{
    class Filters
    {
        public object Items { get; set; }
        public object FilterType { get; set; }
        public object LogicalOperation { get; set; }
        public bool IsEnabled { get; set; }
    }
}
