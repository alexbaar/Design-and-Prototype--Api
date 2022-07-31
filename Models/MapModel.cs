public class MapModel
{
    public int Size { get; set; }
    public int Ycoord { get; set; }
    public int Xcoord { get; set; }
    public override string ToString() => $"({Xcoord}-{Ycoord}";
    public bool HasRobot { get; set; }
}
