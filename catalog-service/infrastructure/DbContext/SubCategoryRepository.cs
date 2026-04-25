using Catalog.domain.Entity;
using Catalog.infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;

namespace Catalog.infrastructure.DbContext;

public class SubCategoryRepository
{
    private readonly AppDbContext _context;
    private readonly ISubCategoryInfrastructureMapper _mapper;


    public SubCategoryRepository(AppDbContext context, ISubCategoryInfrastructureMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public List<DomainSubCategoryEntity> GetAllSubCategory()
    {
        var subCategories = _context.SubCategories
            .AsNoTracking()
            .OrderBy(p => p.NameSubCategory)
            .ToList();
        
        return _mapper.ToDomainSubCategoryEntityList(subCategories);
    }

    public DomainSubCategoryEntity GetSubCategoryById(int id)
    {
        var infraSubCategory = _context.SubCategories.Find(id);

        if (infraSubCategory == null)
        {
            throw new KeyNotFoundException("SubCategory not found");
        }
        
        return _mapper.ToDomainSubCategoryEntity(infraSubCategory);
    }

    public DomainSubCategoryEntity SaveSubCategory(DomainSubCategoryEntity domainSubCategory)
    {
        var infraSubCategory = _mapper.ToInfrastructureSubCategoryEntity(domainSubCategory);

        _context.SubCategories.Add(infraSubCategory);
        
        _context.SaveChanges();
        
        return _mapper.ToDomainSubCategoryEntity(infraSubCategory);
        
    }

    public DomainSubCategoryEntity UpdateSubCategory(int id, DomainSubCategoryEntity domainSubCategory)
    {
        var existingSubCategory = _mapper.ToInfrastructureSubCategoryEntity(domainSubCategory);
        
        if (existingSubCategory == null) throw new KeyNotFoundException("SubCategory not found");
        
        existingSubCategory.SubCategoryId = domainSubCategory.SubCategoryId;
        existingSubCategory.NameSubCategory = domainSubCategory.NameSubCategory;
        existingSubCategory.CategoryId = domainSubCategory.CategoryId;
        
        _context.SubCategories.Update(existingSubCategory);
        
        _context.SaveChanges();
        
        return _mapper.ToDomainSubCategoryEntity(existingSubCategory);
            
    }

    public DomainSubCategoryEntity DeleteSubCategory(int id)
    {
        var existingSubCategory = _context.SubCategories.Find(id);
        
        if (existingSubCategory == null) throw new KeyNotFoundException("SubCategory not found");
        
        _context.SubCategories.Remove(existingSubCategory);
        
        _context.SaveChanges();
        
        return _mapper.ToDomainSubCategoryEntity(existingSubCategory);
    }
}