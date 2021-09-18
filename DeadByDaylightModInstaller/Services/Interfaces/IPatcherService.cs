﻿using Dead_By_Daylight_Mod_Installer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dead_By_Daylight_Mod_Installer.Services.Interfaces
{
    public interface IPatcherService
    {
        Task<bool> FindAndReplaceBytes(string filePath, byte[] originalBytes, byte[] changedBytes);
        byte[] HexToByteArray(string hex);
    }
}
