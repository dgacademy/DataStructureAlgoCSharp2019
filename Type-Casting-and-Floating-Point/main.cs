using System;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    byte byteA = 255;   // unsigned byte
    byteA++;
    print(byteA == 0);    // overflow !!!
    byteA--;
    print(byteA == 255);

    int ix = 128; // sbyte의 최대값 127보다 1 큰 수: 00000000 00000000 00000000 10000000
    print(Convert.ToString(ix, 2) == "10000000");   
         
    sbyte sy = (sbyte)ix; 
    print(sy == -128);  // -128 출력: 10000000
    print(Convert.ToString(sy, 2) == "1111111110000000"); // Does not exist for sbyte
    print(Convert.ToString((byte)sy, 2) == "10000000");
    // https://docs.microsoft.com/ko-kr/dotnet/api/system.convert.tostring?view=netframework-4.7.2#System_Convert_ToString_System_SByte_System_IFormatProvider_

    float floatA = 0.9f;
    int intA = (int)floatA;
    print(intA == 0);
    float floatB = 1.1f;
    int intB = (int)floatB;
    print(intB == 1);

    print(12345.ToString() == "12345");
    print(int.Parse("12345") == 12345);
    
    // http://rapapa.net/?p=3414
    // float type으로 표현할 수 없는 실수가 존재한다: 0.1, 4.2 ...
    // float, double type은 오류를 가지고 있다.
    // 좀 더 안전하게 하려면 double 사용해라!
    float a = 69.6875f; 
    double b = (double)a; 
    print(a == b); 
    
    // https://www.h-schmidt.net/FloatConverter/IEEE754.html
    const float x = 4.2f;     // Value actually stored in float: 4.19999980926513671875
    double y = (double)x; 
    print(y != 4.2); // Why ??????

    string strX = String.Format("{0:G9}", x);
    print( strX == "4.19999981"); 
    print(String.Format("{0}", y) == "4.19999980926514"); 
    print(y == 4.2f);
    
    print(4.19999980926514f == 4.2f);
    print(4.1999998f == 4.2f);
    print(4.19999981f == 4.2f);
    print(4.199999f != 4.2f);
    print(4.19f != 4.2f);

    print((double)x*10);
    int n = (int)(x * 10);  // 4.1999998 * 10
    print(n == 41);       // not 42
    double d = 4.2;
    print((int)(d * 10) == 42);

    double z = 4.2;
    print(String.Format("{0:G9}", z));  

    print(4.2 == 4.2000000000000001);
    print(4.2 != 4.200000000000001);    // float 보다 좀 더 안전하다!

    print(DiscountedPrice1(100, 0.1f) == 89);
    print(DiscountedPrice2(100, 0.1) == 90);
    print(DiscountedPrice3(100, 0.1f) == 90);
    print(DiscountedPrice3(100, 0.01f) == 99);

    const int constIntA = 10000;
    // constIntA = 1;  // error!

  }

  public static int DiscountedPrice1(int fullPrice, float discount) {
    return (int)(fullPrice * (1-discount));
  }
  public static int DiscountedPrice2(int fullPrice, double discount) {
    return (int)(fullPrice * (1-discount));
  }
  public static decimal DiscountedPrice3(int fullPrice, float discount) {
    return (decimal)(fullPrice * (1-discount));
  }    


}