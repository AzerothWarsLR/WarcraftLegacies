-- https://github.com/Orden4/CSharp.lua/blob/4cb973f/CSharp.lua/CoreSystem.Lua/CoreSystem/Exception.lua
local function traceback()
  local trace, separator = "", ""
  local _, lastFile, tracePiece, lastTracePiece
  for loopDepth = 3, 200 do
    _, tracePiece = pcall(error, "", loopDepth)
    if #tracePiece > 0 and lastTracePiece ~= tracePiece then
      trace = trace .. separator .. ((tracePiece:match("^.-:") == lastFile) and tracePiece:match(":%d+"):sub(2, -1) or tracePiece:match("^.-:%d+"))
      lastFile, lastTracePiece, separator = tracePiece:match("^.-:"), tracePiece, " <- "
    end
  end
  return trace
end

System.traceback = traceback

System.Exception.traceback = function(this, lv)
  this.errorStack = traceback("", lv and lv + 3 or 3):gsub("^%s*(.-)%s*$", "%1")
end
