using AutoMapper;
using Azure;
using DataRepository.Core.DTOS.CategoryDtos;
using DataRepository.Core.Interfaces;
using DataRepository.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookAdict.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController
    {


        public CategoryController(IUnitOfWork unitOfWork, IMapper mapper):base(unitOfWork,mapper)
        {

        }
        [HttpGet("GetAllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var categoryDto = _mapper.Map<List<CategoryDto>>(await _unitOfWork.Category.GetAllCategories());
            return Ok(categoryDto);
        }
        [HttpGet("GetCategory/{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            if (!await _unitOfWork.Category.IsCategoryExist(id))
                return NotFound();
            var categoryDto = _mapper.Map<CategoryDto>(await _unitOfWork.Category.GetCategoryAsync(id));
            return Ok(categoryDto);
        }
        [HttpPost("AddCategory")]
        public async Task<IActionResult> AddCategory([FromBody]CategoryInDto categoryDto)
        {
            if(!ModelState.IsValid)
               return BadRequest("Erorr" + ModelState);
            var category = _mapper.Map<Category>(categoryDto);
            await  _unitOfWork.Category.AddCategoryAsync(category);
            _unitOfWork.ActionOnComplete();
            return Ok(category);
        }
        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory([FromBody]CategoryInDto categoryIn)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            _unitOfWork.Category.UpdateCategory(_mapper.Map<Category>(categoryIn));
            _unitOfWork.ActionOnComplete();
            return Ok(categoryIn);
        }
        [HttpDelete("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _unitOfWork.Category.DeleteCategoryAsync(id);
            _unitOfWork.ActionOnComplete();
            return Ok(new { Message =  "category Deleted Successfully" });
        }
        //[HttpPatch("DeactivateCategory")]
        //public async Task<IActionResult> DeactivateCategory(int id , bool deactiveate)
        //{
        //    var category = await _unitOfWork.Category.GetCategoryAsync(id);
        //    category.IsActive = !deactiveate
        //}
    }
}
