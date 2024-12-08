using EcoScrapbookingAPI.Business.DTOs.ToolDTOs;
using EcoScrapbookingAPI.Domain.Models;

namespace EcoScrapbookingAPI.Business.Interfaces;

public interface IToolService
{
  Tool CreateTool(ToolCreateDTO toolCreateDTO);
  void UpdateTool(int toolId, ToolUpdateDTO toolUpdateDTO);
  void DeleteTool(int toolId);
  List<ToolGetDTO> GetAllTools();
  ToolGetDTO GetTool(int toolId);
}