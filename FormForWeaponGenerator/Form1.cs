using WeaponGenerator;
using System.Windows.Forms;

namespace FormForWeaponGenerator
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			ReferenceWeaponGenerator();
		}

		public void ReferenceWeaponGenerator()
		{
			WeaponGenerator.WeaponGenerator weaponGen = new();
			Weapon weapon = weaponGen.GenerateRandomWeapon();

			txtbxWeapon.Text = weapon.WeaponTypeName;
			txtbxClipSize.Text = weapon.ClipSize.ToString();
		}
	}
}
