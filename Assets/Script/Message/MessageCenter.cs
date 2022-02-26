using System;

public class MessageCenter {
    
    public void RegisterMessage<T>(Body body, T t) {
        
    }
    public void RegisterMessage<T, T1>(Body body, T t, T1 t1) {
        
    }    
    public void RegisterMessage<T, T1, T2>(Body body, T t, T1 t1, T2 t2) {
        
    }
    public void RegisterMessage<T, T1, T2, T3>(Body body, T t, T1 t1, T2 t2, T3 t3) {
        
    }
    public void RegisterMessage<T, T1, T2, T3, T4>(Body body, T t, T1 t1, T2 t2, T3 t3, T4 t4) {
        
    }
    public void RegisterMessage<T, T1, T2, T3, T4, T5>(Body body, T t, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5) {
        
    }
    
    public void UnRegisterMessage<T>(Body body, T t) {
        
    }
    public void UnRegisterMessage<T, T1>(Body body, T t, T1 t1) {
        
    }    
    public void UnRegisterMessage<T, T1, T2>(Body body, T t, T1 t1, T2 t2) {
        
    }
    public void UnRegisterMessage<T, T1, T2, T3>(Body body, T t, T1 t1, T2 t2, T3 t3) {
        
    }
    public void UnRegisterMessage<T, T1, T2, T3, T4>(Body body, T t, T1 t1, T2 t2, T3 t3, T4 t4) {
        
    }
    public void UnRegisterMessage<T, T1, T2, T3, T4, T5>(Body body, T t, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5) {
        
    }
    
    public void DispatcherMessage<T>(Body body, T t) {
        
    }
    public void DispatcherMessage<T, T1>(Body body, T t, T1 t1) {
        
    }    
    public void DispatcherMessage<T, T1, T2>(Body body, T t, T1 t1, T2 t2) {
        
    }
    public void DispatcherMessage<T, T1, T2, T3>(Body body, T t, T1 t1, T2 t2, T3 t3) {
        
    }
    public void DispatcherMessage<T, T1, T2, T3, T4>(Body body, T t, T1 t1, T2 t2, T3 t3, T4 t4) {
        
    }
    public void DispatcherMessage<T, T1, T2, T3, T4, T5>(Body body, T t, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5) {
        
    }
}

public class Body {
    public int MessageCode;
    public Action MyAction;

    public void Invoke() {
        if (null != MyAction) {
            MyAction.Invoke();
        }
    }
}