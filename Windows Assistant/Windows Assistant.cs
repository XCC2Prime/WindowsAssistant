using System.Windows.Forms;
using System.Diagnostics;
using System.Net.Sockets;
using System.Net;
using System;
using Microsoft.Win32;

namespace Windows_Assistant
{
    public partial class WindowsAssistant : Form
    {
        public WindowsAssistant()
        {
            InitializeComponent();
            CheckSettings();
        }

        private string StringLang = "En";
        private void BtnRegAdd_Click(object sender, EventArgs e)
        {
            string Content_BoxReg = BoxReg.Text;

            using (RegistryKey FindOne = RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, RegistryView.Registry64))
            using (RegistryKey FindTwo = FindOne.OpenSubKey($@".{Content_BoxReg}"))
            {
                if (FindTwo != null)
                {
                    using (RegistryKey Key = Registry.ClassesRoot.CreateSubKey($@".{Content_BoxReg}\ShellNew"))
                    {
                        if ((string)Key.GetValue("NullFile") == "1")
                        {
                            if (StringLang == "Ru") { LabelProcess.Text = $"Расширение .{Content_BoxReg} уже добавлено!"; }
                            else { LabelProcess.Text = $"Expansion .{Content_BoxReg} has already been added!"; }
                        }
                        else
                        {
                            Key.SetValue("NullFile", "1");
                            if (StringLang == "Ru") { LabelProcess.Text = $"Расширение .{Content_BoxReg} успешно добавлено!"; }
                            else { LabelProcess.Text = $"Expansion .{Content_BoxReg} successfully added!"; }
                        }
                    }
                }
                else
                {
                    if (StringLang == "Ru") { LabelProcess.Text = $"Расширение .{Content_BoxReg} не найдено!"; }
                    else { LabelProcess.Text = $"Expansion .{Content_BoxReg} not found!"; }
                }
            }

            ReloadExplorer();
        }
        private void BtnRegDelete_Click(object sender, EventArgs e)
        {
            string Content_BoxReg = BoxReg.Text;

            using (RegistryKey FindOne = RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, RegistryView.Registry64))
            using (RegistryKey FindTwo = FindOne.OpenSubKey($@".{Content_BoxReg}"))
            {
                if (FindTwo != null)
                {
                    using (RegistryKey FindKey = FindOne.OpenSubKey($@".{Content_BoxReg}\ShellNew"))
                    {
                        if (FindKey != null)
                        {
                            Registry.ClassesRoot.DeleteSubKey($@".{Content_BoxReg}\ShellNew");
                            if (StringLang == "Ru") { LabelProcess.Text = $"Расширение .{Content_BoxReg} успешно удалено!"; }
                            else { LabelProcess.Text = $"Expansion .{Content_BoxReg} successfully deleted!"; }
                        }
                        else
                        {
                            if (StringLang == "Ru") { LabelProcess.Text = $"Расширение .{Content_BoxReg} уже удалено!"; }
                            else { LabelProcess.Text = $"Expansion .{Content_BoxReg} has already been deleted!"; }
                        }
                    }
                }
                else
                {
                    if (StringLang == "Ru") { LabelProcess.Text = $"Расширение .{Content_BoxReg} не найдено!"; }
                    else { LabelProcess.Text = $"Expansion .{Content_BoxReg} not found!"; }
                }
            }

            ReloadExplorer();
        }

        private void OffUpdates()
        {
            using (RegistryKey KeyOne = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate"))
            {
                KeyOne.SetValue("DoNotConnectToWindowsUpdateInternetLocations", 1, RegistryValueKind.DWord);
                KeyOne.SetValue("UpdateServiceUrlAlternate", "server.wsus");
                KeyOne.SetValue("WUServer", "server.wsus");
                KeyOne.SetValue("WUStatusServer", "server.wsus");
            }

            using (RegistryKey KeyTwo = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU"))
            {
                KeyTwo.SetValue("UseWUServer", 1, RegistryValueKind.DWord);
            }

            CheckUpdates.Enabled = false;
            CheckUpdates.Checked = false;
            BtnUpdates.Enabled = true;
        }
        private void OnUpdates()
        {
            using (RegistryKey KeyOne = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate"))
            {
                KeyOne.DeleteValue("DoNotConnectToWindowsUpdateInternetLocations");
                KeyOne.DeleteValue("UpdateServiceUrlAlternate");
                KeyOne.DeleteValue("WUServer");
                KeyOne.DeleteValue("WUStatusServer");
            }

            using (RegistryKey KeyTwo = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU"))
            {
                KeyTwo.DeleteValue("UseWUServer");
            }

            if (StringLang == "Ru") { LabelProcess.Text = "Обновления Windows успешно включены!"; }
            else { LabelProcess.Text = "Windows updates have been successfully enabled!"; }

            CheckUpdates.Enabled = true;
            BtnUpdates.Enabled = false;
            ReloadExplorer();
        }

        private void AddControlPanel()
        {
            using (RegistryKey KeyOne = Registry.ClassesRoot.CreateSubKey(@"DesktopBackground\Shell\Control"))
            {
                if (StringLang == "Ru") { KeyOne.SetValue("MuiVerb", "Панель управления"); }
                else { KeyOne.SetValue("MuiVerb", "Control Panel"); }
                
                KeyOne.SetValue("Icon", "Control.exe");
                KeyOne.SetValue("Position", "Bottom");
            }

            using (RegistryKey KeyTwo = Registry.ClassesRoot.CreateSubKey(@"DesktopBackground\Shell\Control\Command"))
            {
                KeyTwo.SetValue("", "Control.exe");
            }

            CheckControlPanel.Enabled = false;
            CheckControlPanel.Checked = false;
            BtnControlPanel.Enabled = true;
        }
        private void DelControlPanel()
        {
            using (RegistryKey FindOne = RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, RegistryView.Registry64))
            using (RegistryKey FindTwo = FindOne.OpenSubKey($@"DesktopBackground\Shell\Control"))
            {
                if (FindTwo != null)
                {
                    Registry.ClassesRoot.DeleteSubKeyTree($@"DesktopBackground\Shell\Control");
                    if (StringLang == "Ru") { LabelProcess.Text = "\"Панель управления\" успешно удалена из контекстного меню рабочего стола!"; }
                    else { LabelProcess.Text = "\"Control Panel\" has been successfully removed from the desktop context menu!"; }
                }
                else
                {
                    if (StringLang == "Ru") { LabelProcess.Text = "\"Панель управления\" уже удалена из контекстного меню рабочего стола!"; }
                    else { LabelProcess.Text = "\"Control Panel\" has already been removed from the desktop context menu!"; }
                }
            }

            CheckControlPanel.Enabled = true;
            BtnControlPanel.Enabled = false;
            ReloadExplorer();
        }

        private void AddRegedit()
        {
            using (RegistryKey KeyOne = Registry.ClassesRoot.CreateSubKey(@"DesktopBackground\Shell\Regedit"))
            {
                if (StringLang == "Ru") { KeyOne.SetValue("MuiVerb", "Редактор реестра"); }
                else { KeyOne.SetValue("MuiVerb", "Registry Editor"); }
                
                KeyOne.SetValue("Icon", "Regedit.exe");
                KeyOne.SetValue("Position", "Bottom");
            }

            using (RegistryKey KeyTwo = Registry.ClassesRoot.CreateSubKey(@"DesktopBackground\Shell\Regedit\Command"))
            {
                KeyTwo.SetValue("", "Regedit.exe");
            }

            CheckRegedit.Enabled = false;
            CheckRegedit.Checked = false;
            BtnRegedit.Enabled = true;
        }
        private void DelRegedit()
        {
            using (RegistryKey FindOne = RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, RegistryView.Registry64))
            using (RegistryKey FindTwo = FindOne.OpenSubKey($@"DesktopBackground\Shell\Regedit"))
            {
                if (FindTwo != null)
                {
                    Registry.ClassesRoot.DeleteSubKeyTree($@"DesktopBackground\Shell\Regedit");
                    if (StringLang == "Ru") { LabelProcess.Text = "\"Редактор реестра\" успешно удалён из контекстного меню рабочего стола!"; }
                    else { LabelProcess.Text = "\"Registry Editor\" has been successfully removed from the desktop context menu!"; }
                }
                else
                {
                    if (StringLang == "Ru") { LabelProcess.Text = "\"Редактор реестра\" уже удалён из контекстного меню рабочего стола!"; }
                    else { LabelProcess.Text = "\"Registry Editor\" has already been removed from the desktop context menu!"; }
                }
            }

            CheckRegedit.Enabled = true;
            BtnRegedit.Enabled = false;
            ReloadExplorer();
        }

        private void AddSeconds()
        {
            using (RegistryKey Key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced"))
            {
                Key.SetValue("ShowSecondsInSystemClock", "1", RegistryValueKind.DWord);
            }

            CheckSeconds.Enabled = false;
            CheckSeconds.Checked = false;
            BtnSeconds.Enabled = true;
        }
        private void DelSeconds()
        {
            using (RegistryKey Key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced"))
            {
                Key.DeleteValue("ShowSecondsInSystemClock");
            }

            if (StringLang == "Ru") { LabelProcess.Text = "Отображение секунд в часах панели задач успешно отключено!"; }
            else { LabelProcess.Text = "The display of seconds in the taskbar clock has been successfully disabled!"; }

            CheckSeconds.Enabled = true;
            BtnSeconds.Enabled = false;
            ReloadExplorer();
        }

        private void DelNet()
        {
            try
            {
                using (RegistryKey Key = Registry.ClassesRoot.CreateSubKey(@"CLSID\{F02C1A0D-BE21-4350-88B0-7367FC96EF3C}\ShellFolder"))
                {
                    Key.SetValue("Attributes", -1332477852, RegistryValueKind.DWord);
                }

                CheckNet.Enabled = false;
                CheckNet.Checked = false;
                BtnNet.Enabled = true;
            }
            catch
            {
                if (StringLang == "Ru") { LabelProcess.Text = "Для изменения этого параметра, предоставьте системные права администратору"; }
                else { LabelProcess.Text = "To change this parameter, grant system rights to the administrator"; }
            }
        }
        private void AddNet()
        {
            try
            {
                using (RegistryKey Key = Registry.ClassesRoot.CreateSubKey(@"CLSID\{F02C1A0D-BE21-4350-88B0-7367FC96EF3C}\ShellFolder"))
                {
                    Key.SetValue("Attributes", -1341915036, RegistryValueKind.DWord);
                }

                if (StringLang == "Ru") { LabelProcess.Text = "Отоброжение пункта \"Сеть\" успешно восстановлено в проводнике"; }
                else { LabelProcess.Text = "The display of the \"Network\" item has been successfully restored in explorer"; }

                CheckNet.Enabled = true;
                BtnNet.Enabled = false;
                ReloadExplorer();
            }
            catch
            {
                if (StringLang == "Ru") { LabelProcess.Text = "Для изменения этого параметра, предоставьте системные права администратору"; }
                else { LabelProcess.Text = "To change this parameter, grant system rights to the administrator"; }
            }
        }

        private void BtnEnglish_Click(object sender, EventArgs e)
        {
            StringLang = "En";
            SetEnglishLang();
            CheckUpdatesApp();
        }
        private void SetEnglishLang()
        {
            LabelProcess.Text = "Information about the actions of Windows Assistant will appear here";
            BoxReg.Text = "Enter the file extension without a dot";
            BtnRegAdd.Text = "Add";
            BtnRegDelete.Text = "Delete";

            BtnUpdates.Text = "Recover";
            BtnControlPanel.Text = "Recover";
            BtnRegedit.Text = "Recover";
            BtnSeconds.Text = "Recover";
            BtnNet.Text = "Recover";

            CheckUpdates.Text = "[1] - Disable Windows Updates";
            CheckControlPanel.Text = "[2] - Add the \"Control Panel\" item to the desktop context menu";
            CheckRegedit.Text = "[3] - Add the \"Registry Editor\" item to the desktop context menu";
            CheckSeconds.Text = "[4] - Add the display of seconds in the taskbar clock";
            CheckNet.Text = "[5] - Remove the display of the \"Network\" item in the explorer";
            BtnScheme.Text = "Unlock and activate the power scheme \"Maximum performance\"";

            BtnApply.Text = "Apply";
        }

        private void BtnRussian_Click(object sender, EventArgs e)
        {
            StringLang = "Ru";
            SetRussianLang();
            CheckUpdatesApp();
        }
        private void SetRussianLang()
        {
            LabelProcess.Text = "Здесь будет появляться информация о действиях Windows Assistant";
            BoxReg.Text = "Введите расширение файла без точки";
            BtnRegAdd.Text = "Добавить";
            BtnRegDelete.Text = "Удалить";

            BtnUpdates.Text = "Востановить";
            BtnControlPanel.Text = "Востановить";
            BtnRegedit.Text = "Востановить";
            BtnSeconds.Text = "Востановить";
            BtnNet.Text = "Востановить";

            CheckUpdates.Text = "[1] - Отключить обновления Windows";
            CheckControlPanel.Text = "[2] - Добавить в контекстное меню рабочего стола пункт \"Панель управления\"";
            CheckRegedit.Text = "[3] - Добавить в контекстное меню рабочего стола пункт \"Редактор реестра\"";
            CheckSeconds.Text = "[4] - Добавить отображение секунд в часах панели задач";
            CheckNet.Text = "[5] - Убрать отображение пункта \"Сеть\" в проводнике";
            BtnScheme.Text = "Разблокировать и активировать схему электропитания \"Максимальная производительность\"";

            BtnApply.Text = "Применить";
        }
        
        private void LinkLabelGitHub_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/XCC2Prime/WindowsAssistant");
        }
        
        private void BtnUpdates_Click(object sender, EventArgs e) { OnUpdates(); }
        private void BtnControlPanel_Click(object sender, EventArgs e) { DelControlPanel(); }
        private void BtnRegedit_Click(object sender, EventArgs e) { DelRegedit(); }
        private void BtnSeconds_Click(object sender, EventArgs e) { DelSeconds(); }
        private void BtnNet_Click(object sender, EventArgs e) { AddNet(); }
        private void BtnScheme_Click(object sender, EventArgs e)
        {
            try
            {
                using (RegistryKey KeyOne = Registry.LocalMachine.CreateSubKey(@"SYSTEM\ControlSet001\Control\Power\User\PowerSchemes"))
                {
                    KeyOne.SetValue("ActivePowerScheme", "4485d2b1-e666-4566-9476-db79083e62c3", RegistryValueKind.String);
                }

                using (RegistryKey KeyTwo = Registry.LocalMachine.CreateSubKey(@"SYSTEM\ControlSet001\Control\Power\User\PowerSchemes\4485d2b1-e666-4566-9476-db79083e62c3"))
                {
                    KeyTwo.SetValue("Description", "@%SystemRoot%\\system32\\powrprof.dll,-18,Provides ultimate performance on higher end PCs.", RegistryValueKind.ExpandString);
                    KeyTwo.SetValue("FriendlyName", "@%SystemRoot%\\system32\\powrprof.dll,-19,Ultimate Performance", RegistryValueKind.ExpandString);
                }

                if (StringLang == "Ru") { LabelProcess.Text = "Схема электропитания \"Максимальная производительность\" успешно разблокирована и активирована"; }
                else { LabelProcess.Text = "The power scheme \"Maximum performance\" has been successfully unlocked and activated"; }

                BtnScheme.Enabled = false;
                ReloadExplorer();
            }
            catch
            {
                if (StringLang == "Ru") { LabelProcess.Text = "Для изменения этого параметра, предоставьте системные права администратору"; }
                else { LabelProcess.Text = "To change this parameter, grant system rights to the administrator"; }
            }
        }

        private void CheckSettings()
        {
            using (RegistryKey KeyCheckUpdates = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate"))
            {
                if (Convert.ToInt32(KeyCheckUpdates.GetValue("DoNotConnectToWindowsUpdateInternetLocations")) == 1) { CheckUpdates.Enabled = false; } else { BtnUpdates.Enabled = false; }
            }
            using (RegistryKey KeyCheckControlPanel = Registry.ClassesRoot.CreateSubKey(@"DesktopBackground\Shell\Control"))
            {
                if ((string)KeyCheckControlPanel.GetValue("MuiVerb") == "Панель управления") { CheckControlPanel.Enabled = false; }
                else if ((string)KeyCheckControlPanel.GetValue("MuiVerb") == "Control Panel") { CheckControlPanel.Enabled = false; } else { BtnControlPanel.Enabled = false; }
            }
            using (RegistryKey KeyCheckRegedit = Registry.ClassesRoot.CreateSubKey(@"DesktopBackground\Shell\Regedit"))
            {
                if ((string)KeyCheckRegedit.GetValue("MuiVerb") == "Редактор реестра") { CheckRegedit.Enabled = false; }
                else if ((string)KeyCheckRegedit.GetValue("MuiVerb") == "Registry Editor") { CheckRegedit.Enabled = false; } else { BtnRegedit.Enabled = false; }
            }
            using (RegistryKey KeyCheckSeconds = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced"))
            {
                if (Convert.ToInt32(KeyCheckSeconds.GetValue("ShowSecondsInSystemClock")) == 1) { CheckSeconds.Enabled = false; } else { BtnSeconds.Enabled = false; }
            }

            try
            {
                using (RegistryKey KeyCheckNet = Registry.ClassesRoot.CreateSubKey(@"CLSID\{F02C1A0D-BE21-4350-88B0-7367FC96EF3C}\ShellFolder"))
                {
                    if (Convert.ToString(KeyCheckNet.GetValue("Attributes")) == "-1332477852") { CheckNet.Enabled = false; } else { BtnNet.Enabled = false; }
                }
            }
            catch { BtnNet.Enabled = false; }
            try
            {
                using (RegistryKey KeyCheckScheme = Registry.LocalMachine.CreateSubKey(@"SYSTEM\ControlSet001\Control\Power\User\PowerSchemes"))
                {
                    if ((string)KeyCheckScheme.GetValue("ActivePowerScheme") == "4485d2b1-e666-4566-9476-db79083e62c3") { BtnScheme.Enabled = false; }
                }
            } catch { BtnScheme.Enabled = false; }

            if (StringLang == "Ru") { SetRussianLang(); } else { SetEnglishLang(); }
            CheckUpdatesApp();
        }
        private void CheckUpdatesApp()
        {
            try
            {
                WebClient Client = new WebClient();
                if (Client.DownloadString("https://pastebin.com/mY5HB6dp").Contains("Version 1.0.0.0"))
                {
                    if (StringLang == "Ru") { LabelUpdate.Text = "Вы используете последнию версию Windows Assistant -"; }
                    else { LabelUpdate.Text = "You are using the latest version of Windows Assistant -"; }
                }
                else
                {
                    if (StringLang == "Ru") { LabelUpdate.Text = "Доступно новое обновление Windows Assistant -"; }
                    else { LabelUpdate.Text = "A new Windows Assistant update is available -"; }
                }
            }
            catch
            {
                if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                {
                    if (StringLang == "Ru") { LabelUpdate.Text = "Нет физического подключения к Интернету -"; }
                    else { LabelUpdate.Text = "No physical internet connection -"; }
                }
                else
                {
                    bool Connected = false;
                    using (var TCPClient = new TcpClient())
                    {
                        TCPClient.Connect("209.85.148.138", 443);
                        Connected = TCPClient.Connected;
                    }

                    if (!Connected)
                    {
                        if (StringLang == "Ru") { LabelUpdate.Text = "Нет подключения к Интернету -"; }
                        else { LabelUpdate.Text = "No Internet connection -"; }
                    }
                    else
                    {
                        if (StringLang == "Ru") { LabelUpdate.Text = "Программа больше не поддерживается -"; }
                        else { LabelUpdate.Text = "The program is no longer supported -"; }
                    }
                }
            }
        }
        private void BtnApply_Click(object sender, EventArgs e)
        {
            bool Content_CheckUpdates = CheckUpdates.Checked;
            bool Content_CheckControlPanel = CheckControlPanel.Checked;
            bool Content_CheckRegedit = CheckRegedit.Checked;
            bool Content_CheckSeconds = CheckSeconds.Checked;
            bool Content_CheckNet = CheckNet.Checked;
            string RegProcess;

            if (StringLang == "Ru") { RegProcess = "Действия:"; }
            else { RegProcess = "Actions:"; }

            if (Content_CheckUpdates == true) { OffUpdates(); RegProcess += " [1]"; }
            if (Content_CheckControlPanel == true) { AddControlPanel(); RegProcess += " [2]"; }
            if (Content_CheckRegedit == true) { AddRegedit(); RegProcess += " [3]"; }
            if (Content_CheckSeconds == true) { AddSeconds(); RegProcess += " [4]"; }
            if (Content_CheckNet == true) { DelNet(); RegProcess += " [5]"; }
            if (Content_CheckUpdates == false && Content_CheckControlPanel == false && Content_CheckRegedit == false && Content_CheckSeconds == false && Content_CheckNet == false)
            {
                if (StringLang == "Ru") { RegProcess += " [Ничего]"; }
                else { RegProcess += " [Nothing]"; }
            }

            if (StringLang == "Ru")
            {
                if (LabelProcess.Text != "Для изменения этого параметра, предоставьте системные права администратору" &&
                LabelProcess.Text != "To change this parameter, grant system rights to the administrator") { LabelProcess.Text = RegProcess + " - Прошли успешно!"; }
            }
            else { LabelProcess.Text = RegProcess + " - Were successful!"; }
            ReloadExplorer();
        }

        private void ReloadExplorer()
        {
            Process TargetProcess = Process.GetProcessesByName("Explorer")[0];
            TargetProcess.Kill();
        }
    }
}