using CrudEmpresaFuncionario.Domain.Entities;
using CrudEmpresaFuncionario.Dtos;
using CrudEmpresaFuncionario.Infra;
using CrudEmpresaFuncionario.Services;
using CrudEmpresaFuncionario.Utils;
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

        [HttpGet("pagination")]
        public async Task<ActionResult<PaginationResponse<List<Company>>>> GetWithPagination([FromQuery] CompanyRequest companyRequest)
        {
            try
            {
                var response = await _companyService.GetAsync(companyRequest);
                return response;
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
                var response = await _companyService.GetAsync();
                return response;
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
                    if (_companyService.Validations().Messages.Count > 0)
                    {
                        transaction.Rollback();
                        return Ok(_companyService.Validations());
                    }

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

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Company company)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _companyService.UpdateAsync(company);
                    if (_companyService.Validations().Messages.Count > 0)
                    {
                        transaction.Rollback();
                        return Ok(_companyService.Validations());
                    }

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

        [HttpDelete("{id}")]
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
