using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LethalSaveManager
{
	public class LCPlayer : ISaveInterface
	{
		public string saveData = "";

		#region SaveAttributes
		// attributes of the player file
		public static readonly string LastSelectedFile = "SelectedFile"; //int
		public static readonly string LastPlayedVersion = "LastVerPlayed"; //int
		public static readonly string PlayerXP = "PlayerXPNum"; //int
		public static readonly string PlayerLevel = "PlayerLevel"; //int
		public static readonly string PlayerFinishedSetup = "PlayerFinishedSetup"; //bool
		public static readonly string HasUsedTerminal = "HasUsedTerminal"; //bool

		// Player stats
		public static readonly string FinishedShockMinigame = "FinishedShockMinigame"; // int
		public static readonly string TimesLanded = "TimesLanded"; //int
		#endregion

		#region SaveProperties
		private int _lastSelectedFile;
		public int lastSelectedFile {  
			get {
				return _lastSelectedFile;
			} 

			set { 
			_lastSelectedFile = value;
				WriteToAttribute(LastSelectedFile, value.ToString());
			} 
		}
		private int _lastPlayedVersion;
		public int lastPlayedVersion
		{
			get
			{
				return _lastPlayedVersion;
			}

			set
			{
				_lastPlayedVersion = value;
				WriteToAttribute(LastPlayedVersion, value.ToString());
			}
		}
		private int _playerXP;
		public int playerXP
		{
			get
			{
				return _playerXP;
			}

			set
			{
				WriteToAttribute(PlayerXP, value.ToString());
				_playerXP = value;
			}
		}
		private int _playerLevel;
		public int playerLevel
		{
			get
			{
				return _playerLevel;
			}

			set
			{
				_playerLevel = value;
				WriteToAttribute(PlayerLevel, value.ToString());
			}
		}
		private bool _playerFinishedSetup;
		public bool playerFinishedSetup
		{
			get
			{
				return _playerFinishedSetup;
			}

			set
			{
				_playerFinishedSetup = value;
				WriteToAttribute(PlayerFinishedSetup, value.ToString().ToLowerInvariant());
			}
		}
		private bool _hasUsedTerminal;
		public bool hasUsedTerminal
		{
			get
			{
				return _hasUsedTerminal;
			}

			set
			{
				_hasUsedTerminal = value;
				WriteToAttribute(HasUsedTerminal, value.ToString().ToLowerInvariant());
			}
		}
		private int _finishedShockMinigame;
		public int finishedShockMinigame
		{
			get
			{
				return _finishedShockMinigame;
			}

			set
			{
				_finishedShockMinigame = value;
				WriteToAttribute(FinishedShockMinigame, value.ToString());
			}
		}
		private int _timesLanded;
		public int timesLanded
		{
			get
			{
				return _timesLanded;
			}

			set
			{
				_timesLanded = value;
				WriteToAttribute(TimesLanded, value.ToString());
			}
		}
		#endregion

		public LCPlayer()
		{
			Load();
		}

		public void Load()
		{
			FileInfo PlayerSaveFile = new FileInfo(MainForm.GameSavePath + MainForm.PlayerSave);
			if (!PlayerSaveFile.Exists) { return; }

			bool boul = false;
			int ount = 1;

			saveData = LCSecurity.Decrypt(File.ReadAllBytes(PlayerSaveFile.ToString()));

			lastSelectedFile = int.TryParse(GetDataFromSave(LastSelectedFile), out ount) ? ount : 1;
			lastPlayedVersion = int.TryParse(GetDataFromSave(LastPlayedVersion), out ount) ? ount : 45;
			playerXP = int.TryParse(GetDataFromSave(PlayerXP), out ount) ? ount : 0;
			playerLevel = int.TryParse(GetDataFromSave(PlayerLevel), out ount) ? ount : 0;
			playerFinishedSetup = bool.TryParse(GetDataFromSave(PlayerFinishedSetup), out boul) ? boul : false;
			hasUsedTerminal = bool.TryParse(GetDataFromSave(HasUsedTerminal), out boul) ? boul : false;
			finishedShockMinigame = int.TryParse(GetDataFromSave(FinishedShockMinigame), out ount) ? ount : 0;
			timesLanded = int.TryParse(GetDataFromSave(TimesLanded), out ount) ? ount : 0;
		}

		/// <summary>
		/// Gets the value of the attribute from the save file
		/// </summary>
		public string GetDataFromSave(string attribute)
		{
			if (!saveData.Contains(attribute))
				return "";
			int first = saveData.IndexOf(attribute) + attribute.Length + 2;

			string tempStr = saveData.Substring(first, saveData.Length - first);
			tempStr = tempStr.Substring(0, tempStr.IndexOf('}'));
			string resultStr = tempStr.Substring(tempStr.IndexOf("\"value\":") + 8, tempStr.Length - (tempStr.IndexOf("\"value\":") + 8));

			return resultStr;
		}

		/// <summary>
		/// Writes a new value to the attribute in the save file
		/// </summary>
		public string WriteToAttribute(string attribute, string newValue)
		{
			if (!saveData.Contains(attribute))
				return "";

			int firstIndexOfAttribute = saveData.IndexOf(attribute) + attribute.Length;

			string tempStr = saveData.Substring(firstIndexOfAttribute, saveData.Length - firstIndexOfAttribute);

			int firstIndexOfValue = firstIndexOfAttribute + tempStr.IndexOf("\"value\":") + 8;

			try
			{
				tempStr = tempStr.Substring(tempStr.IndexOf("\"value\":") + 8, tempStr.Length - (tempStr.IndexOf("\"value\":") + 8));
				tempStr = tempStr.Substring(0, tempStr.IndexOf('}'));

				saveData = saveData.Remove(firstIndexOfValue, tempStr.Length);
				saveData = saveData.Insert(firstIndexOfValue, newValue);

				return saveData;
			}
			catch (Exception)
			{
				return "";
				throw;
			}
		}
	}
}
