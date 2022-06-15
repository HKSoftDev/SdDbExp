// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Bizz.Clone.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
namespace LogicTier;

/// <remarks/>
public partial class Bizz // Clone
{

	#pragma warning disable CS8604
	#region Methods

	/// <returns>Clone of <paramref name="obj"/> as T</returns><typeparam name="T" /><param name="obj" />
	public static T CloneEntity<T>(T obj) where T : class { Converter<object, object> _memberwiseClone=(Converter<object, object>)Delegate.CreateDelegate(typeof(Converter<object, object>), typeof(object).GetMethod("MemberwiseClone", BindingFlags.NonPublic | BindingFlags.Instance)); return (T)_memberwiseClone(obj); }

	/// <returns>Clone of <paramref name="list"/></returns><typeparam name="T" /><param name="list" />
	public static List<T> CloneList<T>(List<T> list) where T : class { List<T> result=new(); if (list.Any()) Parallel.ForEach(list,item => result.Add(CloneEntity<T>(item))); return result; }

	#endregion
	#pragma warning restore CS8604

}
