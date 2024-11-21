using Microsoft.AspNetCore.Mvc;
using Patient.Repositories;
using Patient.Models;
using FeatureHubSDK;


namespace Patient.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientController : ControllerBase
{
    private readonly IPatientRepository _patientRepository;
    private readonly IClientContext _featureHub;

    public PatientController(IPatientRepository patientRepository, IClientContext featureHub)
    {
        _patientRepository = patientRepository;
        _featureHub = featureHub;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PatientModel>>> Get()
    {
        if (!_featureHub.IsEnabled("patient.get"))
        {
            return Forbid();
        }

        var patients = await _patientRepository.GetPatientsAsync();
        return Ok(patients);
    }

    [HttpGet("{SSN}")]
    public async Task<ActionResult<PatientModel>> Get(string SSN)
    {
        if (!_featureHub.IsEnabled("patient.getBySSN"))
        {
            return Forbid();
        }

        var patient = await _patientRepository.GetPatientBySSNAsync(SSN);
        if (patient == null)
        {
            return NotFound();
        }
        return Ok(patient);
    }

    [HttpPost]
    public async Task<ActionResult<PatientModel>> Post([FromBody] PatientModel patient)
    {
        if (!_featureHub.IsEnabled("patient.post"))
        {
            return Forbid();
        }

        var createdPatient = await _patientRepository.AddPatientAsync(patient);
        return CreatedAtAction(nameof(Get), new { SSN = createdPatient.SSN }, createdPatient);
    }

    [HttpPut("{SSN}")]
    public async Task<IActionResult> Put(string SSN, [FromBody] PatientModel patient)
    {
        if (!_featureHub.IsEnabled("patient.put"))
        {
            return Forbid();
        }

        if (SSN != patient.SSN)
        {
            return BadRequest();
        }

        await _patientRepository.UpdatePatientAsync(patient);
        return NoContent();
    }

    [HttpDelete("{SSN}")]
    public async Task<IActionResult> Delete(string SSN)
    {
        if (!_featureHub.IsEnabled("patient.delete"))
        {
            return Forbid();
        }

        var patient = await _patientRepository.GetPatientBySSNAsync(SSN);
        if (patient == null)
        {
            return NotFound();
        }

        await _patientRepository.DeletePatientAsync(patient);
        return NoContent();
    }
}
