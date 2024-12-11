namespace DigitalMatterWebApp.Models
{
    public class Firmware
    {
        public int FirmwareID { get; set; } // Primary Key
        public string Version { get; set; } // Firmware version (e.g., "1.0.3")
        public DateTime ReleaseDate { get; set; } // Firmware release date
        public List<Device> Devices { get; set; } // List of devices using this firmware

    }
}