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
		private Dictionary<WeaponType, ushort> _chance = new Dictionary<WeaponType, ushort>();

		/// <summary>
		/// The Dictionary of chances for each WeaponType to spawn
		/// </summary>
		public Dictionary<WeaponType, ushort> Chance { get { return _chance; } }

		/// <summary>
		/// Set the chance to spawn value of a particular WeaponType
		/// </summary>
		/// <param name="weaponType">The WeaponType to chance spawn chance</param>
		/// <param name="chance">The chance to spawn it</param>
		public void SetChance(WeaponType weaponType, ushort chance)
		{
			_chance[weaponType] = chance;
		}
		
		/// <summary>
		/// Converts _chance into a flat array
		/// </summary>
		/// <returns>An array of WeaponType</returns>
		private WeaponType[] FlattenChanceToArray()
		{
			List<WeaponType> weaponChances = new();

			foreach (KeyValuePair<WeaponType, ushort> weapon in _chance)
			{
				for (int i = 0; i < weapon.Value; i++)
				{
					weaponChances.Add(weapon.Key);
				}
			}

			return weaponChances.ToArray();
		}

		/// <summary>
		/// Setup WeaponGenerator class, and add each WeaponType value to the variable Chance, all with a default value of 1
		/// </summary>
		public WeaponGenerator()
		{
			foreach (WeaponType weapon in Enum.GetValues(typeof(WeaponType)))
			{
				_chance.Add(weapon, 1);
			}
		}

		/// <summary>
		/// Sum of all weapon generation chances
		/// </summary>
		public ushort TotalChance
		{
			get
			{
				ushort val = 0;
				foreach (ushort value in Chance.Values)
				{
					val += value;
				}
				return val;
			}
		}

		/// <summary>
		/// Set all weapon types to an equal chance to generate
		/// </summary>
		/// <param name="value">The ushort to apply to all weapon type chances</param>
		public void AllWeaponsEqualChance(ushort value)
		{
			foreach (WeaponType weaponType in _chance.Keys)
			{
				_chance[weaponType] = value;
			}
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

			weapon = GetWeapon(FlattenChanceToArray()[rand]);
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
			WeaponType[] ChancePool = FlattenChanceToArray();

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

		//This helped me understand Normal Distributions: https://www.easycalculation.com/statistics/bell-curve-calculator.php
		//This gave me the base code: https://www.reddit.com/r/Unity2D/comments/48058a/how_to_approximate_a_bell_curve_gaussian/
		/// <summary>
		/// Normal distribution bell curve base for clip size with a target Normal Distribution of 95.45%
		/// </summary>
		/// <param name="MinimumRounds">The minimum amount of rounds the clip can hold</param>
		/// <param name="MaximumRounds">The maximum amount of rounds the clip can hold</param>
		/// <returns>A random number, with a mean in the center of MinimumRounds and MaximumRounds</returns>
		public static ushort RandomGenerationBellCurve(ushort MinimumRounds, ushort MaximumRounds)
		{
			Random rnd = new Random();
			float Mean = (MinimumRounds + MaximumRounds) / 2;
			float StdDev = (Mean - MinimumRounds) / 2;
			ushort data;
			float generatedFloat;

			//TODO: Shift distribution closer to MinimumRounds
			do
			{
				float u1 = float.Parse(rnd.NextDouble().ToString());
				float u2 = float.Parse(rnd.NextDouble().ToString());
				float randStdNormal = float.Parse((Math.Sqrt(-2.0f * Math.Log(u1)) * Math.Sin(2.0f * Math.PI * u2)).ToString());

				generatedFloat = Mean + StdDev * randStdNormal;
			} while ((generatedFloat < MinimumRounds) || (generatedFloat > MaximumRounds));

			Decimal generatedDecimal = Convert.ToDecimal(generatedFloat);
			data = Convert.ToUInt16(Decimal.Round(generatedDecimal, 0, MidpointRounding.ToPositiveInfinity));

			return data;
		}
	}
}
