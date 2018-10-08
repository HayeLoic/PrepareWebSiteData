using PrepareWebSiteData.Helper;
using System;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;
using PrepareWebSiteData.Photography;
using PrepareWebSiteData.ThreeDwork;

namespace PrepareWebSiteData
{
    public partial class FormMain : Form
    {
        private const int TimerIntervalInSeconds = 3;
        private const string DefaultPhotographiesFolder = @"K:\Loic\Dev\annie-web-site\src\assets\photography";
        private const string Default3DWorkFolder = @"K:\Loic\Dev\annie-web-site\src\assets\three-d-work";
        private JsonHelper jsonhelper;
        private PhotographyService photographyService;
        private ThreeDworkService threeDworkService;

        public FormMain()
        {
            InitializeComponent();
            this.Initialisation();
        }

        private void Initialisation()
        {
            try
            {
                this.jsonhelper = new JsonHelper();
                this.photographyService = new PhotographyService(jsonhelper);
                this.threeDworkService = new ThreeDworkService(jsonhelper, photographyService);
                this.textBoxPhotographiesFolder.Text = DefaultPhotographiesFolder;
                this.textBox3dWorkFolder.Text = Default3DWorkFolder;
                this.SetResultCopiedLabelsVisibility(false);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void buttonReadPhotographies_Click(object sender, EventArgs e)
        {
            try
            {
                this.textBoxPhotographiesResult.Text = this.photographyService.ReadPhotographies(this.textBoxPhotographiesFolder.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void buttonRead3dWork_Click(object sender, EventArgs e)
        {
            try
            {
                this.textBox3dWorkResult.Text = this.threeDworkService.ReadProjects(this.textBox3dWorkFolder.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void buttonCopyPhotographiesResult_Click(object sender, EventArgs e)
        {
            try
            {
                this.CopyResult(this.textBoxPhotographiesResult.Text, this.labelPhotographiesResultCopied);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void buttonCopy3dWorkResult_Click(object sender, EventArgs e)
        {
            try
            {
                this.CopyResult(this.textBox3dWorkResult.Text, this.label3dWorkResultCopied);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void CopyResult(string resultToCopy, Label labelResultCopied)
        {
            if (!string.IsNullOrWhiteSpace(resultToCopy))
            {
                Clipboard.SetText(resultToCopy);
                labelResultCopied.Visible = true;
                timer.Interval = (TimerIntervalInSeconds * 1000);
                timer.Start();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                this.SetResultCopiedLabelsVisibility(false);
                timer.Stop();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void SetResultCopiedLabelsVisibility(bool isVisible)
        {
            this.labelPhotographiesResultCopied.Visible = isVisible;
            this.label3dWorkResultCopied.Visible = isVisible;
        }

        private void buttonSelectPhotographiesFolder_Click(object sender, EventArgs e)
        {
            try
            {
                this.textBoxPhotographiesFolder.Text = this.GetChoosenFolder(this.textBoxPhotographiesFolder.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void buttonSelectProjectsFolder_Click(object sender, EventArgs e)
        {
            try
            {
                this.textBox3dWorkFolder.Text = this.GetChoosenFolder(this.textBox3dWorkFolder.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private string GetChoosenFolder(string previousFolderValue)
        {
            CommonOpenFileDialog commonOpenFileDialog = new CommonOpenFileDialog
            {
                IsFolderPicker = true
            };
            return commonOpenFileDialog.ShowDialog() == CommonFileDialogResult.Ok ? commonOpenFileDialog.FileName : previousFolderValue;
        }
    }
}
