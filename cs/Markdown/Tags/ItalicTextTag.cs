using Markdown.Tags;

namespace Markdown.Tags;

public class ItalicTextTag : ITag
{
    public string Head => "<em>";
    public string Tail => "</em>";
    public string MdView => "_";
    public TagType Type => TagType.ItalicText;
}