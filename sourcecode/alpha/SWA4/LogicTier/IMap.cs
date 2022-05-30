// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Bizz.Update.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
using AutoMapper;

namespace LogicTier;

/// <remarks/>
public interface IMapFrom<T>
{
  /// <remarks/>
  void Mapping(Profile profile) { profile.CreateMap(typeof(T), GetType()); }

}

/// <remarks/>
public interface IMap<T>
{
  /// <remarks/>
  void Mapping(Profile profile) { profile.CreateMap(GetType(), typeof(T)); }

}
