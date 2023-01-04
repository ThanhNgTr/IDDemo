var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

//Add various middleware to the app pipeline
app.UseHttpsRedirection();
app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

//app.MapRazorPages();
//app.Run(async context =>
//{
//    await context.Response.WriteAsync("Hello Dear Readers!");
//});

app.Use(async (context, next) =>
{
    //Do work that does not write to the Response
    await next.Invoke();
    //Do logging or other work that does not write to the Response.
});
app.Map("/tes", HandleBranchOne);

app.Map("", HandleBranchTwo);

//Rest of Program.cs file

app.Run();

static void HandleBranchOne(IApplicationBuilder app)
{
    app.Run(async context =>
    {
        await context.Response.WriteAsync("NHANH TEST");
    });
}

static void HandleBranchTwo(IApplicationBuilder app)
{
    app.Run(async context =>
    {
        await context.Response.WriteAsync("TRANG MAC DINH");
    });
}

app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
