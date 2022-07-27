using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactList.Models
{
    public class RegisterUserDto
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        public int RoleId { get; set; } = 1;
    }
}
