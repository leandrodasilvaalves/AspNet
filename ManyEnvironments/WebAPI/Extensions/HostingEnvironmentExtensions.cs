using Microsoft.AspNetCore.Hosting;

namespace WebAPI.Extensions
{
    public static class HostingEnvironmentExtensions
    {
        public static bool IsQA(this IHostingEnvironment hostingEnvironment) => 
            hostingEnvironment.EnvironmentName.Equals("QA");
        
    }
}
