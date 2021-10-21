using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class MeatDrop : Ability
    {
        public MeatDrop(): base(1684368705)
        {
        }

        public MeatDrop(int newId): base(1684368705, newId)
        {
        }

        public MeatDrop(string newRawcode): base(1684368705, newRawcode)
        {
        }

        public MeatDrop(ObjectDatabase db): base(1684368705, db)
        {
        }

        public MeatDrop(int newId, ObjectDatabase db): base(1684368705, newId, db)
        {
        }

        public MeatDrop(string newRawcode, ObjectDatabase db): base(1684368705, newRawcode, db)
        {
        }
    }
}