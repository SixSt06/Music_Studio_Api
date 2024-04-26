using Microsoft.AspNetCore.Mvc;
using Music.Studio.Api.Dto;
using Music.Studio.Api.Services.Interfaces;
using Music.Studio.Core.Entities;
using Music.Studio.Core.http;

namespace Music.Studio.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class InvoicesController : ControllerBase
{
    private readonly IInvoiceService _invoiceService;

    public InvoicesController(IInvoiceService invoiceService)
    {
        _invoiceService = invoiceService;
    }
    
    [HttpGet]
    public async Task<ActionResult<Response<List<Invoice>>>> GetAll()
    {
        var response = new Response<List<InvoiceDto>>
        {
            Data = await _invoiceService.GetAllAsync()
        };
        
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<ActionResult<Response<InvoiceDto>>> Post([FromBody] InvoiceDto invoiceDto)
    {
        var response = new Response<InvoiceDto>
        {
            Data = await _invoiceService.SaveAsync(invoiceDto)
        };
        return Created($"/api/[controller]/{invoiceDto.idInvoice}", response);
    }
    
    [HttpGet]
    [Route("{idInvoice:int}")]
    public async Task<ActionResult<Response<InvoiceDto>>> GetById(int idInvoice)
    {
        var response = new Response<InvoiceDto>();
        
        if (!await _invoiceService.InvoicetExist(idInvoice))
        {
            response.Errors.Add("Invoice Not Found");
            return NotFound(response);
        }

        response.Data = await _invoiceService.GetByIdAsync(idInvoice);
        return Ok(response);
    }
    
    [HttpPut]
    public async Task<ActionResult<Response<InvoiceDto>>> Update([FromBody] InvoiceDto invoiceDto)
    {
        var response = new Response<InvoiceDto>();
        if (!await _invoiceService.InvoicetExist(invoiceDto.idInvoice))
        {
            response.Errors.Add("Invoice not found");
            return NotFound(response);
        }

        response.Data = await _invoiceService.UpdateAsync(invoiceDto);
        return Ok(response);
    }
    
    [HttpDelete]
    [Route("{idInvoice:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int idInvoice)
    {
        var response = new Response<bool>();

        if (!await _invoiceService.InvoicetExist(idInvoice))
        {
            response.Errors.Add("Invoice not found");
            return NotFound(response);
        }

        var isDeleted = await _invoiceService.DeleteAsync(idInvoice);

        if (isDeleted)
        {
            return Ok("Invoice Removed");
        }
        else
        {
            response.Errors.Add("Failed to delete Invoice");
            return BadRequest(response);
        }
    }
}