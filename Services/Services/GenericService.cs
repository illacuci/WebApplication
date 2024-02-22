using AutoMapper;
using Azure;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Exceptions;
using OrdersAPI.Application.CustomExeptions;
using OrdersAPI.Application.Interfaces.Services;
using OrdersAPI.Core.Entities.Base;
using OrdersAPI.Insfractucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace OrdersAPI.Application.Services
{
    public class GenericService<T,TDto, TCreateDto, TKey> : IGenericService<T, TDto, TCreateDto, TKey>
        where T : BaseEntity<TKey> where TKey : IEquatable<TKey>
        where TDto : class, new()
        where TCreateDto : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
            
        public GenericService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<(IEnumerable<TDto>, int)> GetAllEntityAsync(int pageIndex, int pageSize)
        {
            var entity = await _unitOfWork.Repository<T, TKey>().GetAllAsync(pageIndex, pageSize);
            return (_mapper.Map<IEnumerable<TDto>>(entity.Entity), entity.totalCount);
        }

        public async Task<TDto> GetEntityByIdAsync(TKey id)
        {
            return _mapper.Map<TDto>(await _unitOfWork.Repository<T, TKey>().GetByIdAsync(id));
        }

        public async Task<TDto> CreateEntityAsync(TCreateDto createdDto)
        {
            try
            {
                T entity = _mapper.Map<T>(createdDto);
                await _unitOfWork.Repository<T, TKey>().AddAsync(entity);
                await _unitOfWork.CommitAsync();

                TDto entityDto = _mapper.Map<TDto>(entity);
                return entityDto;
            } catch (Exception ex)
            {
                throw new ServiceExeption("Service error.", ex);
            }
        }
        public async Task<bool> LogicalDeleteEntityAsync(TKey id)
        {
            if (await _unitOfWork.Repository<T, TKey>().LogicalDeleteAsync(id))
            {
                await _unitOfWork.Repository<T, TKey>().SaveAsync();
                return true;
            }

            return false;
        }
        public async Task<TDto> UpdateEntityAsync(TKey id, TCreateDto updateDto)
        {
            try
            {
                T entity = _mapper.Map<T>(updateDto);
                entity.Id = id;
                await _unitOfWork.Repository<T, TKey>().UpdateAsync(entity);
                await _unitOfWork.CommitAsync();
                return _mapper.Map<TDto>(entity);

            }catch (Exception ex)
            {
                throw new ServiceExeption("Service error.", ex);
            }

        }

        public async Task<TDto> PatchEntityAsync(TKey id, JsonPatchDocument<TDto> jsonPatch)
        {
            T entity = await _unitOfWork.Repository<T, TKey>().GetByIdAsync(id);

            if (entity == null)
            {
                throw new KeyNotFoundException("No se pudo encontrar la entidad con el ID proporcionado.");
            }
            try
            {
                var entityDto = _mapper.Map<TDto>(entity);
                jsonPatch.ApplyTo(entityDto);
                await _unitOfWork.Repository<T, TKey>().UpdateAsync(entity);
                await _unitOfWork.CommitAsync();
                return entityDto;
            }
            catch (JsonPatchException ex)
            {
                throw new ApplicationException("Error al aplicar el parche JSON.", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Ocurrió un error inesperado.", ex);
            }
        }
    }
}
