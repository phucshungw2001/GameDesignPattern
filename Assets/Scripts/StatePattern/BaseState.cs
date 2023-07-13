public abstract class BaseState
{
    protected PlayerController player;

    public BaseState(PlayerController player)
    {
        this.player = player;
    }

    public virtual void EnterState() { }
    public virtual void UpdateState() { }
    public virtual void ExitState() { }

    public virtual void Jump()
    {
    }

    public virtual void Attack()
    {
    }
}