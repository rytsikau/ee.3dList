using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ee3dList
{
    public partial class Form1 : Form
    {
        Encoding fileEncodingLeft;
        Encoding fileEncodingRight;
        Encoding fileEncodingResult;
        string filePathLeft;
        string filePathRight;
        string filePathResult;
        List<string> collectionLeft;
        List<string> collectionRight;
        List<string> collectionResult;

        public Form1()
        {
            InitializeComponent();

            // Tooltips for some elements.
            ToolTip tooltip = new ToolTip();
            tooltip.SetToolTip(comboBoxSaveFileName,
                "Choose filename of result.\n" +
                "Valid tags: [date], [time], [leftname], [rightname]");

            // Fill in with source data the read-only comboboxes.
            comboBoxEncodingLeft.DisplayMember = "DisplayName";
            comboBoxEncodingLeft.DataSource = Encoding.GetEncodings().OrderBy(o => o.DisplayName).ToList();
            comboBoxEncodingRight.DisplayMember = "DisplayName";
            comboBoxEncodingRight.DataSource = Encoding.GetEncodings().OrderBy(o => o.DisplayName).ToList();
            comboBoxEncodingResult.DisplayMember = "DisplayName";
            comboBoxEncodingResult.DataSource = Encoding.GetEncodings().OrderBy(o => o.DisplayName).ToList();
            comboBoxSortResult.Items.AddRange(new object[] {
                "[existing - Left, then Right]",
                "[existing - Right, then Left]",
                "[ascending]", "[descending]",
                "[random]" });

            // "Markability" of menu items.
            menuSettings_AutoModeIfSavedSettingsAreCorrect.CheckOnClick = true;
            menuSettings_AutoOpeningResult.CheckOnClick = true;

            // Form menu handlers.
            menuFile_Exit.Click += new EventHandler(MenuItemFile_Exit_Click);
            menuSettings_Save.Click += new EventHandler(MenuItemSettings_Save_Click);
            menuSettings_LoadSaved.Click += new EventHandler(MenuItemSettings_LoadSaved_Click);
            menuSettings_Reset.Click += new EventHandler(MenuItemSettings_Reset_Click);
            menuHelp_About.Click += new EventHandler(MenuItemHelp_About_Click);

            // Form window handlers.
            buttonOpenLeft.Click += new EventHandler(ButtonOpenLeft_Click);
            buttonOpenRight.Click += new EventHandler(ButtonOpenRight_Click);
            buttonChooseSaveFolder.Click += new EventHandler(ButtonChooseSaveFolder_Click);
            buttonStart.Click += new EventHandler(ButtonStart_Click);
            buttonOpenResult.Click += new EventHandler(ButtonOpenResult_Click);
            buttonReset.Click += new EventHandler(ButtonReset_Click);

            checkBoxIncludeNonUnique.CheckStateChanged += new EventHandler(CheckBoxIncludeNonUnique_CheckStateChanged);

            comboBoxEncodingLeft.SelectedIndexChanged += new EventHandler(ComboBoxEncodingLeft_SelectedIndexChanged);
            comboBoxEncodingRight.SelectedIndexChanged += new EventHandler(ComboBoxEncodingRight_SelectedIndexChanged);
            comboBoxSaveFolder.Leave += new EventHandler(ComboBoxSaveFolder_Leave);
            comboBoxSaveFileName.Leave += new EventHandler(ComboBoxSaveFileName_Leave);

            textBoxLeft.DragEnter += new DragEventHandler(TextBoxLeft_DragEnter);
            textBoxLeft.DragDrop += new DragEventHandler(TextBoxLeft_DragDrop);
            textBoxLeft.Enter += new EventHandler(TextBoxLeft_Enter);
            textBoxLeft.Leave += new EventHandler(TextBoxLeft_Leave);
            textBoxLeft.ModifiedChanged += new EventHandler(TextBoxLeft_ModifiedChanged);

            textBoxRight.DragEnter += new DragEventHandler(TextBoxRight_DragEnter);
            textBoxRight.DragDrop += new DragEventHandler(TextBoxRight_DragDrop);
            textBoxRight.Enter += new EventHandler(TextBoxRight_Enter);
            textBoxRight.Leave += new EventHandler(TextBoxRight_Leave);
            textBoxRight.ModifiedChanged += new EventHandler(TextBoxRight_ModifiedChanged);

            // Exit application handler.
            Application.ApplicationExit += new EventHandler(ApplicationExit);

            // Launch choosing mode (auto or normal).
            LaunchMode();
        }



        // --------------------------------------
        // Launch choosing mode (auto or normal).
        void LaunchMode()
        {
            if (File.Exists(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile)) SettingsRead();
            else { SettingsReset(); return; }

            if (!menuSettings_AutoModeIfSavedSettingsAreCorrect.Checked)
            {
                SettingsReset();
                return;
            }
            else if (SettingsPrepare() == "success")
            {
                StartProcessing();
                Close();
            }
            else if (SettingsPrepare() != "success")
            {
                try
                {
                    var config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);

                    config.AppSettings.Settings.Remove("menuSettings_AutoModeIfSavedSettingsAreCorrect.Checked");
                    config.AppSettings.Settings.Add("menuSettings_AutoModeIfSavedSettingsAreCorrect.Checked",
                        false.ToString());

                    config.Save(ConfigurationSaveMode.Full);

                    menuSettings_AutoModeIfSavedSettingsAreCorrect.Checked = false;
                    SettingsReset();
                }
                catch (Exception) { }
            }

        }



        // --------------------------------------
        // Reset app settings.
        string SettingsReset()
        {
            // Form menu settings.
            // (no need to reset)

            // Form window settings.
            checkBoxSubsetLeft.Checked = true;
            checkBoxSubsetCommon.Checked = true;
            checkBoxSubsetRight.Checked = true;
            checkBoxIncludeUnique.Checked = true;
            checkBoxIncludeNonUnique.Checked = true;
            checkBoxKeepDuplicates.Checked = true;
            checkBoxOverwrite.Checked = false;

            comboBoxEncodingLeft.SelectedIndexChanged -= ComboBoxEncodingLeft_SelectedIndexChanged;
            comboBoxEncodingLeft.SelectedIndex = -1;
            comboBoxEncodingLeft.SelectedIndexChanged += ComboBoxEncodingLeft_SelectedIndexChanged;
            comboBoxEncodingRight.SelectedIndexChanged -= ComboBoxEncodingRight_SelectedIndexChanged;
            comboBoxEncodingRight.SelectedIndex = -1;
            comboBoxEncodingRight.SelectedIndexChanged += ComboBoxEncodingRight_SelectedIndexChanged;
            comboBoxEncodingResult.SelectedIndex = -1;
            comboBoxSortResult.SelectedIndex = 0;

            comboBoxSaveFolder.Items.Clear();
            comboBoxSaveFolder.Items.AddRange(new object[] {
                "[desktop]",
                "[Left file directory]",
                "[Right file directory]",
                "[program directory]" });
            comboBoxSaveFolder.SelectedIndex = 0;

            comboBoxSaveFileName.Items.Clear();
            comboBoxSaveFileName.Items.AddRange(new object[] {
                "[date]-[time]_[leftname]_[rightname]" });
            comboBoxSaveFileName.SelectedIndex = 0;
            
            labelFileNameLeft.Text = "...";
            labelFileNameLeft.ForeColor = Color.Black;
            labelFileNameRight.Text = "...";
            labelFileNameRight.ForeColor = Color.Black;

            TextBox_Infotext("left");
            TextBox_Infotext("right");

            progressBar.Value = 0;

            // Various variables.
            fileEncodingLeft = null;
            fileEncodingRight = null;
            fileEncodingResult = null;
            filePathLeft = null;
            filePathRight = null;
            filePathResult = null;
            collectionLeft = null;
            collectionRight = null;
            collectionResult = null;
            
            return "success";
        }



        // --------------------------------------
        // Set infotext in textbox.
        void TextBox_Infotext(string show)
        {
            if (show == "left")
            {
                textBoxLeft.Text =
                    "Left:" + Environment.NewLine +
                    "Open file with button above" + Environment.NewLine +
                    "or Drop it here" + Environment.NewLine +
                    "or Type/paste text";
                textBoxLeft.ForeColor = Color.Gray;
            }
            else if (show == "leftError")
            {
                textBoxLeft.Text = "Left:" + Environment.NewLine + "File open ERROR";
                textBoxLeft.ForeColor = Color.Red;
            }
            else if (show == "right")
            {
                textBoxRight.Text =
                    "Right:" + Environment.NewLine +
                    "Open file with button above" + Environment.NewLine +
                    "or Drop it here" + Environment.NewLine +
                    "or Type/paste text";
                textBoxRight.ForeColor = Color.Gray;
            }
            else if (show == "rightError")
            {
                textBoxRight.Text = "Right:" + Environment.NewLine + "File open ERROR";
                textBoxRight.ForeColor = Color.Red;
            }
        }

        

        // --------------------------------------
        // Write settings to .config file.
        string SettingsWrite()
        {
            string[] itemsArray;
            
            try
            {
                var config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                config.AppSettings.Settings.Clear();

                // Form menu settings.
                // (menuSettings_SilentModeIfSavedSettingsAreCorrect
                // and menuSettings_OpenResultAfterAutoMode
                // will be saved by ApplicationExit method).

                // Form window settings.
                config.AppSettings.Settings.Add("checkBoxSubsetLeftOnly.Checked",
                    checkBoxSubsetLeft.Checked.ToString());
                config.AppSettings.Settings.Add("checkBoxSubsetCommon.Checked",
                    checkBoxSubsetCommon.Checked.ToString());
                config.AppSettings.Settings.Add("checkBoxSubsetRightOnly.Checked",
                    checkBoxSubsetRight.Checked.ToString());
                config.AppSettings.Settings.Add("checkBoxIncludeUnique.Checked",
                    checkBoxIncludeUnique.Checked.ToString());
                config.AppSettings.Settings.Add("checkBoxIncludeNonUnique.Checked",
                    checkBoxIncludeNonUnique.Checked.ToString());
                config.AppSettings.Settings.Add("checkBoxKeepDuplicates.Checked",
                    checkBoxKeepDuplicates.Checked.ToString());
                config.AppSettings.Settings.Add("checkBoxOverwrite.Checked",
                    checkBoxOverwrite.Checked.ToString());

                // (encodings as codepage numbers)
                if (comboBoxEncodingLeft.Text != string.Empty)
                {
                    config.AppSettings.Settings.Add(
                        "comboBoxEncodingLeft~codePage",
                        Encoding.GetEncoding(((EncodingInfo)
                            comboBoxEncodingLeft.SelectedItem).Name).CodePage.ToString());
                }
                if (comboBoxEncodingRight.Text != string.Empty)
                {
                    config.AppSettings.Settings.Add(
                        "comboBoxEncodingRight~codePage",
                        Encoding.GetEncoding(((EncodingInfo)
                            comboBoxEncodingRight.SelectedItem).Name).CodePage.ToString());
                }
                if (comboBoxEncodingResult.Text != string.Empty)
                {
                    config.AppSettings.Settings.Add(
                        "comboBoxEncodingResult~codePage",
                        Encoding.GetEncoding(((EncodingInfo)
                        comboBoxEncodingResult.SelectedItem).Name).CodePage.ToString());
                }

                config.AppSettings.Settings.Add("comboBoxSortResult.Text", comboBoxSortResult.Text);

                config.AppSettings.Settings.Add("comboBoxSaveFolder.Text", comboBoxSaveFolder.Text);
                // (check if saving occurs when comboBox has focus)
                if (!comboBoxSaveFolder.Items.Contains(comboBoxSaveFolder.Text))
                    comboBoxSaveFolder.Items.Add(comboBoxSaveFolder.Text);
                // (comboBox items as string)
                itemsArray = new string[comboBoxSaveFolder.Items.Count];
                comboBoxSaveFolder.Items.CopyTo(itemsArray, 0);
                config.AppSettings.Settings.Add("comboBoxSaveFolder~items", string.Join(",", itemsArray));

                config.AppSettings.Settings.Add("comboBoxSaveFileName.Text", comboBoxSaveFileName.Text);
                // (check if saving occurs when comboBox has focus)
                if (!comboBoxSaveFileName.Items.Contains(comboBoxSaveFileName.Text))
                    comboBoxSaveFileName.Items.Add(comboBoxSaveFileName.Text);
                // (comboBox items as string)
                itemsArray = new string[comboBoxSaveFileName.Items.Count];
                comboBoxSaveFileName.Items.CopyTo(itemsArray, 0);
                config.AppSettings.Settings.Add("comboBoxSaveFileName~items", string.Join(",", itemsArray));

                // (full paths instead of filename labels)
                if (labelFileNameLeft.Text != "...")
                    config.AppSettings.Settings.Add("filePathLeft", filePathLeft.ToString());
                if (labelFileNameRight.Text != "...")
                    config.AppSettings.Settings.Add("filePathRight", filePathRight.ToString());

                // (contents of textboxes don't need to be saved, and progressbar don't need to be changed)

                // Various variables.
                // (encodings and paths saved above, and collections don't need to be saved)

                config.Save(ConfigurationSaveMode.Full);
            }
            catch (Exception ex) { return ex.Message; }
            
            return "success";
        }



        // --------------------------------------
        // Read settings from .config file.
        string SettingsRead()
        {
            bool b;
            int i;
            string[] itemsArray;
            if (File.Exists(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile)) SettingsReset();
            else return "Configuration file not found!";

            try
            {
                ConfigurationManager.RefreshSection("appSettings");
                var config = ConfigurationManager.AppSettings;

                // Form menu settings.
                if (Boolean.TryParse(config["menuSettings_AutoModeIfSavedSettingsAreCorrect.Checked"], out b))
                    menuSettings_AutoModeIfSavedSettingsAreCorrect.Checked = b;
                if (Boolean.TryParse(config["menuSettings_OpenResultAfterAutoMode.Checked"], out b))
                    menuSettings_AutoOpeningResult.Checked = b;

                // Form window settings.
                if (Boolean.TryParse(config["checkBoxSubsetLeftOnly.Checked"], out b))
                    checkBoxSubsetLeft.Checked = b;
                if (Boolean.TryParse(config["checkBoxSubsetCommon.Checked"], out b))
                    checkBoxSubsetCommon.Checked = b;
                if (Boolean.TryParse(config["checkBoxSubsetRightOnly.Checked"], out b))
                    checkBoxSubsetRight.Checked = b;
                if (Boolean.TryParse(config["checkBoxIncludeUnique.Checked"], out b))
                    checkBoxIncludeUnique.Checked = b;
                if (Boolean.TryParse(config["checkBoxIncludeNonUnique.Checked"], out b))
                    checkBoxIncludeNonUnique.Checked = b;
                if (Boolean.TryParse(config["checkBoxKeepDuplicates.Checked"], out b))
                    checkBoxKeepDuplicates.Checked = b;
                if (Boolean.TryParse(config["checkBoxOverwrite.Checked"], out b))
                    checkBoxOverwrite.Checked = b;

                if (Int32.TryParse(config["comboBoxEncodingLeft~codePage"], out i))
                {
                    fileEncodingLeft = Encoding.GetEncoding(i);
                    comboBoxEncodingLeft.SelectedIndexChanged -= ComboBoxEncodingLeft_SelectedIndexChanged;
                    comboBoxEncodingLeft.Text = fileEncodingLeft.EncodingName.ToString();
                    comboBoxEncodingLeft.SelectedIndexChanged += ComboBoxEncodingLeft_SelectedIndexChanged;
                }
                if (Int32.TryParse(config["comboBoxEncodingRight~codePage"], out i))
                {
                    fileEncodingRight = Encoding.GetEncoding(i);
                    comboBoxEncodingRight.SelectedIndexChanged -= ComboBoxEncodingRight_SelectedIndexChanged;
                    comboBoxEncodingRight.Text = fileEncodingRight.EncodingName.ToString();
                    comboBoxEncodingRight.SelectedIndexChanged += ComboBoxEncodingRight_SelectedIndexChanged;
                }
                if (Int32.TryParse(config["comboBoxEncodingResult~codePage"], out i))
                {
                    fileEncodingResult = Encoding.GetEncoding(i);
                    comboBoxEncodingResult.Text = fileEncodingResult.EncodingName.ToString();
                }
                comboBoxSortResult.Text = config["comboBoxSortResult.Text"] ?? comboBoxSortResult.Text;
                
                comboBoxSaveFolder.Text = config["comboBoxSaveFolder.Text"] ?? comboBoxSaveFolder.Text;
                // (custom-saved comboBox items)
                itemsArray = config["comboBoxSaveFolder~items"].Split(',').ToArray();
                if (itemsArray != null)
                {
                    comboBoxSaveFolder.Items.Clear();
                    comboBoxSaveFolder.Items.AddRange(itemsArray);
                }

                comboBoxSaveFileName.Text = config["comboBoxSaveFileName.Text"] ?? comboBoxSaveFileName.Text;
                // (custom-saved comboBox items)
                itemsArray = config["comboBoxSaveFileName~items"].Split(',').ToArray();
                if (itemsArray != null)
                {
                    comboBoxSaveFileName.Items.Clear();
                    comboBoxSaveFileName.Items.AddRange(itemsArray);
                }
                
                // (filename labels, textboxes and progressbar are controlled by OpenFile method)

                // Various variables.
                // (if encodings were not parsed above, OpenFile will determine them, as well as create collections)
                filePathLeft = config["filePathLeft"];
                if (filePathLeft != null) OpenFile("left", fileEncodingLeft);
                filePathRight = config["filePathRight"];
                if (filePathRight != null) OpenFile("right", fileEncodingRight);
            }
            catch (Exception ex) { return ex.Message; }
            
            return "success";
        }



        // --------------------------------------
        // Check and prepare settings for Logic class.
        string SettingsPrepare()
        {
            string result = string.Empty;

            if (textBoxLeft.ForeColor != Color.Black)
                result += "Left field is empty.\n";
            if (textBoxRight.ForeColor != Color.Black)
                result += "Right field is empty.\n";
            if (filePathLeft == filePathRight & filePathLeft != "" & filePathLeft != null)
                result += "The same file on the left and right sides.\n";

            if (!checkBoxSubsetLeft.Checked & !checkBoxSubsetCommon.Checked & !checkBoxSubsetRight.Checked)
                result += "No subset selected.\n";
            if (!checkBoxIncludeUnique.Checked & !checkBoxIncludeNonUnique.Checked)
                result += "Neither unique nor non-unique lines were selected.\n";

            string folder = comboBoxSaveFolder.Text;
            if (folder == "[desktop]")
                folder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            else if (folder == "[Left file directory]")
                folder = Path.GetDirectoryName(filePathLeft);
            else if (folder == "[Right file directory]")
                folder = Path.GetDirectoryName(filePathRight);
            else if (folder == "[program directory]")
                folder = Path.GetDirectoryName(Application.ExecutablePath);

            string fileName = comboBoxSaveFileName.Text
                .Replace("[date]", DateTime.Now.ToString("yyyyMMdd"))
                .Replace("[time]", DateTime.Now.ToString("HHmmss"))
                .Replace("[leftname]", Path.GetFileNameWithoutExtension(filePathLeft))
                .Replace("[rightname]", Path.GetFileNameWithoutExtension(filePathRight));

            filePathResult = folder + "\\" + fileName + ".txt";

            if (!checkBoxOverwrite.Checked & File.Exists(filePathResult))
                result += "File with selected name already exists.\n";
            else try
            {
                using (StreamWriter file = new StreamWriter(filePathResult, append: true))
                    file.Write("");
            }
            catch (Exception) { result += "Please check path, filename and write permissions.\n"; }

            try
            {
                File.Delete(filePathResult);
                textBoxLeft.Text = textBoxLeft.Text.Remove(textBoxLeft.Text.LastIndexOf(Environment.NewLine));
                textBoxRight.Text = textBoxRight.Text.Remove(textBoxRight.Text.LastIndexOf(Environment.NewLine));
            }
            catch (Exception) { }

            collectionLeft = textBoxLeft.Lines.ToList();
            collectionRight = textBoxRight.Lines.ToList();

            if (result == string.Empty) return "success";
            else return result;
        }



        // --------------------------------------
        // Read input file to textBox.
        string OpenFile(string side, Encoding fileEncodingCustom)
        {
            string filePath;
            long fileLength;
            long fileLengthMax = 1000000000;
            int maxIndex = 10000;
            var fileContent = string.Empty;
            bool possibleBinFile = false;

            filePathResult = null;
            progressBar.Value = 0;
            Encoding fileEncoding = Encoding.Default;

            if (side == "left") filePath = filePathLeft;
            else if (side == "right") filePath = filePathRight;
            else return "OpenFile(): incorrect parameter!";

            try
            {
                fileLength = new FileInfo(filePath).Length;
                if (fileLength > fileLengthMax)
                {
                    string msg = "File is too big! Try to open anyway?";
                    var DialogResult = MessageBox.Show(msg, Application.ProductName, MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                    if (DialogResult == DialogResult.Cancel) return "OpenFile(): File too big";
                }

                if (fileLength < maxIndex) maxIndex = (int)fileLength;
                var fileBegin = new byte[maxIndex];

                using (var file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    file.Read(fileBegin, 0, maxIndex);

                for (var index = 0; index < maxIndex - 1; index++)
                {
                    if (fileBegin[index] == 0x00 & fileBegin[index+1] == 0x00)
                    {
                        possibleBinFile = true;
                        break;
                    }
                }

                if (fileEncodingCustom != null) fileEncoding = fileEncodingCustom;
                else if (fileBegin[0] == 0x2b && fileBegin[1] == 0x2f && fileBegin[2] == 0x76)
                    fileEncoding = Encoding.UTF7; // UTF-7
                else if (fileBegin[0] == 0xef && fileBegin[1] == 0xbb && fileBegin[2] == 0xbf)
                    fileEncoding = Encoding.UTF8; // UTF-8
                else if (fileBegin[0] == 0xff && fileBegin[1] == 0xfe)
                    fileEncoding = Encoding.Unicode; // UTF-16LE
                else if (fileBegin[0] == 0xfe && fileBegin[1] == 0xff)
                    fileEncoding = Encoding.BigEndianUnicode; // UTF-16BE
                else if (fileBegin[0] == 0 && fileBegin[1] == 0 && fileBegin[2] == 0xfe && fileBegin[3] == 0xff)
                    fileEncoding = Encoding.UTF32; // UTF-32
                else if (possibleBinFile)
                {
                    string msg = "It seems file is binary. Try to open it anyway?";
                    var DialogResult = MessageBox.Show(msg, Application.ProductName, MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                    if (DialogResult == DialogResult.Cancel) return "OpenFile(): File is binary";
                }
                
                using (var file = new StreamReader(filePath, fileEncoding, false, 4096))
                    while (!file.EndOfStream) fileContent += file.ReadLine() + "\r\n";

                if (side == "left")
                {
                    fileEncodingLeft = fileEncoding;
                    comboBoxEncodingLeft.SelectedIndexChanged -= ComboBoxEncodingLeft_SelectedIndexChanged;
                    comboBoxEncodingLeft.Text = fileEncodingLeft.EncodingName.ToString();
                    comboBoxEncodingLeft.SelectedIndexChanged += ComboBoxEncodingLeft_SelectedIndexChanged;
                    labelFileNameLeft.ForeColor = Color.Black;
                    labelFileNameLeft.Text = Path.GetFileName(filePathLeft);
                    textBoxLeft.ForeColor = Color.Black;
                    textBoxLeft.Text = fileContent;

                    // Suggest encoding as first added file.
                    if (string.IsNullOrEmpty(comboBoxEncodingRight.Text))
                        comboBoxEncodingResult.Text = comboBoxEncodingLeft.Text;
                }
                if (side == "right")
                {
                    fileEncodingRight = fileEncoding;
                    comboBoxEncodingRight.SelectedIndexChanged -= ComboBoxEncodingRight_SelectedIndexChanged;
                    comboBoxEncodingRight.Text = fileEncodingRight.EncodingName.ToString();
                    comboBoxEncodingRight.SelectedIndexChanged += ComboBoxEncodingRight_SelectedIndexChanged;
                    labelFileNameRight.ForeColor = Color.Black;
                    labelFileNameRight.Text = Path.GetFileName(filePathRight);
                    textBoxRight.ForeColor = Color.Black;
                    textBoxRight.Text = fileContent;

                    // Suggest encoding as first added file.
                    if (string.IsNullOrEmpty(comboBoxEncodingLeft.Text))
                        comboBoxEncodingResult.Text = comboBoxEncodingRight.Text;
                }
            }
            catch (Exception ex)
            {
                if (side == "left")
                {
                    labelFileNameLeft.Text = Path.GetFileName(filePathLeft);
                    labelFileNameLeft.ForeColor = Color.Red;
                    TextBox_Infotext("leftError");
                    return ex.Message;
                }
                if (side == "right")
                {
                    labelFileNameRight.Text = Path.GetFileName(filePathRight);
                    labelFileNameRight.ForeColor = Color.Red;
                    TextBox_Infotext("rightError");
                    return ex.Message;
                }
            }

            return "success";
        }



        // --------------------------------------
        // Form window main menu events.
        void MenuItemFile_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        void MenuItemSettings_Save_Click(object sender, EventArgs e)
        {
            string result = SettingsWrite();
            if (result != "success") ShowError(result);
        }

        void MenuItemSettings_LoadSaved_Click(object sender, EventArgs e)
        {
            string result = SettingsRead();
            if (result != "success") ShowError(result);
        }

        void MenuItemSettings_Reset_Click(object sender, EventArgs e)
        {
            SettingsReset();
        }
        
        void MenuItemHelp_About_Click(object sender, EventArgs e)
        {
            FormAbout aboutWindow = new FormAbout();
            aboutWindow.Show();
        }



        // --------------------------------------
        // Form window events.
        void ButtonOpenLeft_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    filePathLeft = dlg.FileName;
                    OpenFile("left", null);
                }
            }
        }

        void ButtonOpenRight_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    filePathRight = dlg.FileName;
                    OpenFile("right", null);
                }
            }
        }

        void ButtonChooseSaveFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dlg = new FolderBrowserDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK) comboBoxSaveFolder.Text = dlg.SelectedPath;
            }
        }

        void ButtonStart_Click(object sender, EventArgs e)
        {
            string result = SettingsPrepare();
            if (result == "success") StartProcessing();
            else ShowError("Start error!\n\n" + result);
        }

        void ButtonOpenResult_Click(object sender, EventArgs e)
        {
            try { System.Diagnostics.Process.Start(@filePathResult); }
            catch (Exception ex) { ShowError("Open result error!\n\n" + ex.Message); }
        }

        void ButtonReset_Click(object sender, EventArgs e)
        {
            SettingsReset();
        }

        void CheckBoxIncludeNonUnique_CheckStateChanged(object sender, EventArgs e)
        {
            // Controlling 'Keep duplicates' checkbox by 'Non-unique' checkbox.
            if (checkBoxIncludeNonUnique.CheckState == CheckState.Checked) checkBoxKeepDuplicates.Enabled = true;
            else checkBoxKeepDuplicates.Enabled = false;
        }

        void ComboBoxEncodingLeft_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Guided by what the user sees...
            if (labelFileNameLeft.Text != "...")
            {
                Encoding fileEncodingCustom =
                    Encoding.GetEncoding(((EncodingInfo)comboBoxEncodingLeft.SelectedItem).Name);
                OpenFile("left", fileEncodingCustom);
            }
        }

        void ComboBoxEncodingRight_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Guided by what the user sees...
            if (labelFileNameRight.Text != "...")
            {
                Encoding fileEncodingCustom =
                    Encoding.GetEncoding(((EncodingInfo)comboBoxEncodingRight.SelectedItem).Name);
                OpenFile("right", fileEncodingCustom);
            }
        }

        void ComboBoxSaveFolder_Leave(object sender, EventArgs e)
        {
            if (!comboBoxSaveFolder.Items.Contains(comboBoxSaveFolder.Text))
                comboBoxSaveFolder.Items.Add(comboBoxSaveFolder.Text);
        }

        void ComboBoxSaveFileName_Leave(object sender, EventArgs e)
        {
            if (!comboBoxSaveFileName.Items.Contains(comboBoxSaveFileName.Text))
                comboBoxSaveFileName.Items.Add(comboBoxSaveFileName.Text);
        }

        void TextBoxLeft_Enter(object sender, EventArgs e)
        {
            if (textBoxLeft.ForeColor == Color.Black) return;
            textBoxLeft.Text = string.Empty;
            textBoxLeft.ForeColor = Color.Black;
        }

        void TextBoxRight_Enter(object sender, EventArgs e)
        {
            if (textBoxRight.ForeColor == Color.Black) return;
            textBoxRight.Text = string.Empty;
            textBoxRight.ForeColor = Color.Black;
        }

        void TextBoxLeft_ModifiedChanged(object sender, EventArgs e)
        {
            if (labelFileNameLeft.ForeColor == Color.Black & labelFileNameLeft.Text != "...")
                labelFileNameLeft.Text += " *";
        }

        void TextBoxRight_ModifiedChanged(object sender, EventArgs e)
        {
            if (labelFileNameRight.ForeColor == Color.Black & labelFileNameRight.Text != "...")
                labelFileNameRight.Text += " *";
        }

        void TextBoxLeft_Leave(object sender, EventArgs e)
        {
            if (textBoxLeft.Text.Trim() == string.Empty & labelFileNameLeft.ForeColor == Color.Black)
                TextBox_Infotext("left");
            else if (textBoxLeft.Text.Trim() == string.Empty & labelFileNameLeft.ForeColor == Color.Red)
                TextBox_Infotext("leftError");
            else if (textBoxLeft.Text.Trim() != string.Empty & labelFileNameLeft.ForeColor == Color.Red)
            {
                labelFileNameLeft.Text = "...";
                labelFileNameLeft.ForeColor = Color.Black;
                filePathLeft = null;
                comboBoxEncodingLeft.SelectedIndexChanged -= ComboBoxEncodingLeft_SelectedIndexChanged;
                comboBoxEncodingLeft.SelectedIndex = -1;
                comboBoxEncodingLeft.SelectedIndexChanged += ComboBoxEncodingLeft_SelectedIndexChanged;
            }
        }

        void TextBoxRight_Leave(object sender, EventArgs e)
        {
            if (textBoxRight.Text.Trim() == string.Empty & labelFileNameRight.ForeColor == Color.Black)
                TextBox_Infotext("right");
            else if (textBoxRight.Text.Trim() == string.Empty & labelFileNameRight.ForeColor == Color.Red)
                TextBox_Infotext("rightError");
            else if (textBoxRight.Text.Trim() != string.Empty & labelFileNameRight.ForeColor == Color.Red)
            {
                labelFileNameRight.Text = "...";
                labelFileNameRight.ForeColor = Color.Black;
                filePathRight = null;
                comboBoxEncodingRight.SelectedIndexChanged -= ComboBoxEncodingRight_SelectedIndexChanged;
                comboBoxEncodingRight.SelectedIndex = -1;
                comboBoxEncodingRight.SelectedIndexChanged += ComboBoxEncodingRight_SelectedIndexChanged;
            }
        }

        void TextBoxLeft_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        void TextBoxLeft_DragDrop(object sender, DragEventArgs e)
        {
            string[] filesDropped = (string[])e.Data.GetData(DataFormats.FileDrop);
            filePathLeft = filesDropped[0];
            OpenFile("left", null);
        }

        void TextBoxRight_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        void TextBoxRight_DragDrop(object sender, DragEventArgs e)
        {
            string[] filesDropped = (string[])e.Data.GetData(DataFormats.FileDrop);
            filePathRight = filesDropped[0];
            OpenFile("right", null);
        }



        // --------------------------------------
        // Processing lists.
        void StartProcessing()
        {
            Logic dataSet = new Logic();

            for (int i = 0; i < 30; i += 5)
            {
                System.Threading.Thread.Sleep(5);
                progressBar.Value = i;
            }

            string result = dataSet.ProcessLists(
                checkBoxSubsetLeft.Checked,
                checkBoxSubsetCommon.Checked,
                checkBoxSubsetRight.Checked,
                checkBoxIncludeUnique.Checked,
                checkBoxIncludeNonUnique.Checked,
                checkBoxKeepDuplicates.Checked,
                comboBoxSortResult.Text,
                collectionLeft,
                collectionRight,
                out collectionResult);

            if (result == "success")
            {
                if (comboBoxEncodingResult.SelectedIndex != -1) fileEncodingResult =
                        Encoding.GetEncoding(((EncodingInfo)comboBoxEncodingResult.SelectedItem).Name);
                else fileEncodingResult = Encoding.Default;

                try { File.WriteAllLines(filePathResult, collectionResult.ToArray(), fileEncodingResult); }
                catch (Exception ex) { ShowError("Error writing result!\n\n" + ex.Message); }

                if (menuSettings_AutoOpeningResult.Checked)
                {
                    try { System.Diagnostics.Process.Start(@filePathResult); }
                    catch (Exception) { ShowError("Result file open error!"); }
                }
            }
            else ShowError("Error processing list(s)!\n\n" + result);

            for (int i = 60; i < 101; i += 10)
            {
                System.Threading.Thread.Sleep(5);
                progressBar.Value = i;
            }

        }



        // --------------------------------------
        // Show error message.
        void ShowError(string msg)
        {
            if (!string.IsNullOrEmpty(msg))
                MessageBox.Show(msg, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        

        // --------------------------------------
        // Exit application.
        void ApplicationExit(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile))
                {
                    var config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);

                    config.AppSettings.Settings.Remove("menuSettings_AutoModeIfSavedSettingsAreCorrect.Checked");
                    config.AppSettings.Settings.Add("menuSettings_AutoModeIfSavedSettingsAreCorrect.Checked",
                        menuSettings_AutoModeIfSavedSettingsAreCorrect.Checked.ToString());
                    config.AppSettings.Settings.Remove("menuSettings_OpenResultAfterAutoMode.Checked");
                    config.AppSettings.Settings.Add("menuSettings_OpenResultAfterAutoMode.Checked",
                        menuSettings_AutoOpeningResult.Checked.ToString());

                    config.Save(ConfigurationSaveMode.Full);
                }
            }
            catch (Exception ex) { ShowError(ex.Message); }
        }

    }
}
