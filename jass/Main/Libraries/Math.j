library Math

  function GetDistanceBetweenPoints takes real xa, real ya, real xb, real yb returns real
    local real dx = xb - xa
    local real dy = yb - ya

    return SquareRoot(dx*dx + dy*dy)
	endfunction  

	function GetAngleBetweenPoints takes real xa, real ya, real xb, real yb returns real
		return bj_RADTODEG * Atan2(yb - ya, xb - xa)
	endfunction  

	function GetPolarOffsetX takes real x, real dist, real angle returns real
		return x + dist * Cos(angle * bj_DEGTORAD)
	endfunction

	function GetPolarOffsetY takes real y, real dist, real angle returns real
		return y + dist * Sin(angle * bj_DEGTORAD)
	endfunction

	function floor takes real r returns real
		local real add = 0.00
		if (r < 0.00) or (I2R(R2I(r)) == r) then
			set add = -1.00
		endif

		return I2R(R2I(r+add))
	endfunction

	function ceiling takes real r returns real
		local real add = 0.00
		if (r < 0.00) or (I2R(R2I(r)) == r) then
			set add = -1.00
		endif

		return I2R(R2I(r+1.00+add))
	endfunction

	function round takes real r returns real
		local real add = 0.00
		if (r < 0.00) or (I2R(R2I(r)) == r) then
			set add = -1.00
		endif

		return I2R(R2I(r+0.50+add))
	endfunction

endlibrary