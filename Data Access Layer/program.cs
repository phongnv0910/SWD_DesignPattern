using Data_Access_Layer.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Data_Access_Layer
{
    public interface IDataContext
    {
        SWDContext Context { get; }
    }
    public class DataContext : IDataContext
    {
        public SWDContext Context { get; }

        public DataContext(SWDContext context)
        {
            Context = context;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();

            services.AddScoped<IDataContext, DataContext>();

            var serviceProvider = services.BuildServiceProvider();

            using (var scope = serviceProvider.CreateScope())
            {
                var dataContext = scope.ServiceProvider.GetRequiredService<IDataContext>();

            }
        }
    }
}


