using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class Move : Ability
    {
        public Move(): base(1987013953)
        {
        }

        public Move(int newId): base(1987013953, newId)
        {
        }

        public Move(string newRawcode): base(1987013953, newRawcode)
        {
        }

        public Move(ObjectDatabase db): base(1987013953, db)
        {
        }

        public Move(int newId, ObjectDatabase db): base(1987013953, newId, db)
        {
        }

        public Move(string newRawcode, ObjectDatabase db): base(1987013953, newRawcode, db)
        {
        }
    }
}