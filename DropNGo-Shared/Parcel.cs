using System.Text.Json;

namespace DropNGo_Shared;

public class Parcel
{
    public Parcel()
    {
    }

    public Parcel(string tracking, Enums.ParcelStatus status)
    {
        TrackingId = tracking;
        Status = status;
    }
    
    public string TrackingId { get; set; }
    public Enums.ParcelStatus Status { get; set; } //TODO make enum for statuses
    
}