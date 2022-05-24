// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Bizz.Update.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
using MediatR;
using System;

namespace LogicTier;

/// <remarks/>
public class GetAllTasksQuery : IRequest<List<TaskItem>> { }

/// <remarks/>
public class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksQuery, List<TaskItem>>
{
  private readonly ITaskItemRepository _taskItemRepository;

  /// <remarks/>
  public GetAllTasksQueryHandler(ITaskItemRepository taskItemRepository) { _taskItemRepository = taskItemRepository; }

  /// <remarks/>
  public async Task<List<TaskItem>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken) { return await _taskItemRepository.GetTaskItemsAsync(); }

}
