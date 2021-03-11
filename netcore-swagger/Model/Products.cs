using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace netcore_swagger.Model
{
    public class Products
    {
        public int Id { get; set; }

        [Required]
        public string Product_code { get; set; }

        [Required]
        public string Product_name { get; set; }

        [Required]
        public string Product_type { get; set; }

        public string Description { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Create_date { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Modify_date { get; set; }
        public bool Enable { get; set; }
    }
}
