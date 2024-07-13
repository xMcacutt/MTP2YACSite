using System.ComponentModel.DataAnnotations;

namespace MTP2YAC_Scheduling.Models;

public class SignUpFormData
{
    [Required]
    public string DiscordUsername { get; set; }
    public bool Event1 { get; set; }
    public bool Event2 { get; set; }
    public bool Event3 { get; set; }
    public bool Event4 { get; set; }
    public bool Event5 { get; set; }
    public string? Event1StartTime { get; set; }
    public string? Event2StartTime { get; set; }
    public string? Event3StartTime { get; set; }
    public string? Event4StartTime { get; set; }
    public string? Event5StartTime { get; set; }
    public string? Event1EndTime { get; set; }
    public string? Event2EndTime { get; set; }
    public string? Event3EndTime { get; set; }
    public string? Event4EndTime { get; set; }
    public string? Event5EndTime { get; set; }
    public string? Event3RunningPartner { get; set; }
    public string? Event4RunningPartner { get; set; }
    public string? Event5RunningPartner { get; set; }
}