using _3.Data.Model;

namespace _1.API.Response;
 
 public class ProfileResponse
 {
     public string Name { get; set; }
     public string Lastname { get; set; }
     public string Email { get; set; }
     public UserType Rol { get; set; }
     public string Phone { get; set; }
     public int QuantityVehiclesRented { get; set; }
     public List<Automobile> Automobiles { get; set; }
     public byte[] Image { get; set; }
 }