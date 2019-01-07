using EventHandler = System.EventHandler;
using EventArgs = System.EventArgs;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;

    public event EventHandler GameOver;
    public event EventHandler LevelCompleted;

    void Awake()
    {
    }

    void OnEnable()
    {
        player.Died += OnDied;
    }

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
    }

    void OnDied(object sender, EventArgs e)
    {
        OnGameOver(this, null);
    }

    void OnGameOver(object sender, EventArgs e)
    {
        GameOver(this, e);
    }
}
