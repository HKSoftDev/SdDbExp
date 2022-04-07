// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Config.FieldProps.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
namespace SdDbAccess;

/// <summary>An empty window that can be used on its own or navigated to within a Frame.</summary>
public sealed partial class MainWindow : Window
{

	#region Fields

	private static Bizz bizz=new();

	#endregion

	#region Constructors

	/// <summary>The Main Window of SdDbAccess</summary>
	public MainWindow() { InitializeComponent(); ExtendsContentIntoTitleBar = true; SetTitleBar(AppTitleBar); }

	#endregion

	#region Properties

	/// <remarks />
	public static List<string> APIs { get; }=new() { "View3in1Organizations","View3in1OrganizationStructures","View3in1Persons","ViewContactInformationList","ViewController","ViewDepartmentList",
		"ViewDepartmentLevelReferenceList","ViewDepartmentReferenceList","ViewEmploymentList","ViewEmploymentProfessionList","ViewEmploymentStatusList","ViewInstitutionList","ViewKantineList","ViewMochs",
		"ViewOrganizationList","ViewOrganizationStructureList","ViewPersonList","ViewPostalAddressList","ViewProfessionList","ViewSalaryAgreementList","ViewSalaryCodeGroupList","ViewWorkingTimeList", };

	/// <remarks />
	public static List<string> Formats { get; }=new() { "CSV", "JSON", "XML" };

	/// <remarks />
	public static List<string> Silos { get; }=new() { "All", "HB", "HI", "HW" };

	/// <remarks />
	public static string API { get => bizz.Config.Api; set => bizz.Config.Api=value; }

	/// <remarks />
	public static string Format { get => bizz.Config.Format; set => bizz.Config.Format=value; }

	/// <remarks />
	public static string PassWord { get => Config.PassWord; }

	/// <remarks />
	public static string Roles { get => Config.Roles; }

	/// <remarks />
	public static string Silo { get => bizz.Config.Silo; set => bizz.Config.Silo=value; }

	#endregion

	#region Events

	///<remarks />
	private void ButtonSend_Click(object sender, RoutedEventArgs e) { try { bizz.ProcessResponce(); bizz.Config.ResponseSaved=bizz.SaveResponseStringToFile(); }
		catch (ExpressionException eex) { if (bizz.Config.ResponseSaved) DisplayOKDialog("Svar fra server modtaget og gemt som " + bizz.Config.FileName + ":" + Environment.NewLine + eex.ToErrorString(), "Information");
			else if (!bizz.Config.ResponseContainsData) DisplayOKDialog("Der blev ikke modtaget svar fra serveren inden time out:" + Environment.NewLine + eex.ToErrorString(), "Error");
			else DisplayOKDialog("Der opstod en fejl:" + Environment.NewLine + eex.ToErrorString(), "Error"); }
		catch (Exception ex) { if (bizz.Config.ResponseSaved) DisplayOKDialog("Svar fra server modtaget og gemt som " + bizz.Config.FileName + ":" + Environment.NewLine + ExpressionException.ToErrorString(ex), "Information");
			else if (!bizz.Config.ResponseContainsData) DisplayOKDialog("Der blev ikke modtaget svar fra serveren inden time out:" + Environment.NewLine + ExpressionException.ToErrorString(ex),"Error");
			else DisplayOKDialog("Der opstod en fejl:" + Environment.NewLine + ExpressionException.ToErrorString(ex), "Error"); } finally { comboBoxApi.SelectedIndex=-1; } }

	///<remarks />
	private void CheckBoxUuid_Checked(object sender, RoutedEventArgs e) => checkBoxUuid.IsChecked=bizz.Config.Uuid=true;

	///<remarks />
	private void CheckBoxUuid_Unchecked(object sender, RoutedEventArgs e) => checkBoxUuid.IsChecked=bizz.Config.Uuid=false;

	///<remarks />
	private void ComboBoxApi_SelectionChanged(object sender, SelectionChangedEventArgs e) { if (comboBoxApi.SelectedIndex < 0) { ResetGui(); return; } switch (comboBoxApi.SelectedItem.ToString()) {
		case "View3in1Organizations": SetGuiGetSpecial(); break; case "View3in1OrganizationStructures": SetGuiGetSpecial(); break; case "view3in1persons": SetGuiGetSpecial(); break;
		case "ViewContactInformationList": SetGuiDefault(); break; case "ViewController": SetGuiDefault(); break; case "ViewDepartmentLevelReferenceList": SetGuiDefault(); break;
		case "ViewDepartmentList": SetGuiDefault(); break; case "ViewDepartmentReferenceList": SetGuiDefault(); break; case "ViewEmploymentList": SetGuiDefault(); break;
		case "ViewEmploymentProfessionList": SetGuiDefault(); break; case "ViewEmploymentStatusList": SetGuiDefault(); break; case "ViewInstitutionList": SetGuiDefault(); break;
		case "ViewKantineList": SetGuiDefault(); break; case "ViewMochs": SetGuiGetSpecial(true); break; case "ViewOrganizationList": SetGuiDefault(); break;
		case "ViewOrganizationStructureList": SetGuiDefault(); break; case "ViewPersonList": SetGuiDefault(); break; case "ViewPostalAddressList": SetGuiDefault(); break;
		case "ViewProfessionList": SetGuiDefault(); break; case "ViewSalaryAgreementList": SetGuiDefault(); break; case "ViewSalaryCodeGroupList": SetGuiDefault(); break;
		case "ViewWorkingTimeList": SetGuiDefault(); break; default: SetGuiDefault(); break; } }

	///<remarks />
	private void ComboBoxFormat_SelectionChanged(object sender, SelectionChangedEventArgs e) { }

	///<remarks />
	private void ComboBoxSilo_SelectionChanged(object sender, SelectionChangedEventArgs e) { }

	///<remarks />
	private void RadioButtonActive_Checked(object sender, RoutedEventArgs e) { radioButtonActive.IsChecked=true; radioButtonInactive.IsChecked=false; radioButtonAll.IsChecked=false; bizz.Config.Active="True"; }

	///<remarks />
	private void RadioButtonInactive_Checked(object sender, RoutedEventArgs e) { radioButtonActive.IsChecked=false; radioButtonInactive.IsChecked=true; radioButtonAll.IsChecked=false; bizz.Config.Active="False"; }

	///<remarks />
	private void RadioButtonAll_Checked(object sender, RoutedEventArgs e) { radioButtonActive.IsChecked=false; radioButtonInactive.IsChecked=false; radioButtonAll.IsChecked=true; bizz.Config.Active=string.Empty; }

	///<remarks />
	private void TxtRolesInput_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e) { txtRolesInput.Text=Roles; }

	///<remarks />
	private void TxtPassWordInput_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e) { txtRolesInput.Text=Roles; }

	#endregion

	#region Methods

	/// <remarks /><param name="content" /><param name="title" />
	private async void DisplayOKDialog(string content,string title) { ContentDialog dialog=new() { Title=title, Content=content, CloseButtonText="Ok", DefaultButton = ContentDialogButton.Close };
		ContentDialogResult result = await dialog.ShowAsync(); }

	/// <remarks /><param name="content" /><param name="title" />
	private async Task<ContentDialogResult> DisplayOKCancelDialog(string content, string title) { ContentDialog dialog=new() { Title=title, Content=content, PrimaryButtonText="Delete", CloseButtonText="Cancel",
		DefaultButton = ContentDialogButton.Close }; return await dialog.ShowAsync(); }

	/// <summary>Resets MainWindow form for new request</summary>
	private void ResetGui() { comboBoxSilo.SelectedIndex=-1; comboBoxSilo.IsEnabled=false; checkBoxUuid.IsChecked=false; checkBoxUuid.IsEnabled=false; comboBoxFormat.SelectedIndex=-1; comboBoxFormat.IsEnabled=false;
		radioButtonActive.Visibility=Visibility.Collapsed; radioButtonActive.IsEnabled=false; radioButtonActive.IsChecked=false; radioButtonInactive.Visibility=Visibility.Collapsed; radioButtonInactive.IsEnabled=false;
		radioButtonInactive.IsChecked=false; radioButtonAll.Visibility=Visibility.Collapsed; radioButtonAll.IsEnabled=false; radioButtonAll.IsChecked=false; txtPassWord.Visibility=Visibility.Collapsed;
		txtPassWordInput.Visibility=Visibility.Collapsed; txtPassWordInput.IsEnabled=false; txtPassWordInput.Text=string.Empty; txtRoles.Visibility=Visibility.Collapsed; txtRolesInput.Visibility=Visibility.Collapsed;
		txtRolesInput.IsEnabled=false; txtRolesInput.Text=string.Empty; txtStatus.Visibility=Visibility.Collapsed; bizz.ResetFields(); }

	/// <remarks />
	private void SetGuiDefault() { if (checkBoxUuid==null||comboBoxApi==null||comboBoxFormat==null||comboBoxSilo==null||radioButtonActive==null||radioButtonInactive==null||radioButtonAll==null||
			txtRoles==null||txtPassWordInput==null||txtPassWord==null||txtPassWordInput==null) return; comboBoxSilo.IsEnabled=true; comboBoxSilo.SelectedIndex=0; comboBoxFormat.IsEnabled=true; comboBoxFormat.SelectedIndex=0;
		txtPassWord.Visibility=Visibility.Collapsed; txtPassWordInput.Visibility=Visibility.Collapsed; txtPassWordInput.IsEnabled=false; txtPassWordInput.Text=string.Empty; txtRoles.Visibility=Visibility.Collapsed;
		txtRolesInput.Visibility=Visibility.Collapsed; txtRolesInput.IsEnabled=false; txtRolesInput.Text=string.Empty; checkBoxUuid.IsEnabled=false; checkBoxUuid.IsChecked=false; radioButtonActive.Visibility=Visibility.Collapsed;
		radioButtonActive.IsEnabled=false; radioButtonActive.IsChecked=false; radioButtonInactive.Visibility=Visibility.Collapsed; radioButtonInactive.IsEnabled=false; radioButtonInactive.IsChecked=false;
		radioButtonAll.Visibility=Visibility.Collapsed; radioButtonAll.IsEnabled=false; radioButtonAll.IsChecked=false; txtStatus.Visibility=Visibility.Collapsed; }

	/// <remarks /> <param name="moch" />
	private void SetGuiGetSpecial(bool moch=false) { if (checkBoxUuid==null||comboBoxApi==null||comboBoxFormat==null||comboBoxSilo==null||radioButtonActive==null||radioButtonInactive==null||radioButtonAll==null||
			txtRoles==null||txtPassWordInput==null||txtPassWord==null||txtPassWordInput==null) return; checkBoxUuid.IsEnabled=false; checkBoxUuid.IsChecked=false; comboBoxSilo.IsEnabled=true; comboBoxSilo.SelectedIndex=1;
				comboBoxFormat.IsEnabled=false; comboBoxFormat.SelectedIndex=0; radioButtonActive.Visibility=Visibility.Collapsed; radioButtonActive.IsEnabled=false; radioButtonActive.IsChecked=false; radioButtonInactive.Visibility=
					Visibility.Collapsed; radioButtonInactive.IsEnabled=false; radioButtonInactive.IsChecked=false; radioButtonAll.Visibility=Visibility.Collapsed; radioButtonAll.IsEnabled=false; radioButtonAll.IsChecked=false;
		if (moch) { txtPassWord.Visibility=Visibility.Visible; txtPassWordInput.Visibility=Visibility.Visible; txtPassWordInput.IsEnabled=false; txtPassWordInput.Text="Haderslev123";
			txtRoles.Visibility=Visibility.Visible; txtRolesInput.Visibility=Visibility.Visible; txtRolesInput.IsEnabled=false; txtRolesInput.Text="Haderslev"; txtStatus.Visibility=Visibility.Collapsed; }
		else { txtPassWord.Visibility=Visibility.Collapsed; txtPassWordInput.Visibility=Visibility.Collapsed; txtPassWordInput.IsEnabled=false; txtPassWordInput.Text=string.Empty; txtRoles.Visibility=
			Visibility.Collapsed; txtRolesInput.Visibility=Visibility.Collapsed; txtRolesInput.Text=string.Empty; txtStatus.Visibility=Visibility.Collapsed; } }

	#endregion

}
