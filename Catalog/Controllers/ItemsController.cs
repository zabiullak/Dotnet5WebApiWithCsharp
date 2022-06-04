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
        private readonly InMemItemsRepository repositery;

        public ItemsController()
        {
            repositery = new InMemItemsRepository();
        }

        //Get /items
        [HttpGet]
        public IEnumerable<Item> GetItems()
        {
            var items = repositery.GetItems();
            return items;
        }

        //Get /items/{id}
        [HttpGet("{id}")]
        public ActionResult<Item> GetItem(Guid id)
        {
            var item = repositery.GetItem(id);
            if(item is null)
            {
                return NotFound();
            }
            return item;
        }
    }
}
