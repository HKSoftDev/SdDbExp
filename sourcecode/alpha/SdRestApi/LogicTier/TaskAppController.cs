// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Bizz.Update.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LogicTier;

/// <remarks/>
[Route("api/[controller]")]
[ApiController]
public class TaskAppController : ControllerBase
{
  /// <remarks/>
  public IMediator Mediator { get; }

  /// <remarks/>
  public TaskAppController(IMediator mediator) { Mediator = mediator; }

  /// <summary>GET: api/{TaskAppController}</summary>
  [HttpGet]
  public IEnumerable<string> Get() => new string[] { "value1", "value2" };

  /// <summary>GET api/{TaskAppController}/5</summary>
  [HttpGet("{id}")]
  public async Task<IActionResult> Get(int id) { List<TaskItem>? results = await Mediator.Send(new GetAllTasksQuery()); return Ok(results); }

  /// <summary>POST api/{TaskAppController}</summary>
  [HttpPost]
  public async Task<IActionResult> CreateTaskItem([FromBody] CreateTaskCommand command) { await Mediator.Send(command); return CreatedAtAction(nameof(CreateTaskItem),new { Messaage = "Successfully created" }); }

  /// <summary>PUT api/{TaskAppController}/5</summary>
  [HttpPut("{id}")]
  public void Put(int id, [FromBody] string value) { }

  /// <summary>DELETE api/{TaskAppController>}/5</summary>
  [HttpDelete("{id}")]
  public void Delete(int id) { }

}
