namespace AzerothWarsCSharp.Source.Main.Libraries.MacroTools
{
  public class ArtifactGroup
  {
        //A linkedlist of Artifacts for iteration

    static thistype[] artifactGroupsByPlayerId      //A list of ArtifactGroups indexed by player ID, automatically populated by the system
    static Table artifactGroupsByOwningUnit             //A list of ArtifactGroups indexed by the handle ID of the owning unit
    private Table artifactNodesByArtifact               ;//A list of Artifact nodes as indexed by their Artifact ID
    ArtifactNode first
    ArtifactNode last

    void setOwningPersons(Person p ){
      ArtifactNode tempArtifactNode = this.first;
      while(true){
        if ( tempArtifactNode == 0){ break; }
        tempArtifactNode.whichArtifact.setOwningPerson(p);
        tempArtifactNode = tempArtifactNode.next;
      }
    }

    void updateFactions( ){
      ArtifactNode tempArtifactNode = this.first;
      while(true){
        if ( tempArtifactNode == 0){ break; }
        tempArtifactNode.whichArtifact.updateFaction();
        tempArtifactNode = tempArtifactNode.next;
      }
    }

    void destroy( ){
      this.clear();
      this.artifactNodesByArtifact.destroy();
      this.deallocate();
    }

    void clear( ){
      ArtifactNode tempArtifactNode = 0;
      while(true){
        if ( this.last == 0){ break; }
        tempArtifactNode = this.last;
        this.last = this.last.prev;
        tempArtifactNode.destroy();
      }
    }

    void remove(Artifact whichArtifact ){
      ArtifactNode tempArtifactNode = this.artifactNodesByArtifact[whichArtifact];

      tempArtifactNode.prev.next = tempArtifactNode.next;
      tempArtifactNode.next.prev = tempArtifactNode.prev;

      if (this.first == tempArtifactNode){
        this.first = tempArtifactNode.next;
      }

      if (this.last == tempArtifactNode){
        this.last = tempArtifactNode.prev;
      }

      this.artifactNodesByArtifact[whichArtifact] = 0;

      tempArtifactNode.destroy();
    }

    void add(Artifact whichArtifact ){
      ArtifactNode newArtifactNode = ArtifactNode.create(whichArtifact);

      this.last.next = newArtifactNode;
      newArtifactNode.prev = this.last;
      this.last = newArtifactNode;

      if (this.first == 0){
        this.first = newArtifactNode;
      }

      this.artifactNodesByArtifact[whichArtifact] = newArtifactNode;
    }

    thistype ( ){


      this.artifactNodesByArtifact = Table.create();

      ;;
    }

    static void onInit( ){
      int i = 0;
      while(true){
        if ( i > MAX_PLAYERS){ break; }
        thistype.artifactGroupsByPlayerId[i] = thistype.create()    ;//These should really get destroyed at some point if the Person gets destroyed
        i = i + 1;
      }
      thistype.artifactGroupsByOwningUnit = Table.create();
    }
  }
}