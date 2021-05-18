using System;
using System.Collections.Generic;

public class DbContext : IDisposable
{
    // This class only exists so code builds, it isn't a real database context.
    public DbContext(string conn) { }

    public List<Consultant> Consultants { get; set; }

    public void Dispose() { }
}
