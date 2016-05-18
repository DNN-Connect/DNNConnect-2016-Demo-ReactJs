using System;
using System.IO;
using System.Web.UI.WebControls;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Exceptions;

namespace Connect.DNN.Modules.HitchARide
{
    public partial class Settings : ModuleSettingsBase
    {
        #region Properties
        private Common.ModuleSettings _settings;
        public Common.ModuleSettings ModSettings
        {
            get { return _settings ?? (_settings = Common.ModuleSettings.GetSettings(ModuleContext.Configuration)); }
        }
        #endregion

        #region Base Method Implementations
        public override void LoadSettings()
        {
            try
            {
                if (Page.IsPostBack == false)
                {
                    ddView.Items.Clear();
                    ddView.Items.Add(new ListItem(LocalizeString("Default"), "Index"));
                    System.IO.DirectoryInfo viewDir = new DirectoryInfo(Server.MapPath("~/DesktopModules/MVC/Connect/HitchARide/Views"));
                    foreach (var f in viewDir.GetFiles("*.cshtml"))
                    {
                        string vwName = Path.GetFileNameWithoutExtension(f.Name);
                        if (vwName.ToLower() != "index")
                        {
                            ddView.Items.Add(new ListItem(vwName, vwName));
                        }
                    }
                    try
                    {
                        ddView.Items.FindByValue(ModSettings.View).Selected = true;
                    }
                    catch { }
                }
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        public override void UpdateSettings()
        {
            try
            {
                ModSettings.View = ddView.SelectedValue;
                ModSettings.SaveSettings(ModuleContext.Configuration);
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        #endregion
    }
}