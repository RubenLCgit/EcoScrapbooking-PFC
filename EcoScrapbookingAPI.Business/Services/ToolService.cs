using EcoScrapbookingAPI.Business.DTOs.ToolDTOs;
using EcoScrapbookingAPI.Business.Interfaces;
using EcoScrapbookingAPI.Data.Interfaces;
using EcoScrapbookingAPI.Domain.Models;

namespace EcoScrapbookingAPI.Business.Services;

public class ToolService : IToolService
{
  private readonly IRepositoryGeneric<Tool> _toolRepository;

  public ToolService(IRepositoryGeneric<Tool> toolRepository)
  {
    _toolRepository = toolRepository;
  }

  public Tool CreateTool(ToolCreateDTO toolCreateDTO)
  {
    var tool = new Tool(toolCreateDTO.Name, toolCreateDTO.Type, toolCreateDTO.Brand, toolCreateDTO.Quantity, toolCreateDTO.Description, toolCreateDTO.OwnerUserId, toolCreateDTO.ImageResourceUrl, toolCreateDTO.TransactionId??0, toolCreateDTO.Condition, toolCreateDTO.Warranty);
    _toolRepository.AddEntity(tool);
    _toolRepository.SaveChanges();
    return tool;
  }

  public void UpdateTool(int toolId, ToolUpdateDTO toolUpdateDTO)
  {
    var tool = _toolRepository.GetByIdEntity(toolId);
    if (tool == null) throw new Exception("Tool not found");
    tool.Name = toolUpdateDTO.Name ?? tool.Name;
    tool.Type = toolUpdateDTO.Type ?? tool.Type;
    tool.Brand = toolUpdateDTO.Brand ?? tool.Brand;
    tool.Quantity = toolUpdateDTO.Quantity ?? tool.Quantity;
    tool.Description = toolUpdateDTO.Description ?? tool.Description;
    tool.Condition = toolUpdateDTO.Condition ?? tool.Condition;
    tool.Warranty = toolUpdateDTO.Warranty ?? tool.Warranty;
    tool.OwnerUserId = toolUpdateDTO.OwnerUserId ?? tool.OwnerUserId;
    tool.ImageResourceUrl = toolUpdateDTO.ImageResourceUrl ?? tool.ImageResourceUrl;
    tool.TransactionId = toolUpdateDTO.TransactionId ?? tool.TransactionId;
    _toolRepository.UpdateEntity(tool);
    _toolRepository.SaveChanges();
  }

  public void DeleteTool(int toolId)
  {
    var tool = _toolRepository.GetByIdEntity(toolId);
    if (tool == null) throw new Exception("Tool not found");
    _toolRepository.DeleteEntity(tool);
    _toolRepository.SaveChanges();
  }

  public List<ToolGetDTO> GetAllTools()
  {
    var tools = _toolRepository.GetAllEntities();
    return MapToolToDTOs(tools);
  }

  private List<ToolGetDTO> MapToolToDTOs(List<Tool> tools)
  {
    return tools.Select(t => new ToolGetDTO(t)).ToList();
  }

  public ToolGetDTO GetTool(int toolId)
  {
    var tool = _toolRepository.GetByIdEntity(toolId);
    if (tool == null) throw new Exception("Tool not found");
    return new ToolGetDTO(tool);
  }
}