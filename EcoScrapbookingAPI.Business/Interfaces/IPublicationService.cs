using EcoScrapbookingAPI.Business.DTOs.PublicationDTOs;
using EcoScrapbookingAPI.Domain.Models;

namespace EcoScrapbookingAPI.Business.Interfaces;

public interface IPublicationService
{
  Publication CreatePublication(PublicationCreateDTO publicationCreateDTO);
  void UpdatePublication(int publicationId, PublicationUpdateDTO publicationUpdateDTO);
  void DeletePublication(int publicationId);
  List<PublicationGetDTO> GetAllPublications();
  PublicationGetDTO GetPublication(int publicationId);
}