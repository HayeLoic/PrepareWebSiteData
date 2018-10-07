using System.Collections.Generic;

namespace PrepareWebSiteData
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Repository { get; set; }
        public Image ImageMiniature { get; set; }
        public List<Image> Images { get; set; } = new List<Image>();
        public string VimeoLink { get; set; }
    }
}
