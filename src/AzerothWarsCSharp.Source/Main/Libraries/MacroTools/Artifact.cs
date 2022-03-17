using System;
using System.Collections.Generic;

namespace AzerothWarsCSharp.Source.Main.Libraries.MacroTools
{
  public class Artifact
  {
    public event EventHandler<Artifact> OnArtifactCreate;
    public event EventHandler<Artifact> OnArtifactAcquire;
    public event EventHandler<Artifact> OnArtifactDrop;
    public event EventHandler<Artifact> OnArtifactDestroy;
    public event EventHandler<Artifact> OnArtifactOwnerChange; //The owner of this Artifact changes
    public event EventHandler<Artifact> OnArtifactStatusChange; //An Artifact changes status
    public event EventHandler<Artifact> OnArtifactFactionChange; //The owner of this Artifact changes factions
    public event EventHandler<Artifact> OnArtifactCarrierOwnerChange; //The unit carrying an Artifact changes player ownership
    public event EventHandler<Artifact> OnArtifactDescriptionChange; //The Artifact has its description changed. This is just text and is not represented anywhere by the Artifact itself

    const int ARTIFACT_STATUS_GROUND = 0     ;//Artifact is on the ground
    const int ARTIFACT_STATUS_UNIT = 1       ;//Artifact is held by a unit
    const int ARTIFACT_STATUS_SPECIAL = 2    ;//Artifact is nowhere, but artifically has a location
    const int ARTIFACT_STATUS_HIDDEN = 3     ;//Artifact does not allow pinging, and only displays text (which is not set automatically)

    int ARTIFACT_HOLDER_ABIL_ID = FourCC("A01Y");

    private static Dictionary<int, Artifact> _artifactsByType = new();
    readonly item _item;
    readonly Person _owningPerson;
    private unit _owningUnit;
    private int _status;
    private string _description; //More like a situation describer; eg "Owned by xx..." or "Unknown location"
    private bool _titanforged;
    private int _titanforgedAbility = FourCC("A0VJ")         ;//The extra ability the Artifact gains when it)s Titanforged

    float falseX = 0                                     ;//Where the map should ping this artifact when it is in SPECIAL status mode
    float falseY = 0                                     ;//^

    public int TitanforgedAbility
    {
      set => _titanforgedAbility = value;
    }

    public bool Titanforged => _titanforged;

    //Grant the Artifact an additional, predefined ability.
    public void Titanforge( ){
      if (this._titanforged == false){
        this._titanforged = true;
        BlzItemAddAbility(this._item, this._titanforgedAbility);
        BlzSetItemExtendedTooltip(this._item, BlzGetItemExtendedTooltip(this._item) + "|n|n|cff800000Titanforged|r|n" + BlzGetAbilityExtendedTooltip(this._titanforgedAbility, 0));
        BlzSetItemDescription(this._item, BlzGetItemDescription(this._item) + "|n|cff800000Titanforged|r");
      }
    }

    private void UpdateFaction( ){
      OnArtifactFactionChange?.Invoke(this, this);
    }

    public int Status
    {
      set
      {
        _status = value;
        OnArtifactStatusChange?.Invoke(this, this);
      }
    }

    public unit OwningUnit
    {
      get => _owningUnit;
      set
      {
        ArtifactGroup tempArtifactGroup;
        //Remove this Artifact from the ArtifactGroup belonging to the former owning unit, destroying if it is now empty
        tempArtifactGroup = ArtifactGroup.artifactGroupsByOwningUnit[GetHandleId(this._owningUnit)];
        if (tempArtifactGroup != 0){
          tempArtifactGroup.remove(this);
          if (tempArtifactGroup.first == 0){
            tempArtifactGroup.destroy();
          }
        }

        //Transfer ownership
        this._owningUnit = u;

        //Add this Artifact to the ArtifactGroup belonging to this particular unit, first creating it if it doesn)t exist
        if (this._owningUnit != null){
          tempArtifactGroup = ArtifactGroup.artifactGroupsByOwningUnit[GetHandleId(u)];
          if (tempArtifactGroup == 0){
            ArtifactGroup.artifactGroupsByOwningUnit[GetHandleId(u)] = ArtifactGroup.create();
            tempArtifactGroup = ArtifactGroup.artifactGroupsByOwningUnit[GetHandleId(u)];
          }
          tempArtifactGroup.add(this);
        }

        //Change the owner Person if needed
        if (this._owningPerson != Person.ByHandle(GetOwningPlayer(u))){
          if (u != null){
            this.setOwningPerson(Person.ByHandle(GetOwningPlayer(u)));
          }else {
            this.setOwningPerson(0);
          }
        }
      }
    }

    private void SetOwningPerson(Person p)
    {
      if (this._owningPerson != 0){
        ArtifactGroup.artifactGroupsByPlayerId[GetPlayerId(this._owningPerson.Player)].remove(this) ;//Remove this from the old owner)s Artifact group
      }

      if (p != 0){
        ArtifactGroup.artifactGroupsByPlayerId[GetPlayerId(p.Player)].add(this) ;//Add this to the new owner)s Artifact Group
      }

      this._owningPerson = p;
      OnArtifactOwnerChange?.Invoke(this, this);

      if (this._owningPerson != 0){
        this.setStatus(ARTIFACT_STATUS_UNIT);
      } else {
        this.setStatus(ARTIFACT_STATUS_GROUND);
      }
    }

    public string Description
    {
      set
      {
        _description = value;
        OnArtifactDescriptionChange?.Invoke(this, this);
      }
    }

    private void PickedUp( ){
      this.setOwningUnit(GetTriggerUnit());
      OnArtifactAcquire?.Invoke(this, this);
    }

    void dropped( ){
      Shore tempShore = 0;
      Artifact.TriggerArtifact = this;

      if (!IsTerrainPathable(GetUnitX(this._owningUnit), GetUnitY(this._owningUnit), PATHING_TYPE_FLOATABILITY) && IsTerrainPathable(GetUnitX(this._owningUnit), GetUnitY(this._owningUnit), PATHING_TYPE_WALKABILITY)){
        if (!UnitAlive(this._owningUnit)){
          tempShore = GetNearestShore(GetUnitX(this._owningUnit), GetUnitY(this._owningUnit));
          this._item = CreateItem(GetItemTypeId(this._item), tempShore.x, tempShore.y);
        }
      }

      //Remove dummy Artifact holding ability if the dropping unit had one
      if (GetUnitAbilityLevel(this._owningUnit, ARTIFACT_HOLDER_ABIL_ID) > 0){
        UnitRemoveAbility(this._owningUnit, ARTIFACT_HOLDER_ABIL_ID);
      }

      SetOwningPerson(null);
      OwningUnit = null;
      OnArtifactDrop.Invoke(this, this);
    }

    void ping(player p ){
      if (GetLocalPlayer() == p){
        if (this._status == ARTIFACT_STATUS_SPECIAL){
          PingMinimap(this.falseX, this.falseY, 3);
        }else if (this._owningUnit != null){
          PingMinimap(GetUnitX(this._owningUnit), GetUnitY(this._owningUnit), 3);
        }else {
          PingMinimap(GetItemX(this._item), GetItemY(this._item), 3);
        }
      }
    }

    public void Destroy( ){
      OnArtifactDestroy?.Invoke(this, this);
      RemoveItem(_item);
    }

    Artifact(item whichItem){
      if (thistype.artifactsByType[GetItemTypeId(whichItem)] == null){
        thistype.artifactsByType[GetItemTypeId(whichItem)] = this;
        thistype.triggerArtifact = this     ;//For event response
        this._item = whichItem;
        this._status = 0;
        this.setOwningPerson(0);
        OnArtifactCreate.fire();
        ;;
      }else {
        BJDebugMsg("ERROR: Attempted to create already existing Artifact from " + GetItemName(whichItem));
        return 0;
      }
    }

    private static void ItemPickup( ){
      _artifactsByType[GetItemTypeId(GetManipulatedItem())]?.PickedUp();
    }

    private static void ItemDrop( ){
      Artifact tempArtifact = 0;
      if (!IsUnitIllusion(GetTriggerUnit())){
        tempArtifact = Artifact._artifactsByType[GetItemTypeId(GetManipulatedItem())];
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

    public static void Setup( ){
      var trig = CreateTrigger();
      OnPersonFactionChange.register(trig);
      TriggerAddAction(trig, OnPersonFactionChanged);

      PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_PICKUP_ITEM,  ItemPickup) ;//TODO: use filtered events
      PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_DROP_ITEM,  ItemDrop) ;//TODO: use filtered events
      PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_CHANGE_OWNER,  UnitChangeOwner) ;//TODO: use filtered events
    }

  }
}
