using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExerciceApi.Models
{
    public class RegisterProductRequest
    {
        public string Description { get; set; }
        public List<CategoryDTO> Categories { get; set; }
        public string Price { get; set; }
    }
}