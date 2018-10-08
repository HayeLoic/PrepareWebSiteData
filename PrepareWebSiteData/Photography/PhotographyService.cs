﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using PrepareWebSiteData.Helper;
using PrepareWebSiteData.Images;

namespace PrepareWebSiteData.Photography
{
    public class PhotographyService
    {
        private const string JsonFileExtension = ".json";
        private readonly string[] excludedExtensions = { JsonFileExtension };
        private readonly JsonHelper jsonhelper;

        public PhotographyService(JsonHelper jsonhelper)
        {
            this.jsonhelper = jsonhelper;
        }

        public string ReadPhotographies(string photographiesFolder)
        {
            List<Image> imagesFromJson = this.GetImagesFromJsonFile(photographiesFolder);
            List<Image> imagesFromFolder = this.GetImagesFromFolder(photographiesFolder);
            List<Image> images = this.MergeOldAndNewImages(imagesFromJson, imagesFromFolder);
            return this.jsonhelper.SerializeObject(images);
        }

        public int GenerateId(List<Image> images)
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

        private List<Image> GetImagesFromJsonFile(string photographiesFolder)
        {
            List<Image> images = new List<Image>();
            foreach (string file in Directory.EnumerateFiles(photographiesFolder))
            {
                if (this.IsJsonFileExtension(file))
                {
                    using (StreamReader streamReader = new StreamReader(file))
                    {
                        string jsonData = streamReader.ReadToEnd();
                        images = JsonConvert.DeserializeObject<List<Image>>(jsonData);
                    }
                }
            }
            return images;
        }

        private List<Image> GetImagesFromFolder(string photographiesFolder)
        {
            List<Image> images = new List<Image>();
            foreach (string file in Directory.EnumerateFiles(photographiesFolder))
            {
                if (!excludedExtensions.Contains(Path.GetExtension(file)))
                {
                    images.Add(new Image
                    {
                        Id = this.GenerateId(images),
                        FileName = Path.GetFileName(file),
                        Location = string.Empty
                    });
                }
            }
            return images;
        }

        private List<Image> MergeOldAndNewImages(List<Image> oldImages, List<Image> newImages)
        {
            List<Image> mergedImages = this.RemoveDeletedImages(oldImages, newImages);
            mergedImages = this.AddNewImages(mergedImages, newImages);
            return mergedImages.OrderBy(image => image.Id).ToList();
        }

        private List<Image> RemoveDeletedImages(List<Image> oldImages, List<Image> newImages)
        {
            List<Image> imagesToRemove = new List<Image>();
            foreach (Image oldImage in oldImages)
            {
                Image newImageCorrespondingToOldImage = newImages.FirstOrDefault(image => image.FileName == oldImage.FileName);
                if (newImageCorrespondingToOldImage == null)
                {
                    imagesToRemove.Add(oldImage);
                }
            }

            foreach (Image imageToRemove in imagesToRemove)
            {
                oldImages.Remove(imageToRemove);
            }
            return oldImages;
        }

        private List<Image> AddNewImages(List<Image> oldImages, List<Image> newImages)
        {
            List<Image> images = oldImages;
            foreach (Image newImage in newImages)
            {
                Image oldImageCorrespondingToNewImage = oldImages.FirstOrDefault(image => image.FileName == newImage.FileName);
                if (oldImageCorrespondingToNewImage == null)
                {
                    images.Add(new Image
                    {
                        Id = this.GenerateId(images),
                        FileName = newImage.FileName,
                        Location = newImage.Location
                    });
                }
            }
            return images;
        }

        private bool IsJsonFileExtension(string fileFullPath)
        {
            return Path.GetExtension(fileFullPath) == JsonFileExtension;
        }
    }
}