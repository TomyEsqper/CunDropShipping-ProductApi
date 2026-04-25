using Catalog.adapter.restful.v1.controller.Entity;
using Catalog.adapter.restful.v1.controller.Mapper;
using Catalog.application.Service;
using Microsoft.AspNetCore.Mvc;

namespace CunDropShipping.adapter.restful.v1.controller;

[ApiController]
[Route("api/v1/subcategories")]
public class SubCategoryController : ControllerBase
{
    
    private readonly ISubCategoryService _subCategoryService;
    private readonly ISubCategoryAdapterMapper _subCategoryAdapterMapper;
    
    public SubCategoryController(ISubCategoryService subCategoryService, ISubCategoryAdapterMapper subCategoryAdapterMapper)
    {
        _subCategoryService = subCategoryService;
        _subCategoryAdapterMapper = subCategoryAdapterMapper;
    }

    [HttpGet]
    public ActionResult<List<AdapterSubCategoryEntity>> GetAllSubCategory()
    {
        return Ok(_subCategoryAdapterMapper.ToAdapterSubCategoryList(_subCategoryService.GetAllSubCategory()));
    }

    [HttpGet("{id}")]
    public ActionResult<AdapterSubCategoryEntity> GetSubCategoryById(int id)
    {
        var existingSubCtegory = _subCategoryService.GetSubCategoryById(id);
        if (existingSubCtegory == null) return NotFound();
        
        return Ok(_subCategoryAdapterMapper.ToAdapterSubCategory(existingSubCtegory));
    }
    
    [HttpPost]
    public ActionResult<AdapterSubCategoryEntity> SaveSubCategory([FromBody] AdapterSubCategoryEntity subCategory)
    {
        var domainSubCategory = _subCategoryAdapterMapper.ToDomainSubCategory(subCategory);
        var createdSubCategory = _subCategoryService.SaveSubCategory(domainSubCategory);
        var adapterResult = _subCategoryAdapterMapper.ToAdapterSubCategory(createdSubCategory);
        
        return CreatedAtAction(nameof(GetSubCategoryById), new { id = adapterResult.SubCategoryId }, adapterResult);
    }

    [HttpPut("{id}")]
    public ActionResult<AdapterSubCategoryEntity> UpdateSubCategory(int id,
        [FromBody] AdapterSubCategoryEntity subCategory)
    {
        var domainSubCategory = _subCategoryAdapterMapper.ToDomainSubCategory(subCategory);
        var updatedSubCategory = _subCategoryService.UpdateSubCategory(id, domainSubCategory);
        
        if (updatedSubCategory == null) return NotFound();
        
        return Ok(_subCategoryAdapterMapper.ToAdapterSubCategory(updatedSubCategory));
    }
    
    [HttpDelete("{id}")]
    public ActionResult DeleteSubCategory(int id)
    {
        var deletedSubCategory = _subCategoryService.DeleteSubCategory(id);
        
        if (deletedSubCategory == null) return NotFound();
        
        return NoContent();
    }
    
    
}