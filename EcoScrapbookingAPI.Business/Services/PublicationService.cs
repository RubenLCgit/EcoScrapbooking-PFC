using EcoScrapbookingAPI.Business.DTOs.PublicationDTOs;
using EcoScrapbookingAPI.Business.Interfaces;
using EcoScrapbookingAPI.Data.Interfaces;
using EcoScrapbookingAPI.Domain.Models;
using EcoScrapbookingAPI.Domain.Models.Abstracts;

namespace EcoScrapbookingAPI.Business.Services;

public class PublicationService : IPublicationService
{
  private readonly IRepositoryGeneric<Publication> _publicationRepository;
  public PublicationService(IRepositoryGeneric<Publication> publicationRepository)
  {
    _publicationRepository = publicationRepository;
  }

  public Publication CreatePublication(PublicationCreateDTO publicationCreateDTO)
  {
    var publication = new Publication(publicationCreateDTO.AuthorId, publicationCreateDTO.ReplyPostID, publicationCreateDTO.Category, publicationCreateDTO.Title, publicationCreateDTO.Description, publicationCreateDTO.ImagePostUrl, publicationCreateDTO.ActivityId);
    _publicationRepository.AddEntity(publication);
    _publicationRepository.SaveChanges();
    return publication;
  }

  public void UpdatePublication(int publicationId, PublicationUpdateDTO publicationUpdateDTO)
  {
    var publication = _publicationRepository.GetByIdEntity(publicationId);
    if (publication == null) throw new Exception("Publication not found");
    publication.Category = publicationUpdateDTO.Category ?? publication.Category;
    publication.Title = publicationUpdateDTO.Title ?? publication.Title;
    publication.Description = publicationUpdateDTO.Description ?? publication.Description;
    publication.ImagePostUrl = publicationUpdateDTO.ImagePostUrl ?? publication.ImagePostUrl;
    _publicationRepository.UpdateEntity(publication);
    _publicationRepository.SaveChanges();
  }

  public void DeletePublication(int publicationId)
  {
    var publication = _publicationRepository.GetByIdEntity(publicationId);
    if (publication == null) throw new Exception("Publication not found");
    _publicationRepository.DeleteEntity(publication);
    _publicationRepository.SaveChanges();
  }

  public List<PublicationGetDTO> GetAllPublications()
  {
    var publications = _publicationRepository.GetAllEntities();
    return MapPublicationToDTOs(publications);
  }

  private List<PublicationGetDTO> MapPublicationToDTOs(List<Publication> publications)
  {
    return publications.Select(p => new PublicationGetDTO(p)).ToList();
  }

  public PublicationGetDTO GetPublication(int publicationId)
  {
    var publication = _publicationRepository.GetByIdEntity(publicationId);
    if (publication == null) throw new Exception("Publication not found");
    return new PublicationGetDTO(publication);
  }
}