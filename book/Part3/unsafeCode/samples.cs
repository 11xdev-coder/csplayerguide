namespace book.part3.unsafeCode.samples;


public class samples
{
    public unsafe static void Start()
    {
        // actions that allow you to modify data directly is called unsafe code
        // unsafe { do unsafe actions here }
        int x;
        unsafe
        {
            int* p; // pointer to an integer 
            
            // Address-of operator. gets address of variable and returns it
            // get an address to int x
            int* pointerToX = &x;
            
            // indirection operator
            *pointerToX = 3; // same as x = 3;
            
            // pointer member access operator: allows access to members through a pointer
            pointerToX->GetType(); // same as x.GetType();
        }
    }
}