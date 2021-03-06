public class Singleton<T> where T : class, new() {
    private static T instance;

    public static T Instance {//懒汉式
        get {
            if (null == instance) {
                instance = new T();
            }

            return instance;
        }
    }

    ~Singleton() {
        instance = null;
    }
}