using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomWeaponGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomWeaponGenerator.Tests
{
	[TestClass()]
	public class WeaponGeneratorTests
	{
		/// <summary>
		/// Tests to make sure WeaponGenerator.GenerateRandomWeapon() will not generate a null Weapon
		/// </summary>
		[TestMethod()]
		public void GenerateRandomWeaponTest()
		{
			WeaponGenerator weaponGen = new();
			Weapon weapon = weaponGen.GenerateRandomWeapon();

			Assert.IsNotNull(weapon.CurrentWeapon);
		}

		/// <summary>
		/// Tests to make sure WeaponGenerator.GenerateRandomWeapon(int Amount) will not generate a null Weapon
		/// </summary>
		[TestMethod()]
		public void GenerateRandomWeaponsTest()
		{
			int NumberToGenerate = 1000;
			WeaponGenerator weaponGen = new();
			Weapon[] weapons = weaponGen.GenerateRandomWeapon(NumberToGenerate);

			for (int i = 0; i < weapons.Length; i++)
			{
				Assert.IsNotNull(weapons[i].CurrentWeapon);
			}
		}

		/// <summary>
		/// Asserts valid clip sizes for each type of weapon
		/// </summary>
		[TestMethod()]
		public void CheckValidClipSize()
		{
			int TimesToTest = 10;
			WeaponGenerator weaponGen = new();
			weaponGen.AllWeaponsEqualChance(0);

			weaponGen.SingleActionRevolverChance = 1;

			for (int i = 0; i < TimesToTest; i++)
			{
				ushort clip = weaponGen.GenerateRandomWeapon().ClipSize;

				Assert.IsTrue(clip >= 5 && clip <= 12);
			}

			weaponGen.SingleActionRevolverChance = 0;
			weaponGen.DoubleActionRevolverChance = 1;

			for (int i = 0; i < TimesToTest; i++)
			{
				ushort clip = weaponGen.GenerateRandomWeapon().ClipSize;

				Assert.IsTrue(clip >= 5 && clip <= 12);
			}

			weaponGen.DoubleActionRevolverChance = 0;
			weaponGen.FullSizedHandgunChance = 1;

			for (int i = 0; i < TimesToTest; i++)
			{
				ushort clip = weaponGen.GenerateRandomWeapon().ClipSize;

				Assert.IsTrue(clip >= 10 && clip <= 20);
			}

			weaponGen.FullSizedHandgunChance = 0;
			weaponGen.CompactHandgunChance = 1;

			for (int i = 0; i < TimesToTest; i++)
			{
				ushort clip = weaponGen.GenerateRandomWeapon().ClipSize;

				Assert.IsTrue(clip >= 10 && clip <= 20);
			}

			weaponGen.CompactHandgunChance = 0;
			weaponGen.SubcompactHandgunChance = 1;

			for (int i = 0; i < TimesToTest; i++)
			{
				ushort clip = weaponGen.GenerateRandomWeapon().ClipSize;

				Assert.IsTrue(clip >= 10 && clip <= 20);
			}

			weaponGen.SubcompactHandgunChance = 0;
			weaponGen.MicrocompactHandgunChance = 1;

			for (int i = 0; i < TimesToTest; i++)
			{
				ushort clip = weaponGen.GenerateRandomWeapon().ClipSize;

				Assert.IsTrue(clip >= 10 && clip <= 20);
			}

			weaponGen.MicrocompactHandgunChance = 0;
			weaponGen.LeverActionRifleChance = 1;

			for (int i = 0; i < TimesToTest; i++)
			{
				ushort clip = weaponGen.GenerateRandomWeapon().ClipSize;

				Assert.IsTrue(clip >= 4 && clip <= 17);
			}

			weaponGen.LeverActionRifleChance = 0;
			weaponGen.BoltActionRifleChance = 1;

			for (int i = 0; i < TimesToTest; i++)
			{
				ushort clip = weaponGen.GenerateRandomWeapon().ClipSize;

				Assert.IsTrue(clip >= 2 && clip <= 10);
			}

			weaponGen.BoltActionRifleChance = 0;
			weaponGen.SemiautomaticRifleChance = 1;

			for (int i = 0; i < TimesToTest; i++)
			{
				ushort clip = weaponGen.GenerateRandomWeapon().ClipSize;

				Assert.IsTrue(clip >= 5 && clip <= 30);
			}

			weaponGen.SemiautomaticRifleChance = 0;
			weaponGen.BreakActionShotgunChance = 1;

			for (int i = 0; i < TimesToTest; i++)
			{
				ushort clip = weaponGen.GenerateRandomWeapon().ClipSize;

				Assert.IsTrue(clip >= 1 && clip <= 2);
			}

			weaponGen.BreakActionShotgunChance = 0;
			weaponGen.LeverActionShotgunChance = 1;

			for (int i = 0; i < TimesToTest; i++)
			{
				ushort clip = weaponGen.GenerateRandomWeapon().ClipSize;

				Assert.IsTrue(clip >= 5 && clip <= 6);
			}

			weaponGen.LeverActionShotgunChance = 0;
			weaponGen.PumpActionShotgunChance = 1;

			for (int i = 0; i < TimesToTest; i++)
			{
				ushort clip = weaponGen.GenerateRandomWeapon().ClipSize;

				Assert.IsTrue(clip >= 4 && clip <= 5);
			}

			weaponGen.PumpActionShotgunChance = 0;
			weaponGen.SemiautomaticShotgunChance = 1;

			for (int i = 0; i < TimesToTest; i++)
			{
				ushort clip = weaponGen.GenerateRandomWeapon().ClipSize;

				Assert.IsTrue(clip >= 3 && clip <= 9);
			}

			weaponGen.SemiautomaticShotgunChance = 0;
			weaponGen.SubmachineGunChance = 1;

			for (int i = 0; i < TimesToTest; i++)
			{
				ushort clip = weaponGen.GenerateRandomWeapon().ClipSize;

				Assert.IsTrue(clip >= 10 && clip <= 50);
			}

			weaponGen.SubmachineGunChance = 0;
			weaponGen.HeavyMachinGunChance = 1;

			for (int i = 0; i < TimesToTest; i++)
			{
				ushort clip = weaponGen.GenerateRandomWeapon().ClipSize;

				Assert.IsTrue(clip >= 50 && clip <= 300);
			}

			weaponGen.HeavyMachinGunChance = 0;
			weaponGen.LightMachineGunChance = 1;

			for (int i = 0; i < TimesToTest; i++)
			{
				ushort clip = weaponGen.GenerateRandomWeapon().ClipSize;

				Assert.IsTrue(clip >= 50 && clip <= 100);
			}

			weaponGen.LightMachineGunChance = 0;
			weaponGen.AssaultRifleChance = 1;

			for (int i = 0; i < TimesToTest; i++)
			{
				ushort clip = weaponGen.GenerateRandomWeapon().ClipSize;

				Assert.IsTrue(clip >= 15 && clip <= 30);
			}

			weaponGen.AssaultRifleChance = 0;
		}
	}
}