using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models.Entities.Products;
using OrdersAPI.Application.Interfaces.Services;
using OrdersAPI.Application.Services;
using OrdersAPI.Insfractucture;
using OrdersAPI.Application.DTO.ProductsDTO;
using APIRestGrpuL.Models.DTO.ProductsDTO;
using Microsoft.AspNetCore.JsonPatch;
using OrdersAPI.Application.CustomExeptions;
using OrdersAPI.Application.DTO.ResponsesDTO;
using System.Linq.Expressions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrdersAPI.Controllers.ProductsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly IGenericService<Categories, CategoriesDTO, CategoriesCreateDTO, int> _service;
        public CategoriesController(IGenericService<Categories, CategoriesDTO, CategoriesCreateDTO, int> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoriesAsync([FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 10)
        {
            pageSize = Math.Max(1,Math.Min(pageSize, 100));
            pageIndex = Math.Max(pageIndex, 1);

            try
            {
                var result = await _service.GetAllEntityAsync(pageIndex, pageSize);
                var response = new PagedResponseDTO<CategoriesDTO>(result.Entity, pageIndex,pageSize, result.TotalCount);

                return Ok(response);
            }
            catch (ServiceExeption ex)
            {
                return StatusCode(500, new { Message = "An error occurred while processing your request." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error not captured occurred while processing your request." });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryByIdAsync(int id)
        {
            try
            {
                var result = await _service.GetEntityByIdAsync(id);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound(new {Message = $"Category with id {id} not found."});
                }
            }
            catch (ServiceExeption ex)
            {
                return StatusCode(500, new { Message = $"An error occurred while processing your get Category request with id {id}." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"An error not captured occurred while processing your get Category request with id {id}." });
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostCategoryAsync([FromBody] CategoriesCreateDTO categoryDto)
        {
            try
            {
                var result = await _service.CreateEntityAsync(categoryDto);
                var locationUri = Url.Action("GetCategoryById", new { id = result.Id });
                return Created(locationUri, result);
            }
            catch (ServiceExeption ex)
            {
                return StatusCode(500, new { Message = "An error occurred while processing your create Category request." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error not captured occurred while processing your create Category request." });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryAsync(int id)
        {
            try
            {
                var wasDeleted = await _service.LogicalDeleteEntityAsync(id);

                if (!wasDeleted)
                {
                    return NotFound(new { Message = $"Category with ID {id} not found." });
                }
                return NoContent();
            }
            catch (ServiceExeption ex)
            {
                return StatusCode(500, new { Message = "An error occurred while processing your deleting Category request." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error not captured occurred while processing your deleting Category request." });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoryAsync(int id, [FromBody] CategoriesCreateDTO categoryDto)
        {
            try
            {
                var updatedCategoryDto = await _service.UpdateEntityAsync(id, categoryDto);
                return Ok(updatedCategoryDto);
            }catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ServiceExeption ex)
            {
                return StatusCode(500, new { Message = "An error occurred while processing your put Category request." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error not captured occurred while processing your put Category request." });
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchCategoryAsync(int id, JsonPatchDocument<CategoriesDTO> categoryDto)
        {
            try
            {
                var updatedCategoryDto = await _service.PatchEntityAsync(id, categoryDto);
                return Ok(updatedCategoryDto);
            }catch
            {
                return StatusCode(500, new {Message = "An error not captured occurred while processing your put Category request."});
            }
        }
    }
}
