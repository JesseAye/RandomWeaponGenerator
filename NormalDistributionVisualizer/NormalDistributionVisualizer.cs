using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WeaponGenerator;

namespace NormalDistributionVisualizer
{
	public partial class NormalDistributionVisualizer : Form
	{
		private ushort AmountToGenerate = 1000;

		public NormalDistributionVisualizer()
		{
			InitializeComponent();
			WeaponGenerator.WeaponGenerator weaponGen = new WeaponGenerator.WeaponGenerator();
			weaponGen.AllWeaponsEqualChance(0);
			cbWeapon.Items.AddRange(new object[] {
				WeaponType.Revolver,
				WeaponType.Handgun,
				WeaponType.BoltActionRifle,
				WeaponType.SemiautomaticRifle,
				WeaponType.BreakActionShotgun,
				WeaponType.PumpActionShotgun,
				WeaponType.SemiautomaticShotgun,
				WeaponType.SubmachineGun,
				WeaponType.HeavyMachineGun,
				WeaponType.LightMachineGun,
				WeaponType.AssaultRifle});
			cbStat.Items.AddRange(new object[]
			{
				"Clip Size",
				"Effective Range",
				"Absolute Max Range",
				"Weight",
				"Reload Time",
				"Fire Rate",
				"Draw Speed"
			});
		}

		private void cbWeapon_SelectedIndexChanged(object sender, EventArgs e)
		{
			GenerateChart();
		}

		private void cbStat_SelectedIndexChanged(object sender, EventArgs e)
		{
			GenerateChart();
		}

		private void GenerateChart()
		{
			if (cbWeapon.SelectedIndex > -1)
			{
				if (cbStat.SelectedIndex > -1)
				{
					WeaponGenerator.WeaponGenerator weaponGen = new WeaponGenerator.WeaponGenerator();
					Series series = new Series();

					series.ChartType = SeriesChartType.Column;
					series.Name = "series";

					chartDistribution.Series.Clear();
					chartDistribution.Series.Add(series);

					weaponGen.AllWeaponsEqualChance(0);
					weaponGen.SetChance((WeaponType)cbWeapon.SelectedItem, 1);
					Weapon[] weapons = weaponGen.GenerateRandomWeapon(AmountToGenerate);
					ushort[] statArray = new ushort[AmountToGenerate];

					switch (cbStat.SelectedItem.ToString())
					{
						case "Clip Size":
							for (int i = 0; i < AmountToGenerate; i++)
							{
								statArray[i] = weapons[i].ClipSize;
							}
							break;

						case "Effective Range":
							for (int i = 0; i < AmountToGenerate; i++)
							{
								statArray[i] = weapons[i].EffectiveRange;
							}
							break;

						case "Absolute Max Range":
							for (int i = 0; i < AmountToGenerate; i++)
							{
								statArray[i] = weapons[i].AbsoluteMaxRange;
							}
							break;

						case "Weight":
							for (int i = 0; i < AmountToGenerate; i++)
							{
								statArray[i] = weapons[i].Weight;
							}
							break;

						case "Reload Time":
							for (int i = 0; i < AmountToGenerate; i++)
							{
								statArray[i] = Convert.ToUInt16(weapons[i].ReloadTime.TotalMilliseconds);
							}
							break;

						case "Fire Rate":
							for (int i = 0; i < AmountToGenerate; i++)
							{
								statArray[i] = weapons[i].CyclicRate;
							}
							break;

						case "Draw Speed":
							for (int i = 0; i < AmountToGenerate; i++)
							{
								statArray[i] = Convert.ToUInt16(weapons[i].ReloadTime.TotalMilliseconds);
							}
							break;

						default:
							break;
					}

					if (statArray.Distinct().Count() > 25)
					{

					}

					foreach (ushort item in statArray.Distinct())
					{
						chartDistribution.Series["series"].Points.AddXY(item, statArray.Where(a => a == item).Count());
					}
				}
			}
		}
	}
}
