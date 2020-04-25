using System;

public class TodoItem 
{
    public TodoItem(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }
    public Guid Id { get; private set; }
    public string Name { get; set; }
    public bool Checked { get; private set; }

    public void Toggle()
    {
        Checked = !Checked;
    }
}