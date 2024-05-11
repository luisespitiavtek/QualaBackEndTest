
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QualaBackEndTest.Application.Services;
using QualaBackEndTest.Core.Entities;
using QualaBackEndTest.Core.ModelsViews;

namespace QualaBackEndTest.Adapters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalController : ControllerBase
    {
        private readonly ISucursalService _sucursalService;

        public SucursalController(ISucursalService sucursalService)
        {
            _sucursalService = sucursalService;
        }

        [HttpGet("[action]")]
        public IActionResult GetAllSucursales()
        {
            try
            {
                var listAllSucursales = _sucursalService.GetAllSucursales();

                var response = new Response<List<SucursalViewModel>>(true, "List All Sucusales", listAllSucursales);

                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new Response<List<object>>(false, "Error: " + ex.Message, null);
                return BadRequest(response);
            }

        }

        [HttpPost("[action]")]
        public IActionResult GetSucursalById([FromBody] Request<int> request)
        {
            try
            {
                var lsucursale = _sucursalService.GetSucursalById(request.Data);

                var response = new Response<Sucursale>(true, "List Sucursal", lsucursale);

                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new Response<List<object>>(false, "Error: " + ex.Message, null);
                return BadRequest(response);
            }

        }

        [HttpPost("[action]")]
        public IActionResult CreateSucursal([FromBody] Request<Sucursale> request)
        {
            try
            {
                var codigo = Convert.ToDecimal(_sucursalService.CreateSucursal(request.Data));
                var response = new Response<decimal>(true, string.Format("El código creado es: {0}", codigo), codigo);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new Response<List<object>>(false, "Error: " + ex.Message, null);
                return BadRequest(response);
            }
        }

        [HttpPost("[action]")]
        public IActionResult UpdateSucursal([FromBody] Request<Sucursale> request)
        {
            try
            {
                _sucursalService.UpdateSucursal(request.Data);
                var response = new Response<object>(true, "Sucursal actualizada correctamente", null);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new Response<List<object>>(false, "Error: " + ex.Message, null);
                return BadRequest(response);
            }
        }

        [HttpPost("[action]")]
        public IActionResult DeleteSucursal([FromBody] Request<int> request)
        {
            try
            {
                _sucursalService.DeleteSucursal(request.Data);
                var response = new Response<object>(true, "Sucursal borrada correctamente", null);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new Response<List<object>>(false, "Error: " + ex.Message, null);
                return BadRequest(response);
            }
        }

        [HttpGet("[action]")]
        public IActionResult GetAllMonedas()
        {
            try
            {
                var listAllMonedas = _sucursalService.GetMonedas();

                var response = new Response<List<CatMoneda>>(true, "List All Monedas", listAllMonedas);

                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new Response<List<object>>(false, "Error: " + ex.Message, null);
                return BadRequest(response);
            }

        }
    }
}
