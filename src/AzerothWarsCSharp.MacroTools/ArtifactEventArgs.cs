using System;

namespace AzerothWarsCSharp.MacroTools
{
  public class ArtifactEventArgs : EventArgs
  {
    public Artifact Artifact { get; }
    
    public ArtifactEventArgs(Artifact artifact)
    {
      Artifact = artifact;
    }
  }
}