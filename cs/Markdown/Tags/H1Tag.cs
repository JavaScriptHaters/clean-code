using Markdown.Tags;

namespace Markdown.Tags;

public class H1Tag : ITag
{
    public string Head => "<h1>";
    public string Tail => "</h1>";
    public string MdView => "# ";
    public TagType Type => TagType.Header;
}