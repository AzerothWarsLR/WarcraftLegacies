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
    public sealed class ResurrectionItem : Ability
    {
        public ResurrectionItem(): base(2020755777)
        {
        }

        public ResurrectionItem(int newId): base(2020755777, newId)
        {
        }

        public ResurrectionItem(string newRawcode): base(2020755777, newRawcode)
        {
        }

        public ResurrectionItem(ObjectDatabaseBase db): base(2020755777, db)
        {
        }

        public ResurrectionItem(int newId, ObjectDatabaseBase db): base(2020755777, newId, db)
        {
        }

        public ResurrectionItem(string newRawcode, ObjectDatabaseBase db): base(2020755777, newRawcode, db)
        {
        }
    }
}