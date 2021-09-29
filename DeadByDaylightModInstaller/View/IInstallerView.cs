using Dead_By_Daylight_Mod_Installer.Presenter;

namespace Dead_By_Daylight_Mod_Installer.View
{
    public interface IInstallerView
    {
        string PaksPath { get; set; }
        InstallerPresenter Presenter { set; }
    }
}
