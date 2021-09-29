using Dead_By_Daylight_Mod_Installer.Presenter;

namespace Dead_By_Daylight_Mod_Installer.View
{
    public interface ISpinnerProgressView
    {
        SpinnerProgressPresenter Presenter { set; }
        string Message { get; set; }

        void Dismiss();
        void Popup();
    }
}
