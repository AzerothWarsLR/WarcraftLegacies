library ResearchSetup requires TierHighSorcererAndromath, TierKatranaPrestor

  public function OnInit takes nothing returns nothing
    call TierHighSorcererAndromath_OnInit()
    call TierKatranaPrestor_OnInit()
  endfunction

endlibrary