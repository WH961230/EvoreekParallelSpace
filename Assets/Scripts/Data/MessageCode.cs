namespace Data
{
    /// <summary>
    /// 消息码
    /// </summary>
    public class MessageCode
    {
        //游戏开始
        public const int Game_GameStart = 0;
        //游戏结束
        public const int Game_GameOver = 1;
        //玩家攻击
        public const int Play_Attack = 2;
        //玩家死亡
        public const int Play_Dead = 3;
        //跳跃
        public const int Play_Jump = 4;
        //换弹
        public const int Weapon_Reload = 5;
        //拾取武器
        public const int Play_PickWeapon = 6;
        //丢弃武器
        public const int Play_DropWeapon = 7;
        //武器瞄准
        public const int Play_Aim = 8;
        //键盘输入水平和垂直
        public const int Game_InputData = 9;
        //掉血
        public const int Play_CountDownHp = 10;
        //掉子弹
        public const int Weapon_CountDownBulletNum = 11;
        //武器射击
        public const int Weapon_Shot = 12;
        //提示 - 弹药不足
        public const int Tip_BulletNull = 13;

    }
}