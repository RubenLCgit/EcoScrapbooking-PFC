using System.ComponentModel.DataAnnotations;
using EcoScrapbookingAPI.Domain.Models;

namespace EcoScrapbookingAPI.Business.DTOs.PublicationDTOs;

public class PublicationUpdateDTO
{
  public int? AuthorId { get; set; }
  public int? ReplyPostID { get; set; }
  public string? Category { get; set; }
  public string? Title { get; set; }
  public string? Description { get; set; }
  public string? ImagePostUrl { get; set; }
  public int? ActivityId { get; set; }

  public PublicationUpdateDTO() { }

  public PublicationUpdateDTO(Publication publication)
  {
    AuthorId = publication.AuthorId;
    ReplyPostID = publication.ReplyPostID;
    Category = publication.Category;
    Title = publication.Title;
    Description = publication.Description;
    ImagePostUrl = publication.ImagePostUrl;
    ActivityId = publication.ActivityId;
  }
}