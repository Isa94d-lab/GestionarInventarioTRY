using System;

namespace GESTIONINVENTARIOTRY.Domain.Entities;

public class Region
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public int PaisId { get; set; } // FK
    
}