using System.ComponentModel.DataAnnotations;
using _3.Data.Model;

namespace _1.API.Request;

public class ProfileUpdateRequest
{
    [MaxLength (30)]
    public string Name { get; set; }
    [MaxLength (30)]
    public string Lastname { get; set; }
    [MaxLength (30)]
    public string Email { get; set; }
    [MaxLength (9)]
    public string Phone { get; set; }
    public byte[] Image { get; set; }
}