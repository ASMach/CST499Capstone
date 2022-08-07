using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fluent;

public class ConversationHandler : MonoBehaviour
{
    public static ConversationHandler Instance;

    void Awake()
    {
        Instance = this;
    }

    void OnTalk()
    {
        FluentManager.Instance.ExecuteClosestAction(gameObject);
    }
}
