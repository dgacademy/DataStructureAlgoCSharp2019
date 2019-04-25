using System;

// class Point 
// {
//     int x; 
//     int y;
// }

class Point 
{
    protected int x; 
    protected int y;
}

class DerivedPoint: Point 
{
    static void Main() 
    {
        DerivedPoint dpoint = new DerivedPoint();

        // Direct access to protected members:
        dpoint.x = 10;
        dpoint.y = 15;
        Console.WriteLine("x = {0}, y = {1}", dpoint.x, dpoint.y); 
    }
}