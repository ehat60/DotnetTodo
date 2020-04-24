using System;

public class TodoItem 
{
    public TodoItem(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool Checked { get; set; }
}