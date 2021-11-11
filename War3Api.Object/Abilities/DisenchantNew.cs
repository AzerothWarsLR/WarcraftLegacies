using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Api.Object.Enums;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class DisenchantNew : Ability
    {
        public DisenchantNew(): base(1852007489)
        {
        }

        public DisenchantNew(int newId): base(1852007489, newId)
        {
        }

        public DisenchantNew(string newRawcode): base(1852007489, newRawcode)
        {
        }

        public DisenchantNew(ObjectDatabase db): base(1852007489, db)
        {
        }

        public DisenchantNew(int newId, ObjectDatabase db): base(1852007489, newId, db)
        {
        }

        public DisenchantNew(string newRawcode, ObjectDatabase db): base(1852007489, newRawcode, db)
        {
        }
    }
}