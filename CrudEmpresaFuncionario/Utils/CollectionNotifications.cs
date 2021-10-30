using CrudEmpresaFuncionario.Utils;
using System.Collections.Generic;

namespace CrudEmpresaFuncionario.Utils
{
    public class CollectionNotifications
    {
        public ICollection<EntityValidation> Messages { get; }

        public CollectionNotifications(ICollection<EntityValidation> messages)
        {
            Messages = messages;
        }
    }
}
