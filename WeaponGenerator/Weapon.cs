using System;

namespace WeaponGenerator
{
	/// <inheritdoc/>
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
		/// The enum value of WeaponType the derived class represents
		/// </summary>
		public abstract WeaponType WeaponType { get; }

		/// <summary>
		/// The lowest value _clipSize can have
		/// </summary>
		public abstract ushort LowerClipLimit { get; }

		/// <summary>
		/// The highest value _clipSize can have
		/// </summary>
		public abstract ushort UpperClipLimit { get; }

		/// <summary>
		/// The lowest value _effectiveRange can have, should be represented as meters
		/// </summary>
		public abstract ushort LowerEffectiveRangeLimit { get; }

		/// <summary>
		/// The highest value _effectiveRange can have, should be represented as meters
		/// </summary>
		public abstract ushort UpperEffectiveRangeLimit { get; }

		/// <summary>
		/// The lowest value _weight can have, should be represented as grams
		/// </summary>
		public abstract ushort LowerWeightLimit { get; }

		/// <summary>
		/// The highest value _weight can have, should be represented as grams
		/// </summary>
		public abstract ushort UpperWeightLimit { get; }

		/// <summary>
		/// The lowest value _reloadTime can have, should be represented as milliseconds
		/// </summary>
		public abstract ushort LowerReloadTimeLimit { get; }

		/// <summary>
		/// The highest value _reloadTime can have, should be represented as milliseconds
		/// </summary>
		public abstract ushort UpperReloadTimeLimit { get; }

		/// <summary>
		/// The lowest value _fireRate can have, should be represented as milliseconds
		/// </summary>
		public abstract ushort LowerFireRateLimit { get; }

		/// <summary>
		/// The highest value _fireRate can have, should be represented as milliseconds
		/// </summary>
		public abstract ushort UpperFireRateLimit { get; }

		/// <summary>
		/// The lowest value _drawSpeed can have, should be represented as milliseconds
		/// </summary>
		public abstract ushort LowerDrawSpeedLimit { get; }

		/// <summary>
		/// The highest value _drawSpeed can have, should be represented as milliseconds
		/// </summary>
		public abstract ushort UpperDrawSpeedLimit { get; }

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
		public float MinimumSpread { get => throw new NotImplementedException(); }

		/// <summary>
		/// The maximum spread pattern the fired projectile will folow
		/// </summary>
		public float MaximumSpread { get => throw new NotImplementedException(); }

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
		public abstract bool CanDualWield { get; }

		/// <summary>
		/// Whether this firearm requires being held by two hands
		/// </summary>
		public abstract bool IsTwoHanded { get; }

		/// <summary>
		/// The amount of time it takes to go from hip-fire to ADS
		/// </summary>
		public TimeSpan DrawSpeed { get { return _drawSpeed; } }

		/// <summary>
		/// The minimum TimeSpan between two rounds being fired
		/// </summary>
		public TimeSpan FireRate { get { return _fireRate; } }

		/// <summary>
		/// Randomize all stats that need to be randomized based on the values setup by the derived class
		/// </summary>
		public Weapon()
		{
			_clipSize = RandomExtension.NormalDistribution(LowerClipLimit, UpperClipLimit, .5f, 3);
			_effectiveRange = RandomExtension.NormalDistribution(LowerEffectiveRangeLimit, UpperEffectiveRangeLimit, .5f, 3);
			_absMaxRange = (ushort)(_effectiveRange * RandomExtension.NormalDistribution_f(1, 2, 1.25f, .5f)); //Not sure I like this explicit cast from float to ushort
			_weight = RandomExtension.NormalDistribution(LowerWeightLimit, UpperWeightLimit, 1.5f, 3);
			_reloadTime = TimeSpan.FromMilliseconds(RandomExtension.NormalDistribution(LowerReloadTimeLimit, UpperReloadTimeLimit, 1.5f, 3));
			_fireRate = TimeSpan.FromMilliseconds(RandomExtension.NormalDistribution(LowerFireRateLimit, UpperFireRateLimit, 1.5f, 3));
			_drawSpeed = TimeSpan.FromMilliseconds(RandomExtension.NormalDistribution(LowerDrawSpeedLimit, UpperDrawSpeedLimit, 1.5f, 3));
		}
	}

	#region Revolver
	/// <summary>
	/// A class for Revolver type weapons
	/// </summary>
	public class Revolver : Weapon
	{
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override string WeaponName { get { return "Revolver"; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override WeaponType WeaponType { get { return WeaponType.Revolver; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerClipLimit { get { return 5; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperClipLimit { get { return 12; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerEffectiveRangeLimit { get { return 15; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperEffectiveRangeLimit { get { return 40; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerWeightLimit { get { return 3000; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperWeightLimit { get { return 8000; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerReloadTimeLimit { get { return 3000; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperReloadTimeLimit { get { return 12000; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerFireRateLimit { get { return 250; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperFireRateLimit { get { return 600; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerDrawSpeedLimit { get { return 100; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperDrawSpeedLimit { get { return 350; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override bool CanDualWield { get { return true; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override bool IsTwoHanded { get { return false; } }
	}
	#endregion

	#region Handgun
	/// <summary>
	/// A class for Handgun type weapons
	/// </summary>
	public class Handgun : Weapon
	{
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override WeaponType WeaponType { get { return WeaponType.Handgun; } }
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerClipLimit { get { return 10; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperClipLimit { get { return 20; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override string WeaponName { get { return "Handgun"; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerEffectiveRangeLimit { get { return 30; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperEffectiveRangeLimit { get { return 75; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerWeightLimit { get { return 800; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperWeightLimit { get { return 1500; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerReloadTimeLimit { get { return 3000; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperReloadTimeLimit { get { return 7000; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerFireRateLimit { get { return 200; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperFireRateLimit { get { return 500; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerDrawSpeedLimit { get { return 100; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperDrawSpeedLimit { get { return 333; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override bool CanDualWield { get { return true; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override bool IsTwoHanded { get { return false; } }
	}
	#endregion

	#region Rifle
	/// <summary>
	/// An inheritable base class for Rifle type weapons
	/// </summary>
	public abstract class Rifle : Weapon
	{
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerEffectiveRangeLimit { get { return 25; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperEffectiveRangeLimit { get { return 150; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerDrawSpeedLimit { get { return 250; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperDrawSpeedLimit { get { return 500; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override bool CanDualWield { get { return false; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override bool IsTwoHanded { get { return true; } }
	}

	// Mosin reload speed single vs stripper clip: https://www.youtube.com/watch?v=NF7AvZnTQYQ
	// single = 17.5 seconds
	// stripper = 5.0 seconds
	/// <summary>
	/// Represents a Bolt Action Rifle, modeled after a Mosin-Nagant
	/// </summary>
	public class BoltActionRifle : Rifle
	{
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override WeaponType WeaponType { get { return WeaponType.BoltActionRifle; } }
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override string WeaponName { get { return "Bolt Action Rifle"; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerClipLimit { get { return 2; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperClipLimit { get { return 10; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerEffectiveRangeLimit { get { return 400; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperEffectiveRangeLimit { get { return 1000; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerWeightLimit { get { return 3000; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperWeightLimit { get { return 6000; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerReloadTimeLimit { get { return 12000; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperReloadTimeLimit { get { return 20000; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerFireRateLimit { get { return 1000; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperFireRateLimit { get { return 2000; } }
	}

	/// <summary>
	/// Represents a Semiautomatic Rifle
	/// </summary>
	public class SemiautomaticRifle : Rifle
	{
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override WeaponType WeaponType { get { return WeaponType.SemiautomaticRifle; } }
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override string WeaponName { get { return "Semiautomatic Rifle"; } }
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerClipLimit { get { return 5; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperClipLimit { get { return 30; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerWeightLimit { get { return 2500; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperWeightLimit { get { return 7000; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerReloadTimeLimit { get { return 6000; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperReloadTimeLimit { get { return 15000; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerFireRateLimit { get { return 200; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperFireRateLimit { get { return 500; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override bool CanDualWield { get { return true; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override bool IsTwoHanded { get { return false; } }
	}
	#endregion

	#region Shotgun
	/// <summary>
	/// An inheritable base class for Shotgun type weapons
	/// </summary>
	public abstract class Shotgun : Weapon
	{

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerEffectiveRangeLimit { get { return 5; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperEffectiveRangeLimit { get { return 30; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override bool CanDualWield { get { return false; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override bool IsTwoHanded { get { return true; } }
	}

	/// <summary>
	/// Represents a Break Action Shotgun
	/// </summary>
	public class BreakActionShotgun : Shotgun
	{
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override WeaponType WeaponType { get { return WeaponType.BreakActionShotgun; } }
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override string WeaponName { get { return "Break Action Shotgun"; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerClipLimit { get { return 1; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperClipLimit { get { return 2; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerWeightLimit { get { return 2500; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperWeightLimit { get { return 4000; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerReloadTimeLimit { get { return 2750; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperReloadTimeLimit { get { return 6000; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerFireRateLimit { get { return 200; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperFireRateLimit { get { return 1000; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerDrawSpeedLimit { get { return 200; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperDrawSpeedLimit { get { return 500; } }
	}

	/// <summary>
	/// Represents a Pump Action Shotgun
	/// </summary>
	public class PumpActionShotgun : Shotgun
	{
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override WeaponType WeaponType { get { return WeaponType.PumpActionShotgun; } }
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override string WeaponName { get { return "Pump Action Shotgun"; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerClipLimit { get { return 4; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperClipLimit { get { return 5; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerWeightLimit { get { return 3000; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperWeightLimit { get { return 4500; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerReloadTimeLimit { get { return 8000; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperReloadTimeLimit { get { return 15000; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerFireRateLimit { get { return 600; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperFireRateLimit { get { return 1500; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerDrawSpeedLimit { get { return 200; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperDrawSpeedLimit { get { return 500; } }
	}

	/// <summary>
	/// Represents a Semiautomatic Shotgun
	/// </summary>
	public class SemiautomaticShotgun : Shotgun
	{
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override WeaponType WeaponType { get { return WeaponType.SemiautomaticShotgun; } }
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override string WeaponName { get { return "Semiautomatic Shotgun"; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerClipLimit { get { return 3; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperClipLimit { get { return 9; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerWeightLimit { get { return 2250; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperWeightLimit { get { return 4000; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerReloadTimeLimit { get { return 4000; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperReloadTimeLimit { get { return 12000; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerFireRateLimit { get { return 500; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperFireRateLimit { get { return 1000; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerDrawSpeedLimit { get { return 200; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperDrawSpeedLimit { get { return 500; } }
	}
	#endregion

	#region Automatics
	/// <summary>
	/// An inheritable base class for Automatic type weapons
	/// </summary>
	public abstract class Automatics : Weapon
	{

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override bool CanDualWield { get { return false; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override bool IsTwoHanded { get { return true; } }
	}

	/// <summary>
	/// Represents a Submachine Gun
	/// </summary>
	public class SubmachineGun : Automatics
	{
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override WeaponType WeaponType { get { return WeaponType.SubmachineGun; } }
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override string WeaponName { get { return "Submachine Gun"; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerClipLimit { get { return 10; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperClipLimit { get { return 50; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerEffectiveRangeLimit { get { return 25; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperEffectiveRangeLimit { get { return 100; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerWeightLimit { get { return 2500; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperWeightLimit { get { return 4500; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerReloadTimeLimit { get { return 2100; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperReloadTimeLimit { get { return 4500; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerFireRateLimit { get { return 180; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperFireRateLimit { get { return 250; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerDrawSpeedLimit { get { return 100; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperDrawSpeedLimit { get { return 333; } }
	}

	/// <summary>
	/// Represents a Heavy Machine Gun
	/// </summary>
	public class HeavyMachineGun : Automatics
	{
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override WeaponType WeaponType { get { return WeaponType.HeavyMachineGun; } }
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override string WeaponName { get { return "Heavy Machine Gun"; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerClipLimit { get { return 50; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperClipLimit { get { return 300; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerEffectiveRangeLimit { get { return 1200; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperEffectiveRangeLimit { get { return 1800; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerWeightLimit { get { return 34000; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperWeightLimit { get { return 42000; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerReloadTimeLimit { get { return 12000; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperReloadTimeLimit { get { return 20000; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerFireRateLimit { get { return 45; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperFireRateLimit { get { return 133; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerDrawSpeedLimit { get { return 400; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperDrawSpeedLimit { get { return 1000; } }
	}

	/// <summary>
	/// Represents a Light Machine Gun, modeled after M249
	/// </summary>
	public class LightMachineGun : Automatics
	{
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override WeaponType WeaponType { get { return WeaponType.LightMachineGun; } }
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override string WeaponName { get { return "Light Machine Gun"; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerClipLimit { get { return 50; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperClipLimit { get { return 100; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerEffectiveRangeLimit { get { return 600; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperEffectiveRangeLimit { get { return 1000; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerWeightLimit { get { return 6500; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperWeightLimit { get { return 12000; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerReloadTimeLimit { get { return 5000; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperReloadTimeLimit { get { return 12000; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerFireRateLimit { get { return 50; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperFireRateLimit { get { return 100; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerDrawSpeedLimit { get { return 300; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperDrawSpeedLimit { get { return 800; } }
	}

	/// <summary>
	/// Represents an Assault Rifle, modeled after AK-47
	/// </summary>
	public class AssaultRifle : Automatics
	{
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override WeaponType WeaponType { get { return WeaponType.AssaultRifle; } }
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override string WeaponName { get { return "Assault Rifle"; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerClipLimit { get { return 15; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperClipLimit { get { return 30; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerEffectiveRangeLimit { get { return 300; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperEffectiveRangeLimit { get { return 500; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerWeightLimit { get { return 3250; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperWeightLimit { get { return 5000; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerReloadTimeLimit { get { return 4000; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperReloadTimeLimit { get { return 8000; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerFireRateLimit { get { return 100; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperFireRateLimit { get { return 150; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort LowerDrawSpeedLimit { get { return 150; } }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override ushort UpperDrawSpeedLimit { get { return 500; } }
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
