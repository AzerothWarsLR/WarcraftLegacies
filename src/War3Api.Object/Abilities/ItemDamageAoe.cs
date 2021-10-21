using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ItemDamageAoe : Ability
    {
        public ItemDamageAoe(): base(1835288897)
        {
        }

        public ItemDamageAoe(int newId): base(1835288897, newId)
        {
        }

        public ItemDamageAoe(string newRawcode): base(1835288897, newRawcode)
        {
        }

        public ItemDamageAoe(ObjectDatabase db): base(1835288897, db)
        {
        }

        public ItemDamageAoe(int newId, ObjectDatabase db): base(1835288897, newId, db)
        {
        }

        public ItemDamageAoe(string newRawcode, ObjectDatabase db): base(1835288897, newRawcode, db)
        {
        }
    }
}