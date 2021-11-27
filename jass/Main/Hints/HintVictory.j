library HintVictory initializer OnInit requires Hint, ControlPointVictory

  private function OnInit takes nothing returns nothing
    call Hint.create("Win the game by capturing " + I2S(GetControlPointsRequiredVictory()) + " Control Points.")
  endfunction

endlibrary