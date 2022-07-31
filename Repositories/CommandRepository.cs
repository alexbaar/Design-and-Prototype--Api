public static class CommandRepository
{
    // actual "data" examples of commands and their properties

    public static List<CommandModel> Commands = new()
    {
        // generate a random, unique id for each
        new () { Id = Guid.NewGuid(), commandName = "left", commandDescription = "The action of turning left"},
        new () { Id = Guid.NewGuid(), commandName = "right", commandDescription = "The action of turning right"},
        new () { Id = Guid.NewGuid(), commandName = "up", commandDescription = "The action of turning upwards"},
        new () { Id = Guid.NewGuid(), commandName = "slow", commandDescription = "Move at slower pace"},
        new () { Id = Guid.NewGuid(), commandName = "fast", commandDescription = "Move fast"},
        new () { Id = Guid.NewGuid(), commandName = "back up", commandDescription = "Move backwards"}
    };

    // an empty list for the moving commands that will be populated
    public static List<CommandModel> moveCommands = new List<CommandModel>();

}

