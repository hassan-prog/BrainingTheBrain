using UnityEngine;

[RequireComponent(typeof(PlayerInputHandler), typeof(PlayerMovement), typeof(PlayerAbilities))]
public class PlayerController : MonoBehaviour
{
    private PlayerInputHandler _playerInputHandler;
    private PlayerMovement _playerMovement;
    private PlayerAbilities _playerAbilities;
    private PlayerRenderer _playerRenderer;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerInputHandler = GetComponent<PlayerInputHandler>();
        _playerAbilities = GetComponent<PlayerAbilities>();
        _playerRenderer = GetComponent<PlayerRenderer>();

        Init();
    }

    private void Init()
    {
        _playerAbilities.Init(_playerInputHandler, _playerRenderer);
        _playerMovement.Init(_playerInputHandler);
    }
}
