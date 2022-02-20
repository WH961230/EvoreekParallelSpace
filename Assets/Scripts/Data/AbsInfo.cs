public interface IInfo {
}

public abstract class AbsInfo : IInfo {
    public int Id;
    public int ComInstanceId;
}

public class RoleInfo : AbsInfo{
}

public class WeaponInfo : AbsInfo{
}