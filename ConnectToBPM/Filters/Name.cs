using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectToBPM.Filters
{
    class Name
    {
        //public string RootSchemaName { get; set; }
        public int FilterType { get; set; }
        public object ComparisonType { get; set; }
        public object LeftExpression { get; set; }
        public object RightExpression { get; set; }
        public bool IsEnabled { get; set; }
    }
}
