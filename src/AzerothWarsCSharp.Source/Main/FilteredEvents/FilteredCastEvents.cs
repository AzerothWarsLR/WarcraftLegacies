public class FilteredCastEvents{

  
    private FilteredEventType FILTEREDEVENTTYPE_SPELL_CHANNEL;
    private FilteredEventType FILTEREDEVENTTYPE_SPELL_CAST;
    private FilteredEventType FILTEREDEVENTTYPE_SPELL_EFFECT;
    private FilteredEventType FILTEREDEVENTTYPE_SPELL_FINISH;
    private FilteredEventType FILTEREDEVENTTYPE_SPELL_ENDCAST;
  

  static void RegisterSpellChannelAction(int spellId, code whichTriggerAction ){
    PlayerUnitEventAddFilteredAction(EVENT_PLAYER_UNIT_SPELL_CHANNEL, whichTriggerAction, FILTEREDEVENTTYPE_SPELL_CHANNEL, spellId);
  }

  static void RegisterSpellCastAction(int spellId, code whichTriggerAction ){
    PlayerUnitEventAddFilteredAction(EVENT_PLAYER_UNIT_SPELL_CAST, whichTriggerAction, FILTEREDEVENTTYPE_SPELL_CAST, spellId);
  }

  static void RegisterSpellEffectAction(int spellId, code whichTriggerAction ){
    PlayerUnitEventAddFilteredAction(EVENT_PLAYER_UNIT_SPELL_EFFECT, whichTriggerAction, FILTEREDEVENTTYPE_SPELL_EFFECT, spellId);
  }

  static void RegisterSpellFinishAction(int spellId, code whichTriggerAction ){
    PlayerUnitEventAddFilteredAction(EVENT_PLAYER_UNIT_SPELL_FINISH, whichTriggerAction, FILTEREDEVENTTYPE_SPELL_FINISH, spellId);
  }

  static void RegisterSpellEndcastAction(int spellId, code whichTriggerAction ){
    PlayerUnitEventAddFilteredAction(EVENT_PLAYER_UNIT_SPELL_ENDCAST, whichTriggerAction, FILTEREDEVENTTYPE_SPELL_ENDCAST, spellId);
  }

  private static void OnAnyUnitSpellChannel( ){
    PlayerUnitEventExecute(EVENT_PLAYER_UNIT_SPELL_CHANNEL, FILTEREDEVENTTYPE_SPELL_CHANNEL, GetSpellAbilityId());
  }

  private static void OnAnyUnitSpellCast( ){
    PlayerUnitEventExecute(EVENT_PLAYER_UNIT_SPELL_CAST, FILTEREDEVENTTYPE_SPELL_CAST, GetSpellAbilityId());
  }

  private static void OnAnyUnitSpellEffect( ){
    PlayerUnitEventExecute(EVENT_PLAYER_UNIT_SPELL_EFFECT, FILTEREDEVENTTYPE_SPELL_EFFECT, GetSpellAbilityId());
  }

  private static void OnAnyUnitSpellFinish( ){
    PlayerUnitEventExecute(EVENT_PLAYER_UNIT_SPELL_FINISH, FILTEREDEVENTTYPE_SPELL_FINISH, GetSpellAbilityId());
  }

  private static void OnAnyUnitSpellEndCast( ){
    PlayerUnitEventExecute(EVENT_PLAYER_UNIT_SPELL_ENDCAST, FILTEREDEVENTTYPE_SPELL_ENDCAST, GetSpellAbilityId());
  }

  private static void OnInit( ){
    PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_SPELL_CHANNEL,  OnAnyUnitSpellChannel);
    PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_SPELL_CAST,  OnAnyUnitSpellCast);
    PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_SPELL_EFFECT,  OnAnyUnitSpellEffect);
    PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_SPELL_FINISH,  OnAnyUnitSpellFinish);
    PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_SPELL_ENDCAST,  OnAnyUnitSpellEndCast);
    FILTEREDEVENTTYPE_SPELL_CHANNEL = FilteredEventType.create();
    FILTEREDEVENTTYPE_SPELL_CAST = FilteredEventType.create();
    FILTEREDEVENTTYPE_SPELL_EFFECT = FilteredEventType.create();
    FILTEREDEVENTTYPE_SPELL_FINISH = FilteredEventType.create();
    FILTEREDEVENTTYPE_SPELL_ENDCAST = FilteredEventType.create();
  }

}
