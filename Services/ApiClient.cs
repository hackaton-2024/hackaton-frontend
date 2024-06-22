using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace sad.Services
{
	public static class ApiClient
	{
		private static HttpClient client = new HttpClient()
		{
			BaseAddress = new Uri("https://disastersafe.loca.lt/api/")
		};

		public static void SetBearerToken(string token)
		{
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
		}

		public static async Task<HttpResponseMessage> RefreshTokenAsync()
		{
			var refreshToken = TokenManager.GetRefreshToken();
			var refreshContent = new StringContent(JsonConvert.SerializeObject(new { refresh_token = refreshToken }), Encoding.UTF8, "application/json");
			var response = await client.PostAsync("user", refreshContent);

			if (response.IsSuccessStatusCode)
			{
				var newToken = await response.Content.ReadAsStringAsync();
				TokenManager.SaveToken(newToken);
				SetBearerToken(newToken);
			}
			return response;
		}

		public static async Task<HttpResponseMessage> ExecuteRequest(Func<Task<HttpResponseMessage>> requestFunc)
		{
			var response = await requestFunc();
			if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
			{
				var refreshResponse = await RefreshTokenAsync();
				if (refreshResponse.IsSuccessStatusCode)
				{
					response = await requestFunc();
				}
			}
			return response;
		}

		public static async Task<HttpResponseMessage> GetWithAutoRefreshAsync(string requestUri)
		{
			return await ExecuteRequest(() => client.GetAsync(requestUri));
		}

		public static async Task<HttpResponseMessage> PostWithAutoRefreshAsync(HttpContent content)
		{
			return await ExecuteRequest(() => client.PostAsync("login", content));
		}
	}
}

