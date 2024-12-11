namespace DigitalMatterWebApp.Models;

public class DeviceFirmwareViewModel
{
    public int DeviceID { get; set; }
    public string DeviceName { get; set; }
    public int FirmwareID { get; set; }
    public string FirmwareVersion { get; set; }
    public DateTime ReleaseDate { get; set; }
}