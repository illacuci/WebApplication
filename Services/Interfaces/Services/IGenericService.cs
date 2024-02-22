using APIRestGrpuL.Models.DTO.ProductsDTO;
using Azure;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersAPI.Application.Interfaces.Services
{
    public interface IGenericService<T, TDto, TCreateDto, TKey> 
        where T : class
        where TDto : class
        where TCreateDto : class
    {
        Task<(IEnumerable<TDto> Entity, int TotalCount)> GetAllEntityAsync( int pageIndex, int pageSize);
        Task<TDto> GetEntityByIdAsync(TKey id);
        Task<TDto> CreateEntityAsync(TCreateDto entity);
        Task<bool> LogicalDeleteEntityAsync(TKey id);
        //Task<bool> DeleteEntityAsync(TKey id);
        Task<TDto> UpdateEntityAsync(TKey id, TCreateDto entity);
        Task<TDto> PatchEntityAsync(TKey id, JsonPatchDocument<TDto> jsonPatch);
    }
}
    