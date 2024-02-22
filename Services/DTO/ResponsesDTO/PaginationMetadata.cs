using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersAPI.Application.DTO.ResponsesDTO
{
    public class PaginationMetadata
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; } = 0;
        public int TotalPages { get; set; }
    }
}
