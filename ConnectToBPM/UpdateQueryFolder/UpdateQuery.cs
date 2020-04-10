using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectToBPM.UpdateQueryFolder
{
    class UpdateQuery
    {
        public string RootSchemaName { get; set; }
        public int OperationType { get; set; }
        public bool IsForceUpdate { get; set; }
        public object ColumnValues { get; set; }
        public object Filters { get; set; }
    }
}
