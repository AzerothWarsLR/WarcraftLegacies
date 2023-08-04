namespace Launcher.DataTransferObjects
{
  public class ImportedFilesDto
  {
    public int FormatVersion { get; set; }
    public FileDto[] Files { get; set; }
  }

  public class FileDto
  {
    public int Flags { get; set; }
    public string FullPath { get; set; }
  }
}