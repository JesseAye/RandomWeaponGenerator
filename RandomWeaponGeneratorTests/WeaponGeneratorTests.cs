using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace WeaponGenerator.Tests
{
	[TestClass()]
	public class WeaponGeneratorTests
	{
		readonly int IterationsToTest = 10000;

		/// <summary>
		/// Asserts WeaponGenerator.GenerateRandomWeapon() will not generate a null Weapon
		/// </summary>
		[TestMethod()]
		public void GenerateRandomWeaponTest()
		{
			WeaponGenerator weaponGen = new();

			for (int i = 0; i < IterationsToTest; i++)
			{
				Assert.IsNotNull(weaponGen.GenerateRandomWeapon().WeaponName);
			}
		}

		/// <summary>
		/// Asserts WeaponGenerator.GenerateRandomWeapon(int Amount) will not generate null Weapons, and each weapon has been generated
		/// </summary>
		[TestMethod()]
		public void GenerateRandomWeaponsTest()
		{
			WeaponGenerator weaponGen = new();
			weaponGen.AllWeaponsEqualChance(1);
			Weapon[] weapons = weaponGen.GenerateRandomWeapon(IterationsToTest);

			//Assert each weapon is not null
			for (int i = 0; i < weapons.Length; i++)
			{
				Assert.IsNotNull(weapons[i].WeaponName);
			}

			//Assert each weapon has been generated at least once
			foreach (WeaponType weaponType in Enum.GetValues(typeof(WeaponType)))
			{
				Assert.IsTrue(weapons.Where(i => i.GetType().ToString() == "WeaponGenerator." + weaponType.ToString())?.Count() > 0);
			}
		}

		/// <summary>
		/// Asserts valid clip sizes for each type of weapon
		/// </summary>
		[TestMethod()]
		public void CheckValidClipSize()
		{
			WeaponGenerator weaponGen = new();

			Weapon[] weapons = new Weapon[IterationsToTest];
			weapons = weaponGen.GenerateRandomWeapon(IterationsToTest);

			foreach (WeaponType type in Enum.GetValues(typeof(WeaponType)))
			{
				Weapon[] testweapons = weapons.Where(weapon => weapon.WeaponType == type).ToArray();

				foreach (Weapon weapon in testweapons)
				{
					Assert.IsTrue((weapon.ClipSize >= weapon.LowerClipLimit) && (weapon.ClipSize <= weapon.UpperClipLimit));
				}
			}

			/*
			 * 
			weaponGen.AllWeaponsEqualChance(0);

			weaponGen.SetChance(WeaponType.Revolver, 1);

			for (int i = 0; i < IterationsToTest; i++)
			{
				Weapon weapon = weaponGen.GenerateRandomWeapon();
				Assert.IsTrue(weapon.ClipSize >= weapon.LowerClipLimit && weapon.ClipSize <= weapon.UpperClipLimit);
			}

			for (int i = 0; i < IterationsToTest; i++)
			{
				ushort clip = weaponGen.GenerateRandomWeapon().ClipSize;

				Assert.IsTrue(clip >= 5 && clip <= 12);
			}

			weaponGen.SetChance(WeaponType.Revolver, 0);
			weaponGen.SetChance(WeaponType.Handgun, 1);

			for (int i = 0; i < IterationsToTest; i++)
			{
				ushort clip = weaponGen.GenerateRandomWeapon().ClipSize;

				Assert.IsTrue(clip >= 10 && clip <= 20);
			}

			weaponGen.SetChance(WeaponType.Handgun, 0);
			weaponGen.SetChance(WeaponType.BoltActionRifle, 1);

			for (int i = 0; i < IterationsToTest; i++)
			{
				ushort clip = weaponGen.GenerateRandomWeapon().ClipSize;

				Assert.IsTrue(clip >= 2 && clip <= 10);
			}

			weaponGen.SetChance(WeaponType.BoltActionRifle, 0);
			weaponGen.SetChance(WeaponType.SemiautomaticRifle, 1);

			for (int i = 0; i < IterationsToTest; i++)
			{
				ushort clip = weaponGen.GenerateRandomWeapon().ClipSize;

				Assert.IsTrue(clip >= 5 && clip <= 30);
			}

			weaponGen.SetChance(WeaponType.SemiautomaticRifle, 0);
			weaponGen.SetChance(WeaponType.BreakActionShotgun, 1);

			for (int i = 0; i < IterationsToTest; i++)
			{
				ushort clip = weaponGen.GenerateRandomWeapon().ClipSize;

				Assert.IsTrue(clip >= 1 && clip <= 2);
			}

			weaponGen.SetChance(WeaponType.BreakActionShotgun, 0);
			weaponGen.SetChance(WeaponType.PumpActionShotgun, 1);

			for (int i = 0; i < IterationsToTest; i++)
			{
				ushort clip = weaponGen.GenerateRandomWeapon().ClipSize;

				Assert.IsTrue(clip >= 4 && clip <= 5);
			}

			weaponGen.SetChance(WeaponType.PumpActionShotgun, 0);
			weaponGen.SetChance(WeaponType.SemiautomaticShotgun, 1);

			for (int i = 0; i < IterationsToTest; i++)
			{
				ushort clip = weaponGen.GenerateRandomWeapon().ClipSize;

				Assert.IsTrue(clip >= 3 && clip <= 9);
			}

			weaponGen.SetChance(WeaponType.SemiautomaticShotgun, 0);
			weaponGen.SetChance(WeaponType.SubmachineGun, 1);

			for (int i = 0; i < IterationsToTest; i++)
			{
				ushort clip = weaponGen.GenerateRandomWeapon().ClipSize;

				Assert.IsTrue(clip >= 10 && clip <= 50);
			}

			weaponGen.SetChance(WeaponType.SubmachineGun, 0);
			weaponGen.SetChance(WeaponType.HeavyMachineGun, 1);

			for (int i = 0; i < IterationsToTest; i++)
			{
				ushort clip = weaponGen.GenerateRandomWeapon().ClipSize;

				Assert.IsTrue(clip >= 50 && clip <= 300);
			}

			weaponGen.SetChance(WeaponType.HeavyMachineGun, 0);
			weaponGen.SetChance(WeaponType.LightMachineGun, 1);

			for (int i = 0; i < IterationsToTest; i++)
			{
				ushort clip = weaponGen.GenerateRandomWeapon().ClipSize;

				Assert.IsTrue(clip >= 50 && clip <= 100);
			}

			weaponGen.SetChance(WeaponType.LightMachineGun, 0);
			weaponGen.SetChance(WeaponType.AssaultRifle, 1);

			for (int i = 0; i < IterationsToTest; i++)
			{
				ushort clip = weaponGen.GenerateRandomWeapon().ClipSize;

				Assert.IsTrue(clip >= 15 && clip <= 30);
			}
			*
			*/
		}

		/// <summary>
		/// This probably isn't the most effective Unit Test, but let's just make sure NormalDistribution isn't horribly broken
		/// </summary>
		[TestMethod]
		public void NormalDistributionTest()
		{
			ushort[] Iterations = new ushort[IterationsToTest];
			for (int i = 0; i < IterationsToTest; i++)
			{
				Iterations[i] = RandomExtension.NormalDistribution(50, 300, .5f, 3);
				Assert.IsTrue(Iterations[i] is >= 50 and <= 300);
			}
		}
	}
}