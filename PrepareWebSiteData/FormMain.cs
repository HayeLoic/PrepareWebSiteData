using PrepareWebSiteData.Helper;
using System;
using System.Windows.Forms;
using PrepareWebSiteData.Photography;
using PrepareWebSiteData.ThreeDwork;

namespace PrepareWebSiteData
{
    public partial class FormMain : Form
    {
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
    }
}
