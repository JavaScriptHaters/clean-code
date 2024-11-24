using Markdown.Tokens;
using System.Text;

namespace Markdown;

public class Md
{
    public string Render(string text) 
    {
        var textLines = text.Split(Environment.NewLine).ToList();
        var sb = new StringBuilder();
        
        foreach (var line in textLines)
        {
            sb.Append(RenderCurrentString(line));
        }

        return sb.ToString();
    }

    private string RenderCurrentString(string line)
    {
        var tokenizer = new Tokenizer(line);
        return GenerateHtml(line, tokenizer.TokenizeLine());
    }

    private string GenerateHtml(string line, List<ITokenPosition> Tokens)
    {
        // TODO some logic
        throw new NotImplementedException();
    }
}