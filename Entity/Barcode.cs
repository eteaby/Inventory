public class BarcodeTag : Base
{
    public Guid ItemId { get; set; } = default!; // FK
    public string TagCode { get; set; } = default!;
    public string Type { get; set; } = default!; // Barcode/RFID
    public Guid? AssignedToStorageLocationId { get; set; } // optional FK StorageLocation
    public Guid? AssignedToBatchId { get; set; } // optional FK Batch
    public Guid? AssignedToSerialId { get; set; } // optional FK SerialNumber

    // Navigation
    public Item? Item { get; set; }
    public StorageLocation? AssignedLocation { get; set; }
    public Batch? AssignedBatch { get; set; }
    public SerialNumber? AssignedSerial { get; set; }
}
