using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetBootcamp.Service.Products.DTOs
{
    public record ProductCreateRequestDto(string Name, decimal Price, int Stock)
    {
    }
}
