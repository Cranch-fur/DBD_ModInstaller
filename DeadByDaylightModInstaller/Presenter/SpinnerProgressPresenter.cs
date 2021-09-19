using Dead_By_Daylight_Mod_Installer.Model;
using Dead_By_Daylight_Mod_Installer.Services.Interfaces;
using Dead_By_Daylight_Mod_Installer.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dead_By_Daylight_Mod_Installer.Presenter
{
    public class SpinnerProgressPresenter
    {
        private readonly ISpinnerProgressView view;
        private Task workTask = Task.CompletedTask;

        public SpinnerProgressPresenter(ISpinnerProgressView view)
        {
            this.view = view;
            this.view.Presenter = this;
        }

        public void SetMessage(string message)
        {
            view.Message = message;
        }

        public void SetWork(Task task)
        {
            workTask = task;
        }

        public async Task AwaitWorkAndDismiss()
        {
            await workTask;
            view.Dismiss();
        }
    }
}
