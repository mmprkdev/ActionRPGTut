//using System.Collections;
//using System.Collections.Generic;
//using UnityEditor;
//using UnityEngine;
//using UnityEngine.Tilemaps;

////NOTE: This is pretty cool, but for now I'm just going to draw the
//// water manually - i.e. this script is unfinished DO NOT USE.

//public class WaterTile : Tile
//{
//    // "[SerializedField] allows Unity to see this variable in the Inpector even though it is private."
//    [SerializeField]
//    private Sprite[] waterSprites;

//    [SerializeField]
//    private Sprite preview;

//    Vector3Int neighborPosition;

//    public override void RefreshTile(Vector3Int position, ITilemap tilemap)
//    {
//        for (int y = -1; y <= 1; y++)
//        {
//            for (int x = -1; x <= 1; x++)
//            {
//                neighborPosition = new Vector3Int(position.x + x, position.y + y, position.z);

//                if (HasWater(tilemap, neighborPosition))
//                {
//                    tilemap.RefreshTile(neighborPosition);
//                }
//            }
//        }
//    }

//    private bool HasWater(ITilemap tilemap, Vector3Int position)
//    {
//        // return true or false depending on whether the tile is a WaterTile (this).
//        return tilemap.GetTile(position) == this;
//    }

//    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
//    {
//        string composition = string.Empty;
        
//        for (int x = -1; x <= 1; x++)
//        {
//            for (int y = -1; y <= 1; y++)
//            {
//                if (HasWater(tilemap, new Vector3Int(position.x + x, position.y + y, position.z)))
//                {
//                    composition += "W";
//                }
//                else
//                {
//                    composition += "E";
//                }
//            }
//        }

//        tileData.sprite = waterSprites[3];
//    }

//#if UNITY_EDITOR
//    [MenuItem("Assets/Create/Tiles/WaterTile")]
//    public static void CreateWaterTile()
//    {
//        string path = EditorUtility.SaveFilePanelInProject("Save WaterTile", "NewWaterTile", "asset", "Save watertile", "Assets");

//        if (path == "")
//        {
//            return;
//        }
//        AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<WaterTile>(), path);
//    }

//#endif
//}
