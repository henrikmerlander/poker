using Poker.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services
  .AddGraphQLServer()
  .AddQueryType<Query>()
  .AddMutationType<Mutation>();

var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints =>
  endpoints.MapGraphQL());

await app.RunAsync();
