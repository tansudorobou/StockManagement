using Domain.Entities;
using Domain.Events;
using Microsoft.Extensions.Logging;

namespace Application.InventoryHandlers
{
    public class StockChangedEventHandler
    {
        private readonly IStockService _stockService;
        private readonly ILogger<StockChangedEventHandler> _logger;
        public StockChangedEventHandler(IStockService stockService, ILogger<StockChangedEventHandler> logger)
        {
            _stockService = stockService;
            _logger = logger;
        }
        public void Handle(ChangeStockCommand command)
        {
            _stockService.ChangeStock(command);
            _logger.LogInformation($"[ChangeStockCommand] InventoryId: {command.Item.Id}, Qty: {command.Qty}, ChangeType: {command.Type}");
        }
        public void Handle(StockChangedEvent evt)
        {
            _logger.LogInformation($"[StockChangedEvent] InventoryId: {evt.InventoryId}, ChangedQty: {evt.ChangedQty}, ChangeType: {evt.ChangeType}, OccurredAt: {evt.OccurredAt}");
        }
    }

    public class MonthEndInventoryFixedEventHandler
    {
        private readonly ILogger<MonthEndInventoryFixedEventHandler> _logger;
        public MonthEndInventoryFixedEventHandler(ILogger<MonthEndInventoryFixedEventHandler> logger)
        {
            _logger = logger;
        }
        public void Handle(MonthEndInventoryFixedEvent evt)
        {
            _logger.LogInformation($"[MonthEndInventoryFixedEvent] InventoryId: {evt.InventoryId}, QtyAtMonthEnd: {evt.QtyAtMonthEnd}, MonthEnd: {evt.MonthEnd}, OccurredAt: {evt.OccurredAt}");
        }
    }
}
