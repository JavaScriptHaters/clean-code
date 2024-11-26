using Markdown.Tags;

namespace Markdown.Tags;

public class BoldTag : ITag
{
    public string Head => "<strong>";
    public string Tail => "</strong>";
    public string MdView => "__";
    public TagType Type => TagType.BoldText;
    private int state;
    private Stack<ITag> currentStack;
    public int TokenPosition { get; set; }

    public TagKind TagRule(char ch, int position)
    {
        if (state == 2 && char.IsLetter(ch) && currentStack.Count == 0)
        {
            state = 0;
            currentStack.Push(CreateNewTag());
            return TagKind.Open;
        }
        if (state == 2 && (char.IsLetter(ch) || ch == ' '))
        {
            state = 0;
            currentStack.Pop();
            return TagKind.Close;
        }
        if (state == 1 && ch == '_')
        {
            state = 2;
        }
        else if (ch == '_')
        {
            state = 1;
            TokenPosition = position;
        }
        if ((state == 1 || state == 2) && ch != '_')
        {
            state = 0;
        }
        return TagKind.None;
    }

    public ITag CreateNewTag()
    {
        return new BoldTag();
    }

    public void GetCurrentStack(in Stack<ITag> stack)
    {
        currentStack = stack;
    }

    public void ResetRule()
    {
        state = 0;
    }
}