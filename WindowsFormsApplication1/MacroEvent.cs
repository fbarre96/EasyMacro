using System;

namespace WindowsFormsApplication1
{
    public class MacroEvent
    {
        private long seconds;
        public enum EventType : byte { mouseMoved, lDown, lUp, rDown, rUp, wheel, keyDown, keyUp};
        private EventType type;
        private int param1;
        private int param2;

        public int Param2
        {
            get
            {
                return param2;
            }

            set
            {
                param2 = value;
            }
        }

        public int Param1
        {
            get
            {
                return param1;
            }

            set
            {
                param1 = value;
            }
        }

        public EventType Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        public long Seconds
        {
            get
            {
                return seconds;
            }

            set
            {
                seconds = value;
            }
        }

        public MacroEvent(long _seconds, EventType _type, int _param1, int _param2)
        {
            Seconds = _seconds;
            Type = _type;
            param1 = _param1;
            Param2 = _param2;
        }
        public string[] ToStrings()
        {
            string[] ret = new string[3];
            ret[0] = this.Seconds.ToString();
            if (this.Type == EventType.mouseMoved)
            {
                ret[1] = "Mouse moved";
                ret[2] = "(" + this.Param1 + "; " + this.Param2 + ")";
            }
            else if (this.Type == EventType.keyDown)
            {
                System.Windows.Forms.Keys e = (System.Windows.Forms.Keys)this.Param1;
                ret[1] = "Key down";
                ret[2] = e.ToString();
            }
            else if (this.Type == EventType.keyUp)
            {
                System.Windows.Forms.Keys e = (System.Windows.Forms.Keys)this.Param1;
                ret[1] = "Key up";
                ret[2] = e.ToString();
            }
            else if (this.Type == EventType.lDown)
            {
                ret[1] = "M1 down";
                ret[2] = "(" + this.Param1 + "; " + this.Param2 + ")";
            }
            else if (this.Type == EventType.rDown)
            {
                ret[1] = "M2 down";
                ret[2] = "(" + this.Param1 + "; " + this.Param2 + ")";
            }
            else if (this.Type == EventType.lUp)
            {
                ret[1] = "M1 up";
                ret[2] = "(" + this.Param1 + "; " + this.Param2 + ")";
            }
            else if (this.Type == EventType.rUp)
            {
                ret[1] = "M2 up";
                ret[2] = "(" + this.Param1 + "; " + this.Param2 + ")";
            }
            else
            {
                ret[1] = "Wheel";
                if (this.param1 > 0)
                    ret[2] = "Upward";
                else
                    ret[2] = "Downward";
            }
            return ret;
        }
        public override string ToString()
        {
            if (this.Type == EventType.mouseMoved)
            {
                return this.Seconds + " " + "Mouse moved (" + this.Param1 + "; " + this.Param2 + ")";
            }
            else if (this.Type == EventType.keyDown)
            {
                System.Windows.Forms.Keys e = (System.Windows.Forms.Keys)this.Param1;
                return this.Seconds + " " + "Key down " + e.ToString();
            }
            else if (this.Type == EventType.keyUp)
            {
                System.Windows.Forms.Keys e = (System.Windows.Forms.Keys)this.Param1;
                return this.Seconds + " " + "Key up " + e.ToString();
            }
            else if (this.Type == EventType.lDown)
            {
                return this.Seconds + " " + "M1 down (" + this.Param1 + ";" + this.Param2 + ")";
            }
            else if (this.Type == EventType.rDown)
            {
                return this.Seconds + " " + "M2 down (" + this.Param1 + ";" + this.Param2 + ")";
            }
            else if (this.Type == EventType.lUp)
            {
                return this.Seconds + " " + "M1 up (" + this.Param1 + ";" + this.Param2 + ")";
            }
            else if (this.Type == EventType.rUp)
            {
                return this.Seconds + " " + "M2 up (" + this.Param1 + ";" + this.Param2 + ")";
            }
            else if (this.Type == EventType.wheel)
            {
                if (this.param1 > 0)
                    return this.Seconds + " " + "Wheel up";
                else
                    return this.Seconds + " " + "Wheel down";
            }
            else
                return "Unknow event";
        }

    }
}