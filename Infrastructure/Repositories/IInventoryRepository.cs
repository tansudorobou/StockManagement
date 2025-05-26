namespace Infrastructure.Repositories {
    using Domain.Entities;
    public interface IInventoryRepository {
        Inventory? GetById(Guid id);
        Inventory? GetByItemAndLot(string itemCode, string lotNo);
        List<Inventory> GetAll();
        void Add(Inventory inventory);
        void Update(Inventory inventory);
        void Delete(Guid id);
    }

    public interface IInOutRepository {
        InOut? GetById(Guid id);
        List<InOut> GetAll();
        void Add(InOut inOut);
        void Update(InOut inOut);
        void Delete(Guid id);
    }
}
