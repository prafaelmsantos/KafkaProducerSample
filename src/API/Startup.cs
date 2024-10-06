namespace KafkaProducerSample.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Services
            services.AddKafkaServices();
            services.AddProducerServices();

            //Indica que estou a trabalhar com a arquitetura MVC com Views Controllers. Permite chamar o meu controller
            //NewsoftJson para evitar um loop infinito no retorno
            //AddJsonOptions para os Enums, onde para cada item do meu Enum, retorna um Id
            services.AddControllers()
                    .AddJsonOptions(x =>
                        x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()))
                    .AddNewtonsoftJson(x =>
                        x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "KafkaProducerSample.API",
                    Description = "An ASP.NET Core Web API for Kafka Producer Sample",
                    Contact = new OpenApiContact()
                    {
                        Name = "KafkaProducerSample",
                        Email = "KafkaProducerSample@gmail.com"
                    },
                    Version = "1.0"
                });
            });

            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
                options.ApiVersionReader = ApiVersionReader.Combine(
                    new UrlSegmentApiVersionReader(),
                    new QueryStringApiVersionReader("api-version"),
                    new HeaderApiVersionReader("X-Version"),
                    new MediaTypeApiVersionReader("X-Version"));
            });

            services.AddVersionedApiExplorer(o =>
            {
                o.GroupNameFormat = "'v'VVV";
                o.SubstituteApiVersionInUrl = true;
            });

            //CORS - Dado qualquer header da requisição por http vinda de qualquer metodo (get, post, delete..) e vindos de qualquer origem
            services.AddCors(o => o.AddPolicy("CustomPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .WithExposedHeaders("Token-Expired"); ;
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //CORS
            app.UseCors("CustomPolicy");

            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "KafkaProducerSample.API v1"));

            //HTTPS
            app.UseHttpsRedirection();

            //Indica que vou trabalhar por rotas.
            app.UseRouting();
            app.UseWebSockets();

            //E vou retornar determinados endpoints de acordo com a configuração destas rotas dentro do meu controller
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("There is http communication endpoints.");
                });
            });
        }
    }
}
