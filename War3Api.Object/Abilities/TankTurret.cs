using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class TankTurret : Ability
    {
        public TankTurret(): base(1970566209)
        {
        }

        public TankTurret(int newId): base(1970566209, newId)
        {
        }

        public TankTurret(string newRawcode): base(1970566209, newRawcode)
        {
        }

        public TankTurret(ObjectDatabase db): base(1970566209, db)
        {
        }

        public TankTurret(int newId, ObjectDatabase db): base(1970566209, newId, db)
        {
        }

        public TankTurret(string newRawcode, ObjectDatabase db): base(1970566209, newRawcode, db)
        {
        }
    }
}