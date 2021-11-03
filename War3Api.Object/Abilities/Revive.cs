using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class Revive : Ability
    {
        public Revive(): base(1986359873)
        {
        }

        public Revive(int newId): base(1986359873, newId)
        {
        }

        public Revive(string newRawcode): base(1986359873, newRawcode)
        {
        }

        public Revive(ObjectDatabase db): base(1986359873, db)
        {
        }

        public Revive(int newId, ObjectDatabase db): base(1986359873, newId, db)
        {
        }

        public Revive(string newRawcode, ObjectDatabase db): base(1986359873, newRawcode, db)
        {
        }
    }
}