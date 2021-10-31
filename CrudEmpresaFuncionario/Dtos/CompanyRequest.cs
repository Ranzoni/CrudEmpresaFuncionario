using CrudEmpresaFuncionario.Utils;

namespace CrudEmpresaFuncionario.Dtos
{
    public class CompanyRequest : Pagination
    {
        public string Name { get; set; }
    }
}
