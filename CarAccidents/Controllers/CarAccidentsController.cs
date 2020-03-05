using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarAccidents.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace CarAccidents.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarAccidentsController : ControllerBase
    {
        private readonly CarAccidentService _carAccidentService;

        public CarAccidentsController(CarAccidentService carAccidentService)
        {
            _carAccidentService = carAccidentService;
        }

        // GET: api/TodoItems/5
        [HttpGet("{gpsLongitude: double}/{gpsLatitude: double}")]
        public IEnumerable<CarAccidentViewModel> GetCarAccidentList(double gpsLongitude, double gpsLatitude)
        {
            var accidents = _carAccidentService.GetClosestAccidents(gpsLongitude, gpsLatitude);

            return accidents.Select(a => CarAccidentViewModel.From(a));
        }
    }
}