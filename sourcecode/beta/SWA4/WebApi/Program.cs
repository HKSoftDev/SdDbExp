// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Usings.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
WebApplicationBuilder? builder=WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<KestrelServerOptions>(options => { options.ConfigureHttpsDefaults(options => options.ClientCertificateMode = ClientCertificateMode.NoCertificate); });
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<EFContext>(options => options.UseSqlServer(WebApi.Resources.ConnectionString));
builder.Services.AddSwaggerGen(c => { c.SwaggerDoc("v4", new() { Title="SdWebApi", Version="v4" }); });
builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme).AddNegotiate(options => { options.EnableLdap(settings => { settings.Domain=WebApi.Resources.ADDomain; settings.MachineAccountName=
	WebApi.Resources.ADUserName; settings.MachineAccountPassword = WebApi.Resources.ADPassword; }); }).AddCertificate(options=>{ options.Events=new CertificateAuthenticationEvents { OnCertificateValidated=context => { 
		Claim[]? claims=new[] { 
			new Claim(ClaimTypes.NameIdentifier,context.ClientCertificate.Subject,ClaimValueTypes.String,context.Options.ClaimsIssuer),
			new Claim(ClaimTypes.Name,context.ClientCertificate.Subject,ClaimValueTypes.String,context.Options.ClaimsIssuer) };
		context.Principal = new ClaimsPrincipal(new ClaimsIdentity(claims,context.Scheme.Name)); context.Success(); return Task.CompletedTask; } }; });;
builder.Services.AddAuthorization(options => { options.FallbackPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireClaim(ClaimTypes.GroupSid, "S-1-5-21-4166135266-3914534601-1116337541-58942").Build();});

WebApplication? app=builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment()) { app.UseDeveloperExceptionPage(); app.UseSwagger(); app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v4/swagger.json", "SdWebApi v4")); }

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
