namespace EM.Services;

public static class DatabasePathFinder
{
    public static string GetPath()
    {
        var databaseName = "mauiapp.db";

        if (DeviceInfo.Platform == DevicePlatform.Android)
        {
            return Path.Combine(FileSystem.AppDataDirectory, databaseName);
        }

        if (DeviceInfo.Platform == DevicePlatform.iOS)
        {
            return Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "..",
                "Library",
                databaseName);
        }

        return databaseName;
    }
}
