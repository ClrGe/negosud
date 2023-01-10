﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NegoSudApi;
using NegoSudApi.Models;
using NegoSudApi.Services;

namespace NegoSudApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location>>> GetLocations()
        {
            IEnumerable<Location>? locations = await _locationService.GetLocations();
            if (locations == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return StatusCode(StatusCodes.Status200OK, locations.ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Location>> GetLocation(int locationId)
        {
            Location? location = await  _locationService.GetLocation(locationId);
            if (location == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return StatusCode(StatusCodes.Status200OK, location);
        }

        [HttpPost]
        public async Task<ActionResult<Location>> PostLocation(Location model)
        {
            Location? location = await _locationService.PostLocation(model);
            if (location == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return StatusCode(StatusCodes.Status200OK, location);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocation(int locationId, Location model)
        {
            if (locationId != model.Id)
            {
                return BadRequest();
            }

            Location? location = await _locationService.PutLocation(model);
            if (location == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return StatusCode(StatusCodes.Status200OK, location);
        }        

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(int locationId)
        {
            Location? location = await _locationService.GetLocation(locationId);
            if (location == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            await _locationService.DeleteLocation(locationId);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet("bottles/{id}")]
        public async Task<IActionResult> GetBottles(int locationId)
        {
            Location? location = await _locationService.GetLocation(locationId);
            if (location == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            IEnumerable<Bottle>? bottles = await _locationService.GetBottles(locationId);
            if (bottles == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return StatusCode(StatusCodes.Status200OK, bottles);
        }

        [HttpGet("storage/{id}")]
        public async Task<IActionResult> GetStorages(int locationId)
        {
            Location? location = await _locationService.GetLocation(locationId);
            if (location == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            IEnumerable<Storage>? storages = await _locationService.GetStorages(locationId);
            if (storages == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return StatusCode(StatusCodes.Status200OK, storages);
        }


    }
}
