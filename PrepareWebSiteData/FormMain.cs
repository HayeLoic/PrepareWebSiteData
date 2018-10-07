using PrepareWebSiteData.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PrepareWebSiteData
{
    public partial class FormMain : Form
    {
        private const string defaultPhotographiesFolder = @"K:\Loic\Dev\annie-web-site\src\assets\photography";
        private const string default3dWorkFolder = @"K:\Loic\Dev\annie-web-site\src\assets\three-d-work";
        private const string AssetsFolderIdentifier = @"\assets\";
        private readonly string[] ExcludedExtensions = { ".json" };
        private JsonHelper jsonhelper; 

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
                this.textBoxPhotographiesFolder.Text = defaultPhotographiesFolder;
                this.textBox3dWorkFolder.Text = default3dWorkFolder;
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
                List<Image> images = new List<Image>();
                foreach (string file in Directory.EnumerateFiles(this.textBoxPhotographiesFolder.Text))
                {
                    if (!ExcludedExtensions.Contains(Path.GetExtension(file)))
                    {
                        images.Add(new Image
                        {
                            Id = this.GenerateId(images),
                            FileName = Path.GetFileName(file),
                            Location = string.Empty
                        });
                    }
                }
                
                this.textBoxPhotographiesResult.Text = this.GenerateImageListResult(images);
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
                List<Project> projects = new List<Project>();
                foreach (string directory in Directory.GetDirectories(this.textBox3dWorkFolder.Text))
                {
                    Project project = new Project
                    {
                        Id = GenerateId(projects),
                        Title = Path.GetFileName(directory),
                        Description = Path.GetFileName(directory),
                        Repository = this.GetAssetsRepository(directory)
                    };

                    foreach (string file in Directory.EnumerateFiles(directory))
                    {
                        Image image = new Image
                        {
                            Id = this.GenerateId(project.Images),
                            FileName = Path.GetFileName(file),
                            Location = string.Empty
                        };

                        if (image.FileName.Contains("miniature"))
                        {
                            project.ImageMiniature = image;
                        }
                        else
                        {
                            project.Images.Add(image);
                        }
                    }

                    projects.Add(project);
                }

                this.textBox3dWorkResult.Text = this.StringifyProjects(projects);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private int GenerateId(List<Project> projects)
        {
            if (projects.Count == 0)
            {
                return 1;
            }
            else
            {
                return projects.Max(project => project.Id) + 1;
            }
        }

        private int GenerateId(List<Image> images)
        {
            if (images.Count == 0)
            {
                return 1;
            }
            else
            {
                return images.Max(image => image.Id) + 1;
            }
        }

        private string GetAssetsRepository(string repositoryFullPath)
        {
            int AssetsIndex = repositoryFullPath.IndexOf(AssetsFolderIdentifier);
            string goodPartOfRepositoryFullPath = repositoryFullPath.Substring(AssetsIndex, repositoryFullPath.Length - AssetsIndex);
            return goodPartOfRepositoryFullPath.Replace(@"\","/") + "/";
        }

        private string GenerateImageListResult(List<Image> images)
        {
            return this.jsonhelper.SerializeObject(images);
        }

        private string StringifyProjects(List<Project> projects)
        {
            string result = string.Empty;
            foreach (Project project in projects)
            {
                if (!string.IsNullOrWhiteSpace(result))
                {
                    result += $",{Environment.NewLine}";
                }

                result += $"new Project({{{Environment.NewLine}";
                result += $"id: {project.Id},{Environment.NewLine}";
                result += $"title: '{project.Title}',{Environment.NewLine}";
                result += $"description: '{project.Description}',{Environment.NewLine}";
                result += $"repository: '{project.Repository}',{Environment.NewLine}";
                result += $"imageMiniature: new Image({{fileName: '{project.ImageMiniature.FileName}'}}),{Environment.NewLine}";
                result += $"images: [{Environment.NewLine}";
                result += $"{this.GenerateImageListResult(project.Images)}{Environment.NewLine}";
                result += $"],{Environment.NewLine}";
                result += $"vimeoLink: '{project.VimeoLink}'{Environment.NewLine}";
                result += "})";
            }
            return result;
        }
    }
}
