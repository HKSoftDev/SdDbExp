// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Bizz.Process.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
namespace LogicTier;

/// <remarks/>
public partial class Bizz // Process
{
	#region Methods

	/// <summary>Processes the responce to request</summary>
	public void ProcessResponce() { ProcessContent(); CheckErrors(); }

	/// <summary>Processes content of request</summary>
	private void ProcessContent() { this.Config.ContentProcessed = true; try { Authentication(); switch (this.Config.Api.ToLower()) { case "view3in1organizations": ProcessEntityList<View3in1Organization>(); break;
			case "view3in1organizationstructures": ProcessEntityList<View3in1OrganizationStructure>(); break; case "view3in1persons": ProcessEntityList<View3in1Person>(); break;
			case "viewcontactinformationlist": ProcessEntityList<ViewContactInformation>(); break; case "viewcontroller": ProcessEntityList<ViewControl>(); break; case "viewdepartmentlist": ProcessEntityList<ViewDepartment>(); break;
			case "viewdepartmentlevelreferencelist": ProcessEntityList<ViewDepartmentLevelReference>(); break; case "viewdepartmentreferencelist": ProcessEntityList<ViewDepartmentReference>(); break;
			case "viewemploymentlist": ProcessEntityList<ViewEmployment>(); break; case "viewemploymentprofessionlist": ProcessEntityList<ViewEmploymentProfession>(); break;
			case "viewemploymentstatuslist": ProcessEntityList<ViewEmploymentStatus>(); break; case "viewinstitutionlist": ProcessEntityList<ViewInstitution>(); break; case "viewkantinelist": ProcessEntityList<ViewKantine>(); break;
			case "viewmochs": ProcessEntityList<ViewMoch>(); break; case "vieworganizationlist": ProcessEntityList<ViewOrganization>(); break; case "vieworganizationstructurelist": ProcessEntityList<ViewOrganizationStructure>(); break;
			case "viewpersonlist": ProcessEntityList<ViewPerson>(); break; case "viewpostaladdresslist": ProcessEntityList<ViewPostalAddress>(); break; case "viewprofessionlist": ProcessEntityList<ViewProfession>(); break;
			case "viewsalaryagreementlist": ProcessEntityList<ViewSalaryAgreement>(); break; case "viewsalarycodegrouplist": ProcessEntityList<ViewSalaryCodeGroup>(); break;
			case "viewworkingtimelist": ProcessEntityList<ViewWorkingTime>(); break; default: throw new InvalidRefException(nameof(this.Config.Api),this.Config.Api,nameof(this.Config.Api)+Error.UnkAPI); } }
		catch (ExpressionException eex) { WriteStringLineToLogFile("- An error occurred. Content could not be processed:" + Environment.NewLine + eex.ToErrorString()+Environment.NewLine+Environment.NewLine); this.Config.ContentProcessed=false; }
		catch (Exception ex) { WriteStringLineToLogFile("- An error occurred. Content could not be processed:" + Environment.NewLine + ExpressionException.ToErrorString(ex)+Environment.NewLine+Environment.NewLine); this.Config.ContentProcessed=false; } }

	/// <summary>Proces result from Database</summary>
	private void ProcessEntityList<T>() where T : class { try { List<T> list=this.Config.Api.ToLower() switch { "viewkantinelist" => GetViewKantineList() as List<T>,_ => GetView<T>()}; if (list.Count>=1) {
			this.Config.ResponseString=this.Config.Format.ToLower() switch { "csv" => this.Config.ResponseString=ConvertApiEntityListToCsvString(list), "json" => this.Config.ResponseString=ConvertApiEntityListToJsonString(list),
				"xml" => this.Config.ResponseString=ConvertApiEntityListToXmlString(list), _ => throw new InvalidRefException(nameof(this.Config.Format),this.Config.Format,nameof(this.Config.Format)+Error.UnkParam), }; } }
		catch (ExpressionException eex) { WriteStringLineToLogFile(Environment.NewLine+eex.ToErrorString()+Environment.NewLine+Environment.NewLine); }
		catch (Exception ex) { WriteStringLineToLogFile(Environment.NewLine+ExpressionException.ToErrorString(ex)+Environment.NewLine+Environment.NewLine); } }

	#endregion

}
