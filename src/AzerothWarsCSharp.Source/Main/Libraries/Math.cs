public class Math{

  static float GetDistanceBetweenPoints(float xa, float ya, float xb, float yb ){
    float dx = xb - xa;
    float dy = yb - ya;

    return SquareRoot(dx*dx + dy*dy);
	}

	function GetAngleBetweenPoints(float xa, float ya, float xb, float yb ){
		return bj_RADTODEG * Atan2(yb - ya, xb - xa);
	}

	function GetPolarOffsetX(float x, float dist, float angle ){
		return x + dist * Cos(angle * bj_DEGTORAD);
	}

	function GetPolarOffsetY(float y, float dist, float angle ){
		return y + dist * Sin(angle * bj_DEGTORAD);
	}

	function floor(float r ){
		real add = 000;
		if ((r < 000) || (I2R(R2I(r)) == r)){
			add = -100;
		}

		return I2R(R2I(r+add));
	}

	function ceiling(float r ){
		real add = 000;
		if ((r < 000) || (I2R(R2I(r)) == r)){
			add = -100;
		}

		return I2R(R2I(r+100+add));
	}

	function round(float r ){
		real add = 000;
		if ((r < 000) || (I2R(R2I(r)) == r)){
			add = -100;
		}

		return I2R(R2I(r+050+add));
	}

}
