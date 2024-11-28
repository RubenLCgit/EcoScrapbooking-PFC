namespace EcoScrapbookingAPI.Business.DTOs.ProjectDTOs
{
  public class ProjectResourceDTO
  {
    public int ResourceId { get; set; }
    public string ResourceType { get; set; }

    public ProjectResourceDTO() { }

    public ProjectResourceDTO(int resourceId, string resourceType)
    {
      ResourceId = resourceId;
      ResourceType = resourceType;
    }
  }
}
