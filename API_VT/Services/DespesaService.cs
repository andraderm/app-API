using API_VT.Data;
using API_VT.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_VT.Services
{
    public class DespesaService
    {
        private readonly DataContext _context;
        private readonly FuncionarioService _funcionarioService;

        public DespesaService(DataContext context, FuncionarioService funcionarioService)
        {
            _context = context;
            _funcionarioService = funcionarioService;
        }

        public async Task<Despesa> CalcularDespesa(int ano, int mes)
        {
            DateTime dataReferencia = new DateTime(ano, mes, 1);
            int diasNoMes = DateTime.DaysInMonth(ano, mes);
            List<Funcionario> funcionarios = await _funcionarioService.FindAllAsync();
            double subtotal = 0.0;

            foreach (Funcionario f in funcionarios)
            {
                List<DateTime> diasDescanso = new List<DateTime>();
                int diasTrabalhados = dataReferencia.AddMonths(1).Subtract(f.DataAdmissao).Days;
                string[] spl = f.Escala.EscalaTrabalho.ToUpper().Split('X');
                int escalaT;
                int escalaF;
                if (int.Parse(spl[0]) == 12)
                {
                    escalaT = 1;
                    escalaF = 1;
                }
                else
                {
                    escalaT = int.Parse(spl[0]);
                    escalaF = int.Parse(spl[1]);
                }

                for (int i = f.DataAdmissao.Day - 1 + escalaT; i <= diasTrabalhados; i += escalaT)
                {
                    for (int j = 1; j <= escalaF; j++)
                    {
                        diasDescanso.Add(f.DataAdmissao.AddDays(i));
                        i += 1;
                    }
                }
                List<DateTime> folgasMes = diasDescanso.FindAll(x => x.Year == ano && x.Month == mes);

                subtotal += f.CustoDiarioVT * (diasNoMes - folgasMes.Count);
            }

            Despesa d = new Despesa();
            d.DataReferencia = dataReferencia;
            d.DespesaMensal = subtotal;
            _context.Despesas.Add(d);
            await _context.SaveChangesAsync();
            return d;
        }
    }
}
