using System;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    print(SByte.MinValue == -128);
    print(SByte.MaxValue == 127); // SByte's Range: -128 ~ 127 (256)

    print(Convert.ToSByte("01111111", 2) == 127);
    print(Convert.ToSByte("01111110", 2) == 126);
    //                  ...
    print(Convert.ToSByte("01000000", 2) == 64);
    print(Convert.ToSByte("00100000", 2) == 32);
    print(Convert.ToSByte("00000110", 2) == 6);
    print(Convert.ToSByte("00000010", 2) == 2);
    print(Convert.ToSByte("00000001", 2) == 1);
    print(Convert.ToSByte("00000000", 2) == 0);
    print(Convert.ToSByte("11111111", 2) == -1);    // 음수는 2의 보수로 표현됨
    print(Convert.ToSByte("11111110", 2) == -2);
    print(Convert.ToSByte("11111101", 2) == -3);
    print(Convert.ToSByte("11111100", 2) == -4);
    //                  ...
    print(Convert.ToSByte("11100000", 2) == -32);
    print(Convert.ToSByte("11000000", 2) == -64);
    print(Convert.ToSByte("10000001", 2) == -127);
    print(Convert.ToSByte("10000000", 2) == -128);

    print(Convert.ToByte ("10000000", 2) == 128);

    // 음수는 2의 보수법으로 표현된다.
    //    00000001    ->    11111110      + 1 ->     11111111
    // (1에 대한 2진수)    (1에 대한 1의 보수)     (-1에 대한 2의 보수)
    print(                     ~1         + 1 ==     -1);

    print(128 << 1 == 256);   // 1000 0000 << 1   == 1 0000 0000
    print(3 << 1 == 6);       // 0000 0011 << 1   == 0000 0110
    print(64 >> 1 == 32);     // 0100 0000 >> 1   == 0010 0000
    print(Convert.ToString(8, 2) == "1000");
    print(-128 >> 1 == -64);  // 1000 0000 >> 1   == 1100 0000
    print(-128 >> 2 == -32);  // 1000 0000 >> 2   == 1110 0000 
    print((-3 >> 1) == -2);   // 1111 1101 >> 1   == 1111 1110
    
    uint a = 0;
    print(~a == 4294967295 && ~a == uint.MaxValue);   // 1의 보수 구하기 or bit 반전
    print(Convert.ToString(a, 2) == "0");    
    print(Convert.ToString(~a, 2) == "11111111111111111111111111111111");
    
    int ia = 0;
    print(~ia == -1);
    print(Convert.ToString(~ia, 2) == "11111111111111111111111111111111");    

    int c = 8 >> 1; 
    int d = c >> 2;
    print(c == 4);
    print(d == 1);
    
    byte e = 0xF0 | 0x0F;      // 1111 0000 | 0000 1111  == 1111 1111(0xFF)
    print(e == 255);
    print((sbyte)e == -1);
    
    // int i = 1;
    // print(++i); i = 1;
    // print(i++);

  }
}