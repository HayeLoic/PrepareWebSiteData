using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using PrepareWebSiteData.Helper;
using PrepareWebSiteData.Images;
using PrepareWebSiteData.Photography;

namespace PrepareWebSiteData.ThreeDwork
{
    public class ThreeDworkService
    {
        private const string ImageMiniatureIdentifier = "miniature";
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

            List<Project> projectsFromJson = this.GetProjectsFromJsonFile(projectsFolder);
            List<Project> projectsFromFolder = this.GetProjectsFromFolder(projectsFolder);
            List<Project> projects = this.MergeOldAndNewProjects(projectsFromJson, projectsFromFolder);
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

        private List<Project> GetProjectsFromJsonFile(string projectsFolder)
        {
            List<Project> projects = new List<Project>();
            foreach (string file in Directory.EnumerateFiles(projectsFolder))
            {
                if (this.jsonhelper.IsJsonFileExtension(file))
                {
                    using (StreamReader streamReader = new StreamReader(file))
                    {
                        string jsonData = streamReader.ReadToEnd();
                        projects = JsonConvert.DeserializeObject<List<Project>>(jsonData);
                    }
                }
            }
            return projects;
        }

        private List<Project> GetProjectsFromFolder(string projectsFolder)
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
                        FileName = Path.GetFileName(file),
                        Location = string.Empty
                    };

                    if (image.FileName.Contains(ImageMiniatureIdentifier))
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

            return projects;
        }

        private List<Project> MergeOldAndNewProjects(List<Project> oldProjects, List<Project> newProjects)
        {
            List<Project> mergedProjects = this.RemoveDeletedProjects(oldProjects, newProjects);
            mergedProjects = this.UpdateProjects(mergedProjects, newProjects);
            mergedProjects = this.AddNewProjects(mergedProjects, newProjects);
            return mergedProjects.OrderBy(project => project.Id).ToList();
        }

        private List<Project> RemoveDeletedProjects(List<Project> oldProjects, List<Project> newProjects)
        {
            List<Project> projectsToRemove = new List<Project>();
            foreach (Project oldProject in oldProjects)
            {
                Project newProjectCorrespondingToOldProject = newProjects.FirstOrDefault(project => project.Repository == oldProject.Repository);
                if (newProjectCorrespondingToOldProject == null)
                {
                    projectsToRemove.Add(oldProject);
                }
            }

            foreach (Project projectToRemove in projectsToRemove)
            {
                oldProjects.Remove(projectToRemove);
            }
            return oldProjects;
        }

        private List<Project> UpdateProjects(List<Project> oldProjects, List<Project> newProjects)
        {
            List<Project> projects = oldProjects;
            foreach (Project newProject in newProjects)
            {
                Project oldProjectCorrespondingToNewProject = oldProjects.FirstOrDefault(project => project.Repository == newProject.Repository);
                if (oldProjectCorrespondingToNewProject != null)
                {
                    newProject.Id = this.GenerateId(projects);
                    newProject.Title = oldProjectCorrespondingToNewProject.Title;
                    newProject.Description = oldProjectCorrespondingToNewProject.Description;
                    newProject.Repository = oldProjectCorrespondingToNewProject.Repository;
                    newProject.ImageMiniature = newProject.ImageMiniature;
                    newProject.Images = this.photographyService.MergeOldAndNewImages(oldProjectCorrespondingToNewProject.Images, newProject.Images);
                    newProject.VimeoLink = oldProjectCorrespondingToNewProject.VimeoLink;
                }
            }
            return projects;
        }

        private List<Project> AddNewProjects(List<Project> oldProjects, List<Project> newProjects)
        {
            List<Project> projects = oldProjects;
            foreach (Project newProject in newProjects)
            {
                Project oldProjectCorrespondingToNewProject = oldProjects.FirstOrDefault(project => project.Repository == newProject.Repository);
                if (oldProjectCorrespondingToNewProject == null)
                {
                    projects.Add(new Project
                    {
                        Id = this.GenerateId(projects),
                        Title = newProject.Title,
                        Description = newProject.Description,
                        Repository = newProject.Repository,
                        ImageMiniature = newProject.ImageMiniature,
                        Images = newProject.Images,
                        VimeoLink = newProject.VimeoLink
                    });
                }
            }
            return projects;
        }
    }
}