using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ManaBurnHotkeyB : Ability
    {
        public ManaBurnHotkeyB(): base(1650617665)
        {
        }

        public ManaBurnHotkeyB(int newId): base(1650617665, newId)
        {
        }

        public ManaBurnHotkeyB(string newRawcode): base(1650617665, newRawcode)
        {
        }

        public ManaBurnHotkeyB(ObjectDatabase db): base(1650617665, db)
        {
        }

        public ManaBurnHotkeyB(int newId, ObjectDatabase db): base(1650617665, newId, db)
        {
        }

        public ManaBurnHotkeyB(string newRawcode, ObjectDatabase db): base(1650617665, newRawcode, db)
        {
        }
    }
}