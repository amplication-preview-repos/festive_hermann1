using Microsoft.Extensions.DependencyInjection;
using WebsiteScannerService.Brokers.Infrastructure;
using WebsiteScannerService.Brokers.Kafka;

namespace WebsiteScannerService.Brokers.Kafka;

public class KafkaConsumerService : KafkaConsumerService<KafkaMessageHandlersController>
{
    public KafkaConsumerService(IServiceScopeFactory serviceScopeFactory, KafkaOptions kafkaOptions)
        : base(serviceScopeFactory, kafkaOptions) { }
}
