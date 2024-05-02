using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

using War3Api.Object.Enums;

using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object
{
    public sealed class ObjectDatabase : ObjectDatabaseBase
    {
        private static readonly Lazy<ObjectDatabase> _defaultDatabase = new();
        private static readonly Lazy<HashSet<int>> _techTypes = new(() => GetTechTypes().ToHashSet());

        private readonly HashSet<int> _reservedKeys;
        private readonly HashSet<int> _reservedTechs;
        private readonly Dictionary<int, BaseObject> _objects;

        public ObjectDatabase()
            : this(GetDefaultReservedKeys(), LazyStandardObjectDatabase.GetStandardDatabase())
        {
        }

        public ObjectDatabase(ObjectDatabaseBase? fallbackDatabase)
            : this(GetDefaultReservedKeys(), fallbackDatabase)
        {
        }

        public ObjectDatabase(IEnumerable<int> reservedKeys, ObjectDatabaseBase? fallbackDatabase)
            : base(fallbackDatabase)
        {
            _reservedKeys = reservedKeys.ToHashSet();
            _reservedTechs = new();
            _objects = new();
        }

        public static ObjectDatabase DefaultDatabase => _defaultDatabase.Value;

        public override bool TryGetObject(int id, [NotNullWhen(true)] out BaseObject? baseObject)
        {
            if (_objects.TryGetValue(id, out baseObject))
            {
                return true;
            }

            var fallback = FallbackDatabase;
            while (fallback is not null)
            {
                if (fallback.TryGetObject(id, out var fallbackObject))
                {
                    baseObject = BaseObject.ShallowCopy(fallbackObject, this);
                    return true;
                }

                fallback = fallback.FallbackDatabase;
            }

            return false;
        }

        public IEnumerable<Unit> GetUnits()
        {
            return _objects.CastWhere<int, BaseObject, Unit>();
        }

        public IEnumerable<Item> GetItems()
        {
            return _objects.CastWhere<int, BaseObject, Item>();
        }

        public IEnumerable<Destructable> GetDestructables()
        {
            return _objects.CastWhere<int, BaseObject, Destructable>();
        }

        public IEnumerable<Doodad> GetDoodads()
        {
            return _objects.CastWhere<int, BaseObject, Doodad>();
        }

        public IEnumerable<Ability> GetAbilities()
        {
            return _objects.CastWhere<int, BaseObject, Ability>();
        }

        public IEnumerable<Buff> GetBuffs()
        {
            return _objects.CastWhere<int, BaseObject, Buff>();
        }

        public IEnumerable<Upgrade> GetUpgrades()
        {
            return _objects.CastWhere<int, BaseObject, Upgrade>();
        }

        public void AddObjects(UnitObjectData unitObjectData, UnitObjectData unitSkinObjectData)
        {
            foreach (var baseUnit in unitObjectData.BaseUnits) 
              AddOrModifyOldUnit(baseUnit);
            
            foreach (var newUnit in unitObjectData.NewUnits) 
              AddOrModifyNewUnit(newUnit);

            foreach (var baseUnit in unitSkinObjectData.BaseUnits) 
              AddOrModifyOldUnit(baseUnit);

            foreach (var newUnit in unitSkinObjectData.NewUnits)
              AddOrModifyNewUnit(newUnit);

            Unit AddOrModifyOldUnit(SimpleObjectModification simpleObjectModification)
            {
              if (this.TryGetUnit(simpleObjectModification.OldId, out var existingUnit))
              {
                existingUnit.AddModifications(simpleObjectModification.Modifications);
                return existingUnit;
              }
              var newUnit = new Unit((UnitType)simpleObjectModification.OldId, this);
              newUnit.AddModifications(simpleObjectModification.Modifications);
              return newUnit;
            }
            
            void AddOrModifyNewUnit(SimpleObjectModification simpleObjectModification)
             {
               if (this.TryGetUnit(simpleObjectModification.NewId, out var existingUnit))
               {
                 existingUnit.AddModifications(simpleObjectModification.Modifications);
                 return;
               }
               var newUnit = new Unit((UnitType)simpleObjectModification.OldId, simpleObjectModification.NewId, this);
               newUnit.AddModifications(simpleObjectModification.Modifications);
               return;
             }
        }

        public void AddObjects(ItemObjectData itemObjectData, ItemObjectData itemSkinObjectData)
        {
          foreach (var baseItem in itemObjectData.BaseItems) 
            AddOrModifyBaseItem(baseItem);
            
          foreach (var newItem in itemObjectData.NewItems) 
            AddOrModifyNewItem(newItem);

          foreach (var baseItem in itemSkinObjectData.BaseItems) 
            AddOrModifyBaseItem(baseItem);

          foreach (var newItem in itemSkinObjectData.NewItems)
            AddOrModifyNewItem(newItem);

          void AddOrModifyBaseItem(SimpleObjectModification simpleObjectModification)
          {
            if (this.TryGetItem(simpleObjectModification.OldId, out var existingItem))
            {
              existingItem.AddModifications(simpleObjectModification.Modifications);
              return;
            }
            var newItem = new Item((ItemType)simpleObjectModification.OldId, this);
            newItem.AddModifications(simpleObjectModification.Modifications);
            return;
          }
            
          void AddOrModifyNewItem(SimpleObjectModification simpleObjectModification)
          {
            if (this.TryGetItem(simpleObjectModification.NewId, out var existingItem))
            {
              existingItem.AddModifications(simpleObjectModification.Modifications);
              return;
            }
            var newItem = new Item((ItemType)simpleObjectModification.OldId, simpleObjectModification.NewId, this);
            newItem.AddModifications(simpleObjectModification.Modifications);
            return;
          }
        }

        public void AddObjects(DestructableObjectData destructableObjectData, DestructableObjectData destructableSkinObjectData)
        {
          foreach (var oldDestructable in destructableObjectData.BaseDestructables) 
            AddOrModifyBaseDestructable(oldDestructable);
            
          foreach (var oldDestructable in destructableObjectData.NewDestructables) 
            AddOrModifyBaseDestructable(oldDestructable);

          foreach (var newDestructable in destructableSkinObjectData.BaseDestructables) 
            AddOrModifyNewDestructable(newDestructable);

          foreach (var newDestructable in destructableSkinObjectData.NewDestructables)
            AddOrModifyNewDestructable(newDestructable);

          void AddOrModifyBaseDestructable(SimpleObjectModification simpleObjectModification)
          {
            if (this.TryGetDestructable(simpleObjectModification.OldId, out var existingDestructable))
            {
              existingDestructable.AddModifications(simpleObjectModification.Modifications);
              return;
            }
            var newDestructable = new Destructable((DestructableType)simpleObjectModification.OldId, this);
            newDestructable.AddModifications(simpleObjectModification.Modifications);
            return;
          }
            
          void AddOrModifyNewDestructable(SimpleObjectModification simpleObjectModification)
          {
            if (this.TryGetDestructable(simpleObjectModification.NewId, out var existingDestructable))
            {
              existingDestructable.AddModifications(simpleObjectModification.Modifications);
              return;
            }
            var newDestructable = new Destructable((DestructableType)simpleObjectModification.OldId, simpleObjectModification.NewId, this);
            newDestructable.AddModifications(simpleObjectModification.Modifications);
            return;
          }
        }

        public void AddObjects(DoodadObjectData doodadObjectData, DoodadObjectData doodadSkinObjectData)
        {
          foreach (var baseDoodad in doodadObjectData.BaseDoodads) 
            AddOrModifyBaseDoodad(baseDoodad);
            
          foreach (var newDoodad in doodadObjectData.NewDoodads) 
            AddOrModifyNewDoodad(newDoodad);

          foreach (var baseDoodad in doodadSkinObjectData.BaseDoodads) 
            AddOrModifyBaseDoodad(baseDoodad);

          foreach (var newDoodad in doodadSkinObjectData.NewDoodads)
            AddOrModifyNewDoodad(newDoodad);

          void AddOrModifyBaseDoodad(VariationObjectModification variationObjectModification)
          {
            if (this.TryGetDoodad(variationObjectModification.OldId, out var existingDoodad))
            {
              existingDoodad.AddModifications(variationObjectModification.Modifications);
              return;
            }
            var newDoodad = new Doodad((DoodadType)variationObjectModification.OldId, this);
            newDoodad.AddModifications(variationObjectModification.Modifications);
            return;
          }
            
          void AddOrModifyNewDoodad(VariationObjectModification variationObjectModification)
          {
            if (this.TryGetDoodad(variationObjectModification.NewId, out var existingDoodad))
            {
              existingDoodad.AddModifications(variationObjectModification.Modifications);
              return;
            }
            var newDoodad = new Doodad((DoodadType)variationObjectModification.OldId, variationObjectModification.NewId, this);
            newDoodad.AddModifications(variationObjectModification.Modifications);
            return;
          }
        }

        public void AddObjects(AbilityObjectData abilityObjectData, AbilityObjectData abilitySkinObjectData)
        {
            foreach (var baseAbility in abilityObjectData.BaseAbilities) 
              AddOrModifyBaseAbility(baseAbility);

            foreach (var newAbility in abilityObjectData.NewAbilities) 
              AddOrModifyNewAbility(newAbility);
            
            foreach (var baseAbility in abilitySkinObjectData.BaseAbilities) 
              AddOrModifyBaseAbility(baseAbility);

            foreach (var newAbility in abilitySkinObjectData.NewAbilities) 
              AddOrModifyNewAbility(newAbility);

            void AddOrModifyBaseAbility(LevelObjectModification levelObjectModification)
            {
              Ability ability;
              this.TryGetAbility(levelObjectModification.OldId, out ability);
              ability = ability ?? AbilityFactory.Create((AbilityType)levelObjectModification.OldId, this);
              ability.AddModifications(levelObjectModification.Modifications);
              return;
            }

            void AddOrModifyNewAbility(LevelObjectModification levelObjectModification)
            {
              if (this.TryGetAbility(levelObjectModification.OldId, out var existingAbility))
              {
                existingAbility.AddModifications(levelObjectModification.Modifications);
                return;
              }
              var newAbility = AbilityFactory.Create((AbilityType)levelObjectModification.OldId, levelObjectModification.NewId, this);
              newAbility.AddModifications(levelObjectModification.Modifications);
              return;
            }
        }

        public void AddObjects(BuffObjectData buffObjectData, BuffObjectData buffSkinObjectData)
        {
          foreach (var oldBuff in buffObjectData.BaseBuffs) 
            AddOrModifyBaseBuff(oldBuff);
            
          foreach (var oldBuff in buffObjectData.NewBuffs) 
            AddOrModifyNewBuff(oldBuff);

          foreach (var newBuff in buffSkinObjectData.BaseBuffs) 
            AddOrModifyBaseBuff(newBuff);

          foreach (var newBuff in buffSkinObjectData.NewBuffs)
            AddOrModifyNewBuff(newBuff);

          void AddOrModifyBaseBuff(SimpleObjectModification simpleObjectModification)
          {
            if (this.TryGetBuff(simpleObjectModification.OldId, out var existingBuff))
            {
              existingBuff.AddModifications(simpleObjectModification.Modifications);
              return;
            }
            var newBuff = new Buff((BuffType)simpleObjectModification.OldId, this);
            newBuff.AddModifications(simpleObjectModification.Modifications);
            return;
          }
            
          void AddOrModifyNewBuff(SimpleObjectModification simpleObjectModification)
          {
            if (this.TryGetBuff(simpleObjectModification.NewId, out var existingBuff))
            {
              existingBuff.AddModifications(simpleObjectModification.Modifications);
              return;
            }
            var newBuff = new Buff((BuffType)simpleObjectModification.OldId, simpleObjectModification.NewId, this);
            newBuff.AddModifications(simpleObjectModification.Modifications);
            return;
          }
        }

        public void AddObjects(UpgradeObjectData upgradeObjectData, UpgradeObjectData upgradeSkinObjectData)
        {
          foreach (var baseUpgrade in upgradeObjectData.BaseUpgrades) 
            AddOrModifyBaseUpgrade(baseUpgrade);
            
          foreach (var newUpgrade in upgradeObjectData.NewUpgrades) 
            AddOrModifyNewUpgrade(newUpgrade);

          foreach (var baseUpgrade in upgradeSkinObjectData.BaseUpgrades) 
            AddOrModifyBaseUpgrade(baseUpgrade);

          foreach (var newUpgrade in upgradeSkinObjectData.NewUpgrades)
            AddOrModifyNewUpgrade(newUpgrade);

          void AddOrModifyBaseUpgrade(LevelObjectModification levelObjectModification)
          {
            if (this.TryGetUpgrade(levelObjectModification.OldId, out var existingUpgrade))
            {
              existingUpgrade.AddModifications(levelObjectModification.Modifications);
              return;
            }
            var newUpgrade = new Upgrade((UpgradeType)levelObjectModification.OldId, this);
            newUpgrade.AddModifications(levelObjectModification.Modifications);
            return;
          }
            
          void AddOrModifyNewUpgrade(LevelObjectModification levelObjectModification)
          {
            if (this.TryGetUpgrade(levelObjectModification.NewId, out var existingUpgrade))
            {
              existingUpgrade.AddModifications(levelObjectModification.Modifications);
              return;
            }
            var newUpgrade = new Upgrade((UpgradeType)levelObjectModification.OldId, levelObjectModification.NewId, this);
            newUpgrade.AddModifications(levelObjectModification.Modifications);
            return;
          }
        }

        public ObjectData GetAllData(ObjectDataFormatVersion formatVersion = ObjectDataFormatVersion.v3)
        {
            var units = GetUnits().Select(unit => (SimpleObjectModification)unit);
            var items = GetItems().Select(item => (SimpleObjectModification)item);
            var destructables = GetDestructables().Select(destructable => (SimpleObjectModification)destructable);
            var doodads = GetDoodads().Select(doodad => (VariationObjectModification)doodad);
            var abilities = GetAbilities().Select(ability => (LevelObjectModification)ability);
            var buffs = GetBuffs().Select(buff => (SimpleObjectModification)buff);
            var upgrades = GetUpgrades().Select(upgrade => (LevelObjectModification)upgrade);

            return new ObjectData(formatVersion)
            {
                UnitData = units.Any() ? new UnitObjectData(formatVersion)
                {
                    BaseUnits = units.Where(unit => unit.NewId == 0).ToList(),
                    NewUnits = units.Where(unit => unit.NewId != 0).ToList(),
                } : null,
                ItemData = items.Any() ? new ItemObjectData(formatVersion)
                {
                    BaseItems = items.Where(item => item.NewId == 0).ToList(),
                    NewItems = items.Where(item => item.NewId != 0).ToList(),
                } : null,
                DestructableData = destructables.Any() ? new DestructableObjectData(formatVersion)
                {
                    BaseDestructables = destructables.Where(destructable => destructable.NewId == 0).ToList(),
                    NewDestructables = destructables.Where(destructable => destructable.NewId != 0).ToList(),
                } : null,
                DoodadData = doodads.Any() ? new DoodadObjectData(formatVersion)
                {
                    BaseDoodads = doodads.Where(doodad => doodad.NewId == 0).ToList(),
                    NewDoodads = doodads.Where(doodad => doodad.NewId != 0).ToList(),
                } : null,
                AbilityData = abilities.Any() ? new AbilityObjectData(formatVersion)
                {
                    BaseAbilities = abilities.Where(ability => ability.NewId == 0).ToList(),
                    NewAbilities = abilities.Where(ability => ability.NewId != 0).ToList(),
                } : null,
                BuffData = buffs.Any() ? new BuffObjectData(formatVersion)
                {
                    BaseBuffs = buffs.Where(buff => buff.NewId == 0).ToList(),
                    NewBuffs = buffs.Where(buff => buff.NewId != 0).ToList(),
                } : null,
                UpgradeData = upgrades.Any() ? new UpgradeObjectData(formatVersion)
                {
                    BaseUpgrades = upgrades.Where(upgrade => upgrade.NewId == 0).ToList(),
                    NewUpgrades = upgrades.Where(upgrade => upgrade.NewId != 0).ToList(),
                } : null,
            };
        }

        internal override void AddObject(BaseObject baseObject)
        {
            if (_objects.ContainsKey(baseObject.Key))
            {
                throw new ArgumentException($"An object with key '{baseObject.Key.ToRawcode()}' has already been added to this database.");
            }

            if (baseObject is Unit && !Enum.IsDefined(typeof(UnitType), baseObject.OldId))
            {
                throw new InvalidEnumArgumentException(nameof(baseObject.OldId), baseObject.OldId, typeof(UnitType));
            }

            if (baseObject is Item && !Enum.IsDefined(typeof(ItemType), baseObject.OldId))
            {
                throw new InvalidEnumArgumentException(nameof(baseObject.OldId), baseObject.OldId, typeof(ItemType));
            }

            if (baseObject is Destructable && !Enum.IsDefined(typeof(DestructableType), baseObject.OldId))
            {
                throw new InvalidEnumArgumentException(nameof(baseObject.OldId), baseObject.OldId, typeof(DestructableType));
            }

            if (baseObject is Doodad && !Enum.IsDefined(typeof(DoodadType), baseObject.OldId))
            {
                throw new InvalidEnumArgumentException(nameof(baseObject.OldId), baseObject.OldId, typeof(DoodadType));
            }

            if (baseObject is Ability && !Enum.IsDefined(typeof(AbilityType), baseObject.OldId))
            {
                throw new InvalidEnumArgumentException(nameof(baseObject.OldId), baseObject.OldId, typeof(AbilityType));
            }

            if (baseObject is Buff && !Enum.IsDefined(typeof(BuffType), baseObject.OldId))
            {
                throw new InvalidEnumArgumentException(nameof(baseObject.OldId), baseObject.OldId, typeof(BuffType));
            }

            if (baseObject is Upgrade && !Enum.IsDefined(typeof(UpgradeType), baseObject.OldId))
            {
                throw new InvalidEnumArgumentException(nameof(baseObject.OldId), baseObject.OldId, typeof(UpgradeType));
            }

            if (baseObject.NewId != 0)
            {
                if (_reservedKeys.Contains(baseObject.Key))
                {
                    throw new ArgumentException($"Key '{baseObject.Key.ToRawcode()}' is reserved in this database.");
                }

                if (_reservedTechs.Contains(baseObject.Key))
                {
                    if (!(baseObject is Unit || baseObject is Upgrade))
                    {
                        throw new ArgumentException($"Key '{baseObject.Key.ToRawcode()}' is reserved for a {nameof(Tech)} object, which must be of type {nameof(Unit)} or {nameof(Upgrade)}.");
                    }

                    _reservedTechs.Remove(baseObject.Key);
                }
            }

            _objects.Add(baseObject.Key, baseObject);
        }

        internal override void ReserveTech(int id)
        {
            if (_techTypes.Value.Contains(id))
            {
                return;
            }

            if (_objects.TryGetValue(id, out var baseObject))
            {
                if (baseObject is Unit || baseObject is Upgrade)
                {
                    return;
                }

                throw new ArgumentException($"Cannot reserve key '{id.ToRawcode()}' as a {nameof(Tech)} object, because an object with this key has already been added to this database.");
            }

            if (_objectTypes.Value.Contains(id))
            {
                throw new ArgumentException($"Cannot reserve key '{id.ToRawcode()}' as a {nameof(Tech)} object, because it is already reserved for an object that is neither of type {nameof(Unit)} nor {nameof(Upgrade)}.");
            }

            if (_reservedKeys.Contains(id))
            {
                throw new ArgumentException($"Cannot reserve key '{id.ToRawcode()}' as a {nameof(Tech)} object, because this key is reserved in this database.");
            }

            _reservedTechs.Add(id);
        }

        private static IEnumerable<int> GetTechTypes()
        {
            foreach (var unitType in Enum.GetValues(typeof(UnitType)))
            {
                yield return (int)unitType;
            }

            foreach (var upgradeType in Enum.GetValues(typeof(UpgradeType)))
            {
                yield return (int)upgradeType;
            }
        }

        private static IEnumerable<int> GetDefaultReservedKeys()
        {
            foreach (var techEquivalent in Enum.GetValues(typeof(TechEquivalent)))
            {
                yield return (int)techEquivalent;
            }

            // todo: set default reserved keys (random unit/item, etc)
        }
    }
}