namespace Markdown.Tokens;

public class EscapeToken : SingleToken
{
    public override string MdView => """\""";
    public override string HtmlTagOpen => "";
}