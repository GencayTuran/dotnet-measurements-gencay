using ABB.Interview.API.DeviceGroups.Managers;
using ABB.Interview.API.DeviceGroups.Managers.Interfaces;
using ABB.Interview.API.Devices.Managers;
using ABB.Interview.API.Devices.Managers.Interfaces;
using ABB.Interview.API.Services;
using ABB.Interview.API.Services.Interfaces;

namespace ABB.Interview.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddTransient<IDeviceListManager, DeviceListManager>();
            builder.Services.AddTransient<IDeviceGroupManager, DeviceGroupManager>();
            builder.Services.AddSingleton<IDataHandlerService, DataHandlerService>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}