using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Dto
{
    public class StudentDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Surname { get; set; }

        public IFormFile FormFile { get; set; }
    }
}
