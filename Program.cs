var builder = WebApplication.CreateBuilder(args);

// register the service
builder.Services.AddSingleton<IServices, Services>();

var app = builder.Build();

// our endpoints

app.MapGet("/", () => "Hello Robot!");

app.MapPost("/robot-commands",(CommandModel model, IServices service) =>
{
    var result = service.Create(model);
    // 200 OK
    return Results.Ok(result);
});

// GET BY ID version 1

app.MapGet("/get", (IServices service, Guid id) =>
{
    var command = service.Get(id);

    if (command is null)
        return Results.NotFound("Command was not found");

    // 200 OK
    return Results.Ok(command);
});

// GET BY ID version 2

app.MapGet("/robot-commands/{id}", (IServices service, Guid id) =>
{
    var command = service.Get(id);
    // depending on if record is found or not
    return command is not null ? Results.Ok(command) : Results.NotFound();
});

// LIST ALL

app.MapGet("/robot-commands", (IServices service) =>
{
    var listOfCommands = service.list();

    // 200 OK
    return Results.Ok(listOfCommands);
});

// LIST COMMANDS THAT MOVE 

app.MapGet("/robot-commands/move", (IServices service) =>
{
    var listOfMoveCommands = service.listMove();

    // 200 OK
    return Results.Ok(listOfMoveCommands);
});

// UPDATE version 1  -> we need to provide "Id" and the number when typing changed in Postman "Body" section

app.MapPut("/robot-commands", ( CommandModel newCommand, IServices service) =>
{
    var updatedCommand = service.Update(newCommand);

    if (updatedCommand is null)
        return Results.NotFound("Command was not found, so it cannot be updated");

    // 200 OK
    return Results.Ok(updatedCommand);
});


// UPDATE version 2  -> in here we place the "Id" number after slash, so we only need to 
// type in the changes of other parameteres like name or description in the postman's "Body"
// we do not need to provide "Id" in the "Body" anymore 

app.MapPut("/robot-commands/{id}", (CommandModel updatedCommand, IServices service, Guid id) =>
{


    var cmd = service.Get(id);

    if (cmd is null)
        return Results.NotFound("Command was not found, so it cannot be updated");
    cmd = service.Update2(updatedCommand,id);

    // 200 OK
    return Results.Ok(cmd);
});

//app.MapPut("/commands/{id}", ([FromServices] CommandRepository repository, Guid id, CommandsList updatedCommand) =>
//{
//    var cmd = repository.GetById(id);
//    if (updatedCommand is null)
//    {
//        return Results.NotFound();
//    }

//    repository.Update(updatedCommand);
//    return Results.Ok(updatedCommand);

//});

// DELETE

app.MapDelete("/delete/{id}", (Guid id, IServices service) =>
{
    var toBeDeleted = service.Delete(id);

    if (!toBeDeleted) // is false
        return Results.NotFound("Cannot delete a non existent record");

    // 200 OK
    return Results.Ok(toBeDeleted);
});

// GET ROBOT MAP

app.MapGet("/robot-map", (IServices service) =>
{
    var map = service.showMap();

    // 200 OK
    return Results.Ok(map);
});

// GET MAP COORDINATES

app.MapGet("/robot-map/{Xcoord}-{Ycoord}", (int Xcoord, int Ycoord, IServices service) =>
{
    var map = service.CheckCoord(Xcoord, Ycoord);

    if (!map) // is false
        return Results.NotFound(map + "  -> Point does not belong to the map");

    // 200 OK
    return Results.Ok(map + "  -> Point belongs to the map");
});

// UPDATE SIZE OF THE MAP

app.MapPut("/robot-map", (MapModel newMap, IServices service) =>
{
    var updatedMap = service.Update(newMap);

    if (updatedMap is null)
        return Results.NotFound("Command was not found, so it cannot be updated");

    // 200 OK
    return Results.Ok(updatedMap);
});

app.Run();
