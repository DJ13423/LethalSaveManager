﻿using LethalSaveManager.entity;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LethalSaveManager
{
	public class LCSave : ISaveInterface
	{
		public string saveData { get; set; } = "";

		#region SaveAttributes
		// attributes of the save files, do not modify unless the savedata changes
		public static readonly string Credits = "GroupCredits"; // Social credits
		public static readonly string PlanetSeed = "RandomSeed";
		public static readonly string Deadline = "DeadlineTime";
		public static readonly string Planet = "CurrentPlanetID";
		public static readonly string Quota = "ProfitQuota";
		public static readonly string QuotasPassed = "QuotasPassed";
		public static readonly string QuotaFulfilled = "QuotaFulfilled";
		public static readonly string Time = "GlobalTime";
		public static readonly string GameVer = "FileGameVers";
		public static readonly string ShipScrapValues = "shipScrapValues"; // Multiple IDs values

		//Stats
		public static readonly string ValueCollected = "Stats_ValueCollected";
		public static readonly string DaySpent = "Stats_DaysSpent";

		//Ship unlocked assets
		public static readonly string UnlockedShipObjects = "UnlockedShipObjects"; // Multiple IDs values
		public static readonly string ShipGrabbableItems = "shipGrabbableItemIDs"; // Multiple IDs values
		public static readonly string ShipGrabbableItemPos = "shipGrabbableItemPos"; // Mutiple Unity Engine Vector3 values
		#endregion

		#region Save Properties
		public bool isModded { get { return gameVer == 9999; } }

		#region Single values
		private int _credits;
		public int credits
		{
			get
			{
				return _credits;
			}

			set
			{
				_credits = value;
				WriteToAttribute(Credits, value.ToString());
			}
		}
		private int _planetSeed;
		public int planetSeed
		{
			get
			{
				return _planetSeed;
			}

			set
			{
				_planetSeed = value;
				WriteToAttribute(PlanetSeed, value.ToString());
			}
		}
		private int _deadline;
		public int deadline
		{
			get
			{
				return _deadline;
			}

			set
			{
				_deadline = value;
				WriteToAttribute(Deadline, value.ToString());
			}
		}
		private int _planet;
		public int planet
		{
			get
			{
				return _planet;
			}

			set
			{
				_planet = value;
				WriteToAttribute(Planet, value.ToString());
			}
		}
		private int _quota;
		public int quota
		{
			get
			{
				return _quota;
			}

			set
			{
				_quota = value;
				WriteToAttribute(Quota, value.ToString());
			}
		}
		private int _quotasPassed;
		public int quotasPassed
		{
			get
			{
				return _quotasPassed;
			}

			set
			{
				_quotasPassed = value;
				WriteToAttribute(QuotasPassed, value.ToString());
			}
		}
		private int _quotasFullfilled;
		public int quotaFulfilled
		{
			get
			{
				return _quotasFullfilled;
			}

			set
			{
				_quotasFullfilled = value;
				WriteToAttribute(QuotaFulfilled, value.ToString());
			}
		}
		private int _time;
		public int time
		{
			get
			{
				return _time;
			}

			set
			{
				_time = value;
				WriteToAttribute(Time, value.ToString());
			}
		}
		private int _gameVer = 45;
		public int gameVer
		{
			get
			{
				return _gameVer;
			}

			set
			{
				_gameVer = value;
				WriteToAttribute(GameVer, value.ToString());
			}
		}
		private int _valueCollected;
		public int valueCollected
		{
			get
			{
				return _valueCollected;
			}

			set
			{
				_valueCollected = value;
				WriteToAttribute(ValueCollected, value.ToString());
			}
		}
		private int _daySpent;
		public int daySpent
		{
			get
			{
				return _daySpent;
			}

			set
			{
				_daySpent = value;
				WriteToAttribute(DaySpent, value.ToString());
			}
		}
		#endregion

		#region Array values
		private int[] _shipScrapValues;
		public int[] shipScrapValues
		{
			get
			{
				return _shipScrapValues;
			}

			set
			{
				_shipScrapValues = value;
				WriteArrayToAttribute(ShipScrapValues, value);
			}
		}
		private int[] _unlockedObjects;
		public int[] unlockedShipObjects
		{
			get
			{
				return _unlockedObjects;
			}

			set
			{
				_unlockedObjects = value;
				WriteArrayToAttribute(UnlockedShipObjects, value);
			}
		}
		private int[] _shipGrabbableItems;
		public int[] shipGrabbableItems
		{
			get
			{
				return _shipGrabbableItems;
			}

			set
			{
				_shipGrabbableItems = value;
				WriteArrayToAttribute(ShipGrabbableItems, value);
			}
		}
		private UnityVector[] _shipGrabbableItemPos;
		public UnityVector[] shipGrabbableItemPos
		{
			get
			{
				return _shipGrabbableItemPos;
			}

			set
			{
				_shipGrabbableItemPos = value;
				WriteArrayToAttribute(ShipGrabbableItemPos, value);
			}
		}
		#endregion
		#endregion

		public LCSave() { }

		public LCSave(string savePath)
		{
			Load(savePath);
		}

		internal void Load(string savePath)
		{
			FileInfo SaveFile = new FileInfo(savePath);
			if (!SaveFile.Exists) { return; }

			saveData = LCSecurity.Decrypt(File.ReadAllBytes(SaveFile.ToString()));

			int titi;

			#region Single Value Get
			credits = int.TryParse(GetDataFromSave(Credits), out titi) ? titi : 60;
			planetSeed = int.TryParse(GetDataFromSave(PlanetSeed), out titi) ? titi : 0;
			deadline = int.TryParse(GetDataFromSave(Deadline), out titi) ? titi : 3;
			planet = int.TryParse(GetDataFromSave(Planet), out titi) ? titi : 8;
			quota = int.TryParse(GetDataFromSave(Quota), out titi) ? titi : 130;
			quotasPassed = int.TryParse(GetDataFromSave(QuotasPassed), out titi) ? titi : 0;
			quotaFulfilled = int.TryParse(GetDataFromSave(QuotaFulfilled), out titi) ? titi : 0;
			time = int.TryParse(GetDataFromSave(Time), out titi) ? titi : 3000;
			gameVer = int.TryParse(GetDataFromSave(GameVer), out titi) ? titi : 45;
			valueCollected = int.TryParse(GetDataFromSave(ValueCollected), out titi) ? titi : 0;
			daySpent = int.TryParse(GetDataFromSave(DaySpent), out titi) ? titi : 0;

			#endregion

			#region Multiple Value Get
			shipScrapValues = GetIdsFromValues(GetValuesFromString(GetDataFromSave(ShipScrapValues)));
			unlockedShipObjects = GetIdsFromValues(GetValuesFromString(GetDataFromSave(UnlockedShipObjects)));
			shipGrabbableItems = GetIdsFromValues(GetValuesFromString(GetDataFromSave(ShipGrabbableItems)));
			shipGrabbableItemPos = GetVectorFromSaveData(ShipGrabbableItemPos);
			#endregion
		}

		public string[] GetValuesFromString(string values)
		{
			if (values == null || values.Length == 0) return null;
			// Remove '[' and ']' at the beginning and ending of the string
			values = values.Remove(0, 1);
			values = values.Remove(values.Length - 1, 1);

			string[] result = values.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

			return result;
		}

		public int[] GetIdsFromValues(string[] values)
		{
			if (values == null || values.Length == 0) return null;
			int[] result = new int[values.Length + 1];
			int index = 0;

			foreach (string value in values)
			{
				if (String.IsNullOrEmpty(value) || value.Length > 9) continue;
				result[index] = int.Parse(value);
				index++;
			}

			return result;
		}

		//"value":[{"x":6.69129372,"y":2.10340214,"z":-11.4520636},{"x":4.01256371,"y":0.341714382,"z":-13.9975548},{"x":-3.30840683,"y":0.3362217,"z":-14.2954359},{"x":-2.48205948,"y":2.51881552,"z":-12.63819},
		//{"x":9.595259,"y":1.49462366,"z":-12.9279337},{"x":4.92151833,"y":0.541714668,"z":-12.3918781},{"x":7.31608,"y":2.10340214,"z":-11.5677242},{"x":7.455637,"y":2.123402,"z":-11.5858059},
		//{"x":7.37245369,"y":2.10340214,"z":-11.63424},{"x":4.802082,"y":0.7417145,"z":-12.491188}]}
		public UnityVector[] GetVectorFromSaveData(string attribute)
		{
			if (!saveData.Contains(attribute))
				return null;
			int first = saveData.IndexOf(attribute) + attribute.Length + 2;

			string tempStr = saveData.Substring(first, saveData.Length - first);
			tempStr = tempStr.Substring(0, tempStr.IndexOf("}]}") - 1);
			string resultStr = tempStr.Substring(tempStr.IndexOf("\"value\":") + 9, tempStr.Length - (tempStr.IndexOf("\"value\":") + 9));

			string[] values = resultStr.Split(',');

			if (values == null || values.Length == 0) return null;
			UnityVector[] result = new UnityVector[values.Length + 1];
			int resIndex = 0;

			try
			{
				for (int i = 0; i < values.Length; i++)
				{
					UnityVector v = new UnityVector();
					string valStr = "";
					switch (i % 3)
					{
						case 0:
							valStr = values[i].Remove(0, 5).Trim();
							v.x = float.Parse(valStr, CultureInfo.InvariantCulture);
							break;
						case 1:
							valStr = values[i].Remove(0, 4).Trim();
							v.y = float.Parse(valStr, CultureInfo.InvariantCulture);
							break;
						case 2:
							valStr = values[i].Remove(0, 4).Trim();
							valStr = valStr.Remove(valStr.Length - 1, 1);
							v.z = float.Parse(valStr, CultureInfo.InvariantCulture);
							result[resIndex] = v;
							resIndex++;
							break;
						default:
							Debug.WriteLine("BUG in GetVectorFromSaveData switch at " + i + "(Remainder:" + i % 3 + ")" + ":" + values[i]);
							break;

					}
				}
			}
			catch (Exception)
			{
				Debug.WriteLine("Fuck this shit I'm out");
			}

			return result;
		}

		public string WriteArrayToAttribute(string attribute, Array values)
		{
			if (!saveData.Contains(attribute)) return "";
			if (values == null) return null;

			int firstIndexOfAttribute = saveData.IndexOf(attribute) + attribute.Length;

			string tempStr = saveData.Substring(firstIndexOfAttribute, saveData.Length - firstIndexOfAttribute);

			int firstIndexOfValue = firstIndexOfAttribute + tempStr.IndexOf("\"value\":") + 8;

			tempStr = tempStr.Substring(tempStr.IndexOf("\"value\":") + 8, tempStr.Length - (tempStr.IndexOf("\"value\":") + 8));
			tempStr = tempStr.Substring(0, tempStr.IndexOf('}'));

			saveData = saveData.Remove(firstIndexOfValue, tempStr.Length);

			string newValue = "[";
			foreach (var value in values)
			{
				if (value == null) continue;
                newValue += value.ToString() + ',';
			}
			newValue += ']';

			saveData = saveData.Insert(firstIndexOfValue, newValue);

			return saveData;
		}

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

		public string WriteToAttribute(string attribute, string newValue)
		{
			if (!saveData.Contains(attribute))
				return "";

			int firstIndexOfAttribute = saveData.IndexOf(attribute) + attribute.Length;

			string tempStr = saveData.Substring(firstIndexOfAttribute, saveData.Length - firstIndexOfAttribute);

			int firstIndexOfValue = firstIndexOfAttribute + tempStr.IndexOf("\"value\":") + 8;

			tempStr = tempStr.Substring(tempStr.IndexOf("\"value\":") + 8, tempStr.Length - (tempStr.IndexOf("\"value\":") + 8));
			tempStr = tempStr.Substring(0, tempStr.IndexOf('}'));

			saveData = saveData.Remove(firstIndexOfValue, tempStr.Length);
			saveData = saveData.Insert(firstIndexOfValue, newValue);

			return saveData;
		}
	}
}
