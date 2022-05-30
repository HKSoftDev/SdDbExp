// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="SdViewsController.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
namespace WebApi.Controllers;

[Route("[controller]")][ApiController]
public class View3in1OrganizationsController : ControllerBase
{
  private readonly EFContext _context;

  public View3in1OrganizationsController(EFContext context) { _context = context; }

  /// <summary>GET: Get3in1Organizations</summary><returns>result as Task{string}</returns>
  [HttpGet]
  public async Task<string> Get3in1OrganizationList() => await Bizz.Retrieve3in1Organizations(_context.View3in1Organizations);

}

[Route("[controller]")]
[ApiController]
public class View3in1OrganizationStructuresController : ControllerBase
{
  private readonly EFContext _context;

  public View3in1OrganizationStructuresController(EFContext context) { _context = context; }

  /// <summary>GET: Get3in1OrganizationStructureList</summary><returns>result as Task{string}</returns>
  [HttpGet]
  public async Task<string> Get3in1OrganizationStructureList() => await Bizz.Retrieve3in1OrganizationStructures(_context.View3in1OrganizationStructures);

}

[Route("[controller]")]
[ApiController]
public class View3in1PersonsController : ControllerBase
{
  private readonly EFContext _context;

  public View3in1PersonsController(EFContext context) { _context = context; }

  /// <summary>GET: Get3in1PersonList</summary><returns>result as Task{string}</returns>
  [HttpGet]
  public async Task<string> Get3in1PersonList() => await Bizz.Retrieve3in1Persons(_context.View3in1Persons);

}

[Route("[controller]")][ApiController]
public class ViewContactInformationListController : ControllerBase
{
  private readonly EFContext _context;

  public ViewContactInformationListController(EFContext context) { _context = context; }

  /// <summary>GET: GetContactInformationList</summary><returns>result as Task{string}</returns>
  [HttpGet]
  public async Task<string> GetContactInformationList() => await Bizz.RetrieveContactInformationList(_context.ViewContactInformationList);

}

[Route("[controller]")][ApiController]
public class ViewDepartmentLevelReferenceListController : ControllerBase
{
  private readonly EFContext _context;

  public ViewDepartmentLevelReferenceListController(EFContext context) { _context = context; }

  /// <summary>GET: GetDepartmentLevelReferenceList</summary><returns>result as Task{string}</returns>
  [HttpGet]
  public async Task<string> GetDepartmentLevelReferenceList() => await Bizz.RetrieveDepartmentLevelReferenceList(_context.ViewDepartmentLevelReferenceList);

}

[Route("[controller]")][ApiController]
public class ViewDepartmentListController : ControllerBase
{
  private readonly EFContext _context;

  public ViewDepartmentListController(EFContext context) { _context = context; }

  /// <summary>GET: GetDepartmentList</summary><returns>result as Task{string}</returns>
  [HttpGet]
  public async Task<string> GetDepartmentList() => await Bizz.RetrieveDepartmentList(_context.ViewDepartmentList);

}

[Route("[controller]")][ApiController]
public class ViewDepartmentReferenceListController : ControllerBase
{
  private readonly EFContext _context;

  public ViewDepartmentReferenceListController(EFContext context) { _context = context; }

  /// <summary>GET: GetDepartmentReferenceList</summary><returns>result as Task{string}</returns>
  [HttpGet]
  public async Task<string> GetDepartmentReferenceList() => await Bizz.RetrieveDepartmentReferenceList(_context.ViewDepartmentReferenceList);

}

[Route("[controller]")][ApiController]
public class ViewEmploymentListController : ControllerBase
{
  private readonly EFContext _context;

  public ViewEmploymentListController(EFContext context) { _context = context; }

  /// <summary>GET: GetEmploymentList</summary><returns>result as Task{string}</returns>
  [HttpGet]
  public async Task<string> GetEmploymentList() => await Bizz.RetrieveEmploymentList(_context.ViewEmploymentList);

}

[Route("[controller]")][ApiController]
public class ViewEmploymentProfessionListController : ControllerBase
{
  private readonly EFContext _context;

  public ViewEmploymentProfessionListController(EFContext context) { _context = context; }

  /// <summary>GET: GetEmploymentProfessionList</summary><returns>result as Task{string}</returns>
  [HttpGet]
  public async Task<string> GetEmploymentProfessionList() => await Bizz.RetrieveEmploymentProfessionList(_context.ViewEmploymentProfessionList);

}

[Route("[controller]")][ApiController]
public class ViewEmploymentStatusListController : ControllerBase
{
  private readonly EFContext _context;

  public ViewEmploymentStatusListController(EFContext context) { _context = context; }

  /// <summary>GET: GetEmploymentStatusList</summary><returns>result as Task{string}</returns>
  [HttpGet]
  public async Task<string> GetEmploymentStatusList() => await Bizz.RetrieveEmploymentStatusList(_context.ViewEmploymentStatusList);

}

[Route("[controller]")][ApiController]
public class ViewInstitutionListController : ControllerBase
{
  private readonly EFContext _context;

  public ViewInstitutionListController(EFContext context) { _context = context; }

  /// <summary>GET: GetInstitutionList</summary><returns>result as Task{string}</returns>
  [HttpGet]
  public async Task<string> GetInstitutionList() => await Bizz.RetrieveInstitutionList(_context.ViewInstitutionList);

}

[Route("[controller]")]
[ApiController]
public class ViewKantineListController : ControllerBase
{
  private readonly EFContext _context;

  public ViewKantineListController(EFContext context) { _context = context; }

  /// <summary>GET: GetInstitutionList</summary><returns>result as Task{string}</returns>
  [HttpGet]
  public async Task<string> GetKantineList() => await Bizz.RetrieveKantineList(_context.ViewKantineList);

}

[Route("[controller]")][ApiController]
public class ViewMochsController : ControllerBase
{
  private readonly EFContext _context;

  public ViewMochsController(EFContext context) { _context = context; }

  /// <summary>GET: GetMochList</summary><returns>result as Task{string}</returns>
  [HttpGet]
  public async Task<string> GetMochList() => await Bizz.RetrieveMochs(_context.ViewMochs);

}

[Route("[controller]")][ApiController]
public class ViewOrganizationListController : ControllerBase
{
  private readonly EFContext _context;

  public ViewOrganizationListController(EFContext context) { _context = context; }

  /// <summary>GET: GetOrganizationList</summary><returns>result as Task{string}</returns>
  [HttpGet]
  public async Task<string> GetOrganizationList() => await Bizz.RetrieveOrganizationList(_context.ViewOrganizationList);

}

[Route("[controller]")][ApiController]
public class ViewOrganizationStructureListController : ControllerBase
{
  private readonly EFContext _context;

  public ViewOrganizationStructureListController(EFContext context) { _context = context; }

  /// <summary>GET: GetOrganizationStructureList</summary><returns>result as Task{string}</returns>
  [HttpGet]
  public async Task<string> GetOrganizationStructureList() => await Bizz.RetrieveOrganizationStructureList(_context.ViewOrganizationStructureList);

}

[Route("[controller]")][ApiController]
public class ViewPersonListController : ControllerBase
{
  private readonly EFContext _context;

  public ViewPersonListController(EFContext context) { _context = context; }

  /// <summary>GET: GetPersonList</summary><returns>result as Task{string}</returns>
  [HttpGet]
  public async Task<string> GetPersonList() => await Bizz.RetrievePersonList(_context.ViewPersonList);

}

[Route("[controller]")][ApiController]
public class ViewPostalAddressListController : ControllerBase
{
  private readonly EFContext _context;

  public ViewPostalAddressListController(EFContext context) { _context = context; }

  /// <summary>GET: GetPostalAddressList</summary><returns>result as Task{string}</returns>
  [HttpGet]
  public async Task<string> GetPostalAddressList() => await Bizz.RetrievePostalAddressList(_context.ViewPostalAddressList);

}

[Route("[controller]")][ApiController]
public class ViewProfessionListController : ControllerBase
{
  private readonly EFContext _context;

  public ViewProfessionListController(EFContext context) { _context = context; }

  /// <summary>GET: GetProfessionList</summary><returns>result as Task{string}</returns>
  [HttpGet]
  public async Task<string> GetProfessionList() => await Bizz.RetrieveProfessionList(_context.ViewProfessionList);

}

[Route("[controller]")][ApiController]
public class ViewSalaryAgreementLisController : ControllerBase
{
  private readonly EFContext _context;

  public ViewSalaryAgreementLisController(EFContext context) { _context = context; }

  /// <summary>GET: GetSalaryAgreementList</summary><returns>result as Task{string}</returns>
  [HttpGet]
  public async Task<string> GetSalaryAgreementList() => await Bizz.RetrieveSalaryAgreementList(_context.ViewSalaryAgreementList);

}

[Route("[controller]")][ApiController]
public class ViewSalaryCodeGroupListController : ControllerBase
{
  private readonly EFContext _context;

  public ViewSalaryCodeGroupListController(EFContext context) { _context = context; }

  /// <summary>GET: GetSalaryCodeGroupList</summary><returns>result as Task{string}</returns>
  [HttpGet]
  public async Task<string> GetSalaryCodeGroupList() => await Bizz.RetrieveSalaryCodeGroupList(_context.ViewSalaryCodeGroupList);

}

[Route("[controller]")][ApiController]
public class ViewWorkingTimeListController : ControllerBase
{
  private readonly EFContext _context;

  public ViewWorkingTimeListController(EFContext context) { _context = context; }

  /// <summary>GET: GetWorkingTimeList</summary><returns>result as Task{string}</returns>
  [HttpGet]
  public async Task<string> GetWorkingTimeList() => await Bizz.RetrieveWorkingTimeList(_context.ViewWorkingTimeList);

}

