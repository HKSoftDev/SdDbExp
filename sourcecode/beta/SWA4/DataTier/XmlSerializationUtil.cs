// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="XmlSerializationUtil.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace DataTier;

/// <remarks />
public static class XmlSerializationUtil
{
	#region Methods

	/// <returns>Deserialized <paramref name="xml"/> string as T</returns><typeparam name="T" /><param name="xml" /><exception cref="ArgumentEmptyException" />
	public static T Deserialize<T>(string xml) where T : class => Deserialize<T>(XDocument.Parse(xml));

	/// <returns><paramref name="doc"/> deserialized an XDocument</returns><typeparam name="T" /><param name="doc" />
	#pragma warning disable CS8600
	#pragma warning disable CS8602
	#pragma warning disable CS8603
	public static T Deserialize<T>(XDocument doc) where T : class { using XmlReader reader=doc.Root.CreateReader(); XmlSerializer xmlSerializer=new(typeof(T)); T entity=(T)xmlSerializer.Deserialize(reader); return entity; }
	#pragma warning restore CS8600
	#pragma warning restore CS8602
	#pragma warning restore CS8603

	/// <returns><paramref name="value"/> serialized as XDocument</returns><typeparam name="T" /><param name="value" />
	public static XDocument Serialize<T>(T value) where T : class { XmlSerializer xmlSerializer=new(typeof(T)); XDocument doc=new(); using var writer=doc.CreateWriter(); xmlSerializer.Serialize(writer, value); return doc; }

	/// <returns><paramref name="list"/> serialized as XDocument</returns><typeparam name="T" /><param name="list" />
	public static XDocument Serialize<T>(List<T> list) where T : class { XmlSerializer xmlSerializer=new(typeof(T)); XDocument result=new(); using XmlWriter writer=result.CreateWriter(); xmlSerializer.Serialize(writer, list); return result; }

	/// <returns>Content of <paramref name="doc"/> as string</returns><param name="doc" />
	public static string ToStringWithXmlDeclaration(XDocument doc) { StringBuilder builder=new(); using StringWriter writer=new(builder); doc.Save(writer); writer.Flush(); return builder.ToString(); }

	/// <returns>Content of <paramref name="obj"/> as string</returns><param name="obj" />
	public static string ToStringWithJsonDeclaration(JObject obj) { StringBuilder sB=new(); using StringWriter sW=new(sB); using JsonWriter jW=new JsonTextWriter(sW);
		jW.Formatting=Newtonsoft.Json.Formatting.Indented; jW.WriteValue(obj); jW.WriteEnd(); jW.WriteEndObject(); return sB.ToString(); }

	/// <returns><paramref name="doc"/> as XmlDocument</returns><param name="doc" />
	public static XmlDocument XDocumentToXmlDocument(XDocument doc) { XmlDocument xmlDocument=new(); using XmlReader xmlReader=doc.CreateReader(); xmlDocument.Load(xmlReader); return xmlDocument; }

	/// <returns><paramref name="doc"/> as XDocument</returns><param name="doc" />
	#pragma warning disable IDE0059
	public static XDocument XmlDocumentToXDocument(XmlDocument doc) { XDocument result=new(); using var nodeReader=new XmlNodeReader(doc); nodeReader.MoveToContent(); result=XDocument.Load(nodeReader); return result; }
	#pragma warning restore IDE0059

	#endregion

}
