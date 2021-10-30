using CrudEmpresaFuncionario.Utils;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CrudEmpresaFuncionario.Shared
{
    public abstract class Notification
    {
        private readonly List<EntityValidation> _notifications = new();

        [JsonIgnore]
        public bool IsValid
        {
            get
            {
                return _notifications.Count == 0;
            }
        }

        [JsonIgnore]
        public CollectionNotifications Notifications
        {
            get
            {
                return new CollectionNotifications(_notifications.ToArray());
            }
        }

        protected void AddNotification(string message)
        {
            _notifications.Add(new EntityValidation(message));
        }

        protected void AddNotifications(ICollection<EntityValidation> entityValidations)
        {
            _notifications.AddRange(entityValidations);
        }

        public virtual void Validate()
        {
        }
    }
}
