namespace ee3dList
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Auto

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFile_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSettings_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSettings_LoadSaved = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSettings_Reset = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSettings_Separator = new System.Windows.Forms.ToolStripSeparator();
            this.menuSettings_AutoModeIfSavedSettingsAreCorrect = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSettings_AutoOpeningResult = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp_About = new System.Windows.Forms.ToolStripMenuItem();
            this.labelFileNameLeft = new System.Windows.Forms.Label();
            this.buttonOpenLeft = new System.Windows.Forms.Button();
            this.labelFileNameRight = new System.Windows.Forms.Label();
            this.buttonOpenRight = new System.Windows.Forms.Button();
            this.textBoxLeft = new System.Windows.Forms.TextBox();
            this.textBoxRight = new System.Windows.Forms.TextBox();
            this.labelEncodingLeft = new System.Windows.Forms.Label();
            this.labelEncodingRight = new System.Windows.Forms.Label();
            this.comboBoxEncodingLeft = new System.Windows.Forms.ComboBox();
            this.comboBoxEncodingRight = new System.Windows.Forms.ComboBox();
            this.groupBoxSubsets = new System.Windows.Forms.GroupBox();
            this.checkBoxSubsetRight = new System.Windows.Forms.CheckBox();
            this.checkBoxSubsetLeft = new System.Windows.Forms.CheckBox();
            this.checkBoxSubsetCommon = new System.Windows.Forms.CheckBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.comboBoxSortResult = new System.Windows.Forms.ComboBox();
            this.groupBoxIncludeLines = new System.Windows.Forms.GroupBox();
            this.checkBoxKeepDuplicates = new System.Windows.Forms.CheckBox();
            this.checkBoxIncludeNonUnique = new System.Windows.Forms.CheckBox();
            this.checkBoxIncludeUnique = new System.Windows.Forms.CheckBox();
            this.groupBoxResult = new System.Windows.Forms.GroupBox();
            this.checkBoxOverwrite = new System.Windows.Forms.CheckBox();
            this.labelSaveToFileFolder = new System.Windows.Forms.Label();
            this.labelSaveToFileEncoding = new System.Windows.Forms.Label();
            this.labelSaveToFileFileName = new System.Windows.Forms.Label();
            this.comboBoxEncodingResult = new System.Windows.Forms.ComboBox();
            this.comboBoxSaveFileName = new System.Windows.Forms.ComboBox();
            this.buttonChooseSaveFolder = new System.Windows.Forms.Button();
            this.comboBoxSaveFolder = new System.Windows.Forms.ComboBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonOpenResult = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.groupBoxSort = new System.Windows.Forms.GroupBox();
            this.menu.SuspendLayout();
            this.groupBoxSubsets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.groupBoxIncludeLines.SuspendLayout();
            this.groupBoxResult.SuspendLayout();
            this.groupBoxSort.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuSettings,
            this.menuHelp});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(782, 28);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile_Exit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(46, 24);
            this.menuFile.Text = "File";
            // 
            // menuFile_Exit
            // 
            this.menuFile_Exit.Name = "menuFile_Exit";
            this.menuFile_Exit.Size = new System.Drawing.Size(116, 26);
            this.menuFile_Exit.Text = "Exit";
            // 
            // menuSettings
            // 
            this.menuSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSettings_Save,
            this.menuSettings_LoadSaved,
            this.menuSettings_Reset,
            this.menuSettings_Separator,
            this.menuSettings_AutoModeIfSavedSettingsAreCorrect,
            this.menuSettings_AutoOpeningResult});
            this.menuSettings.Name = "menuSettings";
            this.menuSettings.Size = new System.Drawing.Size(76, 24);
            this.menuSettings.Text = "Settings";
            // 
            // menuSettings_Save
            // 
            this.menuSettings_Save.Name = "menuSettings_Save";
            this.menuSettings_Save.Size = new System.Drawing.Size(354, 26);
            this.menuSettings_Save.Text = "Save";
            // 
            // menuSettings_LoadSaved
            // 
            this.menuSettings_LoadSaved.Name = "menuSettings_LoadSaved";
            this.menuSettings_LoadSaved.Size = new System.Drawing.Size(354, 26);
            this.menuSettings_LoadSaved.Text = "Load saved";
            // 
            // menuSettings_Reset
            // 
            this.menuSettings_Reset.Name = "menuSettings_Reset";
            this.menuSettings_Reset.Size = new System.Drawing.Size(354, 26);
            this.menuSettings_Reset.Text = "Reset";
            // 
            // menuSettings_Separator
            // 
            this.menuSettings_Separator.Name = "menuSettings_Separator";
            this.menuSettings_Separator.Size = new System.Drawing.Size(351, 6);
            // 
            // menuSettings_AutoModeIfSavedSettingsAreCorrect
            // 
            this.menuSettings_AutoModeIfSavedSettingsAreCorrect.Name = "menuSettings_AutoModeIfSavedSettingsAreCorrect";
            this.menuSettings_AutoModeIfSavedSettingsAreCorrect.Size = new System.Drawing.Size(354, 26);
            this.menuSettings_AutoModeIfSavedSettingsAreCorrect.Text = "Auto-mode if saved settings are correct";
            // 
            // menuSettings_AutoOpeningResult
            // 
            this.menuSettings_AutoOpeningResult.Name = "menuSettings_AutoOpeningResult";
            this.menuSettings_AutoOpeningResult.Size = new System.Drawing.Size(354, 26);
            this.menuSettings_AutoOpeningResult.Text = "Auto-opening of the result";
            // 
            // menuHelp
            // 
            this.menuHelp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuHelp_About});
            this.menuHelp.Name = "menuHelp";
            this.menuHelp.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuHelp.Size = new System.Drawing.Size(55, 24);
            this.menuHelp.Text = "Help";
            // 
            // menuHelp_About
            // 
            this.menuHelp_About.Name = "menuHelp_About";
            this.menuHelp_About.Size = new System.Drawing.Size(133, 26);
            this.menuHelp_About.Text = "About";
            // 
            // labelFileNameLeft
            // 
            this.labelFileNameLeft.AutoSize = true;
            this.labelFileNameLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFileNameLeft.Location = new System.Drawing.Point(12, 35);
            this.labelFileNameLeft.Name = "labelFileNameLeft";
            this.labelFileNameLeft.Size = new System.Drawing.Size(23, 17);
            this.labelFileNameLeft.TabIndex = 1;
            this.labelFileNameLeft.Text = "...";
            // 
            // buttonOpenLeft
            // 
            this.buttonOpenLeft.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonOpenLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOpenLeft.Location = new System.Drawing.Point(305, 31);
            this.buttonOpenLeft.Name = "buttonOpenLeft";
            this.buttonOpenLeft.Size = new System.Drawing.Size(77, 28);
            this.buttonOpenLeft.TabIndex = 2;
            this.buttonOpenLeft.Text = "...";
            this.buttonOpenLeft.UseVisualStyleBackColor = true;
            // 
            // labelFileNameRight
            // 
            this.labelFileNameRight.AutoSize = true;
            this.labelFileNameRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFileNameRight.Location = new System.Drawing.Point(394, 35);
            this.labelFileNameRight.Name = "labelFileNameRight";
            this.labelFileNameRight.Size = new System.Drawing.Size(23, 17);
            this.labelFileNameRight.TabIndex = 3;
            this.labelFileNameRight.Text = "...";
            // 
            // buttonOpenRight
            // 
            this.buttonOpenRight.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonOpenRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOpenRight.Location = new System.Drawing.Point(686, 31);
            this.buttonOpenRight.Name = "buttonOpenRight";
            this.buttonOpenRight.Size = new System.Drawing.Size(77, 28);
            this.buttonOpenRight.TabIndex = 4;
            this.buttonOpenRight.Text = "...";
            this.buttonOpenRight.UseVisualStyleBackColor = true;
            // 
            // textBoxLeft
            // 
            this.textBoxLeft.AllowDrop = true;
            this.textBoxLeft.Location = new System.Drawing.Point(12, 65);
            this.textBoxLeft.Multiline = true;
            this.textBoxLeft.Name = "textBoxLeft";
            this.textBoxLeft.Size = new System.Drawing.Size(376, 145);
            this.textBoxLeft.TabIndex = 5;
            this.textBoxLeft.TabStop = false;
            this.textBoxLeft.WordWrap = false;
            // 
            // textBoxRight
            // 
            this.textBoxRight.AllowDrop = true;
            this.textBoxRight.Location = new System.Drawing.Point(394, 65);
            this.textBoxRight.Multiline = true;
            this.textBoxRight.Name = "textBoxRight";
            this.textBoxRight.Size = new System.Drawing.Size(376, 145);
            this.textBoxRight.TabIndex = 6;
            this.textBoxRight.TabStop = false;
            this.textBoxRight.WordWrap = false;
            // 
            // labelEncodingLeft
            // 
            this.labelEncodingLeft.AutoSize = true;
            this.labelEncodingLeft.Location = new System.Drawing.Point(18, 219);
            this.labelEncodingLeft.Name = "labelEncodingLeft";
            this.labelEncodingLeft.Size = new System.Drawing.Size(67, 17);
            this.labelEncodingLeft.TabIndex = 7;
            this.labelEncodingLeft.Text = "Encoding";
            // 
            // labelEncodingRight
            // 
            this.labelEncodingRight.AutoSize = true;
            this.labelEncodingRight.Location = new System.Drawing.Point(400, 219);
            this.labelEncodingRight.Name = "labelEncodingRight";
            this.labelEncodingRight.Size = new System.Drawing.Size(67, 17);
            this.labelEncodingRight.TabIndex = 9;
            this.labelEncodingRight.Text = "Encoding";
            // 
            // comboBoxEncodingLeft
            // 
            this.comboBoxEncodingLeft.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEncodingLeft.FormattingEnabled = true;
            this.comboBoxEncodingLeft.Location = new System.Drawing.Point(91, 216);
            this.comboBoxEncodingLeft.Name = "comboBoxEncodingLeft";
            this.comboBoxEncodingLeft.Size = new System.Drawing.Size(291, 24);
            this.comboBoxEncodingLeft.TabIndex = 8;
            // 
            // comboBoxEncodingRight
            // 
            this.comboBoxEncodingRight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEncodingRight.FormattingEnabled = true;
            this.comboBoxEncodingRight.Location = new System.Drawing.Point(473, 216);
            this.comboBoxEncodingRight.Name = "comboBoxEncodingRight";
            this.comboBoxEncodingRight.Size = new System.Drawing.Size(291, 24);
            this.comboBoxEncodingRight.TabIndex = 10;
            // 
            // groupBoxSubsets
            // 
            this.groupBoxSubsets.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBoxSubsets.Controls.Add(this.checkBoxSubsetRight);
            this.groupBoxSubsets.Controls.Add(this.checkBoxSubsetLeft);
            this.groupBoxSubsets.Controls.Add(this.checkBoxSubsetCommon);
            this.groupBoxSubsets.Controls.Add(this.pictureBox);
            this.groupBoxSubsets.Location = new System.Drawing.Point(12, 246);
            this.groupBoxSubsets.Name = "groupBoxSubsets";
            this.groupBoxSubsets.Size = new System.Drawing.Size(758, 90);
            this.groupBoxSubsets.TabIndex = 11;
            this.groupBoxSubsets.TabStop = false;
            this.groupBoxSubsets.Text = "Subsets";
            // 
            // checkBoxSubsetRight
            // 
            this.checkBoxSubsetRight.AutoSize = true;
            this.checkBoxSubsetRight.Location = new System.Drawing.Point(517, 44);
            this.checkBoxSubsetRight.Name = "checkBoxSubsetRight";
            this.checkBoxSubsetRight.Size = new System.Drawing.Size(152, 21);
            this.checkBoxSubsetRight.TabIndex = 14;
            this.checkBoxSubsetRight.Text = "Found in Right only";
            this.checkBoxSubsetRight.UseVisualStyleBackColor = true;
            // 
            // checkBoxSubsetLeft
            // 
            this.checkBoxSubsetLeft.AutoSize = true;
            this.checkBoxSubsetLeft.Location = new System.Drawing.Point(108, 44);
            this.checkBoxSubsetLeft.Name = "checkBoxSubsetLeft";
            this.checkBoxSubsetLeft.Size = new System.Drawing.Size(143, 21);
            this.checkBoxSubsetLeft.TabIndex = 12;
            this.checkBoxSubsetLeft.Text = "Found in Left only";
            this.checkBoxSubsetLeft.UseVisualStyleBackColor = true;
            // 
            // checkBoxSubsetCommon
            // 
            this.checkBoxSubsetCommon.AutoSize = true;
            this.checkBoxSubsetCommon.Location = new System.Drawing.Point(335, 44);
            this.checkBoxSubsetCommon.Name = "checkBoxSubsetCommon";
            this.checkBoxSubsetCommon.Size = new System.Drawing.Size(85, 21);
            this.checkBoxSubsetCommon.TabIndex = 13;
            this.checkBoxSubsetCommon.Text = "Common";
            this.checkBoxSubsetCommon.UseVisualStyleBackColor = true;
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox.BackgroundImage")));
            this.pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox.InitialImage = null;
            this.pictureBox.Location = new System.Drawing.Point(6, 21);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(746, 63);
            this.pictureBox.TabIndex = 3;
            this.pictureBox.TabStop = false;
            // 
            // comboBoxSortResult
            // 
            this.comboBoxSortResult.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSortResult.FormattingEnabled = true;
            this.comboBoxSortResult.Location = new System.Drawing.Point(9, 36);
            this.comboBoxSortResult.Name = "comboBoxSortResult";
            this.comboBoxSortResult.Size = new System.Drawing.Size(360, 24);
            this.comboBoxSortResult.TabIndex = 16;
            // 
            // groupBoxIncludeLines
            // 
            this.groupBoxIncludeLines.Controls.Add(this.checkBoxKeepDuplicates);
            this.groupBoxIncludeLines.Controls.Add(this.checkBoxIncludeNonUnique);
            this.groupBoxIncludeLines.Controls.Add(this.checkBoxIncludeUnique);
            this.groupBoxIncludeLines.Location = new System.Drawing.Point(12, 342);
            this.groupBoxIncludeLines.Name = "groupBoxIncludeLines";
            this.groupBoxIncludeLines.Size = new System.Drawing.Size(376, 76);
            this.groupBoxIncludeLines.TabIndex = 17;
            this.groupBoxIncludeLines.TabStop = false;
            this.groupBoxIncludeLines.Text = "Include lines";
            // 
            // checkBoxKeepDuplicates
            // 
            this.checkBoxKeepDuplicates.AutoSize = true;
            this.checkBoxKeepDuplicates.Location = new System.Drawing.Point(239, 39);
            this.checkBoxKeepDuplicates.Name = "checkBoxKeepDuplicates";
            this.checkBoxKeepDuplicates.Size = new System.Drawing.Size(131, 21);
            this.checkBoxKeepDuplicates.TabIndex = 20;
            this.checkBoxKeepDuplicates.Text = "Keep duplicates";
            this.checkBoxKeepDuplicates.UseVisualStyleBackColor = true;
            // 
            // checkBoxIncludeNonUnique
            // 
            this.checkBoxIncludeNonUnique.AutoSize = true;
            this.checkBoxIncludeNonUnique.Location = new System.Drawing.Point(108, 39);
            this.checkBoxIncludeNonUnique.Name = "checkBoxIncludeNonUnique";
            this.checkBoxIncludeNonUnique.Size = new System.Drawing.Size(104, 21);
            this.checkBoxIncludeNonUnique.TabIndex = 19;
            this.checkBoxIncludeNonUnique.Text = "Non-unique";
            this.checkBoxIncludeNonUnique.UseVisualStyleBackColor = true;
            // 
            // checkBoxIncludeUnique
            // 
            this.checkBoxIncludeUnique.AutoSize = true;
            this.checkBoxIncludeUnique.Location = new System.Drawing.Point(9, 39);
            this.checkBoxIncludeUnique.Name = "checkBoxIncludeUnique";
            this.checkBoxIncludeUnique.Size = new System.Drawing.Size(75, 21);
            this.checkBoxIncludeUnique.TabIndex = 18;
            this.checkBoxIncludeUnique.Text = "Unique";
            this.checkBoxIncludeUnique.UseVisualStyleBackColor = true;
            // 
            // groupBoxResult
            // 
            this.groupBoxResult.Controls.Add(this.checkBoxOverwrite);
            this.groupBoxResult.Controls.Add(this.labelSaveToFileFolder);
            this.groupBoxResult.Controls.Add(this.labelSaveToFileEncoding);
            this.groupBoxResult.Controls.Add(this.labelSaveToFileFileName);
            this.groupBoxResult.Controls.Add(this.comboBoxEncodingResult);
            this.groupBoxResult.Controls.Add(this.comboBoxSaveFileName);
            this.groupBoxResult.Controls.Add(this.buttonChooseSaveFolder);
            this.groupBoxResult.Controls.Add(this.comboBoxSaveFolder);
            this.groupBoxResult.Location = new System.Drawing.Point(394, 342);
            this.groupBoxResult.Name = "groupBoxResult";
            this.groupBoxResult.Size = new System.Drawing.Size(376, 158);
            this.groupBoxResult.TabIndex = 21;
            this.groupBoxResult.TabStop = false;
            this.groupBoxResult.Text = "Result";
            // 
            // checkBoxOverwrite
            // 
            this.checkBoxOverwrite.AutoSize = true;
            this.checkBoxOverwrite.Location = new System.Drawing.Point(79, 84);
            this.checkBoxOverwrite.Name = "checkBoxOverwrite";
            this.checkBoxOverwrite.Size = new System.Drawing.Size(159, 21);
            this.checkBoxOverwrite.TabIndex = 29;
            this.checkBoxOverwrite.Text = "overwrite if file exists";
            this.checkBoxOverwrite.UseVisualStyleBackColor = true;
            // 
            // labelSaveToFileFolder
            // 
            this.labelSaveToFileFolder.AutoSize = true;
            this.labelSaveToFileFolder.Location = new System.Drawing.Point(6, 25);
            this.labelSaveToFileFolder.Name = "labelSaveToFileFolder";
            this.labelSaveToFileFolder.Size = new System.Drawing.Size(48, 17);
            this.labelSaveToFileFolder.TabIndex = 24;
            this.labelSaveToFileFolder.Text = "Folder";
            // 
            // labelSaveToFileEncoding
            // 
            this.labelSaveToFileEncoding.AutoSize = true;
            this.labelSaveToFileEncoding.Location = new System.Drawing.Point(6, 121);
            this.labelSaveToFileEncoding.Name = "labelSaveToFileEncoding";
            this.labelSaveToFileEncoding.Size = new System.Drawing.Size(67, 17);
            this.labelSaveToFileEncoding.TabIndex = 22;
            this.labelSaveToFileEncoding.Text = "Encoding";
            // 
            // labelSaveToFileFileName
            // 
            this.labelSaveToFileFileName.AutoSize = true;
            this.labelSaveToFileFileName.Location = new System.Drawing.Point(6, 57);
            this.labelSaveToFileFileName.Name = "labelSaveToFileFileName";
            this.labelSaveToFileFileName.Size = new System.Drawing.Size(65, 17);
            this.labelSaveToFileFileName.TabIndex = 27;
            this.labelSaveToFileFileName.Text = "Filename";
            // 
            // comboBoxEncodingResult
            // 
            this.comboBoxEncodingResult.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEncodingResult.FormattingEnabled = true;
            this.comboBoxEncodingResult.Location = new System.Drawing.Point(79, 118);
            this.comboBoxEncodingResult.Name = "comboBoxEncodingResult";
            this.comboBoxEncodingResult.Size = new System.Drawing.Size(291, 24);
            this.comboBoxEncodingResult.TabIndex = 23;
            // 
            // comboBoxSaveFileName
            // 
            this.comboBoxSaveFileName.FormattingEnabled = true;
            this.comboBoxSaveFileName.Location = new System.Drawing.Point(79, 54);
            this.comboBoxSaveFileName.Name = "comboBoxSaveFileName";
            this.comboBoxSaveFileName.Size = new System.Drawing.Size(291, 24);
            this.comboBoxSaveFileName.TabIndex = 28;
            // 
            // buttonChooseSaveFolder
            // 
            this.buttonChooseSaveFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonChooseSaveFolder.Location = new System.Drawing.Point(295, 20);
            this.buttonChooseSaveFolder.Name = "buttonChooseSaveFolder";
            this.buttonChooseSaveFolder.Size = new System.Drawing.Size(77, 28);
            this.buttonChooseSaveFolder.TabIndex = 26;
            this.buttonChooseSaveFolder.Text = "...";
            this.buttonChooseSaveFolder.UseVisualStyleBackColor = true;
            // 
            // comboBoxSaveFolder
            // 
            this.comboBoxSaveFolder.FormattingEnabled = true;
            this.comboBoxSaveFolder.Location = new System.Drawing.Point(79, 21);
            this.comboBoxSaveFolder.Name = "comboBoxSaveFolder";
            this.comboBoxSaveFolder.Size = new System.Drawing.Size(210, 24);
            this.comboBoxSaveFolder.TabIndex = 25;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(394, 511);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(121, 32);
            this.buttonStart.TabIndex = 30;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            // 
            // buttonOpenResult
            // 
            this.buttonOpenResult.Location = new System.Drawing.Point(521, 511);
            this.buttonOpenResult.Name = "buttonOpenResult";
            this.buttonOpenResult.Size = new System.Drawing.Size(122, 32);
            this.buttonOpenResult.TabIndex = 31;
            this.buttonOpenResult.Text = "Open result";
            this.buttonOpenResult.UseVisualStyleBackColor = true;
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(649, 511);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(121, 32);
            this.buttonReset.TabIndex = 32;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 512);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(376, 29);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 29;
            // 
            // groupBoxSort
            // 
            this.groupBoxSort.Controls.Add(this.comboBoxSortResult);
            this.groupBoxSort.Location = new System.Drawing.Point(12, 424);
            this.groupBoxSort.Name = "groupBoxSort";
            this.groupBoxSort.Size = new System.Drawing.Size(376, 76);
            this.groupBoxSort.TabIndex = 34;
            this.groupBoxSort.TabStop = false;
            this.groupBoxSort.Text = "Sort";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.groupBoxSort);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonOpenResult);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.groupBoxResult);
            this.Controls.Add(this.groupBoxIncludeLines);
            this.Controls.Add(this.groupBoxSubsets);
            this.Controls.Add(this.comboBoxEncodingRight);
            this.Controls.Add(this.comboBoxEncodingLeft);
            this.Controls.Add(this.labelEncodingRight);
            this.Controls.Add(this.labelEncodingLeft);
            this.Controls.Add(this.textBoxRight);
            this.Controls.Add(this.textBoxLeft);
            this.Controls.Add(this.buttonOpenRight);
            this.Controls.Add(this.labelFileNameRight);
            this.Controls.Add(this.buttonOpenLeft);
            this.Controls.Add(this.labelFileNameLeft);
            this.Controls.Add(this.menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Form1";
            this.Text = "3dList";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.groupBoxSubsets.ResumeLayout(false);
            this.groupBoxSubsets.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.groupBoxIncludeLines.ResumeLayout(false);
            this.groupBoxIncludeLines.PerformLayout();
            this.groupBoxResult.ResumeLayout(false);
            this.groupBoxResult.PerformLayout();
            this.groupBoxSort.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuFile_Exit;
        private System.Windows.Forms.ToolStripMenuItem menuSettings;
        private System.Windows.Forms.ToolStripMenuItem menuSettings_Save;
        private System.Windows.Forms.ToolStripMenuItem menuSettings_LoadSaved;
        private System.Windows.Forms.ToolStripMenuItem menuSettings_Reset;
        private System.Windows.Forms.ToolStripSeparator menuSettings_Separator;
        private System.Windows.Forms.ToolStripMenuItem menuSettings_AutoModeIfSavedSettingsAreCorrect;
        private System.Windows.Forms.ToolStripMenuItem menuSettings_AutoOpeningResult;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
        private System.Windows.Forms.ToolStripMenuItem menuHelp_About;

        private System.Windows.Forms.Button buttonOpenLeft;
        private System.Windows.Forms.Button buttonOpenRight;
        private System.Windows.Forms.Button buttonChooseSaveFolder;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonOpenResult;
        private System.Windows.Forms.Button buttonReset;
        
        private System.Windows.Forms.CheckBox checkBoxSubsetLeft;
        private System.Windows.Forms.CheckBox checkBoxSubsetCommon;
        private System.Windows.Forms.CheckBox checkBoxSubsetRight;
        private System.Windows.Forms.CheckBox checkBoxIncludeUnique;
        private System.Windows.Forms.CheckBox checkBoxIncludeNonUnique;
        private System.Windows.Forms.CheckBox checkBoxKeepDuplicates;
        private System.Windows.Forms.CheckBox checkBoxOverwrite;

        private System.Windows.Forms.ComboBox comboBoxEncodingLeft;
        private System.Windows.Forms.ComboBox comboBoxEncodingRight;
        private System.Windows.Forms.ComboBox comboBoxEncodingResult;
        private System.Windows.Forms.ComboBox comboBoxSortResult;
        private System.Windows.Forms.ComboBox comboBoxSaveFolder;
        private System.Windows.Forms.ComboBox comboBoxSaveFileName;
        
        private System.Windows.Forms.GroupBox groupBoxSubsets;
        private System.Windows.Forms.GroupBox groupBoxIncludeLines;
        private System.Windows.Forms.GroupBox groupBoxSort;
        private System.Windows.Forms.GroupBox groupBoxResult;
        
        private System.Windows.Forms.Label labelFileNameLeft;
        private System.Windows.Forms.Label labelFileNameRight;
        private System.Windows.Forms.Label labelEncodingLeft;
        private System.Windows.Forms.Label labelEncodingRight;
        private System.Windows.Forms.Label labelSaveToFileEncoding;
        private System.Windows.Forms.Label labelSaveToFileFolder;
        private System.Windows.Forms.Label labelSaveToFileFileName;

        private System.Windows.Forms.PictureBox pictureBox;

        private System.Windows.Forms.ProgressBar progressBar;
        
        private System.Windows.Forms.TextBox textBoxLeft;
        private System.Windows.Forms.TextBox textBoxRight;
    }
}

