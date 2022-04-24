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
    public sealed class FirelordIncinerate_ANia : Ability
    {
        public FirelordIncinerate_ANia(): base(1634291265)
        {
        }

        public FirelordIncinerate_ANia(int newId): base(1634291265, newId)
        {
        }

        public FirelordIncinerate_ANia(string newRawcode): base(1634291265, newRawcode)
        {
        }

        public FirelordIncinerate_ANia(ObjectDatabaseBase db): base(1634291265, db)
        {
        }

        public FirelordIncinerate_ANia(int newId, ObjectDatabaseBase db): base(1634291265, newId, db)
        {
        }

        public FirelordIncinerate_ANia(string newRawcode, ObjectDatabaseBase db): base(1634291265, newRawcode, db)
        {
        }
    }
}