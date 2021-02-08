using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BRQ_Test.Data.Repositories;
using BRQ_Test.Domain.Interfaces;
using BRQ_Test.Domain.Models;
using BRQ_Test.Domain.ViewModel;

namespace BRQ_Test.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TruckController : ControllerBase
    {
        private readonly ITruckService _truckService;
        private readonly IMapper _mapper;

        public TruckController(ITruckService truckService, IMapper mapper)
        {
            _truckService = truckService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Add(CreateTruckViewModel truck)
        {
            await _truckService.Add(_mapper.Map<Truck>(truck));

            return Ok(truck);

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update([FromRoute] int id, UpdateTruckViewModel truck)
        {
            if (id != truck.Id)
                return BadRequest();

            await _truckService.Update(_mapper.Map<Truck>(truck));

            return Ok(truck);

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Truck>> GetById([FromRoute] int id)
        {
            var truck = await _truckService.GetById(id);

            if (truck == null) return NotFound();

            return Ok(_mapper.Map<TruckViewModel>(truck));
        }

        [HttpGet]
        public async Task<ActionResult<Truck>> Get()
        {
            var truckList = await _truckService.Get();

            return Ok(_mapper.Map<IList<TruckViewModel>>(truckList));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Truck>> Delete([FromRoute] int id)
        {
            var truck = await _truckService.GetById(id);

            if (truck == null) return NotFound();

            await _truckService.Delete(id);

            return Ok();
        }
    }
}
