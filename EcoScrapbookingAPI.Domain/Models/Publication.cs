using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoScrapbookingAPI.Domain.Models;

public class Publication
{
  [Key]
  public int PublicationID { get; set; }
  public int? ReplyPostID { get; set; }
  [Required]
  public string Category { get; set; }
  [Required]
  public string Title { get; set; }
  [Required]
  public string Description { get; set; }

  [ForeignKey("ReplyPostID")]
  public Publication ReplyTo { get; set; } 
  public List<Publication> Replies { get; set; }

  public Publication() { }

  public Publication(int replyPostID, string category, string title, string description)
  {
    ReplyPostID = replyPostID;
    Category = category;
    Title = title;
    Description = description;
  }
}