using Fluent;

public class Arisa : MyFluentDialogue
{
    public override void OnStart() { Player.Instance.CanMove = false; }
    public override void OnFinish() { Player.Instance.CanMove = true; }

    FluentString[] sentences = FluentString.FromStringArray(new string[] { "I Have something...", "POTATO!", "Actualy I don't, tee-hee-hee!" });

    public override FluentNode Create()
    {
        return
            Yell(sentences);
    }
}
