using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
  public Activity Activity { get; set; }
  public List<Publication> Replies { get; set; }

  public Publication() { }

  public Publication(int replyPostID, string category, string title, string description, int authorId, string imagePostUrl)
  {
    ReplyPostID = replyPostID;
    Category = category;
    Title = title;
    Description = description;
    AuthorId = authorId;
  }
}