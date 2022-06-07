// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Bizz.Add.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
namespace LogicTier;

/// <remarks />
public partial class Bizz // Add
{
	#region Methods

	/// <returns>Clone of <paramref name="list"/> as List{T}</returns><typeparam name="T" /><param name="list" />
	private List<T> AddEntities<T>(List<T> list) where T : class { List<T> result=new(); Parallel.ForEach(list,item => result.Add((T)CloneEntity<object>(item))); return result; }

	/// <returns>A copy of <paramref name="list"/> as List{Organization}</returns><param name="list" />
	private List<Organization> AddEntities(List<WsOrganization> list) { List<Organization> result=new(); Parallel.ForEach(list,item => result.Add(item.ToOrganization())); return result; }

	/// <returns>A copy of <paramref name="list"/> as List{OrganizationStructure}</returns><param name="list" />
	private List<OrganizationStructure> AddEntities(List<WsOrganizationStructure> list) { List<OrganizationStructure> result=new(); Parallel.ForEach(list,item => result.Add(item.ToOrganizationStructure())); return result; }

	/// <summary>Adds <paramref name="organizationStructure"/> to DepartmentLevelReferences in <paramref name="reference"/></summary><param name="reference" /><param name="organizationStructure" /><returns>Result as bool</returns>
	private bool AddOrganizationStructureToDepartmentLevelReferencesClone(WsDepartmentLevelReference reference,string organizationStructure) {if (reference==null) return false; if (organizationStructure.IsNullOrWhiteSpace()) return false; 
		try { DepartmentLevelReference tempRef=reference.ToDepartmentLevelReference(); tempRef.OrganizationStructure=organizationStructure; tempRef.Validate(); //Level 1
			if (reference.WsDepartmentLevelReferences!=null&&reference.WsDepartmentLevelReferences.Count>=1) { foreach (WsDepartmentLevelReference reference1 in reference.WsDepartmentLevelReferences) {
				DepartmentLevelReference tempRef1=reference1.ToDepartmentLevelReference(); tempRef1.OrganizationStructure=organizationStructure; tempRef1.Validate(); //Level 2
				if (reference1.WsDepartmentLevelReferences!=null&&reference1.WsDepartmentLevelReferences.Count>=1) { foreach (WsDepartmentLevelReference reference2 in reference1.WsDepartmentLevelReferences) {
					DepartmentLevelReference tempRef2=reference2.ToDepartmentLevelReference(); tempRef2.OrganizationStructure=organizationStructure; tempRef2.Validate(); //Level 3
					if (reference2.WsDepartmentLevelReferences!=null&&reference2.WsDepartmentLevelReferences.Count>=1) { foreach (WsDepartmentLevelReference reference3 in reference2.WsDepartmentLevelReferences) {
						DepartmentLevelReference tempRef3=reference3.ToDepartmentLevelReference(); tempRef3.OrganizationStructure=organizationStructure; tempRef3.Validate(); //Level 4
						if (reference3.WsDepartmentLevelReferences!=null&&reference3.WsDepartmentLevelReferences.Count>=1) { foreach (WsDepartmentLevelReference reference4 in reference3.WsDepartmentLevelReferences) {
							DepartmentLevelReference tempRef4=reference4.ToDepartmentLevelReference(); tempRef4.OrganizationStructure=organizationStructure; tempRef4.Validate(); //Level 5
							if (reference4.WsDepartmentLevelReferences!=null&&reference4.WsDepartmentLevelReferences.Count>=1) { foreach (WsDepartmentLevelReference reference5 in reference4.WsDepartmentLevelReferences) {
								DepartmentLevelReference tempRef5=reference5.ToDepartmentLevelReference(); tempRef5.OrganizationStructure=organizationStructure; tempRef5.Validate();
								tempRef4.SeniorDepartmentLevelReference=tempRef5.DepartmentLevelIdentifier; CloneDepartmentLevelReference(ref tempRef5,true); } }
							tempRef3.SeniorDepartmentLevelReference=tempRef4.DepartmentLevelIdentifier; CloneDepartmentLevelReference(ref tempRef4,true);; } }
						tempRef2.SeniorDepartmentLevelReference=tempRef3.DepartmentLevelIdentifier; CloneDepartmentLevelReference(ref tempRef3,true);; } }
					tempRef1.SeniorDepartmentLevelReference=tempRef2.DepartmentLevelIdentifier; CloneDepartmentLevelReference(ref tempRef2,true);; } } 
				tempRef.SeniorDepartmentLevelReference=tempRef1.DepartmentLevelIdentifier; CloneDepartmentLevelReference(ref tempRef1,true);; } }
			UpdateDepartmentLevelReference(ref tempRef,true);; return true; }
		catch (ExpressionException eex) { WriteStringLineToLogFile("- An error occurred, when adding OrganizationStructure to DepartmentLevelReferences:"+Environment.NewLine+eex.ToErrorString()+Environment.NewLine); return false; }
		catch (Exception ex) { WriteStringLineToLogFile("- An error occurred, when adding OrganizationStructure to DepartmentLevelReferences:"+Environment.NewLine+ExpressionException.ToErrorString(ex)+Environment.NewLine); return false; } }

	/// <summary>Adds <paramref name="organizationStructure"/> to DepartmentLevelReferences in <paramref name="reference"/></summary><param name="reference" /><param name="organizationStructure" /><returns>Result as bool</returns>
	private bool AddOrganizationStructureToDepartmentLevelReferencesUpdate(WsDepartmentLevelReference reference,string organizationStructure) {if (reference==null) return false; if (organizationStructure.IsNullOrWhiteSpace()) return false; 
		try { DepartmentLevelReference tempRef=reference.ToDepartmentLevelReference(); tempRef.OrganizationStructure=organizationStructure; tempRef.Validate(); //Level 1
			if (reference.WsDepartmentLevelReferences!=null&&reference.WsDepartmentLevelReferences.Count>=1) { foreach (WsDepartmentLevelReference reference1 in reference.WsDepartmentLevelReferences) {
				DepartmentLevelReference tempRef1=reference1.ToDepartmentLevelReference(); tempRef1.OrganizationStructure=organizationStructure; tempRef1.Validate(); //Level 2
				if (reference1.WsDepartmentLevelReferences!=null&&reference1.WsDepartmentLevelReferences.Count>=1) { foreach (WsDepartmentLevelReference reference2 in reference1.WsDepartmentLevelReferences) {
					DepartmentLevelReference tempRef2=reference2.ToDepartmentLevelReference(); tempRef2.OrganizationStructure=organizationStructure; tempRef2.Validate(); //Level 3
					if (reference2.WsDepartmentLevelReferences!=null&&reference2.WsDepartmentLevelReferences.Count>=1) { foreach (WsDepartmentLevelReference reference3 in reference2.WsDepartmentLevelReferences) {
						DepartmentLevelReference tempRef3=reference3.ToDepartmentLevelReference(); tempRef3.OrganizationStructure=organizationStructure; tempRef3.Validate(); //Level 4
						if (reference3.WsDepartmentLevelReferences!=null&&reference3.WsDepartmentLevelReferences.Count>=1) { foreach (WsDepartmentLevelReference reference4 in reference3.WsDepartmentLevelReferences) {
							DepartmentLevelReference tempRef4=reference4.ToDepartmentLevelReference(); tempRef4.OrganizationStructure=organizationStructure; tempRef4.Validate(); //Level 5
							if (reference4.WsDepartmentLevelReferences!=null&&reference4.WsDepartmentLevelReferences.Count>=1) { foreach (WsDepartmentLevelReference reference5 in reference4.WsDepartmentLevelReferences) {
								DepartmentLevelReference tempRef5=reference5.ToDepartmentLevelReference(); tempRef5.OrganizationStructure=organizationStructure; tempRef5.Validate();
								tempRef4.SeniorDepartmentLevelReference=tempRef5.DepartmentLevelIdentifier; UpdateDepartmentLevelReference(ref tempRef5,true); } }
							tempRef3.SeniorDepartmentLevelReference=tempRef4.DepartmentLevelIdentifier; UpdateDepartmentLevelReference(ref tempRef4,true);; } }
						tempRef2.SeniorDepartmentLevelReference=tempRef3.DepartmentLevelIdentifier; UpdateDepartmentLevelReference(ref tempRef3,true);; } }
					tempRef1.SeniorDepartmentLevelReference=tempRef2.DepartmentLevelIdentifier; UpdateDepartmentLevelReference(ref tempRef2,true);; } } 
				tempRef.SeniorDepartmentLevelReference=tempRef1.DepartmentLevelIdentifier; UpdateDepartmentLevelReference(ref tempRef1,true);; } }
			UpdateDepartmentLevelReference(ref tempRef,true);; return true; }
		catch (ExpressionException eex) { WriteStringLineToLogFile("- An error occurred, when adding OrganizationStructure to DepartmentLevelReferences:"+Environment.NewLine+eex.ToErrorString()+Environment.NewLine); return false; }
		catch (Exception ex) { WriteStringLineToLogFile("- An error occurred, when adding OrganizationStructure to DepartmentLevelReferences:"+Environment.NewLine+ExpressionException.ToErrorString(ex)+Environment.NewLine); return false; } }

	/// <summary>Adds <paramref name="organization"/> to DepartmentReferences in <paramref name="reference"/></summary><param name="reference" /><param name="organization" /><returns>Result as bool</returns>
	private bool AddOrganizationToDepartmentReferencesClone(WsDepartmentReference reference,string organization) { if (reference==null) return false; if (organization.IsNullOrWhiteSpace()) return false;
		try { DepartmentReference tempRef=reference.ToDepartmentReference(); tempRef.Organization=organization; tempRef.Validate(); //Level 1
			if (reference.WsDepartmentReferences.Count>=1) { foreach (WsDepartmentReference reference1 in reference.WsDepartmentReferences) {
				DepartmentReference tempRef1=reference1.ToDepartmentReference(); tempRef1.Organization=organization; tempRef1.Validate(); //Level 2
				if (reference1.WsDepartmentReferences.Count>=1) { foreach (WsDepartmentReference reference2 in reference1.WsDepartmentReferences) {
					DepartmentReference tempRef2=reference2.ToDepartmentReference(); tempRef2.Organization=organization; tempRef2.Validate(); //Level 3
					if (reference2.WsDepartmentReferences.Count>=1) { foreach (WsDepartmentReference reference3 in reference2.WsDepartmentReferences) {
						DepartmentReference tempRef3=reference3.ToDepartmentReference(); tempRef3.Organization=organization; tempRef3.Validate(); //Level 4
						if (reference3.WsDepartmentReferences.Count>=1) { foreach (WsDepartmentReference reference4 in reference3.WsDepartmentReferences) {
							DepartmentReference tempRef4=reference4.ToDepartmentReference(); tempRef4.Organization=organization; tempRef4.Validate(); //Level 5
							if (reference4.WsDepartmentReferences.Count>=1) { foreach (WsDepartmentReference reference5 in reference4.WsDepartmentReferences) {
								DepartmentReference tempRef5=reference5.ToDepartmentReference(); tempRef5.Organization=organization; tempRef5.Validate();
								tempRef4.SeniorDepartmentReference=tempRef5.DepartmentIdentifier; CloneDepartmentReference(ref tempRef5,true); } }
							tempRef3.SeniorDepartmentReference=tempRef4.DepartmentIdentifier; CloneDepartmentReference(ref tempRef4,true); } }
						tempRef2.SeniorDepartmentReference=tempRef3.DepartmentIdentifier; CloneDepartmentReference(ref tempRef3,true); } }
					tempRef1.SeniorDepartmentReference=tempRef2.DepartmentIdentifier; CloneDepartmentReference(ref tempRef2,true); } }
				tempRef.SeniorDepartmentReference=tempRef1.DepartmentIdentifier; CloneDepartmentReference(ref tempRef1,true); } }
			UpdateDepartmentReference(ref tempRef,true); return true; }
		catch (ExpressionException eex) { WriteStringLineToLogFile("- An error occurred, when adding Organization to DepartmentReferences:"+Environment.NewLine+eex.ToErrorString()+Environment.NewLine); return false; }
		catch (Exception ex) { WriteStringLineToLogFile("- An error occurred, when adding Organization to DepartmentReferences:"+Environment.NewLine+ExpressionException.ToErrorString(ex)+Environment.NewLine); return false; } }

	/// <summary>Adds <paramref name="organization"/> to DepartmentReferences in <paramref name="reference"/></summary><param name="reference" /><param name="organization" /><returns>Result as bool</returns>
	private bool AddOrganizationToDepartmentReferencesUpdate(WsDepartmentReference reference,string organization) { if (reference==null) return false; if (organization.IsNullOrWhiteSpace()) return false;
		try { DepartmentReference tempRef=reference.ToDepartmentReference(); tempRef.Organization=organization; tempRef.Validate(); //Level 1
			if (reference.WsDepartmentReferences.Count>=1) { foreach (WsDepartmentReference reference1 in reference.WsDepartmentReferences) {
				DepartmentReference tempRef1=reference1.ToDepartmentReference(); tempRef1.Organization=organization; tempRef1.Validate(); //Level 2
				if (reference1.WsDepartmentReferences.Count>=1) { foreach (WsDepartmentReference reference2 in reference1.WsDepartmentReferences) {
					DepartmentReference tempRef2=reference2.ToDepartmentReference(); tempRef2.Organization=organization; tempRef2.Validate(); //Level 3
					if (reference2.WsDepartmentReferences.Count>=1) { foreach (WsDepartmentReference reference3 in reference2.WsDepartmentReferences) {
						DepartmentReference tempRef3=reference3.ToDepartmentReference(); tempRef3.Organization=organization; tempRef3.Validate(); //Level 4
						if (reference3.WsDepartmentReferences.Count>=1) { foreach (WsDepartmentReference reference4 in reference3.WsDepartmentReferences) {
							DepartmentReference tempRef4=reference4.ToDepartmentReference(); tempRef4.Organization=organization; tempRef4.Validate(); //Level 5
							if (reference4.WsDepartmentReferences.Count>=1) { foreach (WsDepartmentReference reference5 in reference4.WsDepartmentReferences) {
								DepartmentReference tempRef5=reference5.ToDepartmentReference(); tempRef5.Organization=organization; tempRef5.Validate();
								tempRef4.SeniorDepartmentReference=tempRef5.DepartmentUuidIdentifier; UpdateDepartmentReference(ref tempRef5,true); } }
							tempRef3.SeniorDepartmentReference=tempRef4.DepartmentUuidIdentifier; UpdateDepartmentReference(ref tempRef4,true); } }
						tempRef2.SeniorDepartmentReference=tempRef3.DepartmentUuidIdentifier; UpdateDepartmentReference(ref tempRef3,true); } }
					tempRef1.SeniorDepartmentReference=tempRef2.DepartmentUuidIdentifier; UpdateDepartmentReference(ref tempRef2,true); } }
				tempRef.SeniorDepartmentReference=tempRef1.DepartmentUuidIdentifier; UpdateDepartmentReference(ref tempRef1,true); } }
			UpdateDepartmentReference(ref tempRef,true); return true; }
		catch (ExpressionException eex) { WriteStringLineToLogFile("- An error occurred, when adding Organization to DepartmentReferences:"+Environment.NewLine+eex.ToErrorString()+Environment.NewLine); return false; }
		catch (Exception ex) { WriteStringLineToLogFile("- An error occurred, when adding Organization to DepartmentReferences:"+Environment.NewLine+ExpressionException.ToErrorString(ex)+Environment.NewLine); return false; } }

	/// <remarks /><param name="infoDict" /><param name="user" />
	private void AddADUserToList(ref Dictionary<string,ContactInformation> infoDict,ADUser user) { if (infoDict.ContainsKey("HB-"+user.EmployeeNumber)) CheckContactInformation(user,infoDict["HB-"+user.EmployeeNumber]);
		else if (!user.Mail.IsNullOrWhiteSpace()||!user.MobilePhone.IsNullOrWhiteSpace()) { ContactInformation info=new(user.EmployeeNumber,"HB",user.MobilePhone,"00000000",user.Mail,"Empty@Empty.Com");
			UpdateOrCreateInDatabase(info); infoDict.Add("HB-"+info.ParentIdentifier,info); } Garbage.Collect(); }

	#endregion

}
