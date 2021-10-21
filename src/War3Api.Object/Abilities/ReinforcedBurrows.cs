using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ReinforcedBurrows : Ability
    {
        public ReinforcedBurrows(): base(1919054401)
        {
        }

        public ReinforcedBurrows(int newId): base(1919054401, newId)
        {
        }

        public ReinforcedBurrows(string newRawcode): base(1919054401, newRawcode)
        {
        }

        public ReinforcedBurrows(ObjectDatabase db): base(1919054401, db)
        {
        }

        public ReinforcedBurrows(int newId, ObjectDatabase db): base(1919054401, newId, db)
        {
        }

        public ReinforcedBurrows(string newRawcode, ObjectDatabase db): base(1919054401, newRawcode, db)
        {
        }
    }
}