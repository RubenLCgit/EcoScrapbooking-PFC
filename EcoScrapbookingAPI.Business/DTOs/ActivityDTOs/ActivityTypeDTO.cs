namespace EcoScrapbookingAPI.Business.DTOs.ActivityDTOs;

public class ActivityTypeDTO
{
  public int ActivityId { get; set; }
  public string ActivityType { get; set; }

  public ActivityTypeDTO() { }

  public ActivityTypeDTO(int activityId, string activityType)
  {
    ActivityId = activityId;
    ActivityType = activityType;
  }
}

