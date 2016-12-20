using ReflexingAdvancedGod.Creations;

namespace ReflexingAdvancedGod
{
    internal interface IGod
    {
        Human CreateHuman();
        IHasName Couple(Human first, Human second);
    }
}