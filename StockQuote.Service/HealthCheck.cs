﻿namespace MinimalAPIService
{
    public static class HealthCheckExtensions
    {
        public static void ConfigureHealthChecks(this IServiceCollection services)
        {
            services.AddHealthChecks();

            services.AddHealthChecksUI(opt =>
            {
                opt.SetEvaluationTimeInSeconds(10); //time in seconds between check    
                opt.MaximumHistoryEntriesPerEndpoint(60); //maximum history of checks    
                opt.SetApiMaxActiveRequests(1); //api requests concurrency    
                opt.AddHealthCheckEndpoint("feedback api", "/health"); //map health check api    

            })
                .AddInMemoryStorage();
        }
    }
}
