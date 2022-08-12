using Fluent;

public class Youko : FluentScript
{
    public override void OnStart() { Player.Instance.CanMove = false; }
    public override void OnFinish() { Player.Instance.CanMove = true; }

    public override FluentNode Create()
    {
        return Yell("Hihi! I'm Youko!");
    }
}
