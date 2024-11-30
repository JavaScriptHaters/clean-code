using Markdown.Tags;
using Microsoft.VisualBasic;

namespace Markdown.Tags;

public class ItalicTextTag : ITag
{
    public string Head => "<em>";
    public string Tail => "</em>";
    public string MdView => "_";
    public TagType Type => TagType.ItalicText;

    public int InputStateNumber { get; } = 1;
    public int[] SubOutputStateNumbers { get; } = Array.Empty<int>();
    public int OutputStateNumber { get; } = 4;

    //private bool state;
    //private Stack<ITag> currentStack;
    //private int startPosition;
    //public int TokenPosition { get; set; }

    private static Dictionary<int, Dictionary<SymbolStatus, int>> states = new();

    public Dictionary<int, Dictionary<SymbolStatus, int>> States { get; } = InitialzeStates();

    public SymbolStatus[] UsedSymbols { get; } =
    {
        SymbolStatus.text, SymbolStatus.digit, SymbolStatus.underscore
        , SymbolStatus.eof, SymbolStatus.newline, SymbolStatus.space
    };

    public static Dictionary<int, Dictionary<SymbolStatus, int>> InitialzeStates()
    {
        states.Add(0, new Dictionary<SymbolStatus, int>());
        states.Add(1, new Dictionary<SymbolStatus, int>());
        states.Add(2, new Dictionary<SymbolStatus, int>());
        states.Add(3, new Dictionary<SymbolStatus, int>());
        states.Add(4, new Dictionary<SymbolStatus, int>());

        states[0].Add(SymbolStatus.text, 0);
        states[0].Add(SymbolStatus.digit, 0);
        states[0].Add(SymbolStatus.underscore, 1);
        states[0].Add(SymbolStatus.backslash, 0);
        states[0].Add(SymbolStatus.eof, 0);
        states[0].Add(SymbolStatus.newline, 0);
        states[0].Add(SymbolStatus.space, 0);

        // Начало
        states[1].Add(SymbolStatus.text, 2);
        states[1].Add(SymbolStatus.digit, 0);
        states[1].Add(SymbolStatus.underscore, 0);
        states[1].Add(SymbolStatus.backslash, 2);
        states[1].Add(SymbolStatus.eof, 0);
        states[1].Add(SymbolStatus.newline, 0);
        states[1].Add(SymbolStatus.space, 0);

        states[2].Add(SymbolStatus.text, 2);
        states[2].Add(SymbolStatus.digit, 0);
        states[2].Add(SymbolStatus.underscore, 3);
        states[2].Add(SymbolStatus.backslash, 2);
        states[2].Add(SymbolStatus.eof, 0);
        states[2].Add(SymbolStatus.newline, 0);
        states[2].Add(SymbolStatus.space, 0);

        states[3].Add(SymbolStatus.text, 4);
        states[3].Add(SymbolStatus.digit, 0);
        states[3].Add(SymbolStatus.underscore, 0);
        states[3].Add(SymbolStatus.backslash, 5);
        states[3].Add(SymbolStatus.eof, 4);
        states[3].Add(SymbolStatus.newline, 4);
        states[3].Add(SymbolStatus.space, 4);

        // 4 состояние выхода
        states[4].Add(SymbolStatus.text, 0);
        states[4].Add(SymbolStatus.digit, 0);
        states[4].Add(SymbolStatus.underscore, 0);
        states[4].Add(SymbolStatus.backslash, 0);
        states[4].Add(SymbolStatus.eof, 0);
        states[4].Add(SymbolStatus.newline, 0);
        states[4].Add(SymbolStatus.space, 0);

        return states;
    }

    //private int gloabalState;
    //public int[] Positions { get; set; } = { 0, 0 };
    //public int[] MdLen { get; set; } = { 0, 0 };
    //public char[] PrevSymbols { get; set; } = { ' ', ' ' };

    //public TagKind TagRule(char ch, int position)
    //{
    //    gloabalState = states[gloabalState][SymbolStatusParser.ParseSymbolStatus(ch)];
    //    if (gloabalState == 1)
    //    {
    //        Positions[0] = position;
    //        MdLen[0] = 1;
    //        PrevSymbols[0] = ch;
    //        return TagKind.Open;
    //    }

    //    if (gloabalState == 4)
    //    {
    //        Positions[1] = position;
    //        MdLen[1] = 1;
    //        PrevSymbols[1] = ch;
    //        return TagKind.Close;
    //    }
    //    return TagKind.None;
    //}

    //public ITag CreateNewTag()
    //{
    //    return new ItalicTextTag();
    //}

    //public void GetCurrentStack(in Stack<ITag> stack)
    //{
    //    currentStack = stack;
    //}

    //public void ResetRule()
    //{
    //    state = false;
    //}
}