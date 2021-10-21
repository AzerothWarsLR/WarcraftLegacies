using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ItemInvulLesser : Ability
    {
        public ItemInvulLesser(): base(1819691329)
        {
        }

        public ItemInvulLesser(int newId): base(1819691329, newId)
        {
        }

        public ItemInvulLesser(string newRawcode): base(1819691329, newRawcode)
        {
        }

        public ItemInvulLesser(ObjectDatabase db): base(1819691329, db)
        {
        }

        public ItemInvulLesser(int newId, ObjectDatabase db): base(1819691329, newId, db)
        {
        }

        public ItemInvulLesser(string newRawcode, ObjectDatabase db): base(1819691329, newRawcode, db)
        {
        }
    }
}