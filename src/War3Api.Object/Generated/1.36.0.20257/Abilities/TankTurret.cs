using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using War3Api.Object.Abilities;
using War3Api.Object.Enums;
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

        public TankTurret(ObjectDatabaseBase db): base(1970566209, db)
        {
        }

        public TankTurret(int newId, ObjectDatabaseBase db): base(1970566209, newId, db)
        {
        }

        public TankTurret(string newRawcode, ObjectDatabaseBase db): base(1970566209, newRawcode, db)
        {
        }
    }
}