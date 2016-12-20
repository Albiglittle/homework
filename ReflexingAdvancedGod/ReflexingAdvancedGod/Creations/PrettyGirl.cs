using ReflexingAdvancedGod.Attributes;

namespace ReflexingAdvancedGod.Creations
{
    [Couple(Pair = "Student", Probability = 0.4, ChildType = "Girl")]
    [Couple(Pair = "Botan", Probability = 0.1, ChildType = "SmartGirl")]
    internal sealed class PrettyGirl : Girl
    {
        internal PrettyGirl(string name) : base(name) { }
    }
}