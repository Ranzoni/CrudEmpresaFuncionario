using CrudEmpresaFuncionario.Domain.Entities;
using CrudEmpresaFuncionario.Domain.Repositories;
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

        public async Task<List<Employee>> GetByIdCompany(int idCompany)
        {
            return await _employeeRepository.Get().Where(e => e.Company.Id == idCompany).ToListAsync();
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
