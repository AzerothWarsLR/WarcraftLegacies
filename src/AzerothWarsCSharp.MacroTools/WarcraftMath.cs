namespace AzerothWarsCSharp.MacroTools
{
	public static class WarcraftMath{

		public static float GetDistanceBetweenPoints(float xa, float ya, float xb, float yb ){
			var dx = xb - xa;
			var dy = yb - ya;
			return SquareRoot(dx*dx + dy*dy);
		}

		public static float GetAngleBetweenPoints(float xa, float ya, float xb, float yb ){
			return bj_RADTODEG * Atan2(yb - ya, xb - xa);
		}

		public static float GetPolarOffsetX(float x, float dist, float angle ){
			return x + dist * Cos(angle * bj_DEGTORAD);
		}

		public static float GetPolarOffsetY(float y, float dist, float angle ){
			return y + dist * Sin(angle * bj_DEGTORAD);
		}

		//Todo: probably don't need this.
		public static float Round(float r ){
			float add = 000;
			if ((r < 000) || I2R(R2I(r)) == r){
				add = -100;
			}
			return I2R(R2I(r+050+add));
		}

	}
}
