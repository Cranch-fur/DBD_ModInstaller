using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dead_By_Daylight_Mod_Installer.Services.Interfaces
{
    public interface IMessageBoxService
    {
        bool Question(string message);
        void ShowMessage(string message);
    }
}
