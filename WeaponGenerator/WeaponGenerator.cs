﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomWeaponGenerator
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
			uint totalChance = TotalChance;
			int rand = rand_Weapon.Next(0, Convert.ToInt32(totalChance));
			Weapon weapon;
			ushort lowerClipLimit;
			ushort upperClipLimit;

			// I can't believe I made all of this. There has to be a much more effecient way of weighting the random generation
			if (rand < SingleActionRevolverChance)
			{
				weapon = new Weapon() { CurrentWeapon = WeaponType.SingleActionRevolver };
			}

			else
			{
				rand -= SingleActionRevolverChance;

				if (rand < DoubleActionRevolverChance)
				{
					weapon = new Weapon() { CurrentWeapon = WeaponType.DoubleActionRevolver };
				}

				else
				{
					rand -= DoubleActionRevolverChance;

					if (rand < FullSizedHandgunChance)
					{
						weapon = new Weapon() { CurrentWeapon = WeaponType.FullSizedHandgun };
					}

					else
					{
						rand -= FullSizedHandgunChance;

						if (rand < CompactHandgunChance)
						{
							weapon = new Weapon() { CurrentWeapon = WeaponType.CompactHandgun };
						}

						else
						{
							rand -= CompactHandgunChance;

							if (rand < SubcompactHandgunChance)
							{
								weapon = new Weapon() { CurrentWeapon = WeaponType.SubcompactHandgun };
							}

							else
							{
								rand -= SubcompactHandgunChance;

								if (rand < MicrocompactHandgunChance)
								{
									weapon = new Weapon() { CurrentWeapon = WeaponType.MicrocompactHandgun };
								}

								else
								{
									rand -= MicrocompactHandgunChance;

									if (rand < LeverActionRifleChance)
									{
										weapon = new Weapon() { CurrentWeapon = WeaponType.LeverActionRifle };
									}

									else
									{
										rand -= LeverActionRifleChance;

										if (rand < BoltActionRifleChance)
										{
											weapon = new Weapon() { CurrentWeapon = WeaponType.BoltActionRifle };
										}

										else
										{
											rand -= BoltActionRifleChance;

											if (rand < SemiautomaticRifleChance)
											{
												weapon = new Weapon() { CurrentWeapon = WeaponType.SemiautomaticRifle };
											}

											else
											{
												rand -= SemiautomaticRifleChance;

												if (rand < BreakActionShotgunChance)
												{
													weapon = new Weapon() { CurrentWeapon = WeaponType.BreakActionShotgun };
												}

												else
												{
													rand -= BreakActionShotgunChance;

													if (rand < LeverActionShotgunChance)
													{
														weapon = new Weapon() { CurrentWeapon = WeaponType.LeverActionShotgun };
													}

													else
													{
														rand -= LeverActionShotgunChance;

														if (rand < PumpActionShotgunChance)
														{
															weapon = new Weapon() { CurrentWeapon = WeaponType.PumpActionShotgun };
														}

														else
														{
															rand -= PumpActionShotgunChance;

															if (rand < SemiautomaticShotgunChance)
															{
																weapon = new Weapon() { CurrentWeapon = WeaponType.SemiautomaticShotgun };
															}

															else
															{
																rand -= SemiautomaticShotgunChance;

																if (rand < SubmachineGunChance)
																{
																	weapon = new Weapon() { CurrentWeapon = WeaponType.SubmachineGun };
																}

																else
																{
																	rand -= SubmachineGunChance;

																	if (rand < HeavyMachinGunChance)
																	{
																		weapon = new Weapon() { CurrentWeapon = WeaponType.HeavyMachineGun };
																	}

																	else
																	{
																		rand -= HeavyMachinGunChance;

																		if (rand < LightMachineGunChance)
																		{
																			weapon = new Weapon() { CurrentWeapon = WeaponType.LightMachineGun };
																		}

																		else
																		{
																			rand -= LightMachineGunChance;

																			if (rand < AssaultRifleChance)
																			{
																				weapon = new Weapon() { CurrentWeapon = WeaponType.AssaultRifle };
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

			for (int i = 0; i < Amount; i++)
			{
				// Calling this method several times and having a new Random object created each iteration may not be as efficient as just
				// duplicating code and running a single Random object
				// Difference in time seemed negligible as far as I could personally perceive
				weapon[i] = GenerateRandomWeapon();
			}

			return weapon;
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