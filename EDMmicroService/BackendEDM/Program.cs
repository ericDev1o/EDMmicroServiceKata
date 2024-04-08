var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var fileTypes = new[]
{
    "PDF", "ODT", "ODS", "ODP", "ODG", "ODF"
};

app.MapGet("/findDocument", () =>
{
    var document = Enumerable.Range(1, 5).Select(index =>
    new Document
    (
        DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        fileTypes[Random.Shared.Next(fileTypes.Length)]
    ))
    .ToArray();
    return document;
}).WithName("GetFileType")
.WithOpenApi();

app.Run();

record Document(DateOnly Date, string? FileType)
{
    
}
