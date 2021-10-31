﻿using CrudEmpresaFuncionario.Domain.Entities;
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
    public class EmployeeController : ControllerBase
    {
        private readonly CrudContext _context;
        private readonly IEmployeeService _employeeService;

        public EmployeeController(CrudContext context, IEmployeeService employeeService)
        {
            _context = context;
            _employeeService = employeeService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetById(int id)
        {
            try
            {
                var employee = await _employeeService.GetByIdAsync(id);
                if (employee == null)
                    return NotFound();

                return employee;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("idcompany/{idcompany}")]
        public async Task<ActionResult<PaginationResponse<List<Employee>>>> GetByIdCompany(int idcompany, [FromQuery] Pagination pagination)
        {
            try
            {
                var response = await _employeeService.GetByIdCompany(idcompany, pagination);
                return response;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Employee employee)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _employeeService.CreateAsync(employee);
                    if (_employeeService.Validations().Messages.Count > 0)
                    {
                        transaction.Rollback();
                        return Ok(_employeeService.Validations());
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
        public async Task<ActionResult> Update([FromBody] Employee employee)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _employeeService.UpdateAsync(employee);
                    if (_employeeService.Validations().Messages.Count > 0)
                    {
                        transaction.Rollback();
                        return Ok(_employeeService.Validations());
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
                    await _employeeService.DeleteAsync(id);
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
