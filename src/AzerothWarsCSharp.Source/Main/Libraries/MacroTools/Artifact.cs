public class Artifact{

  
    Event OnArtifactCreate
    Event OnArtifactAcquire
    Event OnArtifactDrop
    Event OnArtifactDestroy
    Event OnArtifactOwnerChange                     //The owner of this Artifact changes
    Event OnArtifactStatusChange                    //An Artifact changes status
    Event OnArtifactFactionChange                   //The owner of this Artifact changes factions
    Event OnArtifactCarrierOwnerChange              //The unit carrying an Artifact changes player ownership
    Event OnArtifactDescriptionChange               //The Artifact has its description changed. This is just text and is not represented anywhere by the Artifact itself

    const int ARTIFACT_STATUS_GROUND = 0     ;//Artifact is on the ground
    const int ARTIFACT_STATUS_UNIT = 1       ;//Artifact is held by a unit
    const int ARTIFACT_STATUS_SPECIAL = 2    ;//Artifact is nowhere, but artifically has a location
    const int ARTIFACT_STATUS_HIDDEN = 3     ;//Artifact does not allow pinging, and only displays text (which is not set automatically)

    const int ARTIFACT_HOLDER_ABIL_ID = FourCC(A01Y);
  

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



    static Table artifactsByType
    readonly static Artifact triggerArtifact = 0;
    readonly item item = null;
    readonly Person owningPerson = 0;
    private unit owningUnit = null;
    readonly int status = 0;
    readonly string description = null                  ;//More like a situation describer; eg "Owned by xx..." or "Unknown location"
    private boolean titanforged = false;
    private int titanforgedAbility = FourCC(A0VJ)         ;//The extra ability the Artifact gains when it)s Titanforged

    float falseX = 0                                     ;//Where the map should ping this artifact when it is in SPECIAL status mode
    float falseY = 0                                     ;//^

    public void operator TitanforgedAbility=(int value ){
      this.titanforgedAbility = value;
    }

    public boolean operator Titanforged( ){
      ;.titanforged;
    }

    //Grant the Artifact an additional, predefined ability.
    public void Titanforge( ){
      if (this.titanforged == false){
        this.titanforged = true;
        BlzItemAddAbility(this.item, this.titanforgedAbility);
        BlzSetItemExtendedTooltip(this.item, BlzGetItemExtendedTooltip(this.item) + "|n|n|cff800000Titanforged|r|n" + BlzGetAbilityExtendedTooltip(this.titanforgedAbility, 0));
        BlzSetItemDescription(this.item, BlzGetItemDescription(this.item) + "|n|cff800000Titanforged|r");
      }
    }

    void updateFaction( ){
      thistype.triggerArtifact = this;
      OnArtifactFactionChange.fire();
    }

    void setStatus(int i ){
      if (this.status != i){
        this.status = i;
        thistype.triggerArtifact = this;
        OnArtifactStatusChange.fire();
      }
    }

    unit operator OwningUnit( ){
      ;.owningUnit;
    }

    void setOwningUnit(unit u ){
      ArtifactGroup tempArtifactGroup = 0;
      //Remove this Artifact from the ArtifactGroup belonging to the former owning unit, destroying if it is now empty
      tempArtifactGroup = ArtifactGroup.artifactGroupsByOwningUnit[GetHandleId(this.owningUnit)];
      if (tempArtifactGroup != 0){
        tempArtifactGroup.remove(this);
        if (tempArtifactGroup.first == 0){
          tempArtifactGroup.destroy();
        }
      }

      //Transfer ownership
      this.owningUnit = u;

      //Add this Artifact to the ArtifactGroup belonging to this particular unit, first creating it if it doesn)t exist
      if (this.owningUnit != null){
        tempArtifactGroup = ArtifactGroup.artifactGroupsByOwningUnit[GetHandleId(u)];
        if (tempArtifactGroup == 0){
          ArtifactGroup.artifactGroupsByOwningUnit[GetHandleId(u)] = ArtifactGroup.create();
          tempArtifactGroup = ArtifactGroup.artifactGroupsByOwningUnit[GetHandleId(u)];
        }
        tempArtifactGroup.add(this);
      }

      //Change the owner Person if needed
      if (this.owningPerson != Person.ByHandle(GetOwningPlayer(u))){
        if (u != null){
          this.setOwningPerson(Person.ByHandle(GetOwningPlayer(u)));
        }else {
          this.setOwningPerson(0);
        }
      }
    }

    void setOwningPerson(Person p ){
      if (this.owningPerson != 0){
        ArtifactGroup.artifactGroupsByPlayerId[GetPlayerId(this.owningPerson.Player)].remove(this) ;//Remove this from the old owner)s Artifact group
      }

      if (p != 0){
        ArtifactGroup.artifactGroupsByPlayerId[GetPlayerId(p.Player)].add(this) ;//Add this to the new owner)s Artifact Group
      }

      this.owningPerson = p;
      thistype.triggerArtifact = this;
      OnArtifactOwnerChange.fire();

      if (this.owningPerson != 0){
        this.setStatus(ARTIFACT_STATUS_UNIT);
      }else {
        this.setStatus(ARTIFACT_STATUS_GROUND);
      }
    }

    void setDescription(string s ){
      this.description = s;
      thistype.triggerArtifact = this;
      OnArtifactDescriptionChange.fire();
    }

    void pickedUp( ){
      Artifact.triggerArtifact = this;
      this.setOwningUnit(GetTriggerUnit());
      OnArtifactAcquire.fire();
    }

    void dropped( ){
      Shore tempShore = 0;
      Artifact.triggerArtifact = this;

      if (!IsTerrainPathable(GetUnitX(this.owningUnit), GetUnitY(this.owningUnit), PATHING_TYPE_FLOATABILITY) && IsTerrainPathable(GetUnitX(this.owningUnit), GetUnitY(this.owningUnit), PATHING_TYPE_WALKABILITY)){
        if (!UnitAlive(this.owningUnit)){
          tempShore = GetNearestShore(GetUnitX(this.owningUnit), GetUnitY(this.owningUnit));
          this.item = CreateItem(GetItemTypeId(this.item), tempShore.x, tempShore.y);
        }
      }

      //Remove dummy Artifact holding ability if the dropping unit had one
      if (GetUnitAbilityLevel(this.owningUnit, ARTIFACT_HOLDER_ABIL_ID) > 0){
        UnitRemoveAbility(this.owningUnit, ARTIFACT_HOLDER_ABIL_ID);
      }

      this.setOwningPerson(0);
      this.setOwningUnit(null);
      OnArtifactDrop.fire();
    }

    void ping(player p ){
      if (GetLocalPlayer() == p){
        if (this.status == ARTIFACT_STATUS_SPECIAL){
          PingMinimap(this.falseX, this.falseY, 3);
        }else if (this.owningUnit != null){
          PingMinimap(GetUnitX(this.owningUnit), GetUnitY(this.owningUnit), 3);
        }else {
          PingMinimap(GetItemX(this.item), GetItemY(this.item), 3);
        }
      }
    }

    void destroy( ){
      thistype.triggerArtifact = this;
      OnArtifactDestroy.fire();
      RemoveItem(this.item);
      this.item = null;
      this.deallocate();
    }

     Artifact (item whichItem ){

      if (thistype.artifactsByType[GetItemTypeId(whichItem)] == null){
        thistype.artifactsByType[GetItemTypeId(whichItem)] = this;
        thistype.triggerArtifact = this     ;//For event response
        this.item = whichItem;
        this.status = 0;
        this.setOwningPerson(0);
        OnArtifactCreate.fire();
        ;;
      }else {
        BJDebugMsg("ERROR: Attempted to create already existing Artifact from " + GetItemName(whichItem));
        return 0;
      }
    }

    private static void onInit( ){
      thistype.artifactsByType = Table.create();
    }


  static Artifact GetTriggerArtifact( ){
    return Artifact.triggerArtifact;
  }

  private static void ItemPickup( ){
    Artifact tempArtifact = Artifact.artifactsByType[GetItemTypeId(GetManipulatedItem())];
    if (tempArtifact != 0){
      tempArtifact.pickedUp();
    }
  }

  private static void ItemDrop( ){
    Artifact tempArtifact = 0;
    if (!IsUnitIllusion(GetTriggerUnit())){
      tempArtifact = Artifact.artifactsByType[GetItemTypeId(GetManipulatedItem())];
      if (tempArtifact != 0){
        tempArtifact.dropped();
      }
    }
  }

  private static void OnPersonFactionChanged( ){
    ArtifactGroup.artifactGroupsByPlayerId[GetPlayerId(GetTriggerPerson().Player)].updateFactions();
  }

  private static void UnitChangeOwner( ){
    ArtifactGroup tempArtifactGroup = ArtifactGroup.artifactGroupsByOwningUnit[GetHandleId(GetTriggerUnit())];
    if (tempArtifactGroup != 0){
      if (GetTriggerUnit() != null){
        tempArtifactGroup.setOwningPersons(Person.ByHandle(GetOwningPlayer(GetTriggerUnit())));
      }else {
        tempArtifactGroup.setOwningPersons(0);
      }
    }
  }

  private static void OnInit( ){
    trigger trig = CreateTrigger();
    OnPersonFactionChange.register(trig);
    TriggerAddAction(trig,  OnPersonFactionChanged);

    PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_PICKUP_ITEM,  ItemPickup) ;//TODO: use filtered events
    PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_DROP_ITEM,  ItemDrop) ;//TODO: use filtered events
    PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_CHANGE_OWNER,  UnitChangeOwner) ;//TODO: use filtered events

    OnArtifactCreate = Event.create();
    OnArtifactAcquire = Event.create();
    OnArtifactDrop = Event.create();
    OnArtifactDestroy = Event.create();
    OnArtifactOwnerChange = Event.create();
    OnArtifactStatusChange = Event.create();
    OnArtifactFactionChange = Event.create();
    OnArtifactCarrierOwnerChange = Event.create();
    OnArtifactDescriptionChange = Event.create();
  }

}
