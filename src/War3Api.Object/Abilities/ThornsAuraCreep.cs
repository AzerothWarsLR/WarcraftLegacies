using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ThornsAuraCreep : Ability
    {
        public ThornsAuraCreep(): base(1751204673)
        {
        }

        public ThornsAuraCreep(int newId): base(1751204673, newId)
        {
        }

        public ThornsAuraCreep(string newRawcode): base(1751204673, newRawcode)
        {
        }

        public ThornsAuraCreep(ObjectDatabase db): base(1751204673, db)
        {
        }

        public ThornsAuraCreep(int newId, ObjectDatabase db): base(1751204673, newId, db)
        {
        }

        public ThornsAuraCreep(string newRawcode, ObjectDatabase db): base(1751204673, newRawcode, db)
        {
        }
    }
}