// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Bizz.Update.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
using AutoMapper;

namespace LogicTier;

/// <remarks/>
public class MappingProfile : Profile
{
  /// <remarks/>
  public MappingProfile() { ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly()); }

  private void ApplyMappingsFromAssembly(Assembly assembly) { List<Type> types = assembly.GetExportedTypes().Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() ==
    typeof(IMapFrom<>))).ToList(); List<Type> toTypes = assembly.GetExportedTypes().Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMap<>))).ToList();
    foreach (Type type in types) { object? instance = Activator.CreateInstance(type); MethodInfo? methodInfo = type.GetMethod("Mapping") ?? type.GetInterface("IMapFrom`1")?.GetMethod("Mapping");
      methodInfo?.Invoke(instance, new object[] { this }); } foreach (Type type in toTypes) { object? instance = Activator.CreateInstance(type); MethodInfo? methodInfo = type.GetMethod("Mapping") ??
        type.GetInterface("IMapTo`1")?.GetMethod("Mapping"); methodInfo?.Invoke(instance, new object[] { this }); } }

}
