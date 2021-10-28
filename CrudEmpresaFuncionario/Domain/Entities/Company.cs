﻿using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudEmpresaFuncionario.Domain.Entities
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [StringLength(200)]
        [JsonProperty("nome")]
        public string Name { get; set; }
        [ForeignKey(nameof(Address))]
        public int IdAddress { get; set; }
        [JsonProperty("endereco")]
        public Address Address { get; set; }
        [JsonProperty("telefone")]
        public string PhoneNumber { get; set; }

        public Company(int id, string name, int idAddress, string phoneNumber)
        {
            Id = id;
            Name = name;
            IdAddress = idAddress;
            PhoneNumber = phoneNumber;
        }
    }
}
