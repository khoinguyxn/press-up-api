var builder = DistributedApplication.CreateBuilder(args);

builder.AddDockerComposeEnvironment("pressup-aspire-app");

var mySqlDb = builder.AddMySql("mysql").WithLifetime(ContainerLifetime.Persistent).AddDatabase("mysqldb");

builder.AddProject<Projects.PressUpAspireApp_Api>("api").WithHttpHealthCheck("/health").WithReference(mySqlDb)
       .WaitFor(mySqlDb);

builder.Build().Run();