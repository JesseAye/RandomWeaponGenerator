using System;

namespace WeaponGenerator
{
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
		/// The maximum range a fired round will deliver full effect
		/// </summary>
		protected ushort _effectiveRange;
		/// <summary>
		/// The maximum range a fired round will deliver negligible, if not zero, effect
		/// </summary>
		protected ushort _absMaxRange;
		/// <summary>
		/// The weight of the weapon
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
		/// Set the size of the clip
		/// </summary>
		public ushort SetClipSize { set { _clipSize = value; } }

		//TODO: Potentially needs to be changed from protected to protected
		/// <summary>
		/// The lowest value _clipSize can have
		/// </summary>
		public abstract ushort LowerClipLimit { get; }

		/// <summary>
		/// The highest value _clipSize can have
		/// </summary>
		public abstract ushort UpperClipLimit { get; }

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
	public class Revolver : Weapon
	{
		public override string WeaponName { get { return "Revoler"; } }

		public override ushort LowerClipLimit { get { return 5; } }

		public override ushort UpperClipLimit { get { return 12; } }
	}
	#endregion

	#region Handgun
	/// <summary>
	/// An inheritable base class for Handgun type weapons
	/// </summary>
	public class Handgun : Weapon
	{
		public override ushort LowerClipLimit { get { return 10; } }

		public override ushort UpperClipLimit { get { return 20; } }

		public override string WeaponName { get { return "Handgun"; } }
	}
	#endregion

	#region Rifle
	/// <summary>
	/// An inheritable base class for Rifle type weapons
	/// </summary>
	public abstract class Rifle : Weapon { }

	/// <summary>
	/// Represents a Bolt Action Rifle
	/// </summary>
	public class BoltActionRifle : Rifle
	{
		/// <summary>
		/// The weapon's normal name
		/// </summary>
		public override string WeaponName { get { return "Bolt Action Rifle"; } }

		public override ushort LowerClipLimit { get { return 2; } }

		public override ushort UpperClipLimit { get { return 10; } }
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

		public override ushort LowerClipLimit { get { return 5; } }

		public override ushort UpperClipLimit { get { return 30; } }
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

		public override ushort LowerClipLimit { get { return 1; } }

		public override ushort UpperClipLimit { get { return 2; } }
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

		public override ushort LowerClipLimit { get { return 4; } }

		public override ushort UpperClipLimit { get { return 5; } }
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

		public override ushort LowerClipLimit { get { return 3; } }

		public override ushort UpperClipLimit { get { return 9; } }
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

		public override ushort LowerClipLimit { get { return 10; } }

		public override ushort UpperClipLimit { get { return 50; } }
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

		public override ushort LowerClipLimit { get { return 50; } }

		public override ushort UpperClipLimit { get { return 300; } }
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

		public override ushort LowerClipLimit { get { return 50; } }

		public override ushort UpperClipLimit { get { return 100; } }
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

		public override ushort LowerClipLimit { get { return 15; } }

		public override ushort UpperClipLimit { get { return 30; } }
	}
	#endregion

	//Ref: https://legionary.com/all-types-of-guns-with-pictures-and-names/
	/// <summary>
	/// Represents the different available weapon types able to be generated
	/// </summary>
	public enum WeaponType
	{
		/// <summary>
		/// A revolver
		/// </summary>
		Revolver,
		/// <summary>
		/// A full sized semiautomatic handgun
		/// </summary>
		Handgun,
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
}
