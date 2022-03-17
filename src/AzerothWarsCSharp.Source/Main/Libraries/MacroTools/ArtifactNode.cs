namespace AzerothWarsCSharp.Source.Main.Libraries.MacroTools
{
  public class ArtifactNode
  {
    //A node in an ArtifactGroup

    thistype next = 0;
    thistype prev = 0;

    readonly Artifact whichArtifact;

    boolean hasNext( ){
      if (this.next != 0){
        return true;
      }
      return false;
    }

    thistype (Artifact whichArtifact ){


      this.whichArtifact = whichArtifact;

      ;;
    }
  }
}