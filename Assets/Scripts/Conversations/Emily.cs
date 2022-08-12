using Fluent;

public class Emily : FluentScript
{
    public override void OnStart() { Player.Instance.CanMove = false; }
    public override void OnFinish() { Player.Instance.CanMove = true; }

    public override FluentNode Create()
    {
        return Yell("I'm Emily and I have nothing to add!");
    }
}
