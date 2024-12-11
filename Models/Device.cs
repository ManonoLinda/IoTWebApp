public class Device
{
    public int DeviceID { get; set; } // Primary Key
    public string DeviceName { get; set; } // Name of the device (e.g., "Sensor X123")
    public int FirmwareID { get; set; } // Links to the Firmware table
    public Firmware Firmware { get; set; } // Navigation property for firmware
    public int GroupID { get; set; } // Links to the Group table
    public Group Group { get; set; } // Navigation property for the group
}