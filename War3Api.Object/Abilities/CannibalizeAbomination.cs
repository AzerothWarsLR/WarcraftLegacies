using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Api.Object.Enums;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class CannibalizeAbomination : Ability
    {
        public CannibalizeAbomination(): base(846095169)
        {
        }

        public CannibalizeAbomination(int newId): base(846095169, newId)
        {
        }

        public CannibalizeAbomination(string newRawcode): base(846095169, newRawcode)
        {
        }

        public CannibalizeAbomination(ObjectDatabase db): base(846095169, db)
        {
        }

        public CannibalizeAbomination(int newId, ObjectDatabase db): base(846095169, newId, db)
        {
        }

        public CannibalizeAbomination(string newRawcode, ObjectDatabase db): base(846095169, newRawcode, db)
        {
        }
    }
}