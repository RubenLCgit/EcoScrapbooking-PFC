using EcoScrapbookingAPI.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace EcoScrapbookingAPI.Business.DTOs.PublicationDTOs;

public class PublicationCreateDTO
{
  [Required]
  public int AuthorId { get; set; }
  public int? ReplyPostID { get; set; }
  [MinLength(3, ErrorMessage = "Category must be at least 3 characters long.")]
  public string? Category { get; set; }
  [MinLength(3, ErrorMessage = "Title must be at least 3 characters long.")]
  public string? Title { get; set; }
  [Required]
  [MinLength(3, ErrorMessage = "Description must be at least 3 characters long.")]
  public string Description { get; set; }
  [Url(ErrorMessage = "Invalid URL.")]
  public string? ImagePostUrl { get; set; }
  public int? ActivityId { get; set; }

  public PublicationCreateDTO() { }

  public PublicationCreateDTO(Publication publication)
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