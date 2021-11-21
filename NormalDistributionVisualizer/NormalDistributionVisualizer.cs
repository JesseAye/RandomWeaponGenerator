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
		private readonly ushort AmountToGenerate = 10000;

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

		private void btnGenerateNew_Click(object sender, EventArgs e)
		{
			GenerateChart();
		}

		private void GenerateChart()
		{
			//TODO: Investigate issue with Automatic class weapons not getting a bell curve
			if (cbWeapon.SelectedIndex > -1)
			{
				if (cbStat.SelectedIndex > -1)
				{
					WeaponGenerator.WeaponGenerator weaponGen = new WeaponGenerator.WeaponGenerator();
					Weapon[] weapons;
					Series series = new Series();
					ushort lower, upper;
					Decimal interval;
					ushort groupByLimit = 30;
					ushort[] statArray;
					Dictionary<string, int> groupedArray = new Dictionary<string, int>();

					series.ChartType = SeriesChartType.Column;
					series.Name = "series";

					chartDistribution.Series.Clear();
					chartDistribution.Series.Add(series);

					weaponGen.AllWeaponsEqualChance(0);
					weaponGen.SetChance((WeaponType)cbWeapon.SelectedItem, 1);
					weapons = weaponGen.GenerateRandomWeapon(AmountToGenerate);
					statArray = new ushort[AmountToGenerate];

					switch (cbStat.SelectedItem.ToString())
					{
						case "Clip Size":
							for (int i = 0; i < AmountToGenerate; i++)
							{
								statArray[i] = weapons[i].ClipSize;
							}

							lower = weapons[0].LowerClipLimit;
							upper = weapons[0].UpperClipLimit;
							interval = (decimal)(upper - lower) / groupByLimit;
							break;

						case "Effective Range":
							for (int i = 0; i < AmountToGenerate; i++)
							{
								statArray[i] = weapons[i].EffectiveRange;
							}

							lower = weapons[0].LowerEffectiveRangeLimit;
							upper = weapons[0].UpperEffectiveRangeLimit;
							interval = (decimal)(upper - lower) / groupByLimit;
							break;

						case "Absolute Max Range":
							for (int i = 0; i < AmountToGenerate; i++)
							{
								statArray[i] = weapons[i].AbsoluteMaxRange;
							}

							lower = weapons[0].LowerEffectiveRangeLimit;
							upper = (ushort)(weapons[0].UpperEffectiveRangeLimit * 2);
							interval = (decimal)(upper - lower) / groupByLimit;
							break;

						case "Weight":
							for (int i = 0; i < AmountToGenerate; i++)
							{
								statArray[i] = weapons[i].Weight;
							}

							lower = weapons[0].LowerWeightLimit;
							upper = weapons[0].UpperWeightLimit;
							interval = (decimal)(upper - lower) / groupByLimit;
							break;

						case "Reload Time":
							for (int i = 0; i < AmountToGenerate; i++)
							{
								statArray[i] = Convert.ToUInt16(weapons[i].ReloadTime.TotalMilliseconds);
							}

							lower = weapons[0].LowerReloadTimeLimit;
							upper = weapons[0].UpperReloadTimeLimit;
							interval = (decimal)(upper - lower) / groupByLimit;
							break;

						case "Fire Rate":
							for (int i = 0; i < AmountToGenerate; i++)
							{
								statArray[i] = Convert.ToUInt16(weapons[i].FireRate.TotalMilliseconds);
							}

							lower = weapons[0].LowerFireRateLimit;
							upper = weapons[0].UpperFireRateLimit;
							interval = (decimal)(upper - lower) / groupByLimit;
							break;

						case "Draw Speed":
							for (int i = 0; i < AmountToGenerate; i++)
							{
								statArray[i] = Convert.ToUInt16(weapons[i].DrawSpeed.TotalMilliseconds);
							}

							lower = weapons[0].LowerDrawSpeedLimit;
							upper = weapons[0].UpperDrawSpeedLimit;
							interval = (decimal)(upper - lower) / groupByLimit;
							break;

						default:
							throw new Exception();
					}

					if (statArray.Distinct().Count() > groupByLimit)
					{
						groupedArray = statArray.OrderBy(a => a)
												.GroupBy(b =>
												{
													for (int i = 0; i < (groupByLimit - 1); i++)
													{
														if (b >= (lower + (interval * i)) && (b < (lower + (interval * (i + 1)))))
														{
															return (lower + decimal.Round(interval * i, 0, MidpointRounding.AwayFromZero)).ToString();
														}
													}

													return (lower + decimal.Round(interval * (groupByLimit - 1), 0, MidpointRounding.AwayFromZero)).ToString();
												})
												.ToDictionary(k => k.Key, v => v.Count());

						for (int i = 0; i < groupByLimit; i++)
						{
							string key = (lower + decimal.Round(interval * i, 0, MidpointRounding.AwayFromZero)).ToString();
							if (groupedArray.ContainsKey(key))
							{
								chartDistribution.Series["series"].Points.AddXY(key, groupedArray[key]);
							}

							else
							{
								if (lower + (interval * i) < upper)
								{
									chartDistribution.Series["series"].Points.AddXY(key, 0);
								}
							}
						}
					}

					else
					{
						groupedArray = statArray.OrderBy(a => a)
												.GroupBy(b => b)
												.Select(c => new
												{
													Value = c.Key,
													Count = c.Count()
												})
												.ToDictionary(d => d.Value.ToString(), d => d.Count);

						for (int i = lower; i <= upper; i++)
						{
							if (groupedArray.ContainsKey(i.ToString()))
							{
								chartDistribution.Series["series"].Points.AddXY(i.ToString(), groupedArray[i.ToString()]);
							}

							else
							{
								chartDistribution.Series["series"].Points.AddXY(i.ToString(), 0);
							}
						}
					}

					chartDistribution.Series["series"].IsValueShownAsLabel = true;

					txtLowerLimit.Enabled = true;
					txtUpperLimit.Enabled = true;
					txtLowerLimit.Text = lower.ToString();
					txtUpperLimit.Text = upper.ToString();
					txtLowerLimit.Enabled = false;
					txtUpperLimit.Enabled = false;
				}
			}
		}
	}
}
