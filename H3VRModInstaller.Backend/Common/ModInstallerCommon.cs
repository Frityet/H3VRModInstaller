﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H3VRModInstaller.JSON;
using Newtonsoft.Json;
using System.IO;
using GlobExpressions;
using System.Net;
using System.IO.Compression;

namespace H3VRModInstaller.Common
{
	public class MICVarsTemplate
	{
		public bool EnableDebugging { get; set; }
		public bool BypassExec { get; set; }
		public string Execname { get; set; }
		public string Pingsite { get; set; }
		public string[] Modlistloc { get; set; }
	}

	/// <summary>
	/// Commonly used functions and fields
	/// </summary>
	public class ModInstallerCommon
	{
		public struct Files
		{
			/// <summary>
			/// Location of H3VR.EXE, auto stops if not detected
			/// </summary>
			public static string execdir = MainFiledir + @"\H3VR.exe";
			/// <summary>
			/// Loc of the main file with the exe inside
			/// </summary>
			public static string MainFiledir = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
			/// <summary>
			/// loc of the MI lists.
			/// </summary>
			public static string Modinstallerdir = Directory.GetCurrentDirectory() + @"/ModInstallerLists/";
			/// <summary>
			/// Website where the database is located.
			/// </summary>
			public static string[] Modlistloc = { "https://github.com/Frityet/H3VRModInstaller/releases/download/database/ModList.zip", "ModList.zip" };
		}
		/// <summary>
		/// Enables Debugging
		/// </summary>
		public static bool enableDebugging = true;
		/// <summary>
		/// Bypasses the check for H3VR.EXE
		/// </summary>
		public static bool BypassExec = true;
		/// <summary>
		/// Website used to ping to ensure internet access
		/// </summary>
		public static string Pingsite = "www.github.com";
		/// <summary>
		/// Current version.
		/// </summary>
		public static Version ModInstallerVersion = new Version(1, 0, 0);

		public static void overrideMICVars()
		{
			if (!File.Exists(Directory.GetCurrentDirectory() + @"\" + "MICoverride.json")) return;
			Console.WriteLine("MICOverride.json detected!");
			MICVarsTemplate depinput = JsonConvert.DeserializeObject<MICVarsTemplate>(File.ReadAllText(Directory.GetCurrentDirectory() + @"\" + "MICoverride.json"));
			if (depinput.EnableDebugging != null) enableDebugging = depinput.EnableDebugging;
			if (depinput.BypassExec != null) BypassExec = depinput.BypassExec;
			if (depinput.Execname != null) Files.execdir = Files.MainFiledir + depinput.Execname;
			if (depinput.Pingsite != null) Pingsite = depinput.Pingsite;
			if (depinput.Modlistloc != null) Files.Modlistloc = depinput.Modlistloc;
		}

		/// <summary>
		/// Writes line if enabledebugging is true.
		/// </summary>
		public static void DebugLog(string input)
		{
			if (enableDebugging) Console.WriteLine(input);
		}

		//i'm not even sure why i made this, i was just too lazy to write two lines.
		public static void throwexept(string error)
		{
			Console.WriteLine(error);
			Console.ReadKey();
		}

		/// <summary>
		/// returns a string array as foo[1], foo[2], foo[3], etc
		/// </summary>
		public static string ReturnArrayInString(string[] array)
		{
			string strng = "";
			for (int i = 0; i < array.Length; i++)
			{
				strng += array[i];
				strng += ", ";
			}
			return strng;
		}

		public static ModFile[] GetAllMods()
		{
			ModFile[] result = new ModFile[0];
			ModListFormat[] jsonfiles = JsonModList.GetModLists();
			for (int i = 0; i < jsonfiles.Length; i++)
			{
				result = result.Concat(jsonfiles[i].Modlist).ToArray();
			}
			return result;
		}
	}
}