using InGodWeTrust.Humans;

namespace InGodWeTrust
{
    internal interface IGod
    {
        Human CreateHuman();
        Human CreateHuman(Gender gender);
        Human CreatePair(Human human);
    }
}