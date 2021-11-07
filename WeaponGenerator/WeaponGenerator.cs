﻿using System;
using System.Collections.Generic;

namespace WeaponGenerator
{
	//For how to instantiate object with certain class type based on Enum value:
	//https://stackoverflow.com/questions/25640344/how-to-dynamically-create-an-object-based-on-the-name-of-the-enum-without-switc/25640465
	/// <summary>
	/// Generates different types of weapons randomly with random stats
	/// </summary>
	public class WeaponGenerator
	{
		private ushort _singleActionRevolverChance = 1,
			_doubleActionRevolverChance = 1,
			_fullSizedHandgunChance = 1,
			_compactHandgunChance = 1,
			_subcompactHandgunChance = 1,
			_microcompactHandgunChance = 1,
			_leverActionRifleChance = 1,
			_boltActionRifleChance = 1,
			_semiautomaticRifleChance = 1,
			_breakActionShotgunChance = 1,
			_leverActionShotgunChance = 1,
			_pumpShotgunChance = 1,
			_semiautomaticShotgunChance = 1,
			_submachineGunChance = 1,
			_heavyMachinGunChance = 1,
			_lightMachineGunChance = 1,
			_assaultRifleChance = 1;

		/// <summary>
		/// The chance to spawn this weapon; the higher the number, the higher the chance
		/// </summary>
		public ushort SingleActionRevolverChance { get { return _singleActionRevolverChance; } set { _singleActionRevolverChance = value; } }
		/// <summary>
		/// The chance to spawn this weapon; the higher the number, the higher the chance
		/// </summary>
		public ushort DoubleActionRevolverChance { get { return _doubleActionRevolverChance; } set { _doubleActionRevolverChance = value; } }
		/// <summary>
		/// The chance to spawn this weapon; the higher the number, the higher the chance
		/// </summary>
		public ushort FullSizedHandgunChance { get { return _fullSizedHandgunChance; } set { _fullSizedHandgunChance = value; } }
		/// <summary>
		/// The chance to spawn this weapon; the higher the number, the higher the chance
		/// </summary>
		public ushort CompactHandgunChance { get { return _compactHandgunChance; } set { _compactHandgunChance = value; } }
		/// <summary>
		/// The chance to spawn this weapon; the higher the number, the higher the chance
		/// </summary>
		public ushort SubcompactHandgunChance { get { return _subcompactHandgunChance; } set { _subcompactHandgunChance = value; } }
		/// <summary>
		/// The chance to spawn this weapon; the higher the number, the higher the chance
		/// </summary>
		public ushort MicrocompactHandgunChance { get { return _microcompactHandgunChance; } set { _microcompactHandgunChance = value; } }
		/// <summary>
		/// The chance to spawn this weapon; the higher the number, the higher the chance
		/// </summary>
		public ushort LeverActionRifleChance { get { return _leverActionRifleChance; } set { _leverActionRifleChance = value; } }
		/// <summary>
		/// The chance to spawn this weapon; the higher the number, the higher the chance
		/// </summary>
		public ushort BoltActionRifleChance { get { return _boltActionRifleChance; } set { _boltActionRifleChance = value; } }
		/// <summary>
		/// The chance to spawn this weapon; the higher the number, the higher the chance
		/// </summary>
		public ushort SemiautomaticRifleChance { get { return _semiautomaticRifleChance; } set { _semiautomaticRifleChance = value; } }
		/// <summary>
		/// The chance to spawn this weapon; the higher the number, the higher the chance
		/// </summary>
		public ushort BreakActionShotgunChance { get { return _breakActionShotgunChance; } set { _breakActionShotgunChance = value; } }
		/// <summary>
		/// The chance to spawn this weapon; the higher the number, the higher the chance
		/// </summary>
		public ushort LeverActionShotgunChance { get { return _leverActionShotgunChance; } set { _leverActionShotgunChance = value; } }
		/// <summary>
		/// The chance to spawn this weapon; the higher the number, the higher the chance
		/// </summary>
		public ushort PumpActionShotgunChance { get { return _pumpShotgunChance; } set { _pumpShotgunChance = value; } }
		/// <summary>
		/// The chance to spawn this weapon; the higher the number, the higher the chance
		/// </summary>
		public ushort SemiautomaticShotgunChance { get { return _semiautomaticShotgunChance; } set { _semiautomaticShotgunChance = value; } }
		/// <summary>
		/// The chance to spawn this weapon; the higher the number, the higher the chance
		/// </summary>
		public ushort SubmachineGunChance { get { return _submachineGunChance; } set { _submachineGunChance = value; } }
		/// <summary>
		/// The chance to spawn this weapon; the higher the number, the higher the chance
		/// </summary>
		public ushort HeavyMachinGunChance { get { return _heavyMachinGunChance; } set { _heavyMachinGunChance = value; } }
		/// <summary>
		/// The chance to spawn this weapon; the higher the number, the higher the chance
		/// </summary>
		public ushort LightMachineGunChance { get { return _lightMachineGunChance; } set { _lightMachineGunChance = value; } }
		/// <summary>
		/// The chance to spawn this weapon; the higher the number, the higher the chance
		/// </summary>
		public ushort AssaultRifleChance { get { return _assaultRifleChance; } set { _assaultRifleChance = value; } }

		/// <summary>
		/// Sum of all weapon generation chances
		/// </summary>
		public uint TotalChance
		{
			get
			{
				return Convert.ToUInt32(SingleActionRevolverChance + DoubleActionRevolverChance + FullSizedHandgunChance + CompactHandgunChance + SubcompactHandgunChance
											+ MicrocompactHandgunChance + LeverActionRifleChance + BoltActionRifleChance + SemiautomaticRifleChance + BreakActionShotgunChance
											+ LeverActionShotgunChance + PumpActionShotgunChance + SemiautomaticShotgunChance + SubmachineGunChance + HeavyMachinGunChance
											+ LightMachineGunChance + AssaultRifleChance);
			}
		}

		/// <summary>
		/// Set all weapon types to an equal chance to generate
		/// </summary>
		/// <param name="value">The ushort to apply to all weapon type chances</param>
		public void AllWeaponsEqualChance(ushort value)
		{
			_singleActionRevolverChance = value;
			_doubleActionRevolverChance = value;
			_fullSizedHandgunChance = value;
			_compactHandgunChance = value;
			_subcompactHandgunChance = value;
			_microcompactHandgunChance = value;
			_leverActionRifleChance = value;
			_boltActionRifleChance = value;
			_semiautomaticRifleChance = value;
			_breakActionShotgunChance = value;
			_leverActionShotgunChance = value;
			_pumpShotgunChance = value;
			_semiautomaticShotgunChance = value;
			_submachineGunChance = value;
			_heavyMachinGunChance = value;
			_lightMachineGunChance = value;
			_assaultRifleChance = value;
		}

		/// <summary>
		/// Generate a random object with a base type of Weapon
		/// </summary>
		/// <returns>Instance of any of the weapons</returns>
		public Weapon GenerateRandomWeapon()
		{
			Weapon weapon;
			Random rand_Weapon = new();
			int rand = rand_Weapon.Next(0, Convert.ToInt32(TotalChance));

			List<WeaponType> ChancePool = CreateChancePool();

			weapon = GetWeapon(ChancePool[rand]);
			SetupWeapon(ref weapon);

			return weapon;
		}

		/// <summary>
		/// Generate multiple objects with a base type of Weapon
		/// </summary>
		/// <param name="Amount">The amount of weapons to generate</param>
		/// <returns>Array of instances of any of the weapon</returns>
		public Weapon[] GenerateRandomWeapon(int Amount)
		{
			Weapon[] weapon = new Weapon[Amount];
			Random rand_Weapon = new();
			int rand;
			List<WeaponType> ChancePool = CreateChancePool();

			for (int i = 0; i < Amount; i++)
			{
				rand = rand_Weapon.Next(0, Convert.ToInt32(TotalChance));
				weapon[i] = GetWeapon(ChancePool[rand]);
				SetupWeapon(ref weapon[i]);
			}

			return weapon;
		}

		/// <summary>
		/// Assists in setting up the weapon
		/// </summary>
		/// <param name="weapon">The reference of the weapon to setup</param>
		private static void SetupWeapon(ref Weapon weapon)
		{
			Random rand_ClipSize = new();
			weapon.SetClipSize = Convert.ToUInt16(rand_ClipSize.Next(weapon.LowerClipLimit, weapon.UpperClipLimit));
		}

		/// <summary>
		/// Creates a List of type WeaponType representing a chance pool for a random number generator to pick from
		/// </summary>
		/// <returns>The chance pool itself, to be used by a Random number generator to pick from</returns>
		private List<WeaponType> CreateChancePool()
		{
			List<WeaponType> ChancePool = new();

			for (int i = 0; i < SingleActionRevolverChance; i++)
			{
				ChancePool.Add(WeaponType.SingleActionRevolver);
			}

			for (int i = 0; i < DoubleActionRevolverChance; i++)
			{
				ChancePool.Add(WeaponType.DoubleActionRevolver);
			}

			for (int i = 0; i < FullSizedHandgunChance; i++)
			{
				ChancePool.Add(WeaponType.FullSizedHandgun);
			}

			for (int i = 0; i < CompactHandgunChance; i++)
			{
				ChancePool.Add(WeaponType.CompactHandgun);
			}

			for (int i = 0; i < SubcompactHandgunChance; i++)
			{
				ChancePool.Add(WeaponType.SubcompactHandgun);
			}

			for (int i = 0; i < MicrocompactHandgunChance; i++)
			{
				ChancePool.Add(WeaponType.MicrocompactHandgun);
			}

			for (int i = 0; i < LeverActionRifleChance; i++)
			{
				ChancePool.Add(WeaponType.LeverActionRifle);
			}

			for (int i = 0; i < BoltActionRifleChance; i++)
			{
				ChancePool.Add(WeaponType.BoltActionRifle);
			}

			for (int i = 0; i < SemiautomaticRifleChance; i++)
			{
				ChancePool.Add(WeaponType.SemiautomaticRifle);
			}

			for (int i = 0; i < BreakActionShotgunChance; i++)
			{
				ChancePool.Add(WeaponType.BreakActionShotgun);
			}

			for (int i = 0; i < LeverActionShotgunChance; i++)
			{
				ChancePool.Add(WeaponType.LeverActionShotgun);
			}

			for (int i = 0; i < PumpActionShotgunChance; i++)
			{
				ChancePool.Add(WeaponType.PumpActionShotgun);
			}

			for (int i = 0; i < SemiautomaticShotgunChance; i++)
			{
				ChancePool.Add(WeaponType.SemiautomaticShotgun);
			}

			for (int i = 0; i < SubmachineGunChance; i++)
			{
				ChancePool.Add(WeaponType.SubmachineGun);
			}

			for (int i = 0; i < HeavyMachinGunChance; i++)
			{
				ChancePool.Add(WeaponType.HeavyMachineGun);
			}

			for (int i = 0; i < LightMachineGunChance; i++)
			{
				ChancePool.Add(WeaponType.LightMachineGun);
			}

			for (int i = 0; i < AssaultRifleChance; i++)
			{
				ChancePool.Add(WeaponType.AssaultRifle);
			}

			return ChancePool;
		}

		/// <summary>
		/// Convert the WeaponType into the actual type it represents
		/// </summary>
		/// <param name="weaponType">WeaponType to create</param>
		/// <seealso href="https://stackoverflow.com/questions/25640344/how-to-dynamically-create-an-object-based-on-the-name-of-the-enum-without-switc/25640465">Thanks MatteoSp!</seealso>
		/// <returns>An instance of the WeaponType</returns>
		private static Weapon GetWeapon(WeaponType weaponType)
		{
			string ns = typeof(WeaponType).Namespace;
			string typeName = ns + "." + weaponType.ToString();
			Type type = Type.GetType(typeName);
			Weapon weapon = (Weapon)Activator.CreateInstance(type);

			return weapon;
		}
	}

	/// <summary>
	/// An inheritable base class for all weapons
	/// </summary>
	public abstract class Weapon
	{
		/// <summary>
		/// How many rounds a single clip will hold
		/// </summary>
		protected ushort _clipSize;
		/// <summary>
		/// The minimum spread of the round fired
		/// </summary>
		protected float _minimumSpread;
		/// <summary>
		/// The maximum spread of the round fired
		/// </summary>
		protected float _maximumSpread;
		/// <summary>
		/// The maximum range a fired round will deliver full effect, assuming meters
		/// </summary>
		protected ushort _effectiveRange;
		/// <summary>
		/// The maximum range a fired round will deliver negligible, if not zero, effect
		/// </summary>
		protected ushort _absMaxRange;
		/// <summary>
		/// The weight of the weapon, assuming grams
		/// </summary>
		protected ushort _weight;
		/// <summary>
		/// The averaged TimeSpan it takes to reload a weapon, to be affected by _reloadTimeVariance
		/// </summary>
		protected TimeSpan _reloadTime;
		/// <summary>
		/// How much variation in the time to reload, to be used to make a quicker or slower reload based on chance
		/// </summary>
		protected ushort _reloadTimeVariance;
		/// <summary>
		/// Whether two of this weapon can be held and fired simultaneously
		/// </summary>
		protected bool _canDualWield;
		/// <summary>
		/// Whether this weapon has to be held by both hands, probably mutually exclusive to _canDualWield
		/// </summary>
		protected bool _isTwoHanded;
		/// <summary>
		/// The amount of time it takes to go from hip-fire to ADS
		/// </summary>
		protected TimeSpan _drawSpeed;
		/// <summary>
		/// The minimum TimeSpan between two rounds being fired
		/// </summary>
		protected TimeSpan _fireRate;
		/// <summary>
		/// The type of ammunition this weapon uses
		/// </summary>
		protected Ammunition _ammunition;
		/// <summary>
		/// Represents the valid ammunition types this weapon can take, along with the chance the weapon will generate with that type of ammunition
		/// </summary>
		protected Dictionary<Ammunition, ushort> _validAmmunition;

		/// <summary>
		/// Set the size of the clip
		/// </summary>
		public ushort SetClipSize { set { _clipSize = value; } }
		/// <summary>
		/// The type of ammunition this weapon uses
		/// </summary>
		public Ammunition Ammunition { get { return _ammunition; } }

		//TODO: Potentially needs to be changed from internal to protected
		/// <summary>
		/// The lowest value _clipSize can have
		/// </summary>
		internal abstract ushort LowerClipLimit { get; }

		/// <summary>
		/// The highest value _clipSize can have
		/// </summary>
		internal abstract ushort UpperClipLimit { get; }

		/// <summary>
		/// This weapon's normal name
		/// </summary>
		public abstract string WeaponName { get; }

		/// <summary>
		/// The amount of rounds in each clip
		/// </summary>
		public ushort ClipSize { get { return _clipSize; } }

		/// <summary>
		/// The minimum spread pattern the fired projectile will follow
		/// </summary>
		public float MinimumSpread { get { return _minimumSpread; } }

		/// <summary>
		/// The maximum spread pattern the fired projectile will folow
		/// </summary>
		public float MaximumSpread { get { return _maximumSpread; } }

		/// <summary>
		/// The distance the firearm will shoot a projectile and have full effectiveness, assuming meters
		/// </summary>
		public ushort EffectiveRange { get { return _effectiveRange; } }

		/// <summary>
		/// The weight of the firearm, assuming grams
		/// </summary>
		public ushort Weight { get { return _weight; } }

		/// <summary>
		/// The amount of time it takes to reload the firearm
		/// </summary>
		public TimeSpan ReloadTime { get { return _reloadTime; } }

		/// <summary>
		/// Whether this firearm can be dual wielded
		/// </summary>
		public bool CanDualWield { get { return _canDualWield; } }

		/// <summary>
		/// Whether this firearm requires being held by two hands
		/// </summary>
		public bool IsTwoHanded { get { return _isTwoHanded; } }

		/// <summary>
		/// The amount of time it takes to go from hip-fire to ADS
		/// </summary>
		public TimeSpan DrawSpeed { get { return _drawSpeed; } }

		/// <summary>
		/// The minimum TimeSpan between two rounds being fired
		/// </summary>
		public TimeSpan FireRate { get { return _fireRate; } }
	}

	#region Revolver
	/// <summary>
	/// An inheritable base class for Revolver type weapons
	/// </summary>
	public abstract class Revolver : Weapon
	{
		internal override ushort LowerClipLimit { get { return 5; } }

		internal override ushort UpperClipLimit { get { return 12; } }

		/// <summary>
		/// Initializer for both Single and Double Action Revolvers
		/// </summary>
		public Revolver()
		{
			_weight = 979; // S&W Model 29
			_validAmmunition = new Dictionary<Ammunition, ushort>();
			_validAmmunition.Add(Ammunition)
		}
	}

	/// <summary>
	/// Represents a Single Action Revolver
	/// </summary>
	public class SingleActionRevolver : Revolver
	{
		/// <summary>
		/// The weapon's normal name
		/// </summary>
		public override string WeaponName { get { return "Single Action Revolver"; } }
	}

	/// <summary>
	/// Represents a Double Action Revolver
	/// </summary>
	public class DoubleActionRevolver : Revolver
	{
		/// <summary>
		/// The weapon's normal name
		/// </summary>
		public override string WeaponName { get { return "Double Action Revolver"; } }
	}
	#endregion

	#region Handgun
	/// <summary>
	/// An inheritable base class for Handgun type weapons
	/// </summary>
	public abstract class Handgun : Weapon
	{
		internal override ushort LowerClipLimit { get { return 10; } }

		internal override ushort UpperClipLimit { get { return 20; } }
	}

	/// <summary>
	/// Represents a Full Sized Handgun
	/// </summary>
	public class FullSizedHandgun : Handgun
	{
		/// <summary>
		/// The weapon's normal name
		/// </summary>
		public override string WeaponName { get { return "Full Sized Handgun"; } }
	}

	/// <summary>
	/// Represents a Compact Handgun
	/// </summary>
	public class CompactHandgun : Handgun
	{
		/// <summary>
		/// The weapon's normal name
		/// </summary>
		public override string WeaponName { get { return "Compact Handgun"; } }
	}

	/// <summary>
	/// Represents a Subcompact Handgun
	/// </summary>
	public class SubcompactHandgun : Handgun
	{
		/// <summary>
		/// The weapon's normal name
		/// </summary>
		public override string WeaponName { get { return "Subcompact Handgun"; } }
	}

	/// <summary>
	/// Represents a Microcompact Handgun
	/// </summary>
	public class MicrocompactHandgun : Handgun
	{
		/// <summary>
		/// The weapon's normal name
		/// </summary>
		public override string WeaponName { get { return "Microcompact Handgun"; } }
	}
	#endregion

	#region Rifle
	/// <summary>
	/// An inheritable base class for Rifle type weapons
	/// </summary>
	public abstract class Rifle : Weapon { }

	/// <summary>
	/// Represents a Lever Action Rifle
	/// </summary>
	public class LeverActionRifle : Rifle
	{
		/// <summary>
		/// The weapon's normal name
		/// </summary>
		public override string WeaponName { get { return "Lever Action Rifle"; } }

		internal override ushort LowerClipLimit { get { return 4; } }

		internal override ushort UpperClipLimit { get { return 17; } }
	}

	/// <summary>
	/// Represents a Bolt Action Rifle
	/// </summary>
	public class BoltActionRifle : Rifle
	{
		/// <summary>
		/// The weapon's normal name
		/// </summary>
		public override string WeaponName { get { return "Bolt Action Rifle"; } }

		internal override ushort LowerClipLimit { get { return 2; } }

		internal override ushort UpperClipLimit { get { return 10; } }
	}

	/// <summary>
	/// Represents a Semiautomatic Rifle
	/// </summary>
	public class SemiautomaticRifle : Rifle
	{
		/// <summary>
		/// The weapon's normal name
		/// </summary>
		public override string WeaponName { get { return "Semiautomatic Rifle"; } }

		internal override ushort LowerClipLimit { get { return 5; } }

		internal override ushort UpperClipLimit { get { return 30; } }
	}
	#endregion

	#region Shotgun
	/// <summary>
	/// An inheritable base class for Shotgun type weapons
	/// </summary>
	public abstract class Shotgun : Weapon { }

	/// <summary>
	/// Represents a Break Action Shotgun
	/// </summary>
	public class BreakActionShotgun : Shotgun
	{
		/// <summary>
		/// The weapon's normal name
		/// </summary>
		public override string WeaponName { get { return "Break Action Shotgun"; } }

		internal override ushort LowerClipLimit { get { return 1; } }

		internal override ushort UpperClipLimit { get { return 2; } }
	}

	/// <summary>
	/// Represents a Lever Action Shotgun
	/// </summary>
	public class LeverActionShotgun : Shotgun
	{
		/// <summary>
		/// The weapon's normal name
		/// </summary>
		public override string WeaponName { get { return "Lever Action Shotgun"; } }

		internal override ushort LowerClipLimit { get { return 5; } }

		internal override ushort UpperClipLimit { get { return 6; } }
	}

	/// <summary>
	/// Represents a Pump Action Shotgun
	/// </summary>
	public class PumpActionShotgun : Shotgun
	{
		/// <summary>
		/// The weapon's normal name
		/// </summary>
		public override string WeaponName { get { return "Pump Action Shotgun"; } }

		internal override ushort LowerClipLimit { get { return 4; } }

		internal override ushort UpperClipLimit { get { return 5; } }
	}

	/// <summary>
	/// Represents a Semiautomatic Shotgun
	/// </summary>
	public class SemiautomaticShotgun : Shotgun
	{
		/// <summary>
		/// The weapon's normal name
		/// </summary>
		public override string WeaponName { get { return "Semiautomatic Shotgun"; } }

		internal override ushort LowerClipLimit { get { return 3; } }

		internal override ushort UpperClipLimit { get { return 9; } }
	}
	#endregion

	#region Automatics
	/// <summary>
	/// An inheritable base class for Automatic type weapons
	/// </summary>
	public abstract class Automatics : Weapon { }

	/// <summary>
	/// Represents a Submachine Gun
	/// </summary>
	public class SubmachineGun : Automatics
	{
		/// <summary>
		/// The weapon's normal name
		/// </summary>
		public override string WeaponName { get { return "Submachine Gun"; } }

		internal override ushort LowerClipLimit { get { return 10; } }

		internal override ushort UpperClipLimit { get { return 50; } }
	}

	/// <summary>
	/// Represents a Heavy Machine Gun
	/// </summary>
	public class HeavyMachineGun : Automatics
	{
		/// <summary>
		/// The weapon's normal name
		/// </summary>
		public override string WeaponName { get { return "Heavy Machine Gun"; } }

		internal override ushort LowerClipLimit { get { return 50; } }

		internal override ushort UpperClipLimit { get { return 300; } }
	}

	/// <summary>
	/// Represents a Light Machine Gun
	/// </summary>
	public class LightMachineGun : Automatics
	{
		/// <summary>
		/// The weapon's normal name
		/// </summary>
		public override string WeaponName { get { return "Light Machine Gun"; } }

		internal override ushort LowerClipLimit { get { return 50; } }

		internal override ushort UpperClipLimit { get { return 100; } }
	}

	/// <summary>
	/// Represents an Assault Rifle
	/// </summary>
	public class AssaultRifle : Automatics
	{
		/// <summary>
		/// The weapon's normal name
		/// </summary>
		public override string WeaponName { get { return "Assault Rifle"; } }

		internal override ushort LowerClipLimit { get { return 15; } }

		internal override ushort UpperClipLimit { get { return 30; } }
	}
	#endregion

	//Ref: https://legionary.com/all-types-of-guns-with-pictures-and-names/
	/// <summary>
	/// Represents the different available weapon types able to be generated
	/// </summary>
	public enum WeaponType
	{
		/// <summary>
		/// A single action revolver
		/// </summary>
		SingleActionRevolver,
		/// <summary>
		/// A double action revolver
		/// </summary>
		DoubleActionRevolver,
		/// <summary>
		/// A full sized handgun
		/// </summary>
		FullSizedHandgun,
		/// <summary>
		/// A compact handgun
		/// </summary>
		CompactHandgun,
		/// <summary>
		/// A subcompact handgun
		/// </summary>
		SubcompactHandgun,
		/// <summary>
		/// A microcompact handgun
		/// </summary>
		MicrocompactHandgun,
		/// <summary>
		/// A lever action rifle
		/// </summary>
		LeverActionRifle,
		/// <summary>
		/// A bolt action rifle
		/// </summary>
		BoltActionRifle,
		/// <summary>
		/// A semiautomatic rifle
		/// </summary>
		SemiautomaticRifle,
		/// <summary>
		/// A break action shotgun
		/// </summary>
		BreakActionShotgun,
		/// <summary>
		/// A lever action shotgun
		/// </summary>
		LeverActionShotgun,
		/// <summary>
		/// A pump action shotgun
		/// </summary>
		PumpActionShotgun,
		/// <summary>
		/// A semiautomatic shotgun
		/// </summary>
		SemiautomaticShotgun,
		/// <summary>
		/// A submachine gun
		/// </summary>
		SubmachineGun,
		/// <summary>
		/// A heavy machine gun
		/// </summary>
		HeavyMachineGun,
		/// <summary>
		/// A light machine gun
		/// </summary>
		LightMachineGun,
		/// <summary>
		/// An assault rifle
		/// </summary>
		AssaultRifle
	}

	#region Ammunition
	/// <summary>
	/// An inheritable base class for all ammunition types
	/// </summary>
	public abstract class Ammunition
	{
		/// <summary>
		/// The type of round loaded and fired
		/// </summary>
		protected Cartridge _cartridge;
		/// <summary>
		/// The maximum cartridges held in this storage unit
		/// </summary>
		protected byte _cartridgesPerStorageUnit;
		/// <summary>
		/// For random generation, the minimum cartridges held in this storage unit
		/// </summary>
		protected byte _minCartridgesPerStorageUnit;
		/// <summary>
		/// For random generation, the maximum cartridges held in this storage unit
		/// </summary>
		protected byte _maxCartridgesPerStorageUnit;

		/// <summary>
		/// The amount of cartridges held in each storage unit (magazine, clip, wheel, etc.)
		/// </summary>
		public byte CartridgesPerStorageUnit;

		/// <summary>
		/// The type of ammunition that is loaded and fired from this weapon
		/// </summary>
		public Cartridge Cartridge { get { return _cartridge; } }
	}

	public class TwentyTwoLR : Ammunition
	{

	}

	/// <summary>
	/// The type of ammunition loaded and fired from a Weapon
	/// </summary>
	public enum Cartridge
	{
		/// <summary>
		/// .22 Long Rifle
		/// </summary>
		TwentyTwoLR,
		/// <summary>
		/// .38 Special
		/// </summary>
		ThirtyEightSpecial,
		/// <summary>
		/// .357 Magnum
		/// </summary>
		ThreeFiftySevenMagnum,
		/// <summary>
		/// .44 Special
		/// </summary>
		FortyFourSpecial,
		/// <summary>
		/// .44 Magnum
		/// </summary>
		FortyFourMagnum
	}
	#endregion
}

/* Information for Reference:
 * https://en.wikipedia.org/wiki/.44_Magnum
 * https://www.americanrifleman.org/content/america-s-top-5-handgun-cartridges/
 */