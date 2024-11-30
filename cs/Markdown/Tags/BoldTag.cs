using Markdown.Tags;

namespace Markdown.Tags;

public class BoldTag : ITag
{
    public string Head => "<strong>";
    public string Tail => "</strong>";
    public string MdView => "__";
    public TagType Type => TagType.BoldText;
    //private int state;
    //private Stack<ITag> currentStack;
    //public int TokenPosition { get; set; }

    public int InputStateNumber { get; } = 2;
    public int[] SubOutputStateNumbers { get; } = {11, 16};
    public int OutputStateNumber { get; } = 21;

    private static Dictionary<int, Dictionary<SymbolStatus, int>> states = new();

    public Dictionary<int, Dictionary<SymbolStatus, int>> States { get; } = InitialzeStates();

    public SymbolStatus[] UsedSymbols { get; } =
    {
        SymbolStatus.text, SymbolStatus.digit, SymbolStatus.underscore
        , SymbolStatus.eof, SymbolStatus.newline, SymbolStatus.space,
        SymbolStatus.anotherSymbol
    };

    public static Dictionary<int, Dictionary<SymbolStatus, int>> InitialzeStates()
    {
        states.Add(0, new Dictionary<SymbolStatus, int>());
        states.Add(1, new Dictionary<SymbolStatus, int>());
        states.Add(2, new Dictionary<SymbolStatus, int>());
        states.Add(3, new Dictionary<SymbolStatus, int>());
        states.Add(4, new Dictionary<SymbolStatus, int>());
        states.Add(5, new Dictionary<SymbolStatus, int>());
        states.Add(6, new Dictionary<SymbolStatus, int>());
        states.Add(7, new Dictionary<SymbolStatus, int>());
        states.Add(8, new Dictionary<SymbolStatus, int>());
        states.Add(9, new Dictionary<SymbolStatus, int>());
        states.Add(10, new Dictionary<SymbolStatus, int>());
        states.Add(11, new Dictionary<SymbolStatus, int>());
        states.Add(12, new Dictionary<SymbolStatus, int>());
        states.Add(13, new Dictionary<SymbolStatus, int>());
        states.Add(14, new Dictionary<SymbolStatus, int>());
        states.Add(15, new Dictionary<SymbolStatus, int>());
        states.Add(16, new Dictionary<SymbolStatus, int>());
        states.Add(17, new Dictionary<SymbolStatus, int>());
        states.Add(18, new Dictionary<SymbolStatus, int>());
        states.Add(19, new Dictionary<SymbolStatus, int>());
        states.Add(20, new Dictionary<SymbolStatus, int>());
        states.Add(21, new Dictionary<SymbolStatus, int>());

        states.Add(22, new Dictionary<SymbolStatus, int>());
        states.Add(23, new Dictionary<SymbolStatus, int>());
        states.Add(24, new Dictionary<SymbolStatus, int>());
        states.Add(25, new Dictionary<SymbolStatus, int>());
        states.Add(26, new Dictionary<SymbolStatus, int>());
        states.Add(27, new Dictionary<SymbolStatus, int>());
        states.Add(28, new Dictionary<SymbolStatus, int>());
        states.Add(29, new Dictionary<SymbolStatus, int>());
        states.Add(30, new Dictionary<SymbolStatus, int>());
        states.Add(31, new Dictionary<SymbolStatus, int>());

        states[0].Add(SymbolStatus.text, 0);
        states[0].Add(SymbolStatus.digit, 0);
        states[0].Add(SymbolStatus.underscore, 1);
        states[0].Add(SymbolStatus.eof, 0);
        states[0].Add(SymbolStatus.newline, 0);
        states[0].Add(SymbolStatus.space, 0);
        states[0].Add(SymbolStatus.anotherSymbol, 0);

        states[1].Add(SymbolStatus.text, 9);
        states[1].Add(SymbolStatus.digit, 0);
        states[1].Add(SymbolStatus.underscore, 2);
        states[1].Add(SymbolStatus.eof, 0);
        states[1].Add(SymbolStatus.newline, 0);
        states[1].Add(SymbolStatus.space, 9);
        states[1].Add(SymbolStatus.anotherSymbol, 9);

        // Tag Open
        states[2].Add(SymbolStatus.text, 3);
        states[2].Add(SymbolStatus.digit, 0);
        states[2].Add(SymbolStatus.underscore, 7);
        states[2].Add(SymbolStatus.eof, 0);
        states[2].Add(SymbolStatus.newline, 0);
        states[2].Add(SymbolStatus.space, 4);
        states[2].Add(SymbolStatus.anotherSymbol, 3);

        states[3].Add(SymbolStatus.text, 3);
        states[3].Add(SymbolStatus.digit, 0);
        states[3].Add(SymbolStatus.underscore, 6);
        states[3].Add(SymbolStatus.eof, 0);
        states[3].Add(SymbolStatus.newline, 0);
        states[3].Add(SymbolStatus.space, 4);
        states[3].Add(SymbolStatus.anotherSymbol, 3);

        states[4].Add(SymbolStatus.text, 5);
        states[4].Add(SymbolStatus.digit, 0);
        states[4].Add(SymbolStatus.underscore, 1);
        states[4].Add(SymbolStatus.eof, 0);
        states[4].Add(SymbolStatus.newline, 0);
        states[4].Add(SymbolStatus.space, 4);
        states[4].Add(SymbolStatus.anotherSymbol, 5);

        states[5].Add(SymbolStatus.text, 5);
        states[5].Add(SymbolStatus.digit, 0);
        states[5].Add(SymbolStatus.underscore, 6);
        states[5].Add(SymbolStatus.eof, 0);
        states[5].Add(SymbolStatus.newline, 0);
        states[5].Add(SymbolStatus.space, 4);
        states[5].Add(SymbolStatus.anotherSymbol, 5);

        states[6].Add(SymbolStatus.text, 17);
        states[6].Add(SymbolStatus.digit, 0);
        states[6].Add(SymbolStatus.underscore, 21);
        states[6].Add(SymbolStatus.eof, 0);
        states[6].Add(SymbolStatus.newline, 17);
        states[6].Add(SymbolStatus.space, 4);
        states[6].Add(SymbolStatus.anotherSymbol, 17);

        states[7].Add(SymbolStatus.text, 0);
        states[7].Add(SymbolStatus.digit, 0);
        states[7].Add(SymbolStatus.underscore, 8);
        states[7].Add(SymbolStatus.eof, 0);
        states[7].Add(SymbolStatus.newline, 0);
        states[7].Add(SymbolStatus.space, 0);
        states[7].Add(SymbolStatus.anotherSymbol, 0);

        states[8].Add(SymbolStatus.text, 0);
        states[8].Add(SymbolStatus.digit, 0);
        states[8].Add(SymbolStatus.underscore, 0);
        states[8].Add(SymbolStatus.eof, 0);
        states[8].Add(SymbolStatus.newline, 0);
        states[8].Add(SymbolStatus.space, 0);
        states[8].Add(SymbolStatus.anotherSymbol, 0);

        states[9].Add(SymbolStatus.text, 9);
        states[9].Add(SymbolStatus.digit, 0);
        states[9].Add(SymbolStatus.underscore, 10);
        states[9].Add(SymbolStatus.eof, 0);
        states[9].Add(SymbolStatus.newline, 0);
        states[9].Add(SymbolStatus.space, 9);
        states[9].Add(SymbolStatus.anotherSymbol, 9);

        states[10].Add(SymbolStatus.text, 0);
        states[10].Add(SymbolStatus.digit, 0);
        states[10].Add(SymbolStatus.underscore, 11);
        states[10].Add(SymbolStatus.eof, 0);
        states[10].Add(SymbolStatus.newline, 0);
        states[10].Add(SymbolStatus.space, 0);
        states[10].Add(SymbolStatus.anotherSymbol, 0);

        // TagSubOpen
        states[11].Add(SymbolStatus.text, 12);
        states[11].Add(SymbolStatus.digit, 0);
        states[11].Add(SymbolStatus.underscore, 22);
        states[11].Add(SymbolStatus.eof, 0);
        states[11].Add(SymbolStatus.newline, 0);
        states[11].Add(SymbolStatus.space, 13);
        states[11].Add(SymbolStatus.anotherSymbol, 12);

        states[12].Add(SymbolStatus.text, 12);
        states[12].Add(SymbolStatus.digit, 0);
        states[12].Add(SymbolStatus.underscore, 15); 
        states[12].Add(SymbolStatus.eof, 0);
        states[12].Add(SymbolStatus.newline, 0);
        states[12].Add(SymbolStatus.space, 13);
        states[12].Add(SymbolStatus.anotherSymbol, 12);

        states[13].Add(SymbolStatus.text, 14);
        states[13].Add(SymbolStatus.digit, 0);
        states[13].Add(SymbolStatus.underscore, 9);
        states[13].Add(SymbolStatus.eof, 0);
        states[13].Add(SymbolStatus.newline, 0);
        states[13].Add(SymbolStatus.space, 13);
        states[13].Add(SymbolStatus.anotherSymbol, 14);

        states[14].Add(SymbolStatus.text, 14);
        states[14].Add(SymbolStatus.digit, 0);
        states[14].Add(SymbolStatus.underscore, 15);
        states[14].Add(SymbolStatus.eof, 0);
        states[14].Add(SymbolStatus.newline, 0);
        states[14].Add(SymbolStatus.space, 13);
        states[14].Add(SymbolStatus.anotherSymbol, 14);

        states[15].Add(SymbolStatus.text, 0);
        states[15].Add(SymbolStatus.digit, 0);
        states[15].Add(SymbolStatus.underscore, 16);
        states[15].Add(SymbolStatus.eof, 0);
        states[15].Add(SymbolStatus.newline, 0);
        states[15].Add(SymbolStatus.space, 0);
        states[15].Add(SymbolStatus.anotherSymbol, 0);

        // TagSubClose
        states[16].Add(SymbolStatus.text, 9);
        states[16].Add(SymbolStatus.digit, 0);
        states[16].Add(SymbolStatus.underscore, 16);
        states[16].Add(SymbolStatus.eof, 21);
        states[16].Add(SymbolStatus.newline, 21);
        states[16].Add(SymbolStatus.space, 9);
        states[16].Add(SymbolStatus.anotherSymbol, 9);

        states[17].Add(SymbolStatus.text, 17);
        states[17].Add(SymbolStatus.digit, 0);
        states[17].Add(SymbolStatus.underscore, 20);
        states[17].Add(SymbolStatus.eof, 0);
        states[17].Add(SymbolStatus.newline, 0);
        states[17].Add(SymbolStatus.space, 18);
        states[17].Add(SymbolStatus.anotherSymbol, 17);

        states[18].Add(SymbolStatus.text, 19);
        states[18].Add(SymbolStatus.digit, 0);
        states[18].Add(SymbolStatus.underscore, 20);
        states[18].Add(SymbolStatus.eof, 0);
        states[18].Add(SymbolStatus.newline, 0);
        states[18].Add(SymbolStatus.space, 18);
        states[18].Add(SymbolStatus.anotherSymbol, 19);

        states[19].Add(SymbolStatus.text, 19);
        states[19].Add(SymbolStatus.digit, 0);
        states[19].Add(SymbolStatus.underscore, 20);
        states[19].Add(SymbolStatus.eof, 0);
        states[19].Add(SymbolStatus.newline, 0);
        states[19].Add(SymbolStatus.space, 18);
        states[19].Add(SymbolStatus.anotherSymbol, 19);

        states[20].Add(SymbolStatus.text, 3);
        states[20].Add(SymbolStatus.digit, 0);
        states[20].Add(SymbolStatus.underscore, 24);
        states[20].Add(SymbolStatus.eof, 0);
        states[20].Add(SymbolStatus.newline, 0);
        states[20].Add(SymbolStatus.space, 4);
        states[20].Add(SymbolStatus.anotherSymbol, 3);

        // TagClose
        states[21].Add(SymbolStatus.text, 0);
        states[21].Add(SymbolStatus.digit, 0);
        states[21].Add(SymbolStatus.underscore, 1);
        states[21].Add(SymbolStatus.eof, 0);
        states[21].Add(SymbolStatus.newline, 0);
        states[21].Add(SymbolStatus.space, 0);
        states[21].Add(SymbolStatus.anotherSymbol, 0);

        states[22].Add(SymbolStatus.text, 9);
        states[22].Add(SymbolStatus.digit, 0);
        states[22].Add(SymbolStatus.underscore, 9);
        states[22].Add(SymbolStatus.eof, 0);
        states[22].Add(SymbolStatus.newline, 0);
        states[22].Add(SymbolStatus.space, 9);
        states[22].Add(SymbolStatus.anotherSymbol, 9);

        states[23].Add(SymbolStatus.text, 11);
        states[23].Add(SymbolStatus.digit, 0);
        states[23].Add(SymbolStatus.underscore, 11);
        states[23].Add(SymbolStatus.eof, 0);
        states[23].Add(SymbolStatus.newline, 0);
        states[23].Add(SymbolStatus.space, 11);
        states[23].Add(SymbolStatus.anotherSymbol, 11);

        states[24].Add(SymbolStatus.text, 26);
        states[24].Add(SymbolStatus.digit, 0);
        states[24].Add(SymbolStatus.underscore, 25);
        states[24].Add(SymbolStatus.eof, 0);
        states[24].Add(SymbolStatus.newline, 0);
        states[24].Add(SymbolStatus.space, 27);
        states[24].Add(SymbolStatus.anotherSymbol, 26);

        states[25].Add(SymbolStatus.text, 17);
        states[25].Add(SymbolStatus.digit, 0);
        states[25].Add(SymbolStatus.underscore, 17);
        states[25].Add(SymbolStatus.eof, 0);
        states[25].Add(SymbolStatus.newline, 0);
        states[25].Add(SymbolStatus.space, 17);
        states[25].Add(SymbolStatus.anotherSymbol, 17);

        states[26].Add(SymbolStatus.text, 26);
        states[26].Add(SymbolStatus.digit, 0);
        states[26].Add(SymbolStatus.underscore, 29);
        states[26].Add(SymbolStatus.eof, 0);
        states[26].Add(SymbolStatus.newline, 0);
        states[26].Add(SymbolStatus.space, 27);
        states[26].Add(SymbolStatus.anotherSymbol, 26);

        states[27].Add(SymbolStatus.text, 28);
        states[27].Add(SymbolStatus.digit, 0);
        states[27].Add(SymbolStatus.underscore, 24);
        states[27].Add(SymbolStatus.eof, 0);
        states[27].Add(SymbolStatus.newline, 0);
        states[27].Add(SymbolStatus.space, 27);
        states[27].Add(SymbolStatus.anotherSymbol, 28);

        states[28].Add(SymbolStatus.text, 28);
        states[28].Add(SymbolStatus.digit, 0);
        states[28].Add(SymbolStatus.underscore, 29);
        states[28].Add(SymbolStatus.eof, 0);
        states[28].Add(SymbolStatus.newline, 0);
        states[28].Add(SymbolStatus.space, 27);
        states[28].Add(SymbolStatus.anotherSymbol, 28);

        states[29].Add(SymbolStatus.text, 0);
        states[29].Add(SymbolStatus.digit, 0);
        states[29].Add(SymbolStatus.underscore, 30);
        states[29].Add(SymbolStatus.eof, 0);
        states[29].Add(SymbolStatus.newline, 0);
        states[29].Add(SymbolStatus.space, 0);
        states[29].Add(SymbolStatus.anotherSymbol, 0);

        states[30].Add(SymbolStatus.text, 17);
        states[30].Add(SymbolStatus.digit, 0);
        states[30].Add(SymbolStatus.underscore, 31);
        states[30].Add(SymbolStatus.eof, 0);
        states[30].Add(SymbolStatus.newline, 0);
        states[30].Add(SymbolStatus.space, 18);
        states[30].Add(SymbolStatus.anotherSymbol, 17);

        states[31].Add(SymbolStatus.text, 26);
        states[31].Add(SymbolStatus.digit, 0);
        states[31].Add(SymbolStatus.underscore, 31);
        states[31].Add(SymbolStatus.eof, 0);
        states[31].Add(SymbolStatus.newline, 0);
        states[31].Add(SymbolStatus.space, 27);
        states[31].Add(SymbolStatus.anotherSymbol, 26);

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
    //    return new BoldTag();
    //}

    //public void GetCurrentStack(in Stack<ITag> stack)
    //{
    //    currentStack = stack;
    //}

    //public void ResetRule()
    //{
    //    state = 0;
    //}
}