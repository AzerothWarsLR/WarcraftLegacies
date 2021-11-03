using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class CriticalStrikeItem : Ability
    {
        public CriticalStrikeItem(): base(1935886657)
        {
        }

        public CriticalStrikeItem(int newId): base(1935886657, newId)
        {
        }

        public CriticalStrikeItem(string newRawcode): base(1935886657, newRawcode)
        {
        }

        public CriticalStrikeItem(ObjectDatabase db): base(1935886657, db)
        {
        }

        public CriticalStrikeItem(int newId, ObjectDatabase db): base(1935886657, newId, db)
        {
        }

        public CriticalStrikeItem(string newRawcode, ObjectDatabase db): base(1935886657, newRawcode, db)
        {
        }
    }
}