using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Rewired.Data;

public class UserDataStore_PlayerPrefs : UserDataStore
{
	private class ControllerAssignmentSaveInfo
	{
		public class PlayerInfo
		{
			public int id;

			public bool hasKeyboard;

			public bool hasMouse;

			public JoystickInfo[] joysticks;

			public int joystickCount => 0;

			public int IndexOfJoystick(int joystickId)
			{
				return 0;
			}

			public bool ContainsJoystick(int joystickId)
			{
				return false;
			}
		}

		public class JoystickInfo
		{
			public Guid instanceGuid;

			public string hardwareIdentifier;

			public int id;
		}

		public PlayerInfo[] players;

		public int playerCount => 0;

		public ControllerAssignmentSaveInfo()
		{
		}

		public ControllerAssignmentSaveInfo(int playerCount)
		{
		}

		public int IndexOfPlayer(int playerId)
		{
			return 0;
		}

		public bool ContainsPlayer(int playerId)
		{
			return false;
		}
	}

	private class JoystickAssignmentHistoryInfo
	{
		public readonly Joystick joystick;

		public readonly int oldJoystickId;

		public JoystickAssignmentHistoryInfo(Joystick joystick, int oldJoystickId)
		{
		}
	}

	[Serializable]
	private class ControllerElementByRoleMap
	{
		[Serializable]
		public struct Entry
		{
			public int actionId;

			public ControllerElementType elementType;

			public AxisRange axisRange;

			public bool invert;

			public Pole axisContribution;

			public bool TryGetElementAssignment(ControllerType controllerType, Controller.Element targetElement, out ElementAssignment assignment)
			{
				assignment = default(ElementAssignment);
				return false;
			}

			public override string ToString()
			{
				return null;
			}
		}

		public string role;

		public List<Entry> data;

		public void Add(ActionElementMap elementMap)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public string ToJson()
		{
			return null;
		}

		public static ControllerElementByRoleMap FromJson(string role, string json)
		{
			return null;
		}
	}

	public enum ActionMappingSaveMode
	{
		ByController,
		ByControllerElementRole
	}

	private sealed class _003C_003Ec__DisplayClass86_0
	{
		public Joystick joystick;

		internal bool _003CLoadJoystickAssignmentsNow_003Eb__0(JoystickAssignmentHistoryInfo x)
		{
			return false;
		}
	}

	private sealed class _003C_003Ec__DisplayClass86_1
	{
		public ControllerAssignmentSaveInfo.JoystickInfo joystickInfo;

		internal bool _003CLoadJoystickAssignmentsNow_003Eb__1(JoystickAssignmentHistoryInfo x)
		{
			return false;
		}
	}

	private sealed class _003C_003Ec__DisplayClass86_2
	{
		public Joystick match;

		internal bool _003CLoadJoystickAssignmentsNow_003Eb__2(JoystickAssignmentHistoryInfo x)
		{
			return false;
		}
	}

	private sealed class _003CLoadJoystickAssignmentsDeferred_003Ed__88 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UserDataStore_PlayerPrefs _003C_003E4__this;

		object IEnumerator<object>.Current => null;

		object IEnumerator.Current => null;

		public _003CLoadJoystickAssignmentsDeferred_003Ed__88(int _003C_003E1__state)
		{
		}

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
		}
	}

	private const string thisScriptName = "UserDataStore_PlayerPrefs";

	private const string logPrefix = "Rewired: ";

	private const string playerPrefsKeySuffix_controllerAssignments = "ControllerAssignments";

	private const int controllerMapPPKeyVersion_original = 0;

	private const int controllerMapPPKeyVersion_includeDuplicateJoystickIndex = 1;

	private const int controllerMapPPKeyVersion_supportDisconnectedControllers = 2;

	private const int controllerMapPPKeyVersion_includeFormatVersion = 2;

	private const int controllerMapPPKeyVersion = 2;

	private const int controllerElementByRoleMapPPKeyVersion = 0;

	private bool isEnabled;

	private bool loadDataOnStart;

	private bool loadJoystickAssignments;

	private bool loadKeyboardAssignments;

	private bool loadMouseAssignments;

	private ActionMappingSaveMode _actionMappingSaveMode;

	private string playerPrefsKeyPrefix;

	[NonSerialized]
	private bool allowImpreciseJoystickAssignmentMatching;

	[NonSerialized]
	private bool deferredJoystickAssignmentLoadPending;

	[NonSerialized]
	private bool wasJoystickEverDetected;

	[NonSerialized]
	private List<int> __allActionIds;

	[NonSerialized]
	private string __allActionIdsString;

	[NonSerialized]
	private readonly StringBuilder _sb;

	[NonSerialized]
	private Dictionary<string, ControllerElementByRoleMap> _tempElementByRoleMaps;

	[NonSerialized]
	private Dictionary<string, bool> _tempElementByRoleMapsEnabled;

	public bool IsEnabled
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool LoadDataOnStart
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool LoadJoystickAssignments
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool LoadKeyboardAssignments
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool LoadMouseAssignments
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public ActionMappingSaveMode actionMappingSaveMode
	{
		get
		{
			return default(ActionMappingSaveMode);
		}
		set
		{
		}
	}

	public string PlayerPrefsKeyPrefix
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	private string playerPrefsKey_controllerAssignments => null;

	private bool loadControllerAssignments => false;

	private List<int> allActionIds => null;

	private string allActionIdsString => null;

	public override void Save()
	{
	}

	public override void SaveControllerData(int playerId, ControllerType controllerType, int controllerId)
	{
	}

	public override void SaveControllerData(ControllerType controllerType, int controllerId)
	{
	}

	public override void SavePlayerData(int playerId)
	{
	}

	public override void SaveInputBehavior(int playerId, int behaviorId)
	{
	}

	public override void Load()
	{
	}

	public override void LoadControllerData(int playerId, ControllerType controllerType, int controllerId)
	{
	}

	public override void LoadControllerData(ControllerType controllerType, int controllerId)
	{
	}

	public override void LoadPlayerData(int playerId)
	{
	}

	public override void LoadInputBehavior(int playerId, int behaviorId)
	{
	}

	protected override void OnInitialize()
	{
	}

	protected override void OnControllerConnected(ControllerStatusChangedEventArgs args)
	{
	}

	protected override void OnControllerPreDisconnect(ControllerStatusChangedEventArgs args)
	{
	}

	protected override void OnControllerDisconnected(ControllerStatusChangedEventArgs args)
	{
	}

	public override void SaveControllerMap(int playerId, ControllerMap controllerMap)
	{
	}

	public override ControllerMap LoadControllerMap(int playerId, ControllerIdentifier controllerIdentifier, int categoryId, int layoutId)
	{
		return null;
	}

	private int LoadAll()
	{
		return 0;
	}

	private int LoadPlayerDataNow(int playerId)
	{
		return 0;
	}

	private int LoadPlayerDataNow(Player player)
	{
		return 0;
	}

	private int LoadAllJoystickCalibrationData()
	{
		return 0;
	}

	private int LoadJoystickCalibrationData(Joystick joystick)
	{
		return 0;
	}

	private int LoadJoystickCalibrationData(int joystickId)
	{
		return 0;
	}

	private int LoadJoystickData(int joystickId)
	{
		return 0;
	}

	private int LoadControllerDataNow(int playerId, ControllerType controllerType, int controllerId)
	{
		return 0;
	}

	private int LoadControllerDataNow(ControllerType controllerType, int controllerId)
	{
		return 0;
	}

	private int LoadControllerMaps(int playerId, ControllerType controllerType, int controllerId)
	{
		return 0;
	}

	private ControllerMap LoadControllerMap(Player player, ControllerIdentifier controllerIdentifier, int categoryId, int layoutId)
	{
		return null;
	}

	private bool LoadControllerElementMapByRole(Player player, Controller controller, string role, int mapCategoryId, int layoutId, Dictionary<string, ControllerElementByRoleMap> elementByRoleMaps)
	{
		return false;
	}

	private int LoadInputBehaviors(int playerId)
	{
		return 0;
	}

	private int LoadInputBehaviorNow(int playerId, int behaviorId)
	{
		return 0;
	}

	private int LoadInputBehaviorNow(Player player, InputBehavior inputBehavior)
	{
		return 0;
	}

	private bool LoadControllerAssignmentsNow()
	{
		return false;
	}

	private bool LoadKeyboardAndMouseAssignmentsNow(ControllerAssignmentSaveInfo data)
	{
		return false;
	}

	private bool LoadJoystickAssignmentsNow(ControllerAssignmentSaveInfo data)
	{
		return false;
	}

	private ControllerAssignmentSaveInfo LoadControllerAssignmentData()
	{
		return null;
	}

	private IEnumerator LoadJoystickAssignmentsDeferred()
	{
		return null;
	}

	private void SaveAll()
	{
	}

	private void SavePlayerDataNow(int playerId)
	{
	}

	private void SavePlayerDataNow(Player player)
	{
	}

	private void SaveAllJoystickCalibrationData()
	{
	}

	private void SaveJoystickCalibrationData(int joystickId)
	{
	}

	private void SaveJoystickCalibrationData(Joystick joystick)
	{
	}

	private void SaveJoystickData(int joystickId)
	{
	}

	private void SaveControllerDataNow(int playerId, ControllerType controllerType, int controllerId)
	{
	}

	private void SaveControllerDataNow(ControllerType controllerType, int controllerId)
	{
	}

	private void SaveControllerMaps(Player player, PlayerSaveData playerSaveData)
	{
	}

	private void SaveControllerMaps(int playerId, ControllerType controllerType, int controllerId)
	{
	}

	private void SaveControllerMap(Player player, ControllerMap controllerMap)
	{
	}

	private void SaveControllerMapByController(Player player, ControllerMap controllerMap)
	{
	}

	private void SaveControllerMapByControllerElementRole(Player player, Controller controller, ControllerMap controllerMap)
	{
	}

	private bool AddControllerElementByRoleMapEntry(Player player, Controller controller, ActionElementMap elementMap, ref Dictionary<string, ControllerElementByRoleMap> maps)
	{
		return false;
	}

	private void SaveInputBehaviors(Player player, PlayerSaveData playerSaveData)
	{
	}

	private void SaveInputBehaviorNow(int playerId, int behaviorId)
	{
	}

	private void SaveInputBehaviorNow(Player player, InputBehavior inputBehavior)
	{
	}

	private bool SaveControllerAssignments()
	{
		return false;
	}

	private bool ControllerAssignmentSaveDataExists()
	{
		return false;
	}

	private string GetControllerMapPlayerPrefsKey(Player player, ControllerIdentifier controllerIdentifier, int categoryId, int layoutId, int ppKeyVersion)
	{
		return null;
	}

	private string GetControllerElementByRoleMapPlayerPrefsKey(Player player, string elementRole, int categoryId, int layoutId, int ppKeyVersion)
	{
		return null;
	}

	private string GetJoystickCalibrationMapPlayerPrefsKey(Joystick joystick)
	{
		return null;
	}

	private string GetControllerMapKnownActionIdsPlayerPrefsKey(Player player, ControllerIdentifier controllerIdentifier, int categoryId, int layoutId, int ppKeyVersion)
	{
		return null;
	}

	private string GetInputBehaviorPlayerPrefsKey(Player player, int inputBehaviorId)
	{
		return null;
	}

	private static void AppendBaseKey(StringBuilder sb, string playerPrefsKeyPrefix)
	{
	}

	private static void AppendPlayerKey(StringBuilder sb, Player player)
	{
	}

	private static void AppendControllerMapKey(StringBuilder sb, Player player, ControllerIdentifier controllerIdentifier, int categoryId, int layoutId, int ppKeyVersion)
	{
	}

	private static void AppendControllerMapKnownActionIdsKey(StringBuilder sb, Player player, ControllerIdentifier controllerIdentifier, int categoryId, int layoutId, int ppKeyVersion)
	{
	}

	private static void AppendControllerMapKeyCommonSuffix(StringBuilder sb, Player player, ControllerIdentifier controllerIdentifier, int categoryId, int layoutId, int ppKeyVersion)
	{
	}

	private static void AppendControllerElementByRoleMapKey(StringBuilder sb, string elementRole, int categoryId, int layoutId, int ppKeyVersion)
	{
	}

	private static void AppendJoystickCalibrationMapKey(StringBuilder sb, Joystick joystick)
	{
	}

	private static void AppendInputBehaviorKey(StringBuilder sb, int inputBehaviorId)
	{
	}

	private string GetControllerMapXml(Player player, ControllerIdentifier controllerIdentifier, int categoryId, int layoutId)
	{
		return null;
	}

	private List<int> GetControllerMapKnownActionIds(Player player, ControllerIdentifier controllerIdentifier, int categoryId, int layoutId)
	{
		return null;
	}

	private string GetJoystickCalibrationMapXml(Joystick joystick)
	{
		return null;
	}

	private string GetInputBehaviorXml(Player player, int id)
	{
		return null;
	}

	private void AddDefaultMappingsForNewActions(ControllerIdentifier controllerIdentifier, ControllerMap controllerMap, List<int> knownActionIds)
	{
	}

	private Joystick FindJoystickPrecise(ControllerAssignmentSaveInfo.JoystickInfo joystickInfo)
	{
		return null;
	}

	private bool TryFindJoysticksImprecise(ControllerAssignmentSaveInfo.JoystickInfo joystickInfo, out List<Joystick> matches)
	{
		matches = null;
		return false;
	}

	private static int GetDuplicateIndex(Player player, ControllerIdentifier controllerIdentifier)
	{
		return 0;
	}

	private void RefreshLayoutManager(int playerId)
	{
	}

	private void OnControllerMapsSaved(Player player)
	{
	}

	private static Type GetControllerMapType(ControllerType controllerType)
	{
		return null;
	}

	private static int SortOldestToNewest(ControllerMapSaveData a, ControllerMapSaveData b)
	{
		return 0;
	}
}
