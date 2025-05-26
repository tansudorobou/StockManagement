using Domain.Events;
using Microsoft.Extensions.Logging;

namespace Application.InOutHandlers
{
    public class InventoryCountedEventHandler
    {
        private readonly ILogger<InventoryCountedEventHandler> _logger;
        public InventoryCountedEventHandler(ILogger<InventoryCountedEventHandler> logger)
        {
            _logger = logger;
        }
        public void Handle(InventoryCountedEvent evt)
        {
            _logger.LogInformation($"[InventoryCountedEvent] InventoryId: {evt.InventoryId}, CountedQty: {evt.CountedQty}, OccurredAt: {evt.OccurredAt}");
        }
    }
}
