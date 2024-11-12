using EcoScrapbookingAPI.Business.DTOs.TutorialsDTOs;
using EcoScrapbookingAPI.Domain.Models;

namespace EcoScrapbookingAPI.Business.Interfaces;

public interface ITutorialService
{
  Tutorial CreateTutorial(TutorialCreateDTO tutorialCreateDTO);
  void UpdateTutorial(int tutorialId, TutorialUpdateDTO tutorialUpdateDTO);
  void DeleteTutorial(int tutorialId);
  List<TutorialGetDTO> GetAllTutorials();
  TutorialGetDTO GetTutorial(int tutorialId);
}