
public interface IServices  

    // this is interface only 
{
    // create
    public CommandModel Create(CommandModel model);

    // read
    public CommandModel Get(Guid id);

    // show me all commands we have in a form of list
    public List<CommandModel> list ();

    // show me all commands that move in a form of list
    public List<CommandModel> listMove();

    // update
    public CommandModel? Update(CommandModel newCommand);

    public CommandModel? Update2(CommandModel newCommand, Guid id_provided);

    // delete
    public bool Delete(Guid id);

    // show map
    public List<MapModel> showMap();

    //public bool GetCoord();

    public bool CheckCoord(int checkX, int checkY);

    // update size of map
    public int? Update(MapModel updatedMap);
}

