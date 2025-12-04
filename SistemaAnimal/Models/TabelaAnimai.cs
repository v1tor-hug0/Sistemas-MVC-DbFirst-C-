using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SistemaAnimal.Models;

public partial class TabelaAnimai
{
    [Key]
    public int Id { get; set; }

    [StringLength(120)]
    public string Nome { get; set; } = null!;

    [StringLength(30)]
    public string Tipo { get; set; } = null!;
}
