using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using War3Api.Object.Abilities;
using War3Api.Object.Enums;
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

        public PurchaseItem(ObjectDatabaseBase db): base(1953067073, db)
        {
        }

        public PurchaseItem(int newId, ObjectDatabaseBase db): base(1953067073, newId, db)
        {
        }

        public PurchaseItem(string newRawcode, ObjectDatabaseBase db): base(1953067073, newRawcode, db)
        {
        }
    }
}