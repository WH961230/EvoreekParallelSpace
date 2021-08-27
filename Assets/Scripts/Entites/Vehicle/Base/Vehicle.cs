
public enum VehicleType{
    
}

public struct VehicleData {
    public int id;
    public string Name;
    public VehicleType Type;
    public VehicleController VehicleController;
}

public class Vehicle : IBaseEntites{
    public void OnInit() {
    }

    public void OnClear() {
    }
}