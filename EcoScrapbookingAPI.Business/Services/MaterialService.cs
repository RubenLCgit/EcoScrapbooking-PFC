using EcoScrapbookingAPI.Business.DTOs.MaterialDTOs;
using EcoScrapbookingAPI.Business.Interfaces;
using EcoScrapbookingAPI.Data.Interfaces;
using EcoScrapbookingAPI.Domain.Models;

namespace EcoScrapbookingAPI.Business.Services;

public class MaterialService : IMaterialService
{
  private readonly IRepositoryGeneric<Material> _materialRepository;

  public MaterialService(IRepositoryGeneric<Material> materialRepository)
  {
    _materialRepository = materialRepository;
  }

  public Material CreateMaterial(MaterialCreateDTO materialCreateDTO)
  {
    var material = new Material(materialCreateDTO.Name, materialCreateDTO.Type, materialCreateDTO.Brand, materialCreateDTO.Quantity, materialCreateDTO.Description, materialCreateDTO.OwnerUserId, materialCreateDTO.ImageResourceUrl);
    _materialRepository.AddEntity(material);
    _materialRepository.SaveChanges();
    return material;
  }

  public void UpdateMaterial(int materialId, MaterialUpdateDTO materialUpdateDTO)
  {
    var material = _materialRepository.GetByIdEntity(materialId);
    if (material == null) throw new Exception("Material not found");
    material.Name = materialUpdateDTO.Name ?? material.Name;
    material.Type = materialUpdateDTO.Type ?? material.Type;
    material.Brand = materialUpdateDTO.Brand ?? material.Brand;
    material.Quantity = materialUpdateDTO.Quantity ?? material.Quantity;
    material.Description = materialUpdateDTO.Description ?? material.Description;
    material.OwnerUserId = materialUpdateDTO.OwnerUserId ?? material.OwnerUserId;
    material.ImageResourceUrl = materialUpdateDTO.ImageResourceUrl ?? material.ImageResourceUrl;
    material.TransactionId = materialUpdateDTO.TransactionId ?? material.TransactionId;
    _materialRepository.UpdateEntity(material);
    _materialRepository.SaveChanges();
  }

  public void DeleteMaterial(int materialId)
  {
    var material = _materialRepository.GetByIdEntity(materialId);
    if (material == null) throw new Exception("Material not found");
    _materialRepository.DeleteEntity(material);
    _materialRepository.SaveChanges();
  }

  public List<MaterialGetDTO> GetAllMaterials()
  {
    var materials = _materialRepository.GetAllEntities();
    return MapMaterialToDTOs(materials);
  }

  private List<MaterialGetDTO> MapMaterialToDTOs(List<Material> materials)
  {
    return materials.Select(m => new MaterialGetDTO(m)).ToList();
  }

  public MaterialGetDTO GetMaterial(int materialId)
  {
    var material = _materialRepository.GetByIdEntity(materialId);
    if (material == null) throw new Exception("Material not found");
    return new MaterialGetDTO(material);
  }
}