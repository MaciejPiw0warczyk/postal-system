namespace DropNGo_Shared;

public class PickUpBox
{
    public string BoxCode;
    public string Address;
    public List<Compartment> Compartments;
}

public class Compartment
{
    public bool IsFull;
    public ParcelSize MaxSize;
    public string? ParcelId;
}