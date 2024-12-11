using System.Collections.Generic;

public class Firmware
{
    public int FirmwareID { get; set; } // Primary Key
    public string Version { get; set; } // Firmware version (e.g., "1.0.3")
    public string Description { get; set; } // Additional information about the firmware
    public List<Device> Devices { get; set; } // List of devices using this firmware
}
