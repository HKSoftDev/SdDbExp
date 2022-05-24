// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Bizz.Update.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
using AutoMapper;
using FluentValidation;
using MediatR;

namespace LogicTier;

/// <remarks/>
public class CreateTaskCommand : IRequest<int>, IMap<TaskItem>
{
  /// <remarks/>
  public string? Email { get; set; }

  /// <remarks/>
  public string? Name { get; set; }

  /// <remarks/>
  public DateTimeOffset DueDate { get; set; }

  /// <remarks/>
  public int Priority { get; set; }

  /// <remarks/>
  public bool IsCompleted { get; set; }

}


/// <remarks/>
public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, int>
{
  private readonly ITaskItemRepository _taskItemRepositoty;
  private readonly IMapper _mapper;

  /// <remarks/>
  public CreateTaskCommandHandler(ITaskItemRepository taskItemRepositoty,IMapper mapper) { _taskItemRepositoty = taskItemRepositoty; _mapper = mapper; }

  /// <remarks/>
  public async Task<int> Handle(CreateTaskCommand request, CancellationToken cancellationToken) { try { await _taskItemRepositoty.InsertTaskAsync(_mapper.Map<TaskItem>(request)); return 1; }
    catch (Exception ex) { Console.Error.WriteLine(ex.Message); throw; } }

}

/// <remarks/>
public class CreateTaskCommandValidatior : AbstractValidator<CreateTaskCommand>
{
  /// <remarks/>
  public CreateTaskCommandValidatior() {
    RuleFor(v => v.Email).NotEmpty().WithMessage("Email is required.").EmailAddress().WithMessage("This is not a valid email address.").MaximumLength(200).WithMessage("Title must not exceed 200 characters.");
    RuleFor(v => v.Name).NotEmpty().WithMessage("Name is required.").MaximumLength(200).WithMessage("Title must not exceed 200 characters.");
    RuleFor(v => v.IsCompleted).Must(v => v == false).WithMessage("IsCompleted should be false."); }

}