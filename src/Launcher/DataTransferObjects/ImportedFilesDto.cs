using War3Net.Build.Import;

namespace Launcher.DataTransferObjects
{
  public class MapImportedFilesDto
  {
    public int FormatVersion { get; set; }
    public ImportedFile[] Files { get; set; }
  }
}