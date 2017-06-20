namespace WindowsFormsApplication1
{
    public class MacroEvent
    {
        private long seconds;
        public enum EventType : byte { mouseMoved, lDown, lUp, rDown, rUp, wheel, keyDown, keyUp};
        private EventType type;
        private int param1;
        private int param2;
        public MacroEvent(long _seconds, EventType _type, int _param1, int _param2)
        {
            Seconds = _seconds;
            Type = _type;
            Param1 = _param1;
            Param2 = _param2;
        }

        public long Seconds { get => seconds; set => seconds = value; }
        public EventType Type { get => type; set => type = value; }
        public int Param2 { get => param2; set => param2 = value; }
        public int Param1 { get => param1; set => param1 = value; }
    }
}