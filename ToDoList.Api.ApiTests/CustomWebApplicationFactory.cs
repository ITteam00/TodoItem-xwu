using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;

namespace ToDoList.Api.ApiTests;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureAppConfiguration((context, config) =>
        {
            // 清除默认配置源
            config.Sources.Clear();

            // 加载默认的 appsettings.json
            config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            // 加载测试专用的 appsettings.Testing.json
            config.AddJsonFile("appsettings.Testing.json", optional: true, reloadOnChange: true);

            // 加载环境变量
            config.AddEnvironmentVariables();
        });
    }
}