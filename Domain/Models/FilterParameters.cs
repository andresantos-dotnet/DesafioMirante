using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class FilterParameters
    {
        public int PageSize { get; set; } = 20;
        public int PageNumber { get; set; } = 0;
        public string DateStart { get; set; }
        public string DateEnd { get; set; }

        public int Skip()
        {
            return PageNumber == 1 ? 0 : (PageNumber - 1) * PageSize;
        }
    }
}
