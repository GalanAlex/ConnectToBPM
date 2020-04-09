using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectToBPM
{
    class InsertQuery
    {
        public string RootSchemaName { get; set; }
        public int OperationType { get; set; }
        public object ColumnValues {get; set;}

    }
}
