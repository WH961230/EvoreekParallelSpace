public interface IInfo {
}

public abstract class AbsInfo : IInfo {
    public int Id;
    public int ComponentId;
}

public class RoleInfo : AbsInfo{
}

public class WeaponInfo : AbsInfo{
}