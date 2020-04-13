using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectToBPM.DeleteQueryFolder
{
    class DeleteQuery
    {
        public object RootSchemaName { get; set; }
        public object OperationType { get; set; }
        public object ColumnValues { get; set; }
        public object Filters { get; set; }
    }
}
