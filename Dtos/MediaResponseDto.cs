namespace Media_API_project.Dtos
{
    public class MediaResponseDto
    {
        public Guid Id { get; set; }
        public string FilePath { get; set; }
        public string FileType { get; set; }
        public DateTime UploadedAt { get; set; }
    }
}
