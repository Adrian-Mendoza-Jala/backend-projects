class Program_Stacks
{
    static void Main()
    {
        TextEditor textEditor = new TextEditor();
        textEditor.Type("Hi, ");
        textEditor.Display();
        textEditor.Type("Mom!");
        textEditor.Display();
        textEditor.Undo();
        textEditor.Display();
    }
}
