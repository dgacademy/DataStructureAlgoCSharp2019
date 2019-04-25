using System;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    print(Vector3.forward.magnitude == 1f);
    // dir.magnitude = 10; // error!
    print((-Vector3.one).ToString() == "-1,-1,-1");

    print( (Vector3.right + Vector3.up).ToString() == "1,1,0");

    Vector3 a = new Vector3(2f, 2f, 0);
    Vector3 b = new Vector3(2f, 0f, 0f);
    print( Vector3.Distance(a, b) == 2f );

    print( a.ToString() == "2,2,0");
    print( (a + b).ToString() == "4,2,0" );   // operator+()

    print( (2f*a).ToString() == "4,4,0" );
    print( (a*2f).ToString() == "4,4,0" );

    print( b.normalized.ToString() == "1,0,0");
    print( (3*b).normalized.ToString() == "1,0,0");

    print( Vector3.Angle(Vector3.right, Vector3.up) == 90);
    print( Vector3.Angle(a, Vector3.right) == 45);
    print( Vector3.Angle(Vector3.right, a) == 45);
    print( Vector3.Angle(Vector3.right, Vector3.left) == 180);
    print( Vector3.Angle(Vector3.right, Vector3.right) == 0);
    print( Vector3.Angle(Vector3.down, Vector3.right) == 90);
    
    print( Vector3.Dot(Vector3.right, Vector3.right) == 1);
    print( Vector3.Dot(Vector3.right, Vector3.up) == 0);
    print( Vector3.Dot(Vector3.right, Vector3.left) == -1);
  }
}

public class Mathf {
  public static double Rad2Deg = 360/(2*Math.PI);
  public static double Deg2Rad = (2 * Math.PI * d) / 360;
}

public class Vector3 {
  public static readonly Vector3 zero = new Vector3(0f, 0f, 0f);
  public static readonly Vector3 one = new Vector3(1f, 1f, 1f);
  public static readonly Vector3 forward = new Vector3(0f, 0f, 1f);
  public static readonly Vector3 back = -forward;
  public static readonly Vector3 right = new Vector3(1f, 0f, 0f);
  public static readonly Vector3 left = -right;
  public static readonly Vector3 up = new Vector3(0f, 1f, 0f);
  public static readonly Vector3 down = -up;

  public float x { get; set; }
  public float y { get; set; }
  public float z { get; set; }

  public override string ToString() {
    return $"{x},{y},{z}";
  }

  public float magnitude { 
    get { return Math.Abs((float)Math.Sqrt(x*x + y*y + z*z)); }
  }

  public Vector3 normalized {
    get { return this * (1 / this.magnitude); }
  }

  public Vector3(float _x, float _y, float _z) {
    x = _x; y = _y; z = _z;
  }

  public static float Distance(Vector3 a, Vector3 b) {
    return (a-b).magnitude;
  }

  public static float Angle(Vector3 a, Vector3 b) {
    Vector3 na = a.normalized;
    Vector3 nb = b.normalized;
    return (float)(Math.Acos(Dot(na, nb)) * Mathf.Rad2Deg);
    //return (float)(Math.Acos(na.x*nb.x + na.y*nb.y + na.z*nb.z) * Mathf.Rad2Deg);
  }  

  public static Vector3 operator+(Vector3 a, Vector3 b) {
    return new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
  }

  public static Vector3 operator-(Vector3 a, Vector3 b) {
    return (a + -b);
  }

  public static Vector3 operator-(Vector3 a) {
    return new Vector3(-a.x, -a.y, -a.z);
  }

  public static Vector3 operator*(float d, Vector3 a) {
    return new Vector3(d*a.x, d*a.y, d*a.z);
  }
  
  public static Vector3 operator*(Vector3 a, float d) {
    return d*a;
  }    

  public static float Dot(Vector3 a, Vector3 b) {
    return a.x*b.x + a.y*b.y + a.z*b.z;
  }

}