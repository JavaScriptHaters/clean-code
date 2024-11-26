namespace Markdown.Tags;

public class EscapeTag : ITag
{
    public string Head => "";
    public string Tail => "";
    public string MdView => """\""";
    public TagType Type => TagType.Escape;
    private Stack<ITag> currentStack;
    public int TokenPosition { get; set; }

    public TagKind TagRule(char ch, int position)
    {
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