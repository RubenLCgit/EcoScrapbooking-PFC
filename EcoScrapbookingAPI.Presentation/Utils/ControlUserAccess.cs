// Presentation/Utils/ControlUserAccess.cs
namespace EcoScrapbookingAPI.Presentation.Utils
{
  public static class ControlUserAccess
  {
    public static bool UserHasAccess(string roleToken, string idToken, int userId)
    {
      if (string.IsNullOrEmpty(roleToken) || string.IsNullOrEmpty(idToken))
      {
        return false;
      }

      return roleToken.Equals("Admin", StringComparison.OrdinalIgnoreCase) ||
             idToken == userId.ToString();
    }
  }
}
