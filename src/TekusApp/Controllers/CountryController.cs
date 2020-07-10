﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TekusApp.Domain.Behaviors;
using TekusApp.Domain.Models;

namespace TekusApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController: ControllerBase
    {
        private readonly ICountryBehavior _countrytBehavior;
        

        public CountryController(ICountryBehavior countryBehavior)
        {
            _countrytBehavior = countryBehavior; 
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<List<Country>> GetAllAsync()
        {
            return await _countrytBehavior.GetAllAsync();
        }
    }
}
