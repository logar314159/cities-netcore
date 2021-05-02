using System;

namespace netcore_cities.Models{
  public class CityModel{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }
    public bool Capital { get; set; }
    public DateTime CreatedDate{ get; set; }
  }
}