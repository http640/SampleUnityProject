using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour
{
    public enum PanelType
    {
        none,
        start,
        register,
        login,
        storyBoard,
        packageList,
        leaderBoard
    }
    public enum LevelStatus
    {
        none,
        passed,
        current,
        locked
    }

    public enum ButtonType
    {
        none,
        startBtn,
        BackBtn,
        PackageBtn,
        StoryBoardBtn
    }
    public enum InputType
    {
        none,
        username,
        password,
        reEnterPassword,
        name,
        email,
        phoneNumber,
        age,
    }
}


