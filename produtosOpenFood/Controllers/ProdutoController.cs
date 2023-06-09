using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using produtosOpenFood.Interfaces.Services;
using produtosOpenFood.Models;
using System.ComponentModel.DataAnnotations;

namespace produtosOpenFood.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProductsController : ControllerBase
  {
    private readonly IProductService _service;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="service">Adicionado pela injeção de denpendência</param>
    public ProductsController(IProductService service)
    {
      _service = service;
    }

    /// <summary>
    /// Endpoint para recuperar todos os produtos com status diferente de "thrash"
    /// </summary>
    /// <returns></returns>
    [HttpGet("")]
    public async Task<IActionResult> Get()
    {
      try
      {
        var result = await _service.Get();
        return Ok(result);
      }
      catch(Exception ex)
      {
        return StatusCode(500, ex.Message);
      }
    }

    /// <summary>
    /// Recuperar produto pelo ID
    /// </summary>
    /// <param name="id">id do produto</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute, Required] string id)
    {
      try
      {
        var result = await _service.Get(id);
        return Ok(result);
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex.Message);
      }
    }

    /// <summary>
    /// Adicionar um produto 
    /// </summary>
    /// <param name="product"></param>
    /// <returns></returns>
    [HttpPost("")]
    public async Task<IActionResult> Create([FromBody] Product product)
    {
      try
      {
        var result = await _service.Create(product);
        return Ok(result);
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex.Message);
      }
    }

    /// <summary>
    /// Alterar status do produto para "thrash"
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
      try
      {
        var result = await _service.Delete(id);
        if (result)
          return Ok(result);
        else
          return BadRequest();
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex.Message);
      }
    }

  }
}
