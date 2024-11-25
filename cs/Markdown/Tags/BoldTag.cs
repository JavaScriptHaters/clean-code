using Markdown.Tags;

namespace Markdown.Tags;

public class BoldTag : ITag
{
    public string Head => "<strong>";
    public string Tail => "</strong>";
    public string MdView => "__";
    public TagType Type => TagType.BoldText;
}