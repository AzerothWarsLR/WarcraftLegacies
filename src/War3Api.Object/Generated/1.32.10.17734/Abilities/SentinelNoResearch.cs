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
    public sealed class SentinelNoResearch : Ability
    {
        public SentinelNoResearch(): base(1920165185)
        {
        }

        public SentinelNoResearch(int newId): base(1920165185, newId)
        {
        }

        public SentinelNoResearch(string newRawcode): base(1920165185, newRawcode)
        {
        }

        public SentinelNoResearch(ObjectDatabaseBase db): base(1920165185, db)
        {
        }

        public SentinelNoResearch(int newId, ObjectDatabaseBase db): base(1920165185, newId, db)
        {
        }

        public SentinelNoResearch(string newRawcode, ObjectDatabaseBase db): base(1920165185, newRawcode, db)
        {
        }
    }
}