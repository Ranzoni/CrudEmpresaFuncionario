using CrudEmpresaFuncionario.Domain.Entities;
using CrudEmpresaFuncionario.Domain.Repositories;
using CrudEmpresaFuncionario.Dtos;
using CrudEmpresaFuncionario.Shared;
using CrudEmpresaFuncionario.Utils;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudEmpresaFuncionario.Services
{
    public class EmployeeService : Notification, IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task CreateAsync(Employee employee)
        {
            employee.Validate();
            if (!employee.IsValid)
            {
                AddNotifications(employee.Notifications.Messages);
                return;
            }

            await _employeeRepository.CreateAsync(employee);
        }

        public async Task DeleteAsync(int id)
        {
            await _employeeRepository.DeleteAsync(id);
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _employeeRepository.GetByIdAsync(id);
        }

        public async Task<PaginationResponse<List<Employee>>> GetByIdCompany(int idCompany, EmployeeRequest employeeRequest)
        {
            var query = _employeeRepository.Get();
            if (!string.IsNullOrEmpty(employeeRequest.Name))
                query = query.Where(c => c.Name.Contains(employeeRequest.Name));

            var countEmployees = await query.CountAsync();
            var employees = await query
                .Where(e => e.Company.Id == idCompany)
                .Skip((employeeRequest.Page - 1) * employeeRequest.Size)
                .Take(employeeRequest.Size)
                .ToListAsync();

            return new PaginationResponse<List<Employee>>(employees, employeeRequest.Page, employeeRequest.Size, countEmployees);
        }

        public async Task UpdateAsync(Employee employee)
        {
            var actualEmployee = await _employeeRepository.GetByIdAsync(employee.Id);
            if (actualEmployee == null)
            {
                AddNotification("A empresa informada para edição não existe.");
                return;
            }

            employee.Validate();
            if (!employee.IsValid)
            {
                AddNotifications(employee.Notifications.Messages);
                return;
            }

            await _employeeRepository.UpdateAsync(employee);
        }

        public CollectionNotifications Validations()
        {
            return Notifications;
        }
    }
}
