using static Microsoft.AspNetCore.Http.Results;

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

#region data
var files = new List<File>();
#endregion

/// <summary> HTTP verbs </summary>
#region POST
app.MapPost("/files", (File file) =>
{
    files.Add(file);
    return TypedResults.Created("/files/{id}", file);
});
#endregion

#region GET
/// <summary> Get 
/// all, 
/// random typed,
/// all files and 
/// by id files.
/// 
/// ToDo:
/// app.MapGet("/files/{id}", Results<Ok<File>, NotFound>(int id) =>
///{
///    var file = files.SingleOrDefault(f => id == f.id);
///    return file is null 
///   ?
///   TypedResults.NotFound()
///    :
///    TypedResults.Ok(file);
///});
/// </summary>
app.MapGet("/", () =>
{
    var file = Enumerable.Range(0, 6).Select(index =>
    new File
    (
        index, 
        string.Concat("Name", index),
        DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        fileTypes[index],
        false
    ))
    .ToArray();
    return file;
}).WithName("GetAllFileTypes")
.WithOpenApi();

app.MapGet("/randomFileTypes", () =>
{
    var file = Enumerable.Range(2, 4).Select(index =>
    new File
    (
        index,
        string.Concat("Name", index),
        DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        fileTypes[Random.Shared.Next(fileTypes.Length)],
        false
    ))
    .ToArray();
    return file;
}).WithName("GetRandomFileTypes")
.WithOpenApi();

app.MapGet("/files", () => files);
#endregion

#region DELETE
app.MapDelete("/files/{id}", (int id) =>
{
    files.RemoveAll(f => id == f.id);
    return TypedResults.NoContent();
});
#endregion

app.Run();

#region domain
record File(int id, string Name, DateOnly Date, string? FileType, bool? isIndexed){}
#endregion