using CelebrancyHQ.Repository.Persons;
using CelebrancyHQ.Repository.Users;

namespace CelebrancyHQ.Repository
{
    /// <summary>
    /// Provides dependency setup for the CelebrancyHQ.Repository library.
    /// </summary>
    public static class DependencySetup
    {
        /// <summary>
        /// Sets up the dependencies for the CelebrancyHQ.Repository library.
        /// </summary>
        public static void AddCelebrancyHQRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
        }
    }
}