using static Microsoft.AspNetCore.Http.Results;
using Microsoft.AspNetCore.Rewrite;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IFileService>(new InMemoryFileService());

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

app.UseRewriter(new RewriteOptions().AddRedirect("documents/(.*)", "files/$1"));

app.Use(async (context, next) =>
{
    Console.WriteLine($"[{context.Request.Method} {context.Request.Path} {DateTime.UtcNow} Started API]");
    await next(context);
    Console.WriteLine($"[{context.Request.Method} {context.Request.Path} {DateTime.UtcNow}] Ended API");
});

#region data
var files = new List<File>(){};
#endregion

/// <summary> HTTP verbs </summary>
#region POST
app.MapPost("/files", (File file, IFileService service) =>
{
    service.AddFile(file);
    return TypedResults.Created("/files/{id}", file);
})
.AddEndpointFilter(async (context, next) =>
{
    var fileArgument = context.GetArgument<File>(0);
    var errors = new Dictionary<string, string[]>();
    if(fileArgument.DueDate.ToDateTime(new TimeOnly()) < DateTime.UtcNow)
    {
        errors.Add(nameof(File.DueDate), new string[]{"Cannot have a due date in the past"});
    }
    if(errors.Count > 0)
        return Results.ValidationProblem(errors);

    return await next(context);
})
;
#endregion

#region GET
/// <summary> Get 
/// all, 
/// random typed,
/// all files and 
/// by id files.
/// 
/// ToDo:
/// app.MapGet("/files/{id}", Results<Ok<File>, NotFound>(int id, IFileService service) =>
///{
///    var file = service.GetFileById(id);
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

app.MapGet("/files", (IFileService service) => service.GetFiles());
#endregion

#region DELETE
app.MapDelete("/files/{id}", (int id, IFileService service) =>
{
    service.DeleteFileById(id);
    return TypedResults.NoContent();
});
#endregion

app.Run();

#region domain
record File(int Id, string Name, DateOnly DueDate, string? FileType, bool? IsIndexed){}

interface IFileService
{
    File? GetFileById(int id);
    List<File> GetFiles();
    void DeleteFileById(int id);
    File AddFile(File file);
}

/// <summary>
/// Decoupled to replace it by a database handler.
/// </summary>
class InMemoryFileService : IFileService
{
    private readonly List<File> _files = [];

    public File AddFile(File file)
    {
        _files.Add(file);
        return file;
    }

    public void DeleteFileById(int id)
    {
        _files.RemoveAll(file => id == file.Id);
    }

    public File GetFileById(int id)
    {
        return _files.SingleOrDefault(file => id == file.Id);
    }

    public List<File> GetFiles()
    {
        return _files;
    }
}
#endregion