namespace Media_API_project.Entities
{
    public class Media
    {
        public Guid Id { get; set; }
        public string FilePath { get; set; } = default!;
        public string FileType { get; set; } = default!;
        public DateTime UploadedAt { get; set; }
    }
}
