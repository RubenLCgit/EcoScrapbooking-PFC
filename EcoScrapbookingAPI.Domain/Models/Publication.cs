using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using EcoScrapbookingAPI.Domain.Models.Abstracts;

namespace EcoScrapbookingAPI.Domain.Models;

public class Publication
{
  [Key]
  public int PublicationID { get; set; }
  public int AuthorId { get; set; }
  public int? ReplyPostID { get; set; }
  [Required]
  public string Category { get; set; }
  [Required]
  public string Title { get; set; }
  [Required]
  public string Description { get; set; }
  public string? ImagePostUrl { get; set; }

  [ForeignKey("ReplyPostID")]
  public Publication ReplyTo { get; set; } 
  [ForeignKey("AuthorId")]
  public User Author { get; set; }

  public int? ActivityId { get; set; }
  [ForeignKey("ActivityId")]
  [JsonIgnore]
  public Activity Activity { get; set; }
  [JsonIgnore]
  public List<Publication> Replies { get; set; } = new List<Publication>();

  public Publication() { }

  public Publication(int authorId, int? replyPostID, string category, string title, string description, string? imagePostUrl, int? activityId)
  {
    AuthorId = authorId;
    ReplyPostID = replyPostID;
    Category = category;
    Title = title;
    Description = description;
    ImagePostUrl = imagePostUrl;
    ActivityId = activityId;
    Replies = new List<Publication>();
  }
}