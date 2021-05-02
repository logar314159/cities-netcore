using System;
using System.Collections.Generic;
using System.Linq;
using netcore_cities.Models;

namespace netcore_cities.Repositories{
  public class MemoryCitiesRepository : ICitiesRepository{

    private int CurrentId = 4;

    private readonly List<CityModel> cities = new(){
      new CityModel{ Id= 1, Name= "México", Country= "México", Capital= true, CreatedDate= DateTime.Now },
      new CityModel{ Id= 2, Name= "Madrid", Country= "México", Capital= true, CreatedDate= DateTime.Now },
      new CityModel{ Id= 3, Name= "París", Country= "México", Capital= true, CreatedDate= DateTime.Now },
      new CityModel{ Id= 4, Name= "Berlín", Country= "México", Capital= true, CreatedDate= DateTime.Now },
    };

    public int GetCurrentId(){ CurrentId ++; return CurrentId; }

    public IEnumerable<CityModel> GetCities(){
      return cities;
    }

    public CityModel GetById(int id){
      return cities.Where(city => city.Id == id).FirstOrDefault();
    }

    public void CreateCity(CityModel city){
      city.Id = GetCurrentId();
      cities.Add(city);
    }

    public void UpdateCity(CityModel city){
      var index = cities.FindIndex(x => x.Id == city.Id);

      cities[index] = city;
    }

    public void DeleteCity(int id){      
      var index = cities.FindIndex(x => x.Id == id);

      cities.RemoveAt(index);
    }
  }
}