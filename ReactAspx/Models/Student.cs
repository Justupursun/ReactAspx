using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ReactAspx.Models
{
    public class Student
    // this class will create the table in the backend, database table, using Entity Framework
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }

        [NotMapped] //No need to save to database
        public string ConfirmPassword { get; set; }
    }
}