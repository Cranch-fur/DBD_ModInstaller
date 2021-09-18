using Dead_By_Daylight_Mod_Installer.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dead_By_Daylight_Mod_Installer.View
{
    public interface ICreatorView
    {
        string PakFileName { get; set; }
        CreatorPresenter Presenter { set; }
        string OriginalFilePath { get; set; }
        string ModifiedFilePath { get; set; }
        string ModTitle { get; set; }
    }
}
