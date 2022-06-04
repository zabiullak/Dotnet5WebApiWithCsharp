using Catalog.Dtos;
using Catalog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog
{
    public static class Extensions
    {
        public static ItemDto AaDtos(this Item item)
        {
            return new ItemDto
            {
                Id = item.Id,
                Name = item.Name,
                CreatedDate = item.CreatedDate,
                Price = item.Price
            };
        }
    }
}
