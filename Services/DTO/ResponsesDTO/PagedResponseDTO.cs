using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersAPI.Application.DTO.ResponsesDTO 
{ 
    public class PagedResponseDTO<T> where T : class
    {
        public IEnumerable<T>? Result { get; set; }

        public PaginationMetadata Pagination { get; set; }


        public PagedResponseDTO  (IEnumerable<T> result, int currentPage, int pageSize, int totalCout)
        {
            Result = result?? Enumerable.Empty<T>();
            Pagination = new PaginationMetadata
            {
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = totalCout,
                TotalPages = (int)Math.Ceiling(totalCout/(double)pageSize)
            };
        }


    }
}
