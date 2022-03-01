// Copyright (c) Daniel Giversen. All Rights reserved.
// Copyright (c) Haderslev Kommune. All Rights reserved.
// Licenced under Proprietary License. See License.txt
using SnaBizz;
using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;

namespace SnaTester
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		#region Fields
		private static Bizz bizz = new Bizz();

		#endregion

		#region Constructors
		/// <summary>
		/// The Main Window of the SdApi
		/// </summary>
		public MainWindow()
		{
			InitializeComponent();
		}

		#endregion

		#region Events

		#region Buttons
		///<remarks />
		private void ButtonSend_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				CollectData();

				if (MessageBox.Show("Vil du sende følgende forespørgsel?" + Environment.NewLine + "Api: " + bizz.Api + Environment.NewLine + "Silo: " + bizz.Silo + Environment.NewLine + "UUID: " + bizz.Uuid.ToString() + Environment.NewLine + "Format: " + bizz.Format + Environment.NewLine + "Roles: " + bizz.Roles + Environment.NewLine + "PassWord: " + bizz.PassWord + Environment.NewLine + "Active: " + bizz.Active, "Send Forespørgsel til Api", MessageBoxButton.OKCancel, MessageBoxImage.Information) == MessageBoxResult.OK)
				{
					switch (bizz.Api)
					{
						case "Get3in1Organizations":
							bizz.CreateSpecialApiRequest("3in1");
							break;
						case "Get3in1OrganizationStructures":
							bizz.CreateSpecialApiRequest("3in1");
							break;
						case "Get3in1Persons":
							bizz.CreateSpecialApiRequest("3in1");
							break;
						case "GetDepartments":
							bizz.CreateDefaultApiRequest(true);
							break;
						case "GetEmployments":
							bizz.CreateDefaultApiRequest(true);
							break;
						case "GetMochPersons":
							bizz.CreateSpecialApiRequest("moch");
							break;
						default:
							bizz.CreateDefaultApiRequest();
							break;
					}

					if (bizz.RequestContainsData)
					{
						bizz.Client.Connect();
						bizz.SaveResponse();
					}

				}

			}
			catch (IOException ioex)
			{
				MessageBox.Show("Der opstod en I/O fejl:" + Environment.NewLine + ioex, "Send Forespørgsel til Api", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			catch (NotImplementedException niex)
			{
				MessageBox.Show("Funktionen er endnu ikke implementeret:" + Environment.NewLine + niex, "Send Forespørgsel til Api", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			catch (NotSupportedException nsex)
			{
				MessageBox.Show("Funktionen er ikke supporteret:" + Environment.NewLine + nsex, "Send Forespørgsel til Api", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			catch (OperationCanceledException ocex)
			{
				MessageBox.Show("Det modtagne svar fra serveren var tomt." + Environment.NewLine + "Der kan der være en midlertidig fejl på serveren." + Environment.NewLine + "Prøv igen om 5 minutter:" + Environment.NewLine + ocex, "Send Forespørgsel til Api", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			catch (OutOfMemoryException oomex)
			{
				MessageBox.Show("Der opstod en Out of Memory fejl:" + Environment.NewLine + oomex, "Send Forespørgsel til Api", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			catch (WebException wex)
			{
				MessageBox.Show("Der opstod en Web fejl:" + Environment.NewLine + wex, "Send Forespørgsel til Api", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			catch (Exception ex)
			{
				if (bizz.ResponseSaved)
				{
					MessageBox.Show("Svar fra server modtaget og gemt som " + bizz.FileName + ":" + Environment.NewLine + ex, "Send Forespørgsel til Api", MessageBoxButton.OK, MessageBoxImage.Information);
				}
				else if (!bizz.RequestContainsData)
				{
					MessageBox.Show("Der blev ikke genereret en forespørgsel:" + Environment.NewLine + ex, "Send Forespørgsel til Api", MessageBoxButton.OK, MessageBoxImage.Error);
				}
				else if (!bizz.ResponseContainsData)
				{
					MessageBox.Show("Der blev ikke modtaget svar fra serveren inden time out:" + Environment.NewLine + ex, "Send Forespørgsel til Api", MessageBoxButton.OK, MessageBoxImage.Error);
				}
				else
				{
					MessageBox.Show("Svaret fra serveren kunne ikke gemmes" + ".\u000a" + ex, "Send Forespørgsel til Api", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
			finally
			{
				comboBoxApi.SelectedIndex = -1;
			}

		}

		///<remarks />
		private void ButtonStopServer_Click(object sender, RoutedEventArgs e)
		{
			bizz.ShutdownServer();
		}

		#endregion

		#region Check Boxes
		///<remarks />
		private void CheckBoxUuid_Checked(object sender, RoutedEventArgs e)
		{
			checkBoxUuid.IsChecked = true;
		}

		///<remarks />
		private void CheckBoxUuid_Unchecked(object sender, RoutedEventArgs e)
		{
			checkBoxUuid.IsChecked = false;
		}

		#endregion

		///<remarks />
		private void ComboBoxApi_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (comboBoxApi.SelectedIndex >= 0)
			{
				switch (comboBoxApi.SelectedIndex)
				{
					case 0: //Get3in1Organizations
						SetGuiGetSpecial();
						break;
					case 1: //Get3in1OrganizationStructures
						SetGuiGetSpecial();
						break;
					case 2: //Get3in1Persons
						SetGuiGetSpecial();
						break;
					case 3: //GetDepartments
						SetGuiDefault(true);
						break;
					case 4: //GetEmployments
						SetGuiDefault(true);
						break;
					case 6: //GetMocPersons
						SetGuiGetSpecial(true);
						break;
					default:
						SetGuiDefault();
						break;
				}

			}
			else
			{
				bizz.Api = "";
				ResetGui();
			}
		}

		#region Radio Buttons
		///<remarks />
		private void RadioButtonActive_Checked(object sender, RoutedEventArgs e)
		{
			radioButtonActive.IsChecked = true;
			radioButtonInactive.IsChecked = false;
			radioButtonAll.IsChecked = false;
		}

		///<remarks />
		private void RadioButtonInactive_Checked(object sender, RoutedEventArgs e)
		{
			radioButtonActive.IsChecked = false;
			radioButtonInactive.IsChecked = true;
			radioButtonAll.IsChecked = false;
		}

		///<remarks />
		private void RadioButtonAll_Checked(object sender, RoutedEventArgs e)
		{
			radioButtonActive.IsChecked = false;
			radioButtonInactive.IsChecked = false;
			radioButtonAll.IsChecked = true;
		}

		#endregion

		#endregion

		#region Methods
		/// <summary>
		/// Collects data from <see cref="MainWindow"/> form.
		/// </summary>
		private void CollectData()
		{
			// bizz.Api
			bizz.Api = comboBoxApi.SelectedItem.ToString();

			if (bizz.Api.Contains(@":"))
			{
				bizz.Api = bizz.Api.Remove(0, bizz.Api.IndexOf(@":") + 2);
			}

			// bizz.Silo
			bizz.Silo = comboBoxSilo.SelectedItem.ToString();

			if (bizz.Silo.Contains(@":"))
			{
				bizz.Silo = bizz.Silo.Remove(0, bizz.Silo.IndexOf(@":") + 2);
			}

			// bizz.Uuid
			if (checkBoxUuid.IsChecked.Equals(true))
			{
				bizz.Uuid = true;
			}
			else
			{
				bizz.Uuid = false;
			}

			// bizz.Format
			bizz.Format = comboBoxFormat.SelectedItem.ToString().ToLower();

			if (bizz.Format.Contains(@":"))
			{
				bizz.Format = bizz.Format.Remove(0, bizz.Format.IndexOf(@":") + 2);
			}

			if (string.IsNullOrWhiteSpace(bizz.Format))
			{
				bizz.Format = "csv";
			}

			// bizz.Roles
			if (txtRolesInput.IsEnabled)
			{
				bizz.Roles = txtRolesInput.Text;
			}
			else
			{
				bizz.Roles = string.Empty;
			}

			// bizz.PassWord
			if (txtPassWordInput.IsEnabled)
			{
				bizz.PassWord = txtPassWordInput.Text;
			}
			else
			{
				bizz.PassWord = string.Empty;
			}

			// bizz.Active
			if (radioButtonActive.IsEnabled && radioButtonActive.IsChecked.Equals(true))
			{
				bizz.Active = "True";
			}
			else if (radioButtonInactive.IsEnabled && radioButtonInactive.IsChecked.Equals(true))
			{
				bizz.Active = "False";
			}
			if (radioButtonAll.IsEnabled && radioButtonAll.IsChecked.Equals(true))
			{
				bizz.Active = string.Empty;
			}

		}

		/// <summary>
		/// Resets <see cref="MainWindow"/> for new request.
		/// </summary>
		private void ResetGui()
		{
			comboBoxSilo.SelectedIndex = -1;
			comboBoxSilo.IsEnabled = false;
			checkBoxUuid.IsChecked = false;
			checkBoxUuid.IsEnabled = false;
			comboBoxFormat.SelectedIndex = -1;
			comboBoxFormat.IsEnabled = false;
			radioButtonActive.Visibility = Visibility.Hidden;
			radioButtonActive.IsEnabled = false;
			radioButtonActive.IsChecked = false;
			radioButtonInactive.Visibility = Visibility.Hidden;
			radioButtonInactive.IsEnabled = false;
			radioButtonInactive.IsChecked = false;
			radioButtonAll.Visibility = Visibility.Hidden;
			radioButtonAll.IsEnabled = false;
			radioButtonAll.IsChecked = false;
			txtPassWord.Visibility = Visibility.Hidden;
			txtPassWordInput.Visibility = Visibility.Hidden;
			txtPassWordInput.IsEnabled = false;
			txtPassWordInput.Text = string.Empty;
			txtRoles.Visibility = Visibility.Hidden;
			txtRolesInput.Visibility = Visibility.Hidden;
			txtRolesInput.IsEnabled = false;
			txtRolesInput.Text = string.Empty;
			txtStatus.Visibility = Visibility.Hidden;
			bizz.ResetFields();

		}

		#region Set Gui
		///<remarks />
		private void SetGuiDefault(bool status = false)
		{
			comboBoxSilo.IsEnabled = true;
			comboBoxSilo.SelectedIndex = 0;
			comboBoxFormat.IsEnabled = true;
			comboBoxFormat.SelectedIndex = 0;
			txtPassWord.Visibility = Visibility.Hidden;
			txtPassWordInput.Visibility = Visibility.Hidden;
			txtPassWordInput.IsEnabled = false;
			txtPassWordInput.Text = string.Empty;
			txtRoles.Visibility = Visibility.Hidden;
			txtRolesInput.Visibility = Visibility.Hidden;
			txtRolesInput.IsEnabled = false;
			txtRolesInput.Text = string.Empty;

			if (status)
			{
				checkBoxUuid.IsEnabled = true;
				checkBoxUuid.IsChecked = true;
				radioButtonActive.Visibility = Visibility.Visible;
				radioButtonActive.IsEnabled = true;
				radioButtonActive.IsChecked = true;
				radioButtonInactive.Visibility = Visibility.Visible;
				radioButtonInactive.IsEnabled = true;
				radioButtonInactive.IsChecked = false;
				radioButtonAll.Visibility = Visibility.Visible;
				radioButtonAll.IsEnabled = true;
				radioButtonAll.IsChecked = false;
				txtStatus.Visibility = Visibility.Visible;
			}
			else
			{
				checkBoxUuid.IsEnabled = false;
				checkBoxUuid.IsChecked = false;
				radioButtonActive.Visibility = Visibility.Hidden;
				radioButtonActive.IsEnabled = false;
				radioButtonActive.IsChecked = false;
				radioButtonInactive.Visibility = Visibility.Hidden;
				radioButtonInactive.IsEnabled = false;
				radioButtonInactive.IsChecked = false;
				radioButtonAll.Visibility = Visibility.Hidden;
				radioButtonAll.IsEnabled = false;
				radioButtonAll.IsChecked = false;
				txtStatus.Visibility = Visibility.Hidden;
			}

		}

		///<remarks />
		///<param name="moch"><see cref="bool"/></param>
		private void SetGuiGetSpecial(bool moch = false)
		{
			checkBoxUuid.IsEnabled = false;
			checkBoxUuid.IsChecked = false;
			comboBoxSilo.IsEnabled = true;
			comboBoxSilo.SelectedIndex = 1;
			comboBoxFormat.IsEnabled = false;
			comboBoxFormat.SelectedIndex = 0;
			radioButtonActive.Visibility = Visibility.Hidden;
			radioButtonActive.IsEnabled = false;
			radioButtonActive.IsChecked = false;
			radioButtonInactive.Visibility = Visibility.Hidden;
			radioButtonInactive.IsEnabled = false;
			radioButtonInactive.IsChecked = false;
			radioButtonAll.Visibility = Visibility.Hidden;
			radioButtonAll.IsEnabled = false;
			radioButtonAll.IsChecked = false;

			if (moch)
			{
				txtPassWord.Visibility = Visibility.Visible;
				txtPassWordInput.Visibility = Visibility.Visible;
				txtPassWordInput.IsEnabled = true;
				txtPassWordInput.Text = "Haderslev123";
				txtRoles.Visibility = Visibility.Visible;
				txtRolesInput.Visibility = Visibility.Visible;
				txtRolesInput.IsEnabled = true;
				txtRolesInput.Text = "Haderslev";
				txtStatus.Visibility = Visibility.Hidden;
			}
			else
			{
				txtPassWord.Visibility = Visibility.Hidden;
				txtPassWordInput.Visibility = Visibility.Hidden;
				txtPassWordInput.IsEnabled = false;
				txtPassWordInput.Text = string.Empty;
				txtRoles.Visibility = Visibility.Hidden;
				txtRolesInput.Visibility = Visibility.Hidden;
				txtRolesInput.Text = string.Empty;
				txtStatus.Visibility = Visibility.Hidden;
				txtStatus.IsEnabled = false;
			}

		}

		#endregion

		#endregion

	}
}
