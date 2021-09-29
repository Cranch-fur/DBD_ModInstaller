namespace Dead_By_Daylight_Mod_Installer.Services.Interfaces
{
    public interface IMessageBoxService
    {
        bool Question(string message);
        void ShowMessage(string message);
    }
}
