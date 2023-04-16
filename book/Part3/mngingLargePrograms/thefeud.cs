using IField;
using McDroid;
using McPig = McDroid.Pig;

namespace IField
{
    public class Sheep { }
    public class Pig { }
}
namespace McDroid
{
    public class Cow { }
    public class Pig { }
}

namespace book.part3.mngingLargePrograms.thefeud
{
    public class thefeud
    {
        public static void Start()
        {
            Cow cow = new Cow();
            Sheep sheep = new Sheep();
            IField.Pig pig = new IField.Pig();
            McPig pigCool = new McPig(); // alias
        }
    }
}
