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
    public sealed class RuneManaRestoreAoe : Ability
    {
        public RuneManaRestoreAoe(): base(1919766593)
        {
        }

        public RuneManaRestoreAoe(int newId): base(1919766593, newId)
        {
        }

        public RuneManaRestoreAoe(string newRawcode): base(1919766593, newRawcode)
        {
        }

        public RuneManaRestoreAoe(ObjectDatabaseBase db): base(1919766593, db)
        {
        }

        public RuneManaRestoreAoe(int newId, ObjectDatabaseBase db): base(1919766593, newId, db)
        {
        }

        public RuneManaRestoreAoe(string newRawcode, ObjectDatabaseBase db): base(1919766593, newRawcode, db)
        {
        }
    }
}