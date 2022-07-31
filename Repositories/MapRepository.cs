 public static class MapRepository
{
    // actual "data" examples of commands and their properties

    public static List<MapModel> Map = new()
    {
        // generate a random, unique id for each
        new () { Size = 20, Xcoord = 10, Ycoord = 24, HasRobot= true}
    };
       
}
