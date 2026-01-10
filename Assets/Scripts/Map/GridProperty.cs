[System.Serializable]
public class GridProperty
{
    public GridCoordinate gridCoordinate;
    public GridBoolProperty gridBoolPrperty;
    public bool gridBoolValue = false;

    public GridProperty(GridCoordinate gridCoordinate,  GridBoolProperty gridBoolPrperty, bool gridBoolValue)
    {
        this.gridCoordinate = gridCoordinate;
        this.gridBoolPrperty = gridBoolPrperty;
        this.gridBoolValue = gridBoolValue;
    }
}