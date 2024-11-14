using EcoScrapbookingAPI.Business.DTOs.SustainableActivityDTOs;
using EcoScrapbookingAPI.Business.Interfaces;
using EcoScrapbookingAPI.Data.Interfaces;
using EcoScrapbookingAPI.Domain.Models;

namespace EcoScrapbookingAPI.Business.Services;

public class SustainableActivityService : ISustainableActivityService
{
  private readonly IRepositoryGeneric<SustainableActivity> _sustainableActivityRepository;

  public SustainableActivityService(IRepositoryGeneric<SustainableActivity> sustainableActivityRepository)
  {
    _sustainableActivityRepository = sustainableActivityRepository;
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
}