using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    [SerializeField] private List<AbilityBase> _abilities;

    private PlayerInputHandler _playerInputhandler;
    private PlayerRenderer _playerRenderer;
    public AbilityBase ActiveAbility { get; private set; }

    public void Init(PlayerInputHandler playerInputHandler, PlayerRenderer renderer)
    {
        _playerInputhandler = playerInputHandler;
        _playerRenderer = renderer;
    }

    private void OnEnable()
    {
        _playerInputhandler.OnAbilityUse += PerformAbility;
    }

    private void OnDisable()
    {
        _playerInputhandler.OnAbilityUse -= PerformAbility;
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

