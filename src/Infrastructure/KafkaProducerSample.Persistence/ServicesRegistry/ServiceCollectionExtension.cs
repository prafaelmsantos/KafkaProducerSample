namespace KafkaProducerSample.Persistence.ServicesRegistry
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            #region Services
            services.AddScoped<IMessageService, MessageService>();
            #endregion

            return services;
        }
    }
}
