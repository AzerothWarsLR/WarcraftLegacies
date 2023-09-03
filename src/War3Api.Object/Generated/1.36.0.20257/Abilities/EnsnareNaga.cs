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
    public sealed class EnsnareNaga : Ability
    {
        public EnsnareNaga(): base(1852132929)
        {
        }

        public EnsnareNaga(int newId): base(1852132929, newId)
        {
        }

        public EnsnareNaga(string newRawcode): base(1852132929, newRawcode)
        {
        }

        public EnsnareNaga(ObjectDatabaseBase db): base(1852132929, db)
        {
        }

        public EnsnareNaga(int newId, ObjectDatabaseBase db): base(1852132929, newId, db)
        {
        }

        public EnsnareNaga(string newRawcode, ObjectDatabaseBase db): base(1852132929, newRawcode, db)
        {
        }
    }
}