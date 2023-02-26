namespace NegoSudApi.Models;

public enum DeliveryStatus
{
    New = 1,
    OnHold = 2,
    Validate = 3,
    Ready = 4,
    Pending = 5,
    Delivered = 6,
    Failed = 7,
    Cancelled = 8
}