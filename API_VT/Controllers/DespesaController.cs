using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_VT.Data;
using API_VT.Models.Entities;
using API_VT.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_VT.Controllers
{
    [ApiController]
    [Route("vt/despesa")]
    public class DespesaController : Controller
    {
        private readonly DespesaService _dservice;

        public DespesaController(DespesaService dservice)
        {
            _dservice = dservice;
        }

        [HttpGet("{ano}/{mes}")]
        public async Task<Despesa> DespesaMensal(int ano, int mes)
        {
            return await _dservice.CalcularDespesa(ano, mes);
        }


    }
}
