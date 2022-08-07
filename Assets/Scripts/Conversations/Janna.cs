using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fluent;

public class Janna : MyFluentDialogue
{
    public GameObject friend;

    public override void OnStart() { Player.Instance.CanMove = false; }
    public override void OnFinish() { Player.Instance.CanMove = true; }

    public override FluentNode Create()
{
    return
        Show() *

        Options
        (
            Write(0, "Lets do many things") *
            Option("That guy...") *
                Write(0, "What about him ?") *
                Options
                (
                    Option("Whats his name?") *
                        Write(0, "Um...I forgot...") *

                    Option("Do you think he's into pink ?") *
                        Hide() *
                        Yell(friend, "I heard that!") *
                        Show() *
                        Write(0, "... maybe we shouldnt talk about him anymore") *

                    Option("Back") *
                        Back()
                ) *

            Option("Bye") *
                Hide() *
                Yell("Bye bye!") *
                End()
        );

}
}
