using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class ApiResponse
    {
        public string Result { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
    }
}