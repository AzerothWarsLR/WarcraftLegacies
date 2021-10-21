using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class WateryMinionItem : Ability
    {
        public WateryMinionItem(): base(1836534081)
        {
        }

        public WateryMinionItem(int newId): base(1836534081, newId)
        {
        }

        public WateryMinionItem(string newRawcode): base(1836534081, newRawcode)
        {
        }

        public WateryMinionItem(ObjectDatabase db): base(1836534081, db)
        {
        }

        public WateryMinionItem(int newId, ObjectDatabase db): base(1836534081, newId, db)
        {
        }

        public WateryMinionItem(string newRawcode, ObjectDatabase db): base(1836534081, newRawcode, db)
        {
        }
    }
}