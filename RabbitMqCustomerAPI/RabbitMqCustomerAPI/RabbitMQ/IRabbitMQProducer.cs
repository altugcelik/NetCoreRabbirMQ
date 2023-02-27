namespace RabbitMqCustomerAPI.RabbitMQ
{
    public interface IRabitMQProducer
    {
        public void SendCustomerMessage<T>(T message);
    }
}
