namespace CrudEmpresaFuncionario.Utils
{
    public class PaginationResponse<T>
    {
        public T Data { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
        public int Total { get; set; }

        public PaginationResponse(T data, int page, int size, int total)
        {
            Data = data;
            Page = page;
            Size = size;
            Total = total;
        }
    }
}
