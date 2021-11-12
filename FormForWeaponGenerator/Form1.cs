using System;
using System.Data;
using System.Windows.Forms;
using WeaponGenerator;

namespace FormForWeaponGenerator
{
	public partial class Form1 : Form
	{
		private Weapon[] weapons;
		private ushort NumberOfWeaponsToGenerate = 1000;
		DataTable weaponTable;
		public Form1()
		{
			InitializeComponent();
			WeaponGenerator.WeaponGenerator weaponGen = new();
			weapons = weaponGen.GenerateRandomWeapon(NumberOfWeaponsToGenerate);
			weaponTable = new DataTable();

			weaponTable.Columns.Add("Weapon Name", typeof(string));
			weaponTable.Columns.Add("Clip Size", typeof(ushort));
			weaponTable.Columns.Add("Effective Range", typeof(ushort));
			weaponTable.Columns.Add("Absolute Max Range", typeof(ushort));
			weaponTable.Columns.Add("Weight", typeof(ushort));
			weaponTable.Columns.Add("Reload Time", typeof(string));
			weaponTable.Columns.Add("Draw Speed", typeof(string));
			weaponTable.Columns.Add("Fire Rate", typeof(string));
			weaponTable.Columns.Add("Cyclic Rate", typeof(string));
			weaponTable.Columns.Add("Can Dual Wield", typeof(bool));
			weaponTable.Columns.Add("Clip Size Rank", typeof(string));
			weaponTable.Columns.Add("Effective Range Rank", typeof(string));
			weaponTable.Columns.Add("Absolute Max Range Rank", typeof(string));
			weaponTable.Columns.Add("Weight Rank", typeof(string));
			weaponTable.Columns.Add("Reload Time Rank", typeof(string));
			weaponTable.Columns.Add("Draw Speed Rank", typeof(string));
			weaponTable.Columns.Add("Fire Rate Rank", typeof(string));

			foreach (Weapon weapon in weapons)
			{
				DataRow dr = weaponTable.NewRow();
				dr["Weapon Name"] = weapon.WeaponName;
				dr["Clip Size"] = weapon.ClipSize;
				dr["Effective Range"] = weapon.EffectiveRange;
				dr["Absolute Max Range"] = weapon.AbsoluteMaxRange;
				dr["Weight"] = weapon.Weight;
				dr["Reload Time"] = weapon.ReloadTimeSecondsMS;
				dr["Draw Speed"] = weapon.DrawSpeedSecondsMS;
				dr["Fire Rate"] = weapon.FireRateSecondsMS;
				dr["Cyclic Rate"] = weapon.CyclicRate + " RPM";
				dr["Can Dual Wield"] = weapon.CanDualWield;
				dr["Clip Size Rank"] = Math.Round((weapon.ClipSizeRank * 100), 1) + "%";
				dr["Effective Range Rank"] = Math.Round((weapon.EffectiveRangeRank * 100), 1) + "%";
				dr["Absolute Max Range Rank"] = Math.Round((weapon.AbsoluteMaxRangeRank * 100), 1) + "%";
				dr["Weight Rank"] = Math.Round((weapon.WeightRank * 100), 1) + "%";
				dr["Reload Time Rank"] = Math.Round((weapon.ReloadTimeRank * 100), 1) + "%";
				dr["Draw Speed Rank"] = Math.Round((weapon.DrawSpeedRank * 100), 1) + "%";
				dr["Fire Rate Rank"] = Math.Round((weapon.FireRateRank * 100), 1) + "%";

				weaponTable.Rows.Add(dr);
			}
			dgvWeapons.DataSource = weaponTable;
			dgvWeapons.AutoResizeColumns();
		}
	}
}
