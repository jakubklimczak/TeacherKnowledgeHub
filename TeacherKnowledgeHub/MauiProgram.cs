using Microsoft.Extensions.Logging;
using TeacherKnowledgeHub.Services;

namespace TeacherKnowledgeHub;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();
        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "teacherknowledgehub.db");
        builder.Services.AddSingleton(new ClassService(dbPath));

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
