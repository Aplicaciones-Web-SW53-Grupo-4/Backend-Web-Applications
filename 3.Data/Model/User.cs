﻿namespace _3.Data.Model;

public class User:ModelBase
{
    public string username{ get; set; }
    public string password { get; set; }
    public string Name { get; set; }
    public string Lastname { get; set; }
    public string Country { get; set; }
    public string phone { get; set; }
    
    public UserType UserType { get; set; } 
    
}