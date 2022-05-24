// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Bizz.Update.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
using FluentValidation;
using MediatR;


namespace LogicTier;

/// <remarks/>
public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
	/// <remarks/>
	public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators) { _validators = validators; }

	/// <remarks/>
	public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next) { if (_validators.Any()) { ValidationContext<TRequest> context = new(request);
		FluentValidation.Results.ValidationResult[] validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));  List<FluentValidation.Results.ValidationFailure> failures = 
			validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList(); if (failures.Count != 0) throw new ValidationException(failures); } return await next(); }

	private readonly IEnumerable<IValidator<TRequest>> _validators;

}
