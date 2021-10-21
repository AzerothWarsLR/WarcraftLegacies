using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ItemInvisGreater : Ability
    {
        public ItemInvisGreater(): base(846612801)
        {
        }

        public ItemInvisGreater(int newId): base(846612801, newId)
        {
        }

        public ItemInvisGreater(string newRawcode): base(846612801, newRawcode)
        {
        }

        public ItemInvisGreater(ObjectDatabase db): base(846612801, db)
        {
        }

        public ItemInvisGreater(int newId, ObjectDatabase db): base(846612801, newId, db)
        {
        }

        public ItemInvisGreater(string newRawcode, ObjectDatabase db): base(846612801, newRawcode, db)
        {
        }
    }
}