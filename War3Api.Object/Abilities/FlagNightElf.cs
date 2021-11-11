using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Api.Object.Enums;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class FlagNightElf : Ability
    {
        public FlagNightElf(): base(1852197185)
        {
        }

        public FlagNightElf(int newId): base(1852197185, newId)
        {
        }

        public FlagNightElf(string newRawcode): base(1852197185, newRawcode)
        {
        }

        public FlagNightElf(ObjectDatabase db): base(1852197185, db)
        {
        }

        public FlagNightElf(int newId, ObjectDatabase db): base(1852197185, newId, db)
        {
        }

        public FlagNightElf(string newRawcode, ObjectDatabase db): base(1852197185, newRawcode, db)
        {
        }
    }
}