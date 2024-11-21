using Measurement.Repositories;
using Microsoft.AspNetCore.Mvc;
using Measurement.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Measurement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MeasurementController : ControllerBase
{
    private readonly IMeasurementRepository _measurementRepository;

    public MeasurementController(IMeasurementRepository measurementRepository)
    {
        _measurementRepository = measurementRepository;
    }

    // GET: api/<MeasurementController>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MeasurementModel>>> Get()
    {
        var measurements = await _measurementRepository.GetMeasurementsAsync();
        return Ok(measurements);
    }

    // GET api/<MeasurementController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<MeasurementModel>> Get(int id)
    {
        var measurement = await _measurementRepository.GetMeasurementByIdAsync(id);
        if (measurement == null)
        {
            return NotFound();
        }
        return Ok(measurement);
    }

    // POST api/<MeasurementController>
    [HttpPost]
    public async Task<ActionResult<MeasurementModel>> Post([FromBody] MeasurementModel measurement)
    {
        var createdMeasurement = await _measurementRepository.AddMeasurementAsync(measurement);
        return CreatedAtAction(nameof(Get), new { id = createdMeasurement.Id }, createdMeasurement);
    }

    // PUT api/<MeasurementController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] MeasurementModel measurement)
    {
        if (id != measurement.Id)
        {
            return BadRequest();
        }

        await _measurementRepository.UpdateMeasurementAsync(measurement);
        return NoContent();
    }

    // DELETE api/<MeasurementController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var measurement = await _measurementRepository.GetMeasurementByIdAsync(id);
        if (measurement == null)
        {
            return NotFound();
        }

        await _measurementRepository.DeleteMeasurementAsync(measurement);
        return NoContent();
    }
}
