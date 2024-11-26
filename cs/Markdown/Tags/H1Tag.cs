using Markdown.Tags;

namespace Markdown.Tags;

public class H1Tag : ITag
{
    public string Head => "<h1>";
    public string Tail => "</h1>";
    public string MdView => "# ";
    public TagType Type => TagType.Header;
    private Stack<ITag> currentStack;
    public int TokenPosition { get; set; }

    public TagKind TagRule(char ch, int position)
    {
        return TagKind.None;
    }

    public ITag CreateNewTag()
    {
        return new H1Tag();
    }

    public void GetCurrentStack(in Stack<ITag> stack)
    {
        currentStack = stack;
    }

    public void ResetRule()
    {
    }
}