using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Website.Components;

namespace Website.Shared
{
	public partial class AppBar
	{
		private bool _isLightMode = false;
		private MudTheme _currentTheme = GenerateDarkTheme();
		private DialogOptions _options = new() {CloseOnEscapeKey = true, DisableBackdropClick = true};

		[Parameter] public EventCallback OnSidebarToggled { get; set; }
		[Parameter] public EventCallback<MudTheme> OnThemeToggled { get; set; }

		private async Task ToggleTheme()
		{
			
			_isLightMode = !_isLightMode;

			_currentTheme = !_isLightMode ? GenerateDarkTheme() : new MudTheme();

			await OnThemeToggled.InvokeAsync(_currentTheme);
		}

		public static MudTheme GenerateDarkTheme() =>
			new()
			{
				Palette = new Palette()
				{
					Black = "#27272f",
					Background = "#32333d",
					BackgroundGrey = "#27272f",
					Surface = "#373740",
					TextPrimary = "#ffffffb3",
					TextSecondary = "rgba(255,255,255, 0.50)",
					AppbarBackground = "#27272f",
					AppbarText = "#ffffffb3",
					DrawerBackground = "#27272f",
					DrawerText = "#ffffffb3",
					DrawerIcon = "#ffffffb3"
				}
			};
	}
}