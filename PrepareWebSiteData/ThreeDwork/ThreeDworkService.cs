using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PrepareWebSiteData.Helper;
using PrepareWebSiteData.Images;
using PrepareWebSiteData.Photography;

namespace PrepareWebSiteData.ThreeDwork
{
    public class ThreeDworkService
    {
        private const string AssetsFolderIdentifier = @"\assets\";
        private readonly JsonHelper jsonhelper;
        private readonly PhotographyService photographyService;
        
        public ThreeDworkService(JsonHelper jsonhelper, PhotographyService photographyService)
        {
            this.jsonhelper = jsonhelper;
            this.photographyService = photographyService;
        }

        public string ReadProjects(string projectsFolder)
        {
            List<Project> projects = new List<Project>();
            foreach (string directory in Directory.GetDirectories(projectsFolder))
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
                        Id = this.photographyService.GenerateId(project.Images),
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

            return this.jsonhelper.SerializeObject(projects);
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

        private string GetAssetsRepository(string repositoryFullPath)
        {
            int assetsIndex = repositoryFullPath.IndexOf(AssetsFolderIdentifier, StringComparison.Ordinal);
            string goodPartOfRepositoryFullPath = repositoryFullPath.Substring(assetsIndex, repositoryFullPath.Length - assetsIndex);
            return goodPartOfRepositoryFullPath.Replace(@"\", "/") + "/";
        }
    }
}