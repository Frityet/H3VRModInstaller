﻿using System;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using GlobExpressions;
using System.Net;
using System.IO.Compression;

namespace H3VRModInstaller.JSON
{
	/// <summary>
	/// Another layer for multiple mods in one file
	/// </summary>
	public class InstalledModsFormat
	{
		/// <summary>
		/// Read class comment
		/// </summary>
		public string[] InstalledMods { get; set; }
	}

	/// <summary>
	/// Actions for the installed mods. Serialised
	/// </summary>
	public class InstalledMods
	{
		/// <summary>
		/// Gets the currently installed mods from the JSON files
		/// </summary>
		/// <returns>String array with the installed mods</returns>
		public static string[] GetInstalledMods()
		{
			if (!File.Exists(Directory.GetCurrentDirectory() + @"\installedmods.json")) return new string[0];
			InstalledModsFormat input = JsonConvert.DeserializeObject<InstalledModsFormat>(File.ReadAllText(Directory.GetCurrentDirectory() + "/installedmods.json"));
			if (input == null) return new string[0];
			return input.InstalledMods;
		}
		
		/// <summary>
		/// Adds a <c>ModID</c> to the JSON file
		/// </summary>
		/// <param name="addmod">Mod to add</param>
		public static void AddInstalledMods(string addmod)
		{
			string[] file = new string[0];
			file = GetInstalledMods();
			Array.Resize<string>(ref file, file.Length + 1);
			InstalledModsFormat modexport = new InstalledModsFormat();
			file[file.Length - 1] = addmod;
			modexport.InstalledMods = file;
			string output = JsonConvert.SerializeObject(modexport);
			File.WriteAllText(Directory.GetCurrentDirectory() + @"\installedmods.json", output);
		}
	}
}
