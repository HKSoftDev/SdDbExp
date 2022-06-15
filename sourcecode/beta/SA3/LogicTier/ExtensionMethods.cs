// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ADExtensionMethods.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
namespace LogicTier;

///<remarks />
public static class ExtensionMethods
{
	#pragma warning disable CA1416
	#pragma warning disable CS8603
	#region Methods

	/// <remarks/>
	public static bool IsNullOrWhiteSpace(this string value) => string.IsNullOrWhiteSpace(value);

	/// <returns>Property value as string</returns><param name="sr">SearchResult</param><param name="propertyName">string</param>
	public static string RetrievePropertyValue(this SearchResult sr, string propertyName) { if (propertyName.IsNullOrWhiteSpace()||!sr.Properties.Contains(propertyName)||sr.Properties[propertyName].Count<1)
			return string.Empty; else return sr.Properties[propertyName][0].ToString(); }

	#endregion
	#pragma warning restore CA1416
	#pragma warning restore CS8603

}

