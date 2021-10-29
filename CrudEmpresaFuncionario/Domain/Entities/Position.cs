﻿using System.ComponentModel.DataAnnotations;

namespace CrudEmpresaFuncionario.Domain.Entities
{
    public class Position
    {
        [Key]
        public int Id { get; private set; }
        public string Name { get; private set; }

        public Position(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
