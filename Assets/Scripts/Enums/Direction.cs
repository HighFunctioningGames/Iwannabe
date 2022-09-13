using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction 
{
    rayDir,

    #region Relative to Player
        forward, backwards, left, right, above, below, 
    #endregion

    #region Cardinal
        North, East, South, West,
        NorthEast, NorthWest,
        SouthEast, SouthWest
    #endregion
}

static class DirectionExtensions
{
    public static string EnumToString(int index, int verbosityFactor) 
    {
        string str = "";
        index *= (verbosityFactor+1);
        switch(index)
        {
            case 0:
                str += "forward";
                break;
            case 1:
                str += "backwards";
                break;
            case 2:
                str += "left";
                break;
            case 3:
                str += "right";
                break;
            case 4:
                str += "above";
                break;
            case 5:
                str += "below";
                break;
            case 6:
                str += "in-front";
                break;
            case 7:
                str += "behind";
                break;
            case 8:
                str += "left side";
                break;
            case 9:
                str += "right side";
                break;
            case 10:
                str += "above";
                break;
            case 11:
                str += "below";
                break;
            case 12:
                break;
            case 13:
                break;
            case 14:
                str += "on the left side";
                break;
            case 15:
                str += "on the right side";
                break;
            case 16:
                break;
            case 17:
                break;
            case 18:
                break;
            case 19:
                break;
            case 20:
                break;
            case 21:
                break;
            case 22:
                break;
            case 23:
                break;
            case 24:
                str += EnumToString(index-6,0) + "of ";
                break;
        }
        return str;
    }

    public static Vector3 GetDirRel(this Direction dir, int index) 
    {
        switch(index)
        {
            case 0:
                return Vector3.forward;
            case 1:
                return -Vector3.forward;
            case 2:
                return Vector3.up;
            case 3:
                return -Vector3.up;
            case 4:
                return Vector3.right;
            case 5:
                return -Vector3.right;
        }
        return Vector3.zero;
    }
}