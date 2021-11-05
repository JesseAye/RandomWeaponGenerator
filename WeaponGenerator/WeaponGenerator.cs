using System;
using System.Collections.Generic;

namespace WeaponGenerator
{
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
		public ushort PumpActionShotgunChance { get { return _pumpShotgunChance; } set { _pumpShotgunChance = value; } }
		public ushort SemiautomaticShotgunChance { get { return _semiautomaticShotgunChance; } set { _semiautomaticShotgunChance = value; } }
		public ushort SubmachineGunChance { get { return _submachineGunChance; } set { _submachineGunChance = value; } }
		public ushort HeavyMachinGunChance { get { return _heavyMachinGunChance; } set { _heavyMachinGunChance = value; } }
		public ushort LightMachineGunChance { get { return _lightMachineGunChance; } set { _lightMachineGunChance = value; } }
		public ushort AssaultRifleChance { get { return _assaultRifleChance; } set { _assaultRifleChance = value; } }

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
		/// Sum of all weapon generation chances
		/// </summary>
		public uint TotalChance { get {
				return Convert.ToUInt32(SingleActionRevolverChance + DoubleActionRevolverChance + FullSizedHandgunChance + CompactHandgunChance + SubcompactHandgunChance
											+ MicrocompactHandgunChance + LeverActionRifleChance + BoltActionRifleChance + SemiautomaticRifleChance + BreakActionShotgunChance
											+ LeverActionShotgunChance + PumpActionShotgunChance + SemiautomaticShotgunChance + SubmachineGunChance + HeavyMachinGunChance
											+ LightMachineGunChance + AssaultRifleChance);
			} }

		/// <summary>
		/// Generate a single instance of a randomly generated Weapon
		/// </summary>
		/// <returns>Randomly generated Weapon</returns>
		public Weapon GenerateRandomWeapon()
		{
			Random rand_Weapon = new();
			Random rand_ClipSize = new();
			int rand = rand_Weapon.Next(0, Convert.ToInt32(TotalChance));
			Weapon weapon;
			ushort lowerClipLimit;
			ushort upperClipLimit;

			weapon = new() { CurrentWeapon = CalculateWeaponTypeFromChance(rand) };

			/* Ref
			 * Revolver: https://en.wikipedia.org/wiki/Revolver
			 * Handgun: https://www.cato.org/legal-policy-bulletin/losing-count-empty-case-high-capacity-magazine-restrictions
			 * Lever Action Rifle: https://www.quora.com/How-many-bullets-does-a-lever-action-rifle-carry
			 * Bolt Action Rifle: https://en.wikipedia.org/wiki/Bolt_action
			 * Semiautomatic Rifle: https://www.quora.com/Do-all-semi-automatic-assault-guns-have-high-capacity-magazine-clips
			 * Break/Pump/Semiautomatic Shotgun: https://lundestudio.com/how-many-shells-can-a-shotgun-hold/
			 * Lever Action Shotgun: https://www.thegunsource.com/best-lever-action-shotguns/
			 * Submachine Gun: https://www.britannica.com/technology/submachine-gun
			 * Heavy Machine Gun: https://en.wikipedia.org/wiki/Belt_(firearms)
			 * Light Machine Gun: https://en.wikipedia.org/wiki/Drum_magazine
			 * Assault Rifles: https://congressionalsportsmen.org/policies/state/full-capacity-magazines
			 */
			switch (weapon.CurrentWeapon)
			{
				case WeaponType.SingleActionRevolver:
					lowerClipLimit = 5;
					upperClipLimit = 12;
					break;
				case WeaponType.DoubleActionRevolver:
					lowerClipLimit = 5;
					upperClipLimit = 12;
					break;
				case WeaponType.FullSizedHandgun:
					lowerClipLimit = 10;
					upperClipLimit = 20;
					break;
				case WeaponType.CompactHandgun:
					lowerClipLimit = 10;
					upperClipLimit = 20;
					break;
				case WeaponType.SubcompactHandgun:
					lowerClipLimit = 10;
					upperClipLimit = 20;
					break;
				case WeaponType.MicrocompactHandgun:
					lowerClipLimit = 10;
					upperClipLimit = 20;
					break;
				case WeaponType.LeverActionRifle:
					lowerClipLimit = 4;
					upperClipLimit = 17;
					break;
				case WeaponType.BoltActionRifle:
					lowerClipLimit = 2;
					upperClipLimit = 10;
					break;
				case WeaponType.SemiautomaticRifle:
					lowerClipLimit = 5;
					upperClipLimit = 30;
					break;
				case WeaponType.BreakActionShotgun:
					lowerClipLimit = 1;
					upperClipLimit = 2;
					break;
				case WeaponType.LeverActionShotgun:
					lowerClipLimit = 5;
					upperClipLimit = 6;
					break;
				case WeaponType.PumpActionShotgun:
					lowerClipLimit = 4;
					upperClipLimit = 5;
					break;
				case WeaponType.SemiautomaticShotgun:
					lowerClipLimit = 3;
					upperClipLimit = 9;
					break;
				case WeaponType.SubmachineGun:
					lowerClipLimit = 10;
					upperClipLimit = 50;
					break;
				case WeaponType.HeavyMachineGun:
					lowerClipLimit = 50;
					upperClipLimit = 300;
					break;
				case WeaponType.LightMachineGun:
					lowerClipLimit = 50;
					upperClipLimit = 100;
					break;
				case WeaponType.AssaultRifle:
					lowerClipLimit = 15;
					upperClipLimit = 30;
					break;
				default:
					throw new WeaponTypeNotFoundException();
			}

			weapon.ClipSize = Convert.ToUInt16(rand_ClipSize.Next(lowerClipLimit, upperClipLimit));

			return weapon;
		}

		/// <summary>
		/// Generate an amount of randomly generated Weapons
		/// </summary>
		/// <param name="Amount">Number of Weapons to generate</param>
		/// <returns>Array of Weapons</returns>
		public Weapon[] GenerateRandomWeapon(int Amount)
		{
			Weapon[] weapon = new Weapon[Amount];
			Random rand_Weapon = new();
			int rand;

			for (int i = 0; i < Amount; i++)
			{
				rand = rand_Weapon.Next(0, Convert.ToInt32(TotalChance));
				weapon[i] = new() { CurrentWeapon = CalculateWeaponTypeFromChance(rand) };
			}

			return weapon;
		}

		/// <summary>
		/// Calculates which weapon is to be generated. There has to be a way better way of doing this.
		/// </summary>
		/// <param name="rand">The randomly generated number</param>
		/// <returns>The WeaponType to be generated</returns>
		private WeaponType CalculateWeaponTypeFromChance(int rand)
		{
			if (rand < SingleActionRevolverChance)
			{
				return WeaponType.SingleActionRevolver;
			}

			else
			{
				rand -= SingleActionRevolverChance;

				if (rand < DoubleActionRevolverChance)
				{
					return WeaponType.DoubleActionRevolver;
				}

				else
				{
					rand -= DoubleActionRevolverChance;

					if (rand < FullSizedHandgunChance)
					{
						return WeaponType.FullSizedHandgun;
					}

					else
					{
						rand -= FullSizedHandgunChance;

						if (rand < CompactHandgunChance)
						{
							return  WeaponType.CompactHandgun;
						}

						else
						{
							rand -= CompactHandgunChance;

							if (rand < SubcompactHandgunChance)
							{
								return WeaponType.SubcompactHandgun;
							}

							else
							{
								rand -= SubcompactHandgunChance;

								if (rand < MicrocompactHandgunChance)
								{
									return WeaponType.MicrocompactHandgun;
								}

								else
								{
									rand -= MicrocompactHandgunChance;

									if (rand < LeverActionRifleChance)
									{
										return WeaponType.LeverActionRifle;
									}

									else
									{
										rand -= LeverActionRifleChance;

										if (rand < BoltActionRifleChance)
										{
											return WeaponType.BoltActionRifle;
										}

										else
										{
											rand -= BoltActionRifleChance;

											if (rand < SemiautomaticRifleChance)
											{
												return WeaponType.SemiautomaticRifle;
											}

											else
											{
												rand -= SemiautomaticRifleChance;

												if (rand < BreakActionShotgunChance)
												{
													return WeaponType.BreakActionShotgun;
												}

												else
												{
													rand -= BreakActionShotgunChance;

													if (rand < LeverActionShotgunChance)
													{
														return WeaponType.LeverActionShotgun;
													}

													else
													{
														rand -= LeverActionShotgunChance;

														if (rand < PumpActionShotgunChance)
														{
															return WeaponType.PumpActionShotgun;
														}

														else
														{
															rand -= PumpActionShotgunChance;

															if (rand < SemiautomaticShotgunChance)
															{
																return WeaponType.SemiautomaticShotgun;
															}

															else
															{
																rand -= SemiautomaticShotgunChance;

																if (rand < SubmachineGunChance)
																{
																	return WeaponType.SubmachineGun;
																}

																else
																{
																	rand -= SubmachineGunChance;

																	if (rand < HeavyMachinGunChance)
																	{
																		return WeaponType.HeavyMachineGun;
																	}

																	else
																	{
																		rand -= HeavyMachinGunChance;

																		if (rand < LightMachineGunChance)
																		{
																			return WeaponType.LightMachineGun;
																		}

																		else
																		{
																			rand -= LightMachineGunChance;

																			if (rand < AssaultRifleChance)
																			{
																				return WeaponType.AssaultRifle;
																			}

																			else
																			{
																				throw new WeaponTypeNotFoundException();
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
	}

	/// <summary>
	/// A weapon with several specifications about the weapon
	/// </summary>
	public class Weapon
	{
		private WeaponType _currentWeapon;
		public WeaponType CurrentWeapon { get { return _currentWeapon; } set { _currentWeapon = value; } }

		/// <summary>
		/// Get the Weapon Type as a string
		/// </summary>
		public string WeaponTypeName { get {
				return _currentWeapon switch // Thanks IntelliSense for making this cleaner!
				{
					WeaponType.SingleActionRevolver => "Single Action Revolver",
					WeaponType.DoubleActionRevolver => "Double Action Revolver",
					WeaponType.FullSizedHandgun => "Full Sized Handgun",
					WeaponType.CompactHandgun => "Compact Handgun",
					WeaponType.SubcompactHandgun => "Sub-Compact Handgun",
					WeaponType.MicrocompactHandgun => "Micro-Compact Handgun",
					WeaponType.LeverActionRifle => "Lever Action Rifle",
					WeaponType.BoltActionRifle => "Bolt Action Rifle",
					WeaponType.SemiautomaticRifle => "Semi-Automatic Rifle",
					WeaponType.BreakActionShotgun => "Break Action Shotgun",
					WeaponType.LeverActionShotgun => "Lever Action Shotgun",
					WeaponType.PumpActionShotgun => "Pump Action Shotgun",
					WeaponType.SemiautomaticShotgun => "Semi-Automatic Shotgun",
					WeaponType.SubmachineGun => "Submachine Gun",
					WeaponType.HeavyMachineGun => "Heavy Machine Gun",
					WeaponType.LightMachineGun => "Light Machine Gun",
					WeaponType.AssaultRifle => "Assault Rifle",
					_ => throw new WeaponTypeNotFoundException(),
				};
			} }

		private ushort _clipSize;
		public ushort ClipSize { get { return _clipSize; } set { _clipSize = value; } }
	}

	//For how to instantiate object with certain class type based on Enum value:
	//https://stackoverflow.com/questions/25640344/how-to-dynamically-create-an-object-based-on-the-name-of-the-enum-without-switc/25640465
	public class WeaponGeneratorNew
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

		public WeaponBase GenerateRandomWeapon()
		{
			WeaponBase weapon;
			Random rand_Weapon = new();
			int rand = rand_Weapon.Next(0, Convert.ToInt32(TotalChance));

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
				ChancePool.Add(WeaponType.SingleActionRevolver);
			}

			weapon = (WeaponBase)GetWeapon(ChancePool[rand]);

			return weapon;
		}

		/// <summary>
		/// Convert the WeaponType into the actual type it represents
		/// </summary>
		/// <param name="weaponType">WeaponType to create</param>
		/// <seealso href="https://stackoverflow.com/questions/25640344/how-to-dynamically-create-an-object-based-on-the-name-of-the-enum-without-switc/25640465">Thanks MatteoSp!</seealso>
		/// <returns>An instance of the WeaponType</returns>
		private static object GetWeapon(WeaponType weaponType)
		{
			string ns = typeof(WeaponType).Namespace;
			string typeName = ns + "." + weaponType.ToString();

			return Activator.CreateInstance(Type.GetType(typeName));
		}
	}

	public abstract class WeaponBase
	{
		public abstract string WeaponName { get; }

		protected ushort _clipSize;

		public ushort ClipSize { get { return _clipSize; } set { _clipSize = value; } }

		public abstract ushort LowerClipLimit { get; }

		public abstract ushort UpperClipLimit { get; }
	}

	#region Revolver
	public abstract class Revolver : WeaponBase
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
	public abstract class Handgun : WeaponBase
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

	public class SubcompactHangun : Handgun
	{
		public override string WeaponName { get { return "Subcompact Handgun"; } }
	}

	public class MicrocompactHandgun : Handgun
	{
		public override string WeaponName { get { return "Microcompact Handgun"; } }
	}
	#endregion

	#region Rifle
	public abstract class Rifle : WeaponBase { }

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
	public abstract class Shotgun : WeaponBase { }

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
	public abstract class Automatics : WeaponBase { }

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
