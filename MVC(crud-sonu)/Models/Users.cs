﻿using System.ComponentModel.DataAnnotations;

namespace MVC_crud_sonu_.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
