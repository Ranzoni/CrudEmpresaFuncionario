namespace CrudEmpresaFuncionario.Utils
{
    public class EntityValidation
    {
        public string Message { get; set; }

        public EntityValidation(string message)
        {
            Message = message;
        }
    }
}
