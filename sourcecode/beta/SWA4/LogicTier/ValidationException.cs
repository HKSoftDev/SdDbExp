// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Bizz.Update.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
using FluentValidation.Results;

namespace LogicTier;


/// <remarks/>
public class ValidationException : Exception
{
  /// <remarks/>
  public IDictionary<string, string[]> Errors { get; }

  /// <remarks/>
  public ValidationException() : base("One or more validation failures have occurred.") { Errors = new Dictionary<string, string[]>(); }

  /// <remarks/>
  public ValidationException(IEnumerable<ValidationFailure> failures) : this() { Errors = failures.GroupBy(e => e.PropertyName, e => e.ErrorMessage).ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray()); }

}

