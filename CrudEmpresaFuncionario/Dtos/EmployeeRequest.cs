using CrudEmpresaFuncionario.Utils;

namespace CrudEmpresaFuncionario.Dtos
{
    public class EmployeeRequest : Pagination
    {
        public string Name { get; set; }
    }
}
