namespace Markdown.Tags;

public class EscapeTag : ITag
{
    public string Head => "";
    private string symbol;
    public string Tail => symbol;
    public string MdView => """\""";
    public TagType Type => TagType.Escape;
    private Stack<ITag> currentStack;
    public int TokenPosition { get; set; }
    private char previousCharecter;

    public TagKind TagRule(char ch, int position)
    {
        if (previousCharecter == '\\' && (ch == '_' || ch == '\\'))
        {
            TokenPosition = position;
            symbol = ch.ToString();
            previousCharecter = ch;
            return TagKind.Close;
        }
        if (ch == '\\')
        {
            TokenPosition = position;
            previousCharecter = ch;
            return TagKind.Open;
        }
        previousCharecter = ch;
        return TagKind.None;
    }

    public ITag CreateNewTag()
    {
        return new EscapeTag();
    }
    public void GetCurrentStack(in Stack<ITag> stack)
    {
        currentStack = stack;
    }

    public void ResetRule()
    {
    }
}