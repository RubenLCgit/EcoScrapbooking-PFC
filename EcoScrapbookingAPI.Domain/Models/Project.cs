using System.ComponentModel.DataAnnotations;
using EcoScrapbookingAPI.Domain.Models.Abstracts;

namespace EcoScrapbookingAPI.Domain.Models;

public class Project : Activity
{
  [Required]
  public string ProjectType { get; set; }

  public Project() { }

  public Project(String title, String description, int maxParticipants, DateTime startDate, DateTime finishDate, decimal greenPointsValue, string homeImageUrl, string projectType, int creatorUserId) : base(title, description, maxParticipants, startDate, finishDate, greenPointsValue, homeImageUrl, creatorUserId)
  {
    ProjectType = projectType;
  }

}