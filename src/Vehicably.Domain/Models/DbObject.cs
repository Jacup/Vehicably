﻿namespace Vehicably.Domain.Models;

public class DbObject
{
    public Guid Id { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }
}
