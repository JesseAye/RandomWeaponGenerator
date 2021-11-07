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
			weaponGen.AllWeaponsEqualChance(0);

			weaponGen.SingleActionRevolverChance = 1;

			for (int i = 0; i < IterationsToTest; i++)
			{
				ushort clip = weaponGen.GenerateRandomWeapon().ClipSize;

				Assert.IsTrue(clip >= 5 && clip <= 12);
			}

			weaponGen.SingleActionRevolverChance = 0;
			weaponGen.DoubleActionRevolverChance = 1;

			for (int i = 0; i < IterationsToTest; i++)
			{
				ushort clip = weaponGen.GenerateRandomWeapon().ClipSize;

				Assert.IsTrue(clip >= 5 && clip <= 12);
			}

			weaponGen.DoubleActionRevolverChance = 0;
			weaponGen.FullSizedHandgunChance = 1;

			for (int i = 0; i < IterationsToTest; i++)
			{
				ushort clip = weaponGen.GenerateRandomWeapon().ClipSize;

				Assert.IsTrue(clip >= 10 && clip <= 20);
			}

			weaponGen.FullSizedHandgunChance = 0;
			weaponGen.CompactHandgunChance = 1;

			for (int i = 0; i < IterationsToTest; i++)
			{
				ushort clip = weaponGen.GenerateRandomWeapon().ClipSize;

				Assert.IsTrue(clip >= 10 && clip <= 20);
			}

			weaponGen.CompactHandgunChance = 0;
			weaponGen.SubcompactHandgunChance = 1;

			for (int i = 0; i < IterationsToTest; i++)
			{
				ushort clip = weaponGen.GenerateRandomWeapon().ClipSize;

				Assert.IsTrue(clip >= 10 && clip <= 20);
			}

			weaponGen.SubcompactHandgunChance = 0;
			weaponGen.MicrocompactHandgunChance = 1;

			for (int i = 0; i < IterationsToTest; i++)
			{
				ushort clip = weaponGen.GenerateRandomWeapon().ClipSize;

				Assert.IsTrue(clip >= 10 && clip <= 20);
			}

			weaponGen.MicrocompactHandgunChance = 0;
			weaponGen.LeverActionRifleChance = 1;

			for (int i = 0; i < IterationsToTest; i++)
			{
				ushort clip = weaponGen.GenerateRandomWeapon().ClipSize;

				Assert.IsTrue(clip >= 4 && clip <= 17);
			}

			weaponGen.LeverActionRifleChance = 0;
			weaponGen.BoltActionRifleChance = 1;

			for (int i = 0; i < IterationsToTest; i++)
			{
				ushort clip = weaponGen.GenerateRandomWeapon().ClipSize;

				Assert.IsTrue(clip >= 2 && clip <= 10);
			}

			weaponGen.BoltActionRifleChance = 0;
			weaponGen.SemiautomaticRifleChance = 1;

			for (int i = 0; i < IterationsToTest; i++)
			{
				ushort clip = weaponGen.GenerateRandomWeapon().ClipSize;

				Assert.IsTrue(clip >= 5 && clip <= 30);
			}

			weaponGen.SemiautomaticRifleChance = 0;
			weaponGen.BreakActionShotgunChance = 1;

			for (int i = 0; i < IterationsToTest; i++)
			{
				ushort clip = weaponGen.GenerateRandomWeapon().ClipSize;

				Assert.IsTrue(clip >= 1 && clip <= 2);
			}

			weaponGen.BreakActionShotgunChance = 0;
			weaponGen.LeverActionShotgunChance = 1;

			for (int i = 0; i < IterationsToTest; i++)
			{
				ushort clip = weaponGen.GenerateRandomWeapon().ClipSize;

				Assert.IsTrue(clip >= 5 && clip <= 6);
			}

			weaponGen.LeverActionShotgunChance = 0;
			weaponGen.PumpActionShotgunChance = 1;

			for (int i = 0; i < IterationsToTest; i++)
			{
				ushort clip = weaponGen.GenerateRandomWeapon().ClipSize;

				Assert.IsTrue(clip >= 4 && clip <= 5);
			}

			weaponGen.PumpActionShotgunChance = 0;
			weaponGen.SemiautomaticShotgunChance = 1;

			for (int i = 0; i < IterationsToTest; i++)
			{
				ushort clip = weaponGen.GenerateRandomWeapon().ClipSize;

				Assert.IsTrue(clip >= 3 && clip <= 9);
			}

			weaponGen.SemiautomaticShotgunChance = 0;
			weaponGen.SubmachineGunChance = 1;

			for (int i = 0; i < IterationsToTest; i++)
			{
				ushort clip = weaponGen.GenerateRandomWeapon().ClipSize;

				Assert.IsTrue(clip >= 10 && clip <= 50);
			}

			weaponGen.SubmachineGunChance = 0;
			weaponGen.HeavyMachinGunChance = 1;

			for (int i = 0; i < IterationsToTest; i++)
			{
				ushort clip = weaponGen.GenerateRandomWeapon().ClipSize;

				Assert.IsTrue(clip >= 50 && clip <= 300);
			}

			weaponGen.HeavyMachinGunChance = 0;
			weaponGen.LightMachineGunChance = 1;

			for (int i = 0; i < IterationsToTest; i++)
			{
				ushort clip = weaponGen.GenerateRandomWeapon().ClipSize;

				Assert.IsTrue(clip >= 50 && clip <= 100);
			}

			weaponGen.LightMachineGunChance = 0;
			weaponGen.AssaultRifleChance = 1;

			for (int i = 0; i < IterationsToTest; i++)
			{
				ushort clip = weaponGen.GenerateRandomWeapon().ClipSize;

				Assert.IsTrue(clip >= 15 && clip <= 30);
			}

			weaponGen.AssaultRifleChance = 0;
		}
	}
}