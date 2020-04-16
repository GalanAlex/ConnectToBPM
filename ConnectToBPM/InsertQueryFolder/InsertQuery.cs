using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectToBPM.InsertQueryFolder
{
    class InsertQuery
    {
        public string RootSchemaName { get; set; }
        public int OperationType { get; set; }
        public object ColumnValues {get; set;}
        public object Filters { get; set; }


    }
}
