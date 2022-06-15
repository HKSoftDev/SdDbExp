// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Config.FieldProps.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
namespace SdAccess;

/// <summary>Interaction logic for MainWindow.xaml</summary>
public partial class MainWindow : Window
{
	#pragma warning disable IDE0044
	#pragma warning disable IDE0051
	#pragma warning disable IDE0060
	#region Fields

	private static Bizz bizz=new();

	#endregion

	#region Constructors
	/// <summary>The Main Window of the SdApi</summary>
	public MainWindow() { this.DataContext = this; InitializeComponent(); }

	#endregion

	#region Properties

	/// <remarks />
	public static List<string> APIs { get; } = new() { "View3in1Organizations","View3in1OrganizationStructures","View3in1Persons","ViewContactInformationList","ViewController","ViewDepartmentList",
		"ViewDepartmentLevelReferenceList","ViewDepartmentReferenceList","ViewEmploymentList","ViewEmploymentProfessionList","ViewEmploymentStatusList","ViewInstitutionList","ViewKantineList","ViewMochs",
		"ViewOrganizationList","ViewOrganizationStructureList","ViewPersonList","ViewPostalAddressList","ViewProfessionList","ViewSalaryAgreementList","ViewSalaryCodeGroupList","ViewWorkingTimeList", };

	/// <remarks />
	public static List<string> Formats { get; } = new() { "CSV", "JSON", "XML" };

	/// <remarks />
	public static List<string> Silos { get; } = new() { "All", "HB", "HI", "HW" };

	/// <remarks />
	public string API { get => bizz.Config.Api; set => bizz.Config.Api = value; }

	/// <remarks />
	public string Format { get => bizz.Config.Format; set => bizz.Config.Format = value; }

	/// <remarks />
	public string PassWord { get => Config.PassWord; }

	/// <remarks />
	public string Roles { get => Config.Roles; }

	/// <remarks />
	public string Silo { get => bizz.Config.Silo; set => bizz.Config.Silo = value; }

	#endregion

	#region Events

	#region Buttons

	///<remarks /><param name="sender" /><param name="e" />
	private void ButtonSend_Click(object sender, RoutedEventArgs e) { if (MessageBox.Show("Vil du sende følgende forespørgsel?\u000AApi: "+bizz.Config.Api+"\u000ASilo: "+bizz.Config.Silo+"\u000AUUID: "+bizz.Config.Uuid.ToString()+
		"\u000AFormat: "+bizz.Config.Format, "Send Forespørgsel til API", MessageBoxButton.OKCancel, MessageBoxImage.Information) == MessageBoxResult.OK) { try { // CollectData();
			bizz.ProcessResponce(); bizz.Config.ResponseSaved=bizz.SaveResponseStringToFile(); }
		catch (ExpressionException eex) {  if (bizz.Config.ResponseSaved) MessageBox.Show("Svar fra server modtaget og gemt som "+bizz.Config.FileName+":"+Environment.NewLine+eex.ToErrorString(),"Send Forespørgsel til Api",MessageBoxButton.OK,
			MessageBoxImage.Information); else if (!bizz.Config.ResponseContainsData) MessageBox.Show("Der blev ikke modtaget svar fra serveren inden time out:"+Environment.NewLine+eex.ToErrorString(),"Send Forespørgsel til Api",
				MessageBoxButton.OK, MessageBoxImage.Error); else MessageBox.Show("Der opstod en fejl:"+Environment.NewLine+eex.ToErrorString(),"Send Forespørgsel til Api",MessageBoxButton.OK,MessageBoxImage.Error); }
		catch (Exception ex) { if (bizz.Config.ResponseSaved) MessageBox.Show("Svar fra server modtaget og gemt som "+bizz.Config.FileName+":"+Environment.NewLine+ExpressionException.ToErrorString(ex),"Send Forespørgsel til Api",
			MessageBoxButton.OK, MessageBoxImage.Information); else if (!bizz.Config.ResponseContainsData) MessageBox.Show("Der blev ikke modtaget svar fra serveren inden time out:"+Environment.NewLine+ExpressionException.ToErrorString(ex),
				"Send Forespørgsel til Api", MessageBoxButton.OK, MessageBoxImage.Error); else MessageBox.Show("Der opstod en fejl:"+Environment.NewLine+ExpressionException.ToErrorString(ex),"Send Forespørgsel til Api",
					MessageBoxButton.OK,MessageBoxImage.Error); } finally { comboBoxApi.SelectedIndex=-1; } } }

	/// <remarks /><param name="sender" /><param name="e" />
	private void ButtonStopServer_Click(object sender, RoutedEventArgs e) { bizz.ShutdownServer(); }

	#endregion

	#region Check Boxes
	///<remarks />
	private void CheckBoxUuid_Checked(object sender, RoutedEventArgs e) => checkBoxUuid.IsChecked=bizz.Config.Uuid=true;

	///<remarks />
	private void CheckBoxUuid_Unchecked(object sender, RoutedEventArgs e) => checkBoxUuid.IsChecked=bizz.Config.Uuid=false;

	#endregion

	#region Combo Boxes

	///<remarks />
	private void ComboBoxApi_SelectionChanged(object sender, SelectionChangedEventArgs e) { if (comboBoxApi.SelectedIndex<0) { ResetGui(); return; } switch (comboBoxApi.SelectedItem.ToString()) {
		case "View3in1Organizations": SetGuiGetSpecial(); break; case "View3in1OrganizationStructures": SetGuiGetSpecial(); break; case "view3in1persons": SetGuiGetSpecial(); break; case "ViewContactInformationList": SetGuiDefault(); break;
		case "ViewController": SetGuiDefault(); break; case "ViewDepartmentLevelReferenceList": SetGuiDefault(); break; case "ViewDepartmentList": SetGuiDefault(); break; case "ViewDepartmentReferenceList": SetGuiDefault(); break;
		case "ViewEmploymentList": SetGuiDefault(); break; case "ViewEmploymentProfessionList": SetGuiDefault(); break; case "ViewEmploymentStatusList": SetGuiDefault(); break; case "ViewInstitutionList": SetGuiDefault(); break;
		case "ViewKantineList": SetGuiDefault(); break; case "ViewMochs": SetGuiGetSpecial(true); break; case "ViewOrganizationList": SetGuiDefault(); break; case "ViewOrganizationStructureList": SetGuiDefault(); break;
		case "ViewPersonList": SetGuiDefault(); break; case "ViewPostalAddressList": SetGuiDefault(); break; case "ViewProfessionList": SetGuiDefault(); break; case "ViewSalaryAgreementList": SetGuiDefault(); break;
		case "ViewSalaryCodeGroupList": SetGuiDefault(); break; case "ViewWorkingTimeList": SetGuiDefault(); break; default: SetGuiDefault(); break; } }

	///<remarks />
	private void ComboBoxFormat_SelectionChanged(object sender, SelectionChangedEventArgs e) { }

	///<remarks />
	private void ComboBoxSilo_SelectionChanged(object sender, SelectionChangedEventArgs e) { }

	#endregion

	#region Radio Buttons

	///<remarks />
	private void RadioButtonActive_Checked(object sender, RoutedEventArgs e) { radioButtonActive.IsChecked=true; radioButtonInactive.IsChecked=false; radioButtonAll.IsChecked=false; bizz.Config.Active="True"; }

	///<remarks />
	private void RadioButtonInactive_Checked(object sender, RoutedEventArgs e) { radioButtonActive.IsChecked=false; radioButtonInactive.IsChecked=true; radioButtonAll.IsChecked=false; bizz.Config.Active="False";}

	///<remarks />
	private void RadioButtonAll_Checked(object sender, RoutedEventArgs e) { radioButtonActive.IsChecked=false; radioButtonInactive.IsChecked=false; radioButtonAll.IsChecked=true; bizz.Config.Active=string.Empty;}

	#endregion

	#region Text Boxes

	///<remarks />
	private void TxtRolesInput_DataContextChanged(object sender,DependencyPropertyChangedEventArgs e) { txtRolesInput.Text=Roles; }

	///<remarks />
	private void TxtPassWordInput_DataContextChanged(object sender,DependencyPropertyChangedEventArgs e) { txtRolesInput.Text=Roles; }

	#endregion

	#endregion

	#region Methods

	/// <summary>Resets MainWindow form for new request</summary>
	private void ResetGui() { comboBoxSilo.SelectedIndex=-1; comboBoxSilo.IsEnabled=false; checkBoxUuid.IsChecked=false; checkBoxUuid.IsEnabled=false; comboBoxFormat.SelectedIndex=-1; comboBoxFormat.IsEnabled=false;
		radioButtonActive.Visibility=Visibility.Hidden; radioButtonActive.IsEnabled=false; radioButtonActive.IsChecked=false; radioButtonInactive.Visibility=Visibility.Hidden; radioButtonInactive.IsEnabled=false;
		radioButtonInactive.IsChecked=false; radioButtonAll.Visibility=Visibility.Hidden; radioButtonAll.IsEnabled=false; radioButtonAll.IsChecked=false; txtPassWord.Visibility=Visibility.Hidden;
		txtPassWordInput.Visibility=Visibility.Hidden; txtPassWordInput.IsEnabled=false; txtPassWordInput.Text=string.Empty; txtRoles.Visibility=Visibility.Hidden; txtRolesInput.Visibility=Visibility.Hidden;
		txtRolesInput.IsEnabled=false; txtRolesInput.Text=string.Empty; txtStatus.Visibility=Visibility.Hidden; bizz.ResetFields(); }

	/// <remarks />
	private void SetGuiDefault() { if (checkBoxUuid==null||comboBoxApi==null||comboBoxFormat==null||comboBoxSilo==null||radioButtonActive==null||radioButtonInactive==null||radioButtonAll==null||
			txtRoles==null|| txtPassWordInput==null||txtPassWord==null||txtPassWordInput==null) return; comboBoxSilo.IsEnabled=true; comboBoxSilo.SelectedIndex=0; comboBoxFormat.IsEnabled=true; comboBoxFormat.SelectedIndex=0;
		txtPassWord.Visibility=Visibility.Hidden; txtPassWordInput.Visibility=Visibility.Hidden; txtPassWordInput.IsEnabled=false; txtPassWordInput.Text=string.Empty; txtRoles.Visibility=Visibility.Hidden;
		txtRolesInput.Visibility=Visibility.Hidden; txtRolesInput.IsEnabled=false; txtRolesInput.Text=string.Empty; checkBoxUuid.IsEnabled=false; checkBoxUuid.IsChecked=false; radioButtonActive.Visibility=Visibility.Hidden;
		radioButtonActive.IsEnabled=false; radioButtonActive.IsChecked=false; radioButtonInactive.Visibility=Visibility.Hidden; radioButtonInactive.IsEnabled=false; radioButtonInactive.IsChecked=false;
		radioButtonAll.Visibility=Visibility.Hidden; radioButtonAll.IsEnabled=false; radioButtonAll.IsChecked=false; txtStatus.Visibility=Visibility.Hidden; }

	/// <remarks /> <param name="moch" />
	private void SetGuiGetSpecial(bool moch=false) { if (checkBoxUuid==null||comboBoxApi==null||comboBoxFormat==null||comboBoxSilo==null||radioButtonActive==null||radioButtonInactive==null||radioButtonAll==null||
			txtRoles==null|| txtPassWordInput==null||txtPassWord==null||txtPassWordInput==null) return; checkBoxUuid.IsEnabled=false; checkBoxUuid.IsChecked=false; comboBoxSilo.IsEnabled=true; comboBoxSilo.SelectedIndex=1;
		comboBoxFormat.IsEnabled=false; comboBoxFormat.SelectedIndex=0; radioButtonActive.Visibility=Visibility.Hidden; radioButtonActive.IsEnabled=false; radioButtonActive.IsChecked=false; 
		radioButtonInactive.Visibility=Visibility.Hidden; radioButtonInactive.IsEnabled=false; radioButtonInactive.IsChecked=false; radioButtonAll.Visibility=Visibility.Hidden; radioButtonAll.IsEnabled=false; 
		radioButtonAll.IsChecked=false;
		if (moch) { txtPassWord.Visibility=Visibility.Visible; txtPassWordInput.Visibility=Visibility.Visible; txtPassWordInput.IsEnabled=false; txtPassWordInput.Text="Haderslev123"; txtRoles.Visibility=Visibility.Visible;
			txtRolesInput.Visibility=Visibility.Visible; txtRolesInput.IsEnabled=false; txtRolesInput.Text="Haderslev"; txtStatus.Visibility=Visibility.Hidden; }
		else { txtPassWord.Visibility=Visibility.Hidden; txtPassWordInput.Visibility=Visibility.Hidden; txtPassWordInput.IsEnabled=false; txtPassWordInput.Text=string.Empty; txtRoles.Visibility=Visibility.Hidden;
			txtRolesInput.Visibility=Visibility.Hidden; txtRolesInput.Text=string.Empty; txtStatus.Visibility=Visibility.Hidden; txtStatus.IsEnabled=false; } }

	#endregion
	#pragma warning restore IDE0044
	#pragma warning restore IDE0051
	#pragma warning restore IDE0060

}
