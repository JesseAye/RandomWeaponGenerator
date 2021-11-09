# RandomWeaponGenerator
The goal of this project is to randomly generate a weapon with varying stats such as clip size

## How To Use
1. Build the WeaponGeneratorDLL project, and get the built library from ..\RandomWeaponGenerator\WeaponGenerator\bin\Debug\net5.0\WeaponGenerator.dll, along with WeaponGenerator.xml if you need documentation
2. Place the library in the appropriate folder for your project, and import into your project if needed

## Example Code
Include the namespace with `using WeaponGenerator;`
The follow code will generate one Weapon:
```
WeaponGenerator.WeaponGenerator weaponGen = new();
Weapon weapon = weaponGen.GenerateRandomWeapon();
```
