namespace Markdown.Tags;

public interface ITag
{
    public string MdView { get; }
    public string Head { get;}
    public string Tail { get;}
    public TagType Type { get; }

    public SymbolStatus[] UsedSymbols { get; }
    public Dictionary<int, Dictionary<SymbolStatus, int>> States { get; }

    public int InputStateNumber { get; }
    public int[] SubOutputStateNumbers { get; }
    public int OutputStateNumber { get; }

    // public int TokenPosition { get; set; }

    //public TagKind TagRule(char ch, int position);
    // public ITag CreateNewTag();
    // public void GetCurrentStack(in Stack<ITag> stack);
    // public void ResetRule();

    // public void InitialzeStates();
    // public int[] Positions { get; set; }
    // public char[] PrevSymbols { get; set; }
}