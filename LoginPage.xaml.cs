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
			public string Email { get; set;}
            public string Password { get; set; }
        }


		private async void ButtonLogin_Click(object sender, RoutedEventArgs e)
		{
			string url = "https://3fad-149-62-209-202.ngrok-free.app/api/login";
			string email = TextBoxEmail.Text;
			string password = PasswordBoxLogin.Password; // Using PasswordBox for password input

			if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
			{
				MessageBox.Show("Please enter both email and password!");
				return;
			}

			LoginRequest request = new LoginRequest
			{
				Email = email,
				Password = password
			};

			// Get response from the server with login details
			string response = await SendLoginRequestAsync(url, request);

			// Display response in TextBlock
			if (!string.IsNullOrEmpty(response))
			{
				MessageBox.Show("Response from server: " + response);
			}
			else
			{
				MessageBox.Show("Failed to get response from server");
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


		private void Register_Click(object sender, RoutedEventArgs e) //Forwards the user to the 'Register Page' UserControl
		{

		}



	}
}
