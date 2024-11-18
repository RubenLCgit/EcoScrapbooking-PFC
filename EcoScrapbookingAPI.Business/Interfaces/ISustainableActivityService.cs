using EcoScrapbookingAPI.Business.DTOs.SustainableActivityDTOs;
using EcoScrapbookingAPI.Domain.Models;

namespace EcoScrapbookingAPI.Business.Interfaces;

public interface ISustainableActivityService
{
  SustainableActivity CreateSustainableActivity(SustainableActivityCreateDTO sustainableActivityCreateDTO);
  void UpdateSustainableActivity(int sustainableActivityId, SustainableActivityUpdateDTO sustainableActivityUpdateDTO);
  void DeleteSustainableActivity(int sustainableActivityId);
  List<SustainableActivityGetDTO> GetAllSustainableActivities();
  SustainableActivityGetDTO GetSustainableActivity(int sustainableActivityId);
  void AddResourceToSustainableActivity(int sustainableActivityId, int resourceId);
  void RemoveResourceFromSustainableActivity(int sustainableActivityId, int resourceId);
}