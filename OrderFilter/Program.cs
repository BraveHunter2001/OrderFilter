using OrderFilter.Repositories;
using System.Text;

namespace OrderFilter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string connect = builder.Configuration.GetValue<string>("ConnectionString");
            string logPath = builder.Configuration.GetValue<string>("deliveryLog");

            MyDbContext.InstanseDataBase(connect);

            // Add services to the container.
            builder.Services.AddScoped<IResultRepository, ResultRepository>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();

            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();
            app.Use(async (context, next) =>
            {
                Stream originalBody = context.Response.Body;

                try
                {
                    using var memStream = new MemoryStream();
                    context.Response.Body = memStream;
                    await next(context);

                    memStream.Position = 0;
                    string responseBody = new StreamReader(memStream).ReadToEnd();

                    memStream.Position = 0;
                    await memStream.CopyToAsync(originalBody);

                    var sb = new StringBuilder();
                    sb.AppendLine($"Log {DateTime.Now}");
                    sb.AppendLine($"Requset:\n {context.Request.Path}{context.Request.QueryString}");
                    sb.AppendLine($"Response:\n {context.Response.StatusCode} {responseBody}");

                    using var writer = new StreamWriter(logPath, true);
                    writer.WriteLine(sb);
                }
                finally
                {
                    context.Response.Body = originalBody;
                }
            });

            app.MapControllers();

            app.Run();
        }
    }
}