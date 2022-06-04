﻿using Catalog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Repositories
{
    public class InMemItemsRepository : IItemsRepository
    {
        private readonly List<Item> Items = new()
        {
            new Item { Id = Guid.NewGuid(), Name = "Potion", Price = 9, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Iron Sword", Price = 20, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Bronze Shield", Price = 18, CreatedDate = DateTimeOffset.UtcNow }
        };

        public IEnumerable<Item> GetItems()
        {
            return Items;
        }

        public Item GetItem(Guid id)
        {
            return Items.Where(item => item.Id == id).SingleOrDefault();
        }

        public void CreateItem(Item item)
        {
            Items.Add(item);
        }

        public void UpdateItem(Item item)
        {
            var index = Items.FindIndex(excistingItem => excistingItem.Id == item.Id);
            Items[index] = item;
        }

        public void DeleteItem(Guid id)
        {
            var index = Items.FindIndex(excistingItem => excistingItem.Id == id);
            Items.RemoveAt(index);
        }
    }
}
