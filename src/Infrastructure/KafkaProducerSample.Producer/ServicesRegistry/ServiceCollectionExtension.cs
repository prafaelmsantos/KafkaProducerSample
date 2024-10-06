namespace KafkaProducerSample.Producer.ServicesRegistry
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddProducerServices(this IServiceCollection services)
        {
            #region Services
            services.AddScoped<IMessageService, MessageService>();
            #endregion

            return services;
        }
    }
}
