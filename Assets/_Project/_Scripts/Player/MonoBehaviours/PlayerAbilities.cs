using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    [SerializeField] private List<AbilityBase> _abilities;

    private PlayerInputHandler _playerInputhandler;
    private PlayerRenderer _playerRenderer;
    private InvisibleAbility _invisibility;

    public AbilityBase ActiveAbility { get; private set; }

    private void Awake()
    {
        _invisibility = new InvisibleAbility();
        _abilities = new List<AbilityBase>();

    }

    private void Start()
    {
        _abilities.Add(_invisibility);
    }

    private void OnEnable()
    {
        _playerInputhandler.OnAbilityUse += PerformAbility;
    }

    private void OnDisable()
    {
        _playerInputhandler.OnAbilityUse -= PerformAbility;
    }

    public void Init(PlayerInputHandler playerInputHandler, PlayerRenderer renderer)
    {
        _playerInputhandler = playerInputHandler;
        _playerRenderer = renderer;
    }

    public void PerformAbility(AbilityType type)
    {
        ActiveAbility = _abilities.FirstOrDefault(x => x.AbilityType == type)?.ActivateAbility();

        if (ActiveAbility != null
            && ActiveAbility.AbilityType == AbilityType.Invisibility
            && ActiveAbility.IsActive)
        {
            PlayerProperties.IsInvisible = true;
            _playerRenderer.SetVisibility(1);
        }
        else
        {
            PlayerProperties.IsInvisible = false;
            _playerRenderer.SetVisibility(0.25f);
        } 
    }
}

