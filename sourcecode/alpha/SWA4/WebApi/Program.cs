// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Usings.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
//builder.Services.AddDbContext<EFContext>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDbContext<EFContext>(options => options.UseSqlServer(WebApi.Resources.ConnectionString));
builder.Services.AddSwaggerGen(c => { c.SwaggerDoc("v4", new() { Title = "SdWebApi", Version = "v4" }); });

WebApplication? app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment()) { app.UseDeveloperExceptionPage(); app.UseSwagger(); app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v4/swagger.json", "SdWebApi v4")); }

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
