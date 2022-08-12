using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fluent;

public class Latifa : FluentScript
{
    [SerializeField]
    HealthStats health;
    public GameObject playerGameObject;
    bool stillFighting = true;

    public override void OnStart()
    {
        stillFighting = true;
        base.OnStart();
    }

    FluentNode AttackOption(string itemName, string yell, int damage)
    {
        return
            Option(itemName) *
            Hide() *
            Yell(playerGameObject, yell) *
            Yell("You delt " + damage + " damage") *
            Do(() => health.Damage((float)damage)) *
            Yell(Eval(() => health.Health + " hp left")) *
            Show() *
            If(() => health.Health <= 0,
                Hide() *
                Yell("I died!") *
                Yell("You win!")
            ) *
            End();
    }

    FluentNode SpellList()
    {
        return
            Options
            (
                AttackOption("Magic Missile", "Missles away!", 4) *
                AttackOption("Fairy Fire", "Boom!", 2) *
                Option("Back") *
                    Back()
            );
    }

    public override FluentNode Create()
    {
        return
            Show() *
            While(() => stillFighting,
                Show() *
                Options
                (
                    If(() => health.Health >= 100, Write(0, "You will NEVER defeat me !!")) *
                    If(() => health.Health >= 60 && health.Health < 100, Write(0, "I'v been hurt!")) *
                    If(() => health.Health >= 20 && health.Health < 60, Write(0, "Awwwwwwww! Stop that!")) *

                    Option("Spells") *
                        Write(0, "Choose a spell") *
                        SpellList() *

                    AttackOption("Melee", "Hand 2 Hand!", 2) *

                    Option("Flee") *
                        Hide() *
                        Yell("Coward!") *
                        Do(() => stillFighting = false) *
                        End()
                )
            );
    }
}
