using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using vue_dotnet_mvc;

namespace vue_dotnet_mvc.Controllers
{

  [Route("api/[controller]")]
  // [Authorize]
  [ApiController]
  public class DeviceRecordsController : ControllerBase
  {
    private readonly ApplicationDbContext _dbContext;

    public DeviceRecordsController(ApplicationDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    // GET api/DeviceRecords
    [HttpGet]
    public async Task<ActionResult<List<DeviceRecord>>> Get()
    {
      return await _dbContext.DeviceRecords.ToListAsync();
    }

    // GET api/DeviceRecords/5
    [HttpGet("{id}")]
    public async Task<ActionResult<DeviceRecord>> Get(string id)
    {
      return await _dbContext.DeviceRecords.FindAsync(id);
    }

    // POST api/DeviceRecords
    [HttpPost]
    public async Task Post(DeviceRecord model)
    {
      await _dbContext.AddAsync(model);
      
      await _dbContext.SaveChangesAsync();
    }

    // PUT api/DeviceRecords/5
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(string id, DeviceRecord model)
    {
      var exists = await _dbContext.DeviceRecords.AnyAsync(f => f.Id == id);
      if (!exists)
      {
        return NotFound();
      }

      _dbContext.DeviceRecords.Update(model);
      
      await _dbContext.SaveChangesAsync();

      return Ok();

    }

    // DELETE api/DeviceRecords/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(string id)
    {
      var entity = await _dbContext.DeviceRecords.FindAsync(id);

      _dbContext.DeviceRecords.Remove(entity);
      
      await _dbContext.SaveChangesAsync();
      
      return Ok();
    }
  }
}