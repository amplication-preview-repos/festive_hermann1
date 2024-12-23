using WebsiteScannerService.Brokers.Infrastructure;

namespace WebsiteScannerService.Brokers.Kafka;

public class KafkaProducerService : InternalProducer
{
    public KafkaProducerService(string bootstrapServers)
        : base(bootstrapServers) { }
}
