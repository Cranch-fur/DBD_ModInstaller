using Dead_By_Daylight_Mod_Installer.Model;
using Dead_By_Daylight_Mod_Installer.Presenter;
using System.Collections.Generic;

namespace Dead_By_Daylight_Mod_Installer.View
{
    public interface ICreatorView
    {
        CreatorPresenter Presenter { set; }
        List<ModListItem> ModListItems { get; set; }
    }
}
