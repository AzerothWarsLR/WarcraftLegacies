using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class PurchaseItem : Ability
    {
        public PurchaseItem(): base(1953067073)
        {
        }

        public PurchaseItem(int newId): base(1953067073, newId)
        {
        }

        public PurchaseItem(string newRawcode): base(1953067073, newRawcode)
        {
        }

        public PurchaseItem(ObjectDatabase db): base(1953067073, db)
        {
        }

        public PurchaseItem(int newId, ObjectDatabase db): base(1953067073, newId, db)
        {
        }

        public PurchaseItem(string newRawcode, ObjectDatabase db): base(1953067073, newRawcode, db)
        {
        }
    }
}