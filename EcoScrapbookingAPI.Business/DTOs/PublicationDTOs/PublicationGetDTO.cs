using EcoScrapbookingAPI.Domain.Models;

namespace EcoScrapbookingAPI.Business.DTOs.PublicationDTOs;

public class PublicationGetDTO
{
  public int PublicationId { get; set; }
  public int AuthorId { get; set; }
  public int? ReplyPostID { get; set; }
  public string Category { get; set; }
  public string Title { get; set; }
  public string Description { get; set; }
  public string? ImagePostUrl { get; set; }
  public int? ActivityId { get; set; }
  public List<int> RepliesIds { get; set; }

  public PublicationGetDTO() { }

  public PublicationGetDTO(Publication publication)
  {
    PublicationId = publication.PublicationID;
    AuthorId = publication.AuthorId;
    ReplyPostID = publication.ReplyPostID;
    Category = publication.Category;
    Title = publication.Title;
    Description = publication.Description;
    ImagePostUrl = publication.ImagePostUrl;
    ActivityId = publication.ActivityId;

    if (publication.Replies != null)
    {
      RepliesIds = publication.Replies.Select(r => r.PublicationID).ToList();
    }
  }
}