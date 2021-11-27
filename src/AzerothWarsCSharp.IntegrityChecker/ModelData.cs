using System.IO;

namespace AzerothWarsCSharp.IntegrityChecker
{
  public class ModelData
  {
    private readonly string _fullPath;
    private readonly string _rootMapFolderPath;

    public string RelativePathMdx => Path.GetRelativePath(_rootMapFolderPath, _fullPath);

    public string RelativePathMdl => Path.GetRelativePath(_rootMapFolderPath, Path.ChangeExtension(_fullPath, ".mdl"));

    public ModelData(string fullPath, string rootMapFolderPath)
    {
      _fullPath = fullPath;
      _rootMapFolderPath = rootMapFolderPath;
    }
  }
}