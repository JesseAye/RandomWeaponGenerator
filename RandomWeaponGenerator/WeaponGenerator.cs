using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomWeaponGenerator
{
	class WeaponGenerator
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
		public ushort DoubleActionRevolverChance { get { return _doubleActionRevolverChance;} set { _doubleActionRevolverChance = value; } }
		public ushort FullSizedHandgunChance { get { return _fullSizedHandgunChance; } set { _fullSizedHandgunChance = value; } }
		public ushort CompactHandgunChance { get { return _compactHandgunChance; } set { _compactHandgunChance = value; } }
		public ushort SubcompactHandgunChance { get { return _subcompactHandgunChance; } set { _subcompactHandgunChance = value; } }
		public ushort MicrocompactHandgunChance { get { return _microcompactHandgunChance; } set { _microcompactHandgunChance = value; } }
		public ushort LeverActionRifleChance { get { return _leverActionRifleChance; } set { _leverActionRifleChance = value; } }
		public ushort BoltActionRifleChance { get { return _boltActionRifleChance; } set { _boltActionRifleChance = value; } }
		public ushort SemiautomaticRifleChance { get { return _semiautomaticRifleChance; } set { _semiautomaticRifleChance = value; } }
		public ushort BreakActionShotgunChance { get { return _breakActionShotgunChance; } set { _breakActionShotgunChance = value; } }
		public ushort LeverActionShotgunChance { get { return _leverActionShotgunChance; } set { _leverActionShotgunChance = value; } }
		public ushort PumpShotgunChance { get { return _pumpShotgunChance; } set { _pumpShotgunChance = value; } }
		public ushort SemiautomaticShotgunChance { get { return _semiautomaticShotgunChance; } set { _semiautomaticShotgunChance = value; } }
		public ushort SubmachineGunChance { get { return _submachineGunChance; } set { _submachineGunChance = value; } }
		public ushort HeavyMachinGunChance { get { return _heavyMachinGunChance; } set { _heavyMachinGunChance = value; } }
		public ushort LightMachineGunChance { get { return _lightMachineGunChance; } set { _lightMachineGunChance = value; } }
		public ushort AssaultRifleChance { get { return _assaultRifleChance; } set { _assaultRifleChance = value; } }


		public WeaponGenerator()
		{

		}
	}

	class Weapon
	{
		private WeaponType _weaponType;
		public WeaponType CurrentWeapon { get { return _weaponType; } }
	}

	//Ref: https://legionary.com/all-types-of-guns-with-pictures-and-names/
	enum WeaponType
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
