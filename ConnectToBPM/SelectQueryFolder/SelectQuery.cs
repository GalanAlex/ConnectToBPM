using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectToBPM.SelectQueryFolder
{
    class SelectQuery
    {
        public string RootSchemaName { get; set; }
        public int OperationType { get; set; }
        public object Columns {get; set;}

    }
}
