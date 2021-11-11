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