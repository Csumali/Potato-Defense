using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


// Stores all the tiles related to farming (plow, plant, harvest)
public class FarmManager : MonoBehaviour
{
    public static FarmManager fm;
    [SerializeField]
    private Tilemap map;

    [SerializeField]
    private CropBehavior crop;

    [SerializeField]
    private Tile dirt;

    [SerializeField]
    private Tile plowed;

    [SerializeField]
    private TileMapManager mapManager;

    private Dictionary<Vector3Int, CropBehavior> crops;

    // Start is called before the first frame update
    void Start()
    {
        crops = new Dictionary<Vector3Int, CropBehavior>();
        fm = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Check if tilebase is grass.
    public void plow(Vector3 position)
    {
        Vector3Int gridPosition = map.WorldToCell(position);
        map.SetTile(gridPosition, dirt);
    }

    // Check if tile plantable.
    public bool plowable(Vector3 position)
    {
        Vector3Int gridPosition = map.WorldToCell(position);
        return mapManager.GetTileData(gridPosition).state == TileType.GRASS;
    }

    // Plant at position.
    public bool plant(Vector3 position)
    {
        Vector3Int gridPosition = map.WorldToCell(position);
        if (crops.ContainsKey(gridPosition)) return false;
        if (mapManager.GetTileData(gridPosition).state != TileType.PLOWED) return false;

        map.SetTile(gridPosition, plowed);
        CropBehavior newCrop = Instantiate(crop);
        crops.Add(gridPosition, newCrop);
        newCrop.startGrowing(this, gridPosition, mapManager.GetTileData(gridPosition));
        newCrop.transform.position = map.GetCellCenterWorld(gridPosition);
        return true;
    }

    public void destroyCrop(Vector3Int position)
    {
        Destroy(crops[position]);
        crops.Remove(position);
    }

    public void harvest(Vector3Int position)
    {
        //PlayerInventory.potatoes++;
        destroyCrop(position);
    }

    // Getters
    public Dictionary<Vector3Int, CropBehavior> getCrops()
    {
        return crops;
    }
}
