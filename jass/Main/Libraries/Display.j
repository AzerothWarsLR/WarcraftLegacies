library Display requires Faction

  function DisplayHint takes player whichPlayer, string msg returns nothing
    call DisplayTextToPlayer(whichPlayer, 0, 0, "\n|cff00ff00HINT|r - " + msg)
    if GetLocalPlayer() == whichPlayer then
      call StartSound(bj_questHintSound)
    endif
  endfunction

  function DisplayHeroReward takes unit whichUnit, integer strength, integer agility, integer intelligence, integer experience returns nothing
    local string display = "\n|cff00ff00HERO REWARD EARNED -" + GetHeroProperName(whichUnit) + "|r"
    if strength > 0 then
      set display = display + "\n+" + I2S(strength) + " Strength"
    endif
    if agility > 0 then
      set display = display + "\n+" + I2S(agility) + " Agility"
    endif
    if intelligence > 0 then
      set display = display + "\n+" + I2S(intelligence) + " Intelligence"
    endif
    if experience > 0 then
      set display = display + "\n+" + I2S(experience) + " Experience"
    endif
    call DisplayTextToPlayer(GetOwningPlayer(whichUnit), 0, 0, display)
    if GetLocalPlayer() == GetOwningPlayer(whichUnit) then
      call StartSound(bj_questHintSound)
    endif
  endfunction

  function DisplayUnitLimit takes Faction whichFaction, integer unitTypeId returns nothing
    call DisplayTextToPlayer(whichFaction.Player, 0, 0, "\n|cff00ff00UNIT LIMIT CHANGED - " + GetObjectName(unitTypeId) + "|r\nYou can now train up to " + I2S(whichFaction.objectLimits[unitTypeId]) + " " + GetObjectName(unitTypeId) + "s.")
    if GetLocalPlayer() == whichFaction.Player then
      call StartSound(bj_questHintSound)
    endif
  endfunction

  function DisplayResearchAcquired takes player whichPlayer, integer researchId, integer researchLevel returns nothing
    call DisplayTextToPlayer(whichPlayer, 0, 0, "\n|cff00ff00RESEARCH ACQUIRED - " + GetObjectName(researchId) + "|r\n" + BlzGetAbilityExtendedTooltip(researchId, researchLevel))
    if GetLocalPlayer() == whichPlayer then
      call StartSound(bj_questHintSound)
    endif
  endfunction

  function DisplayUnitTypeAcquired takes player whichPlayer, integer unitId, string flavor returns nothing
    call DisplayTextToPlayer(whichPlayer, 0, 0, "\n|cff00ff00NEW UNIT ACQUIRED - " + GetObjectName(unitId) + "\n|r" + flavor)
    if GetLocalPlayer() == whichPlayer then
      call StartSound(bj_questHintSound)
    endif
  endfunction

  function DisplaySoloPath takes Faction whichFaction, string flavour returns nothing
    local string display = "\n|cffffcc00PATH - " + whichFaction.prefixCol + whichFaction.Name + "|r\n" + flavour + "\n"
    call StartSound(bj_rescueSound)
    call DisplayTextToPlayer(GetLocalPlayer(), 0, 0, display)
  endfunction

endlibrary