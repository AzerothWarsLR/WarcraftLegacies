using System;
using System.Collections.Generic;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Libraries
{
  public class FactionEventArgs : EventArgs
  {
    public FactionEventArgs(Faction faction)
    {
      Faction = faction;
    }

    public Faction Faction { get; }
  }
  public class FactionChangesTeamArgs
  {
    public Faction FactionChangingTeam;
    public Team PreviousTeam;
  }

  public class FactionQuestProgressChangedArgs
  {
    public Faction Faction;
    public QuestEx QuestEx;
    public QuestProgress PreviousProgress;
  }

  public class FactionQuestAddedArgs
  {
    public Faction Faction;
    public QuestEx QuestEx;
  }

  public class Faction
  {
    public static int UNLIMITED { get; } = 200;

    public static HashSet<Faction> All { get; } = new();

    public EventHandler<FactionChangesTeamArgs> ChangesTeam { get; set; }
    public EventHandler<FactionEventArgs> ChangesPerson { get; set; }
    public EventHandler<FactionEventArgs> ObjectLevelChanged { get; set; }
    public EventHandler<FactionQuestAddedArgs> QuestAdded { get; set; }
    public EventHandler<FactionQuestProgressChangedArgs> QuestProgressChanged { get; set; }
    public static EventHandler<FactionEventArgs> FactionCreated { get; set; }

    public Faction(string name, playercolor playercolor, string prefixColor, string icon, int weight)
    {
      Name = name;
      PlayerColor = playercolor;
      PrefixColor = prefixColor;
      Icon = icon;
      Weight = weight;
      FactionCreated?.Invoke(this, new FactionEventArgs(this));
      All.Add(this);
    }

    /// <summary>
    /// A research that is enabled for all players whenever this Faction is occupied.
    /// </summary>
    public int PresenceResearch
    {
      get;
    }

    /// <summary>
    /// A research that is enabled for all players whenever this Faction is not occupied.
    /// </summary>
    public int AbsenceResearch
    {
      get;
    }

    /// <summary>
    /// Unlike native gold, this can be fractional.
    /// </summary>
    public float Gold
    {
      get
      {
        throw new NotImplementedException();
      }
      set
      {
        throw new NotImplementedException();
      }
    }

    /// <summary>
    /// Unlike native lumber, this can be fractional.
    /// </summary>
    public float Lumber
    {
      get
      {
        throw new NotImplementedException();
      }
      set
      {
        throw new NotImplementedException();
      }
    }

    /// <summary>
    /// An estimation of this faction's techtree strength.
    /// </summary>
    public int Weight
    {
      get;
    }

    /// <summary>
    /// Gold earned per second.
    /// </summary>
    /// <returns></returns>
    public float Income
    {
      get
      {
        throw new NotImplementedException();
      }
      set
      {
        throw new NotImplementedException();
      }
    }

    /// <summary>
    /// Which Team this Faction currently belongs to. Determines a player's allies.
    /// </summary>
    public Team Team
    {
      get
      {
        throw new NotImplementedException();
      }
      set
      {
        throw new NotImplementedException();
      }
    }

    /// <summary>
    /// Faction's name that appears in user interface.
    /// </summary>
    public string Name
    {
      get;
    }

    /// <summary>
    /// The string that goes before the faction's name to color it.
    /// </summary>
    public string PrefixColor
    {
      get;
    }

    /// <summary>
    /// Faction's name with a color prefix.
    /// </summary>
    public string ColoredName
    {
      get
      {
        return PrefixColor + Name;
      }
    }

    public string Icon { get;  }

    public int ControlPoints { get; private set; }

    /// <summary>
    /// Player currently occupying this Faction.
    /// </summary>
    public player Player
    {
      get
      {
        throw new NotImplementedException();
      }
    }

    /// <summary>
    /// Person currently occupying this Faction.
    /// </summary>
    public Person Person
    {
      get
      {
        throw new NotImplementedException();
      }
      set
      {
        throw new NotImplementedException();
      }
    }

    /// <summary>
    /// Quest that pops up for this Faction early on as an introduction.
    /// </summary>
    public QuestEx StartingQuest
    {
      get;
      set;
    }

    /// <summary>
    /// Music that plays when this team wins the game.
    /// </summary>
    public string VictoryMusic { get; set; }

    /// <summary>
    /// Whether or not this Faction can be invited to join a team.
    /// </summary>
    public virtual bool CanBeInvited {
      get
      {
        return true;
      }
    }

    /// <summary>
    /// The WC3 player color of this faction in-game.
    /// </summary>
    public playercolor PlayerColor
    {
      get; set;
    }

    /// <summary>
    /// Adds a Quest to this Faction's quest log.
    /// </summary>
    /// <param name="quest"></param>
    public void AddQuest(QuestEx quest)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Sets the research level of an object to a value.
    /// </summary>
    public void SetObjectLevel(int obj, int level)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Changes this Faction's research or unit limit by a provided value.
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="limit"></param>
    public void ModObjectLimit(int obj, int limit)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Causes a Faction's player to lose all units and resources.
    /// </summary>
    public void Obliterate()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Causes a Faction's player to distribute all units and resources amongst allies.
    /// </summary>
    public void Leave()
    {
      throw new NotImplementedException();
    }
  }
}
