namespace Markdown.Tags;

public interface ITag
{
    public string MdView { get; }
    public string Head { get;}
    public string Tail { get;}
    public TagType Type { get; }
    public int TokenPosition { get; set; }

    public TagKind TagRule(char ch, int position);
    public ITag CreateNewTag();
    public void GetCurrentStack(in Stack<ITag> stack);
    public void ResetRule();
}