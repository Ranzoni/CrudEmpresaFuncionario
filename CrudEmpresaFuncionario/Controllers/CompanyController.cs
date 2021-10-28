using CrudEmpresaFuncionario.Domain.Entities;
using CrudEmpresaFuncionario.Infra;
using CrudEmpresaFuncionario.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudEmpresaFuncionario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly CrudContext _context;
        private readonly ICompanyService _companyService;

        public CompanyController(CrudContext context, ICompanyService companyService)
        {
            _context = context;
            _companyService = companyService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetById(int id)
        {
            try
            {
                var company = await _companyService.GetByIdAsync(id);
                if (company == null)
                    return NotFound();

                return company;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<Company>>> Get()
        {
            try
            {
                var companies = await _companyService.GetAsync();
                return companies;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Company company)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _companyService.CreateAsync(company);
                    transaction.Commit();
                    return Ok();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return BadRequest(e.Message);
                }
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Company company)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _companyService.UpdateAsync(id, company);
                    transaction.Commit();
                    return Ok();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return BadRequest(e.Message);
                }
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _companyService.DeleteAsync(id);
                    transaction.Commit();
                    return Ok();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return BadRequest(e.Message);
                }
            }
        }
    }
}
