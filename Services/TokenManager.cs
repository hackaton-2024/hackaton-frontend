using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace sad.Services
{
	public static class TokenManager
	{
		private static string appDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "sad");
		private static string tokenFilePath = Path.Combine(appDataPath, "token.dat");
		private static string refreshTokenFilePath = Path.Combine(appDataPath, "refreshToken.dat");

		static TokenManager()
		{
			if (!Directory.Exists(appDataPath))
			{
				Directory.CreateDirectory(appDataPath);
			}
		}

		public static string GetToken()
		{
			return File.Exists(tokenFilePath) ? File.ReadAllText(tokenFilePath) : null;
		}

		public static void SaveToken(string token)
		{
			File.WriteAllText(tokenFilePath, token);
		}

		public static string GetRefreshToken()
		{
			return File.Exists(refreshTokenFilePath) ? File.ReadAllText(refreshTokenFilePath) : null;
		}

		public static void SaveRefreshToken(string refreshToken)
		{
			File.WriteAllText(refreshTokenFilePath, refreshToken);
		}

		public static void DeleteTokens()
		{
			if (File.Exists(tokenFilePath))
			{
				File.Delete(tokenFilePath);
			}
			if (File.Exists(refreshTokenFilePath))
			{
				File.Delete(refreshTokenFilePath);
			}
		}
	}
}
