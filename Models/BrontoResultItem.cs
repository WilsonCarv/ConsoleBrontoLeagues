using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBrontoLeagues.Models
{
    public class BrontoResultItem
    {
        public string Id { get; set; }

        public bool IsNew { get; set; }

        public bool IsError { get; set; }

        public int ErrorCode { get; set; }

        public string ErrorString { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} ,IsNew: {IsNew} ,IsError: {IsError} ,ErrorCode: {ErrorCode},ErrorString: {ErrorString} ";
        }
    }
}
