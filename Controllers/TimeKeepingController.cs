using wickedbotz_web_api.Model;
using wickedbotz_web_api.Repository;

namespace wickedbotz_web_api.Controllers;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TimeKeepingController : ControllerBase
{
    private readonly TimekeepingRepository _timekeepingRepository;

    public TimeKeepingController(TimekeepingRepository timekeepingRepository) =>
        _timekeepingRepository = timekeepingRepository;

    [HttpGet]
    public async Task<List<Timekeeping>> Get() =>
        await _timekeepingRepository.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Timekeeping>> Get(string id)
    {
        var timekeeping = await _timekeepingRepository.GetAsync(id);

        if (timekeeping is null)
        {
            return NotFound();
        }

        return timekeeping;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Timekeeping newTimeKeeping)
    {
        await _timekeepingRepository.CreateAsync(newTimeKeeping);

        return CreatedAtAction(nameof(Get), new { id = newTimeKeeping.Id }, newTimeKeeping);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Timekeeping updatedTimekeeping)
    {
        var timekeeping = await _timekeepingRepository.GetAsync(id);

        if (timekeeping is null)
        {
            return NotFound();
        }

        updatedTimekeeping.Id = timekeeping.Id;

        await _timekeepingRepository.UpdateAsync(id, updatedTimekeeping);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var updatedTimekeeping = await _timekeepingRepository.GetAsync(id);

        if (updatedTimekeeping is null)
        {
            return NotFound();
        }

        await _timekeepingRepository.RemoveAsync(id);

        return NoContent();
    }
}