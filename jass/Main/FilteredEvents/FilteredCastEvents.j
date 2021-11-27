library FilteredCastEvents initializer OnInit requires PlayerUnitEventFilterManager

  globals
    private FilteredEventType FILTEREDEVENTTYPE_SPELL_CHANNEL
    private FilteredEventType FILTEREDEVENTTYPE_SPELL_CAST
    private FilteredEventType FILTEREDEVENTTYPE_SPELL_EFFECT
    private FilteredEventType FILTEREDEVENTTYPE_SPELL_FINISH
    private FilteredEventType FILTEREDEVENTTYPE_SPELL_ENDCAST
  endglobals

  function RegisterSpellChannelAction takes integer spellId, code whichTriggerAction returns nothing
    call PlayerUnitEventAddFilteredAction(EVENT_PLAYER_UNIT_SPELL_CHANNEL, whichTriggerAction, FILTEREDEVENTTYPE_SPELL_CHANNEL, spellId)
  endfunction

  function RegisterSpellCastAction takes integer spellId, code whichTriggerAction returns nothing
    call PlayerUnitEventAddFilteredAction(EVENT_PLAYER_UNIT_SPELL_CAST, whichTriggerAction, FILTEREDEVENTTYPE_SPELL_CAST, spellId)
  endfunction

  function RegisterSpellEffectAction takes integer spellId, code whichTriggerAction returns nothing
    call PlayerUnitEventAddFilteredAction(EVENT_PLAYER_UNIT_SPELL_EFFECT, whichTriggerAction, FILTEREDEVENTTYPE_SPELL_EFFECT, spellId)
  endfunction

  function RegisterSpellFinishAction takes integer spellId, code whichTriggerAction returns nothing
    call PlayerUnitEventAddFilteredAction(EVENT_PLAYER_UNIT_SPELL_FINISH, whichTriggerAction, FILTEREDEVENTTYPE_SPELL_FINISH, spellId)
  endfunction

  function RegisterSpellEndcastAction takes integer spellId, code whichTriggerAction returns nothing
    call PlayerUnitEventAddFilteredAction(EVENT_PLAYER_UNIT_SPELL_ENDCAST, whichTriggerAction, FILTEREDEVENTTYPE_SPELL_ENDCAST, spellId)
  endfunction

  private function OnAnyUnitSpellChannel takes nothing returns nothing
    call PlayerUnitEventExecute(EVENT_PLAYER_UNIT_SPELL_CHANNEL, FILTEREDEVENTTYPE_SPELL_CHANNEL, GetSpellAbilityId())
  endfunction

  private function OnAnyUnitSpellCast takes nothing returns nothing
    call PlayerUnitEventExecute(EVENT_PLAYER_UNIT_SPELL_CAST, FILTEREDEVENTTYPE_SPELL_CAST, GetSpellAbilityId())
  endfunction

  private function OnAnyUnitSpellEffect takes nothing returns nothing
    call PlayerUnitEventExecute(EVENT_PLAYER_UNIT_SPELL_EFFECT, FILTEREDEVENTTYPE_SPELL_EFFECT, GetSpellAbilityId())
  endfunction

  private function OnAnyUnitSpellFinish takes nothing returns nothing
    call PlayerUnitEventExecute(EVENT_PLAYER_UNIT_SPELL_FINISH, FILTEREDEVENTTYPE_SPELL_FINISH, GetSpellAbilityId())
  endfunction

  private function OnAnyUnitSpellEndCast takes nothing returns nothing
    call PlayerUnitEventExecute(EVENT_PLAYER_UNIT_SPELL_ENDCAST, FILTEREDEVENTTYPE_SPELL_ENDCAST, GetSpellAbilityId())
  endfunction

  private function OnInit takes nothing returns nothing
    call PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_SPELL_CHANNEL, function OnAnyUnitSpellChannel)
    call PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_SPELL_CAST, function OnAnyUnitSpellCast)
    call PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_SPELL_EFFECT, function OnAnyUnitSpellEffect)
    call PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_SPELL_FINISH, function OnAnyUnitSpellFinish)
    call PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_SPELL_ENDCAST, function OnAnyUnitSpellEndCast)
    set FILTEREDEVENTTYPE_SPELL_CHANNEL = FilteredEventType.create()
    set FILTEREDEVENTTYPE_SPELL_CAST = FilteredEventType.create()
    set FILTEREDEVENTTYPE_SPELL_EFFECT = FilteredEventType.create()
    set FILTEREDEVENTTYPE_SPELL_FINISH = FilteredEventType.create()
    set FILTEREDEVENTTYPE_SPELL_ENDCAST = FilteredEventType.create()
  endfunction

endlibrary