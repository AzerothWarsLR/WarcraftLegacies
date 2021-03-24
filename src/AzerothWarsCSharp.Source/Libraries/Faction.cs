using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static War3Api.Common;

namespace AzerothWarsCSharp.Template.Source.Libraries
{
  public class FactionEventArgs : EventArgs
  {
    public Faction Faction;
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
    public static readonly int UNLIMITED = 200;

    public static EventHandler<FactionChangesTeamArgs> ChangesTeam;

    public static EventHandler<FactionEventArgs> ChangesPerson;

    public static EventHandler<FactionEventArgs> ObjectLevelChanged;

    public static EventHandler<FactionQuestAddedArgs> QuestAdded;

    public static EventHandler<FactionQuestProgressChangedArgs> QuestProgressChanged;

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
    /// Faction's name with a color prefix.
    /// </summary>
    public string ColoredName
    {
      get
      {
        throw new NotImplementedException();
      }
    }

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
