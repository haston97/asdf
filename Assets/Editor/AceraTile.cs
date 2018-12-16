using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class AceraTile : Tile {
    static public Texture2D texture;
    public Sprite[] tSprites;
    public override void RefreshTile(Vector3Int location, ITilemap tilemap)
    {
        for(int yd = -1; yd<=1; yd++)
        {
            for(int xd = -1; xd<=1; xd++)
            {
                Vector3Int position = new Vector3Int(location.x + xd, location.y + yd, location.z);
                if(hasThisType(tilemap, position))
                {
                    tilemap.RefreshTile(position);
                }
            }
        }
    }
    public override void GetTileData(Vector3Int location, ITilemap tilemap, ref TileData tileData)
    {
        int sides = 0;
        int corners = 0;
        bool[] mask = new bool[8]; 
        mask[0] = hasThisType(tilemap, location + new Vector3Int(1, 0, 0));
        mask[1] = hasThisType(tilemap, location + new Vector3Int(0, 1, 0));
        mask[2] = hasThisType(tilemap, location + new Vector3Int(-1, 0, 0));
        mask[3] = hasThisType(tilemap, location + new Vector3Int(0, -1, 0));
        mask[4] = hasThisType(tilemap, location + new Vector3Int(1, 1, 0));
        mask[5] = hasThisType(tilemap, location + new Vector3Int(-1, 1, 0));
        mask[6] = hasThisType(tilemap, location + new Vector3Int(-1, -1, 0));
        mask[7] = hasThisType(tilemap, location + new Vector3Int(1, -1, 0));
        for (int i = 0; i<4; i++)
        {
            if (mask[i]) {
                sides++;
                
            }
        }
        for (int i = 4; i < 8; i++)
        {
            if (mask[i])
            {
                corners++;
                
            }
        }
        Debug.Log(corners);
        switch (sides)
        {
            case 0: tileData.sprite = tSprites[0];
                break;
            case 1:
                if (mask[0])
                {
                    tileData.sprite = tSprites[1];
                }
                if (mask[1])
                {
                    tileData.sprite = tSprites[2];
                }
                if (mask[2])
                {
                    tileData.sprite = tSprites[3];
                }
                if (mask[3])
                {
                    tileData.sprite = tSprites[4];
                }
                break;
            case 2:
                if (mask[0] && mask[1])
                {
                    tileData.sprite = mask[4] ? tSprites[9] : tSprites[5];
                }
                if (mask[0] && mask[2])
                {
                    tileData.sprite = tSprites[13];
                }
                if (mask[0] && mask[3])
                {
                    tileData.sprite = mask[7] ? tSprites[12] : tSprites[8];
                }
                if (mask[1] && mask[2])
                {
                    tileData.sprite = mask[5] ? tSprites[10] : tSprites[6];
                }
                if (mask[1] && mask[3])
                {
                    tileData.sprite = tSprites[14];
                }
                if (mask[2] && mask[3])
                {
                    tileData.sprite = mask[6] ? tSprites[11] : tSprites[7];
                }
                break;
            case 3:
                switch (corners)
                {
                    case 0:
                        if (mask[0] && mask[1] && mask[2])
                        {
                            tileData.sprite = tSprites[15];
                        }
                        if (mask[0] && mask[1] && mask[3])
                        {
                            tileData.sprite = tSprites[18];
                        }
                        if (mask[0] && mask[2] && mask[3])
                        {
                            tileData.sprite = tSprites[17];
                        }
                        if (mask[1] && mask[2] && mask[3])
                        {
                            tileData.sprite = tSprites[16];
                        }
                        break;
                    case 1:
                        if (mask[0] && mask[1] && mask[2])
                        {
                            if (mask[4]) tileData.sprite = tSprites[19];
                            else
                            {
                                tileData.sprite = mask[5] ? tSprites[23] : tSprites[15];
                            }
                        }
                        if (mask[0] && mask[1] && mask[3])
                        {
                            if (mask[4]) tileData.sprite = tSprites[26];
                            else
                            {
                                tileData.sprite = mask[7] ? tSprites[22] : tSprites[18];
                            }
                        }
                        if (mask[0] && mask[2] && mask[3])
                        {
                            if (mask[6]) tileData.sprite = tSprites[21];
                            else
                            {
                                if (mask[7]) tileData.sprite = tSprites[25];
                                else
                                {
                                    tileData.sprite = tSprites[17];
                                }
                            }
                        }
                        if (mask[1] && mask[2] && mask[3])
                        {
                            if (mask[6]) { tileData.sprite = tSprites[24]; }
                            else
                            {
                                if (mask[5]) { tileData.sprite = tSprites[20]; }
                                else
                                {
                                    tileData.sprite = tSprites[16];
                                }
                            }
                        }
                        break;

                    case 2:
                        if (mask[0] && mask[1] && mask[2])
                        {
                            if (mask[4] && mask[5]) tileData.sprite = tSprites[27];
                            if (mask[4] && mask[6]) tileData.sprite = tSprites[19];
                            if (mask[4] && mask[7]) tileData.sprite = tSprites[19];
                            if (mask[5] && mask[6]) tileData.sprite = tSprites[23];
                            if (mask[5] && mask[7]) tileData.sprite = tSprites[23];
                            if (mask[6] && mask[7]) tileData.sprite = tSprites[15];
                        }
                        if (mask[0] && mask[1] && mask[3])
                        {
                            if (mask[4] && mask[5]) tileData.sprite = tSprites[26];
                            if (mask[4] && mask[6]) tileData.sprite = tSprites[26];
                            if (mask[4] && mask[7]) tileData.sprite = tSprites[30];
                            if (mask[5] && mask[6]) tileData.sprite = tSprites[18];
                            if (mask[5] && mask[7]) tileData.sprite = tSprites[22];
                            if (mask[6] && mask[7]) tileData.sprite = tSprites[22];
                        }
                        if (mask[0] && mask[2] && mask[3])
                        {
                            if (mask[4] && mask[5]) tileData.sprite = tSprites[17];
                            if (mask[4] && mask[6]) tileData.sprite = tSprites[21];
                            if (mask[4] && mask[7]) tileData.sprite = tSprites[25];
                            if (mask[5] && mask[6]) tileData.sprite = tSprites[21];
                            if (mask[5] && mask[7]) tileData.sprite = tSprites[25];
                            if (mask[6] && mask[7]) tileData.sprite = tSprites[29];
                        }
                        if (mask[1] && mask[2] && mask[3])
                        {
                            if (mask[4] && mask[5]) tileData.sprite = tSprites[20];
                            if (mask[4] && mask[6]) tileData.sprite = tSprites[24];
                            if (mask[4] && mask[7]) tileData.sprite = tSprites[16];
                            if (mask[5] && mask[6]) tileData.sprite = tSprites[28];
                            if (mask[5] && mask[7]) tileData.sprite = tSprites[20];
                            if (mask[6] && mask[7]) tileData.sprite = tSprites[24];
                        }
                        break;
                    case 3:
                        if (mask[0] && mask[1] && mask[2])
                        {
                            if (!mask[4]) tileData.sprite = tSprites[23];
                            if (!mask[5]) tileData.sprite = tSprites[19];
                            if (!mask[6]||!mask[7]) tileData.sprite = tSprites[27];
                        }
                        if (mask[0] && mask[1] && mask[3])
                        {
                            if (!mask[4]) tileData.sprite = tSprites[22];
                            if (!mask[7]) tileData.sprite = tSprites[26];
                            if (!mask[6] || !mask[5]) tileData.sprite = tSprites[30];
                        }
                        if (mask[0] && mask[2] && mask[3])
                        {

                            if (!mask[6]) tileData.sprite = tSprites[25];
                            if (!mask[7]) tileData.sprite = tSprites[21];
                            if (!mask[4] || !mask[5]) tileData.sprite = tSprites[29];
                        }
                        if (mask[1] && mask[2] && mask[3])
                        {

                            if (!mask[5]) tileData.sprite = tSprites[24];
                            if (!mask[6]) tileData.sprite = tSprites[20];
                            if (!mask[4] || !mask[7]) tileData.sprite = tSprites[28];
                        }
                        break;
                    case 4:
                        if (mask[0] && mask[1] && mask[2])
                        {
                            tileData.sprite = tSprites[27];
                        }
                        if (mask[0] && mask[1] && mask[3])
                        {
                            tileData.sprite = tSprites[30];
                        }
                        if (mask[0] && mask[2] && mask[3])
                        {
                            tileData.sprite = tSprites[29];
                        }
                        if (mask[1] && mask[2] && mask[3])
                        {
                            tileData.sprite = tSprites[28];
                        }
                        break;
                }
                break;
            case 4:
                switch (corners)
                {
                    case 0:
                        tileData.sprite = tSprites[31];
                        break;
                    case 1:
                        if (mask[4])
                        {
                            tileData.sprite = tSprites[40];
                        }
                        if (mask[5])
                        {
                            tileData.sprite = tSprites[41];
                        }
                        if (mask[6])
                        {
                            tileData.sprite = tSprites[42];
                        }
                        if (mask[7])
                        {
                            tileData.sprite = tSprites[43];
                        }
                        break;
                    case 2:
                        if (mask[4]&&mask[5])
                        {
                            tileData.sprite = tSprites[38];
                        }
                        if (mask[4] && mask[6])
                        {
                            tileData.sprite = tSprites[45];
                        }
                        if (mask[4] && mask[7])
                        {
                            tileData.sprite = tSprites[37];
                        }
                        if (mask[5] && mask[6])
                        {
                            tileData.sprite = tSprites[39];
                        }
                        if (mask[5] && mask[7])
                        {
                            tileData.sprite = tSprites[44];
                        }
                        if (mask[6] && mask[7])
                        {
                            tileData.sprite = tSprites[36];
                        }
                        break;
                    case 3:
                        if (!mask[4])
                        {
                            tileData.sprite = tSprites[32];
                        }
                        if (!mask[5])
                        {
                            tileData.sprite = tSprites[33];
                        }
                        if (!mask[6])
                        {
                            tileData.sprite = tSprites[34];
                        }
                        if (!mask[7])
                        {
                            tileData.sprite = tSprites[35];
                        }
                        break;
                    case 4:
                        tileData.sprite = tSprites[46];
                        break;
                }
                break;
            default:
                    tileData.sprite = tSprites[0];
                break;
        }
    }
    private bool hasThisType(ITilemap tilemap, Vector3Int position)
    {
        return tilemap.GetTile(position) == this;
    }

#if UNITY_EDITOR
    // The following is a helper that adds a menu item to create a RoadTile Asset
    [MenuItem("Assets/Create/CenterTile")]
    public static void CreateRoadTile()
    {
        string path = EditorUtility.SaveFilePanelInProject("Save Center Tile", "New Center Tile", "Asset", "Save Center Tile", "Assets");
        if (path == "")
            return;
        AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<AceraTile>(), path);
    }
#endif
}
