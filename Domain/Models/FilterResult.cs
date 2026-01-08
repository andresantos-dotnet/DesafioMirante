using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class FilterResult<T>
    {

        public int PageSize { get; set; } = 20;
        public int PageNumber { get; set; } = 1;
        public int TotalPage { get; set; } = 0;
        public int TotalCount { get; set; } = 0;
        public decimal TotalAmount { get; set; } = 0;

        public List<T> ResultList { get; set; }

        public void calcule()
        {
            TotalPage = TotalCount / PageSize;
            if (TotalPage < 1) TotalPage = 1;

            int mod = TotalCount % PageSize;
            if (mod > 0) TotalPage = TotalPage + 1;
        }
    }
}
