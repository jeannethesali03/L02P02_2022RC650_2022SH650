﻿using System.ComponentModel.DataAnnotations;

namespace L02P02_2022RC650_2022SH650.Models
{
    public class clientes
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string email { get; set; }
        public string direccion { get; set; }
        public DateTime created_at { get; set; }
    }
}
