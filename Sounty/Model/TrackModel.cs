namespace Sounty.Model
{
    class TrackModel
    {
        public string Path      { get; set; }
        public string Name      { get; set; }
        public string ImagePath { get; set; }

        public TrackModel(string path, string name, string imagePath)
        {
            Path = path;
            Name = name;
            ImagePath = imagePath;
        }
    }
}
