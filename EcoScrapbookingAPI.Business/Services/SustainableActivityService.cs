using EcoScrapbookingAPI.Business.DTOs.SustainableActivityDTOs;
using EcoScrapbookingAPI.Business.Interfaces;
using EcoScrapbookingAPI.Data.Interfaces;
using EcoScrapbookingAPI.Domain.Models;
using EcoScrapbookingAPI.Domain.Models.Abstracts;

namespace EcoScrapbookingAPI.Business.Services;

public class SustainableActivityService : ISustainableActivityService
{
  private readonly IRepositoryGeneric<SustainableActivity> _sustainableActivityRepository;
  private readonly IRepositoryGeneric<Material> _materialRepository;
  private readonly IRepositoryGeneric<Tool> _toolRepository;

  public SustainableActivityService(IRepositoryGeneric<SustainableActivity> sustainableActivityRepository, IRepositoryGeneric<Material> materialRepository, IRepositoryGeneric<Tool> toolRepository)
  {
    _sustainableActivityRepository = sustainableActivityRepository;
    _materialRepository = materialRepository;
    _toolRepository = toolRepository;
  }

  public SustainableActivity CreateSustainableActivity(SustainableActivityCreateDTO sustainableActivityCreateDTO)
  {
    var sustainableActivity = new SustainableActivity(sustainableActivityCreateDTO.Title, sustainableActivityCreateDTO.Description, sustainableActivityCreateDTO.MaxParticipants ?? 0, sustainableActivityCreateDTO.StartDate, sustainableActivityCreateDTO.FinishDate, sustainableActivityCreateDTO.GreenPointsValue, sustainableActivityCreateDTO.HomeImageUrl, sustainableActivityCreateDTO.NameCollaborator, sustainableActivityCreateDTO.CreatorUserId, sustainableActivityCreateDTO.AddressId);
    _sustainableActivityRepository.AddEntity(sustainableActivity);
    _sustainableActivityRepository.SaveChanges();
    return sustainableActivity;
  }

  public void UpdateSustainableActivity(int sustainableActivityId, SustainableActivityUpdateDTO sustainableActivityUpdateDTO)
  {
    var sustainableActivity = _sustainableActivityRepository.GetByIdEntity(sustainableActivityId);
    if (sustainableActivity == null) throw new Exception("Sustainable activity not found");
    sustainableActivity.Title = sustainableActivityUpdateDTO.Title ?? sustainableActivity.Title;
    sustainableActivity.Description = sustainableActivityUpdateDTO.Description ?? sustainableActivity.Description;
    sustainableActivity.MaxParticipants = sustainableActivityUpdateDTO.MaxParticipants ?? sustainableActivity.MaxParticipants;
    sustainableActivity.StartDate = sustainableActivityUpdateDTO.StartDate ?? sustainableActivity.StartDate;
    sustainableActivity.FinishDate = sustainableActivityUpdateDTO.FinishDate ?? sustainableActivity.FinishDate;
    sustainableActivity.IsActive = sustainableActivityUpdateDTO.IsActive ?? sustainableActivity.IsActive;
    sustainableActivity.GreenPointsValue = sustainableActivityUpdateDTO.GreenPointsValue ?? sustainableActivity.GreenPointsValue;
    sustainableActivity.HomeImageUrl = sustainableActivityUpdateDTO.HomeImageUrl ?? sustainableActivity.HomeImageUrl;
    sustainableActivity.NameCollaborator = sustainableActivityUpdateDTO.NameCollaborator ?? sustainableActivity.NameCollaborator;
    sustainableActivity.AddressId = sustainableActivityUpdateDTO.AddressId ?? sustainableActivity.AddressId;
    _sustainableActivityRepository.UpdateEntity(sustainableActivity);
    _sustainableActivityRepository.SaveChanges();
  }

  public void DeleteSustainableActivity(int sustainableActivityId)
  {
    var sustainableActivity = _sustainableActivityRepository.GetByIdEntity(sustainableActivityId);
    if (sustainableActivity == null) throw new Exception("Sustainable activity not found");
    _sustainableActivityRepository.DeleteEntity(sustainableActivity);
    _sustainableActivityRepository.SaveChanges();
  }

  public List<SustainableActivityGetDTO> GetAllSustainableActivities()
  {
    var sustainableActivities = _sustainableActivityRepository.GetAllEntities();
    return MapSustainableActivityToDTOs(sustainableActivities);
  }

  private List<SustainableActivityGetDTO> MapSustainableActivityToDTOs(List<SustainableActivity> sustainableActivities)
  {
    return sustainableActivities.Select(s => new SustainableActivityGetDTO(s)).ToList();
  }

  public SustainableActivityGetDTO GetSustainableActivity(int sustainableActivityId)
  {
    var sustainableActivity = _sustainableActivityRepository.GetByIdEntity(sustainableActivityId);
    if (sustainableActivity == null) throw new Exception("Sustainable activity not found");
    return new SustainableActivityGetDTO(sustainableActivity);
  }

  public void AddResourceToSustainableActivity(int sustainableActivityId, int resourceId)
  {
    var sustainableActivity = _sustainableActivityRepository.GetByIdEntity(sustainableActivityId);
    if (sustainableActivity == null) throw new Exception("SustainableActivity not found");
    var material = _materialRepository.GetByIdEntity(resourceId);
    if (material != null)
    {
      if (sustainableActivity.ActivityResources.Contains(material)) throw new Exception("Resource already added to project");
      sustainableActivity.ActivityResources.Add(material);
      material.Activities.Add(sustainableActivity);
      _materialRepository.UpdateEntity(material);
      _sustainableActivityRepository.UpdateEntity(sustainableActivity);
      _sustainableActivityRepository.SaveChanges();
      return;
    }
    var tool = _toolRepository.GetByIdEntity(resourceId);
    if (tool != null)
    {
      if (sustainableActivity.ActivityResources.Contains(tool)) throw new Exception("Resource already added to project");
      sustainableActivity.ActivityResources.Add(tool);
      tool.Activities.Add(sustainableActivity);
      _toolRepository.UpdateEntity(tool);
      _sustainableActivityRepository.UpdateEntity(sustainableActivity);
      _sustainableActivityRepository.SaveChanges();
      return;
    }
    throw new Exception("Resource not found");
  }

  public void RemoveResourceFromSustainableActivity(int sustainableActivityId, int resourceId)
  {
    var sustainableActivity = _sustainableActivityRepository.GetByIdEntity(sustainableActivityId);
    if (sustainableActivity == null) throw new Exception("SustainableActivity not found");
    var material = _materialRepository.GetByIdEntity(resourceId);
    if (material != null)
    {
      if (!sustainableActivity.ActivityResources.Contains(material)) throw new Exception("Resource not added to project");
      sustainableActivity.ActivityResources.Remove(material);
      material.Activities.Remove(sustainableActivity);
      _materialRepository.UpdateEntity(material);
      _sustainableActivityRepository.UpdateEntity(sustainableActivity);
      _sustainableActivityRepository.SaveChanges();
      return;
    }
    var tool = _toolRepository.GetByIdEntity(resourceId);
    if (tool != null)
    {
      if (!sustainableActivity.ActivityResources.Contains(tool)) throw new Exception("Resource not added to project");
      sustainableActivity.ActivityResources.Remove(tool);
      tool.Activities.Remove(sustainableActivity);
      _toolRepository.UpdateEntity(tool);
      _sustainableActivityRepository.UpdateEntity(sustainableActivity);
      _sustainableActivityRepository.SaveChanges();
      return;
    }
    throw new Exception("Resource not found");
  }
}