
public class Services : IServices
{
    // implement the methods

    public CommandModel Create(CommandModel command)
    {
        command.Id = Guid.NewGuid();  //*
        CommandRepository.Commands.Add(command);
        return command;
    }

    // find by Id
    public CommandModel Get(Guid id)
    {
        // get the command by ID
        var command = CommandRepository.Commands.FirstOrDefault(c => c.Id == id);
        if (command is null)
            return null;
        return command;
    }

    // list all
    public List<CommandModel> list()
    {
        var commands = CommandRepository.Commands;
        return commands;
    }

    // list only the cmd that move the robot; filter applied to "commandDescription"
    public List<CommandModel> listMove()
    {
        var commands = CommandRepository.Commands;
        var moveCommands = CommandRepository.moveCommands; // the empty one
        
        foreach(var element in commands)
        {
            if(element.commandDescription.ToLower().Contains("move"))
            {
                moveCommands.Add(element);
            }
        }
        if (moveCommands is null) return null;
        else return moveCommands;
    }

    // UPDATE version 1  -> we need to provide "Id" and the number when typing changed in Postman "Body" section

    public CommandModel? Update(CommandModel newCommand)
    {
        //find it
        var oldCommand = CommandRepository.Commands.FirstOrDefault(c => c.Id == newCommand.Id);

        if (oldCommand is null)  // if not found
            return null;

        // we can decide to change only one of the parameters not all, so the below
        // keeps the unchanged values
        if (newCommand.commandName is not null)
            oldCommand.commandName = newCommand.commandName;
        if (newCommand.commandDescription is not null)
            oldCommand.commandDescription = newCommand.commandDescription;

        return oldCommand;
    }

    // UPDATE version 2  -> in here we place the "Id" number after slash, so we only need to 
    // type in the changes of other parameteres like name or description in the postman's "Body"
    // we do not need to provide "Id" in the "Body" anymore 

    public CommandModel? Update2(CommandModel newCommand, Guid id_provided)
    {
        //find it
        var oldCommand = CommandRepository.Commands.FirstOrDefault(c => c.Id == id_provided);

        if (oldCommand is null)  // if not found
            return null;

        // we can decide to change only one of the parameters not all, so the below
        // keeps the unchanged values
        if (newCommand.commandName is not null)
            oldCommand.commandName = newCommand.commandName;
        if (newCommand.commandDescription is not null)
            oldCommand.commandDescription = newCommand.commandDescription;

        return oldCommand;
    }

    // true - exists, false- does not
    public bool Exists(Guid id)
    {
        var oldCommand = CommandRepository.Commands.FirstOrDefault(c => c.Id == id);

        if (oldCommand is null)
            return false;

        return true;
    }

    // true - been deleted, false- not found
    public bool Delete(Guid id)
    {
        var oldCommand = CommandRepository.Commands.FirstOrDefault(c => c.Id == id);

        if (oldCommand is null)
            return false;

        CommandRepository.Commands.Remove(oldCommand);

        return true;
    }

    // get a robot map
    public List<MapModel> showMap()
    {
        var map = MapRepository.Map;
        return map;
    }

    // true- a point belongs to map, false- does not belong
    public bool CheckCoord(int checkX, int checkY)
    {
        var Map = MapRepository.Map;

        if (Map is null)
            return false;

        foreach(var mapItem in Map)
        {
            if(mapItem.Xcoord == checkX && mapItem.Ycoord == checkY)
                return true;
        }

        return false;
    }

    // update map with new size

    public int? Update(MapModel updatedMap)
    {
        var oldMap = MapRepository.Map.FirstOrDefault(); // we only have 1 instance of map

        if (oldMap is null)  // if not found
            return null;
        oldMap.Size = updatedMap.Size;

        return updatedMap.Size; // return only this feature, as the rest stays the same
    }
}
