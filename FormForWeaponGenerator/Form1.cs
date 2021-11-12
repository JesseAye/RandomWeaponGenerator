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

				weaponTable.Rows.Add(dr);
			}
			dgvWeapons.DataSource = weaponTable;
			dgvWeapons.AutoResizeColumns();
		}
	}
}
