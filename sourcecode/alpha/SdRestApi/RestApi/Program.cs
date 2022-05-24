// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Bizz.Add.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
using FluentValidation;
using MediatR;

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// add mongo db
builder.Services.Configure<MongoDatabaseSettings>(builder.Configuration.GetSection(nameof(MongoDatabaseSettings)));
builder.Services.AddSingleton<IMongoDatabaseSettings>(sp => sp.GetRequiredService<IOptions<MongoDatabaseSettings>>().Value);

builder.Services.AddControllers();

// Inject the mediator
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
builder.Services.AddScoped<ITaskItemRepository, TaskItemRepository>();


builder.Services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new() { Title = "TaskApp", Version = "v1" }); });


WebApplication? app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment()) { app.UseDeveloperExceptionPage(); app.UseSwagger(); app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TaskApp v1")); }

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
