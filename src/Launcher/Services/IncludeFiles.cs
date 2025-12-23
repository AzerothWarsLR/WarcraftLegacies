using System;

namespace Launcher.Services;

[Flags]
public enum IncludeFiles
{
  Sounds = 1,
  Terrain = 2,
  Regions = 4,
  Info = 8,
  ObjectData = 16,
  Script = 32,
  Objects = 64,
  Imports = 128,
  All = Sounds | Terrain | Regions | Info | ObjectData | Script | Objects | Imports
}
