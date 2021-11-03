using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ShadowHunterVoodooo : Ability
    {
        public ShadowHunterVoodooo(): base(1685475137)
        {
        }

        public ShadowHunterVoodooo(int newId): base(1685475137, newId)
        {
        }

        public ShadowHunterVoodooo(string newRawcode): base(1685475137, newRawcode)
        {
        }

        public ShadowHunterVoodooo(ObjectDatabase db): base(1685475137, db)
        {
        }

        public ShadowHunterVoodooo(int newId, ObjectDatabase db): base(1685475137, newId, db)
        {
        }

        public ShadowHunterVoodooo(string newRawcode, ObjectDatabase db): base(1685475137, newRawcode, db)
        {
        }
    }
}