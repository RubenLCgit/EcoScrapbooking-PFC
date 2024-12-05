using EcoScrapbookingAPI.Business.DTOs.TutorialsDTOs;
using EcoScrapbookingAPI.Business.Interfaces;
using EcoScrapbookingAPI.Data.Interfaces;
using EcoScrapbookingAPI.Domain.Models;

namespace EcoScrapbookingAPI.Business.Services;

public class TutorialService : ITutorialService
{
  private readonly IRepositoryGeneric<Tutorial> _tutorialRepository;
  private readonly IRepositoryGeneric<Material> _materialRepository;
  private readonly IRepositoryGeneric<Tool> _toolRepository;

  public TutorialService(IRepositoryGeneric<Tutorial> tutorialRepository, IRepositoryGeneric<Material> materialRepository, IRepositoryGeneric<Tool> toolRepository)
  {
    _tutorialRepository = tutorialRepository;
    _materialRepository = materialRepository;
    _toolRepository = toolRepository;
  }
  public Tutorial CreateTutorial(TutorialCreateDTO tutorialCreateDTO)
  {
    var tutorial = new Tutorial(tutorialCreateDTO.Title, tutorialCreateDTO.Description, tutorialCreateDTO.MaxParticipants ?? 0, tutorialCreateDTO.StartDate, tutorialCreateDTO.FinishDate, tutorialCreateDTO.GreenPointsValue, tutorialCreateDTO.HomeImageUrl, tutorialCreateDTO.Duration, tutorialCreateDTO.VideoUrl, tutorialCreateDTO.CreatorUserId);
    _tutorialRepository.AddEntity(tutorial);
    _tutorialRepository.SaveChanges();
    return tutorial;
  }

  public void UpdateTutorial(int tutorialId, TutorialUpdateDTO tutorialUpdateDTO)
  {
    var tutorial = _tutorialRepository.GetByIdEntity(tutorialId);
    if (tutorial == null) throw new Exception("Tutorial not found");
    tutorial.Title = tutorialUpdateDTO.Title ?? tutorial.Title;
    tutorial.Description = tutorialUpdateDTO.Description ?? tutorial.Description;
    tutorial.MaxParticipants = tutorialUpdateDTO.MaxParticipants ?? tutorial.MaxParticipants;
    tutorial.StartDate = tutorialUpdateDTO.StartDate ?? tutorial.StartDate;
    tutorial.FinishDate = tutorialUpdateDTO.FinishDate ?? tutorial.FinishDate;
    tutorial.IsActive = tutorialUpdateDTO.IsActive ?? tutorial.IsActive;
    tutorial.GreenPointsValue = tutorialUpdateDTO.GreenPointsValue ?? tutorial.GreenPointsValue;
    tutorial.HomeImageUrl = tutorialUpdateDTO.HomeImageUrl ?? tutorial.HomeImageUrl;
    tutorial.Duration = tutorialUpdateDTO.Duration ?? tutorial.Duration;
    tutorial.VideoUrl = tutorialUpdateDTO.VideoUrl ?? tutorial.VideoUrl;
    _tutorialRepository.UpdateEntity(tutorial);
    _tutorialRepository.SaveChanges();
  }

  public void DeleteTutorial(int tutorialId)
  {
    var tutorial = _tutorialRepository.GetByIdEntity(tutorialId);
    if (tutorial == null) throw new Exception("Tutorial not found");
    _tutorialRepository.DeleteEntity(tutorial);
    _tutorialRepository.SaveChanges();
  }

  public List<TutorialGetDTO> GetAllTutorials()
  {
    var tutorials = _tutorialRepository.GetAllEntities();
    return MapTutorialToDTOs(tutorials);
  }

  private List<TutorialGetDTO> MapTutorialToDTOs(List<Tutorial> tutorials)
  {
    return tutorials.Select(t => new TutorialGetDTO(t)).ToList();
  }

  public TutorialGetDTO GetTutorial(int tutorialId)
  {
    var tutorial = _tutorialRepository.GetByIdEntity(tutorialId);
    if (tutorial == null) throw new Exception("Tutorial not found");
    return new TutorialGetDTO(tutorial);
  }

  public void AddResourceToTutorial(int tutorialId, int resourceId)
  {
    var tutorial = _tutorialRepository.GetByIdEntity(tutorialId);
    if (tutorial == null) throw new Exception("Tutorial not found");
    var material = _materialRepository.GetByIdEntity(resourceId);
    if (material != null)
    {
      if (tutorial.ActivityResources.Contains(material)) throw new Exception("Resource already added to tutorial");
      tutorial.ActivityResources.Add(material);
      material.Activities.Add(tutorial);
      _materialRepository.UpdateEntity(material);
      _tutorialRepository.UpdateEntity(tutorial);
      _tutorialRepository.SaveChanges();
      return;
    }
    var tool = _toolRepository.GetByIdEntity(resourceId);
    if (tool != null)
    {
      if (tutorial.ActivityResources.Contains(tool)) throw new Exception("Resource already added to tutorial");
      tutorial.ActivityResources.Add(tool);
      tool.Activities.Add(tutorial);
      _toolRepository.UpdateEntity(tool);
      _tutorialRepository.UpdateEntity(tutorial);
      _tutorialRepository.SaveChanges();
      return;
    }
    throw new Exception("Resource not found");
  }

  public void RemoveResourceFromTutorial(int tutorialId, int resourceId)
  {
    var tutorial = _tutorialRepository.GetByIdEntity(tutorialId);
    if (tutorial == null) throw new Exception("Tutorial not found");
    var material = _materialRepository.GetByIdEntity(resourceId);
    if (material != null)
    {
      if (!tutorial.ActivityResources.Contains(material)) throw new Exception("Resource not added to tutorial");
      tutorial.ActivityResources.Remove(material);
      material.Activities.Remove(tutorial);
      _materialRepository.UpdateEntity(material);
      _tutorialRepository.UpdateEntity(tutorial);
      _tutorialRepository.SaveChanges();
      return;
    }
    var tool = _toolRepository.GetByIdEntity(resourceId);
    if (tool != null)
    {
      if (!tutorial.ActivityResources.Contains(tool)) throw new Exception("Resource not added to tutorial");
      tutorial.ActivityResources.Remove(tool);
      tool.Activities.Remove(tutorial);
      _toolRepository.UpdateEntity(tool);
      _tutorialRepository.UpdateEntity(tutorial);
      _tutorialRepository.SaveChanges();
      return;
    }
    throw new Exception("Resource not found");
  }
}