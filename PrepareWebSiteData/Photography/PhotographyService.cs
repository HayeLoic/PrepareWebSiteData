using System.Collections.Generic;
using System.IO;
using System.Linq;
using PrepareWebSiteData.Helper;
using PrepareWebSiteData.Images;

namespace PrepareWebSiteData.Photography
{
    public class PhotographyService
    {
        private readonly string[] excludedExtensions = { ".json" };
        private readonly JsonHelper jsonhelper;

        public PhotographyService(JsonHelper jsonhelper)
        {
            this.jsonhelper = jsonhelper;
        }

        public string ReadPhotographies(string photographiesFolder)
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
    }
}