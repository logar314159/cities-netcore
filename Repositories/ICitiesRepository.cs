using System;
using System.Collections.Generic;
using System.Linq;
using netcore_cities.Models;

namespace netcore_cities.Repositories{
  public interface ICitiesRepository{

    IEnumerable<CityModel> GetCities();

    CityModel GetById(int id);

    void CreateCity(CityModel city);

    void UpdateCity(CityModel city);

    void DeleteCity(int id);
  }
}