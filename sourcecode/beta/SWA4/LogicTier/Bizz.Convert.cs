// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Bizz.Convert.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
namespace LogicTier;

/// <remarks/>
public partial class Bizz // Convert
{
	#pragma warning disable CS8602
	#region Methods

	/// <returns><paramref name="list"/> as csv string</returns><typeparam name="T" /><param name="list" />
	private static string ConvertApiEntityListToCsvString<T>(List<T> list) where T : class { string result=""; bool headerReady=false; foreach (T obj in list) { if (!headerReady) { switch (typeof(T).Name) {
			case "View3in1Organization": result += View3in1Organization.CsvHeader; break; case "View3in1OrganizationStructure": result += View3in1OrganizationStructure.CsvHeader; break;
			case "View3in1Person": result += View3in1Person.CsvHeader; break; case "ViewContactInformation": result += ViewContactInformation.CsvHeader; break; case "ViewControl": result += ViewControl.CsvHeader; break;
			case "ViewDepartment": result += ViewDepartment.CsvHeader; break; case "ViewDepartmentLevelReference": result += ViewDepartmentLevelReference.CsvHeader; break;
			case "ViewDepartmentReference": result += ViewDepartmentReference.CsvHeader; break; case "ViewEmployment": result += ViewEmployment.CsvHeader; break;
			case "ViewEmploymentProfession": result += ViewEmploymentProfession.CsvHeader; break; case "ViewEmploymentStatus": result += ViewEmploymentStatus.CsvHeader; break;
			case "ViewInstitution": result += ViewInstitution.CsvHeader; break; case "ViewKantine": result += ViewKantine.CsvHeader; break; case "ViewMoch": result += ViewMoch.CsvHeader; break;
			case "ViewOrganization": result += ViewOrganization.CsvHeader; break; case "ViewOrganizationStructure": result += ViewOrganizationStructure.CsvHeader; break;
			case "ViewPerson": result += ViewPerson.CsvHeader; break; case "ViewPostalAddress": result += ViewPostalAddress.CsvHeader; break; case "ViewProfession": result += ViewProfession.CsvHeader; break;
			case "ViewSalaryAgreement": result += ViewSalaryAgreement.CsvHeader; break; case "ViewSalaryCodeGroup": result += ViewSalaryCodeGroup.CsvHeader; break; case "ViewWorkingTime": result += ViewWorkingTime.CsvHeader; break; } headerReady=true; }
		switch (typeof(T).Name) { case "View3in1Organization": result += (obj as View3in1Organization).CsvValue; break;
			case "View3in1OrganizationStructure": result += (obj as View3in1OrganizationStructure).CsvValue; break;
			case "View3in1Person": result += (obj as View3in1Person).CsvValue; break;
			case "ViewContactInformation": result += (obj as ViewContactInformation).CsvValue; break;
			case "ViewControl": result += (obj as ViewControl).CsvValue; break;
			case "ViewDepartment": result += (obj as ViewDepartment).CsvValue; break;
			case "ViewDepartmentLevelReference": result += (obj as ViewDepartmentLevelReference).CsvValue; break;
			case "ViewDepartmentReference": result += (obj as ViewDepartmentReference).CsvValue; break;
			case "ViewEmployment": result += (obj as ViewEmployment).CsvValue; break;
			case "ViewEmploymentProfession": result += (obj as ViewEmploymentProfession).CsvValue; break;
			case "ViewEmploymentStatus": result += (obj as ViewEmploymentStatus).CsvValue; break;
			case "ViewInstitution": result += (obj as ViewInstitution).CsvValue; break;
			case "ViewKantine": result += (obj as ViewKantine).CsvValue; break;
			case "ViewMoch": result += (obj as ViewMoch).ToCsvValue(Config.Roles,Config.PassWord); break;
			case "ViewOrganization": result += (obj as ViewOrganization).CsvValue; break;
			case "ViewOrganizationStructure": result += (obj as ViewOrganizationStructure).CsvValue; break;
			case "ViewPerson": result += (obj as ViewPerson).CsvValue; break;
			case "ViewPostalAddress": result += (obj as ViewPostalAddress).CsvValue; break;
			case "ViewProfession": result += (obj as ViewProfession).CsvValue; break;
			case "ViewSalaryAgreement": result += (obj as ViewSalaryAgreement).CsvValue; break;
			case "ViewSalaryCodeGroup": result += (obj as ViewSalaryCodeGroup).CsvValue; break;
			case "ViewWorkingTime": result += (obj as ViewWorkingTime).CsvValue; break; } } return result; }

	/// <returns><paramref name="list"/> as a json string</returns><typeparam name="T" /><param name="list" />
	private string ConvertApiEntityListToJsonString<T>(List<T> list) where T : class => ConvertXmlStringToJsonString(ConvertApiEntityListToXmlString(list));

	/// <returns><paramref name="list"/> as an xml string</returns><typeparam name="T" /><param name="list" />
	private string ConvertApiEntityListToXmlString<T>(List<T> list) where T : class { string result = "\u003C\u003Fxml version=\u00221\u002E0\u0022 encoding=\u0022utf-16\u0022\u003F\u003E"+Environment.NewLine;
		string type = typeof(T).Name; result+="\u003C"+type+"s\u003E" + Environment.NewLine; foreach (T obj in list) { switch (type) { 
			case "View3in1Organization": result += (obj as View3in1Organization).ToXmlString(); break;
			case "View3in1OrganizationStructure": result += (obj as View3in1OrganizationStructure).XmlString(); break;
			case "View3in1Person": result += (obj as View3in1Person).ToXmlString(); break;
			case "ViewContactInformation": result += (obj as ViewContactInformation).ToXmlString(); break;
			case "ViewControl": result += (obj as ViewControl).ToXmlString(); break;
			case "ViewDepartment": result += (obj as ViewDepartment).ToXmlString(); break;
			case "ViewDepartmentLevelReference": result += (obj as ViewDepartmentLevelReference).ToXmlString(); break;
			case "ViewDepartmentReference": result += (obj as ViewDepartmentReference).ToXmlString(); break;
			case "ViewEmployment": result += (obj as ViewEmployment).ToXmlString(); break;
			case "ViewEmploymentProfession": result += (obj as ViewEmploymentProfession).ToXmlString(); break;
			case "ViewEmploymentStatus": result += (obj as ViewEmploymentStatus).ToXmlString(); break;
			case "ViewInstitution": result += (obj as ViewInstitution).ToXmlString(); break;
			case "ViewKantine": result += (obj as ViewKantine).ToXmlString(); break;
			case "ViewMoch": result += (obj as ViewMoch).ToXmlString(Config.Roles,Config.PassWord); break;
			case "ViewOrganization": result += (obj as ViewOrganization).ToXmlString(); break;
			case "ViewOrganizationStructure": result += (obj as ViewOrganizationStructure).ToXmlString(); break;
			case "ViewPerson": result += (obj as ViewPerson).ToXmlString(); break;
			case "ViewPostalAddress": result += (obj as ViewPostalAddress).ToXmlString(); break; 
			case "ViewProfession": result += (obj as ViewProfession).ToXmlString(); break;
			case "ViewSalaryAgreement": result += (obj as ViewSalaryAgreement).ToXmlString(); break; 
			case "ViewSalaryCodeGroup": result += (obj as ViewSalaryCodeGroup).ToXmlString(); break;
			case "ViewWorkingTime": result += (obj as ViewWorkingTime).ToXmlString(); break; } }
		result += "\u003C\u002F" + type + "s\u003E" + Environment.NewLine; return result; }

	/// <returns><paramref name="xml"/> as json string</returns><param name="xml" />
	private string ConvertXmlStringToJsonString(string xml) { XmlDocument doc=new(); doc.LoadXml(xml); return JsonConvert.SerializeXmlNode(doc); }

	#endregion
	#pragma warning restore CS8602

}
