// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Body.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace WsRepository;

/// <remarks/>
[Serializable]
public class Body
{
  #region Constructors
  /// <summary>Initializes an empty instance of Body</summary>
  public Body() { }

  /// <summary>Initializes a new instance of Body</summary><param name="getDepartment20111201" /><param name="getEmployment20111201" /><param name="getEmploymentChanged20111201" /><param name="getEmploymentChangedAtDate20111201" />
  /// <param name="getInstitution20111201" /><param name="getOrganization20111201" /><param name="getPerson20111201" /><param name="getPersonChangedAtDate20111201" /><param name="getProfession20080201" />
  public Body(GetDepartment20111201 getDepartment20111201, GetEmployment20111201 getEmployment20111201, GetEmploymentChanged20111201 getEmploymentChanged20111201, GetEmploymentChangedAtDate20111201 getEmploymentChangedAtDate20111201, GetInstitution20111201 getInstitution20111201, GetOrganization20111201 getOrganization20111201, GetPerson20111201 getPerson20111201, GetPersonChangedAtDate20111201 getPersonChangedAtDate20111201, GetProfession20080201 getProfession20080201)
  {
      this.GetDepartment20111201=getDepartment20111201;
      this.GetEmployment20111201=getEmployment20111201;
      this.GetEmploymentChanged20111201=getEmploymentChanged20111201;
      this.GetEmploymentChangedAtDate20111201=getEmploymentChangedAtDate20111201;
      this.GetInstitution20111201=getInstitution20111201;
      this.GetOrganization20111201=getOrganization20111201;
      this.GetPerson20111201=getPerson20111201;
      this.GetPersonChangedAtDate20111201=getPersonChangedAtDate20111201;
      this.GetProfession20080201=getProfession20080201;

  }

  /// <summary>Initializes a new instance of Body accepting data from existing Body</summary><param name="body" />
  public Body(Body body)
  {
    this.GetDepartment20111201=body.GetDepartment20111201;
    this.GetEmployment20111201=body.GetEmployment20111201;
    this.GetEmploymentChanged20111201=body.GetEmploymentChanged20111201;
    this.GetEmploymentChangedAtDate20111201=body.GetEmploymentChangedAtDate20111201;
    this.GetInstitution20111201=body.GetInstitution20111201;
    this.GetOrganization20111201=body.GetOrganization20111201;
    this.GetPerson20111201=body.GetPerson20111201;
    this.GetPersonChangedAtDate20111201=body.GetPersonChangedAtDate20111201;
    this.GetProfession20080201=body.GetProfession20080201;
  }

  #endregion

  #region Properties
  /// <remarks/>
  public GetDepartment20111201 GetDepartment20111201 { get; set; } = new();

  /// <remarks/>
  public GetEmployment20111201 GetEmployment20111201 { get; set; } = new();

  /// <remarks/>
  public GetEmploymentChanged20111201 GetEmploymentChanged20111201 { get; set; } = new();

  /// <remarks/>
  public GetEmploymentChangedAtDate20111201 GetEmploymentChangedAtDate20111201 { get; set; } = new();

  /// <remarks/>
  public GetInstitution20111201 GetInstitution20111201 { get; set; } = new();

  /// <remarks/>
  public GetOrganization20111201 GetOrganization20111201 { get; set; } = new();

  /// <remarks/>
  public GetPerson20111201 GetPerson20111201 { get; set; } = new();

  /// <remarks/>
  public GetPersonChangedAtDate20111201 GetPersonChangedAtDate20111201 { get; set; } = new();

  /// <remarks/>
  public GetProfession20080201 GetProfession20080201 { get; set; } = new();

  #endregion

}
