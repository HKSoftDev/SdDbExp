// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Usings.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<EFContext>(options => options.UseSqlServer(WebApi.Resources.ConnectionString));
builder.Services.AddSwaggerGen(c => { c.SwaggerDoc("v4", new() { Title = "SdWebApi", Version = "v4" }); });

builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme).AddNegotiate();

builder.Services.AddAuthorization(options => { options.FallbackPolicy = options.DefaultPolicy; });

builder.Services.AddControllersWithViews(options => { AuthorizationPolicy? policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireClaim("groups", "SdDatabase_Gruppe").Build();
  options.Filters.Add(new AuthorizeFilter(policy)); }); 

WebApplication? app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment()) { app.UseDeveloperExceptionPage(); app.UseSwagger(); app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v4/swagger.json", "SdWebApi v4")); }

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
