namespace Lab3_ShabbarKazmi;

public static class MauiProgram
{
    public static IBusinessLogic ibl = new BusinessLogic();
    /*
     * @uthor Shabbar Kazmi 
     * Date 10/8/22
     * Program allows for storage, adding , deleting, edit and sorting of crossword clues. 
     * 
     * The UI might not be 
     */
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        return builder.Build();
    }
}