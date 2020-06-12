using System;
using System.Threading.Tasks;
using API_VT.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_VT.Controllers
{
    [ApiController]
    [Route("vt/setor")]
    public class SetorController : Controller
    {
        private readonly SetorService _service;

        public SetorController(SetorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var setores = await _service.FindAllAsync();
                return Ok(setores);
            }
            catch (ApplicationException e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
