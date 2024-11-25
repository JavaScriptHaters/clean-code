namespace Markdown.Tags;

public class EscapeTag : ITag
{
    public string Head => "";
    public string Tail => "";
    public string MdView => """\""";
    public TagType Type => TagType.Escape;
}