using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using Newtonsoft.Json;
using System.IO;
using sad.Services;
using System.Net;


namespace sad
{
	/// <summary>
	/// Interaction logic for LoginPage.xaml
	/// </summary>
	public partial class LoginPage : UserControl
	{
		public LoginPage()
		{
			InitializeComponent();
		}

		public class LoginRequest
		{
			public string email { get; set;}
            public string password { get; set; }
        }

		//Login Button Logic with API Confiramtion
		private async void ButtonLogin_Click(object sender, RoutedEventArgs e)
		{
			string url = "https://disastersafe.loca.lt/api/login";
			string Email = TextBoxEmail.Text;
			string Password = PasswordBoxLogin.Password; // Using PasswordBox for password input

			if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
			{
				MessageBox.Show("Please enter both email and password!");
				return;
			}

			LoginRequest request = new LoginRequest
			{
				email = Email,
				password = Password
			};

			// Get response from the server with login details
			var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
			var response = await ApiClient.PostWithAutoRefreshAsync(content);

			if (response.IsSuccessStatusCode)
			{
				var result = await response.Content.ReadAsStringAsync();
				dynamic json = JsonConvert.DeserializeObject<dynamic>(result);
				string token = json.accessToken;
				string refreshToken = json.refresh_token;

				TokenManager.SaveToken(token);
				TokenManager.SaveRefreshToken(refreshToken);
				ApiClient.SetBearerToken(token);

				NavigateToHomePage();
			}

			else
			{
				MessageBox.Show("Login failed.");
			}
		}

		private void NavigateToHomePage()
		{
			var parent = this.Parent as ContentControl;
			if (parent != null)
			{
				parent.Content = new HomePage();
			}
		}

		public async Task<string> SendLoginRequestAsync(string url, LoginRequest request)
		{
			try
			{
				using (HttpClient client = new HttpClient())
				{
					var json = JsonConvert.SerializeObject(request);
					var data = new StringContent(json, Encoding.UTF8, "application/json");

					var response = await client.PostAsync(url, data);
					response.EnsureSuccessStatusCode(); // Throw if not a success code.

					string responseBody = await response.Content.ReadAsStringAsync();
					return responseBody;
				}
			}
			catch (HttpRequestException e)
			{
				MessageBox.Show($"Request error: {e.Message}");
				return null;
			}
		}


		//Don't have an account logic forward to RegisterPage
		private void Register_Click(object sender, RoutedEventArgs e) //Forwards the user to the 'Register Page' UserControl - Encho's Work
		{
			var parent = this.Parent as ContentControl;
			if(parent != null)
			{
				parent.Content = new RegisterPage();
			}
		}


	}
}
