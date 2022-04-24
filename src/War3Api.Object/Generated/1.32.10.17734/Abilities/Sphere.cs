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
    public sealed class Sphere : Ability
    {
        public Sphere(): base(1752200001)
        {
        }

        public Sphere(int newId): base(1752200001, newId)
        {
        }

        public Sphere(string newRawcode): base(1752200001, newRawcode)
        {
        }

        public Sphere(ObjectDatabaseBase db): base(1752200001, db)
        {
        }

        public Sphere(int newId, ObjectDatabaseBase db): base(1752200001, newId, db)
        {
        }

        public Sphere(string newRawcode, ObjectDatabaseBase db): base(1752200001, newRawcode, db)
        {
        }
    }
}