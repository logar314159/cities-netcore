using netcore_cities.Models;
using netcore_cities.DTO.Info;

namespace netcore_cities{
  public static class Extensions{
    public static CityInfo AsDto(this CityModel cityModel)
    {
        return new  CityInfo {
          Id = cityModel.Id,
          Name = cityModel.Name,
          Country = cityModel.Country,
          Capital = cityModel.Capital,
        };
    }
  }
}