using EcoScrapbookingAPI.Business.DTOs.TutorialsDTOs;
using EcoScrapbookingAPI.Business.Interfaces;
using EcoScrapbookingAPI.Data.Interfaces;
using EcoScrapbookingAPI.Domain.Models;

namespace EcoScrapbookingAPI.Business.Services;

public class TutorialService : ITutorialService
{
  private readonly IRepositoryGeneric<Tutorial> _tutorialRepository;

  public TutorialService(IRepositoryGeneric<Tutorial> tutorialRepository)
  {
    _tutorialRepository = tutorialRepository;
  }

  public Tutorial CreateTutorial(TutorialCreateDTO tutorialCreateDTO)
  {
    var tutorial = new Tutorial(tutorialCreateDTO.Title, tutorialCreateDTO.Description, tutorialCreateDTO.MaxParticipants ?? 0, tutorialCreateDTO.StartDate, tutorialCreateDTO.FinishDate, tutorialCreateDTO.GreenPointsValue, tutorialCreateDTO.Duration, tutorialCreateDTO.CreatorUserId);
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
}