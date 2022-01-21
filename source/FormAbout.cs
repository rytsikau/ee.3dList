using System;
using System.Windows.Forms;

namespace ee3dList
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();

            // Form window handlers.
            buttonOk.Click += new EventHandler(ButtonOk_Click);
            labelPage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(LabelPage_LinkClicked);
            textBoxAbout.Enter += new EventHandler(TextBox_Enter);
            labelMail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(LabelMail_LinkClicked);

            Info();
        }



        // --------------------------------------
        // Application info.
        void Info()
        {
            labelName.Text = Application.ProductName + " (version 1.2)";
            labelPage.Text = "github.com/rytsikau/ee.3dList";
            labelCondition.Text = "Freeware for non-commercial use";
            labelPage.LinkColor = System.Drawing.Color.Navy;
            textBoxAbout.Text =
                "The tool allows to make a selection of data from two text files, " +
                "choosing and sorting their common and unique lines in different combinations.";
            textBoxLicense.Text =
                "The software is provided \"as is\", without warranty of any kind, express or implied. " +
                "The author will not be liable for data loss, damages, " +
                "loss of profits or any other kind of loss while using or misusing this software.";
            textBoxLicense.Enabled = false;
            labelAuthor.Text = "Copyright(c) 2019-2020 Yauheni Rytsikau";
            labelMail.Text = "y.rytsikau@gmail.com";
            labelMail.LinkColor = System.Drawing.Color.Navy;
        }



        // --------------------------------------
        // Form window events.
        void ButtonOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        void LabelPage_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/rytsikau/ee.3dList");
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            ActiveControl = labelName;
        }

        void LabelMail_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:y.rytsikau@gmail.com?subject=ee.3dList Tool");
        }

    }
}
