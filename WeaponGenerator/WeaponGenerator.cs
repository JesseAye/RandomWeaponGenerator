using System;
using System.Collections.Generic;

namespace WeaponGenerator
{
	//For how to instantiate object with certain class type based on Enum value:
	//https://stackoverflow.com/questions/25640344/how-to-dynamically-create-an-object-based-on-the-name-of-the-enum-without-switc/25640465
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

		public ushort SingleActionRevolverChance { get { return _singleActionRevolverChance; } set { _singleActionRevolverChance = value; } }
		public ushort DoubleActionRevolverChance { get { return _doubleActionRevolverChance; } set { _doubleActionRevolverChance = value; } }
		public ushort FullSizedHandgunChance { get { return _fullSizedHandgunChance; } set { _fullSizedHandgunChance = value; } }
		public ushort CompactHandgunChance { get { return _compactHandgunChance; } set { _compactHandgunChance = value; } }
		public ushort SubcompactHandgunChance { get { return _subcompactHandgunChance; } set { _subcompactHandgunChance = value; } }
		public ushort MicrocompactHandgunChance { get { return _microcompactHandgunChance; } set { _microcompactHandgunChance = value; } }
		public ushort LeverActionRifleChance { get { return _leverActionRifleChance; } set { _leverActionRifleChance = value; } }
		public ushort BoltActionRifleChance { get { return _boltActionRifleChance; } set { _boltActionRifleChance = value; } }
		public ushort SemiautomaticRifleChance { get { return _semiautomaticRifleChance; } set { _semiautomaticRifleChance = value; } }
		public ushort BreakActionShotgunChance { get { return _breakActionShotgunChance; } set { _breakActionShotgunChance = value; } }
		public ushort LeverActionShotgunChance { get { return _leverActionShotgunChance; } set { _leverActionShotgunChance = value; } }
		public ushort PumpActionShotgunChance { get { return _pumpShotgunChance; } set { _pumpShotgunChance = value; } }
		public ushort SemiautomaticShotgunChance { get { return _semiautomaticShotgunChance; } set { _semiautomaticShotgunChance = value; } }
		public ushort SubmachineGunChance { get { return _submachineGunChance; } set { _submachineGunChance = value; } }
		public ushort HeavyMachinGunChance { get { return _heavyMachinGunChance; } set { _heavyMachinGunChance = value; } }
		public ushort LightMachineGunChance { get { return _lightMachineGunChance; } set { _lightMachineGunChance = value; } }
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

	public abstract class Weapon
	{
		protected ushort _clipSize;
		protected float _minimumSpread;
		protected float _maximumSpread;
		protected ushort _effectiveRange;
		protected ushort _absMaxRange;
		protected ushort _weight;
		protected TimeSpan _reloadTime;
		protected ushort _reloadTimeVariance;
		protected bool _canDualWield;
		protected bool _isTwoHanded;
		protected TimeSpan _drawSpeed;
		protected TimeSpan _fireRate;

		internal ushort SetClipSize { set { _clipSize = value; } }

		internal abstract ushort LowerClipLimit { get; }

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
		/// The distance the firearm will shoot a projectile and have full effectiveness
		/// </summary>
		public ushort EffectiveRange { get { return _effectiveRange; } }

		/// <summary>
		/// The weight of the firearm
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

		public TimeSpan DrawSpeed { get { return _drawSpeed; } }

		public TimeSpan FireRate { get { return _fireRate; } }
	}

	#region Revolver
	public abstract class Revolver : Weapon
	{
		internal override ushort LowerClipLimit { get { return 5; } }

		internal override ushort UpperClipLimit { get { return 12; } }
	}

	public class SingleActionRevolver : Revolver
	{
		public override string WeaponName { get { return "Single Action Revolver"; } }
	}

	public class DoubleActionRevolver : Revolver
	{
		public override string WeaponName { get { return "Double Action Revolver"; } }
	}
	#endregion

	#region Handgun
	public abstract class Handgun : Weapon
	{
		internal override ushort LowerClipLimit { get { return 10; } }

		internal override ushort UpperClipLimit { get { return 20; } }
	}

	public class FullSizedHandgun : Handgun
	{
		public override string WeaponName { get { return "Full Sized Handgun"; } }
	}

	public class CompactHandgun : Handgun
	{
		public override string WeaponName { get { return "Compact Handgun"; } }
	}

	public class SubcompactHandgun : Handgun
	{
		public override string WeaponName { get { return "Subcompact Handgun"; } }
	}

	public class MicrocompactHandgun : Handgun
	{
		public override string WeaponName { get { return "Microcompact Handgun"; } }
	}
	#endregion

	#region Rifle
	public abstract class Rifle : Weapon { }

	public class LeverActionRifle : Rifle
	{
		public override string WeaponName { get { return "Lever Action Rifle"; } }

		internal override ushort LowerClipLimit { get { return 4; } }

		internal override ushort UpperClipLimit { get { return 17; } }
	}

	public class BoltActionRifle : Rifle
	{
		public override string WeaponName { get { return "Bolt Action Rifle"; } }

		internal override ushort LowerClipLimit { get { return 2; } }

		internal override ushort UpperClipLimit { get { return 10; } }
	}

	public class SemiautomaticRifle : Rifle
	{
		public override string WeaponName { get { return "Semiautomatic Rifle"; } }

		internal override ushort LowerClipLimit { get { return 5; } }

		internal override ushort UpperClipLimit { get { return 30; } }
	}
	#endregion

	#region Shotgun
	public abstract class Shotgun : Weapon { }

	public class BreakActionShotgun : Shotgun
	{
		public override string WeaponName { get { return "Break Action Shotgun"; } }

		internal override ushort LowerClipLimit { get { return 1; } }

		internal override ushort UpperClipLimit { get { return 2; } }
	}

	public class LeverActionShotgun : Shotgun
	{
		public override string WeaponName { get { return "Lever Action Shotgun"; } }

		internal override ushort LowerClipLimit { get { return 5; } }

		internal override ushort UpperClipLimit { get { return 6; } }
	}

	public class PumpActionShotgun : Shotgun
	{
		public override string WeaponName { get { return "Pump Action Shotgun"; } }

		internal override ushort LowerClipLimit { get { return 4; } }

		internal override ushort UpperClipLimit { get { return 5; } }
	}

	public class SemiautomaticShotgun : Shotgun
	{
		public override string WeaponName { get { return "Semiautomatic Shotgun"; } }

		internal override ushort LowerClipLimit { get { return 3; } }

		internal override ushort UpperClipLimit { get { return 9; } }
	}
	#endregion

	#region Automatics
	public abstract class Automatics : Weapon { }

	public class SubmachineGun : Automatics
	{
		public override string WeaponName { get { return "Submachine Gun"; } }

		internal override ushort LowerClipLimit { get { return 10; } }

		internal override ushort UpperClipLimit { get { return 50; } }
	}

	public class HeavyMachineGun : Automatics
	{
		public override string WeaponName { get { return "Heavy Machine Gun"; } }

		internal override ushort LowerClipLimit { get { return 50; } }

		internal override ushort UpperClipLimit { get { return 300; } }
	}

	public class LightMachineGun : Automatics
	{
		public override string WeaponName { get { return "Light Machine Gun"; } }

		internal override ushort LowerClipLimit { get { return 50; } }

		internal override ushort UpperClipLimit { get { return 100; } }
	}

	public class AssaultRifle : Automatics
	{
		public override string WeaponName { get { return "Assault Rifle"; } }

		internal override ushort LowerClipLimit { get { return 15; } }

		internal override ushort UpperClipLimit { get { return 30; } }
	}
	#endregion

	//Ref: https://legionary.com/all-types-of-guns-with-pictures-and-names/
	public enum WeaponType
	{
		SingleActionRevolver,
		DoubleActionRevolver,
		FullSizedHandgun,
		CompactHandgun,
		SubcompactHandgun,
		MicrocompactHandgun,
		LeverActionRifle,
		BoltActionRifle,
		SemiautomaticRifle,
		BreakActionShotgun,
		LeverActionShotgun,
		PumpActionShotgun,
		SemiautomaticShotgun,
		SubmachineGun,
		HeavyMachineGun,
		LightMachineGun,
		AssaultRifle
	}
}
