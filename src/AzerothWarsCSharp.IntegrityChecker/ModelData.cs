using System.IO;

namespace AzerothWarsCSharp.IntegrityChecker
{
  public readonly struct ModelData
  {
    private readonly string _fullPath;
    private readonly string _rootMapFolderPath;

    public bool IsPortrait { get; }

    public string RelativePathWithoutPortraitSuffixMdl => 
      Path.GetRelativePath(_rootMapFolderPath, Path.ChangeExtension(_fullPath, ".mdl")
      .Replace("_portrait", string.Empty)
      .Replace("_Portrait", string.Empty));

    public string RelativePathMdx => Path.GetRelativePath(_rootMapFolderPath, _fullPath);

    public string RelativePathMdl => Path.GetRelativePath(_rootMapFolderPath, Path.ChangeExtension(_fullPath, ".mdl"));

    public ModelData(string fullPath, string rootMapFolderPath)
    {
      _fullPath = fullPath;
      _rootMapFolderPath = rootMapFolderPath;
      IsPortrait = fullPath.ToLower().Contains("_portrait");
    }
  }
}