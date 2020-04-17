using Map;
using UnityEngine;

public class TileMarker
{
    private Texture2D tex;

    public TileMarker()
    {

    }

    public Texture2D BuildTexture(int _height, int _width, int _tileResolution, Texture2D _wantedTexture)
    {
        int texWidth = _width * _tileResolution;
        int texHeight = _height * _tileResolution;
        tex = new Texture2D(texWidth, texHeight);








        return tex;
    }

    public void MoveTextureToTile()
    {

    }

    public void ChangeTextureSize()
    {

    }

    public Texture2D GetTexture()
    {
        return tex;
    }

    public void SetTexture()
    {

    }

}
