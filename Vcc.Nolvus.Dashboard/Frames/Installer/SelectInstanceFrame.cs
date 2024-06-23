﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using Vcc.Nolvus.Api.Installer.Services;
using Vcc.Nolvus.Api.Installer.Library;
using Vcc.Nolvus.Core.Interfaces;
using Vcc.Nolvus.Core.Frames;
using Vcc.Nolvus.Core.Enums;
using Vcc.Nolvus.Core.Services;
using Vcc.Nolvus.Instance.Core;
using Vcc.Nolvus.Dashboard.Core;
using Vcc.Nolvus.Dashboard.Forms;
using Vcc.Nolvus.Dashboard.Frames.Instance;
using System.Threading.Tasks;

namespace Vcc.Nolvus.Dashboard.Frames.Installer
{
    public partial class SelectInstanceFrame : DashboardFrame
    {        
        public SelectInstanceFrame()
        {
            InitializeComponent();
        }

        public SelectInstanceFrame(IDashboard Dashboard, FrameParameters Params)
            :base(Dashboard, Params)
        {
            InitializeComponent();
        }

        private int InstanceIndex(IEnumerable<INolvusVersionDTO> Versions)
        {           
            INolvusInstance Instance = ServiceSingleton.Instances.WorkingInstance;

            if (Instance != null)
            {
                var Index = Versions.ToList().FindIndex(x => x.Name == Instance.Name);

                return Index == -1 ? Versions.ToList().Count - 1 : Index;
            }

            return Versions.ToList().Count - 1;
        }

        private int ResolutionIndex(List<string> Resolutions)
        {            
            INolvusInstance WorkingInstance = ServiceSingleton.Instances.WorkingInstance;
           
            var Index = Resolutions.FindIndex(x => x == WorkingInstance.Settings.Width + "x" + WorkingInstance.Settings.Height);

            return Index == -1 ? 0 : Index;            
        }

        private int RatioIndex(List<string> Ratios)
        {            
            var Index = Ratios.FindIndex(x => x == ServiceSingleton.Instances.WorkingInstance.Settings.Ratio);

            return Index == -1 ? 0 : Index;            
        }

        private int LgIndex(List<LgCode> Lgs)
        {            
            var Index = Lgs.FindIndex(x => x.Code == ServiceSingleton.Instances.WorkingInstance.Settings.LgCode);

            return Index == -1 ? 0 : Index;                          
        }

        protected override async Task OnLoadAsync()
        {
            try
            {
                ServiceSingleton.Dashboard.Title("Nolvus Dashboard - [Instance Auto Installer]");
                ServiceSingleton.Dashboard.Info("Instance Prerequisites");

                BtnCancel.Visible = !Parameters.IsEmpty && Parameters["Cancel"] != null;

                var Versions = await ApiManager.Service.Installer.GetNolvusVersions();

                DrpDwnLstGuides.DataSource = Versions;
                DrpDwnLstGuides.DisplayMember = "Name";
                DrpDwnLstGuides.ValueMember = "Id";

                DrpDwnLstGuides.SelectedIndex = InstanceIndex(Versions);
                DrpDwnLstScreenRes.DataSource = ServiceSingleton.Globals.WindowsResolutions;

                DrpDwnLstScreenRes.SelectedIndex = ResolutionIndex(ServiceSingleton.Globals.WindowsResolutions);

                List<string> Ratios = new List<string>();

                Ratios.Add("16:9");
                Ratios.Add("21:9");

                DrpDwnLstRatios.DataSource = Ratios;

                DrpDwnLstRatios.SelectedIndex = RatioIndex(Ratios);

                List<LgCode> LgList = new List<LgCode>();

                LgCode Lg1 = new LgCode { Code = "EN", Name = "English" };
                LgCode Lg2 = new LgCode { Code = "FR", Name = "French" };
                LgCode Lg3 = new LgCode { Code = "IT", Name = "Italian" };
                LgCode Lg4 = new LgCode { Code = "DE", Name = "German" };
                LgCode Lg5 = new LgCode { Code = "ES", Name = "Spanish" };
                LgCode Lg6 = new LgCode { Code = "RU", Name = "Russian" };
                LgCode Lg7 = new LgCode { Code = "PL", Name = "Polish" };

                LgList.Add(Lg1);
                LgList.Add(Lg2);
                LgList.Add(Lg3);
                LgList.Add(Lg4);
                LgList.Add(Lg5);
                LgList.Add(Lg6);
                LgList.Add(Lg7);

                DrpDwnLg.DataSource = LgList;
                DrpDwnLg.DisplayMember = "Name";
                DrpDwnLg.ValueMember = "Code";

                DrpDwnLg.SelectedIndex = LgIndex(LgList);
            }
            catch (Exception ex)
            {
                await ServiceSingleton.Dashboard.Error("Error during instance selection loading", ex.Message, ex.StackTrace);
            }
        }                                

        private void BtnContinue_Click(object sender, EventArgs e)
        {
            INolvusVersionDTO InstanceToInstall = DrpDwnLstGuides.SelectedItem as INolvusVersionDTO;

            if (ServiceSingleton.Instances.InstanceExists(InstanceToInstall.Name))
            {
                NolvusMessageBox.ShowMessage("Invalid Instance", "The nolvus instance " + InstanceToInstall.Name + " is already installed!", MessageBoxType.Error);
            }
            else
            {
                INolvusInstance WorkingInstance = ServiceSingleton.Instances.WorkingInstance;

                WorkingInstance.Settings.Ratio = DrpDwnLstRatios.SelectedValue.ToString();

                string Resolution = DrpDwnLstScreenRes.SelectedValue.ToString();

                string[] Reso = Resolution.Split(new char[] { 'x' });

                WorkingInstance.Settings.Width = Reso[0];                
                WorkingInstance.Settings.Height = Reso[1];                

                WorkingInstance.Settings.LgCode = (DrpDwnLg.SelectedItem as LgCode).Code;
                WorkingInstance.Settings.LgName = (DrpDwnLg.SelectedItem as LgCode).Name;

                ServiceSingleton.Dashboard.LoadFrame<PathFrame>();
            }                                     
        }

        private int GetTotalStorage(INolvusVersionDTO NolvusVersion)
        {
            int Mods = System.Convert.ToInt32(NolvusVersion.ModsStorageSpace);
            int Archives = System.Convert.ToInt32(NolvusVersion.ArchiveStorageSpace);

            return Mods + Archives;                 
        }

        private void DrpDwnLstGuides_SelectedIndexChanged(object sender, EventArgs e)
        {
            INolvusVersionDTO NolvusVersion = DrpDwnLstGuides.SelectedItem as INolvusVersionDTO;

            if (ServiceSingleton.Instances.WorkingInstance == null || ServiceSingleton.Instances.WorkingInstance.Name != NolvusVersion.Name)
            {                                                
                ServiceSingleton.Instances.WorkingInstance = new NolvusInstance(NolvusVersion);

                ServiceSingleton.Instances.WorkingInstance.Settings.Height = Screen.PrimaryScreen.Bounds.Height.ToString();
                ServiceSingleton.Instances.WorkingInstance.Settings.Width = Screen.PrimaryScreen.Bounds.Width.ToString();
            }
            
            LblCPU.Text = "Minimum : " + NolvusVersion.MinCPU + ", Recommended : " + NolvusVersion.MaxCPU;
            LblGPU.Text = "Minimum : " + NolvusVersion.MinGPU + ", Recommended : " + NolvusVersion.MaxGPU;
            LblRAM.Text = "Minimum : " + NolvusVersion.MinRAM + ", Recommended : " + NolvusVersion.MaxRAM;
            LblVRAM.Text = "Minimum : " + NolvusVersion.MinVRAM + ", Recommended : " + NolvusVersion.MaxVRAM;
            LblStorage.Text = "Mods : " + NolvusVersion.ModsStorageSpace + " Gb, Archive : " + NolvusVersion.ArchiveStorageSpace + " Gb, Total : " + GetTotalStorage(NolvusVersion) + " Gb";

            LblDesc.Text = NolvusVersion.Description;
            
            switch (NolvusVersion.Code)
            {               
                case "ASC":
                    LblGPU.Text = "Depends of the selected options";
                    LblVRAM.Text = "Depends of the selected options";
                    LblStorage.Text = "Depends of the selected options";
                    PicBox.Image = Properties.Resources.Nolvus_V5;
                    break;              
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            ServiceSingleton.Dashboard.LoadFrame<InstancesFrame>();
        }
    }
}
