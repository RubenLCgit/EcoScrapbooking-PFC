using System.Security.Claims;
using EcoScrapbookingAPI.Business.DTOs.TransactionDTOs;
using EcoScrapbookingAPI.Business.Interfaces;
using EcoScrapbookingAPI.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcoScrapbookingAPI.Presentation.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class TransactionController : ControllerBase
{
  private readonly ITransactionService _transactionService;

  public TransactionController(ITransactionService transactionService)
  {
      _transactionService = transactionService;
  }

  [AllowAnonymous]
  [HttpGet]
  public ActionResult<List<TransactionGetDTO>> GetAll()
  {
      try
      {
          var transactions = _transactionService.GetAllTransactions(User.FindFirst(ClaimTypes.Role).Value);
          return Ok(transactions);
      }
      catch (ArgumentNullException anEx)
      {
          return NotFound(anEx.Message);
      }
      catch (Exception ex)
      {
          return BadRequest(ex.Message);
      }
  }

  [AllowAnonymous]
  [HttpGet("{transactionId}")]
  public ActionResult<TransactionGetDTO> Get(int transactionId)
  {
      try
      {
          return Ok(_transactionService.GetTransaction(transactionId));
      }
      catch (ArgumentNullException anEx)
      {
          return NotFound(anEx.Message);
      }
      catch (Exception ex)
      {
          return BadRequest(ex.Message);
      }
  }

  [AllowAnonymous]
  [HttpPost]
  public ActionResult<Transaction> Create([FromBody] TransactionCreateDTO transactionCreateDTO)
  {
      try
      {
          var transaction = _transactionService.CreateTransaction(transactionCreateDTO);
          return CreatedAtAction(nameof(Get), new { transactionId = transaction.TransactionID }, transaction);
      }
      catch (ArgumentNullException anEx)
      {
          return NotFound(anEx.Message);
      }
      catch (Exception ex)
      {
          return BadRequest(ex.Message);
      }
  }

  [AllowAnonymous]
  [HttpPut("{transactionId}")]
  public ActionResult Update(int transactionId, [FromBody] TransactionUpdateDTO transactionUpdateDTO)
  {
      try
      {
          _transactionService.UpdateTransaction(transactionId, transactionUpdateDTO);
          return NoContent();
      }
      catch (ArgumentNullException anEx)
      {
          return NotFound(anEx.Message);
      }
      catch (Exception ex)
      {
          return BadRequest(ex.Message);
      }
  }

  [AllowAnonymous]
  [HttpDelete("{transactionId}")]
  public ActionResult Delete(int transactionId)
  {
      try
      {
          _transactionService.DeleteTransaction(transactionId);
          return NoContent();
      }
      catch (ArgumentNullException anEx)
      {
          return NotFound(anEx.Message);
      }
      catch (Exception ex)
      {
          return BadRequest(ex.Message);
      }
  }

  [AllowAnonymous]
  [HttpPatch("{transactionId}/accept/{receiverId}")]
  public ActionResult Accept(int transactionId, int receiverId)
  {
      try
      {
          _transactionService.AcceptedTransaction(transactionId, receiverId);
          return NoContent();
      }
      catch (ArgumentNullException anEx)
      {
          return NotFound(anEx.Message);
      }
      catch (Exception ex)
      {
          return BadRequest(ex.Message);
      }
  }

  [AllowAnonymous]
  [HttpPatch("{transactionId}/reject")]
  public ActionResult Reject(int transactionId)
  {
      try
      {
          _transactionService.RejectedTransaction(transactionId);
          return NoContent();
      }
      catch (ArgumentNullException anEx)
      {
          return NotFound(anEx.Message);
      }
      catch (Exception ex)
      {
          return BadRequest(ex.Message);
      }
  }

  [AllowAnonymous]
  [HttpPatch("{transactionId}/complete")]
  public ActionResult Complete(int transactionId)
  {
      try
      {
          _transactionService.CompleteTransaction(transactionId);
          return NoContent();
      }
      catch (ArgumentNullException anEx)
      {
          return NotFound(anEx.Message);
      }
      catch (Exception ex)
      {
          return BadRequest(ex.Message);
      }
  }
}