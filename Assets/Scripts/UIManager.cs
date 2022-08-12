using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;
using Unity.Netcode;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI playersInGameText;

    [SerializeField]
    private TMP_InputField joinCodeInput;

    private bool hasServerStarted;

    private void Awake()
    {
        Cursor.visible = true;
    }

    void Update()
    {
        //playersInGameText.text = $"Players in game: {PlayersManager.Instance.PlayersInGame}";
    }

    void Start()
    {

        // Status types callbacks for networking
        NetworkManager.Singleton.OnClientConnectedCallback += (id) =>
        {
            Debug.Log($"{id} just connected...");
        };

        NetworkManager.Singleton.OnServerStarted += () =>
        {
            hasServerStarted = true;
        };
    }

    public void StartServer()
    {
        if (NetworkManager.Singleton.StartServer())
            Debug.Log("Server started...");
        else
            Debug.Log("Unable to start server...");
    }

    public void StartHost()
    {
        // this allows the UnityMultiplayer and UnityMultiplayerRelay scene to work with and without
        // relay features - if the Unity transport is found and is relay protocol then we redirect all the 
        // traffic through the relay, else it just uses a LAN type (UNET) communication.
        if (RelayManager.Instance.IsRelayEnabled)
        {
            var relay = SetupRelay();
        }

        if (NetworkManager.Singleton.StartHost())
            Debug.Log("Host started...");
        else
            Debug.Log("Unable to start host...");
    }

    public void StartClient()
    {
        if (RelayManager.Instance.IsRelayEnabled && !string.IsNullOrEmpty(joinCodeInput.text))
        {
            var join = JoinRelay();
        }

        if (NetworkManager.Singleton.StartClient())
            Debug.Log("Client started...");
        else
            Debug.Log("Unable to start client...");
    }
    public void StatusLabels()
    {
        var mode = NetworkManager.Singleton.IsHost ?
            "Host" : NetworkManager.Singleton.IsServer ? "Server" : "Client";

        GUILayout.Label("Transport: " +
            NetworkManager.Singleton.NetworkConfig.NetworkTransport.GetType().Name);
        GUILayout.Label("Mode: " + mode);
    }

    // Async helpers

    public async Task SetupRelay()
    {
        try
        {
            await RelayManager.Instance.SetupRelay();
        }
        catch
        {
            Debug.LogWarning("Failed to setup relay");
        }
    }

    public async Task JoinRelay() {
        try
        {
            await RelayManager.Instance.JoinRelay(joinCodeInput.text);
        }
        catch
        {
            Debug.Log("Failed to join relay with input code " + joinCodeInput.text);
        }
    }
}
