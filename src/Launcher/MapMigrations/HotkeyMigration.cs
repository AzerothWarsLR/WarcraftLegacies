using System;
using War3Api.Object;
using War3Net.Build;

namespace Launcher.MapMigrations
{
    /// <summary>
    /// Migrates hotkeys for abilities and units based on their button position fields, excluding upgrades.
    /// </summary>
    public sealed class HotkeyMigration : IMapMigration
    {
        public void Migrate(Map map, ObjectDatabase objectDatabase)
        {
        
            foreach (var ability in objectDatabase.GetAbilities())
            {
                try
                {
                    SetAbilityHotkey(ability);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to migrate hotkey for ability {ability.TextName}: {ex}");
                }
            }

         
            foreach (var unit in objectDatabase.GetUnits())
            {
                try
                {
                    SetUnitHotkey(unit);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to migrate hotkey for unit {unit.TextName}: {ex}");
                }
            }

          
            map.AbilityObjectData = objectDatabase.GetAllData().AbilityData;
            map.UnitObjectData = objectDatabase.GetAllData().UnitData;
        }

        private static void SetAbilityHotkey(Ability ability)
        {
            var x = ability.ArtButtonPositionNormalX;
            var y = ability.ArtButtonPositionNormalY;

            var hotkey = DetermineAbilityHotkey(x, y);

            if (hotkey.HasValue)
            {
                ability.TextHotkeyNormal = hotkey.Value;
            }
        }

        private static void SetUnitHotkey(Unit unit)
        {
            var x = unit.ArtButtonPositionX;
            var y = unit.ArtButtonPositionY;

            var hotkey = DetermineUnitHotkey(x, y);

            if (hotkey.HasValue)
            {
                unit.TextHotkey = hotkey.Value;
            }
        }

        private static char? DetermineAbilityHotkey(int x, int y)
        {
          
            return (x, y) switch
            {
                (0, 2) => 'Q',
                (1, 2) => 'W',
                (2, 2) => 'E',
                (3, 2) => 'R',
                (1, 1) => 'D',
                _ => null 
            };
        }

        private static char? DetermineUnitHotkey(int x, int y)
        {
    
            return (x, y) switch
            {
                (0, 0) => 'Q',
                (1, 0) => 'W',
                (2, 0) => 'E',
                (3, 0) => 'R',
                _ => null 
            };
        }
    }
}