namespace CrudEmpresaFuncionario.Utils
{
    public class Pagination
    {
        public int Page { get; set; }
        public int Size { get; set; }

        public Pagination()
        {
            Page = 1;
            Size = 5;
        }

        public Pagination(int page, int size)
        {
            Page = page;
            Size = size;
        }
    }
}
