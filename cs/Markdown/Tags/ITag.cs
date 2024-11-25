namespace Markdown.Tags;

public interface ITag
{
    public string MdView { get; }
    public string Head { get;}
    public string Tail { get;}
    public TagType Type { get; }
}