using Simsy.Models;

namespace Simsy.Interface
{
    public interface INPC
    {
        string Name { get; set; }
        int Age { get; set; }
        int RelationshipLevel { get; set; }

        void Greet(Person character);
        void Talk(Person character);
        void GiveGift(Person character);
    }
}
