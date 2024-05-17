// Camera.csx
// Run:
// % dotnet script Camera.csx

//using UnityEngine;

// A typical Unity Script class
public class Camera // : MonoBehaviour
{
    //[SerializeField]
    private int width = 720;
    //[SerializeField]
    private int height = 1280;

    /* Normal C# way
    private (int,int) GetBaseRatio(int width, int height)
    {
        // ...
        return (0,0);
    }*/

    public void Awake()
    {
        (int rw, int rh) = 
            CameraModule.GetBaseRatio(this.width, this.height);
        Console.WriteLine($"width : height = {rw} : {rh}");
    }

    // public void Start() { }    
}

// C#/F# hybrid way
// You can easily convert this static class into a F# module later
public static class CameraModule
{
    // Greatest Common Divisor (GCD)
    // int->int -> int   // Type annotation comments help us in C# as well.
    public static int Gcd(int a, int b)
    {
        if (b == 0)
        {
            return a;
        }
        return Gcd(b, a % b);
    }
    
    // int->int -> (int,int)
    public static (int,int) GetBaseRatio(int width, int height)
    {
        int gcd = Gcd(width, height);
        return (width / gcd, height / gcd);
    }
}

public static class MathModule
{
    // You can easily move all methods from a module to another module
    // because all methods are static. 
    // This is really convenient for refactoring.
    public static int Gcd(int a, int b)
    {
        if (b == 0)
        {
            return a;
        }
        return Gcd(b, a % b);
    }    
}

var cam = new Camera();
cam.Awake(); 
// Output:  width : height = 9 : 16
