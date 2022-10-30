namespace ProjectBook.Services;

public class WebDownloadService
{
    private static HttpClient? _httpClient { get; set; }

    public static HttpClient httpClient
    {
        get
        {
            _httpClient ??= new();
            
            return _httpClient;
        }
    }

    public async Task DownloadFonts()
    {
        if (File.Exists(@$"{Consts.FONTS_FOLDER}\{Consts.FONTS_DOWNLOAD[0]}") && 
            File.Exists(@$"{Consts.FONTS_FOLDER}\{Consts.FONTS_DOWNLOAD[1]}") &&
            File.Exists(@$"{Consts.FONTS_FOLDER}\{Consts.FONTS_DOWNLOAD[2]}"))
            return;

        Directory.CreateDirectory(Consts.FONTS_FOLDER);
        
        foreach (string font in Consts.FONTS_DOWNLOAD)
        {
            HttpResponseMessage response = await httpClient.GetAsync(new Uri(Consts.URI_DOWNLAD_FONTS + font));

            await using FileStream fileStream = new(@$"{Consts.FONTS_FOLDER}\{font}", FileMode.Create);
            await response.Content.CopyToAsync(fileStream);
        }
    }
}