using EcoScrapbookingAPI.Business.DTOs.MaterialDTOs;
using EcoScrapbookingAPI.Domain.Models;

namespace EcoScrapbookingAPI.Business.Interfaces;

public interface IMaterialService
{
  Material CreateMaterial(MaterialCreateDTO materialCreateDTO);
  void UpdateMaterial(int materialId, MaterialUpdateDTO materialUpdateDTO);
  void DeleteMaterial(int materialId);
  List<MaterialGetDTO> GetAllMaterials();
  MaterialGetDTO GetMaterial(int materialId);
}