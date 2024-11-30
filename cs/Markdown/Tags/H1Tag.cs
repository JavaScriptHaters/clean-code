using Markdown.Tags;

namespace Markdown.Tags;

public class H1Tag : ITag
{
    public string Head => "<h1>";
    public string Tail => "</h1>";
    public string MdView => "# ";
    public TagType Type => TagType.Header;
    //private Stack<ITag> currentStack;
    //public int TokenPosition { get; set; }

    public int InputStateNumber { get; } = 3;
    public int[] SubOutputStateNumbers { get; } = Array.Empty<int>();
    public int OutputStateNumber { get; } = 5;

    private static Dictionary<int, Dictionary<SymbolStatus, int>> states = new();

    public Dictionary<int, Dictionary<SymbolStatus, int>> States { get; } = InitialzeStates();

    public SymbolStatus[] UsedSymbols { get; } =
    {
        SymbolStatus.eof, SymbolStatus.newline, SymbolStatus.space,
        SymbolStatus.sharp, SymbolStatus.anotherSymbol
    };

    public static Dictionary<int, Dictionary<SymbolStatus, int>> InitialzeStates()
    {
        states.Add(0, new Dictionary<SymbolStatus, int>());
        states.Add(1, new Dictionary<SymbolStatus, int>());
        states.Add(2, new Dictionary<SymbolStatus, int>());
        states.Add(3, new Dictionary<SymbolStatus, int>());
        states.Add(4, new Dictionary<SymbolStatus, int>());
        states.Add(5, new Dictionary<SymbolStatus, int>());

        states[0].Add(SymbolStatus.sharp, 1);
        states[0].Add(SymbolStatus.space, 2);
        states[0].Add(SymbolStatus.newline, 0);
        states[0].Add(SymbolStatus.eof, 0);
        states[0].Add(SymbolStatus.anotherSymbol, 2);

        states[1].Add(SymbolStatus.sharp, 0);
        states[1].Add(SymbolStatus.space, 3);
        states[1].Add(SymbolStatus.newline, 0);
        states[1].Add(SymbolStatus.eof, 0);
        states[1].Add(SymbolStatus.anotherSymbol, 0);

        states[2].Add(SymbolStatus.sharp, 2);
        states[2].Add(SymbolStatus.space, 2);
        states[2].Add(SymbolStatus.newline, 0);
        states[2].Add(SymbolStatus.eof, 0);
        states[2].Add(SymbolStatus.anotherSymbol, 2);

        // Tag Open
        states[3].Add(SymbolStatus.sharp, 4);
        states[3].Add(SymbolStatus.space, 4);
        states[3].Add(SymbolStatus.newline, 5);
        states[3].Add(SymbolStatus.eof, 5);
        states[3].Add(SymbolStatus.anotherSymbol, 4);

        states[4].Add(SymbolStatus.sharp, 4);
        states[4].Add(SymbolStatus.space, 4);
        states[4].Add(SymbolStatus.newline, 5);
        states[4].Add(SymbolStatus.eof, 5);
        states[4].Add(SymbolStatus.anotherSymbol, 4);

        // Tag Close
        states[5].Add(SymbolStatus.sharp, 0);
        states[5].Add(SymbolStatus.space, 0);
        states[5].Add(SymbolStatus.newline, 0);
        states[5].Add(SymbolStatus.eof, 0);
        states[5].Add(SymbolStatus.anotherSymbol, 0);

        return states;
    }
    //public int[] Positions { get; set; } = { 0, 0 };
    //public int[] MdLen { get; set; } = { 0, 0 };
    //public char[] PrevSymbols { get; set; } = { ' ', ' ' };

    //public TagKind TagRule(char ch, int position)
    //{
    //    return TagKind.None;
    //}

    //public ITag CreateNewTag()
    //{
    //    return new H1Tag();
    //}

    //public void GetCurrentStack(in Stack<ITag> stack)
    //{
    //    currentStack = stack;
    //}

    //public void ResetRule()
    //{
    //}
}