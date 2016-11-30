using UnityEngine;
using System.Collections;

public class GameVariables : MonoBehaviour 
{


    #region BrickBreak Public static Variables
    public static bool BrickBreakisGame = false;
    public static bool BrickBreakStart = false;
    public static bool YouWin = false;
    public static bool YouLose = false;


    public static bool KeyBrickBreak = false;

    public static bool IsHit = false;
    public static bool IsDead = false;
    public static bool IsPaddle = false;
    public static bool IsBall = false;
    public static bool IsMiss = false;
    public static bool BrickDead = false;
    public static bool BricksDead = false;


    public static bool HasHitBrick = false;
    public static bool HasFailed = false;
    public static bool hitSound = false;

    public static bool PaddleHitBall = false;
    public static bool AddScore = false;
    public static bool WallHitStuck = false;
    #endregion


    #region SliderPuzzle Public Static Variables

    public static bool KeySlidePuzzle = false;

    public static bool SliderISWin = false;

    #endregion


    #region Bomberman Public Static Variables


    public static bool AIDestroyBlockCollide = false;


    public static bool PlaceBomb = false;


    public static bool YouDieNow = false;
    public static bool HahahahaIWillWin = false;


    public static bool InsertEvilLaugh = false;



    public static int KeyCount;
    public static int ammo;
    public static int Health;
    public static Vector3 checkpoint;
    public static float keyDisplayTime;
    public static bool BombArmed = false;
    public static bool HaveBomb = false;
    public static int BombCount;
    public static int BombsList;
    public static bool BombExplode = false;




    public static bool ActivatePickup = false;
    public static bool RangeAddUp = false;
    public static bool RangeAddMax = false;
    public static bool BombAdd1 = false;
    public static bool KickBomb = false;


    public static bool BombCounter = false;
    public static bool targetSet = false;
    public static bool wallFound = false;

    #endregion


    #region ThirdMinigame Public Static Variables

    public static bool Game3Key = false;

	public static bool IsAlive = false;

    public static bool Game3IsWin = false;


   

   

    public static bool logDead = false;


    public static bool LogSpawn = false;
    public static bool LogSpawn2 = false;
    public static bool LogSpawn3 = false;
    public static bool LogSpawn4 = false;
    public static bool LogSpawn5 = false;
    public static bool LogSpawn6 = false;
    public static bool LogSpawn7 = false;
    public static bool LogSpawn8 = false;
    public static bool LogSpawn9 = false;
    public static bool LogSpawn10 = false;

    public static bool CarSpawn = false;
    public static bool CarSpawn2 = false;
    public static bool CarSpawn3 = false;
    public static bool CarSpawn4 = false;
    public static bool CarSpawn5 = false;
    public static bool CarSpawn6 = false;
    public static bool CarSpawn7 = false;
    public static bool CarSpawn8 = false;
    public static bool CarSpawn9 = false;
    public static bool CarSpawn10 = false;




    #endregion









}
