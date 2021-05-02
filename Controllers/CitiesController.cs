using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using netcore_cities.Models;
using netcore_cities.Repositories;
using netcore_cities.DTO.Info;
using System;

namespace netcore_cities.Controllers{
  [ApiController]
  [Route("[controller]")]
  public class CitiesController : ControllerBase
  {
    private readonly ICitiesRepository citiesRepository;

    public CitiesController(ICitiesRepository citiesRepository)
    {
        this.citiesRepository = citiesRepository;
    }

    [HttpGet()]
    public IEnumerable<CityInfo> GetCities()
    {
      return citiesRepository.GetCities().Select(city => city.AsDto());
    }

    [HttpGet("{id}")]
    public ActionResult GetById(int id)
    {
      var city = citiesRepository.GetById(id);

      if(city is null)
      { return NotFound(); }

      return Ok(city.AsDto());
    }

    [HttpPost]
    public ActionResult<CityInfo> CreateCity(CityInfo city)
    {
      CityModel cityModel = new(){
        Id = city.Id,
        Name = city.Name,
        Country = city.Country,
        Capital = city.Capital,
        CreatedDate = DateTime.Now,
      };

      citiesRepository.CreateCity(cityModel);

      return CreatedAtAction(nameof(GetById), new { id = cityModel.Id }, cityModel.AsDto());
    }

    [HttpPut]
    public ActionResult UpdateCity(CityInfo city)
    {
      CityModel currentCity = citiesRepository.GetById(city.Id);

      if(currentCity is null){
        return NotFound();
      }

      CityModel updatedCity = new() {
        Id = currentCity.Id,
        Name= city.Name,
        Country= city.Country,
        Capital= city.Capital,
        CreatedDate = currentCity.CreatedDate
      };

      citiesRepository.UpdateCity(updatedCity);

      return NoContent();
    }
    
    [HttpDelete("{id}")]
    public ActionResult UpdateCity(int id)
    {
      CityModel currentCity = citiesRepository.GetById(id);

      if(currentCity is null){
        return NotFound();
      }

      citiesRepository.DeleteCity(id);

      return NoContent();
    }
  }
}