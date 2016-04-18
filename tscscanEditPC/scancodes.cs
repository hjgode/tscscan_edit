using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace tscscan_edit
{
    public class scancode
    {
        public int _scancode { get; set; }
        public string _keyUS { get; set; }

        public scancode()
        {
        }
        public scancode(int bScancode, string sKey)
        {
            _scancode = bScancode;
            _keyUS = sKey;
        }
        public override string ToString()
        {
            return _keyUS;
        }
        public static scancode[] scancodes = new scancode[]{
            new scancode( 0x00	,"error code"),
            new scancode( 0x01 	,"Esc"),
            new scancode( 0x02 	,"1!"),
            new scancode( 0x03 	,"2@"),
            new scancode( 0x04 	,"3#"),
            new scancode( 0x05 	,"4$"),
            new scancode( 0x06 	,"5%E"),
            new scancode( 0x07 	,"6^"),
            new scancode( 0x08 	,"7&"),
            new scancode( 0x09 	,"8*"),
            new scancode( 0x0a 	,"9\""),
            new scancode( 0x0b 	,"0\""),
            new scancode( 0x0c 	,"-_"),
            new scancode( 0x0d 	,"=+"),
            new scancode( 0x0e 	,"Backspace"),
            new scancode( 0x0f 	,"Tab"),
            new scancode( 0x10 	,"Q"),
            new scancode( 0x11 	,"W"),
            new scancode( 0x12 	,"E"),
            new scancode( 0x13 	,"R"),
            new scancode( 0x14 	,"T"),
            new scancode( 0x15 	,"Y"),
            new scancode( 0x16 	,"U"),
            new scancode( 0x17 	,"I"),
            new scancode( 0x18 	,"O"),
            new scancode( 0x19 	,"P"),
            new scancode( 0x1a 	,"[{"),
            new scancode( 0x1b 	,"]}"),
            new scancode( 0x1c 	,"Enter"),
            new scancode( 0x1d 	,"LCtrl"),
            new scancode( 0x1e 	,"A"),
            new scancode( 0x1f 	,"S"),
            new scancode( 0x20 	,"D"),
            new scancode( 0x21 	,"F"),
            new scancode( 0x22 	,"G"),
            new scancode( 0x23 	,"H"),
            new scancode( 0x24 	,"J"),
            new scancode( 0x25 	,"K"),
            new scancode( 0x26 	,"L"),
            new scancode( 0x27 	,";:"),
            new scancode( 0x28 	,"'\""),
            new scancode( 0x29 	,"`~"),
            new scancode( 0x2a 	,"LShift"),
            new scancode( 0x2b 	,"\\|"), //  on a 102-key keyboard),
            new scancode( 0x2c 	,"Z"),
            new scancode( 0x2d 	,"X"),
            new scancode( 0x2e 	,"C"),
            new scancode( 0x2f 	,"V"),
            new scancode( 0x30 	,"B"),
            new scancode( 0x31 	,"N"),
            new scancode( 0x32 	,"M"),
            new scancode( 0x33 	,",<"),
            new scancode( 0x34 	,".>"),
            new scancode( 0x35 	,"/?"),
            new scancode( 0x36 	,"RShift"),
            new scancode( 0x37 	,"Keypad-*"), //or ,"*/PrtScn" on a 83/84-key keyboard),
            new scancode( 0x38 	,"LAlt"),
            new scancode( 0x39 	,"Space bar"),
            new scancode( 0x3a 	,"CapsLock"),
            new scancode( 0x3b 	,"F1"),
            new scancode( 0x3c 	,"F2"),
            new scancode( 0x3d 	,"F3"),
            new scancode( 0x3e 	,"F4"),
            new scancode( 0x3f 	,"F5"),
            new scancode( 0x40 	,"F6"),
            new scancode( 0x41 	,"F7"),
            new scancode( 0x42 	,"F8"),
            new scancode( 0x43 	,"F9"),
            new scancode( 0x44 	,"F10"),
            new scancode( 0x45 	,"NumLock"),
            new scancode( 0x46 	,"ScrollLock"),
            new scancode( 0x47 	,"Keypad-7/Home"),
            new scancode( 0x48 	,"Keypad-8/Up"),
            new scancode( 0x49 	,"Keypad-9/PgUp"),
            new scancode( 0x4a 	,"Keypad--"),
            new scancode( 0x4b 	,"Keypad-4/Left"),
            new scancode( 0x4c 	,"Keypad-5"),
            new scancode( 0x4d 	,"Keypad-6/Right"),
            new scancode( 0x4e 	,"Keypad-+"),
            new scancode( 0x4f 	,"Keypad-1/End"),
            new scancode( 0x50 	,"Keypad-2/Down"),
            new scancode( 0x51 	,"Keypad-3/PgDn"),
            new scancode( 0x52 	,"Keypad-0/Ins"),
            new scancode( 0x53 	,"Keypad-./Del"),
            new scancode( 0x54 	,"Alt-SysRq")// on a 84+ key keyboard),
        };

    }
}
