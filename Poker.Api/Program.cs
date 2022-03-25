using Poker.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services
  .AddGraphQLServer()
  .AddQueryType<Query>();

var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints =>
  endpoints.MapGraphQL());

await app.RunAsync();
