using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class InMemoryInventoryRepository : IInventoryRepository
    {
        private readonly InMemoryDataStore _store;
        public InMemoryInventoryRepository(InMemoryDataStore store)
        {
            _store = store;
        }
        public Inventory? GetById(Guid id)
        {
            return _store.Inventories.FirstOrDefault(x => x.Id == id);
        }
        public Inventory? GetByItemAndLot(string itemCode, string lotNo)
        {
            return _store.Inventories.FirstOrDefault(x => x.ItemMaster.ItemCode == itemCode && x.LotNo == lotNo);
        }
        public List<Inventory> GetAll()
        {
            return _store.Inventories.ToList();
        }
        public void Add(Inventory inventory)
        {
            _store.Inventories.Add(inventory);
        }
        public void Update(Inventory inventory)
        {
            var idx = _store.Inventories.FindIndex(x => x.Id == inventory.Id);
            if (idx >= 0)
                _store.Inventories[idx] = inventory;
        }
        public void Delete(Guid id)
        {
            var target = _store.Inventories.FirstOrDefault(x => x.Id == id);
            if (target != null)
                _store.Inventories.Remove(target);
        }
    }

    public class InMemoryInOutRepository : IInOutRepository
    {
        private readonly InMemoryDataStore _store;
        public InMemoryInOutRepository(InMemoryDataStore store)
        {
            _store = store;
        }
        public InOut? GetById(Guid id)
        {
            return _store.InOuts.FirstOrDefault(x => x.Id == id);
        }
        public List<InOut> GetAll()
        {
            return _store.InOuts.ToList();
        }
        public void Add(InOut inOut)
        {
            _store.InOuts.Add(inOut);
        }
        public void Update(InOut inOut)
        {
            var idx = _store.InOuts.FindIndex(x => x.Id == inOut.Id);
            if (idx >= 0)
                _store.InOuts[idx] = inOut;
        }
        public void Delete(Guid id)
        {
            var target = _store.InOuts.FirstOrDefault(x => x.Id == id);
            if (target != null)
                _store.InOuts.Remove(target);
        }
    }
}
