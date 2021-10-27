namespace CrudEmpresaFuncionario.Domain.Entities
{
    public class Position
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public Position(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
