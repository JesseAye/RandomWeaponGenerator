using System;
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
		private ushort _revolverChance = 1,
			_handgunChance = 1,
			_boltActionRifleChance = 1,
			_semiautomaticRifleChance = 1,
			_breakActionShotgunChance = 1,
			_pumpShotgunChance = 1,
			_semiautomaticShotgunChance = 1,
			_submachineGunChance = 1,
			_heavyMachinGunChance = 1,
			_lightMachineGunChance = 1,
			_assaultRifleChance = 1;

		/// <summary>
		/// The chance to spawn this weapon; the higher the number, the higher the chance
		/// </summary>
		public ushort RevolverChance { get { return _revolverChance; } set { _revolverChance = value; } }
		/// <summary>
		/// The chance to spawn this weapon; the higher the number, the higher the chance
		/// </summary>
		public ushort HandgunChance { get { return _handgunChance; } set { _handgunChance = value; } }
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
				return Convert.ToUInt32(RevolverChance + HandgunChance + BoltActionRifleChance + SemiautomaticRifleChance + BreakActionShotgunChance + PumpActionShotgunChance
										+ SemiautomaticShotgunChance + SubmachineGunChance + HeavyMachinGunChance + LightMachineGunChance + AssaultRifleChance);
			}
		}

		/// <summary>
		/// Set all weapon types to an equal chance to generate
		/// </summary>
		/// <param name="value">The ushort to apply to all weapon type chances</param>
		public void AllWeaponsEqualChance(ushort value)
		{
			_revolverChance = value;
			_handgunChance = value;
			_boltActionRifleChance = value;
			_semiautomaticRifleChance = value;
			_breakActionShotgunChance = value;
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

			for (int i = 0; i < RevolverChance; i++)
			{
				ChancePool.Add(WeaponType.Revolver);
			}

			for (int i = 0; i < HandgunChance; i++)
			{
				ChancePool.Add(WeaponType.Handgun);
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
}
