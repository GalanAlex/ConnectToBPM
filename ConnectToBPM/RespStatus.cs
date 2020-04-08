using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectToBPM
{
    class RespStatus
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public object Exeption { get; set; }
        public object PasswordChangeUrl { get; set; }
        public object RedirectUrl { get; set; }
    }
}
