namespace Services.File
{
    public interface IFileService
    {
        Task<ServiceResult<string>> AddFile(Stream file);
    }
}
