using Markdown;

// text \n\n\n _text123_ 
Console.WriteLine(Md.Render("__markdown _bobo_ __ a"));
// _text123_ __markdown__ a