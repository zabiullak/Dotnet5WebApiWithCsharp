using Catalog.Dtos;
using Catalog.Entities;
using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController:ControllerBase
    {
        private readonly IItemsRepository _repositery;

        public ItemsController(IItemsRepository repositery)
        {
            _repositery = repositery;
        }

        //Get /items
        [HttpGet]
        public IEnumerable<ItemDto> GetItems()
        {
            var items = _repositery.GetItems().Select(item=> item.AaDtos());
            return items;
        }

        //Get /items/{id}
        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id)
        {
            var item = _repositery.GetItem(id);
            if(item is null)
            {
                return NotFound();
            }
            return item.AaDtos();
        }

        //POST /items
        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow

            };

            _repositery.CreateItem(item);

            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item.AaDtos());
        }

        //PUT /items/{id}
        [HttpPut("{id}")]
        public ActionResult<ItemDto> UpdateItem(Guid id, UpdateItemDto itemDto)
        {
            var excistingItem = _repositery.GetItem(id);

            if(excistingItem is null)
            {
                return NotFound();
            }

            Item updatedItem = excistingItem with
            {
                Name = itemDto.Name,
                Price = itemDto.Price
            };

            _repositery.UpdateItem(updatedItem);

            return NoContent();
        }

        //DELETE /items/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteItem(Guid id)
        {
            var excistingItem = _repositery.GetItem(id);
            if (excistingItem is null)
            {
                return NotFound();
            }

            _repositery.DeleteItem(id);
            return NoContent();
        }
    }
}
