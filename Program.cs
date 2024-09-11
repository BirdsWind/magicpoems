using MagicPoems.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");



List<GetPoemDto> poems = [
    new (
        0,
        "Be patient toward all that is unsolved in your heart and try to love the questions themselves, like locked rooms and like books that are now written in a very foreign tongue. Do not now seek the answers, which cannot be given you because you would not be able to live them. And the point is, to live everything. Live the questions now. Perhaps you will then gradually, without noticing it, live along some distant day into the answer.",
        "Rainer Maria Rilke"
    ),
    new (
        1,
        "Let the people who never find true love keep saying that there's no such thing.Their faith will make it easier for them to live and die.",
        "Wislawa Szymborska"
    )];

app.MapGet("poems", ()=>poems);
app.MapGet("poems/{id}", (int id) => {
    return poems.Find(poem=>poem.id == id);
}).WithName("GetPoem");

app.MapPost("poems",(CreatePoemDto newPoem)=> {
    int id = poems.Count + 1;
    GetPoemDto poem = new(id,newPoem.content, newPoem.author);
    poems.Add(poem);
    return Results.CreatedAtRoute("GetPoem", new {id= id}, poem);
});

app.Run();
