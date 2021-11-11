using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Api.Object.Enums;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ControlMagicItem : Ability
    {
        public ControlMagicItem(): base(1835223361)
        {
        }

        public ControlMagicItem(int newId): base(1835223361, newId)
        {
        }

        public ControlMagicItem(string newRawcode): base(1835223361, newRawcode)
        {
        }

        public ControlMagicItem(ObjectDatabase db): base(1835223361, db)
        {
        }

        public ControlMagicItem(int newId, ObjectDatabase db): base(1835223361, newId, db)
        {
        }

        public ControlMagicItem(string newRawcode, ObjectDatabase db): base(1835223361, newRawcode, db)
        {
        }
    }
}