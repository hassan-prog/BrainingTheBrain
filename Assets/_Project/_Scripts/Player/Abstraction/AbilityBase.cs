using UnityEngine;

public enum AbilityType
{
    Invisibility = 0,
    Shield = 1
}

public abstract class AbilityBase
{
    public abstract float CooldownTimer { get; set; }
    public abstract float Cooldown { get; }
    public abstract float Duration { get; }
    public abstract bool IsOnCooldown { get; }
    public abstract bool IsActive { get; }
    public abstract AbilityType AbilityType { get; }
    public abstract AbilityBase ActivateAbility();
    public abstract AbilityBase DeactivateAbility();
    public abstract void StartCooldown();
    public abstract void ResetCooldown();
}
