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
			Random rand_ClipSize = new();
			int rand = rand_Weapon.Next(0, Convert.ToInt32(TotalChance));

			List<WeaponType> ChancePool = CreateChancePool();

			weapon = GetWeapon(ChancePool[rand]);
			weapon.ClipSize = Convert.ToUInt16(rand_ClipSize.Next(weapon.LowerClipLimit, weapon.UpperClipLimit));

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
			Random rand_ClipSize = new();
			int rand;
			List<WeaponType> ChancePool = CreateChancePool();

			for (int i = 0; i < Amount; i++)
			{
				rand = rand_Weapon.Next(0, Convert.ToInt32(TotalChance));
				weapon[i] = GetWeapon(ChancePool[rand]);
				weapon[i].ClipSize = Convert.ToUInt16(rand_ClipSize.Next(weapon[i].LowerClipLimit, weapon[i].UpperClipLimit));
			}

			return weapon;
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
		public abstract string WeaponName { get; }

		protected ushort _clipSize;

		public ushort ClipSize { get { return _clipSize; } set { _clipSize = value; } }

		public abstract ushort LowerClipLimit { get; }

		public abstract ushort UpperClipLimit { get; }
	}

	#region Revolver
	public abstract class Revolver : Weapon
	{
		public override ushort LowerClipLimit { get { return 5; } }

		public override ushort UpperClipLimit { get { return 12; } }
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
		public override ushort LowerClipLimit { get { return 10; } }

		public override ushort UpperClipLimit { get { return 20; } }
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

		public override ushort LowerClipLimit { get { return 4; } }

		public override ushort UpperClipLimit { get { return 17; } }
	}

	public class BoltActionRifle : Rifle
	{
		public override string WeaponName { get { return "Bolt Action Rifle"; } }

		public override ushort LowerClipLimit { get { return 2; } }

		public override ushort UpperClipLimit { get { return 10; } }
	}

	public class SemiautomaticRifle : Rifle
	{
		public override string WeaponName { get { return "Semiautomatic Rifle"; } }

		public override ushort LowerClipLimit { get { return 5; } }

		public override ushort UpperClipLimit { get { return 30; } }
	}
	#endregion

	#region Shotgun
	public abstract class Shotgun : Weapon { }

	public class BreakActionShotgun : Shotgun
	{
		public override string WeaponName { get { return "Break Action Shotgun"; } }

		public override ushort LowerClipLimit { get { return 1; } }

		public override ushort UpperClipLimit { get { return 2; } }
	}

	public class LeverActionShotgun : Shotgun
	{
		public override string WeaponName { get { return "Lever Action Shotgun"; } }

		public override ushort LowerClipLimit { get { return 5; } }

		public override ushort UpperClipLimit { get { return 6; } }
	}

	public class PumpActionShotgun : Shotgun
	{
		public override string WeaponName { get { return "Pump Action Shotgun"; } }

		public override ushort LowerClipLimit { get { return 4; } }

		public override ushort UpperClipLimit { get { return 5; } }
	}

	public class SemiautomaticShotgun : Shotgun
	{
		public override string WeaponName { get { return "Semiautomatic Shotgun"; } }

		public override ushort LowerClipLimit { get { return 3; } }

		public override ushort UpperClipLimit { get { return 9; } }
	}
	#endregion

	#region Automatics
	public abstract class Automatics : Weapon { }

	public class SubmachineGun : Automatics
	{
		public override string WeaponName { get { return "Submachine Gun"; } }

		public override ushort LowerClipLimit { get { return 10; } }

		public override ushort UpperClipLimit { get { return 50; } }
	}

	public class HeavyMachineGun : Automatics
	{
		public override string WeaponName { get { return "Heavy Machine Gun"; } }

		public override ushort LowerClipLimit { get { return 50; } }

		public override ushort UpperClipLimit { get { return 300; } }
	}

	public class LightMachineGun : Automatics
	{
		public override string WeaponName { get { return "Light Machine Gun"; } }

		public override ushort LowerClipLimit { get { return 50; } }

		public override ushort UpperClipLimit { get { return 100; } }
	}

	public class AssaultRifle : Automatics
	{
		public override string WeaponName { get { return "Assault Rifle"; } }

		public override ushort LowerClipLimit { get { return 15; } }

		public override ushort UpperClipLimit { get { return 30; } }
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
